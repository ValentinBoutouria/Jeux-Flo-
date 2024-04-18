using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public Selection _selection;
    public int _prixUpgrade;
    public Ressources _ressources;

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
        InfoBatiment _infobat= _batimentUpgrade.GetComponent<InfoBatiment>();
        if (_infobat)
        { 
            //Panel explicatif
            _nom.text=_infobat._nom;
            _benefParSec.text=_infobat._benefparsec+" "+_infobat._ressource+"/s";
            _niveau.text="Niveau : "+_infobat._niveau;
            _cout.text = "Prix : " + _infobat._niveau * _prixUpgrade;
        }
        

    }
    public void CliqueUpgrade()
    {
        GameObject _batimentUpgrade =_selection.listeGameObjectbatimentSelect[0];
        InfoBatiment _infobat = _batimentUpgrade.GetComponent<InfoBatiment>();


        if (_infobat)
        {
            if (_infobat.id == 1)
            {
                if(_ressources._nbStone-_prixUpgrade*_infobat._niveau>=0)//10*niveau si  il y a assez d'argent alors on upgrade
                {
                _ressources._nbStone-=_prixUpgrade*_infobat._niveau;
                _infobat._niveau+=1;
                }
                else
                {
                    Debug.Log("pas assez de Stone pour cette upgrade");
                }
            }
            if (_infobat.id==0)//chateau
            {
                if (_ressources._nbGold - _prixUpgrade * _infobat._niveau >= 0)//10*niveau si  il y a assez d'argent alors on upgrade
                {
                    _ressources._nbGold -= _prixUpgrade * _infobat._niveau;
                    _infobat._niveau += 1;
                }
                else
                {
                    Debug.Log("pas assez d'Or pour cette upgrade");
                }

            }
            if (_infobat.id == 2)//maison
            {
                if (_ressources._nbWood - _prixUpgrade * _infobat._niveau >= 0)//10*niveau si  il y a assez d'argent alors on upgrade
                {
                    _ressources._nbWood -= _prixUpgrade * _infobat._niveau;
                    _infobat._niveau += 1;
                }
                else
                {
                    Debug.Log("pas assez de Wood pour cette upgrade");
                }

            }

        }


    }
}
