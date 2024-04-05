using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermeBouton : MonoBehaviour
{

    public int _prix;
    public int _nbFermeAchete;
    public GameObject _validationUI;
    public Selection _selection;
    public GameObject _fermePrefabLVL1;
    public GameObject _parent;
    public Stone _stone;
    public int benefice;
    

    private int _nbFerme = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //calculBenefice();
        
    }
    void calculBenefice()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        // Parcourir tous les enfants
        foreach (Transform child in children)
        {
            // R�cup�rer le composant "ChildScript" attach� � l'enfant
            InfoFerme _infoFerme = child.GetComponent<InfoFerme>();
            if (_infoFerme != null)
            {
                benefice += _infoFerme.benefice;

            }
      
        }
    }

  
    public void CliqueFerme()
    {
        //_validationUI.SetActive(true);
        if (_stone._nbStone >= _prix * _selection.gameObjectListSelectionne.Count)//si assez d'or pour acheter un chateau
        {
            _nbFermeAchete=_selection.nbGameObjectSelect;
            _stone._nbStone -= _prix * _selection.gameObjectListSelectionne.Count;//on retire le prix des batiments
            foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
            {
                _nbFerme += 1;//on ajoute une ferme
                GameObject GameObjectTemp=Instantiate(_fermePrefabLVL1,obj.transform.position+new Vector3(0,0.1f,0),Quaternion.Euler(0, -90, 0),_parent.transform);
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
            Debug.Log("Pas assez de stone pour acheter cette quantit� de ferme");

        }
        _selection.gameObjectListSelectionne.Clear();
    }
}
