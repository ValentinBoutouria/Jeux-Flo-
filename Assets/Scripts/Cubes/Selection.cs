using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public Material _matSelection; // Le nouveau mat�riau que vous souhaitez appliquer
    public AjoutPoint ScriptAjout;
    private Material _matInitial; //Material initial de l'hexagone
    private Deselction deselction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
        // V�rifie si l'utilisateur clique avec le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            // Convertit la position du curseur de la souris en un rayon dans la sc�ne
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cube"))
            {
                // L'objet touch� a le tag "Cube", vous pouvez impl�menter ici la logique de s�lection
                //Debug.Log("Cube s�lectionn� : " + hit.collider.gameObject.name);
                deselction=hit.collider.gameObject.GetComponent<Deselction>();//on recupere le script deselection pour changer le bool
                Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
                renderer.material = _matSelection;//on place le mat selection
                deselction.Select=true;//on met le bool Selection a true
                ScriptAjout.scoreSelect = ScriptAjout.scoreSelect + 1; //on ajout le score de 1 vu qu'on selectionne

            }
        }

    }
   
    
}
