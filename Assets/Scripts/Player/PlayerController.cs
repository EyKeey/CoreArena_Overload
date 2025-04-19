using UnityEngine;
using Random = UnityEngine.Random;

public enum PlayerState
{
    Idle,
    Moving,
    Attacking,
}

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float movementSpeed = 5f;
    public float attackRange = 5f;
    public float attackTimer = 0f;
    public float attackDuration = 0.5f;
    public float attackDamage = 10f;
    public PlayerState currentState;

    private Rigidbody2D rb;
    private PlayerTargetingSystem targetingSystem;
    private PlayerAttackController playerAttackController;
    private Transform currentTarget;
    private Vector2 randomDirection;
    private float randomTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetingSystem = GetComponent<PlayerTargetingSystem>();
        playerAttackController = GetComponent<PlayerAttackController>();
    }

    private void Update()
    {
        if(currentState == PlayerState.Attacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                currentState = PlayerState.Moving;   
            }
            return;
        }

        currentTarget = targetingSystem.UpdateTarget();

        if (currentTarget != null)
        {
            float distanceToTarget = Vector2.Distance(transform.position, currentTarget.position);

            if (distanceToTarget <= attackRange)
            {
                playerAttackController.Attack(currentTarget);
            }
            else
            {
                MoveTowards(currentTarget.position);    
            }
        }
        else
        {
            Wander();
        }
    }


    
    private void MoveTowards(Vector2 position)
    {
        currentState = PlayerState.Moving;

        Vector2 dir  =  (position - (Vector2)transform.position).normalized;
        transform.position += (Vector3)dir * movementSpeed * Time.deltaTime;

        if (dir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Saða bak
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Sola bak
        }
    }

    private void Wander()
    {
        currentState = PlayerState.Moving;

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
