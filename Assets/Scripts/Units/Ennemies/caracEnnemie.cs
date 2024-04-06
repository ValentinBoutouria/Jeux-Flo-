using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracEnnemie : MonoBehaviour
{

    private Dictionary<string, int> nameToIndex = new Dictionary<string, int>()
    {
        {"spinne", 0},
        {"mage__", 1 }
    };


    private int[] attaque = new int[3] { 5, 7, 3 };
    private int[] vie = new int[3] { 15, 8, 12 };
    private int[] defense = new int[3] { 3, 0, 2 };
    private readonly int[] vitesse = new int[3] { 5, 4, 15 };
    private int[] vitesseAttaque = new int[3] { 2, 4, 3 };
    private int[] portee = new int[3] { 3, 20, 1 };

    private string classe;


    // Start is called before the first frame update
    void Start()
    {
        classe = this.GetComponent<Transform>().name.Substring(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getVie()
    {
        return vie[nameToIndex[classe]];
    }

    public int getAttaque()
    {
        return attaque[nameToIndex[classe]];
    }

    public int getDefense()
    {
        return defense[nameToIndex[classe]];
    }

    public int getVitesse()
    {
        return vitesse[nameToIndex[classe]];
    }

    public int getVitesseAttaque()
    {
        return vitesseAttaque[nameToIndex[classe]];
    }

    public int getPortee()
    {
        return portee[nameToIndex[classe]];
    }

    public string getClasse() 
    { 
        return classe;
    }
}
