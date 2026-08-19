// Controldor
// Repasito interpolación de cadenas de caracters
// Console.WriteLine($"sumar uno más uno da {1+1}");

class Program
{
    static void Main(string[] args)
    {
        // Declaramos una variable que será referencia para el objeto
        //Pocion veneno;
        // Creamos el objeto
        //veneno = new Pocion(); 

        // Todo de una
        Pocion veneno = new Pocion();

        veneno.Mostrar();
        veneno.Consumir(1);
        veneno.Mostrar();
    }
}


// Modelo
// declaramos la clase "Pocion"

class Pocion
{
    // Declaramos una variable para cada uno de los atributos
    // [visibilidad] [tipo de dato] [identicador] 
    // Podemos inicializar
    private ConsoleColor color = ConsoleColor.Red;
    private int calidad = 7;
    private int dosis = 3;

    // Declaramos y definimos una función para cada método
    public void Consumir (int cantidad) // Declaración (método)
    {
        dosis = dosis - cantidad; // Definición (comportamiento)
    }

    public void Mostrar()
    {
        Console.WriteLine($"Calidad:{calidad} Dosis:{dosis}");
    }
}

