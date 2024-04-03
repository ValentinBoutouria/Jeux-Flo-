using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselction : MonoBehaviour
{
    public bool Select=false;
    public Material _matInitial;
    public AjoutPoint ScriptAjout;
    // Start is called before the first frame update
    void Start()
    {
        //Renderer renderer = GetComponent<Renderer>();
        //_matInitial=renderer.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        // V�rifie si l'utilisateur clique avec le bouton Droit de la souris
        if (Input.GetMouseButtonDown(1))
        {
            // Convertit la position du curseur de la souris en un rayon dans la sc�ne
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cube"))
            {
                // L'objet touch� a le tag "Cube", vous pouvez impl�menter ici la logique de s�lection
                //Debug.Log("Cube s�lectionn� : " + hit.collider.gameObject.name);
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                Deselction deselect =hit.collider.GetComponent<Deselction>();
                if(renderer.material !=_matInitial)
                {
                    deselect.Select=false;
                    //ScriptAjout.scoreSelect = ScriptAjout.scoreSelect - 1; //on retire le score de 1 vu qu'on deselectionne
                    renderer.material= _matInitial;
                }
            }
        }
        
    }
}
