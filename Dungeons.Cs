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
            int decis = 0;
            int situacion = 0;
            //Jugador
            Console.WriteLine("¿Cual es tu nombre viajero?: ");
            string v = Console.ReadLine();
            Jugador Le = new Jugador(v);
            Le.Habilidad = Asignacion();
            Boost(Le.Habilidad, Le);
            Le.Stat();

            while (true)
            {
                Console.WriteLine("Quieres avanzar?:\n1.- Si\n2.-No ");
                int seguir = Convert.ToInt32(Console.ReadLine());
                Random rand = new Random();
               situacion = rand.Next(0,3);

                    if (seguir == 1)
                {
                    //Jugador decide
                    Decision(decis, Le, situacion);
                }                                
            }


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
            if (op1==op2)
            {
                habilidad = "Golden Boy";
            }
            else
            {
                switch (op1)
                {
                    case 0:
                        habilidad = "impenetrable";//
                        break;
                    case 1:
                        habilidad = "El Esquivo";//
                        break;
                    case 2:
                        habilidad = "Puños";//
                        break;
                    case 3:
                        habilidad = "El vasto";//
                        break;
                    case 4:
                        habilidad = "Toque sanador";//
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
                case "El vasto":
                    mob.Vida*=5;
                    break;
                case "El Esquivo":
                    mob.Velocidad*=5;
                    break;
                case "Puños":
                    mob.Daño*=5;
                    break;
                case "impenetrable":
                    mob.Defensa *= 5;
                    break;
                case "Golden Boy":
                    mob.Vida*=5;
                    mob.Defensa *= 5;
                    mob.Velocidad *= 5;
                    mob.Daño *= 5;
                    break;
                case "El más debil":
                    mob.Vida -= 9;
                    break;

            }
        }
        public static void Atacar(Personaje mob, Personaje ob)
        {
            int lostlife =  ob.Daño - (mob.Defensa / 3);
            if (lostlife > 0)
            {
                mob.Vida -= lostlife;
            }
            else { Console.WriteLine("Tu ataque hizo ningun daño \nTal vez deberias correr"); }
            if (mob.Vida <= 0)
            {
                mob.Vida = 0;
                mob.Existencia = 0;
                mob.Stat();
                Console.WriteLine("El enemigo fue abatido");
            }
        }
        public static void Huir(Personaje mob, Personaje ob)
        {

            if (ob.Velocidad > mob.Velocidad)
            {
                ob.Existencia=2;
                Console.WriteLine("Fuiste mas veloz");
            }
            else {
                Atacar(ob,mob);
                Console.WriteLine("No podras salir de esta tan facil, toma otra decison:\n "); }
        }
        public static void Decision(int desi,Personaje ob, int situacion = 0)
        {
            if (situacion == 0 || situacion == 2)
            {
                Console.WriteLine("Una habitacion vacia... \nSeguimos adelante?");
            }
            if (situacion == 1)
            {
                Console.WriteLine("Encontraste a un enemigo\n");
                Mob gob = new Mob(1);
                
                gob.Habilidad = "Debilidad " + 1;
                gob.Stat();
                while ((gob.Existencia == 1) && (ob.Existencia == 1))
                {
                    
                    Console.WriteLine("Decide: \n1.- Pelear\n2.- Huir\n");
                    desi = Convert.ToInt32(Console.ReadLine());
                    switch (desi)
                    {
                        case 1:
                            Atacar(gob, ob);
                            break;
                        case 2:
                            Huir(gob,ob);
                            break;
                    }
                }
                if (ob.Vida != 0 && ob.Existencia == 2)
                    ob.Existencia = 1;
                
            }
        }
    }

class Personaje
{
    //private int lvl=1;//Implementar a futuro
    private int vida=1;
    private int defensa=1;
    private int velocidad=1;
    private int daño=1;
    private string nombre;
    private string habilidadH;
    private int existencia=1;

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
    public void Stat()
        {
            Console.WriteLine("Vida = {0} \nDefensa = {1} \nVelocidad = {2} \nDaño = {4} \nHabilidad = {3}\n", Vida, Defensa, Velocidad, Habilidad, Daño);
        }
    public int Existencia
        {
            get { return existencia; }
            set { existencia = value;}
        }
    
    }
    class Jugador : Personaje
    {
        public Jugador(string v)
        {
            Nombre = v;
            //Jugador lvl 1 sin habilidad
            Vida = 10;
            Daño = 10;
            Defensa = 10;
            Velocidad = 10;
        }
    }
    class Mob : Personaje
    {       
        public Mob(int lvl)
            {
            Nombre ="Goblin";
            //Goblin lvl 1 sin habilidad
            Vida = 1*(lvl);
            Daño = 6*(lvl);
            Defensa = 0*(lvl);
            Velocidad = 6*(lvl);
            }
        ~Mob()
        {      
        }
    }
}

             