using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationGrille : MonoBehaviour
{
    // Start is called before the first frame update
  
    private GameObject cellPrefab; // Pr�fabriqu� de la cellule de la grille
    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject cam; // GameObject de la camera
    public int gridSizeX = 5; // Nombre de cellules en largeur
    public int gridSizeY = 5; // Nombre de cellules en hauteur
    public float gridEcartX = 1f; // Nombre D'ecart entre les cellules en X
    public float gridEcartY = 1f; // Nombre D'ecart entre les cellules en Y
    public float cellSize = 1f; // Taille de chaque cellule
    private float posCamX; //Pos camX
    private float posCamY; //Pos camY

    void Start()
    {
        GenerateGrid();
    }
    void AleaHexa()
    {
        int randomNumber = Random.Range(0, 5);
        cellPrefab=prefabs[randomNumber];

    }

    void GenerateGrid()
    {
        CalibrageCamera();
        // Boucle pour cr�er chaque cellule de la grille
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                // Calcule la position de la cellule dans la grille
                Vector3 cellPosition = new Vector3(x * (cellSize+gridEcartX), 10f, y * (cellSize+ gridEcartY));

                AleaHexa();//Choisi aleatoirement un hexagone parmi les trois
                // Instancie une nouvelle cellule de la grille � la position calcul�e
                GameObject newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                newCell.transform.localScale = new Vector3(cellSize, 1f, cellSize); // R�glage de la taille de la cellule
                newCell.transform.parent = transform; // D�finit le parent de la cellule en tant que gameObject de grille pour une organisation propre
            }
        }
    }
    void CalibrageCamera()
    {
        posCamX=gridSizeX/2;
        posCamY=gridSizeY/2;
        Vector3 posCamVect=new Vector3 (posCamX,50.0f,posCamY);
        cam.transform.localPosition =posCamVect;


    }
}
