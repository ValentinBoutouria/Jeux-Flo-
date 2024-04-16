using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chateau : MonoBehaviour
{
   
    public int _prix;
    public int _nbChateauAchete;
    public GameObject _validationUI;
    public Selection _selection;
    public GameObject _chateauPrefabLVL1;
    public GameObject _parent;

    public Ressources _ressources;
    public int benefice;
    public Compteur _compteur;
    public TMP_Text _textCoutChateau;
  
    private int _nbChateau = 0;
    // Start is called before the first frame update
    void Start()
    {
        CalculPrix();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void CalculPrix()
    {
        if (_nbChateau>0)
        {
            _prix=_prix*(_nbChateau+1);
            
        }
        else
        {
            _prix=100;
        }
        _textCoutChateau.text=_prix+" Gold";
    }
  
    public void CliqueChateau()
    {
        //_validationUI.SetActive(true);
        
        if(_ressources._nbGold>=_prix*_selection.gameObjectListSelectionne.Count)//si assez d'or pour acheter un chateau
        {
            _nbChateauAchete=_selection.nbGameObjectSelect;
            _ressources._nbGold -= _prix * _selection.gameObjectListSelectionne.Count;//on retire le prix des batiments

            foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
            {
                _nbChateau += 1;//on ajoute un chateau
                CalculPrix();
                GameObject GameObjectTemp=Instantiate(_chateauPrefabLVL1,obj.transform.position+new Vector3(0,0.2f,0),Quaternion.Euler(0, -90, 0),_parent.transform);
                GameObjectTemp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
                Renderer renderer = obj.GetComponent<Renderer>();//on recupere le renderer
                renderer.material = _selection._matInitial;//on place le mat deselection
                _selection.listeGameObjectBatimentPresent.Add(obj);
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
            Debug.Log("Pas assez d'or pour acheter cette quantit� de chateau");
        }
            _selection.gameObjectListSelectionne.Clear();//clear la liste selectionn� dans tout les cas
    }
}
