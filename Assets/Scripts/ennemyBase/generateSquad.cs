using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateSquad : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Les préfabs d'ennemis à instancier
    public float minSpawnInterval = 120.0f; // L'intervalle de temps minimum entre chaque spawn d'escouade
    public float maxSpawnInterval = 130.0f; // L'intervalle de temps maximum entre chaque spawn d'escouade

    public List<List<GameObject>> squads; // La liste des escouades
    private int squadSize; // La taille de l'escouade

    // Start is called before the first frame update
    void Start()
    {
        squads = new List<List<GameObject>>();
        SpawnSquad();
    }

    private void Update()
    {
        
        // Si le temps écoulé est supérieur à l'intervalle de spawn, instancier une nouvelle escouade
        if (Time.time > minSpawnInterval)
        {
            SpawnSquad();
            float randTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            minSpawnInterval = Time.time + randTime;
            maxSpawnInterval = Time.time + randTime + 10;
        }
    }

    // Cette méthode instancie une escouade d'ennemis
    void SpawnSquad()
    {
        squadSize = Random.Range(3, 11); // Générer une taille d'escouade aléatoire entre 3 et 10
        List<GameObject> newSquad = new List<GameObject>();

        // Créer un nouveau GameObject pour l'escouade et lui attacher le script squad
        GameObject squadObject = new GameObject("Escouade");
        squad squadScript = squadObject.AddComponent<squad>();
        squadScript.generateSquadScript = this;

        for (int i = 0; i < squadSize; i++)
        {
            // Choisir un préfab d'ennemi aléatoire
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Instancier l'ennemi et l'ajouter à l'escouade
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newSquad.Add(enemy);

            // Faire de l'ennemi un enfant du GameObject de l'escouade
            enemy.transform.parent = squadObject.transform;

            // Obtenir une référence au script caracEnnemie et appeler setSquad()
            caracEnnemie enemyScript = enemy.GetComponent<caracEnnemie>();
            enemyScript.setSquad(true);
        }

        squads.Add(newSquad);
    }
}


/*
         // Générer un délai aléatoire avant le prochain spawn d'escouade
        float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke("SpawnSquad", spawnInterval);
*/
