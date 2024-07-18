using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public Camera camera; // Référence à la caméra

    public float zoomedInSize = 5f; // Taille de la caméra lorsqu'elle est zoomée
    public float zoomSpeed = 2f; // Vitesse du zoom

    private Vector3 initialCameraPosition; // Position initiale de la caméra
    private float initialCameraSize; // Taille initiale de la caméra

    void Start()
    {
        // Enregistrer la position et la taille initiales de la caméra
        initialCameraPosition = camera.transform.position;
        initialCameraSize = camera.orthographicSize;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            // Zoomer la caméra sur le joueur
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoomedInSize, Time.deltaTime * zoomSpeed);
            camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(player.position.x, player.position.y, camera.transform.position.z), Time.deltaTime * zoomSpeed);
        }
        else
        {
            // Revenir à la taille et à la position initiales de la caméra
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, initialCameraSize, Time.deltaTime * zoomSpeed);
            camera.transform.position = Vector3.Lerp(camera.transform.position, initialCameraPosition, Time.deltaTime * zoomSpeed);
        }
    }
}
