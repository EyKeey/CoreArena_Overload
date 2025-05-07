using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInput playerInput;
    private Transform player;

    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public Vector2 lookInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerInput = new PlayerInput();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerInput.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

        playerInput.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();

        playerInput.Player.Fire.performed += ctx => player.GetComponentInChildren<Weapon>().Fire();
        
        playerInput.Player.Reload.performed += ctx => player.GetComponentInChildren<Weapon>().TryReload();

        playerInput.Player.Dash.performed += ctx => player.GetComponent<PlayerController>().TryDash();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

}
