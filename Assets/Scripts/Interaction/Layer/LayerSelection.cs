using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LayerSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public int layer;
    public TMP_Text _layerUi;
    public GameObject _boxLayer1;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _layerUi.text = "Layer : "+layer;
        LayerAttribution();
        
    }
    public void UpBouton()
    {
        layer += 1;

    }
    public void DownBouton()
    {
        layer -= 1;

    }
    public void LayerAttribution()
    {
        
       

    }

   



}
