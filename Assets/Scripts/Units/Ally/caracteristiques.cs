using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class caracteristique : MonoBehaviour
{
    private Dictionary<string, int> nameToIndex = new Dictionary<string, int>()
    {
        {"Soldie", 0},
        {"Bowman", 1},
        {"Horsem", 2 },
        {"Worker", 3 }
    };

    private const int sizeDict = 4;
    //spécificités unités
    private int[] attaque = new int[sizeDict] {5, 7, 3, 1};
    private int[] vie = new int[sizeDict] {15, 10, 12, 6};
    private int[] defense = new int[sizeDict] {3, 1, 2, 0};
    private readonly int[] vitesse = new int[sizeDict] {5, 8, 15, 10};
    private int[] vitesseAttaque = new int[sizeDict] {2, 1, 3, 5};
    private float[] portee = new float[sizeDict] {0.4f, 2f, 0.2f, 0.2f};


    //Cout fabrication
    private int[] stone = new int[sizeDict] {1 , 0 , 1, 0};
    private int[] bois = new int[sizeDict] {0 , 1, 1, 1 };
    private int[] gold = new int[sizeDict] {0, 1, 1, 0};
    private int[] food = new int[sizeDict] {0, 1, 1, 1 };
    private int[] mana = new int[sizeDict] {0, 0, 0, 0};
    private int[] corpse = new int[sizeDict] {0, 0, 0, 0};

    private string classe;

    // Start is called before the first frame update
    void Start()
    {
        classe = this.GetComponent<Transform>().parent.name.Substring(0,6);
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

    public float getPortee()
    {
        return portee[nameToIndex[classe]];
    }

    public int getStone()
    {
        return stone[nameToIndex[classe]];
    }

    public int getBois()
    {
        return bois[nameToIndex[classe]];
    }

    public int getGold()
    {
        return gold[nameToIndex[classe]];
    }

    public int getFood()
    {
        return food[nameToIndex[classe]];
    }

    public int getMana()
    {
        return mana[nameToIndex[classe]];
    }

    public int getCorpse()
    {
        return corpse[nameToIndex[classe]];
    }
}
