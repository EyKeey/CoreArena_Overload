using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private Transform healthBar;
    public Vector3 healthBarOffset = Vector3.zero;

    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
        healthBar.position = screenPos + healthBarOffset;

    }
}
