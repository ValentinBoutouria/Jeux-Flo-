using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    private int numeroHexa;

    public int _nbMaxHexaStone;
    public int _nbMaxHexaWood;
    public int _nbMaxHexaGold;

    private int _nbHexaStone;
    private int _nbHexaWood;
    private int _nbHexaGold;

    private float posCamX; //Pos camX
    private float posCamY; //Pos camY

    void Start()
    {
        GenerateGrid();
        _nbHexaWood = 0;
        _nbHexaGold = 0;
        _nbHexaStone = 0;
    }
    void AleaHexa()
    {
        numeroHexa = Random.Range(0, prefabs.Count-1);
        cellPrefab=prefabs[numeroHexa];

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
                    float zPos = (cellSize/2)*z;
                    // Calcule la position de la cellule dans la grille
                    Vector3 cellPosition = new Vector3(xPos, zPos, yPos);
                    
                    if(z==0)
                    {
                        ControlePaquet();//on verifie si on doit changer le block
                        newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                        DetHexaPrefab();
                        
                        _selection.listeGameObjectNONSelect.Add(newCell);//on ajoute les hexa "spawnable" aussi a la liste "nonselect" pour poser des bat dessus

                    }
                    else
                    {
                        cellPrefab = prefabs[prefabs.Count-1];
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
    void DetHexaPrefab()
    {
        switch (prefabs[numeroHexa].name)
        {
            case "WoodHexa":
                _selection.listeGameObjectHexaWood.Add(newCell);
               
                break;
            case "StoneHexa":
                _selection.listeGameObjectHexaStone.Add(newCell);//ajout liste stone
                
                break;
            case "GoldHexa": 
                _selection.listeGameObjectHexaGold.Add(newCell);
                //_nbHexaGold++;
                break;
            default:
                //Debug.Log("Paquet non reconnu !");
                _selection.listeGameObjectNONSelect.Add(newCell);//Pas selectionnable les hexa de loot
                break;
        }
    }


    void MaxHexaAtteind()
    {
        if(_nbHexaGold==_nbMaxHexaGold)
        {
            prefabs.Remove(prefabs[parcourlist(prefabs, "GoldHexa")]);//on retire la possibilité de tomber sur l'hexa ou le Gold peut spawn
            _nbHexaGold++;
        }
        if (_nbHexaStone == _nbMaxHexaStone)
        {
            
            prefabs.Remove(prefabs[parcourlist(prefabs, "StoneHexa")]);//on retire la possibilité de tomber sur l'hexa ou le Gold peut spawn
            _nbHexaStone++;
        }
        if (_nbHexaWood == _nbMaxHexaWood)
        {
            prefabs.Remove(prefabs[parcourlist(prefabs, "WoodHexa")]);//on retire la possibilité de tomber sur l'hexa ou le Gold peut spawn
            _nbHexaWood++;
        }
    }



    void ControlePaquet()
    {
        if (compteurpaquet == paquet)//on a atteind le nombre de meme hexa voulu
        {
            MaxHexaAtteind();
            AleaHexa();//Choisi aleatoirement un hexagone parmi les n-1
            if (cellPrefab.name=="WoodHexa")
            {
                _nbHexaWood++;
            }
            if (cellPrefab.name == "StoneHexa")
            {
                _nbHexaStone++;
            }
            if (cellPrefab.name == "GoldHexa")
            {
                _nbHexaGold++;
            }
           
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

    int parcourlist(List<GameObject> list,string objectname)
    {
        int index=0;
        for (int i = 0; i < prefabs.Count; i++)
        {
            if (prefabs[i].name==objectname)
            {
                index = i;

            }


        }
        return index;
    }
}
