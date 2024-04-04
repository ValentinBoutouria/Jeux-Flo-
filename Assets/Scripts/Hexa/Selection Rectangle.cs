using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRectangle : MonoBehaviour
{
  
    public GameObject hexagonPrefab; // Le pr�fabriqu� de votre hexagone
    public LayerMask hexagonLayer; // La couche � laquelle appartiennent les hexagones

    bool isSelecting = false;
    Vector3 startPosition;
    Vector3 endPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Quand le bouton gauche de la souris est enfonc�
        {
            isSelecting = true;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0)) // Quand le bouton gauche de la souris est rel�ch�
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
        // Obtenir le rectangle entre la position de d�part et la position actuelle de la souris
        Rect rect = new Rect(startScreenPos.x, Screen.height - startScreenPos.y, endScreenPos.x - startScreenPos.x, -1 * (endScreenPos.y - startScreenPos.y));
        return rect;
    }

    void SelectHexagons()
    {
        Collider2D[] hitColliders = Physics2D.OverlapAreaAll(startPosition, endPosition, hexagonLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            // Marquer les hexagones s�lectionn�s
            GameObject hexagon = hitCollider.gameObject;
            hexagon.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
