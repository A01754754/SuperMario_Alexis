// GhostAnimation.cs
//Alexis Maximiliano Alva Martínez A01754754
/*Clase que se encarga de la animación del fantasma, hace que gire y cambie de tamaño cada cierto tiempo*/
using UnityEngine;

public class GhostAnimation : MonoBehaviour
{
    //Velocidad en la que gira el fantasma
    [SerializeField] private float velocidadRotacion = 200f;
    //Velocidad a la que cambia de tamaño el fantasma
    [SerializeField] private float velocidadEscala = 2f;
    //Tamaño mínimo al que puede llegar el fantasma
    [SerializeField] private float tamañoMin = 0f;
    //Tamaño máximo al que puede llegar el fantasma
    [SerializeField] private float tamañoMax = 1f;

    //Tiempo que se ha estado "animando" el fantasma
    private float tiempo;

    void Update()
    {
        //Esto hace que el fantasma gire constantemente
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);

        //Esto hace que el fantasma cambie de tamaño
        tiempo += Time.deltaTime * velocidadEscala;
        float escala = Mathf.Lerp(tamañoMin, tamañoMax, (Mathf.Sin(tiempo) + 1f) / 2f);
        //Le da el nuevo tamaño al fantasma
        transform.localScale = new Vector3(escala, escala, 1);
    }
}