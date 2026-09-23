class Program
{
    static void Main(string[] args)
    {
        Alma alma;

        Random rng = new Random();

        if (rng.Next(10) < 5)
            alma = new AlmaRoja();
        else
            alma = new AlmaAzul();
        /*
        if (alma is AlmaRoja)
        {
            AlmaRoja almaObjetivo = alma as AlmaRoja;
            almaObjetivo.Incinerar();
        }
        */
        AlmaRoja? almaRoja;
        AlmaAzul? almaAzul;
        
        almaRoja = alma as AlmaRoja;
        if (almaRoja != null)
            almaRoja.Incinerar();
        
        almaAzul = alma as AlmaAzul;
        if (almaAzul != null)
            almaAzul.Congelar();

        Console.Title = "UNPAZ";
     
        Alma almanaque = new Alma(ConsoleColor.Green);

        almanaque.X = 17;

        //Console.WriteLine($"{almanaque.getx()}");
        Console.WriteLine($"{almanaque.X}");
     
        Console.ReadKey();

        
        
    }
}

class Alma
{
    protected int x;
    protected int y;
    private ConsoleColor color;

    public Alma(ConsoleColor color)
    { 
        this.color = color;
    }

    public int X 
    {
        get { return x * 2; }
        set { x = value; }
    }

    public int getx() { return x; }
    public int gety() { return y; }
    public ConsoleColor getcolor() { return color; }

    public void irA(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    virtual public void Mover()
    {
        Console.WriteLine("¿Dijiste mover?");
    }

    override public string ToString()
    {
        return $"Soy un almita en pena, me encontrás en {x},{y}";
    }
}

class AlmaRoja : Alma 
{
    public AlmaRoja() : base(ConsoleColor.Red) 
    {
        //color = ConsoleColor.Red;
    }

    public void Incinerar()
    {
        Console.WriteLine("Fuego");
    }
    override public void Mover()
    {
        y++;
    }
}

class AlmaAzul : Alma
{
    public AlmaAzul() : base(ConsoleColor.Blue) 
    {
    }

    public void Congelar() 
    {
        Console.WriteLine("Que chucho manucho");
    }
    override public void Mover()
    {
        x++;
    }

}