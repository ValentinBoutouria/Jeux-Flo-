using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ressources : MonoBehaviour
{
    public int _nbGold = 0;
    public int _nbStone = 0;
    public int _nbWood = 0;
    public int _nbMana = 0;
    public int _nbCorpse = 0;
    public int _nbFood = 0;

    public Compteur _compteur;
    public Benefice _benefice;


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
        AjoutRessources();
        _textNbWood.text = "Wood : " + _nbWood; // ajouter les autres ressources
        _textNbStone.text = "Stone : " + _nbStone;
        _textNbGold.text = "Gold : " + _nbGold;
    }
    public void AjoutRessources()
    {
        if (_compteur.counterAjoutRessources > 10f)
        {
            _compteur.counterAjoutRessources = 0;
            //on actualise toutes les ressources

            _nbGold += _benefice.tableauBeneficeRessources[0];
            _nbStone += _benefice.tableauBeneficeRessources[1];
            _nbWood += _benefice.tableauBeneficeRessources[2];
            _nbMana += _benefice.tableauBeneficeRessources[3];
            _nbCorpse += _benefice.tableauBeneficeRessources[4];
            _nbFood += _benefice.tableauBeneficeRessources[5];


        }
    }
}
