using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison : MonoBehaviour
{

    public int _prix;
    public AjoutPoint _ajoutPoint;
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
        //_ajoutPoint.scoreSelect = _ajoutPoint.scoreSelect - (_prix * _ajoutPoint.scoreSelect);//retire le prix pour placer un Maison sur chaque hexagone selectionn�
        _validationUI.SetActive(true);
        foreach (GameObject obj in _selection.gameObjectListSelectionne)//pour tout les gameobject dans liste selectionne
        {
          GameObject GameObjectTemp=Instantiate(_maisonPrefabLVL1,obj.transform.position+new Vector3(0,0.1f,0),Quaternion.identity);
          GameObjectTemp.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
          Renderer renderer = obj.GetComponent<Renderer>();//on recupere le renderer
          renderer.material = _selection._matInitial;//on place le mat deselection

        }
        _selection.gameObjectListSelectionne.Clear();
    }
}
