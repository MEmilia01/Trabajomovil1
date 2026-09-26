using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ayuda : MonoBehaviour
{

    [Header("Variables de ayuda")]
    public string muestra = "Hola";
    public int ultimoID;

    public class Datos
    {
        public int indice;
        public int edad;
        public string nombre;

    }

    [Header("Lista de personajes")]
    public List<Datos> listaDatos = new List<Datos>();


    //la idea es hacer el Id desde 83 000
    //que si es menor de 15, no pueda meterse
    //y que tiene que escribir algo

    private void Start()
    {
        InicioId();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //aca para ver el nuevo añadido
            MostrarElemnt();
        }
        else if (Input.GetKeyDown(KeyCode.Z)) { Revisarlista(); }
        else if (Input.GetKeyDown(KeyCode.W)) { QuitarPersona(); }
    }

    public void MostrarElemnt()
    {
        Debug.Log(muestra);
        for (int i = 0; i < listaDatos.Count; i++) 
        { Debug.Log("El ID: " + listaDatos[i].indice + " y el nombre " + listaDatos[i].nombre); }
    }

    public void Revisarlista()
    {
        int numanterior = 0;
        int fin = ultimoID;

        if (listaDatos.Count < 1) { NuevaPersona(); }
        else
        { 
            for (int i = 0; i < fin; i++)
            {
                Debug.Log(numanterior + " y " + listaDatos[i].indice);
                if (numanterior != listaDatos[i].indice)
                {
                    //listaDatos.Add(new Datos { indice = numanterior, edad = 15, nombre = "Juanco" });
                    Debug.Log("Guardado expecial (" + numanterior + ")");
                    break;
                }
                else
                {
                    NuevaPersona();
                }
                numanterior++;
            }
        }

    }

    public void NuevaPersona()
    {
       listaDatos.Add(new Datos { indice = ultimoID, edad = 15, nombre = "Juanco" });        
       Debug.Log("Guardado");
       ultimoID++;
    }
    public void QuitarPersona()
    {
        for (int i = 0;i < listaDatos.Count;i++)
        {
            if (listaDatos[i].indice == 3)
            {  listaDatos.RemoveAt(i); }
        }
    }

    public void InicioId()
    {
        if (ultimoID != 0) { ultimoID = 0; }
        else return;
    }
    


    /*
    variables de los usuarios
    id(identificair) // nombre // edad

    funciones
    añadir usuarios, solo nombre y edad
    eliminar, con el id 
    ordenar por id o edad

    demas:
    lista dinamica
    mensaje hayacente de feedback (ya esta borrado // nombre ya esta puesto)

    */
}
