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
    public GameObject Mensajeatras;

    [Header("Textos")]
    [SerializeField] public TMP_Text advertenciatexto;
    [SerializeField] public TMP_Text cuentaatras;

    [Header("Textos secundarios")]
    public GameObject eliminado;
    public GameObject botonvolver;


    void Start()
    {
        AbrirLista();
        eliminado.SetActive(false);
        botonvolver.SetActive(false);
    }

    //abrir y cerrar menus
    public void AbrirLista()
    {
        Mensajeatras.SetActive(false);
        menulista.SetActive(true);
        menuanadir.SetActive(false);
        menuborrar.SetActive(false);
        Mensajepop.SetActive(false);
    }
    public void AbrirAñadir()
    {
        Mensajeatras.SetActive(false);
        menulista.SetActive(false);
        menuanadir.SetActive(true);
        menuborrar.SetActive(false);
        Mensajepop.SetActive(false);
    }
    public void AbrirBorrar()
    {
        Mensajeatras.SetActive(false);
        menulista.SetActive(false);
        menuanadir.SetActive(false);
        menuborrar.SetActive(true);
        Mensajepop.SetActive(false);
    }

    //estos son especiales
    public void AbrirPop() { Mensajepop.SetActive(true); }
    public void AbrirAtras() { Mensajeatras.SetActive(true); }
    public void CerrarPop() { Mensajepop.SetActive(false); }

    public void CerrarAtras() { Mensajeatras.SetActive(false); }

}
