using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ressources : MonoBehaviour
{
    public int _nbWood = 0;
    public int _nbStone = 0;
    public int _nbGold = 0;
    public int _nbMana = 0;
    public int _nbCorpse = 0;
    public int _nbRats = 0;


    public TMP_Text _textNbWood;
    public TMP_Text _textNbStone;
    public TMP_Text _textNbGold;
    //public TMP_Text _textNbMana;
    //public TMP_Text _textNbCorpse;
    //public TMP_Text _textNbRats;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _textNbWood.text = "Wood : " + _nbWood; // ajouter les autres ressources
        _textNbStone.text = "Stone : " + _nbStone; 
        _textNbGold.text = "Gold : " + _nbGold; 
    }
}
