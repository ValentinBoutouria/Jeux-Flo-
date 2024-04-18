using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goToDest : MonoBehaviour
{
    private int speed;
    private float portee;

    private GameObject body;
    public Transform _tf_dest;
    private GameObject ennemie;
    private bool isEnnemie;

    private float minDist = 1;


    // Start is called before the first frame update
    void Start()
    {
        _tf_dest.gameObject.SetActive(false);
        speed = this.GetComponent<Transform>().parent.parent.parent.GetChild(0).GetComponent<caracteristique>().getVitesse();
        portee = this.GetComponent<Transform>().parent.parent.parent.GetChild(0).GetComponent<caracteristique>().getPortee();

        body = this.GetComponent<Transform>().parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_tf_dest.gameObject.activeSelf)
        {
            if (isEnnemie)
            {
                minDist = portee*0.9f;
                try
                {
                    if (ennemie == null)
                    {
                        _tf_dest.gameObject.SetActive(false);
                        minDist = 1;
                    }
                    else
                    {
                        _tf_dest.position = Vector3.MoveTowards(transform.position, ennemie.transform.position, Vector3.Distance(transform.position, ennemie.transform.position) - portee);
                        gameObject.GetComponent<attack>().setEnnemie(ennemie);
                    }
                }
                catch { }
            }
            else
            {
                gameObject.GetComponent<attack>().setEnnemie(null);
            }

            if (!isEnnemie && Vector3.Distance(body.GetComponent<Transform>().position, _tf_dest.position) < minDist)
            {
                _tf_dest.gameObject.SetActive(false);
                minDist = 1;
            }
            else
            {
                body.GetComponent<Transform>().position = Vector3.MoveTowards(body.transform.position, _tf_dest.position, Time.deltaTime * speed);
            }
        }
    }


    public void setIsEnnemie(bool maybe)
    {
        isEnnemie = maybe;
    }

    public void goToEnnemie(GameObject e)
    {
        ennemie = e;
        gameObject.GetComponent<attack>().setEnnemie(e);
        _tf_dest.position = ennemie.GetComponent<Transform>().position;
        _tf_dest.gameObject.SetActive(true);
    }
}


