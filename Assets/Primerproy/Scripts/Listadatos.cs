using Unity.VisualScripting;
using UnityEngine;

public class Listadatos : MonoBehaviour
{
    [SerializeField] public Variables variables;
    public struct Variableslistas 
    {  
        public int id;
        public int edad;
        public string nombre;
    }

    public Variableslistas[] variableslistas;

    //Variableslistas variableslistas
    //{
    //    set => id = variables.Id;
    //}



    void Start()
    {
     
    }

    public void Anadirjugador()
    {
        //revisar si hay algun hueco, sino ++ al ultimo
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
