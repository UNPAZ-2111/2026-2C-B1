class Program
{
    /*
    static void Main(string[] args)
    {
        for (int i = 0; i < args.GetLength(0); i++)
            Console.WriteLine($"args[{i}]={args[i]}");
    }
    */
    static void Main()
    {
        //Carta carta1 = new Carta(1, "Bastos");
        //Console.WriteLine(carta1.getDescripcion());

        Mazo mazo = new Mazo();
        //mazo.AgregarCarta(carta1);
        //Console.WriteLine(mazo.CantidadCartas());
        mazo.Generar();
        //mazo.Mostrar();
        //Carta miCarta = mazo.QuitarCartaAlAzar();
        
        //Console.WriteLine($"Me tocó el {miCarta.getDescripcion()}");
        //mazo.Mostrar();
        /*
        Jugador rene = new Jugador();
        while(!rene.ManoCompleta())
            rene.RecibirCarta(mazo.QuitarCartaAlAzar());
        
        rene.MostrarMano();
        */
        Carta carta1 = new Carta(1, "Espadas");
        Carta carta2 = new Carta(1, "Espadas");
    //    if (carta1 == carta2)
    //        Console.WriteLine("Son iguales");
    //    else
    //        Console.WriteLine("Obvio que no porque estás comparando las referencias");
    
        if (carta1.esIgualA(carta2))
            Console.WriteLine("menos mal");
    }
}

class Jugador
{
    private List<Carta> mano;

    public Jugador()
    {
        mano = new List<Carta>();
    }
    public bool RecibirCarta(Carta unaCarta)
    {
        if (ManoCompleta())
            return false;
        mano.Add(unaCarta);
        return true;
    }
    public bool ManoCompleta()
    {
        return (mano.Count() == 3);
    }
    public void MostrarMano()
    {
        foreach (Carta estaCarta in mano)
            Console.WriteLine($"{estaCarta.getDescripcion()}");
    }
}
class Mazo
{
    // Declaramos una lista (tipo genérico) indicando su tipo/clase
    private List<Carta> cartas;
    
    public Mazo()
    {
        cartas = new List<Carta>();   
    }
    public void Generar()
    {
        // Solución muy trucha
        //Generar12Cartas("Bastos");
        //Generar12Cartas("Copas");
        //Generar12Cartas("Espadas");
        //Generar12Cartas("Oros");
        
        //Antes de poblar la lista es mejor vaciarla

        string[] palos = {"Bastos", "Copas", "Espadas", "Oros"};
        cartas.Clear();

        for (int i = 0; i < palos.GetLength(0); i++)
            Generar12Cartas(palos[i]);

            //Console.WriteLine($"{palos[i]}");

        
    }
    private void Generar12Cartas(string palo)
    {
        for (int i = 0; i < 3; i++)
            AgregarCarta(new Carta(i+1, palo));

    }
    public void AgregarCarta(Carta unaCarta)
    {
        cartas.Add(unaCarta);
    } 
    public int CantidadCartas()
    {
        return cartas.Count();
    }
    
    public Carta QuitarCartaAlAzar()
    {
        Random rng = new Random(); // Se podría llevar a atributo de clase

        int ubicacionCarta = rng.Next(cartas.Count());
        Carta carta = cartas[ubicacionCarta]; 
        cartas.RemoveAt(ubicacionCarta);
        return carta;

    }

    public void Mostrar()
    {
        //for (int i = 0; i < CantidadCartas(); i++)
        //    Console.WriteLine($"{cartas[i].getDescripcion()}");
    
        // Alternativa utilizando iteradores
        foreach (Carta estaCarta in cartas)
        {
            Console.WriteLine($"{estaCarta.getDescripcion()}");
        }
    }
}
class Carta
{
    private int valor;
    private string palo;

    public Carta(int valor, string palo)
    {
        this.valor = valor;
        this.palo = palo;
    } 
    public string getDescripcion()
    {
        return $"{valor} de {palo}";
    }
    public bool esIgualA(Carta otraCarta)
    {
        return valor == otraCarta.getValor() && palo == otraCarta.getPalo();
    }
    public int getValor() { return valor; }
    public string getPalo() {return palo; }
}
