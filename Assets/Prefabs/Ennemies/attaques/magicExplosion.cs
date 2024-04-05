using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class magicExplosion : MonoBehaviour
{
    private GameObject selectionController;
    public GameObject carac;

    private List<(GameObject, int)> li;
    // Start is called before the first frame update
    void Start()
    {
        selectionController = GameObject.FindGameObjectWithTag("selectionController");
        List<GameObject> list = selectionController.GetComponent<SelectionController>().availableWarriorList;
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();


        // GameObject[] _list = new GameObject[selectionController.GetComponent<SelectionController>().availableWarriorList.Capacity];
        // selectionController.GetComponent<SelectionController>().availableWarriorList.CopyTo(_list);
        foreach (GameObject warrior in list)
        {
            float dist = Vector3.Distance(gameObject.transform.position, warrior.transform.position);
            if (dist < transform.GetChild(0).GetComponent<ParticleSystem>().main.startSpeedMultiplier)
            {
                int dgt = (int)(carac.GetComponent<caracEnnemie>().getAttaque() / (0.3 * dist + 1));
                li.Add((warrior, dgt));
            }
        }

        foreach (var warrior in li) 
        {
            warrior.Item1.transform.parent.GetComponent<health>().getDamages(warrior.Item2);

        }

        try
        {

            }
            catch { }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).GetComponent<ParticleSystem>().isStopped)
        {
            Destroy(gameObject);
        }
    }
}
