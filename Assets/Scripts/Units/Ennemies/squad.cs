using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squad : MonoBehaviour
{
    public generateSquad generateSquadScript; // Le script generateSquad

    public List<GameObject> units; // La liste des unit�s dans l'escouade
    private Vector3 destination; // La destination de l'escouade

    private Vector3 positionChef;

        // Start is called before the first frame update
    void Start()
    {
        units = new List<GameObject>();
        foreach (Transform child in transform)
        {
            units.Add(child.gameObject);
        }
        GenerateSquadDestination();
    }

    // Update is called once per frame
    void Update()
    {
        positionChef = this.transform.GetChild(0).GetComponent<Transform>().position;
        // Si l'escouade a atteint sa destination, g�n�rer une nouvelle destination
        if (Vector3.Distance(positionChef, destination) < 1f)
        {
            GenerateSquadDestination();
        }

        // Assigner la destination � chaque unit� de l'escouade
        foreach (GameObject unit in units)
        {
            deplacement unitScript = unit.GetComponent<deplacement>();
            unitScript.GenerateTargetPosition(destination);
        }

    }

    // Cette m�thode g�n�re une destination al�atoire pour l'escouade
    void GenerateSquadDestination()
    {
        destination = new Vector3(Random.Range(-15, 15), 0.2f, Random.Range(-15, 15));
    }


    // Cette m�thode assigne une nouvelle cible � chaque unit� de l'escouade
    public void SetSquadTarget(Vector3 target)
    {
        foreach (GameObject unit in units)
        {
            deplacement unitScript = unit.GetComponent<deplacement>();
            unitScript.GenerateTargetPosition(target);
        }
    }
}
