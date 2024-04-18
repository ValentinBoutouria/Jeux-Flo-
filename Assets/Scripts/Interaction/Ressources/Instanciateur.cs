using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Instanciateur : MonoBehaviour
{
    public GameObject _woodPrefab;
    public GameObject _stonePrefab;
    public GameObject _goldPrefab;
    public Compteur _compteur;
    public Selection _selection;
    public int _spawnTime;

    private GameObject _ressourceSpawn;
    private GameObject _tempHexa;
    private int _aleaHexaIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChoixAleaHexa();
        ChoixRessource();
        instanciation();
        
    }

    void ChoixAleaHexa()
    {
        _aleaHexaIndex = Random.Range(0, _selection.listeGameObjectNONSelect.Count);
    }
    void ChoixRessource()
    {
        int randomNumber = Random.Range(0, 9);
        if (randomNumber==0)//0
        {
            _ressourceSpawn=_goldPrefab;
        }
        else
        {
            if(randomNumber<5)//1,2,3,4
            {
                _ressourceSpawn=_woodPrefab;
            }
            else//5,6,7,8
            {
                _ressourceSpawn=_stonePrefab;
            }
        }
    }
    void instanciation()
    {
            
        if (_compteur.counterSpawnRessources == _spawnTime)
        {
            //instancie la ressource sur le bon hexa
            //=_selection.listeGameObjectNONSelect[_aleaHexaIndex];//hexa ou la ressource spawn //ajouter le spawn des ressources sur les hexa attitrés
            if(_ressourceSpawn==_woodPrefab)
            {
                _tempHexa = _selection.listeGameObjectHexaWood[Random.Range(0, _selection.listeGameObjectHexaWood.Count)];//choisi un hexaWood au piff
                _selection.listeGameObjectWOOD.Add(_tempHexa);  

            }
            if(_ressourceSpawn==_stonePrefab)
            {
                _tempHexa = _selection.listeGameObjectHexaStone[Random.Range(0, _selection.listeGameObjectHexaStone.Count)];//choisi un hexaWood au piff

                _selection.listeGameObjectStone.Add(_tempHexa);  
            }
            if(_ressourceSpawn==_goldPrefab)
            {
                _tempHexa = _selection.listeGameObjectHexaGold[Random.Range(0, _selection.listeGameObjectHexaGold.Count)];//choisi un hexaWood au piff
                _selection.listeGameObjectGold.Add(_tempHexa);  
            }
            GameObject _gameObjectTemp= Instantiate(_ressourceSpawn,_tempHexa.transform.position,Quaternion.identity,_tempHexa.transform);
            _gameObjectTemp.transform.SetAsFirstSibling();
            _selection.listeGameObjectNONSelect.Remove(_selection.listeGameObjectNONSelect[_aleaHexaIndex]);//on retire l'hexa ou la ressource vient de spawn de la liste des hexa selectionnables
            _compteur.counterSpawnRessources=0;
        }
    }
}
