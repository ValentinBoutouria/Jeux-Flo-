using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison : MonoBehaviour
{

    public int _prix;
    public int _nbMaisonsAchete;
    public GameObject _validationUI;
    public Selection _selection;
    public GameObject _maisonPrefabLVL1;
    public GameObject _parent;
    public Ressources _ressources;
    public Compteur _compteur;
    public int benefice;
 
    private int _nbMaison = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AjoutRessourcesMaison();
    }
    public void AjoutRessourcesMaison()
    {
        if (_compteur.counterAjoutRessources>10f)
        {
            _compteur.counterAjoutRessources = 0;
            _ressources._nbWood += benefice * _nbMaison;
        }
    }
    public void CliqueMaison()
    {
        //_validationUI.SetActive(true);
        if (_ressources._nbWood >= _prix * _selection.gameObjectListSelectionne.Count)//si assez de bois pour acheter un chateau
        {
            _nbMaisonsAchete=_selection.nbGameObjectSelect;
            _ressources._nbWood -= _prix * _selection.gameObjectListSelectionne.Count;//on retire le prix des batiments
            foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
            {
                _nbMaison += 1;//on ajoute une maison
                GameObject GameObjectTemp=Instantiate(_maisonPrefabLVL1,obj.transform.position+new Vector3(0,0.3f,0),Quaternion.Euler(0, -90, 0),_parent.transform);
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
            Debug.Log("Pas assez de bois pour acheter cette quantité de maison");

        }
        _selection.gameObjectListSelectionne.Clear();
    }
}
