using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         
    public float smoothSpeed = 0.125f;
    public float xOffset = 0f;       

    void LateUpdate()
    {
        if (target == null) return;

        float desiredX = target.position.x + xOffset;
        float smoothedX = Mathf.Lerp(transform.position.x, desiredX, smoothSpeed);

        transform.position = new Vector3(smoothedX, transform.position.y, transform.position.z);
    }
}
