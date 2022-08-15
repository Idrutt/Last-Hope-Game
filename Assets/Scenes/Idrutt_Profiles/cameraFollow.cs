
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float SmoothFactor;
    public Vector3 MinValue, MaxValue;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 TargetPosition = target.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(TargetPosition.x, MinValue.x, MaxValue.x),
            Mathf.Clamp(TargetPosition.y, MinValue.y, MaxValue.y),
            Mathf.Clamp(TargetPosition.z, MinValue.z, MaxValue.z));

        Vector3 SmoothPosition = Vector3.Lerp(transform.position, boundPosition, SmoothFactor*Time.fixedDeltaTime);
        transform.position = SmoothPosition;
    }
}
