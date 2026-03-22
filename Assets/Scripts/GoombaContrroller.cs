// GoombaController.cs
//Alexis Maximiliano Alva Martínez A01754754
/*Clase que se encarga de controlar el movimiento del goomba, hace que se mueva de un lado a otro y cambie de dirección al tocar algo.*/
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    //Velocidad con la que se mueve el goomba.
    [SerializeField] private float velocidad = 2f;
    //Dirección inicial en la que se mueve el goomba.
    private int direccion = 1;
    //Referencia al componente Rigidbody2D del goomba.
    private Rigidbody2D rb;

    void Start()
    {
        // Obtener la referencia al componente Rigidbody2D del goomba.
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Darle la velocidad del goomba en la dirección actual.
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Si el goomba toca algo cambia de dirección.
        direccion *= -1;
        // Cambia la escala del goomba para que mire hacia la dirección a la que se está moviendo.
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        // Le da la nueva escala al goomba.
        transform.localScale = escala;
    }
}