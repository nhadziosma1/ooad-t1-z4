using System;

namespace ooad_t1_z4
{
    class Program
    {
        public static void ispravanUnos(String unos, out int broj)
        {
            while (Int32.TryParse(Console.ReadLine(), out broj) == false || broj==0)
                Console.WriteLine("neispravan unos, unesite ponovo");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Unesite broj koji ce predstvaljati dimenzije materice: ");
            int dimenzijeMatrice;

            ispravanUnos(string.Empty, out dimenzijeMatrice);

            //I nacin inicijaliziranja materice
            int[][] matrica = new int[dimenzijeMatrice][];
            for (int i = 0; i < dimenzijeMatrice; i++)
                matrica[i] = new int[dimenzijeMatrice];

            //II nacin
            int[,] matrica2 = new int[dimenzijeMatrice, dimenzijeMatrice];

            Console.WriteLine("Unesite elemente matrice: ");
            unesiElementeMatrice(matrica);
            //unesiElementeMatrice(matrica2);

            ispisiMatricu(matrica);

            Console.WriteLine("Kolona sa najvecom sumom elemenata je {0}, a suma elementa na dijagonali je {1}.", kolonaSaNajvecomSumomElemenata(matrica), sumaElemenataNaDijagonali(matrica));

            Console.ReadLine();
        }

        private static void ispisiMatricu(int[][] matrica)
        {
            for (int i = 0; i < matrica.Length; i++)
            {
                for (int j = 0; j < matrica[i].Length; j++)
                    Console.Write("{0} ", matrica[i][j]);

                Console.WriteLine();
            }
        }

        private static void unesiElementeMatrice(int[,] matrica2)
        {
            for(int i=0; i<matrica2.GetLength(0); i++)
            {
                for(int j=0; j<matrica2.GetLength(1); j++)
                {
                    ispravanUnos(string.Empty, out matrica2[i, j]);
                }
            }
        }

        private static void unesiElementeMatrice(int[][] matrica)
        {
            for (int i = 0; i < matrica.Length; i++)
            {
                for (int j = 0; j < matrica[i].Length; j++)
                {
                    ispravanUnos(string.Empty, out matrica[i][j]);
                }
            }
        }

        private static int sumaElemenataNaDijagonali(int[,] matrica2)
        {
            int suma = 0;

            //int[,,] multiDimensionalArray = new int[21,72,103];
            //then multiDimensionalArray.GetLength(n) will, for n = 0, 1 and 2, return 21, 72 and 103 respectively.

            for (int i = 0; i<matrica2.GetLength(0); i++)
            {
                for(int j=0; j<matrica2.GetLength(1); j++)
                {
                    if (i == j)
                        suma += matrica2[i, j];
                }
            }
            return suma;
        }

        private static int sumaElemenataNaDijagonali(int[][] matrica)
        {
            int suma = 0;

            //int[,,] multiDimensionalArray = new int[21,72,103];
            //then multiDimensionalArray.GetLength(n) will, for n = 0, 1 and 2, return 21, 72 and 103 respectively.

            for (int i = 0; i < matrica.Length; i++)
            {
                for (int j = 0; j < matrica[i].Length; j++)
                {
                    if (i == j)
                        suma += matrica[i][j];
                }
            }
            return suma;
        }

        private static int kolonaSaNajvecomSumomElemenata(int[][] matrica)
        {
            int[] nizSumaKolona = new int[matrica.Length];

            for(int i=0; i<matrica.Length; i++)
            {
                for(int j=0; j<matrica[i].Length; j++)
                {
                    nizSumaKolona[j] += matrica[i][j];
                }
            }

            int trazenaKolona=1, sumaKolone;

            if (nizSumaKolona.Length != 0)
                sumaKolone = nizSumaKolona[0];
            else
                throw new Exception("Matrica mora imati dimenzije vece od nula");

            for(int i=0; i<nizSumaKolona.Length; i++)
            {
                if(sumaKolone < nizSumaKolona[i])
                {
                    sumaKolone = nizSumaKolona[i];
                    trazenaKolona = i+1;
                }
            }

            return trazenaKolona;
        }
    }
}
