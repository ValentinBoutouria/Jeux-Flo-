using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squad : MonoBehaviour
{
    public generateSquad generateSquadScript; // Le script generateSquad

    public List<GameObject> units; // La liste des unités dans l'escouade
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
            // Si l'escouade a atteint sa destination, générer une nouvelle destination
            if (Vector3.Distance(transform.position, destination) < 1f)
            {
                GenerateSquadDestination();
            }

            // Assigner la destination à chaque unité de l'escouade
            foreach (GameObject unit in squad)
            {
                deplacement unitScript = unit.GetComponent<deplacement>();
                unitScript.GenerateTargetPosition(destination);
            }
        }
    }

    // Cette méthode génère une destination aléatoire pour l'escouade
    void GenerateSquadDestination()
    {
        destination = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }


    // Cette méthode assigne une nouvelle cible à chaque unité de l'escouade
    public void SetSquadTarget(Vector3 target)
    {
        foreach (GameObject unit in units)
        {
            deplacement unitScript = unit.GetComponent<deplacement>();
            unitScript.GenerateTargetPosition(target);
        }
    }
}
