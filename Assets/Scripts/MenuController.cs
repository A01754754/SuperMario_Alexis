using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private Button btnPlay;
    private Button btnHelp;
    private Button btnCredits;
    private Button btnCerrarVentana;
    private Button btnVolverMenu;
    private Button btnCerrarCreditos;

    private VisualElement menuMain;
    private VisualElement contenedorBotones;
    private VisualElement ventanaInfoAyuda;
    private VisualElement pantallaCreditos;

    private Label Texto;
    private Label Titulo;
    private Label tituloCreditos;
    private Label textoCreditos;

    private bool reproduciendoCreditos = false;

    private float velocidadCreditos = 160f;

    private float posicionInicialCreditos = 300f;
    private float posicionFinalCreditos = -950f;
    private float posicionActualCreditos;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        btnPlay = root.Q<Button>("ButtonPlay");
        btnHelp = root.Q<Button>("ButtonHelp");
        btnCredits = root.Q<Button>("ButtonCredits");
        btnCerrarVentana = root.Q<Button>("cerrarVentana");
        btnVolverMenu = root.Q<Button>("ButtonClose");
        btnCerrarCreditos = root.Q<Button>("cerrarCreditos");

        menuMain = root.Q<VisualElement>("MenuMain");
        contenedorBotones = root.Q<VisualElement>("Botones");
        ventanaInfoAyuda = root.Q<VisualElement>("VentanaInfoAyuda");
        pantallaCreditos = root.Q<VisualElement>("PantallaCreditos");

        Texto = root.Q<Label>("Texto");
        Titulo = root.Q<Label>("Titulo");
        tituloCreditos = root.Q<Label>("TituloCreditos");
        textoCreditos = root.Q<Label>("TextoCreditos");

        if (ventanaInfoAyuda != null)
            ventanaInfoAyuda.style.display = DisplayStyle.None;

        if (pantallaCreditos != null)
            pantallaCreditos.style.display = DisplayStyle.None;

        if (btnPlay != null)
            btnPlay.clicked += IrAJuego;

        if (btnHelp != null)
            btnHelp.clicked += AbrirAyuda;

        if (btnCredits != null)
            btnCredits.clicked += AbrirPantallaCreditos;

        if (btnCerrarVentana != null)
            btnCerrarVentana.clicked += CerrarVentanaInfo;

        if (btnVolverMenu != null)
            btnVolverMenu.clicked += VolverAlMenu;

        if (btnCerrarCreditos != null)
            btnCerrarCreditos.clicked += CerrarPantallaCreditos;

        if (Texto != null)
        {
            Texto.style.fontSize = 25;
            Texto.style.unityTextAlign = TextAnchor.UpperCenter;
            Texto.style.whiteSpace = WhiteSpace.Normal;
            Texto.style.width = Length.Percent(100);
            Texto.style.marginLeft = 50;
            Texto.style.marginRight = 50;
        }

        if (Titulo != null)
        {
            Titulo.style.fontSize = 30;
            Titulo.style.unityTextAlign = TextAnchor.MiddleCenter;
        }
    }

    void OnDisable()
    {
        if (btnPlay != null) btnPlay.clicked -= IrAJuego;
        if (btnHelp != null) btnHelp.clicked -= AbrirAyuda;
        if (btnCredits != null) btnCredits.clicked -= AbrirPantallaCreditos;
        if (btnCerrarVentana != null) btnCerrarVentana.clicked -= CerrarVentanaInfo;
        if (btnVolverMenu != null) btnVolverMenu.clicked -= VolverAlMenu;
        if (btnCerrarCreditos != null) btnCerrarCreditos.clicked -= CerrarPantallaCreditos;
    }

    void Update()
    {
        if (reproduciendoCreditos && textoCreditos != null)
        {
            posicionActualCreditos -= velocidadCreditos * Time.deltaTime;
            textoCreditos.style.top = posicionActualCreditos;

            if (posicionActualCreditos <= posicionFinalCreditos)
            {
                posicionActualCreditos = posicionInicialCreditos;
                textoCreditos.style.top = posicionActualCreditos;
            }
        }
    }

    void IrAJuego()
    {
        SceneManager.LoadScene("GameScene");
    }

    void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void AbrirAyuda()
    {
        reproduciendoCreditos = false;

        if (Titulo != null)
            Titulo.text = "¿Qué es Lorem Ipsum?";

        if (Texto != null)
        {
            Texto.text =
                "Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto.\n\n" +
                "Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, " +
                "cuando un impresor desconocido usó una galería de textos y los mezcló de tal manera " +
                "que logró hacer un libro de textos espécimen.\n\n" +
                "No sólo sobrevivió 500 años, sino que también ingresó como texto de relleno en " +
                "documentos electrónicos, quedando esencialmente igual al original.\n\n" +
                "Fue popularizado en los años 60 con la creación de las hojas \"Letraset\".";
        }

        if (contenedorBotones != null)
            contenedorBotones.style.display = DisplayStyle.None;

        if (pantallaCreditos != null)
            pantallaCreditos.style.display = DisplayStyle.None;

        if (ventanaInfoAyuda != null)
            ventanaInfoAyuda.style.display = DisplayStyle.Flex;
    }

    void CerrarVentanaInfo()
    {
        if (ventanaInfoAyuda != null)
            ventanaInfoAyuda.style.display = DisplayStyle.None;

        if (contenedorBotones != null)
            contenedorBotones.style.display = DisplayStyle.Flex;
    }

    void AbrirPantallaCreditos()
    {
        if (menuMain != null)
            menuMain.style.display = DisplayStyle.None;

        if (pantallaCreditos != null)
            pantallaCreditos.style.display = DisplayStyle.Flex;

        if (tituloCreditos != null)
            tituloCreditos.text = "Créditos";

        if (textoCreditos != null)
        {
            textoCreditos.text =
                "\n\n\n\n\n" +
                "¿Qué es Lorem Ipsum?\n\n" +

                "Lorem Ipsum es simplemente el texto de relleno de las imprentas.\n\n" +

                "Lorem Ipsum ha sido el texto estándar desde el año 1500.\n\n" +

                "No sólo sobrevivió 500 años, sino que también ingresó en documentos electrónicos.\n\n" +

                "Fue popularizado en los años 60 con Letraset.\n\n\n";

            textoCreditos.style.fontSize = 50;
            textoCreditos.style.unityTextAlign = TextAnchor.MiddleCenter;
            textoCreditos.style.whiteSpace = WhiteSpace.Normal;
            textoCreditos.style.width = Length.Percent(100);
            textoCreditos.style.marginLeft = 50;
            textoCreditos.style.marginRight = 50;
        }

        posicionActualCreditos = posicionInicialCreditos;

        if (textoCreditos != null)
            textoCreditos.style.top = posicionActualCreditos;

        reproduciendoCreditos = true;
    }

    void CerrarPantallaCreditos()
    {
        reproduciendoCreditos = false;

        if (pantallaCreditos != null)
            pantallaCreditos.style.display = DisplayStyle.None;

        if (menuMain != null)
            menuMain.style.display = DisplayStyle.Flex;
    }
}