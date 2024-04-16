using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private caracEnnemie carac; // Référence au script caracEnnemie
    private Vector3 targetPosition; // Position cible pour le déplacement
    private SelectionController selectionController; // Référence au script SelectionController

    private float vision;
    private float portee;


// Start is called before the first frame update
void Start()
    {
        // Obtenir la référence au script caracEnnemie
        carac = GetComponent<caracEnnemie>();

        // Obtenir la référence au script SelectionController
        selectionController = GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>();

        // Générer une position cible initiale
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
                // Si un soldat est à une distance inférieure à getVision()
                if (Vector3.Distance(transform.position, soldier.transform.position) < vision)
                {
                    // Si getAggressive() retourne false, l'unité doit fuir
                    if (!carac.isAggressive())
                    {
                        // Générer une direction aléatoire
                        Vector3 randomDirection = Random.insideUnitCircle;

                        // Assurer que la direction est à l'opposé du soldat
                        if (Vector3.Dot(randomDirection, soldier.transform.position - transform.position) > 0)
                        {
                            randomDirection *= -1;
                        }

                        // Assigner une nouvelle destination à l'opposé du soldat par rapport à l'unité
                        targetPosition = transform.position + randomDirection.normalized * vision;
                        targetPosition.y = 0;
                    }
                    else
                    {
                        // Rediriger l'unité vers ce soldat, mais s'arrêter à une distance égale à la portée
                        Vector3 directionToSoldier = soldier.transform.position - transform.position;
                        targetPosition = soldier.transform.position - directionToSoldier.normalized * portee;

                        // Assigner cette cible à toute l'escouade
                        squad squadScript = GetComponentInParent<squad>();
                        squadScript.SetSquadTarget(targetPosition);

                        // Sortir de la boucle
                        break;
                    }
                }
            }
            catch { }

        }

        // Déplacer l'unité vers la position cible
        MoveTowardsTarget();
    }

    public void GenerateTargetPosition(Vector3? squadDest = null)
    {
        if (squadDest.HasValue)
        {
            // Si squadDest est non nul, assigner sa valeur à targetPosition
            targetPosition = squadDest.Value;
        }
        else
        {
            // Sinon, générer une position cible aléatoire
            targetPosition += new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        }
    }

    void MoveTowardsTarget()
    {
        // Déplacer le personnage vers la position cible à la vitesse définie
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, carac.getCurrentSpeed() * Time.deltaTime);

        // Si le personnage est proche de la position cible, générer une nouvelle position cible
        if (transform.parent == null && Vector3.Distance( transform.position, targetPosition) < 1f)
        {
            GenerateTargetPosition();
        }
    }
}