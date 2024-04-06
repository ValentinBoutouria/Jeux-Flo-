using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private caracEnnemie carac; // Référence au script caracEnnemie
    private Vector3 targetPosition; // Position cible pour le déplacement

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir la référence au script caracEnnemie
        carac = GetComponent<caracEnnemie>();

        // Générer une position cible initiale
        GenerateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacer le personnage vers la position cible
        MoveTowardsTarget();
    }

    void GenerateTargetPosition()
    {
        // Générer une position cible aléatoire
        targetPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    void MoveTowardsTarget()
    {
        // Déplacer le personnage vers la position cible à la vitesse définie
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, carac.getVitesse() * Time.deltaTime);

        // Si le personnage a atteint la position cible, générer une nouvelle position cible
        // Si le personnage est proche de la position cible, générer une nouvelle position cible
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            GenerateTargetPosition();
        }
    }
}