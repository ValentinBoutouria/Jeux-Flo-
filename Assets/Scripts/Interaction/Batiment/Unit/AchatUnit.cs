using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class AchatUnit : MonoBehaviour
{
    public Selection _selection;
    public Ressources _ressources;
    

    private caracteristique _caracteristique;

    public TMP_Text _unit1TMP;
    public TMP_Text _unit2TMP;
    public TMP_Text _unit3TMP;
    public TMP_Text _unit4TMP;

    public GameObject _maison;
    public GameObject _ferme;
    public GameObject _chateau;

    public GameObject _unitMaison;
    public GameObject _unitFerme;
    public GameObject _unitChateau;

    public GameObject _unitRangement;

    private GameObject tmpUnit;

    private InfoBatiment _infobat;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChoixUnitTMPAffiche();
        
    }
    public void ChoixUnitTMPAffiche() 
    {
        if(_selection.listeGameObjectbatimentSelect.Count!=0)
        {
            InfoBatiment _infobat = _selection.listeGameObjectbatimentSelect[0].GetComponent<InfoBatiment>();//on recupere l'info du batiment qu'on selectionne

            //select bat Maison
            if (_infobat.id==2) 
            {
                _unit1TMP.text = _unitMaison.transform.GetChild(0).name;//pour selectionner l'une des 4 troupes du batiment maison on regarde ses fils
                _unit2TMP.text = _unitMaison.transform.GetChild(1).name;
                _unit3TMP.text = _unitMaison.transform.GetChild(2).name;
                _unit4TMP.text = _unitMaison.transform.GetChild(3).name;
            }
            //select bat Ferme
            if (_infobat.id == 1)
            {
                _unit1TMP.text = _unitFerme.transform.GetChild(0).name;
                _unit2TMP.text = _unitFerme.transform.GetChild(1).name;
                _unit3TMP.text = _unitFerme.transform.GetChild(2).name;
                _unit4TMP.text = _unitFerme.transform.GetChild(3).name;
            }
            //select bat Chateau
            if (_infobat.id == 0)
            {
                _unit1TMP.text = _unitChateau.transform.GetChild(0).name;
                _unit2TMP.text = _unitChateau.transform.GetChild(1).name;
                _unit3TMP.text = _unitChateau.transform.GetChild(2).name;
                _unit4TMP.text = _unitChateau.transform.GetChild(3).name;
            }
        }
    }

    public void ChoiUnitSpawn(int idBouton)
    {
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {
            _infobat = _selection.listeGameObjectbatimentSelect[0].GetComponent<InfoBatiment>();//on recupere l'info du batiment qu'on selectionne
            if (_infobat.id==2)//maison
            {
                SpawnUnit(idBouton,_unitMaison,_maison);//lvl de l'unit , quelle groupe d'unit(unitMaison),où on la range (maison au child du niveau)
            }
            if(_infobat.id==1)//select bat Ferme
            {
                SpawnUnit(idBouton, _unitFerme, _ferme);//lvl de l'unit , quelle groupe d'unit(unitMaison),où on la range (maison au child du niveau)
            }
            if(_infobat.id==0) 
            {
                SpawnUnit(idBouton, _unitChateau, _chateau);//lvl de l'unit , quelle groupe d'unit(unitMaison),où on la range (maison au child du niveau)
            }  
        }
    }
    void ChoixTempUnit(int bat,int lvlUnit)
    {
        tmpUnit = _unitRangement.transform.GetChild(bat).GetChild(lvlUnit).gameObject;// Maison/soldier/
    }
    void SpawnUnit(int _lvlUnit,GameObject _unitBat,GameObject _unitRangementBat)
    {
        //on recupere la position du spawn de l'unit :
        Vector3 _positionSpawnUnit = _selection.listeGameObjectbatimentSelect[0].transform.position + new Vector3(0, 1, 0);
        ChoixTempUnit(_infobat.id, _lvlUnit);//recup le gameobject de l'unité a spawn
        getCaracteristique(tmpUnit); // a changer pour tout 
        if (VerifieRessource())
        {
            Instantiate(_unitBat.transform.GetChild(_lvlUnit), _positionSpawnUnit, Quaternion.identity, _unitRangementBat.transform.GetChild(_lvlUnit));//instancie l'unité lors de l'appuie du bouton1
        }
    }


    void getCaracteristique(GameObject unit)
    {
        Transform Caracteristique=unit.transform.GetChild(0); //on recup le tranform de l'enfant du prefab de la troupe
        _caracteristique=Caracteristique.GetComponent<caracteristique>();//on recupére le script de la troupe unit
    }
    bool VerifieRessource()
    {
        bool result = false;

        if ( _ressources._nbStone>=_caracteristique.getStone()&&
             _ressources._nbWood>= _caracteristique.getBois()&&
             _ressources._nbFood>=_caracteristique.getFood()&&
             _ressources._nbMana>=_caracteristique.getMana()&&
             _ressources._nbGold>=_caracteristique.getGold()&&
             _ressources._nbCorpse>=_caracteristique.getCorpse()
             )//si la quantite de ressource qu'on a est supérieur ou égale au cout de la ressource (on a assez) // FLO !!!!!!!
        {
            result = true;//on a assez 
        }
        else
        {
            Debug.Log("pas assez de ressource pour acheter cette unité");
        }
        return result;
    }
 
}
