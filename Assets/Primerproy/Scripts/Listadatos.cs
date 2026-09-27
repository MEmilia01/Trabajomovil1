using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Listadatos : MonoBehaviour
{
    public class Variables
    { // aca estan las variable

        [Header("Lista de datos para los personajes")]
        public int indice;
        public int edad;
        public string nombre;

    }

    [Header("Variables de ayuda")]
    [Tooltip("Esto es para ver que aparescan en debug al menos")]
    public string muestra = "Hola";
    public int ultimoID;

    [Header("Scripts necesarios")]
    //public Variables datos;
    public CanvasManager menumanager;

    [Header("Listas")]
    public List<Variables> listadatos = new List<Variables>();
    private List<int> idslibres = new List<int>();
    //este segundo, va a servir para cuando haya huecos

    [Header("Jugadores creados")]
    [Tooltip("El objeto Content del Scroll View")]
    public Transform contentTransform;

    [Tooltip("Prefab de cada item de la lista (debe tener un Text hijo para el nombre)")]
    public GameObject itemPrefab;

    [Header("Datos obtenidos")]
    public TMP_InputField idbusqueda;
    public TMP_InputField nombrepuesto;
    public TMP_InputField edadpuesta;

    [Header("Ordenar datos")]
    public TMP_Dropdown opcionesorden;



    void Start()
    {
        ultimoID = 0;

        //el dropdown es un quebradero de cabeza
        opcionesorden.onValueChanged.RemoveAllListeners();
        opcionesorden.onValueChanged.AddListener(OnDropdownChanged);
    }

    public void Anadirjugador()
    {
        string nombrejugador = nombrepuesto.text;
        string edadjugador = edadpuesta.text;
        int edadjug = int.Parse(edadjugador);
        //revisar si hay algun hueco, sino ++ al ultimo

        if(nombrejugador == "" || nombrejugador == " " || edadjug < 15)
        {
            menumanager.AbrirPop();
            if(edadjug < 15) {  menumanager.advertenciatexto.text = "Eres demasiado menor"; return; }
            else menumanager.advertenciatexto.text = "Ese nombre esta mal"; return;
        }


        if (idslibres.Count > 0)
        {
            // Buscamos el menor ID libre
            int idAUsar = idslibres[0];
            int indiceMenor = 0;

            for (int i = 1; i < idslibres.Count; i++)
            {
                if (idslibres[i] < idAUsar)
                {
                    idAUsar = idslibres[i];
                    indiceMenor = i;
                }
            }

            // Lo quitamos de la lista de libres
            idslibres.RemoveAt(indiceMenor);

            listadatos.Add(new Variables { indice = idAUsar, edad = edadjug, nombre = nombrejugador });
            Debug.Log("Guardado especial: " + idAUsar);
        }
        else
        {
            int nuevoId = ultimoID;
            listadatos.Add(new Variables { indice = nuevoId, edad = edadjug, nombre = nombrejugador });
            Debug.Log("Guardado: " + nuevoId);
            ultimoID++;
        }

        RefrescarUI();

    }




    public void QuitarJugador()
    {
        StartCoroutine(QuitarJugadorCoroutine());
    }

    public IEnumerator QuitarJugadorCoroutine()
    {
        string numerobuscado = idbusqueda.text;
        //con esto deberia hacer una conversion
        int idABorrar = int.Parse(numerobuscado);
        bool encontrado = false;
        //me esta dando problemas pop

        for (int i = 0; i < listadatos.Count; i++)
        {
            if (listadatos[i].indice == idABorrar)
            {
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            menumanager.AbrirPop();
            menumanager.advertenciatexto.text = "Ese ID no existe o lo estás poniendo mak";
            yield break;
        }

        for (int i = 0; i < listadatos.Count; i++)
        {
            if (listadatos[i].indice == idABorrar)
            {
                // Marcamos ese ID como libre para reutilizar
                idslibres.Add(listadatos[i].indice);
                menumanager.AbrirAtras();
                menumanager.IniciarTemporizador(3f);

                yield return new WaitForSeconds(3f);

                listadatos.RemoveAt(i);

                menumanager.ActivarEliminado();
                Debug.Log("Persona con ID " + idABorrar + " eliminada.");
                break;
            }
            
        }

        RefrescarUI();
    }




    public void RefrescarUI()
    {
        if (contentTransform == null || itemPrefab == null)
        {
            Debug.Log("Algun transform no ha sido asignado xdd");
            return;
        }

        // Limpiar hijos previos
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }

        // Crear un item por cada dato
        foreach (var dato in listadatos)
        {
            GameObject newItem = Instantiate(itemPrefab, contentTransform);

            // Ejemplo: buscar un Text y poner el nombre
            TextMeshProUGUI textoNombre = newItem.GetComponent<TextMeshProUGUI>();
            if (textoNombre != null)
            {
                textoNombre.text = $"ID: {dato.indice} || Nombre: {dato.nombre} || Edad: {dato.edad} años)";
            }
            else Debug.Log("No aparece nada");

            // Aquí podrías añadir botones, eventos, etc.
        }
    }

    void OnDropdownChanged(int indice)
    {
        switch (indice)
        {
            case 0:
                OrdenarID();
                break;
            case 1:
                OrdenarEdad();
                break;
            default:
                Debug.Log("Opción no reconocida");
                break;
        }
    }

    public void OrdenarID() 
    {
        Debug.Log("entra dentro para organizar");
        listadatos.Sort((a, b) => a.indice.CompareTo(b.indice));
        RefrescarUI();
    }
    public void OrdenarEdad() 
    {
        Debug.Log("Que haces");
        listadatos.Sort((a, b) => a.edad.CompareTo(b.edad));
        RefrescarUI();
    }

}
