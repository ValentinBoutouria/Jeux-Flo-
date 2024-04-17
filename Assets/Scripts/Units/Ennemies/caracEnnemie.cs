using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracEnnemie : MonoBehaviour
{

    private Dictionary<string, int> nameToIndex = new Dictionary<string, int>()
    {
        {"spinne", 0},
        {"mage__", 1 },
        {"citize", 2 }
    };


    private int[] attaque = new int[3] { 5, 6, 0};
    private int[] vie = new int[3] { 15, 8, 20};
    private int[] defense = new int[3] { 3, 0, 1};
    private readonly int[] vitesse = new int[3] { 5, 4, 3};
    private int[] vitesseAttaque = new int[3] {2, 4, 10000};
    private float[] portee = new float[3] { 0.6f, 3.4f, 0};

    private int[] vision = new int[3] {17, 25, 20};
    private bool[] aggressive = new bool[3] {true, true, false};

    private bool isInSquad = false;

    private int[] manaDrop = new int[3] { 0, 3, 0 };
    private int[] corpseDrop = new int[3] { 3, 2, 1 };

    public int currentSpeed;

    public string classe;


    // Start is called before the first frame update
    void Start()
    {
        classe = this.GetComponent<Transform>().name.Substring(0, 6);
        currentSpeed = vitesse[nameToIndex[classe]];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSquad(bool b)
    {
        isInSquad = b;
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

    public string getClasse() 
    { 
        return classe;
    }

    public int getVision()
    {
        return vision[nameToIndex[classe]];
    }

    public bool isAggressive()
    {
        return aggressive[nameToIndex[classe]];
    }

    public void setCurrentSpeed(int speed)
    {
        currentSpeed = speed;
    }

    public int getCurrentSpeed()
    {
        return currentSpeed;
    }

    public int getManaDrop()
    {
        return manaDrop[nameToIndex[classe]];
    }

    public int getCorpseDrop()
    {
        return corpseDrop[nameToIndex[classe]];
    }
}
