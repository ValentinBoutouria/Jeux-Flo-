using UnityEngine;

public class ActivateTargeted : MonoBehaviour
{
    public float activationDistance = 5f; // La distance à laquelle le script "targeted" sera activé
    private targeted targetedScript; // Une référence au script "targeted"
    public Transform tfCam;

    // Start is called before the first frame update
    void Start()
    {
        // Obtenir une référence au script "targeted"
        targetedScript = GetComponent<targeted>();
        targetedScript.enabled = false;
        tfCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Si la caméra est à moins de activationDistance de l'objet
        if (Vector3.Distance(tfCam.position, transform.position) < activationDistance)
        {
            // Activer le script "targeted"
            targetedScript.enabled = true;
        }
        else
        {
            // Désactiver le script "targeted"
            targetedScript.enabled = false;
        }
    }
}
