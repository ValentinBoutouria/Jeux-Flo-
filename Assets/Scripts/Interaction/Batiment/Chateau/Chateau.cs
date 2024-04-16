using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChateauBat : MonoBehaviour
{    public Compteur _compteur;
    public Ressources _ressources;
    public int _beneficeChateau;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AjoutRessourcesChateau();
        
    }
      public void AjoutRessourcesChateau()
    {
        if (_compteur.counterAjoutRessources >10f)
        {
            _compteur.counterAjoutRessources = 0;
            _ressources._nbGold += _beneficeChateau;
        }
    }
}
