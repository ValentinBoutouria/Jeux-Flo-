using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildLader : MonoBehaviour
{
    public GameObject lader;
    private List<GameObject> listeobjectiveLader;
    private Selection selectionScript;
    public workersRecolt isSelectedScript;

    private GameObject laderInstance;
    // Start is called before the first frame update
    void Start()
    {
        selectionScript = GameObject.FindObjectOfType<Selection>();
        listeobjectiveLader = selectionScript.gameObjectListSelectionne;
        isSelectedScript = gameObject.GetComponent<workersRecolt>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelectedScript.selected && Input.GetKeyDown(KeyCode.Keypad8))
        {
            Debug.Log("Mouvement initié");

            this.GetComponent<setMovement>().setMovementDest(listeobjectiveLader[0].transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject == listeobjectiveLader[0])
            {
                laderInstance = Instantiate(lader, other.transform);
                laderInstance.transform.parent = selectionScript.gameObject.transform;
                selectionScript.listeGameObjectBatimentPresent.Add(laderInstance);
                Destroy(listeobjectiveLader[0]);
                listeobjectiveLader.RemoveAt(0);
            }
        }
        catch { }

    }
}
