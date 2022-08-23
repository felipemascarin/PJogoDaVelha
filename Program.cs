using System;
using System.Threading;

namespace PJogoDaVelha
{
    internal class Program
    {
        //Inicio / Reinicio
        static void Inicio(ConsoleKey jogador, int cursorlados, int cursoraltura, int jogada, string[,] matrizxo)
        {
            jogada = 0;
            jogador = ConsoleKey.X;
            cursorlados = 0;
            cursoraltura = 0;
            Console.CursorVisible = true;

            for (int col = 0; col < 5; col = col + 2)
            {
                matrizxo[2, col] = " ";
            }
            for (int col = 0; col < 5; col = col + 2)
            {
                matrizxo[0, col] = "_";
                matrizxo[1, col] = "_";
            }
            for (int col = 1; col < 4; col = col + 2)
            {
                matrizxo[0, col] = "|";
                matrizxo[1, col] = "|";
                matrizxo[2, col] = "|";
            }
            ImprimeInicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
        }

        //Atualiza a tela inicial do jogo
        static void ImprimeInicio(ConsoleKey jogador, int cursorlados, int cursoraltura, int jogada, string[,] matrizxo)
        {
            Imprime(jogador, cursorlados, cursoraltura, matrizxo);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(matrizxo[0, 0] + matrizxo[0, 1] + matrizxo[0, 2] + matrizxo[0, 3] + matrizxo[0, 4]);
            Console.SetCursorPosition(0, 1);
            Console.Write(matrizxo[1, 0] + matrizxo[1, 1] + matrizxo[1, 2] + matrizxo[1, 3] + matrizxo[1, 4]);
            Console.SetCursorPosition(0, 2);
            Console.Write(matrizxo[2, 0] + matrizxo[2, 1] + matrizxo[2, 2] + matrizxo[2, 3] + matrizxo[2, 4]);
            Console.SetCursorPosition(0, 4);
            Console.Write("É a vez do jogador " + jogador);
            Console.SetCursorPosition(cursoraltura, cursorlados);
            Jogo(jogador, cursorlados, cursoraltura, jogada, matrizxo);
        }

        //Mostra a matriz na tela / Atualiza a tela
        static void Imprime(ConsoleKey jogador, int cursorlados, int cursoraltura, string[,] matrizxo)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(matrizxo[0, 0] + matrizxo[0, 1] + matrizxo[0, 2] + matrizxo[0, 3] + matrizxo[0, 4]);
            Console.SetCursorPosition(0, 1);
            Console.Write(matrizxo[1, 0] + matrizxo[1, 1] + matrizxo[1, 2] + matrizxo[1, 3] + matrizxo[1, 4]);
            Console.SetCursorPosition(0, 2);
            Console.Write(matrizxo[2, 0] + matrizxo[2, 1] + matrizxo[2, 2] + matrizxo[2, 3] + matrizxo[2, 4]);
            Console.SetCursorPosition(0, 4);
            Console.Write("É a vez do jogador " + jogador);
            Console.SetCursorPosition(cursorlados, cursoraltura);
        }

