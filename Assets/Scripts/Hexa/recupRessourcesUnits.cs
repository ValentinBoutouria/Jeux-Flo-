using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class recupRessourcesUnits : MonoBehaviour
{
    private Selection selectionScript; // Référence au script Selection
    private Bois boisScript; // Référence au script Bois
    private Stone stoneScript; // Référence au script Stone
    private Gold goldScript; // Référence au script Gold
    private Collider soldierCollider; // Référence au Collider du soldat

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir la référence au script Selection
        selectionScript = GameObject.FindGameObjectWithTag("empty").GetComponent<Selection>();

        // Obtenir les références aux scripts Bois, Stone et Gold
        boisScript = GameObject.FindObjectOfType<Bois>();
        stoneScript = GameObject.FindObjectOfType<Stone>();
        goldScript = GameObject.FindObjectOfType<Gold>();

    }

    // Cette méthode est appelée lorsque le Collider du soldat entre en collision avec un autre Collider
    void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'autre Collider a le tag "Cube"
        if (other.gameObject.tag == "Cube")
        {
            // Vérifier si l'objet est présent dans l'une des listes du script "selection"
            if (selectionScript.listeGameObjectWOOD.Contains(other.gameObject))
            {
                // Supprimer l'objet de la liste, incrémenter la variable correspondante de 100 et détruire le premier enfant de l'objet
                selectionScript.listeGameObjectWOOD.Remove(other.gameObject);
                boisScript._nbBois += 100;
                Destroy(other.gameObject.transform.GetChild(0).gameObject);
            }
            else if (selectionScript.listeGameObjectStone.Contains(other.gameObject))
            {
                selectionScript.listeGameObjectStone.Remove(other.gameObject);
                stoneScript._nbStone += 100;
                Destroy(other.gameObject.transform.GetChild(0).gameObject);
            }
            else if (selectionScript.listeGameObjectGold.Contains(other.gameObject))
            {
                selectionScript.listeGameObjectGold.Remove(other.gameObject);
                goldScript._nbGold += 100;
                Destroy(other.gameObject.transform.GetChild(0).gameObject);
            }
        }
    }

}