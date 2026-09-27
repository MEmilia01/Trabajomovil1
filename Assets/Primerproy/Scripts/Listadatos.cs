using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static ayuda;

public class Listadatos : MonoBehaviour
{
    [Header("Variables de ayuda")]
    public string muestra = "Hola";
    public int ultimoID;

    [Header("Scripts necesarios")]
    public Variables datos;
    public CanvasManager menumanager;

    [Header("Listas")]
    public List<Variables> listaDatos = new List<Variables>();
    private List<int> idsLibres = new List<int>();
    //este segundo, va a servir para cuando haya huecos



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

    }

    public void MostrarLista()
    {
        Debug.Log(muestra);
        for (int i = 0; i < listaDatos.Count; i++)
        { Debug.Log("El ID: " + listaDatos[i].indice + " y el nombre " + listaDatos[i].nombre); }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Y))
        {
            //aca para ver el nuevo añadido
            MostrarLista();
        }
        else if (Input.GetKeyDown(KeyCode.Z)) { Anadirjugador(); }

    }
}
