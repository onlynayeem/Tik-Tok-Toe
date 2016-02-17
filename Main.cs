using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class board
    {
        char[,] gameBoard = new char[3, 3];

        public board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = ' ';
                }
            }

        }

        public void printBoard()
        {
            Console.WriteLine(" A B C\n");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|" + gameBoard[i, j]);
                }
                Console.Write("|\n\n");
            }

        }
        public int castMove(String column)
        {
            if (column == "A")
            {
                return 0;
            }
            else if (column == "B")
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }

        public bool submitMove(string move, char player)
        {

            int column = this.castMove(move.Substring(0, 1));
            int row = int.Parse(move.Substring(1, 1)) - 1;




            if (gameBoard[row, column] == ' ')
            {
                gameBoard[row, column] = player;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isWinner(char player)
        {

            if (gameBoard[0, 0] == player && gameBoard[0, 1] == player && gameBoard[0, 2] == player)
            {
                return true;
            }
            if (gameBoard[1, 0] == player && gameBoard[1, 1] == player && gameBoard[1, 2] == player)
            {
                return true;
            }
            if (gameBoard[2, 0] == player && gameBoard[2, 1] == player && gameBoard[2, 2] == player)
            {
                return true;
            }
            if (gameBoard[0, 0] == player && gameBoard[1, 0] == player && gameBoard[2, 0] == player)
            {
                return true;
            }
            if (gameBoard[0, 1] == player && gameBoard[1, 1] == player && gameBoard[2, 1] == player)
            {
                return true;
            }
            if (gameBoard[0, 2] == player && gameBoard[1, 2] == player && gameBoard[2, 2] == player)
            {
                return true;
            }
            if (gameBoard[0, 0] == player && gameBoard[1, 1] == player && gameBoard[2, 2] == player)
            {
                return true;
            }
            if (gameBoard[0, 2] == player && gameBoard[1, 1] == player && gameBoard[2, 0] == player)
            {
                return true;
            }
            return false;
        }
        public bool isTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool isMoveValid(string move)
        {
            if (!(move.Length == 2))
            {
                return false;
            }
            string check1 = move.Substring(0, 1);
            string check2 = move.Substring(1, 1);
            if ((check1 == "A" || check1 == "B" || check1 == "C") && (check2 == "1" || check2 == "2" || check2 == "3") && move.Length == 2)
            {
                return true;
            }
            return false;

        }

        public char[,] getBoard()
        {
            return gameBoard;
        }



    }

    class player
    {
        char marker;
        bool isHuman;
        string currentMove = null;
        bool firstMove = true,secondMove=true;
        String storeFirstMove = "";
        String storeSecondMove = "";
        String storefirstMoveIndex = "";
        String storeCompFirstMove = "";
        public player()
        {
            this.marker = 'X';
            this.isHuman = true;
        }
        public player(bool inIsHuman)
        {
            if (inIsHuman)
            {
                this.marker = 'X';
                this.isHuman = inIsHuman;
            }
            else
            {
                this.marker = 'O';
                this.isHuman = inIsHuman;
            }
        }

        public char getMarker()
        {
            return this.marker;
        }

        public bool getIsHuman()
        {
            return isHuman;
        }

        public string getPlayerMove(char[,] checkBoard)
        {
            if (this.isHuman)
            {
                return this.getHumanMove();
            }
            else
            {
                return this.generateComputerMove(checkBoard);
            }
            //return this.currentMove;
        }
        public int castMove(String column)
        {
            if (column == "A")
            {
                return 0;
            }
            else if (column == "B")
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }
        public string getHumanMove()
        {
            board check = new board();
        start:
            Console.Write("Player move (" + this.marker + ") : ");
            this.currentMove = Console.ReadLine();
            Console.WriteLine("");
            

            if (check.isMoveValid(this.currentMove))
            {
                
                return this.currentMove;
            }
            else
            {
                Console.WriteLine("Invalid Input: Please enter the column and row of your move (Example: A1).");
                goto start;
            }

        }
        public string casting(int column, int row)
        {
            if (column == 0)
            {
                return "A" + (row + 1);
            }
            else if (column == 1)
            {
                return "B" + (row + 1);
            }
            else
            {
                return "C" + (row + 1);
            }
        }

        public bool isFirstMove(char[,] checkBoard)
        {
            if (firstMove)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (checkBoard[i, j] != ' ')
                        {
                            if(i==1 && j==1)
                            {
                                this.storeFirstMove = "Middle";
                                this.storefirstMoveIndex = this.casting(j,i);
                            }
                            else if((i+j)%2==1)
                            {
                                this.storeFirstMove = "Side";
                                this.storefirstMoveIndex = this.casting(j, i);
                            }
                            else{
                                this.storeFirstMove = "Corner";
                                this.storefirstMoveIndex = this.casting(j, i);
                            }
                        }
                    }
                }
            }
            if (firstMove == false && secondMove == true)
            {
                secondMove = false;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (checkBoard[i, j] != ' ' && this.casting(j,i)!=storefirstMoveIndex && this.casting(j,i)!=storeCompFirstMove)
                        {
                            if (i == 1 && j == 1)
                            {
                                this.storeSecondMove = "Middle";
                               

                            }
                            else if ((i + j) % 2 == 1)
                            {
                                this.storeSecondMove = "Side";
                                
                            }
                            else
                            {
                                this.storeSecondMove = "Corner";
                               
                            }
                        }
                    }
                }

            }
            if ((checkBoard[1, 1] == ' '))
            {
                this.currentMove = this.casting(1, 1);

            }
            else if (firstMove)
            {

                
                Random r = new Random();
            start:
                int row = r.Next(3);
                int column = r.Next(3);
                if (row == 1 || column == 1)
                {
                    goto start;
                }

                this.currentMove = this.casting(column, row);

            }

            return this.firstMove;
        }

        public bool isWinOrBlock(char[,] checkBoard, String WinOrBlock)
        {


            String checkRowLine = "", checkColumnLine = "", checkDiagonalLine1 = "", checkDiagonalLine2 = "";
            String tempRowIndex = null, tempColumnIndex = null, tempDiagonalIndex1 = null, tempDiagonalIndex2 = null;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (checkBoard[i, j] == 'X' || checkBoard[i, j] == 'O')
                    {
                        checkRowLine = checkRowLine + checkBoard[i, j];
                    }
                    if (checkBoard[j, i] == 'X' || checkBoard[j, i] == 'O')
                    {
                        checkColumnLine = checkColumnLine + checkBoard[j, i];
                    }

                    if (checkBoard[i, j] == ' ')
                    {
                        tempRowIndex = this.casting(j, i);
                    }
                    if (checkBoard[j, i] == ' ')
                    {
                        tempColumnIndex = this.casting(i, j);
                    }

                    if (i == j)
                    {
                        if (checkBoard[i, j] == 'X' || checkBoard[i, j] == 'O')
                        {
                            checkDiagonalLine1 = checkDiagonalLine1 + checkBoard[i, j];
                        }

                        if (checkBoard[i, j] == ' ')
                        {
                            tempDiagonalIndex1 = this.casting(j, i);
                        }
                    }

                    if (i + j == 2)
                    {
                        if (checkBoard[i, j] == 'X' || checkBoard[i, j] == 'O')
                        {
                            checkDiagonalLine2 = checkDiagonalLine2 + checkBoard[i, j];
                        }

                        if (checkBoard[i, j] == ' ')
                        {
                            tempDiagonalIndex2 = this.casting(j, i);
                        }
                    }
                }
                if (checkRowLine == WinOrBlock)
                {
                    this.currentMove = tempRowIndex;
                    return true;
                }
                if (checkColumnLine == WinOrBlock)
                {
                    this.currentMove = tempColumnIndex;
                    return true;
                }
                checkRowLine = "";
                checkColumnLine = "";
            }

            if (checkDiagonalLine1 == WinOrBlock)
            {
                this.currentMove = tempDiagonalIndex1;
                return true;
            }
            if (checkDiagonalLine2 == WinOrBlock)
            {
                this.currentMove = tempDiagonalIndex2;
                return true;
            }

            return false;
        }

        public void freeMove(char[,] checkBoard)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (checkBoard[i, j] == ' ')
                    {
                        if (storeFirstMove == "Middle" || storeFirstMove == "Side" || (storeFirstMove == "Corner" && storeSecondMove == "Side"))
                        {
                            if ((i == 0 || i == 2) && (j == 0 || j == 2))
                            {
                                this.currentMove = this.casting(j, i);

                                break;
                            }

                        }

                        else if (storeFirstMove == "Corner")
                        {
                            if ((i + j) % 2 == 1)
                            {
                                this.currentMove = this.casting(j, i);

                                break;
                            }
                        }


                    }
                }
            }

        }

        public string generateComputerMove(char[,] checkBoard)
        {
            
            if (this.isFirstMove(checkBoard))
            {
                if (secondMove) { this.storeCompFirstMove = this.currentMove;}
                
                this.firstMove = false;
                return this.currentMove;
                
            }
                
            else if (this.isWinOrBlock(checkBoard, "OO"))
            {
                if (secondMove) { this.storeCompFirstMove = this.currentMove; }
                return this.currentMove;
            }
            else if (this.isWinOrBlock(checkBoard, "XX"))
            {
                if (secondMove) { this.storeCompFirstMove = this.currentMove; }
                return this.currentMove;
            }
            else
            {
                if (secondMove) { this.storeCompFirstMove = this.currentMove; }
                this.freeMove(checkBoard);
                return this.currentMove;
            }

        }


    }

    class Program
    {

        static void Main(string[] args)
        {
            board b = new board();
            player human = new player();
            player comp = new player(false);

            Console.WriteLine("************************* ");
            Console.WriteLine("	Welcome to my Tic-Tac-Toe!");
            Console.WriteLine("*************************");
            Console.WriteLine("Please enter the column and then row of your move(Example : A1,B2,C3)");
            b.printBoard();

            while (true)
            {
                //human player move ;
                while (true)
                {

                    string move = human.getPlayerMove(b.getBoard());
                    if (b.isMoveValid(move) == true)
                    {
                        if (b.submitMove(move, 'X'))
                        {
                            b.printBoard();
                            break;
                        }
                        Console.WriteLine("The space entered is already taken.");

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input: Please enter the column and row of your move (Example: A1).");
                    }

                }

                if (b.isWinner('X'))
                {
                    Console.WriteLine("You win !!");
                    break;
                }
                else if (b.isTie())
                {
                    Console.WriteLine("Gome Over ,Draw");
                    break;
                }



                //computer move 
                Console.Write("Player Move (O): ");
                while (true)
                {
                    string move = comp.getPlayerMove(b.getBoard());
                    if (b.isMoveValid(move))
                    {
                        if (b.submitMove(move, 'O'))
                        {
                            Console.WriteLine("{0}", move.ToString());
                            b.printBoard();
                            break;
                        }
                    }
                }

                if (b.isWinner('O'))
                {
                    Console.WriteLine("You Lose!!");
                    break;
                }



            }

        }
    }
}
