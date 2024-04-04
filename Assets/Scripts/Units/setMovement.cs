using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class setMovement : MonoBehaviour
{
    private GameObject selectionController;
    public UnityEngine.Vector3 worldPos;
    private UnityEngine.Plane plane = new UnityEngine.Plane(UnityEngine.Vector3.up, 0);
    public Transform _tf_dest;

    // Start is called before the first frame update
    void Start()
    {
        selectionController = GameObject.FindGameObjectWithTag("selectionController");
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetMouseButtonUp(1))
        {
            //pos.position = Input.mousePosition;
            if(UnityEngine.Input.GetMouseButtonUp(1))
            {
                float distance;
                Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
                if (plane.Raycast(ray, out distance))
                {
                    worldPos = ray.GetPoint(distance);
                }
            }

            if (selectionController.GetComponent<SelectionController>().selectedWarriorList.Contains(this.gameObject) )
            {
                setMovementDest(worldPos);
            }
        }
    }

    public void setMovementDest(UnityEngine.Vector3 position)
    {
        _tf_dest.gameObject.SetActive(true);
        _tf_dest.position = position; 
    }


}
