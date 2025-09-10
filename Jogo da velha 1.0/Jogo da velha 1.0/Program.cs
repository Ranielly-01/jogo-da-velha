
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        string[,] tabuleiro = new string[3, 3];
        int posicaoLinha = 0, posicaoColuna = 0, qtddJogadas = 1;
        char jogadorDaVez = 'X';
        bool deuCerto = false;
        bool houveGanhador = false;
        int jogarNovamente = 0;
        int placarX = 0, placarO = 0;
        int jogadores = 1;
        bool maquinaVez = false;

        Console.WriteLine("Bem-vindo ao jogo da velha!");
        Console.WriteLine("com qunatos jogadores voce quer jogar? (1 ou 2)");
        jogadores = int.Parse(Console.ReadLine());


        if (jogadores == 2)
        {
            Console.WriteLine("jogo para 2 jogadores selecionado.");
            do
            {
                limparTabuleiro(ref tabuleiro);

                MostrarTabuleiroVazio();

                DefinirSimbolo(ref jogadorDaVez);

                do
                {
                    EscolherPosicao(ref jogadorDaVez, ref deuCerto, ref posicaoLinha, ref posicaoColuna, ref tabuleiro, ref qtddJogadas, ref maquinaVez);

                    MostrarTabuleiroPreenchido(tabuleiro);

                    verificaGanhador(ref tabuleiro, ref houveGanhador, ref placarX, ref placarO, ref qtddJogadas);


                    if (houveGanhador == true)
                    {
                        houveGanhador = false;
                        break;
                    }


                } while (qtddJogadas <= 9);

                qtddJogadas = 1;


                Console.WriteLine("Placar do jogador X: " + placarX);
                Console.WriteLine("Placar do jogador O: " + placarO);

                Console.WriteLine("Deseja jogar novamente? Digite 0 para não ou 1 para sim.");
                jogarNovamente = int.Parse(Console.ReadLine());




            } while (houveGanhador == false || jogarNovamente == 1);

        }

        else
        {
            Console.WriteLine("jogo para 1 jogador selecionado.");
            Console.WriteLine("voce jogara com a maquina.");


            DefinirSimbolo(ref jogadorDaVez);

            limparTabuleiro(ref tabuleiro);


            do
            {
                if (maquinaVez == true)
                {
                    bool maquinaPrencheu = false;

                    do
                    {
                        Random random = new Random();
                        int linha = random.Next(0, 3);
                        int coluna = random.Next(0, 3);

                        if (tabuleiro[linha, coluna] == " ")
                        {
                            tabuleiro[linha, coluna] = jogadorDaVez.ToString();
                            qtddJogadas++;
                            maquinaPrencheu = true;

                            if (jogadorDaVez == 'X')
                            {
                                jogadorDaVez = 'O';
                            }
                            else
                            {
                                jogadorDaVez = 'X';
                            }
                            maquinaVez = false;
                        }


                    } while (maquinaPrencheu == false);

                }
                else
                {
                    EscolherPosicao(ref jogadorDaVez, ref deuCerto, ref posicaoLinha, ref posicaoColuna, ref tabuleiro, ref qtddJogadas, ref maquinaVez);


                }

                verificaGanhador(ref tabuleiro, ref houveGanhador, ref placarX, ref placarO, ref qtddJogadas);
                if (houveGanhador == true)
                {
                    break;
                }
                MostrarTabuleiroPreenchido(tabuleiro);

            } while (qtddJogadas <= 9);

        }
    }

    private static void MostrarTabuleiroVazio()
    {
        Console.WriteLine("    |  |  ");
        Console.WriteLine(" ---+--+--- ");
        Console.WriteLine("    |  |  ");
        Console.WriteLine(" ---+--+--- ");
        Console.WriteLine("    |  |  ");

    }

    private static void limparTabuleiro(ref string[,] tabuleiro)
    {
        tabuleiro[0, 0] = " ";
        tabuleiro[0, 1] = " ";
        tabuleiro[0, 2] = " ";
        tabuleiro[1, 0] = " ";
        tabuleiro[1, 1] = " ";
        tabuleiro[1, 2] = " ";
        tabuleiro[2, 0] = " ";
        tabuleiro[2, 1] = " ";
        tabuleiro[2, 2] = " ";
    }

    private static void DefinirSimbolo(ref char jogadorDaVez)
    {
        do
        {
            Console.WriteLine("Quem começa? Digite 'X' ou 'O' ");
            jogadorDaVez = char.Parse(Console.ReadLine());
            if (jogadorDaVez != 'X' && jogadorDaVez != 'O')
            {
                Console.WriteLine("Jogador inválido! Tente novamente.");
                jogadorDaVez = char.Parse(Console.ReadLine());
            }
        } while (jogadorDaVez != 'X' && jogadorDaVez != 'O');
    }

    private static void EscolherPosicao(ref char jogadorDaVez, ref bool deuCerto, ref int posicaoLinha, ref int posicaoColuna, ref string[,] tabuleiro, ref int qtddJogadas, ref bool maquinaVez)
    {
        do
        {
            Console.WriteLine("Jogador {0}, escolha a linha: ", jogadorDaVez);
            deuCerto = int.TryParse(Console.ReadLine(), out posicaoLinha);
            if (deuCerto == true)
            {
                posicaoLinha--;
            }
            else
            {
                Console.WriteLine("Escreva um número! Tente novamente.");
            }
        } while (deuCerto == false);


        do
        {
            Console.WriteLine("Jogador, escolha a coluna: ");
            deuCerto = int.TryParse(Console.ReadLine(), out posicaoColuna);
            if (deuCerto == true)
            {
                posicaoColuna--;
            }
            else
            {
                Console.WriteLine("Escreva um número! Tente novamente.");
            }
        } while (deuCerto == false);

        if (posicaoLinha >= 3 || posicaoColuna >= 3 || posicaoLinha < 0 || posicaoColuna < 0)
        {

            Console.WriteLine("Posição inválida! Tente novamente.");
        }
        else
        {


            if (tabuleiro[posicaoLinha, posicaoColuna] == " ")
            {

                tabuleiro[posicaoLinha, posicaoColuna] = jogadorDaVez.ToString();
                if (jogadorDaVez == 'X')
                {
                    jogadorDaVez = 'O';
                }
                else
                {
                    jogadorDaVez = 'X';
                }

                qtddJogadas++;

                maquinaVez = true;




            }
            else
            {
                Console.WriteLine("Posição já ocupada! Tente novamente.");
            }
        }
    }
    private static void verificaGanhador(ref string[,] tabuleiro, ref bool houveGanhador, ref int placarX, ref int placarO, ref int qtddJogadas)
    {
        if ((tabuleiro[0, 0] == "X" && tabuleiro[0, 1] == "X" && tabuleiro[0, 2] == "X") ||
                        (tabuleiro[1, 0] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[1, 2] == "X") ||
                        (tabuleiro[2, 0] == "X" && tabuleiro[2, 1] == "X" && tabuleiro[2, 2] == "X") ||
                        (tabuleiro[0, 0] == "X" && tabuleiro[1, 0] == "X" && tabuleiro[2, 0] == "X") ||
                        (tabuleiro[0, 1] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 1] == "X") ||
                        (tabuleiro[0, 2] == "X" && tabuleiro[1, 2] == "X" && tabuleiro[2, 2] == "X") ||
                        (tabuleiro[0, 0] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 2] == "X") ||
                        (tabuleiro[0, 2] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 0] == "X"))
        {
            Console.WriteLine("Jogador X venceu!");
            houveGanhador = true;

            placarX++;

        }
        else if ((tabuleiro[0, 0] == "O" && tabuleiro[0, 1] == "O" && tabuleiro[0, 2] == "O") ||
                 (tabuleiro[2, 0] == "O" && tabuleiro[2, 1] == "O" && tabuleiro[2, 2] == "O") ||
                 (tabuleiro[0, 0] == "O" && tabuleiro[1, 0] == "O" && tabuleiro[2, 0] == "O") ||
                 (tabuleiro[0, 1] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 1] == "O") ||
                 (tabuleiro[0, 2] == "O" && tabuleiro[1, 2] == "O" && tabuleiro[2, 2] == "O") ||
                 (tabuleiro[0, 0] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 2] == "O") ||
                 (tabuleiro[1, 0] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[1, 2] == "O") ||
                 (tabuleiro[0, 2] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 0] == "O"))
        {
            Console.WriteLine("Jogador O venceu!");
            houveGanhador = true;
            placarO++;

        }
        else if (qtddJogadas == 10)
        {
            houveGanhador = false;
            Console.WriteLine("Deu velha!");
        }


    }


    private static void MostarPlacar(int placarX, int placarO)
    {
        Console.WriteLine("Placar do jogador X: " + placarX);
        Console.WriteLine("Placar do jogador O: " + placarO);
    }

    private static void MostrarTabuleiroPreenchido(string[,] tabuleiro)
    {
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[0, 0], tabuleiro[0, 1], tabuleiro[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[1, 0], tabuleiro[1, 1], tabuleiro[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[2, 0], tabuleiro[2, 1], tabuleiro[2, 2]);
    }
}



