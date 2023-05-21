using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorder = 10f;

    public float scrollSpeed = 5f;

    private float minZ = 0f;
    private float maxZ = 70f;
    private float minX = 0f;
    private float maxX = 70f;

    private float minY = 10f;
    private float maxY = 80f;

    void Update()
    {
        // déplacement vers l'avant
        if (this.transform.position.z < maxZ && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            Debug.Log("haut");
        }

        // déplacement vers l'arrière
        if (this.transform.position.z > minZ && (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            Debug.Log("bas");
        }

        // déplacement vers la gauche
        if (this.transform.position.x > minX && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorder))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            Debug.Log("gauche");
        }

        // déplacement vers la droite
        if (this.transform.position.x < maxX && (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            Debug.Log("droite");
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 pos = transform.position;
        pos.y -= scroll * 2000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
