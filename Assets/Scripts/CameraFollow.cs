using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + posOffset, ref velocity, timeOffset);
    }
}