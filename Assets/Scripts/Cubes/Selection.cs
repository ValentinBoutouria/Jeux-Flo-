using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public Material _matSelection; // Le nouveau matériau que vous souhaitez appliquer

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
        // Vérifie si l'utilisateur clique avec le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            // Convertit la position du curseur de la souris en un rayon dans la scène
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Lance un rayon et vérifie s'il a touché un objet avec le tag "Cube"
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cube"))
            {
                // L'objet touché a le tag "Cube", vous pouvez implémenter ici la logique de sélection
                Debug.Log("Cube sélectionné : " + hit.collider.gameObject.name);
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                renderer.material = _matSelection;
            }
        }

    }
   
    
}
