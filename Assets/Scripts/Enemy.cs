using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;

    private int direccion = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        direccion *= -1;

        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}