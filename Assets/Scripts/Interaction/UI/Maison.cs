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
        foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
        {
          GameObject GameObjectTemp=Instantiate(_maisonPrefabLVL1,obj.transform.position+new Vector3(0,0.1f,0),Quaternion.Euler(0, -90, 0),obj.transform);
          GameObjectTemp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
          Renderer renderer = obj.GetComponent<Renderer>();//on recupere le renderer
          renderer.material = _selection._matInitial;//on place le mat deselection

        }
        _selection.gameObjectListSelectionne.Clear();
    }
}
