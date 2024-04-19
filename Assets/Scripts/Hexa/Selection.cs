using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public Material _matSelection; // Le nouveau mat�riau que vous souhaitez appliquer
    public GenerationGrille _grille;
    public Material _matInitial; //Material initial de l'hexagone

    public List<GameObject> gameObjectListSelectionne = new List<GameObject>();
    public List<GameObject> listeGameObjectNONSelect = new List<GameObject>();

    public List<GameObject> listeGameObjectSousSol = new List<GameObject>();

    public List<GameObject> listeGameObjectWOOD = new List<GameObject>();
    public List<GameObject> listeGameObjectStone = new List<GameObject>();
    public List<GameObject> listeGameObjectGold = new List<GameObject>();

    public List<GameObject> listeGameObjectBatimentPresent = new List<GameObject>();
    public List<GameObject> listeGameObjectbatimentSelect = new List<GameObject>(1); // Définir la taille maximale à 1

    public List<GameObject> listeGameObjectHexaWood = new List<GameObject>();
    public List<GameObject> listeGameObjectHexaStone = new List<GameObject>();
    public List<GameObject> listeGameObjectHexaGold = new List<GameObject>();


    public int nbGameObjectSelect;

    public Ressources _ressources;
    private int Gains;

    // Start is called before the first frame update
    void Start()
    {
        Gains = 100;//combien on gagne de ressources quand on la recupére
        
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
            //clique sur du bois
            if (listeGameObjectWOOD.Contains(hit.collider.gameObject))
            {
                //listeGameObjectNONSelect.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste NON selectionne
                listeGameObjectWOOD.Remove(hit.collider.gameObject);//on retire l'hexa de la liste ou il y avait la ressource (bois)
                listeGameObjectNONSelect.Add(hit.collider.gameObject);//apres recuperation on ajout l'hexa dans la liste non select pour pouvoir poser un bat

                _ressources._nbWood+=Gains;
                Destroy(hit.collider.gameObject.transform.GetChild(0).gameObject);
            }

            //clique sur du Gold
            if (listeGameObjectGold.Contains(hit.collider.gameObject))
            {
                //listeGameObjectNONSelect.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste NON selectionne
                listeGameObjectGold.Remove(hit.collider.gameObject);//on retire l'hexa de la liste ou il y avait la ressource (gold)
                listeGameObjectNONSelect.Add(hit.collider.gameObject);//apres recuperation on ajout l'hexa dans la liste non select pour pouvoir poser un bat

                _ressources._nbGold += Gains;
                Destroy(hit.collider.gameObject.transform.GetChild(0).gameObject);
            }

            //clique sur de la Stone
            if (listeGameObjectStone.Contains(hit.collider.gameObject))
            {
                //listeGameObjectNONSelect.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste NON selectionne
                listeGameObjectStone.Remove(hit.collider.gameObject);//on retire l'hexa de la liste ou il y avait la ressource (Stone)
                listeGameObjectNONSelect.Add(hit.collider.gameObject);//apres recuperation on ajout l'hexa dans la liste non select pour pouvoir poser un bat

                _ressources._nbStone += Gains;
                Destroy(hit.collider.gameObject.transform.GetChild(0).gameObject);
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
            Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
            renderer.material = _matInitial;//on place le mat deselection
            if (gameObjectListSelectionne.Contains(hit.collider.gameObject))//uniquement si dans liste selectionne
            {
                gameObjectListSelectionne.Remove(hit.collider.gameObject);//on retire le game object selectionne dans la liste
                listeGameObjectNONSelect.Add(hit.collider.gameObject);
                if (hit.collider.gameObject.name=="StoneHexa(Clone)")
                {
                    listeGameObjectHexaStone.Add(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.name == "WoodHexa(Clone)")
                {
                    listeGameObjectHexaWood.Add(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.name == "GoldHexa(Clone)")
                {
                    listeGameObjectHexaGold.Add(hit.collider.gameObject);//remettre l'hexa dans la liste pour pouvoir faire spawn des ressources quand on deselectionne
                }
            }
        }       
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))// V�rifie si l'utilisateur clique avec le bouton droit de la souris
        {
            CliqueDroit();
        }

        if (Input.GetMouseButtonUp(0)) // V�rifie si l'utilisateur clique avec le bouton gauche de la souris
        {
            CliqueGauche();  
        }

        if (Input.GetKey(KeyCode.Keypad7))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Lance un rayon et v�rifie s'il a touch� un objet avec le tag "Cube"
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cube"))
            {
                if (GameObject.FindGameObjectWithTag("empty").GetComponent<isWorkerSelected>().nbWorkerSelected > 0 && listeGameObjectNONSelect.Contains(hit.collider.gameObject))
                //uniquement si dans liste NON selectionne || dans les listes des ressources
                {

                    gameObjectListSelectionne.Add(hit.collider.gameObject);//ajout du game object selectionne dans la liste selectionne
                    listeGameObjectNONSelect.Remove(hit.collider.gameObject);
                    if (listeGameObjectHexaWood.Contains(hit.collider.gameObject))
                    {
                        listeGameObjectHexaWood.Remove(hit.collider.gameObject);
                    }
                    if (listeGameObjectHexaStone.Contains(hit.collider.gameObject))
                    {
                        listeGameObjectHexaStone.Remove(hit.collider.gameObject);
                    }
                    if (listeGameObjectHexaGold.Contains(hit.collider.gameObject))
                    {
                        listeGameObjectHexaGold.Remove(hit.collider.gameObject);
                    }
                    Renderer renderer = hit.collider.GetComponent<Renderer>();//on recupere le renderer
                    renderer.material = _matSelection;//on place le mat selection
                }
            }
        }

        UpdateNbGameObjectSelect();
    }
   
    
}
