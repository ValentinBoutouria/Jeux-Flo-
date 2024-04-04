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
            GameObject _tempHexa=_selection.listeGameObjectNONSelect[_aleaHexaIndex];//hexa ou la ressource spawn
            GameObject _gameObjectTemp= Instantiate(_ressourceSpawn,_tempHexa.transform.position,Quaternion.identity,_tempHexa.transform);
            _selection.listeGameObjectNONSelect.Remove(_selection.listeGameObjectNONSelect[_aleaHexaIndex]);//on retire l'hexa ou la ressource vient de spawn de la liste des hexa selectionnables
            if(_ressourceSpawn==_woodPrefab)
            {
                _selection.listeGameObjectWOOD.Add(_tempHexa);  

            }
            if(_ressourceSpawn==_stonePrefab)
            {
                _selection.listeGameObjectStone.Add(_tempHexa);  
            }
            if(_ressourceSpawn==_goldPrefab)
            {
                _selection.listeGameObjectGold.Add(_tempHexa);  
            }
            _compteur.counterSpawnRessources=0;
        }
    }
}
