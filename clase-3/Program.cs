class Program 
{
    static void Main(string[] args)
    {
        Random rng = new Random();

        Carta carta1 = new Carta(100, rng.Next(5, 11), rng.Next(0, 6));
        Carta carta2 = new Carta(100, rng.Next(5, 11), rng.Next(0, 6));

        carta1.Mostrar();
        carta2.Mostrar();
        Console.WriteLine("---------------------------");
        
        while(carta1.estaActiva() && carta2.estaActiva())
        {
            carta1.Atacar(carta2);
            carta2.Atacar();
            carta1.Mostrar();
            carta2.Mostrar();
            Console.WriteLine("---------------------------");
        }
        
        
    }
}

class Carta
{
    private int puntosVida;
    private int puntosAtaque;
    private int puntosDefensa;
    private Carta? cartaRival;

    public Carta(int puntosVida, int puntosAtaque, int puntosDefensa)
    {
        this.puntosVida = puntosVida;
        this.puntosAtaque = puntosAtaque;
        this.puntosDefensa = puntosDefensa;
        this.cartaRival = null;  // ¿ por qué ?
    } 

    public int getPuntosAtaque() { return puntosAtaque; }

    public bool estaActiva() { return puntosVida > 0; }
   
    public void Atacar() 
    {
        if (cartaRival != null)
            Atacar(cartaRival); 
    }
    public void Atacar(Carta unaCarta) // Polimorfismo
    {
        unaCarta.Recibiratque(this);
    }
    public void Recibiratque(Carta atacante)
    {
        puntosVida -= (atacante.getPuntosAtaque() - puntosDefensa);
        cartaRival = atacante;
    }

    public void Mostrar()
    {
        Console.WriteLine($"[{puntosAtaque}-{puntosDefensa}] Vida:{puntosVida}");
    }
}
