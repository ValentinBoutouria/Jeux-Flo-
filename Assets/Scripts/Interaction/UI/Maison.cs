using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison : MonoBehaviour
{

    public int _prix;
    public AjoutPoint _ajoutPoint;
    public GameObject _validationUI;
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
        _ajoutPoint.scoreSelect = _ajoutPoint.scoreSelect - (_prix * _ajoutPoint.scoreSelect);//retire le prix pour placer un Maison sur chaque hexagone selectionné
        _validationUI.SetActive(true);


    }
}
