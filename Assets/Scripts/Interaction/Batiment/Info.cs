using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Info : MonoBehaviour
{
    public Selection _selection;
    public GameObject _panelInfo;
    public Material _matselect;
    public Material _matBat;
    public GameObject _panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // V�rifie si l'utilisateur clique avec le bouton gauche de la souris
        {
            CliqueselectionBat();
        }
        if (Input.GetMouseButtonUp(1)) // V�rifie si l'utilisateur clique avec le bouton droit de la souris
        {
            CliquedeselectionBat();
        }
        VerificationPanelInfo();

    }
    public void VerificationPanelInfo()
    {
        if (_selection.listeGameObjectbatimentSelect.Count==1)
        {
            _panel.SetActive(true);
        }
        else
        {
            _panel.SetActive(false);
        }
    }
    public void VerifieSelectionBat()
    {
        if (_selection.listeGameObjectbatimentSelect.Count==1)//il y a un batiment deja selectionne
        {
            
           GameObject test= _selection.listeGameObjectbatimentSelect[0];
           Renderer renderer=test.GetComponent<Renderer>();
           renderer.material=_matBat;
           _selection.listeGameObjectbatimentSelect.Clear();
           //liste est vide et le mat bat a bien ete remis
        }
        if (_selection.listeGameObjectbatimentSelect.Count==0)
        {
        }
    }
    void CliqueselectionBat()
    {

        // Convertit la position du curseur de la souris en un rayon dans la sc�ne
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Batiment"))
        {
                //_selection.gameObjectListSelectionne.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste selectionne
                //_selection.listeGameObjectNONSelect.Remove(hit.collider.gameObject);
                VerifieSelectionBat();
                _panel.SetActive(true);
                _selection.listeGameObjectbatimentSelect.Add(hit.collider.gameObject);
                Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
                renderer.material = _matselect;//on place le mat selection
        }
    }
    void CliquedeselectionBat()
    {
        // Convertit la position du curseur de la souris en un rayon dans la sc�ne
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Batiment"))
        {
            //_selection.gameObjectListSelectionne.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste selectionne
            //_selection.listeGameObjectNONSelect.Remove(hit.collider.gameObject);
            _selection.listeGameObjectbatimentSelect.Remove(hit.collider.gameObject);
            Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
            renderer.material = _matBat;//on place le mat selection
        }

    }
}
