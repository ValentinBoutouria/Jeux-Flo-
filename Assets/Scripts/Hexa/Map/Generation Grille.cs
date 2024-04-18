using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationGrille : MonoBehaviour
{
    // Start is called before the first frame update
  
    private GameObject cellPrefab; // Pr�fabriqu� de la cellule de la grille
    private GameObject newCell;
    public List<GameObject> prefabs = new List<GameObject>();
   
    public Selection _selection;
    public GameObject cam; // GameObject de la camera
    public int gridSizeX = 5; // Nombre de cellules en largeur
    public int gridSizeY = 5; // Nombre de cellules en hauteur
    public int gridSizeZ = 2; // Nombre de cellules en hauteur

    public float cellSize = 1f; // Taille de chaque cellule
    private int paquet = 2;
    private int compteurpaquet = 2;
    private float posCamX; //Pos camX
    private float posCamY; //Pos camY

    void Start()
    {
        GenerateGrid();
    }
    void AleaHexa()
    {
        int randomNumber = Random.Range(0, prefabs.Count-1);
        cellPrefab=prefabs[randomNumber];

    }

    void GenerateGrid()
    {
        CalibrageCamera();
        // Boucle pour cr�er chaque cellule de la grille
        for(int z = 0; z > -gridSizeZ; z--)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    // Calculer la position de l'hexagone
                    float xPos = x * (cellSize/2);
                    float yPos = (x % 2 == 0 ? 0 : 0.866f) + y * (1.732f * cellSize);
                    float zPos = (cellSize/5)*z;
                    // Calcule la position de la cellule dans la grille
                    Vector3 cellPosition = new Vector3(xPos, zPos, yPos);
                    
                    if(z==0)
                    {
                        ControlePaquet();//on verifie si on doit changer le block
                        newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                        _selection.listeGameObjectNONSelect.Add(newCell);
                    }
                    else
                    {
                        cellPrefab = prefabs[6];
                        newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                        _selection.listeGameObjectSousSol.Add(newCell);
                    }
                    newCell.transform.localScale = new Vector3(cellSize, 1f, cellSize); // R�glage de la taille de la cellule
                    newCell.transform.parent = transform; // D�finit le parent de la cellule en tant que gameObject de grille pour une organisation "propre"
                    // Instancie une nouvelle cellule de la grille � la position calcul�e
                }
            }
        }
    }
    void CalibrageCamera()
    {
        posCamX=gridSizeX/2;
        posCamY=gridSizeY;
        Vector3 posCamVect=new Vector3 (posCamX,gridSizeY*2,posCamY);
        cam.transform.localPosition =posCamVect;


    }
    void DetCellPrefab()
    { 
    }
    void ControlePaquet()
    {
        if (compteurpaquet == paquet)//on a atteind le nombre de meme hexa voulu
        {
            AleaHexa();//Choisi aleatoirement un hexagone parmi les n-1
            AleaPaquet();//donne un nombre de paquet d'hexa random
            compteurpaquet = 0;

        }
        else
        {
            compteurpaquet++;
        }

    }
    void AleaPaquet()
    {
        paquet = Random.Range(1, 5);

    }
}
