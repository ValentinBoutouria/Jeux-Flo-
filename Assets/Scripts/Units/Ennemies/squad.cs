using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squad : MonoBehaviour
{
    public generateSquad generateSquadScript; // Le script generateSquad

    public List<GameObject> units; // La liste des unités dans l'escouade
    private Vector3 destination; // La destination de l'escouade

    private Vector3 positionChef;
    public int slowestSpeed;

        // Start is called before the first frame update
    void Start()
    {
        units = new List<GameObject>();
        foreach (Transform child in transform)
        {
            units.Add(child.gameObject);
        }
        slowestSpeed = setSlowestSpeed();
        GenerateSquadDestination();
    }

    // Update is called once per frame
    void Update()
    {
        positionChef = this.transform.GetChild(0).GetComponent<Transform>().position;
        // Si l'escouade a atteint sa destination, générer une nouvelle destination
        if (Vector3.Distance(positionChef, destination) < 1f)
        {
            GenerateSquadDestination();
        }

        // Assigner la destination à chaque unité de l'escouade, y compris le chef
        foreach (Transform child in transform)
        {
            deplacement unitScript = child.GetComponent<deplacement>();
            if (unitScript != null)
            {
                unitScript.GenerateTargetPosition(destination);
            }
        }
    }

    // Cette méthode génère une destination aléatoire pour l'escouade
    void GenerateSquadDestination()
    {
        // Avec une probabilité de 70%, déplacer l'escouade
        if (Random.Range(0f, 1f) < 0.7f)
        {
            destination += new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            // Réactiver le script deplacement pour chaque unité
            foreach (GameObject unit in units)
            {
                unit.GetComponent<deplacement>().enabled = true;
            }
        }
        else
        {
            // Sinon, désactiver le script deplacement pour chaque unité et commencer une coroutine pour le réactiver après 5 secondes
            foreach (GameObject unit in units)
            {
                deplacement unitScript = unit.GetComponent<deplacement>();
                unitScript.enabled = false;
                StartCoroutine(EnableDeplacementAfterDelay(unitScript, 5f));
            }
        }
    }

    // Cette coroutine réactive le script deplacement après un certain délai
    IEnumerator EnableDeplacementAfterDelay(deplacement unitScript, float delay)
    {
        yield return new WaitForSeconds(delay);
        unitScript.enabled = true;
    }

    public int setSlowestSpeed()
    {
        int slowestSpeed = 10000;
        foreach (GameObject unit in units)
        {
            caracEnnemie unitScript = unit.GetComponent<caracEnnemie>();
            if (unitScript.getVitesse() < slowestSpeed)
            {
                slowestSpeed = unitScript.getVitesse();
            }
        }
        foreach (GameObject unit in units)
        {
            caracEnnemie unitScript = unit.GetComponent<caracEnnemie>();
            unitScript.setCurrentSpeed(slowestSpeed);
        }
        return slowestSpeed;
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
