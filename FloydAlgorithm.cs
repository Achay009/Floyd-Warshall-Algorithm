using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace floyd_shortest_path
{
    class FloydAlgorithm
    {
        public const int infinity = 100000 ;
        public void start()
        {
          //infinity is  set to 100000
            Console.WriteLine("Let Infinity =100000");
            
            Console.WriteLine("Enter the number of nodes");
            int ans = Convert.ToInt32(Console.ReadLine());
            int[,] arrayD = new int[ans, ans];
            
            for (int row = 0; row <arrayD.GetLength(0); row++)
            {
                for (int column = 0; column < arrayD.GetLength(1); column++)
                {
                    Console.WriteLine("enter row-{0} column-{1}", row, column);
                    Console.WriteLine("\n1)Positive Real Number                    2)Infinity  ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {

                        //input the values in tabular form to be extracted//
                        Console.WriteLine("enter row-{0} column-{1}", row, column);
                        arrayD[row, column] = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    else if (choice == 2)
                    {

                        arrayD[row, column] = infinity;
                        Console.Clear();
                    }




                }


            }


            computeFloyd(arrayD, ans);




        }





        // start the floyd shortest path
        public void computeFloyd(int[,] graph, int verticesCount)
        {
            
            int[,] distance = graph;
            int[,] Smatrix = createS(distance);

            int count = 1;

            for (int k = 0; k < verticesCount; k++)
            {
               
                for (int i = 0; i < verticesCount; i++)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {

                            distance[i, j] = distance[i, k] + distance[k, j];
                            Smatrix[i, j] = k + 1;
                            
                        }
                        else
                            continue;
                    }
                }


                Console.WriteLine("Iteration {0}",k+1);
                Console.WriteLine("=========================");
                Console.WriteLine("\nThe D matrix");
                outPutArray(distance);
                Console.WriteLine();
                Console.WriteLine("\nThe s Matrix");
                Console.WriteLine();
                outPutArray(Smatrix);
              
            }


            
            Console.ReadLine();

           

        }

        ///To create the S matrix for floyd
        public int[,]createS(int[,]old)
        {
          
            int[,] sArray = new int[old.GetLength(0), old.GetLength(1)];

            for (int row = 0; row < sArray.GetLength(0); row++)
            {
                int counter = 1;
                for (int column = 0; column < sArray.GetLength(1); column++)
                {
                    if (row == column)
                        sArray[row, column] = 0;
                    else
                    {
                        sArray[row, column] = counter;

                    }
                    counter++;

                }

            }

            return sArray;
        }



        //To print out any n by n matrix
        public void outPutArray(int[,]nodes)
        {
            for (int row = 0; row < nodes.GetLength(0); row++)
            {
                for (int column = 0; column < nodes.GetLength(1); column++)
                {

                    if (column <= nodes.GetLength(0) - 1)
                    {
                        Console.Write("   {0}   ", nodes[row, column]);
                    }


                }
                Console.WriteLine();


            }
        }




    }
}
