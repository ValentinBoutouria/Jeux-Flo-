using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public Selection _selection;
    public int _prixUpgrade;
    public Stone _stone;
    public Bois _bois;
    public Gold _gold;

    public TMP_Text _nom;
    public TMP_Text _niveau;
    public TMP_Text _benefParSec;
    public TMP_Text _cout;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AffichagePanel();
        
    }
    public void AffichagePanel()
    {
        GameObject _batimentUpgrade =_selection.listeGameObjectbatimentSelect[0];
        InfoFerme _infoFerme =_batimentUpgrade.GetComponent<InfoFerme>();
        //Panel explicatif
        _nom.text=_infoFerme._nom;
        _niveau.text="Niveau : "+_infoFerme._niveau;
        _benefParSec.text=_infoFerme._benefparsec+" Wood/s";
        _cout.text="Prix : "+_infoFerme._niveau*_prixUpgrade;

    }
    public void CliqueUpgrade()
    {
        GameObject _batimentUpgrade =_selection.listeGameObjectbatimentSelect[0];
        InfoFerme _infoFerme =_batimentUpgrade.GetComponent<InfoFerme>();
        
        if(_stone._nbStone-_prixUpgrade*_infoFerme._niveau>=0)//10*niveau si  il y a assez d'argent alors on upgrade
        {
        _stone._nbStone-=_prixUpgrade*_infoFerme._niveau;
        _infoFerme._niveau+=1;
        }
        else
        {
            Debug.Log("pas assez d'argent pour cette upgrade");
        }
        


    }
}
