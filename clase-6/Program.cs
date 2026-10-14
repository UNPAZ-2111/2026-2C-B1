// REPASO DE ARREGLOS

// Declaramos un arreglo unidimensional llamado "dados"
//int[] dados;
// Construimos un arreglo de longitud 5
//dados = new int[5];

// todo de una
/*
int[] dados = new int[5];

Random rng = new Random();

for (int i = 0; i < 5; i++)
    dados[i] = rng.Next(1, 7);

for (int i = 0; i < 5; i++)
    Console.Write($"{dados[i]} ");

Console.WriteLine();


char[,] letras = new char[3, 3];

char letra = 'A';
for (int f = 0; f < 3; f++)
    for (int c = 0; c < 3; c++)
        letras[f, c] = letra++; 

Console.WriteLine($"La longitud en la dimensión cero del arreglo letras es {letras.GetLength(0)}");
Console.WriteLine($"La longitud en la dimensión uno del arreglo letras es {letras.GetLength(1)}");

for (int f = 0; f < 3; f++)
{
    for (int c = 0; c < 3; c++)
        Console.Write(letras[f, c]);
    Console.WriteLine();
}

*/


class Program
{
    
    static public void Main(string[] args)
    {
        Juego juego = new Juego();

    }       
}
class Juego
{
    private Item? item;

    public Juego()
    {
        Personaje perso = new Personaje();
//        Pistola pistola = new Pistola("Super pistola");
//        Botella botella = new Botella("Botella interminable");
//        Pocion pocion = new Pocion("Tang de uva");

        Random rng = new Random();
        
        int claseItem = rng.Next(0, 4);
        
        switch(claseItem)
        {
            case 0: 
                item = new Pistola("Pistola random");
                break;
            case 1:
                item = new Botella("Botella random");        
                break;
            case 2:
                item = new Pocion("Pocion random (pero Tang)");
                break;
            case 3:
                item = new Agua("H2O");
                break;
        
        }
        perso.AgarrarItem(new Botella("Super botella"));
        perso.AgarrarItem(new Pocion("Pocion random (pero Tang)"));
        perso.AgarrarItem(new Agua("H2O"));

        perso.AgarrarItem(item);
        perso.Mostrar();
        if (perso.estaArmada())
            Console.WriteLine("Cuidado...");

    }
}
class Personaje
{
    private Item[] inventario;

    public Personaje()
    {
        inventario = new Item[10];
    }

    public bool AgarrarItem(Item? unItem) 
    {
        if (unItem == null)
            return false;
        if (unItem is Agua || unItem is Pocion)
            return Embotellar(unItem);
        else
        {
            for (int i = 0; i < inventario.GetLength(0); i++)
                if (inventario[i] == null)
                {
                    inventario[i] = unItem;
                    return true;
                }
            return false;
        }
        
    }

    public bool Embotellar(Item unItem)
    {
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] is Botella)
            {
                Botella botella = inventario[i] as Botella;
                if (botella != null)
                    botella.AgregarItem(unItem);
                return true;
            }
            return false;
    }
    
    public bool estaArmada()
    {
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] is Pistola)
                return true;
        
        return false;
    }

    public void Mostrar()
    {
        Console.WriteLine("Inventario: ");
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] != null)
            {
                if (inventario[i] is Botella)
                {
                    Botella botella = inventario[i] as Botella;
                    if (botella != null)
                        botella.Mostrar();
                }
                    
                else
                    Console.WriteLine($"\t{inventario[i].getDescripcion()}");
            }   
        
    }

    
}
class Item
{
    private string descripcion;

    public Item(string descripcion) { this.descripcion = descripcion; }
    public string getDescripcion() { return descripcion; }

}

class Pistola : Item
{
    public Pistola(string descripcion) : base(descripcion) {}
}

class Botella : Item
{
    private Pocion? pocion;
    private Agua? agua;

    public Botella(string descripcion) : base(descripcion) 
    {
        pocion = null;
        agua = null;
    }
    
    public void AgregarItem(Item? unItem)
    {
        if (unItem is Pocion)
            pocion = unItem as Pocion;
        if (unItem is Agua)
            agua = unItem as Agua;
        
    }
    
    public bool estalista() { return (pocion != null && agua != null); }
    
    public void Consumir()
    {
        pocion = null;
        agua = null;
    }

    public void Mostrar()
    {
        Console.Write("Botella: ");
        if (pocion != null)
            Console.Write($"{pocion.getDescripcion()} ");
        if (agua != null)
            Console.Write($"{agua.getDescripcion()} ");
        Console.WriteLine($" lista: {estalista()}");
    }
}

class Pocion : Item 
{
    public Pocion(string descripcion) : base(descripcion) {}
}

class Agua : Item 
{
    public Agua(string descripcion) : base(descripcion) {}
}

