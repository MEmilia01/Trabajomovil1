using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject menulista;
    public GameObject menuanadir;
    public GameObject menuborrar;
    public GameObject Mensajepop;
    public GameObject Mensajefeliz;
    public GameObject Mensajeatras;

    [Header("Textos")]
    [SerializeField] public TMP_Text advertenciatexto;
    [SerializeField] public TMP_Text cuentaatras;

    [Header("Textos secundarios")]
    public GameObject eliminado;
    public GameObject botonvolver;

    [Header("Temporizador")]
    private float tiemporestante;
    public bool ontemporizador;


    void Start()
    {
        AbrirLista();
        DesactivarEliminado();
    }

    //abrir y cerrar menus
    public void AbrirLista()
    {
        Mensajeatras.SetActive(false);
        menulista.SetActive(true);
        menuanadir.SetActive(false);
        menuborrar.SetActive(false);
        Mensajepop.SetActive(false);
        Mensajefeliz.SetActive(false);
    }
    public void AbrirAñadir()
    {
        Mensajeatras.SetActive(false);
        menulista.SetActive(false);
        menuanadir.SetActive(true);
        menuborrar.SetActive(false);
        Mensajepop.SetActive(false);
        Mensajefeliz.SetActive(false);
    }
    public void AbrirBorrar()
    {
        Mensajeatras.SetActive(false);
        menulista.SetActive(false);
        menuanadir.SetActive(false);
        menuborrar.SetActive(true);
        Mensajepop.SetActive(false);
        Mensajefeliz.SetActive(false);
    }

    //estos son especiales
    public void AbrirPop() { Mensajepop.SetActive(true); }
    public void AbrirFeliz() { Mensajefeliz.SetActive(true); }
    public void AbrirAtras() { Mensajeatras.SetActive(true); }
    public void CerrarPop() { Mensajepop.SetActive(false); }
    public void CerrarFeliz() { Mensajefeliz.SetActive(false); }

    public void CerrarAtras() 
    { 
        Mensajeatras.SetActive(false);
        DesactivarEliminado();
    }
    public void ActivarEliminado() 
    {
        eliminado.SetActive(true);
        botonvolver.SetActive(true);
    }
    public void DesactivarEliminado() 
    {
        eliminado.SetActive(false);
        botonvolver.SetActive(false);
    }


    //el temporizador
    public void IniciarTemporizador(float duracionSegundos)
    {
        if (cuentaatras == null)
        {
            Debug.Log("No hay cuantaatras");
            return;
        }

        tiemporestante = duracionSegundos;
        ontemporizador = true;
    }

    void Update()
    {
        if (ontemporizador)
        {
            tiemporestante -= Time.deltaTime;

            if (tiemporestante <= 0f)
            {
                tiemporestante = 0f;
                ontemporizador = false;
                cuentaatras.text = "0";
            }
            else
            {
                // tiempo redondeado hacia arriba 3/2/1
                cuentaatras.text = Mathf.CeilToInt(tiemporestante).ToString();
            }
        }
    }

}
