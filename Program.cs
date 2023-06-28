// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



Console.WriteLine("Indique cuantas tareas desea realizar: ");

int cantidad = Convert.ToInt32(Console.ReadLine());

var realizadas = new List<Tarea>();

var pendientes = new List<Tarea>();

for (int i = 0; i < cantidad; i++)
{
    Console.WriteLine("Tarea #" + (i + 1) + "\n");
    CargarTarea(pendientes, i);
}

Console.WriteLine("\n");
// mostrar Lista de Tareas

Console.WriteLine("\nLos Tareas asignadas son:\n");
mostrarTareas(pendientes);

Console.WriteLine("\n");
PendientesORealizadas(pendientes, realizadas);

Console.WriteLine("\nLos Tareas realizadas son:\n");
mostrarTareas(pendientes);

Console.WriteLine("\nLos Tareas aun pendientes son:\n");
mostrarTareas(pendientes);



string fileName = "HorasTrabajadas.txt";
string mensaje = "El Total de horas trabajadas son: ";
int Horaspend = Horas(pendientes);
int Horasrealiz = Horas(realizadas);
int HorasTotales = Horaspend + Horasrealiz;


FileStream fs = new FileStream(fileName, FileMode.Create);
using (StreamWriter writer = new StreamWriter(fs))
{
    writer.Write(mensaje);
    writer.Write(HorasTotales);
}

// Create an instance of StreamReader to read from a file.
// The using statement also closes the StreamReader.
try
{


    using (StreamReader sr = new StreamReader("HorasTrabajadas.txt"))
    {
        string? line;
        // Read and display lines from the file until the end of
        // the file is reached.
        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
catch (Exception e)
{
    // Let the user know what went wrong.
    Console.WriteLine("El archivo no se pudo leer:");
    Console.WriteLine(e.Message);
}

//METODOS(FUNCIONES
void CargarTarea(List<Tarea> pendiente, int cantidad)
{
    Random Rand = new Random();
    string[] Tareas = { "Tarea1", "Tarea2", "Tarea3", "Tarea4", "Tarea5", "Tarea6" };
    int T = Rand.Next(Tareas.Length);
    var Tarea1 = new Tarea();
    Console.WriteLine("Ingrese el ID de la tarea");
    Tarea1.Id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese la descripcion de la tarea");
    Tarea1.Descripcion = Tareas[T];
    Tarea1.Duracion = Rand.Next(1, 101);
    pendiente.Add(Tarea1);
}





void PendientesORealizadas(List<Tarea> pendiente, List<Tarea> realizadas)
{
    int numTrealizadas = 0;
    foreach (Tarea tarea in pendientes)
    {
        Console.WriteLine("Se realizo la tarea # ? (Si(1)/No(0))");
        int respuesta = Convert.ToInt32(Console.ReadLine());
        if (respuesta == 1)
        {
            realizadas.Add(tarea);
        }
        numTrealizadas++;
    }
    foreach (Tarea tarea in realizadas)
    {
        pendiente.Remove(tarea);
    }


}

void mostrarTareas(List<Tarea> Listas)
{

    foreach (Tarea tarea in Listas)
    {
        Console.WriteLine($"ID :{tarea.Id} \n");
        Console.WriteLine($"Descripcion : {tarea.Descripcion}\n");
        Console.WriteLine($"Duracion : {tarea.Duracion}\n");

    }
}

int Horas(List<Tarea> Listas)
{
    int HorasTotales = 0;
    foreach (Tarea tarea in Listas)
    {
        HorasTotales += tarea.Duracion;

    }
    return HorasTotales;

}





public class Tarea
{
    private int id;
    private string? descripcion;
    private int duracion;
    public int Id { get => id; set => id = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }
}



