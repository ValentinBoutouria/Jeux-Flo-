using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class recupRessourcesUnits : MonoBehaviour
{
    private Selection selectionScript; // R�f�rence au script Selection
    private Ressources ressourcesScript; // R�f�rence au script Gold
    private Collider soldierCollider; // R�f�rence au Collider du soldat
    private int Gains;

    // Start is called before the first frame update
    void Start()
    {
        Gains = 100;//combien on gagne de ressource quand on la recup
        // Obtenir la r�f�rence au script Selection
        selectionScript = GameObject.FindGameObjectWithTag("empty").GetComponent<Selection>();

        // Obtenir les r�f�rences aux scripts Bois, Stone et Gold
        ressourcesScript = GameObject.FindObjectOfType<Ressources>();
       

    }

    // Cette m�thode est appel�e lorsque le Collider du soldat entre en collision avec un autre Collider
    /*
    void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'autre Collider a le tag "Cube"
        if (other.gameObject.tag == "Cube")
        {
            // V�rifier si l'objet est pr�sent dans l'une des listes du script "selection"
            if (selectionScript.listeGameObjectWOOD.Contains(other.gameObject))
            {
                // Supprimer l'objet de la liste, incr�menter la variable correspondante de 100 et d�truire le premier enfant de l'objet
                selectionScript.listeGameObjectWOOD.Remove(other.gameObject);
                selectionScript.listeGameObjectNONSelect.Add(other.gameObject);//apres recuperation on ajout l'hexa dans la liste non select pour pouvoir poser un bat
                ressourcesScript._nbWood += Gains;
                Destroy(other.gameObject.transform.GetChild(0).gameObject);
            }
            else if (selectionScript.listeGameObjectStone.Contains(other.gameObject))
            {
                selectionScript.listeGameObjectStone.Remove(other.gameObject);
                selectionScript.listeGameObjectNONSelect.Add(other.gameObject);//apres recuperation on ajout l'hexa dans la liste non select pour pouvoir poser un bat
                ressourcesScript._nbStone += Gains;
                Destroy(other.gameObject.transform.GetChild(0).gameObject);
            }
            else if (selectionScript.listeGameObjectGold.Contains(other.gameObject))
            {
                selectionScript.listeGameObjectGold.Remove(other.gameObject);
                selectionScript.listeGameObjectNONSelect.Add(other.gameObject);//apres recuperation on ajout l'hexa dans la liste non select pour pouvoir poser un bat
                ressourcesScript._nbGold += Gains;
                Destroy(other.gameObject.transform.GetChild(0).gameObject);
            }
        }
    }
    */

}