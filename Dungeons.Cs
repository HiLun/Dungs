using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsDungeons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¿Cual es tu nombre viajero?: ");
            string v = Console.ReadLine();
            Jugador Le = new Jugador();

            //datos
            Le.Habilidad = Asignacion();
            Le.Nombre = v;           
            Le.Velocidad = 10;
            Le.Vida = 10;
            Le.Defensa = 10;
            Le.Daño = 10;
            Boost(Le.Habilidad, Le);
            Le.Stat();




            Console.ReadKey();
        }
        public static string Asignacion()
        {
            string habilidad="";
            Random rand = new Random();
            int op1 = rand.Next(0, 5);
            //Console.WriteLine(habilidadH);
            int op2 = rand.Next(0, 5);
            //Console.WriteLine(habilidadH);
            if (true)
            {
                habilidad = "Golden Boy";
            }
            else
            {
                switch (op1)
                {
                    case 0:
                        habilidad = "impenetrable";
                        break;
                    case 1:
                        habilidad = "El Esquivo";
                        break;
                    case 2:
                        habilidad = "Puños";
                        break;
                    case 3:
                        habilidad = "El vasto";
                        break;
                    case 4:
                        habilidad = "Toque sanador";
                        break;
                    case 5:
                        habilidad = "El más debil";
                        break;
                }
            }
            //string H = hablilidadH;
            return habilidad;
        }
        public static void Boost(string habili,Personaje mob )
        {
            switch (habili)
            {
                case "Toque sanador":
                    Console.WriteLine("Aun no hay poder sorry bro");
                    break;
                case "":
                    Console.WriteLine("Aun no hay poder sorry bro");
                    break;
               /* case "":
                    Console.WriteLine("Aun no hay poder sorry bro");
                    break;
                case "":
                    Console.WriteLine("Aun no hay poder sorry bro");
                    break;
                case "":
                    Console.WriteLine("Aun no hay poder sorry bro");
                    break;*/
                case "Golden Boy":
                    mob.Vida*=5;
                    mob.Defensa *= 5;
                    mob.Velocidad *= 5;
                    mob.Daño *= 5;
                    
                    break;

            }
        }
    }

class Personaje
{
    private int lvl;
    private int vida;
    private int defensa;
    private int velocidad;
    private int daño=0;
    private string nombre;
    private string habilidadH;

    public int Vida
    {
        get { return vida; }
        set { vida = value; }
    }
    public int Velocidad
    {
        get { return velocidad; }
        set { velocidad = value; }
    }
    public int Defensa
    {
        get { return defensa; }
        set { defensa = value; }
    }
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public string Habilidad
    {
        get { return habilidadH; }
        set { habilidadH = value; }
    }
    public int Daño
        {
            get { return daño; }
            set { daño = value; }
        }
    }
    class Jugador : Personaje
    {
        public void Stat()
        {
            Console.WriteLine("Vida = {0} \nDefensa = {1} \nVelocidad = {2} \nDaño = {4} \nHabilidad = {3}", Vida, Defensa, Velocidad, Habilidad,Daño);
        }

    }

}
