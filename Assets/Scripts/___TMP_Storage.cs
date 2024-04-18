using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ___TMP_Storage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "deadBody")
        {
            Debug.Log("dead body entered, add ressources ---- mana : " + other.gameObject.GetComponent<deadBodies>().mana + "  ------ corpses : " + other.gameObject.GetComponent<deadBodies>().corpse);
            Destroy(other.gameObject);
        }
    }
}
