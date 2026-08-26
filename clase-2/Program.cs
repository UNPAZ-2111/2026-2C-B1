class Program
{
    static void Main(string[] args)
    {
        Contenedor mochila = new Contenedor();
        mochila.setCapacidad(10);
        mochila.setClave("1234");
        mochila.Mostrar();

        Contenedor valija = new Contenedor(100, "abracadabra");
        valija.Mostrar();
        //Console.WriteLine(valija.getClave());
        valija.Abrir("abracadabra");
        valija.Mostrar();
        valija.Cerrar();
        valija.Mostrar();
        
        Tarjeta black = new Tarjeta("1234");
        // Vamos a estudiar "null", la clase que viene
        //Tarjeta master;

        mochila.Abrir(master);
        mochila.Mostrar();

    }   
}
class Contenedor
{
    private int capacidad;
    private int cantidadItems = 0;
    private string clave;
    private bool abierto;

    public Contenedor()
    {
        capacidad = 5;
        clave = "1234";
    }
    
    public Contenedor(int capacidad, string clave)
    {
        setCapacidad(capacidad);
        setClave(clave);
    }

    public void setCapacidad(int capacidad)
    {
        this.capacidad = capacidad;
    }
    public void setClave(string clave) { this.clave = clave; }
    
    public string getClave() { return clave; }
    
    public void Abrir(string clave)
    {
        if (clave == this.clave)
            abierto = true;
    }

    public void Abrir(Tarjeta unaTarjeta)
    {
        Abrir(unaTarjeta.getClave());
    }
    public void Cerrar() { abierto = false; }
    
    public void Mostrar()
    {
        Console.WriteLine($"[{cantidadItems}/{capacidad}] Abierto:{abierto} Clave:{clave}");
    }
}

class Tarjeta
{
    private string clave;

    public Tarjeta(string clave) { setClave(clave); }
    public void setClave(string clave) { this.clave = clave; }
    public string getClave() { return clave; }
    
}