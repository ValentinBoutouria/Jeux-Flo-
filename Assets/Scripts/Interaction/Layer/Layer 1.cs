using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer1 : MonoBehaviour
{

    public LayerSelection _layerselection;
    public List<GameObject> ObjectDetruit = new List<GameObject>();
    public List<GameObject> ObjectDetruit1 = new List<GameObject>();
    public List<GameObject> ObjectDetruit2 = new List<GameObject>();
    public List<GameObject> ObjectDetruit3 = new List<GameObject>();
    public GameObject _layerPoint0;
    public GameObject _layerPoint1;
    public GameObject _layerPoint2;
    public GameObject _layerPoint3;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = _layerPoint0.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTrueObject();
        
    }
    void SetTrueObject()
    {
        if (_layerselection.layer==0)//faire un switch case break
        {
            this.transform.position = _layerPoint0.transform.position;
            foreach (GameObject obj in ObjectDetruit) 
           {
                obj.SetActive(true);
           }
        }
        if (_layerselection.layer == -1)
        {
            this.transform.position = _layerPoint1.transform.position;
        }
        if ( _layerselection.layer == -2)
        {
            this.transform.position = _layerPoint2.transform.position;
        }
        if (_layerselection.layer == -3)
        {
            this.transform.position = _layerPoint3.transform.position;
        }

    }
    
    private void OnTriggerStay(Collider other)
    {//ajouter dans la bonne liste suivant le bon layout pour les reactiver 
            ObjectDetruit.Add(other.gameObject);
            other.gameObject.SetActive(false);  
    }
   
    
}
