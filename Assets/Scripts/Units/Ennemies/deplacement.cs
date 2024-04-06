using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private caracEnnemie carac; // R�f�rence au script caracEnnemie
    private Vector3 targetPosition; // Position cible pour le d�placement

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir la r�f�rence au script caracEnnemie
        carac = GetComponent<caracEnnemie>();

        // G�n�rer une position cible initiale
        GenerateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
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

        // Si le personnage a atteint la position cible, g�n�rer une nouvelle position cible
        // Si le personnage est proche de la position cible, g�n�rer une nouvelle position cible
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            GenerateTargetPosition();
        }
    }
}