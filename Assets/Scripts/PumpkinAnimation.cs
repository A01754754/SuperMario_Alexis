using UnityEngine;

// Esta clase se encarga de hacer la "animación" de la calabaza cambiando su color entre blanco.
public class PumpkinAnimation : MonoBehaviour
{
    // Velocidad en la que sucede el cambio de color
    [SerializeField] private float velocidad = 5f;

    // Referencia al SpriteRenderer para cambiar el color
    private SpriteRenderer sr;
    // Contador para el cambio de color
    private float tiempo;

    void Start()
    {
        // Obtener la referencia al SpriteRenderer
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Incrementar el tiempo para el cambio de color
        tiempo += Time.deltaTime * velocidad;
        // Calcular el valor de t para cambiar entre los dos colores
        float t = (Mathf.Sin(tiempo) + 1f) / 2f;
        // Cambiar entre el color blanco y un color rojo un poco más suave
        Color color = Color.Lerp(Color.white, new Color(1f, 0.5f, 0.5f), t);
        // Asignar el color al SpriteRenderer
        sr.color = color;
    }
}