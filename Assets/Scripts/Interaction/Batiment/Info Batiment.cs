using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBatiment : MonoBehaviour

{
    public int id; //0=chateau 1=Ferme 2=Maison ...
    public string _nom;
    public int benefice;
    public int _niveau;
    public int _niveauTemp;
    public string _ressource;

    public float _benefparsec;
    // Start is called before the first frame update
    void Start()
    {//init valeur
        _niveau = 1;
        _niveauTemp = 0;
        benefice = 1;

    }

    // Update is called once per frame
    void Update()
    {
        benefParSec();
        if (_niveauTemp != _niveau)//a chaque changement de niveau
        {

            ModificationBenefice();
            ModificationBeneficeParent();
            _niveauTemp = _niveau;

        }
    }

    public void ModificationBenefice()
    //fonction lance apres chaque upgrade

    {
        benefice = _niveau * 2;
    }
    public void ModificationBeneficeParent()
    //fonction lance apres chaque upgrade
    {
        //on recupere le parent
        
        
        Benefice _benefice = GetComponentInParent<Benefice>();
        _benefice.tableauBeneficeRessources[id] += 2;//0.2 ressource par secondes en plus par niveau (2 toutes les 10 sec) //on peut selectionner quelle ressource on veut augmenter

        
        
    }
    void benefParSec()
    {
        _benefparsec = benefice / 10f;
    }

}
