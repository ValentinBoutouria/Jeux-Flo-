using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison : MonoBehaviour
{

    public int _prix;
    public int _nbMaisonsAchete;
    public GameObject _validationUI;
<<<<<<< HEAD
    public GameObject InstantiateMaison; // Référence vers le prefab de l'objet à instancier
=======
    public Selection _selection;
    public GameObject _maisonPrefabLVL1;
>>>>>>> d6585a054b9a324195ab7a1e4c859ed3a9dd8130

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void CliqueMaison()
    {
        _nbMaisonsAchete=_selection.nbGameObjectSelect;
        _validationUI.SetActive(true);
<<<<<<< HEAD
        InstantiateMaison.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);//changement du scale de la maison
        GameObject Maison = Instantiate(InstantiateMaison, Vector3.zero + new Vector3(0f, 0.2f,0f), Quaternion.identity) ;//a changer



=======
        foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
        {
          GameObject GameObjectTemp=Instantiate(_maisonPrefabLVL1,obj.transform.position+new Vector3(0,0.3f,0),Quaternion.Euler(0, -90, 0),obj.transform);
          GameObjectTemp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
          Renderer renderer = obj.GetComponent<Renderer>();//on recupere le renderer
          renderer.material = _selection._matInitial;//on place le mat deselection
          _selection.listeGameObjectNONSelect.Add(obj);
        }
        _selection.gameObjectListSelectionne.Clear();
>>>>>>> d6585a054b9a324195ab7a1e4c859ed3a9dd8130
    }
}
