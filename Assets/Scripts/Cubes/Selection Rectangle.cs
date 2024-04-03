using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRectangle : MonoBehaviour
{
  
    public GameObject hexagonPrefab; // Le préfabriqué de votre hexagone
    public LayerMask hexagonLayer; // La couche à laquelle appartiennent les hexagones

    bool isSelecting = false;
    Vector3 startPosition;
    Vector3 endPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Quand le bouton gauche de la souris est enfoncé
        {
            isSelecting = true;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0)) // Quand le bouton gauche de la souris est relâché
        {
            isSelecting = false;
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectHexagons();
        }
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            // Dessiner un rectangle imaginaire
            Rect rect = GetScreenRect(startPosition, Input.mousePosition);
            GUI.Box(rect, "");
        }
    }

    Rect GetScreenRect(Vector3 startScreenPos, Vector3 endScreenPos)
    {
        // Obtenir le rectangle entre la position de départ et la position actuelle de la souris
        Rect rect = new Rect(startScreenPos.x, Screen.height - startScreenPos.y, endScreenPos.x - startScreenPos.x, -1 * (endScreenPos.y - startScreenPos.y));
        return rect;
    }

    void SelectHexagons()
    {
        Collider2D[] hitColliders = Physics2D.OverlapAreaAll(startPosition, endPosition, hexagonLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            // Marquer les hexagones sélectionnés
            GameObject hexagon = hitCollider.gameObject;
            hexagon.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
