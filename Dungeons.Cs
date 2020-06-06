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
            Le.Nombre = v;
            Le.Velocidad = 10;
            Le.Vida = 10;
            Le.Defensa = 10;
            Le.Stat();

            Jugador Loco = new Jugador();

            Loco.Stat();


            Console.ReadKey();
        }
    }
    class Personaje
    {
        private int vida;
        private int defensa;
        private int velocidad;
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

        //Este metodo le da las habilidades tanto a goblins como al jugador
        public Personaje()
        {
            Random rand = new Random();
            int op1 = rand.Next(0, 5);
            //Console.WriteLine(habilidadH);
            int op2 = rand.Next(0, 5);
            //Console.WriteLine(habilidadH);
            if (op1 == op2)
            {
                habilidadH = "Golden Boy";
            }
            else
            {
                switch (op1)
                {
                    case 0:
                        habilidadH = "impenetrable";
                        break;
                    case 1:
                        habilidadH = "El Esquivo";
                        break;
                    case 2:
                        habilidadH = "Puños";
                        break;
                    case 3:
                        habilidadH = "El vasto";
                        break;
                    case 4:
                        habilidadH = "Toque sanador";
                        break;
                    case 5:
                        habilidadH = "El más debil";
                        break;
                }
            }
            //string H = hablilidadH;

            Console.WriteLine("Tu habilidad especial es: {0}", habilidadH);
            //return H;
        }
    }
    class Jugador : Personaje
    {
        public void Stat()
        {
            Console.WriteLine("Vida = {0} \nDefensa = {1} \nVelocidad = {2}", Vida, Defensa, Velocidad);
        }

    }

}
