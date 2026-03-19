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

    }

    void OnEnable()
    {
        accionMover.Enable();
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
        movimiento = accionMover.ReadValue<Vector2>();

        animator.SetFloat("Horizontal", movimiento.x);
        animator.SetFloat("Speed", Mathf.Abs(movimiento.x));
        animator.SetFloat("Vertical", rb.linearVelocity.y);

        transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimiento.x * velocidadX, rb.linearVelocity.y);
    }

    void Saltar(InputAction.CallbackContext context)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, velocidadY);
    }
}