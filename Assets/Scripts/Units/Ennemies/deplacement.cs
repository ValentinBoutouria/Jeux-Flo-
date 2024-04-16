using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private caracEnnemie carac; // R�f�rence au script caracEnnemie
    private Vector3 targetPosition; // Position cible pour le d�placement
    private SelectionController selectionController; // R�f�rence au script SelectionController

    private float vision;
    private float portee;


// Start is called before the first frame update
void Start()
    {
        // Obtenir la r�f�rence au script caracEnnemie
        carac = GetComponent<caracEnnemie>();

        // Obtenir la r�f�rence au script SelectionController
        selectionController = GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>();

        // G�n�rer une position cible initiale
        GenerateTargetPosition();
        vision = carac.getVision();
        portee = carac.getPortee();
    }

    // Update is called once per frame
    void Update()
    {
        // Parcourir la liste des soldats disponibles
        foreach (GameObject soldier in selectionController.availableWarriorList)
        {
            try
            {
                // Si un soldat est � une distance inf�rieure � getVision()
                if (Vector3.Distance(transform.position, soldier.transform.position) < vision)
                {
                    // Si getAggressive() retourne false, l'unit� doit fuir
                    if (!carac.isAggressive())
                    {
                        // G�n�rer une direction al�atoire
                        Vector3 randomDirection = Random.insideUnitCircle;

                        // Assurer que la direction est � l'oppos� du soldat
                        if (Vector3.Dot(randomDirection, soldier.transform.position - transform.position) > 0)
                        {
                            randomDirection *= -1;
                        }

                        // Assigner une nouvelle destination � l'oppos� du soldat par rapport � l'unit�
                        targetPosition = transform.position + randomDirection.normalized * vision;
                        targetPosition.y = 0;
                    }
                    else
                    {
                        // Rediriger l'unit� vers ce soldat, mais s'arr�ter � une distance �gale � la port�e
                        Vector3 directionToSoldier = soldier.transform.position - transform.position;
                        targetPosition = soldier.transform.position - directionToSoldier.normalized * portee;

                        // Assigner cette cible � toute l'escouade
                        squad squadScript = GetComponentInParent<squad>();
                        squadScript.SetSquadTarget(targetPosition);

                        // Sortir de la boucle
                        break;
                    }
                }
            }
            catch { }

        }

        // D�placer l'unit� vers la position cible
        MoveTowardsTarget();
    }

    public void GenerateTargetPosition(Vector3? squadDest = null)
    {
        if (squadDest.HasValue)
        {
            // Si squadDest est non nul, assigner sa valeur � targetPosition
            targetPosition = squadDest.Value;
        }
        else
        {
            // Sinon, g�n�rer une position cible al�atoire
            targetPosition += new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        }
    }

    void MoveTowardsTarget()
    {
        // D�placer le personnage vers la position cible � la vitesse d�finie
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, carac.getCurrentSpeed() * Time.deltaTime);

        // Si le personnage est proche de la position cible, g�n�rer une nouvelle position cible
        if (transform.parent == null && Vector3.Distance( transform.position, targetPosition) < 1f)
        {
            GenerateTargetPosition();
        }
    }
}