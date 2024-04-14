using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squad : MonoBehaviour
{
    public generateSquad generateSquadScript; // Le script generateSquad

    public List<GameObject> units; // La liste des unit�s dans l'escouade
    private Vector3 destination; // La destination de l'escouade

        // Start is called before the first frame update
    void Start()
    {
        units = new List<GameObject>();
        GenerateSquadDestination();
    }

        // Update is called once per frame
        void Update()
    {
        // Parcourir chaque escouade
        foreach (List<GameObject> squad in generateSquadScript.squads)
        {
            // Si l'escouade a atteint sa destination, g�n�rer une nouvelle destination
            if (Vector3.Distance(transform.position, destination) < 1f)
            {
                GenerateSquadDestination();
            }

            // Assigner la destination � chaque unit� de l'escouade
            foreach (GameObject unit in squad)
            {
                deplacement unitScript = unit.GetComponent<deplacement>();
                unitScript.GenerateTargetPosition(destination);
            }
        }
    }

    // Cette m�thode g�n�re une destination al�atoire pour l'escouade
    void GenerateSquadDestination()
    {
        destination = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
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
