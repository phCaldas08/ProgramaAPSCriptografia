using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa_APS.Classes
{
    class CriptografiaMatriz
    {
                int[,] matrizInversivel = new int[3, 3];
        int[,] matrizInversivelInversa = new int[3, 3];

        int[] palavraNumerica = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 , 0, 0, 0, 0};
        int[] palavraNumericaCrip = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] parte1 = {32,32,32};
        int[] parte2 = {32,32,32};
        int[] parte3 = {32,32,32};
        int[] parte4 = {32,32,32};
        int[] parte5 = {32,32,32};
        int[] parte6 = {32,32,32};
        int[] parte7 = {32,32,32};
        int[] parte8 = {32,32,32};
        int[] parte9 = {32,32,32};

        int[] parte1Encrip = new int[3];
        int[] parte2Encrip = new int[3];
        int[] parte3Encrip = new int[3];
        int[] parte4Encrip = new int[3];
        int[] parte5Encrip = new int[3];
        int[] parte6Encrip = new int[3];
        int[] parte7Encrip = new int[3];
        int[] parte8Encrip = new int[3];
        int[] parte9Encrip = new int[3];

        
        private void ValorMatriz()
        {
            //definir valores da matriz que será nossa chave
            matrizInversivel[0, 0] = 1;
            matrizInversivel[1, 0] = 1;
            matrizInversivel[2, 0] = 0;
            matrizInversivel[0, 1] = 2;
            matrizInversivel[1, 1] = 1;
            matrizInversivel[2, 1] = 1;
            matrizInversivel[0, 2] = 3;
            matrizInversivel[1, 2] = 2;
            matrizInversivel[2, 2] = 2;

            //Os valores da matriz inversa da MatrizInversivel
            matrizInversivelInversa[0, 0] =  0;
            matrizInversivelInversa[1, 0] =  2;
            matrizInversivelInversa[2, 0] = -1;
            matrizInversivelInversa[0, 1] =  1;
            matrizInversivelInversa[1, 1] = -2;
            matrizInversivelInversa[2, 1] =  1;
            matrizInversivelInversa[0, 2] = -1;
            matrizInversivelInversa[1, 2] = -1;
            matrizInversivelInversa[2, 2] =  1;
        }

        public List<List<int>> Descriptografar(List<List<int>> listEncrip)
        {
            //Multiplico os valores obtidos na primeira multiplicação na matriz inversa da MatrizInversivel
            List<List<int>> listResult = multiplicarMatrizInversa(listEncrip);

            return listResult;
        }

        public List<List<int>> Criptografar(string texto)
        {
            //Define os valores das matrizes chaves
            ValorMatriz();
            //Separa o texto em partes, cada uma com 3 componentes
            List<int[]> list = SepararTexto(texto);
            //Multiplica os valores pela MatrizInversivel 3x3
            List<List<int>> listEncrip = multiplicarMatriz(list);

            return listEncrip;
        }

        private List<List<int>> multiplicarMatrizInversa(List<List<int>> listEncrip)
        {            
            List<List<int>> listGlobal = new List<List<int>>();

            int cont = 0;
            for (int c = 0; c < 9; c++)
            {
                List<int> listTemp = new List<int>();
                for (int i = 0; i < 3; i++)
                {

                    int temp = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        //Faz a multiplicação dos vetores obtidos pela matrizinversa
                        temp += (matrizInversivelInversa[i, j] * listEncrip[c][j]);
                        //listEncrip[0][cont] += (matrizInversivel[i, j] + list[i][j]);

                    }
                    //Guarda os valores obtidos
                    listTemp.Add(temp);
                    //listEncrip;
                }
                //Guarda as matrizes obtidas
                listGlobal.Add(listTemp);
            }
            return listGlobal;
        }

        private List<List<int>> multiplicarMatriz(List<int[]> list)
        {
            List<List<int>> listGlobal = new List<List<int>>();

            int cont = 0;

            //Numero de partes divididas
            for(int c = 0; c < 9; c++)
            {
                List<int> listTemp = new List<int>();
                //numero de linhas da matriz 
                for(int i = 0; i < 3; i++)
                {                   
                    int temp = 0;
                    //numero de colunas da matriz e das partes do texto
                    for(int j = 0; j < 3; j++)
                    {
                        //Armazena o valor obtido na multiplicação EX: (A11 * B11) + (A12 * B21) + (A13 * B31) = C11 
                        temp += (matrizInversivel[i, j] * list[c][j]);
                        //listEncrip[0][cont] += (matrizInversivel[i, j] + list[i][j]);
                        
                    }
                    //Guarda os valores de cada componente da matriz
                    listTemp.Add(temp);
                    //listEncrip;
                }
                //Guarda a matriz
                listGlobal.Add(listTemp);
            }
            return listGlobal;
        }

        private List<int[]> SepararTexto(string texto)
        {

            List<int[]> list = new List<int[]>();
            list.Add(parte1);
            list.Add(parte2);
            list.Add(parte3);
            list.Add(parte4);
            list.Add(parte5);
            list.Add(parte6);
            list.Add(parte7);
            list.Add(parte8);
            list.Add(parte9);

            List<string> listTemp = new List<string>();

            
            if(texto.Length % 3 != 0)
            {
                switch (texto.Length % 3)
                {
                    case 1:
                        texto += "  ";
                        break;
                    case 2:
                        texto += " ";
                        break;
                }
            }

            int contador = 0;
            int i;

            //Separa os caracteres de três em três
            for (i = 0; i < texto.Length; i += 3)
            {
                string temp = "";
                for (int j = contador; j < contador + 3; j++)
                {
                    temp += texto[j];
                }
                listTemp.Add(temp);
                contador += 3;
            }
            
            for (int k = 0; k < listTemp.Count; k++)
            {
                for (int c = 0; c < 3; c++)
                {
                    list[k][c] = listTemp[k][c];
                }
                
            }

            return list;
        }
    }    
}
