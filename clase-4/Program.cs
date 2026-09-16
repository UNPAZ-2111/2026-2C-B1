class Program
{
    static void Main(string[] args)
    {
        Alma alma1 = new AlmaRoja();
        
        Alma alma2;
        alma1.irA(17, 17);
 
        Console.WriteLine(alma1);
        Console.ReadKey();

        Random rng = new Random();

        if (rng.Next(10) < 5)
            alma2 = new AlmaRoja();
        else
            alma2 = new AlmaAzul();

        alma1.irA(7, 7);
        alma2.irA(14, 14);

        Console.CursorVisible = false;

        while (true)
        {
            Console.ResetColor();
            Console.Clear();
         
            Console.SetCursorPosition(alma1.getx(), alma1.gety());
            Console.BackgroundColor = alma1.getcolor();
            Console.Write('@');
     
            Console.SetCursorPosition(alma2.getx(), alma2.gety());
            Console.BackgroundColor = alma2.getcolor();
            Console.Write('@');
     
            Console.ReadKey();

            alma1.Mover();
            if (alma2 is AlmaRoja)
                alma2.irA(alma1.getx()-1, alma1.gety());
            else
                alma2.Mover();
        }
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

    override public void Mover()
    {
        x++;
    }

}