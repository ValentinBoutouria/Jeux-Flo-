using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferme : MonoBehaviour
{

    public int _prix;
    public int _nbFermeAchete;
    public GameObject _validationUI;
    public Selection _selection;
    public GameObject _fermePrefabLVL1;
    public Stone _stone;
    public int benefice;
    public Compteur _compteur;
    [SerializeField]
    private int _nbFerme = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AjoutRessourcesFerme();
    }
    public void AjoutRessourcesFerme()
    {
        if (_compteur.counterAjoutFerme < 0f)
        {
            _compteur.counterAjoutFerme = 9;
            _stone._nbStone = benefice * _nbFerme;
        }
    }
    public void CliqueFerme()
    {
        _nbFermeAchete=_selection.nbGameObjectSelect;
        //_validationUI.SetActive(true);
        if (_stone._nbStone >= _prix * _selection.gameObjectListSelectionne.Count)//si assez d'or pour acheter un chateau
        {
            _stone._nbStone -= _prix * _selection.gameObjectListSelectionne.Count;//on retire le prix des batiments
            foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
            {
                _nbFerme += 1;//on ajoute une ferme
                GameObject GameObjectTemp=Instantiate(_fermePrefabLVL1,obj.transform.position+new Vector3(0,0.1f,0),Quaternion.Euler(0, -90, 0),obj.transform);
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
            Debug.Log("Pas assez de stone pour acheter cette quantité de ferme");

        }
        _selection.gameObjectListSelectionne.Clear();
    }
}
