using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    //Camera
    public Camera m_camera;

    //Rectangle de s�lection
    public RectTransform selectionBox;

    //Unit�s disponibles
    public List<GameObject> availableWarriorList;

    //Unit�s s�lectionn�es
    public List<GameObject> selectedWarriorList;

    //Position du rectangle de s�lection au moment o� on clique  
    private Vector2 startPos;

    private bool isDown = false;

    private void Awake()
    {
        //Initialise selectedWarriorList
        selectedWarriorList = new List<GameObject>();

        //Le rectangle de s�lection ne doit pas �tre visible
        selectionBox.gameObject.SetActive(false);

    }

    private void Update()
    {
        //Cherche toutes les unit� sur la sc�ne et remplit availableWarriorList
        availableWarriorList.Clear();
        foreach (var warrior in GameObject.FindGameObjectsWithTag("unit"))
            availableWarriorList.Add(warrior.gameObject);
        //Si on clique sur le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            //D�selectionne toutes les unit�s
            foreach (GameObject warrior in availableWarriorList)
                warrior.GetComponent<select_unselect>().UnSelect();

            //Vide le tableau
            selectedWarriorList.Clear();

            //Position de la souris au moment du clique
            startPos = Input.mousePosition;

            isDown = true;

            //Fait apparaitre le rectangle de s�lection
            selectionBox.gameObject.SetActive(true);
        }

        //Si on rel�che le bouton gauche de la souris
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;

            //Fait disparaitre le rectangle de s�lection
            selectionBox.gameObject.SetActive(false);

        }


        //Si on n'est pas en train d'appuyer le bouton, on return pour ne pas lire le reste du script
        if (!isDown)
            return;

        //Position de la souris cette frame
        Vector2 curMousePos = Input.mousePosition;

        //Position du rectangle de s�lection
        selectionBox.anchoredPosition = startPos;

        //Calcule de la taille du rectangle de s�lection
        // position actuelle de la souris - osition au moment du clique
        float width = curMousePos.x - startPos.x;
        float height = curMousePos.y - startPos.y;

        selectionBox.anchoredPosition = startPos + new Vector2(width / 2, height / 2);
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));

        //Permettra de savoir si une unit� rentre dans le rectangle de s�lection
        Bounds bounds = new Bounds(selectionBox.anchoredPosition,
            selectionBox.sizeDelta);

        //Parcours toutes les unite�s
        foreach (GameObject warrior in availableWarriorList)
        {
            //Convertit la position 3D de l'unit� en position 2D sur l'�cran
            Vector2 posVector2 = m_camera.WorldToScreenPoint(warrior.transform.position);

            //V�rifie si l'unit� est dans le rectangle
            if (CheckWarriorInBox(posVector2, bounds))
            {
                //Si oui, on s�lectionne l'unit�
                if(!selectedWarriorList.Contains(warrior))
                {
                    warrior.GetComponent<select_unselect>().Select();
                    selectedWarriorList.Add(warrior);
                }
            }
            else
            {
                warrior.GetComponent<select_unselect>().UnSelect();
                selectedWarriorList.Remove(warrior);
            }
        }
    }

    //Fonction qui v�rifie si l'unit� est dans le rectangle
    private bool CheckWarriorInBox(Vector2 position, Bounds bounds)
    {

        return position.x > bounds.min.x
            && position.x < bounds.max.x
            && position.y > bounds.min.y
            && position.y < bounds.max.y;
    }


}