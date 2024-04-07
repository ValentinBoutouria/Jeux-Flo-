using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class AchatUnit : MonoBehaviour
{
    public Selection _selection;
    public Bois _bois;
    public Gold _gold;
    public Stone _stone;
    public Food _food;
    public Mana _mana;
    public Corpse _corpse;
    

    public caracteristique _caracteristique;

    public TMP_Text _unit1TMP;
    public TMP_Text _unit2TMP;
    public TMP_Text _unit3TMP;
    public TMP_Text _unit4TMP;

    public GameObject _unitFerme1;
    public GameObject _unitFerme2;
    public GameObject _unitFerme3;
    public GameObject _unitFerme4;

    public GameObject _unitChateau1;
    public GameObject _unitChateau2;
    public GameObject _unitChateau3;
    public GameObject _unitChateau4;

    public GameObject Soldier;
    public GameObject _unitMaison2;
    public GameObject _unitMaison3;
    public GameObject _unitMaison4;

    public GameObject _maison;
    public GameObject _ferme;
    public GameObject _chateau;

    public GameObject _unitRangement;
    public GameObject tmpinstance;


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

            //select bat Maison
            if (_selection.listeGameObjectbatimentSelect[0].name =="Maison(Clone)") 
            {
                _unit1TMP.text = Soldier.name;
                _unit2TMP.text = _unitMaison2.name;
                _unit3TMP.text = _unitMaison3.name;
                _unit4TMP.text = _unitMaison4.name;
            }
            //select bat Ferme
            if (_selection.listeGameObjectbatimentSelect[0].name == "Ferme(Clone)")
            {
                _unit1TMP.text = _unitFerme1.name;
                _unit2TMP.text = _unitFerme2.name;
                _unit3TMP.text = _unitFerme3.name;
                _unit4TMP.text = _unitFerme4.name;
            }
            //select bat Chateau
            if (_selection.listeGameObjectbatimentSelect[0].name == "Chateau(Clone)")
            {
                _unit1TMP.text = _unitChateau1.name;
                _unit2TMP.text = _unitChateau2.name;
                _unit3TMP.text = _unitChateau3.name;
                _unit4TMP.text = _unitChateau4.name;
            }
        }
    }

    //unit 1
    public void ChoiUnitSpawnBouton1()
    {
        
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {//on recupere la position du spawn de l'unit :
            Vector3 _positionSpawnUnit=_selection.listeGameObjectbatimentSelect[0].transform.position;

            //select bat Maison
            if (_selection.listeGameObjectbatimentSelect[0].name == "Maison(Clone)")
            {
                tmpinstance =_unitRangement.transform.GetChild(0).GetChild(0).gameObject;// ferme/caracteristique
                getCaracteristique(tmpinstance); // a changer pour tout

                
                if(VerifieRessource())
                {
                Instantiate(Soldier, _positionSpawnUnit,Quaternion.identity,_maison.transform.GetChild(0));//instancie l'unité lors de l'appuie du bouton1
                }

                
            }
            //select bat Ferme
            if (_selection.listeGameObjectbatimentSelect[0].name == "Ferme(Clone)")
            {
                Instantiate(_unitFerme1, _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(0));//instancie l'unité lors de l'appuie du bouton1


            }
            //select bat Chateau
            if (_selection.listeGameObjectbatimentSelect[0].name == "Chateau(Clone)")
            {
                Instantiate(_unitChateau1, _positionSpawnUnit, Quaternion.identity, _chateau.transform.GetChild(0));//instancie l'unité lors de l'appuie du bouton1
            }
        }

    }

    //unit 2
    public void ChoiUnitSpawnBouton2()
    {
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {//on recupere la position du spawn de l'unit :
            Vector3 _positionSpawnUnit = _selection.listeGameObjectbatimentSelect[0].transform.position;

            //select bat Maison
            if (_selection.listeGameObjectbatimentSelect[0].name == "Maison(Clone)")
            {
                Instantiate(_unitMaison2, _positionSpawnUnit, Quaternion.identity, _maison.transform.GetChild(1));//instancie l'unité lors de l'appuie du bouton2
            }
            //select bat Ferme
            if (_selection.listeGameObjectbatimentSelect[0].name == "Ferme(Clone)")
            {
                Instantiate(_unitFerme2, _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(1));//instancie l'unité lors de l'appuie du bouton2
            }
            //select bat Chateau
            if (_selection.listeGameObjectbatimentSelect[0].name == "Chateau(Clone)")
            {
                Instantiate(_unitChateau2, _positionSpawnUnit, Quaternion.identity, _chateau.transform.GetChild(1));//instancie l'unité lors de l'appuie du bouton2
            }
        }

    }
    //unit 3
    public void ChoiUnitSpawnBouton3()
    {
        if (_selection.listeGameObjectbatimentSelect.Count != 0)
        {//on recupere la position du spawn de l'unit :
            Vector3 _positionSpawnUnit = _selection.listeGameObjectbatimentSelect[0].transform.position;

            //select bat Maison
            if (_selection.listeGameObjectbatimentSelect[0].name == "Maison(Clone)")
            {
                Instantiate(_unitMaison3, _positionSpawnUnit, Quaternion.identity, _maison.transform.GetChild(2));//instancie l'unité lors de l'appuie du bouton3
            }
            //select bat Ferme
            if (_selection.listeGameObjectbatimentSelect[0].name == "Ferme(Clone)")
            {
                Instantiate(_unitFerme3, _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(2));//instancie l'unité lors de l'appuie du bouton3
            }
            //select bat Chateau
            if (_selection.listeGameObjectbatimentSelect[0].name == "Chateau(Clone)")
            {
                Instantiate(_unitChateau3, _positionSpawnUnit, Quaternion.identity, _chateau.transform.GetChild(2));//instancie l'unité lors de l'appuie du bouton3
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

            //select bat Maison
            if (_selection.listeGameObjectbatimentSelect[0].name == "Maison(Clone)")
            {
                //si le cout le permet
              
                Instantiate(_unitMaison3, _positionSpawnUnit, Quaternion.identity, _maison.transform.GetChild(3));//instancie l'unité lors de l'appuie du bouton4
                
            }
            //select bat Ferme
            if (_selection.listeGameObjectbatimentSelect[0].name == "Ferme(Clone)")
            {
                Instantiate(_unitFerme3, _positionSpawnUnit, Quaternion.identity, _ferme.transform.GetChild(3));//instancie l'unité lors de l'appuie du bouton4
            }
            //select bat Chateau
            if (_selection.listeGameObjectbatimentSelect[0].name == "Chateau(Clone)")
            {
                Instantiate(_unitChateau3, _positionSpawnUnit , Quaternion.identity, _chateau.transform.GetChild(3));//instancie l'unité lors de l'appuie du bouton4
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

        if ( _stone._nbStone>=_caracteristique.getStone()
            )//si la quantite de ressource qu'on a est supérieur ou égale au cout de la ressource (on a assez)
        {
            result = true;//on a assez 
            _bois._nbBois-=_caracteristique.getBois();
            _stone._nbStone-=_caracteristique.getStone();
        }
        else
        {
            Debug.Log("pas assez de ressource pour acheter cette unité");
        }
        return result;
    }
 
}
