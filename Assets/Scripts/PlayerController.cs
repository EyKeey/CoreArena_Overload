using UnityEngine;
using Random = UnityEngine.Random;



public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float movementSpeed = 5f;
    public float detectionRadius = 10f;


    private Rigidbody2D rb;
    private PlayerTargetingSystem targetingSystem;
    private Transform currentTarget;
    private Vector2 randomDirection;
    private float randomTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetingSystem = GetComponent<PlayerTargetingSystem>();
    }

    private void Update()
    {
        currentTarget = targetingSystem.UpdateTarget(detectionRadius);

        if (currentTarget != null)
        {
            MoveTowards(currentTarget.position);
        }
        else
        {
            Wander();
        }
    }


    
    private void MoveTowards(Vector2 position)
    {
        Vector2 dir  =  (position - (Vector2)transform.position).normalized;
        transform.position += (Vector3)dir * movementSpeed * Time.deltaTime;
    }

    private void Wander()
    {
        randomTime -= Time.deltaTime;

        if (randomTime <= 0f)
        {
            float angle = Random.Range(0f, 360f);
            randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            randomTime = Random.Range(1f, 2f);
        }

        if (randomDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Saða bak
        }
        else if (randomDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Sola bak
        }



        transform.position += (Vector3)randomDirection.normalized * movementSpeed * Time.deltaTime;

    }




}
