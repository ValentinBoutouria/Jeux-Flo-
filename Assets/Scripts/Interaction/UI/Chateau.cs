using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chateau : MonoBehaviour
{
   
    public int _prix;
    public int _nbChateauAchete;
    public GameObject _validationUI;
    public Selection _selection;
    public GameObject _chateauPrefabLVL1;
    public Gold _gold;
    public int benefice;
    public Compteur _compteur;
    [SerializeField]
    private int _nbChateau = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AjoutRessourcesChateau();

        
    }
    public void AjoutRessourcesChateau()
    {
        if (_compteur.counterAjoutChateau < 0f)
        {
            _compteur.counterAjoutChateau = 9;
            _gold._nbGold = benefice * _nbChateau;
        }
    }
    public void CliqueChateau()
    {
        _nbChateauAchete=_selection.nbGameObjectSelect;
        //_validationUI.SetActive(true);
        if(_gold._nbGold>=_prix*_selection.gameObjectListSelectionne.Count)//si assez d'or pour acheter un chateau
        {
            _gold._nbGold -= _prix * _selection.gameObjectListSelectionne.Count;//on retire le prix des batiments

            foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
            {
                _nbChateau += 1;//on ajoute un chateau
                GameObject GameObjectTemp=Instantiate(_chateauPrefabLVL1,obj.transform.position+new Vector3(0,0.2f,0),Quaternion.Euler(0, -90, 0),obj.transform);
                GameObjectTemp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
                Renderer renderer = obj.GetComponent<Renderer>();//on recupere le renderer
                renderer.material = _selection._matInitial;//on place le mat deselection
                _selection.listeGameObjectNONSelect.Add(obj);
            }
        }
        else
        {
            foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
            {
                Renderer renderer = obj.GetComponent<Renderer>();//on recupere le renderer
                renderer.material = _selection._matInitial;//on place le mat deselection
                _selection.listeGameObjectNONSelect.Add(obj);
            }
            Debug.Log("Pas assez d'or pour acheter cette quantité de chateau");
        }
            _selection.gameObjectListSelectionne.Clear();//clear la liste selectionné dans tout les cas
    }
}
