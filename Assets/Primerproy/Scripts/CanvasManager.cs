using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject menuinicio;
    public GameObject menulista;
    public GameObject Menuanadir;
    public GameObject menuborrar;
    public GameObject Mensajepop;

    //
    public TextMeshProUGUI mensaje;

    void Start()
    {
        menuinicio.SetActive(true);
        menulista.SetActive(false);
        Menuanadir.SetActive(false);
        menuborrar.SetActive(false);
        Mensajepop.SetActive(false);
    }















    //abrir y cerrar menus
    public void Abririnicio()
    {
        
    }
}
