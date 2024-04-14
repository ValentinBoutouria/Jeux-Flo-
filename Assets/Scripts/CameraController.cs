using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float turnSpeed = 50f;
    public float zoomSpeed = 6000f;

    // Update is called once per frame
    void Update()
    {
        // Déplacer la caméra avec Z, Q, S, D
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveHorizontal, 0, moveVertical), Space.World);

        // Pivoter la caméra avec A et E
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(transform.position, Vector3.up, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(transform.position, Vector3.up, -turnSpeed * Time.deltaTime);
        }

        // Zoomer et dézoomer avec la molette de la souris
        float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        transform.Translate(0, 0, zoom);
    }
}
