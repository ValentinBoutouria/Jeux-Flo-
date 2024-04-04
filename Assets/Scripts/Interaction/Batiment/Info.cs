using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public Selection _selection;
    public GameObject _panelInfo;
    public Material _matselect;
    public Material _matBat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // V�rifie si l'utilisateur clique avec le bouton gauche de la souris
        {
            selectionBat();
        }
        if (Input.GetMouseButtonUp(1)) // V�rifie si l'utilisateur clique avec le bouton droit de la souris
        {
            deselectionBat();
        }

    }
    void selectionBat()
    {

        // Convertit la position du curseur de la souris en un rayon dans la sc�ne
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Batiment"))
        {
                //_selection.gameObjectListSelectionne.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste selectionne
                //_selection.listeGameObjectNONSelect.Remove(hit.collider.gameObject);
                Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
                renderer.material = _matselect;//on place le mat selection
        }
    }
    void deselectionBat()
    {
        // Convertit la position du curseur de la souris en un rayon dans la sc�ne
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Batiment"))
        {
            //_selection.gameObjectListSelectionne.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste selectionne
            //_selection.listeGameObjectNONSelect.Remove(hit.collider.gameObject);
            Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
            renderer.material = _matBat;//on place le mat selection
        }

    }
}
