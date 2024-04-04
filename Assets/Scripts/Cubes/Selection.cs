using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public Material _matSelection; // Le nouveau mat�riau que vous souhaitez appliquer
    public AjoutPoint ScriptAjout;
    public Material _matInitial; //Material initial de l'hexagone
    public List<GameObject> gameObjectListSelectionne = new List<GameObject>();
    public int nbGameObjectSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateNbGameObjectSelect()
    {
        nbGameObjectSelect=gameObjectListSelectionne.Count;//nbGameObjectSelect element selectionne
    }

    void CliqueGauche()
    {
        // Convertit la position du curseur de la souris en un rayon dans la sc�ne
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cube"))
        {
            // L'objet touch� a le tag "Cube", vous pouvez impl�menter ici la logique de s�lection
            //Debug.Log("Cube s�lectionn� : " + hit.collider.gameObject.name);
            //deselction=hit.collider.gameObject.GetComponent<Deselction>();//on recupere le script deselection pour changer le bool
            Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
            renderer.material = _matSelection;//on place le mat selection
            if (!gameObjectListSelectionne.Contains(hit.collider.gameObject))//uniquement si PAS selectionne
            {
            //ScriptAjout.scoreSelect = ScriptAjout.scoreSelect + 1; //on ajout le score de 1 vu qu'on selectionne
            //deselction.Select=true;//on met le bool Selection a true
            gameObjectListSelectionne.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste
            }
        }
    }

    void CliqueDroit()
    {
        // Convertit la position du curseur de la souris en un rayon dans la sc�ne
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cube"))
        {
            // L'objet touch� a le tag "Cube", vous pouvez impl�menter ici la logique de s�lection
            //Debug.Log("Cube s�lectionn� : " + hit.collider.gameObject.name);
            //deselction = hit.collider.gameObject.GetComponent<Deselction>();//on recupere le script deselection pour changer le bool
            Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
            renderer.material = _matInitial;//on place le mat deselection

            if (gameObjectListSelectionne.Contains(hit.collider.gameObject))//uniquement si DEJA selectionne
            {
                //ScriptAjout.scoreSelect = ScriptAjout.scoreSelect - 1; //on ajout le score de 1 vu qu'on selectionne
                //deselction.Select = false;//on met le bool Selection a true
                gameObjectListSelectionne.Remove(hit.collider.gameObject);//on retire le game object selectionne dans la liste
            }
        }       
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))// V�rifie si l'utilisateur clique avec le bouton droit de la souris
        {
            CliqueDroit();
        }

        if (Input.GetMouseButtonDown(0)) // V�rifie si l'utilisateur clique avec le bouton gauche de la souris
        {
            CliqueGauche();  
        }

        UpdateNbGameObjectSelect();
    }
   
    
}