        //Mostra Mensagem de vitória
        static void ImprimeVitoria(string[,] matrizxo, int linha, int coluna)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Vitória do jogador " + matrizxo[linha, coluna] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Pressione qualquer tecla para recomeçar.");
            Console.ReadKey();
            Thread.Sleep(1500);
        }
       
        //Mostra Mensagem de empate
        static void ImprimeEmpate()
        {            
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Deu velha!! Empate!!" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Pressione qualquer tecla para recomeçar.");
            Console.ReadKey();
            Thread.Sleep(1500);
        }

        //Verifica se o jogo acabou e recomeça
        static void VerificaVitoria(ConsoleKey jogador, int cursorlados, int cursoraltura, int jogada, string[,] matrizxo)
        {
            if ((matrizxo[0, 0] == matrizxo[0, 2] && matrizxo[0, 0] == matrizxo[0, 4]) && (matrizxo[0, 0] != "_"))
            {
                ImprimeVitoria(matrizxo, 0, 0);
                Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
            }
            else
            {
                if ((matrizxo[0, 0] == matrizxo[1, 0] && matrizxo[0, 0] == matrizxo[2, 0]) && (matrizxo[0, 0] != "_"))
                {
                    ImprimeVitoria(matrizxo, 0, 0);
                    Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                }
                else
                {
                    if ((matrizxo[1, 0] == matrizxo[1, 2] && matrizxo[1, 0] == matrizxo[1, 4]) && (matrizxo[1, 0] != "_"))
                    {
                        ImprimeVitoria(matrizxo, 1, 0);
                        Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                    }
                    else
                    {
                        if ((matrizxo[2, 0] == matrizxo[2, 2] && matrizxo[2, 0] == matrizxo[2, 4]) && (matrizxo[2, 0] != "_") && (matrizxo[2, 0] != " "))
                        {
                            ImprimeVitoria(matrizxo, 2, 0);
                            Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                        }
                        else
                        {
                            if ((matrizxo[0, 2] == matrizxo[1, 2] && matrizxo[0, 2] == matrizxo[2, 2]) && (matrizxo[0, 2] != "_"))
                            {
                                ImprimeVitoria(matrizxo, 0, 2);
                                Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                            }
                            else
                            {
                                if ((matrizxo[0, 4] == matrizxo[1, 4] && matrizxo[0, 4] == matrizxo[2, 4]) && (matrizxo[0, 4] != "_"))
                                {
                                    ImprimeVitoria(matrizxo, 0, 4);
                                    Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                                }
                                else
                                {
                                    if ((matrizxo[0, 0] == matrizxo[1, 2] && matrizxo[0, 0] == matrizxo[2, 4]) && (matrizxo[0, 0] != "_"))
                                    {
                                        ImprimeVitoria(matrizxo, 0, 0);
                                        Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                                    }
                                    else
                                    {
                                        if ((matrizxo[0, 4] == matrizxo[1, 2] && matrizxo[0, 4] == matrizxo[2, 0]) && (matrizxo[0, 4] != "_"))
                                        {
                                            ImprimeVitoria(matrizxo, 0, 4);
                                            Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                                        }
                                        else
                                        {
                                            if (jogada == 9)
                                            {
                                                ImprimeEmpate();
                                                Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //Alterna coordenadas no Console e le entradas de letras
        static void Jogo(ConsoleKey jogador, int cursorlados, int cursoraltura, int jogada, string[,] matrizxo)
        {
            ConsoleKeyInfo letra;
            string letraa;
            do
            {
                letra = Console.ReadKey(true);
                letraa = letra.Key.ToString().ToUpper();

                if (cursorlados >= 0 && cursoraltura >= 0)
                {
                    //if (letra.Key == ConsoleKey.RightArrow && cursorlados < 4)
                    if (letraa.Equals("RIGHTARROW") && cursorlados < 4)
                    {
                        cursorlados = cursorlados + 2;
                        Console.SetCursorPosition(cursorlados, cursoraltura); 
                    }
                    else
                    {
                        if (letraa.Equals("LEFTARROW") && cursorlados > 0)
                        {
                            cursorlados = cursorlados - 2;
                            Console.SetCursorPosition(cursorlados, cursoraltura);
                        }
                        else
                        {

                            if (letraa.Equals("UPARROW") && cursoraltura > 0)
                            {
                                cursoraltura--;
                                Console.SetCursorPosition(cursorlados, cursoraltura);
                            }
                            else
                            {

                                if (letraa.Equals("DOWNARROW") && cursoraltura < 2)
                                {
                                    cursoraltura++;
                                    Console.SetCursorPosition(cursorlados, cursoraltura);
                                }
                                else
                                {
                                    //Jogada do jogador X:
                                    if (letraa.Equals("X"))
                                    {
                                        Imprime(jogador, cursorlados, cursoraltura, matrizxo);
                                        if (matrizxo[cursoraltura, cursorlados] == "X" || matrizxo[cursoraltura, cursorlados] == "O")
                                        {
                                            Imprime(jogador, cursorlados, cursoraltura, matrizxo);
                                        }
                                        else
                                        {
                                            if (jogador == ConsoleKey.X)
                                            {
                                                Console.Beep();
                                                matrizxo[cursoraltura, cursorlados] = "X";
                                                jogada++;
                                                jogador = ConsoleKey.O;
                                                Imprime(jogador, cursorlados, cursoraltura, matrizxo);
                                                VerificaVitoria(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                                            }
                                        }
                                    }
                                    else

                                    {

                                        //Jogada do jogador O:                                   
                                        if (letraa == "O")
                                        {
                                            Imprime(jogador, cursorlados, cursoraltura, matrizxo);
                                            if (matrizxo[cursoraltura, cursorlados] == "X" || matrizxo[cursoraltura, cursorlados] == "O")
                                            {
                                                Imprime(jogador, cursorlados, cursoraltura, matrizxo);
                                            }
                                            else
                                            {
                                                if (jogador == ConsoleKey.O)
                                                {
                                                    Console.Beep();
                                                    matrizxo[cursoraltura, cursorlados] = "O";
                                                    jogada++;
                                                    jogador = ConsoleKey.X;
                                                    Imprime(jogador, cursorlados, cursoraltura, matrizxo);
                                                    
                                                    VerificaVitoria(jogador, cursorlados, cursoraltura, jogada, matrizxo);
                                                }
                                            }
                                        }
                                        //Se digitar qualquer letra:
                                        else
                                        {
                                            //Detecta as setas e não deixa as setas mudarem de casas para fora do jogo:
                                            if (letra.Key == ConsoleKey.RightArrow || letra.Key == ConsoleKey.LeftArrow || letra.Key == ConsoleKey.UpArrow || letra.Key == ConsoleKey.DownArrow) { }
                                            else
                                            {
                                                Imprime(jogador, cursorlados, cursoraltura, matrizxo);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }         
            } while (true);
        }

        static void Main(string[] args)
        {
            ConsoleKey jogador = ConsoleKey.O;
            int cursorlados = 0;
            int cursoraltura = 0;
            int jogada = 0;
            string[,] matrizxo = new string[3, 5];
            //Console.CursorSize = 50;

            Inicio(jogador, cursorlados, cursoraltura, jogada, matrizxo);

            //_________________________//_______________________________//


        }
    }
}



