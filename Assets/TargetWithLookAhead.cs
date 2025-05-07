using UnityEngine;

public class TargetWithLookAhead : MonoBehaviour
{
    public Transform player;
    public Transform cursor;
    public float lookAheadDistance = 3f;
    private Camera cam;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 dir = (cursor.position - player.position).normalized;
        transform.position = player.position + dir * lookAheadDistance;
    }
}
