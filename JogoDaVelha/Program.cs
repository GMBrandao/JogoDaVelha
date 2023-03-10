char[,] board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };


int input, move = 1;
bool play;
char player;

Console.WriteLine("\t\t\tJOGO DA VELHA\nPara jogar digite o número da casa que você deseja preencher.");
Console.WriteLine("Vence o jogador que conseguir formar primeiro uma linha com três símbolos iguais,\n" +
    "seja ela na horizontal, vertical ou diagonal.\n");

do
{
    if(move != 1)
    {
        Console.Clear();
    }
    PrintBoard();
    play = true;

    while (play)
    {
        if(move % 2 == 0)
        {
            player = 'O';
        }
        else
        {
            player = 'X';
        }

        Console.WriteLine("Vez do jogador " + player + "\nDigite o número da posição que deseja jogar: ");

        if (int.TryParse(Console.ReadLine(), out input))
        {
            if (input > 0 && input < 10)
            {
                play = ChoosePosition(input, move);
            }
            else
            {
                Console.WriteLine(input);
                Console.WriteLine("A posição deve estar entre 1 e 9\n");
            }
        }
        else
        {
            Console.WriteLine("Por favor digite uma posição válida\n");

        }
    }

    move++;

    if (move > 5)
    {
        move += VerifyVictory();
    }

} while (move < 10);

if (move == 10)
{   
    Console.Clear();
    PrintBoard();
    Console.WriteLine("Deu velha\nNinguém ganhou");
    Console.WriteLine("\nPressione qualquer tecla para encerrar...");
    Console.ReadKey();
}

bool Winner(int sumX, int sumO)
{
    if (sumX == 3)
    {
        Console.Clear();
        PrintBoard();
        Console.WriteLine("Jogador X venceu a partida");
        Console.WriteLine("\nPressione qualquer tecla para encerrar...");
        Console.ReadKey();
        return true;
    }
    else if (sumO == 3)
    {
        Console.Clear();
        PrintBoard();
        Console.WriteLine("Jogador O venceu a partida");
        Console.WriteLine("\nPressione qualquer tecla para encerrar...");
        Console.ReadKey();
        return true;
    }
    return false;
}

int VerifyVictory()
{
    int sumX = 0, sumO = 0;

    //diagonal principal
    for (int i = 0; i < 3; i++)
    {
        if (board[i, i] == 'X')
        {
            sumX++;
        }
        else if (board[i, i] == 'O')
        {
            sumO++;
        }
    }
    if (Winner(sumX, sumO))
        return 10;
    else
    {
        sumX = 0;
        sumO = 0;
    }

    //diagonal secundaria
    for (int i = 0; i < 3; i++)
    {
        if (board[i, 2-i] == 'X')
        {
            sumX++;
        }
        else if (board[i, 2 - i] == 'O') 
        { 
            sumO++;
        }
    }
    if (Winner(sumX, sumO))
        return 10;
    else
    {
        sumX = 0;
        sumO = 0;
    }

    //verificaLinha
    for (int line = 0; line < 3; line++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (board[line, col] == 'X')
            {
                sumX++;
            }
            else if (board[line, col] == 'O')
            {
                sumO++;
            }
        }
        if (Winner(sumX, sumO))
            return 10;
        else
        {
            sumX = 0;
            sumO = 0;
        }
    }

    //verificaColuna
    for (int col = 0; col < 3; col++)
    {
        for (int line = 0; line < 3; line++)
        {
            if (board[line, col] == 'X')
            {
                sumX++;
            }
            else if (board[line, col] == 'O')
            {
                sumO++;
            }
        }
        if (Winner(sumX, sumO))
            return 10;
        else
        {
            sumX = 0;
            sumO = 0;
        }
    }
    return 0;
}

bool ChoosePosition(int input, int move)
{
    int pos = 1;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (input == pos)
            {
                if (board[i,j] != 'X' && board[i, j] != 'O')
                {
                    if(move % 2 == 0)
                    {
                        board[i,j] = 'O';
                    }
                    else
                    {
                        board[i,j] = 'X';

                    }
                return false;
                }
            }
            pos++;
        }
    }
    Console.WriteLine("Jogada inválida, insira outra posição\n");
    return true;
}

void PrintBoard()
{
    for (int i = 0; i < 3; i++)
    {
        BlankLine();
        for (int j = 0; j < 3; j++)
        {
            Console.Write("  " + board[i, j] + "  ");
            if (j < 2)
                Console.Write("|");
        }
        Console.WriteLine();
        if (i < 2)
            FillLine();
    }
    BlankLine();
    Console.WriteLine();
}

void BlankLine()
{
    int pipe = 0;
    for (int i = 0; i < 15; i++)
    {
        Console.Write(' ');
        pipe++;
        if (pipe == 5 || pipe == 10)
            Console.Write('|');
    }
    Console.WriteLine();
}

void FillLine()
{
    int pipe = 0;
    for (int i = 0; i < 15; i++)
    {
        Console.Write('_');
        pipe++;
        if (pipe == 5 || pipe == 10)
            Console.Write('|');
    }
    Console.WriteLine();
}