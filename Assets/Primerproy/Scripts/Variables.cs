using UnityEngine;

public class Variables : MonoBehaviour
{ // aca estan las variables
    private int id = 83000;
    private int edad = 15;
    private string nombre;

    public int Id { get => id; set => id = value; }
    public int Edad { get => edad; set => edad = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}
