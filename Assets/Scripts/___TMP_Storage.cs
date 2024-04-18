using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ___TMP_Storage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ressourceTag")
        {
            Debug.Log("dead body entered, add ressources ---- mana : ");
            other.transform.parent.GetComponent<workersRecolt>().isCharged = false;
            Destroy(other.gameObject);
        }
    }
}
