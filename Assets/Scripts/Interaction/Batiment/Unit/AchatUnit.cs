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

    private GameObject tmpinstance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChoixUnitAffiche();
        
    }
    public void ChoixUnitAffiche() 
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

    //unit 1
    public void ChoiUnitSpawnBouton1()
    {
        
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {//on recupere la position du spawn de l'unit :
            Vector3 _positionSpawnUnit=_selection.listeGameObjectbatimentSelect[0].transform.position;
            InfoBatiment _infobat = _selection.listeGameObjectbatimentSelect[0].GetComponent<InfoBatiment>();//on recupere l'info du batiment qu'on selectionne
            //select bat Maison
            if (_infobat.id == 2)//Maison
            {
                tmpinstance =_unitRangement.transform.GetChild(0).GetChild(0).gameObject;// ferme/caracteristique
                getCaracteristique(tmpinstance); // a changer pour tout

                
                if(VerifieRessource())
                {
                Instantiate(_unitMaison.transform.GetChild(0), _positionSpawnUnit,Quaternion.identity,_maison.transform.GetChild(0));//instancie l'unité lors de l'appuie du bouton1
                }

                
            }
            //select bat Ferme
            if (_infobat.id == 1)
            {
                Instantiate(_unitFerme.transform.GetChild(0), _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(0));//instancie l'unité lors de l'appuie du bouton1


            }
            //select bat Chateau
            if (_infobat.id == 0)
            {
                Instantiate(_unitChateau.transform.GetChild(0), _positionSpawnUnit, Quaternion.identity, _chateau.transform.GetChild(0));//instancie l'unité lors de l'appuie du bouton1
            }
        }

    }

    //unit 2
    public void ChoiUnitSpawnBouton2()
    {
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {//on recupere la position du spawn de l'unit :
            Vector3 _positionSpawnUnit = _selection.listeGameObjectbatimentSelect[0].transform.position;
            InfoBatiment _infobat = _selection.listeGameObjectbatimentSelect[0].GetComponent<InfoBatiment>();//on recupere l'info du batiment qu'on selectionne
            //select bat Maison
            if (_infobat.id == 2)
            {
                Instantiate(_unitMaison.transform.GetChild(1), _positionSpawnUnit, Quaternion.identity, _maison.transform.GetChild(1));//instancie l'unité lors de l'appuie du bouton2
            }
            //select bat Ferme
            if (_infobat.id == 1)
            {
                Instantiate(_unitFerme.transform.GetChild(1), _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(1));//instancie l'unité lors de l'appuie du bouton2
            }
            //select bat Chateau
            if (_infobat.id == 0)
            {
                Instantiate(_unitChateau.transform.GetChild(1), _positionSpawnUnit, Quaternion.identity, _chateau.transform.GetChild(1));//instancie l'unité lors de l'appuie du bouton2
            }
        }

    }
    //unit 3
    public void ChoiUnitSpawnBouton3()
    {
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {//on recupere la position du spawn de l'unit :
            Vector3 _positionSpawnUnit = _selection.listeGameObjectbatimentSelect[0].transform.position;
            InfoBatiment _infobat = _selection.listeGameObjectbatimentSelect[0].GetComponent<InfoBatiment>();//on recupere l'info du batiment qu'on selectionne
            //select bat Maison
            if (_infobat.id == 2)
            {
                Instantiate(_unitMaison.transform.GetChild(2), _positionSpawnUnit, Quaternion.identity, _maison.transform.GetChild(2));//instancie l'unité lors de l'appuie du bouton3
            }
            //select bat Ferme
            if (_infobat.id == 1)
            {
                Instantiate(_unitFerme.transform.GetChild(2), _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(2));//instancie l'unité lors de l'appuie du bouton3
            }
            //select bat Chateau
            if (_infobat.id == 0)
            {
                Instantiate(_unitChateau.transform.GetChild(2), _positionSpawnUnit, Quaternion.identity, _chateau.transform.GetChild(2));//instancie l'unité lors de l'appuie du bouton3
            }
        }

    }
    //unit 4
    public void ChoiUnitSpawnBouton4()
    {
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {//on recupere la position du spawn de l'unit :
            //Vector3 DecalageSpawn=new Vector3(0,40,0);
            Vector3 _positionSpawnUnit = _selection.listeGameObjectbatimentSelect[0].transform.position;
            InfoBatiment _infobat = _selection.listeGameObjectbatimentSelect[0].GetComponent<InfoBatiment>();//on recupere l'info du batiment qu'on selectionne
            //select bat Maison
            if (_infobat.id == 2)
            {
                //si le cout le permet
              
                Instantiate(_unitMaison.transform.GetChild(3), _positionSpawnUnit, Quaternion.identity, _maison.transform.GetChild(3));//instancie l'unité lors de l'appuie du bouton4
                
            }
            //select bat Ferme
            if (_infobat.id == 1)
            {
                Instantiate(_unitFerme.transform.GetChild(3), _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(3));//instancie l'unité lors de l'appuie du bouton4
            }
            //select bat Chateau
            if (_infobat.id == 0)
            {
                Instantiate(_unitChateau.transform.GetChild(3), _positionSpawnUnit , Quaternion.identity, _chateau.transform.GetChild(3));//instancie l'unité lors de l'appuie du bouton4
            }
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
             _ressources._nbRats>=_caracteristique.getFood()&&
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
