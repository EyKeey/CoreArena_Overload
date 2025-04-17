using UnityEngine;

public class healthBarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject fullSegment;
    [SerializeField] private GameObject emptySegment;
    [SerializeField] private int maxSegments = 10;
    [SerializeField] private int currentSegments = 10;

    private void Start()
    {
        // Initialize the health bar with full segments
        InitBar();

        UpdateBar(250, 1000);
    }

    public void InitBar()
    {
        currentSegments = maxSegments;
        for (int i = 0; i < maxSegments; i++)
        {
            GameObject segment = Instantiate(fullSegment, transform);
            segment.SetActive(true);
        }
    }

    public void UpdateBar(int currentHealth, int maxHealth)
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        currentSegments = currentHealth * maxSegments / maxHealth;

        for (int i = 0; i < maxSegments; i++)
        {
            if (i < currentSegments)
            {
                Instantiate(fullSegment, transform).SetActive(true);
            }
            else
            {
                Instantiate(emptySegment, transform).SetActive(true);
            }
        }

    }
    
}
