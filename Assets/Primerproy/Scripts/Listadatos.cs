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
    public List<Variables> listaDatos = new List<Variables>();
    private List<int> idsLibres = new List<int>();
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
    public Dropdown miDropdown;



    void Start()
    {
        ultimoID = 0;
    }

    public void Anadirjugador()
    {
        //revisar si hay algun hueco, sino ++ al ultimo

        if (idsLibres.Count > 0)
        {
            // Buscamos el menor ID libre
            int idAUsar = idsLibres[0];
            int indiceMenor = 0;

            for (int i = 1; i < idsLibres.Count; i++)
            {
                if (idsLibres[i] < idAUsar)
                {
                    idAUsar = idsLibres[i];
                    indiceMenor = i;
                }
            }

            // Lo quitamos de la lista de libres
            idsLibres.RemoveAt(indiceMenor);

            listaDatos.Add(new Variables { indice = idAUsar, edad = 19, nombre = "Mauricio" });
            Debug.Log("Guardado especial: " + idAUsar);
        }
        else
        {
            int nuevoId = ultimoID;
            listaDatos.Add(new Variables { indice = nuevoId, edad = 15, nombre = "Juanco" });
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

        for (int i = 0; i < listaDatos.Count; i++)
        {
            if (listaDatos[i].indice == idABorrar)
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

        for (int i = 0; i < listaDatos.Count; i++)
        {
            if (listaDatos[i].indice == idABorrar)
            {
                // Marcamos ese ID como libre para reutilizar
                idsLibres.Add(listaDatos[i].indice);
                menumanager.AbrirAtras();
                menumanager.IniciarTemporizador(3f);

                yield return new WaitForSeconds(3f);

                listaDatos.RemoveAt(i);

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
        foreach (var dato in listaDatos)
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

    public void OrdenarID() 
    {
        Debug.Log("entra dentro para organizar");
        listaDatos.Sort((a, b) => a.indice.CompareTo(b.indice));
        RefrescarUI();
    }
    public void OrdenarEdad() 
    {
        Debug.Log("Que haces");
        listaDatos.Sort((a, b) => a.edad.CompareTo(b.edad));
        RefrescarUI();
    }

}
