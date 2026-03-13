using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover;
    [SerializeField]
    private InputAction accionSaltar;

    [SerializeField]
    private float velocidadX = 5f;

    [SerializeField]
    private float velocidadY = 5f;

    void Start(){

        accionMover.Enable();
    }

    void OnEnable(){
        accionSaltar.Enable();
        accionSaltar.performed += saltar;
    }

    void OnDisable(){
        accionSaltar.Disable();
        accionSaltar.performed -= saltar;
    }

    void saltar(InputAction.CallbackContext context)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = velocidadY * 1;
    }

    void Update(){
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        transform.position = (Vector2)transform.position + movimiento*velocidadX*Time.deltaTime;

    }
}