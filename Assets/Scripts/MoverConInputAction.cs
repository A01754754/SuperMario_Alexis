using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField] private InputAction accionMover;
    [SerializeField] private InputAction accionSalto;

    private Rigidbody2D rb;
    private EstadoPersonaje estado;

    [SerializeField] private float XVelocity = 5f;
    [SerializeField] private float YVelocity = 7f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        estado = GetComponent<EstadoPersonaje>();
    }

    void OnEnable()
    {
        accionMover.Enable();
        accionSalto.Enable();
        accionSalto.performed += Saltar;
    }

    void OnDisable()
    {
        accionMover.Disable();
        accionSalto.Disable();
        accionSalto.performed -= Saltar;
    }

    void Update()
    {
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        rb.velocity = new Vector2(XVelocity * movimiento.x, rb.velocity.y);
    }

    public void Saltar(InputAction.CallbackContext context)
    {
        if (estado.estaEnSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, YVelocity);
        }
    }
}