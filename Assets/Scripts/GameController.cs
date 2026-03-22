// GameController.cs
//Alexis Maximiliano Alva Martínez A01754754
/*Clase que al presionar el botón de "Regresar" hace que se cargue la escena del menú*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    //Referencia al botón de "Regresar" en la UI
    private Button btnClose;

    void OnEnable()
    {
        //Obtiene la referencia al botón de "Regresar" en la UI
        var root = GetComponent<UIDocument>().rootVisualElement;
        //Busca el botón con el nombre "ButtonClose" en la UI
        btnClose = root.Q<Button>("ButtonClose");
        //Si el botón existe, le asigna la función "VolverAlMenu" al evento "clicked" del botón
        if (btnClose != null)
            btnClose.clicked += VolverAlMenu;
    }
    void OnDisable()
    {
        //Si el botón existe, le quita la funcionalidad "VolverAlMenu" al evento "clicked" del botón
        if (btnClose != null)
            btnClose.clicked -= VolverAlMenu;
    }

    //Función que se llama al presionar el botón de "Regresar"
    void VolverAlMenu()
    {
        //Carga la escena del menú
        SceneManager.LoadScene("Menu");
    }
}