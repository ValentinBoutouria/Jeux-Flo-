using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goToDest : MonoBehaviour
{
    private int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().parent.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Transform>().parent.GetChild(1).gameObject.activeSelf)
        {
            var dest = this.GetComponent<Transform>().parent.GetChild(1).position;

            if(Vector3.Distance(this.gameObject.GetComponent<Transform>().position, dest) < 1)
            {
                this.GetComponent<Transform>().parent.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.GetComponent<Transform>().position = Vector3.MoveTowards(this.gameObject.GetComponent<Transform>().position, dest, Time.deltaTime * speed);
            }
        }
    }
}
