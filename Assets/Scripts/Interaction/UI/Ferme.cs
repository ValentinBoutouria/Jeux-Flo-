using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferme : MonoBehaviour
{

    public int _prix;
    public AjoutPoint _ajoutPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void CliqueFerme()
    {
        _ajoutPoint.scoreSelect = _ajoutPoint.scoreSelect - (_prix * _ajoutPoint.scoreSelect);//retire le prix pour placer un Ferme sur chaque hexagone selectionné

    }
}
