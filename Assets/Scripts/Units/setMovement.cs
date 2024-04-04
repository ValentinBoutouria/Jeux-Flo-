using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class setMovement : MonoBehaviour
{
    public GameObject selectionController;
    private bool orderGiven = false;
    public UnityEngine.Vector3 worldPos;
    private UnityEngine.Plane plane = new UnityEngine.Plane(UnityEngine.Vector3.up, 0);
    // Start is called before the first frame update
    void Start()
    {
        
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

            foreach (var warrior in selectionController.GetComponent<SelectionController>().selectedWarriorList)
            {
                setMovementDest(worldPos, warrior);
            }
        }
    }

    public void setMovementDest(UnityEngine.Vector3 position, GameObject warrior)
    {
        warrior.GetComponent<Transform>().parent.GetChild(1).gameObject.SetActive(true);
        warrior.GetComponent<Transform>().parent.GetChild(1).position = position; 
    }


}
