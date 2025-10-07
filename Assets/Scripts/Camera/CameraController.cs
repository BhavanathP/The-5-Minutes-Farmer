using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float maximizedSize = 15f;
    public float minimizedSize = 4f;

    private bool maximized = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            maximized = !maximized;

        }
        if (maximized)
        {
            transform.position = new Vector3(5, 5, -10);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, maximizedSize, smoothSpeed);
        }
        else
        {
            if (target != null)
            {
                transform.position = target.position + offset;
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, minimizedSize, smoothSpeed);
            }
        }
    }

    void LateUpdate()
    {
        if (target != null && !maximized)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
