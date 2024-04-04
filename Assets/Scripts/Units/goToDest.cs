using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goToDest : MonoBehaviour
{
    private int speed;
    private GameObject body;
    public Transform _tf_dest;

    // Start is called before the first frame update
    void Start()
    {
        _tf_dest.gameObject.SetActive(false);
        speed = this.GetComponent<Transform>().parent.parent.parent.GetChild(0).GetComponent<caracteristique>().getVitesse();
        body = this.GetComponent<Transform>().parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(_tf_dest.gameObject.activeSelf)
        {
            if(Vector3.Distance(body.GetComponent<Transform>().position, _tf_dest.position) < 1)
            {
                _tf_dest.gameObject.SetActive(false);
            }
            else
            {
                body.GetComponent<Transform>().position = Vector3.MoveTowards(body.GetComponent<Transform>().position, _tf_dest.position, Time.deltaTime * speed);
            }
        }
    }
}
