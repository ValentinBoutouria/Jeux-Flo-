using UnityEngine;

public class ActivateTargeted : MonoBehaviour
{
    public float activationDistance = 5f; // La distance � laquelle le script "targeted" sera activ�
    private targeted targetedScript; // Une r�f�rence au script "targeted"
    public Transform tfCam;

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir une r�f�rence au script "targeted"
        targetedScript = GetComponent<targeted>();
        targetedScript.enabled = false;
        tfCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Si la cam�ra est � moins de activationDistance de l'objet
        if (Vector3.Distance(tfCam.position, transform.position) < activationDistance)
        {
            // Activer le script "targeted"
            targetedScript.enabled = true;
        }
        else
        {
            // D�sactiver le script "targeted"
            targetedScript.enabled = false;
        }
    }
}
