using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private caracEnnemie carac; // Référence au script caracEnnemie
    private Vector3 targetPosition; // Position cible pour le déplacement
    private SelectionController selectionController; // Référence au script SelectionController

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir la référence au script caracEnnemie
        carac = GetComponent<caracEnnemie>();

        // Obtenir la référence au script SelectionController
        selectionController = GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>();

        // Générer une position cible initiale
        GenerateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Parcourir la liste des soldats disponibles
        foreach (GameObject soldier in selectionController.availableWarriorList)
        {
            // Si un soldat est à une distance inférieure à getVision()
            if (Vector3.Distance(transform.position, soldier.transform.position) < carac.getVision())
            {
                // Si le personnage est un "citizen", il doit fuir
                if (gameObject.name.Contains("citizen"))
                {
                    // Inverser la direction du mouvement pour faire fuir le personnage
                    targetPosition = transform.position + (transform.position - soldier.transform.position).normalized;
                    targetPosition.y = 0;
                }
                else
                {
                    // Rediriger le personnage vers ce soldat
                    targetPosition = soldier.transform.position;
                }

                // Si la distance entre le personnage et le soldat est inférieure à getPortee(), arrêter le mouvement du personnage
                if (Vector3.Distance(transform.position, soldier.transform.position) < carac.getPortee())
                {
                    return;
                }
            }
        }

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

        // Si le personnage est proche de la position cible, générer une nouvelle position cible
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            GenerateTargetPosition();
        }
    }
}