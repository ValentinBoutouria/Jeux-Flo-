using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationGrille : MonoBehaviour
{
    // Start is called before the first frame update
  
    public GameObject cellPrefab; // Préfabriqué de la cellule de la grille
    public int gridSizeX = 5; // Nombre de cellules en largeur
    public int gridSizeY = 5; // Nombre de cellules en hauteur
    public float gridEcartX = 1f; // Nombre D'ecart entre les cellules en X
    public float gridEcartY = 1f; // Nombre D'ecart entre les cellules en Y
    public float cellSize = 1f; // Taille de chaque cellule

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Boucle pour créer chaque cellule de la grille
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                // Calcule la position de la cellule dans la grille
                Vector3 cellPosition = new Vector3(x * (cellSize+gridEcartX), 0, y * (cellSize+ gridEcartY));

                // Instancie une nouvelle cellule de la grille à la position calculée
                GameObject newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                newCell.transform.localScale = new Vector3(cellSize, 1f, cellSize); // Réglage de la taille de la cellule
                newCell.transform.parent = transform; // Définit le parent de la cellule en tant que gameObject de grille pour une organisation propre
            }
        }
    }
}
