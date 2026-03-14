using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private InputAction accionMover;
    [SerializeField] private InputAction accionSaltar;
    [SerializeField] private float velocidadX = 5f;
    [SerializeField] private float velocidadY = 8f;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        accionMover.Enable();

        // Evita que el personaje se rote y se ponga boca abajo
        rb.freezeRotation = true;
    }

    void OnEnable()
    {
        accionSaltar.Enable();
        accionSaltar.performed += Saltar;
    }

    void OnDisable()
    {
        accionSaltar.performed -= Saltar;
        accionSaltar.Disable();
        accionMover.Disable();
    }

    void Update()
    {
        // Leer movimiento
        movimiento = accionMover.ReadValue<Vector2>();

        // Animaciones
        if (movimiento.x > 0)
        {
            animator.Play("WalkRight");
        }
        else if (movimiento.x < 0)
        {
            animator.Play("WalkLeft");
        }
        else
        {
            animator.Play("Idle");
        }

        // Por seguridad, mantener la rotación en 0
        transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        // Movimiento horizontal usando Rigidbody2D
        rb.linearVelocity = new Vector2(movimiento.x * velocidadX, rb.linearVelocity.y);
    }

    void Saltar(InputAction.CallbackContext context)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, velocidadY);
    }
}