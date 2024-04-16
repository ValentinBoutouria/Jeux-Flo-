using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class magicExplosion : MonoBehaviour
{
    private SelectionController selectionController;
    public GameObject carac;

    private List<(GameObject, int)> li = new List<(GameObject, int)>();
    public int dgt;
    // Start is called before the first frame update
    void Start()
    {
        selectionController = GameObject.FindGameObjectWithTag("selectionController").GetComponent<SelectionController>();
        List<GameObject> list = selectionController.availableWarriorList;
        GetComponent<ParticleSystem>().Play();


        // GameObject[] _list = new GameObject[selectionController.GetComponent<SelectionController>().availableWarriorList.Capacity];
        // selectionController.GetComponent<SelectionController>().availableWarriorList.CopyTo(_list);
        foreach (GameObject warrior in list)
        {
            float dist = Vector3.Distance(gameObject.transform.position, warrior.transform.position);
            if (dist < GetComponent<ParticleSystem>().main.startSpeedMultiplier)
            {
                dgt = (int)(carac.GetComponent<caracEnnemie>().getAttaque() / (0.1*dist + 1));

                li.Add((warrior, dgt));
            }
        }
        
        foreach (var warrior in li) 
        {
            warrior.Item1.transform.parent.GetComponent<health>().getDamages(warrior.Item2);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ParticleSystem>().isStopped)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
