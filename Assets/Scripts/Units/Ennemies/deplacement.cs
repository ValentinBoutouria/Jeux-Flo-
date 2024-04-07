using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private caracEnnemie carac; // R�f�rence au script caracEnnemie
    private Vector3 targetPosition; // Position cible pour le d�placement
    private SelectionController selectionController; // R�f�rence au script SelectionController

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir la r�f�rence au script caracEnnemie
        carac = GetComponent<caracEnnemie>();

        // Obtenir la r�f�rence au script SelectionController
        selectionController = GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>();

        // G�n�rer une position cible initiale
        GenerateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Parcourir la liste des soldats disponibles
        foreach (GameObject soldier in selectionController.availableWarriorList)
        {
            // Si un soldat est � une distance inf�rieure � getVision()
            if (Vector3.Distance(transform.position, soldier.transform.position) < carac.getVision())
            {
                // Si le personnage est un "citizen", il doit fuir
                if (gameObject.name.Contains("citizen"))
                {
                    // G�n�rer une direction al�atoire
                    Vector3 randomDirection = Random.insideUnitSphere;

                    // Assurer que la direction est � l'oppos� du soldat
                    if (Vector3.Dot(randomDirection, soldier.transform.position - transform.position) > 0)
                    {
                        randomDirection *= -1;
                    }

                    // Assigner une nouvelle destination � l'oppos� du soldat par rapport au citoyen
                    targetPosition = transform.position + randomDirection.normalized * carac.getVision();
                    targetPosition.y = 0;
                }
                else
                {
                    // Rediriger le personnage vers ce soldat
                    targetPosition = soldier.transform.position;
                }

                // Si la distance entre le personnage et le soldat est inf�rieure � getPortee(), arr�ter le mouvement du personnage
                if (Vector3.Distance(transform.position, soldier.transform.position) < carac.getPortee())
                {
                    return;
                }
            }
        }

        // D�placer le personnage vers la position cible
        MoveTowardsTarget();
    }

    void GenerateTargetPosition()
    {
        // G�n�rer une position cible al�atoire
        targetPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    void MoveTowardsTarget()
    {
        // D�placer le personnage vers la position cible � la vitesse d�finie
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, carac.getVitesse() * Time.deltaTime);

        // Si le personnage est proche de la position cible, g�n�rer une nouvelle position cible
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            GenerateTargetPosition();
        }
    }
}