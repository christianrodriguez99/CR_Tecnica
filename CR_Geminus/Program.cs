namespace CR_Geminus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                salir = MostrarMenu(salir);
            }

        }

        private static bool MostrarMenu(bool salir)
        {
            Console.Clear();
            Console.WriteLine("1 - Ejercicio 1");
            Console.WriteLine("2 - Ejercicio 2");
            Console.WriteLine("3 - Ejercicio 3");
            Console.WriteLine("4 - Salir");
            Console.WriteLine();
            Console.WriteLine("Elija una opcion");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    EjercicioUno();
                    break;
                case 2:
                    EjercicioDos();
                    break;
                case 3:
                    EjercicioTres();
                    break;
                case 4:
                    salir = true;
                    break;
            }

            return salir;
        }

        private static void EjercicioUno()
        {
            Console.Clear();
            const string negro = "X";
            const string blanco = "_";
            bool esNegro = true;

            Console.WriteLine("Cantidad de casillas:");
            int n = Convert.ToInt32(Console.ReadLine());


            if (n < 1 || n > 10)
            {
                n = 5;
            }
            string[,] matriz = new string[n, n];

            for (int col = 0; col < n; col++)
            {
                for (int filas = 0; filas < n; filas++)
                {
                    if (esNegro)
                    {
                        matriz[col, filas] = negro;
                        esNegro = false;
                        Console.Write(matriz[col, filas]);
                    }
                    else
                    {
                        matriz[col, filas] = blanco;
                        esNegro = true;
                        Console.Write(matriz[col, filas]);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("1 - Probar otro valor");
            Console.WriteLine("2 - Salir");

            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
                EjercicioUno();
        }

        private static void EjercicioDos()
        {
            Console.Clear();
            string[,] matrizVista = new string[4, 4];
            int[,] matrizPosiciones = new int[5, 2];
            int posicionX = 1;
            int posicionY = 1;

            int posicionVista = 1;


            for (int x = 0; x < matrizPosiciones.GetLength(0); x++)
            {

                for (int y = 0; y < matrizPosiciones.GetLength(1); y++)
                {
                    Console.Clear();
                    Console.WriteLine($"Ingrese valor en x{posicionVista}");
                    matrizPosiciones[x, y] = Convert.ToInt32(Console.ReadLine());

                    if (matrizPosiciones[x, y] + posicionX > 0 && matrizPosiciones[x, y] + posicionX < 5)
                    {
                        posicionX = posicionX + matrizPosiciones[x, y];
                    }
                    else if (matrizPosiciones[x, y] + posicionX <= 0)
                    {
                        posicionX = 1;
                    }
                    else if (matrizPosiciones[x, y] + posicionX >= 5)
                    {
                        posicionX = 4;
                    }


                    y++;

                    Console.WriteLine($"Ingrese valor en y{posicionVista}");
                    matrizPosiciones[x, y] = Convert.ToInt32(Console.ReadLine());

                    if (matrizPosiciones[x, y] + posicionY > 0 && matrizPosiciones[x, y] + posicionY < 5)
                    {
                        posicionY = posicionY + matrizPosiciones[x, y];
                    }
                    else if (matrizPosiciones[x, y] + posicionY <= 0)
                    {
                        posicionY = 1;
                    }
                    else if (matrizPosiciones[x, y] + posicionY >= 5)
                    {
                        posicionY = 4;
                    }

                    posicionVista++;
                }
                Console.WriteLine($"Posicion X actual:");
                for (int col = 0; col < matrizVista.GetLength(0); col++)
                {
                    for (int filas = 0; filas < matrizVista.GetLength(1); filas++)
                    {
                        if (posicionX - 1 == filas && posicionY - 1 == col)
                            matrizVista[filas, col] = "X";
                        else
                            matrizVista[filas, col] = "O";
                        Console.Write(matrizVista[filas, col]);
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }

        private static void EjercicioTres()
        {
            Console.Clear();
            int contadorCajas = 1;

            const double capacidadTotal = 141;
            const double alturaTotal = 3;
            const double longitudTotal = 15.4;
            double anchoTotal = capacidadTotal / alturaTotal / longitudTotal;

            Contenedor contenedorUno = new(1, capacidadTotal, alturaTotal, longitudTotal, anchoTotal);
            Contenedor contenedorDos = new(2, capacidadTotal, alturaTotal, longitudTotal, anchoTotal);
            Contenedor contenedorTres = new(3, capacidadTotal, alturaTotal, longitudTotal, anchoTotal);

            List<Contenedor> contenedores = new List<Contenedor>();
            contenedores.Add(contenedorUno);
            contenedores.Add(contenedorDos);
            contenedores.Add(contenedorTres);

            bool salir = false;
            while (!salir)
            {
                Caja caja = new();
                Console.WriteLine($"Para completar la carga, ingrese 0 en alguna dimension");
                Console.WriteLine($"Cargado de caja numero: {contadorCajas}");
                Console.WriteLine();
                Console.WriteLine("Cargar altura:");
                caja.Altura = Convert.ToDouble(Console.ReadLine());

                if (caja.Altura > alturaTotal)
                {
                    Console.WriteLine($"Carga no factible, la altura es mayor a la total del contenedor");
                    Console.ReadKey();
                    salir = true;
                    break;
                }

                if (caja.Altura == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Carga terminada");
                    MostrarResultados(contenedores);
                    Console.ReadKey();
                }
                Console.WriteLine("Cargar ancho:");
                caja.Ancho = Convert.ToDouble(Console.ReadLine());

                if (caja.Ancho > anchoTotal)
                {
                    Console.WriteLine($"Carga no factible, el ancho es mayor a la total del contenedor");
                    Console.ReadKey();
                    salir = true;
                    break;
                }
                if (caja.Ancho == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Carga terminada");
                    MostrarResultados(contenedores);
                    Console.ReadKey();
                }

                Console.WriteLine("Cargar longitud:");
                caja.Longitud = Convert.ToDouble(Console.ReadLine());

                if (caja.Longitud > longitudTotal)
                {
                    Console.WriteLine($"Carga no factible, la longitud es mayor a la total del contenedor");
                    Console.ReadKey();
                    salir = true;
                    break;
                }

                if (caja.Longitud == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Carga terminada");
                    MostrarResultados(contenedores);
                    Console.ReadKey();
                }

                caja.Capacidad = caja.Ancho * caja.Altura * caja.Longitud;
                caja.NumeroCaja = contadorCajas;

                contenedores = contenedores.OrderByDescending(x => x.Capacidad).ThenBy(x => x.NumeroContenedor).ToList();

                if (caja.Capacidad > contenedores[0].Capacidad)
                {
                    Console.WriteLine($"Carga no factible, no queda mas capacidad en los contenedores para cargar la caja");
                    Console.ReadKey();
                    MostrarResultados(contenedores);
                }

                foreach (Contenedor contenedor in contenedores)
                {
                    if (caja.Altura > contenedor.Altura)
                    {
                        contenedor.TieneLugarParaUltimaCaja = false;
                    }
                    if (caja.Ancho > contenedor.Ancho)
                    {
                        contenedor.TieneLugarParaUltimaCaja = false;
                    }
                    if (caja.Longitud > contenedor.Longitud)
                    {
                        contenedor.TieneLugarParaUltimaCaja = false;
                    }
                    if (contenedor.TieneLugarParaUltimaCaja)
                    {
                        contenedor.Altura = contenedor.Altura - caja.Altura;
                        contenedor.Ancho = contenedor.Ancho - caja.Ancho;
                        contenedor.Longitud = contenedor.Longitud - caja.Longitud;
                        contenedor.Capacidad = contenedor.Capacidad - caja.Capacidad;
                        contenedor.cajas.Add(caja);
                        break;
                    }
                }

                Console.Clear();
                if (contenedores.All(x => x.TieneLugarParaUltimaCaja == false))
                {
                    Console.WriteLine($"Carga no factible, no queda mas lugar o capacidad en ningun contenedor para cargar la caja");
                    Console.WriteLine($"Aprete una tecla para continuar");
                    Console.ReadKey();
                    MostrarResultados(contenedores);
                }

                foreach (Contenedor contenedor in contenedores)
                {
                    contenedor.TieneLugarParaUltimaCaja = true;
                }
                contadorCajas++;
            }
            MostrarResultados(contenedores);
        }

        public static void MostrarResultados(List<Contenedor> contenedores)
        {
            Console.Clear();
            contenedores = contenedores.OrderBy(x => x.NumeroContenedor).ToList();
            foreach (Contenedor contenedor in contenedores)
            {
                Console.WriteLine(contenedor.ToString());
                foreach (Caja caja in contenedor.cajas)
                {
                    Console.WriteLine(caja.ToString());
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            if (contenedores.All(x => x.TieneLugarParaUltimaCaja == false))
            {
                MostrarMenu(false);
            }
        }
        public class Caja
        {
            public override string ToString()
            {
                return String.Format("NumeroCaja: {0}, Capacidad: {1}, Altura: {2}, Longitud: {3}, Ancho; {4}"
                    , NumeroCaja, Capacidad, Altura, Longitud, Ancho);
            }
            public int NumeroCaja { get; set; }
            public double Capacidad { get; set; }
            public double Altura { get; set; }
            public double Longitud { get; set; }
            public double Ancho { get; set; }
        }

        public class Contenedor
        {
            public Contenedor(int numeroContenedor, double capacidad, double altura, double longitud, double ancho)
            {
                NumeroContenedor = numeroContenedor;
                Capacidad = capacidad;
                Altura = altura;
                Longitud = longitud;
                Ancho = ancho;
            }
            public override string ToString()
            {
                return String.Format("NumeroContenedor: {0}, Capacidad: {1}, Altura: {2}, Longitud: {3}, Ancho; {4}"
                    , NumeroContenedor, Capacidad, Altura, Longitud, Ancho);
            }
            public int NumeroContenedor { get; set; }
            public double Capacidad { get; set; }
            public double Altura { get; set; }
            public double Longitud { get; set; }
            public double Ancho { get; set; }
            public bool TieneLugarParaUltimaCaja { get; set; } = true;

            public List<Caja> cajas = new List<Caja>();
        }

    }
}