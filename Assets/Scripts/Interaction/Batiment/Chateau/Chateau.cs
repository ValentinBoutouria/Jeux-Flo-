using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChateauBat : MonoBehaviour
{    public Compteur _compteur;
    public Gold _gold;
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
        if (_compteur.counterAjoutChateau < 0f)
        {
            _compteur.counterAjoutChateau = 9;
            _gold._nbGold += _beneficeChateau;
        }
    }
}
