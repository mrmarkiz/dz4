using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    internal class Task1_2
    {
        public static void Run1()
        {
            Tic_Tac_Toe game = new Tic_Tac_Toe();
            game.PlayWithComp();
        }
        public static void Run2()
        {
            Tic_Tac_Toe game = new Tic_Tac_Toe();
            game.PlayWithPerson();
        }
    }

    class Tic_Tac_Toe
    {
        private char[,] _field;

        public Tic_Tac_Toe()
        {
            this._field = new char[3, 3];
            for(int i=0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this._field[i, j] = ' ';
        }

        public void PlayWithComp()
        {
            Random rand = new Random();
            bool side;
            char person_sym, comp_sym;
            if (rand.Next(2) == 0)
            {
                side = true;
                person_sym = 'X';
                comp_sym = 'O';
            }
            else
            {
                side = false;
                person_sym = 'O';
                comp_sym = 'X';
            }
            
            while (!Have_Winner() && Have_Empty_Places())
            {
                Console.Clear();
                Show();
                if(side == true)
                {
                    PersonMove(person_sym);
                    side = false;
                }
                else
                {                    
                    CompMove(comp_sym);
                    System.Threading.Thread.Sleep(500);
                    side = true;
                }                
            }
            Console.Clear();
            Show();
            if(!Have_Winner())
                Console.WriteLine("Draw");
            else if (side)
                Console.WriteLine("You lost");
            else
                Console.WriteLine("You won!!!");
        }

        public void PlayWithPerson()
        {
            bool side = true;
            char person1_sym = 'X', person2_sym = 'O';
            
            while (!Have_Winner() && Have_Empty_Places())
            {
                Console.Clear();
                Show();
                if (side == true)
                {
                    Console.WriteLine("First person's turn");
                    PersonMove(person1_sym);
                    side = false;
                }
                else
                {
                    Console.WriteLine("Second person's turn");
                    PersonMove(person2_sym);
                    side = true;
                }
            }
            Console.Clear();
            Show();
            if (!Have_Winner())
                Console.WriteLine("Draw");
            else if (side)
                Console.WriteLine("Second person won!!!");
            else
                Console.WriteLine("Fisrt person won!!!");

        }

        private void CompMove(char sym)
        {
            if (MakeWinMove(sym))
                return;
            if (MakeBlockMove(sym))
                return;
            ChooseRandom(sym);
        }
        /*
        public void ShowWinnerComp(char person_sym, char comp_sym)
        {
            //horizontal
            if (_field[0, 0] == _field[0, 1] && _field[0, 1] == _field[0, 2])
            {
                if (_field[0,0] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }
            if (_field[1, 0] == _field[1, 1] && _field[1, 1] == _field[1, 2])
            {
                if (_field[1,0] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }
            if (_field[2, 0] == _field[2, 1] && _field[2, 1] == _field[2, 2])
            {
                if (_field[2, 0] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }

            //vertical
            if (_field[0, 0] == _field[1, 0] && _field[1, 0] == _field[2, 0])
            {
                if (_field[0, 0] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }
            if (_field[0, 1] == _field[1, 1] && _field[1, 1] == _field[2, 1])
            {
                if (_field[0, 1] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }
            if (_field[0, 2] == _field[1, 2] && _field[1, 2] == _field[2, 2])
            {
                if (_field[0, 2] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }

            //diagonal
            if (_field[0, 0] == _field[1, 1] && _field[1, 1] == _field[2, 2])
            {
                if (_field[0, 0] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }
            if (_field[0, 2] == _field[1, 1] && _field[1, 1] == _field[2, 0])
            {
                if (_field[0, 2] == person_sym)
                    Console.WriteLine("You won!!!");
                else
                    Console.WriteLine("You lost");
                return;
            }
        }

        public void ShowWinnerPerson(char person1_sym)
        {

            //horizontal
            if (_field[0, 0] == _field[0, 1] && _field[0, 1] == _field[0, 2])
            {
                if (_field[0, 0] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }
            if (_field[1, 0] == _field[1, 1] && _field[1, 1] == _field[1, 2])
            {
                if (_field[1, 0] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }
            if (_field[2, 0] == _field[2, 1] && _field[2, 1] == _field[2, 2])
            {
                if (_field[2, 0] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }

            //vertical
            if (_field[0, 0] == _field[1, 0] && _field[1, 0] == _field[2, 0])
            {
                if (_field[0, 0] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }
            if (_field[0, 1] == _field[1, 1] && _field[1, 1] == _field[2, 1])
            {
                if (_field[0, 1] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }
            if (_field[0, 2] == _field[1, 2] && _field[1, 2] == _field[2, 2])
            {
                if (_field[0, 2] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }

            //diagonal
            if (_field[0, 0] == _field[1, 1] && _field[1, 1] == _field[2, 2])
            {
                if (_field[0, 0] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }
            if (_field[0, 2] == _field[1, 1] && _field[1, 1] == _field[2, 0])
            {
                if (_field[0, 2] == person1_sym)
                    Console.WriteLine("First person won!!!");
                else
                    Console.WriteLine("Second person won!!!");
                return;
            }
        }
        */
        private void PersonMove(char sym)
        {
            int i,j;
            do
            {
                Console.Write("Choose place(for example 1-3): ");
                string[] input = Console.ReadLine().Split('-');
                int.TryParse(input[0], out i);
                int.TryParse(input[1], out j);
            } while (i < 1 || i > 3 || j < 1 || j > 3 || _field[i - 1, j - 1] != ' ');
            _field[i - 1, j - 1] = sym;
        }

        private bool MakeWinMove(char sym)
        {
            //horizontal
            if (_field[0, 0] == sym && _field[0, 1] == sym && _field[0, 2] == ' ')
            {
                _field[0, 2] = sym;
                return true;
            }
            if (_field[0, 0] == sym && _field[0, 2] == sym && _field[0, 1] == ' ')
            {
                _field[0, 1] = sym;
                return true;
            }
            if (_field[0, 2] == sym && _field[0, 1] == sym && _field[0, 0] == ' ')
            {
                _field[0, 0] = sym;
                return true;
            }

            if (_field[1, 0] == sym && _field[1, 1] == sym && _field[1, 2] == ' ')
            {
                _field[1, 2] = sym;
                return true;
            }
            if (_field[1, 0] == sym && _field[1, 2] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = sym;
                return true;
            }
            if (_field[1, 2] == sym && _field[1, 1] == sym && _field[1, 0] == ' ')
            {
                _field[1, 0] = sym;
                return true;
            }

            if (_field[2, 0] == sym && _field[2, 1] == sym && _field[2, 2] == ' ')
            {
                _field[2, 2] = sym;
                return true;
            }
            if (_field[2, 0] == sym && _field[2, 2] == sym && _field[2, 1] == ' ')
            {
                _field[2, 1] = sym;
                return true;
            }
            if (_field[2, 2] == sym && _field[2, 1] == sym && _field[2, 0] == ' ')
            {
                _field[2, 0] = sym;
                return true;
            }

            //vertical
            if (_field[0, 0] == sym && _field[1, 0] == sym && _field[2, 0] == ' ')
            {
                _field[2, 0] = sym;
                return true;
            }
            if (_field[0, 0] == sym && _field[2, 0] == sym && _field[1, 0] == ' ')
            {
                _field[1, 0] = sym;
                return true;
            }
            if (_field[2, 0] == sym && _field[1, 0] == sym && _field[0, 0] == ' ')
            {
                _field[0, 0] = sym;
                return true;
            }

            if (_field[0, 1] == sym && _field[1, 1] == sym && _field[2, 1] == ' ')
            {
                _field[2, 1] = sym;
                return true;
            }
            if (_field[0, 1] == sym && _field[2, 1] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = sym;
                return true;
            }
            if (_field[2, 1] == sym && _field[1, 1] == sym && _field[0, 1] == ' ')
            {
                _field[0, 1] = sym;
                return true;
            }

            if (_field[0, 2] == sym && _field[1, 2] == sym && _field[2, 2] == ' ')
            {
                _field[2, 2] = sym;
                return true;
            }
            if (_field[0, 2] == sym && _field[2, 2] == sym && _field[1, 2] == ' ')
            {
                _field[1, 2] = sym;
                return true;
            }
            if (_field[2, 2] == sym && _field[1, 2] == sym && _field[0, 2] == ' ')
            {
                _field[0, 2] = sym;
                return true;
            }

            //diagonal
            if (_field[0, 0] == sym && _field[1, 1] == sym && _field[2, 2] == ' ')
            {
                _field[2, 2] = sym;
                return true;
            }
            if (_field[0, 0] == sym && _field[2, 2] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = sym;
                return true;
            }
            if (_field[2, 2] == sym && _field[1, 1] == sym && _field[0, 0] == ' ')
            {
                _field[0, 0] = sym;
                return true;
            }

            if (_field[0, 2] == sym && _field[1, 1] == sym && _field[2, 0] == ' ')
            {
                _field[2, 0] = sym;
                return true;
            }
            if (_field[0, 2] == sym && _field[2, 0] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = sym;
                return true;
            }
            if (_field[2, 0] == sym && _field[1, 1] == sym && _field[0, 2] == ' ')
            {
                _field[0, 2] = sym;
                return true;
            }
            return false;
        }

        private bool MakeBlockMove(char sym)
        {
            char orig = sym;
            if (sym == 'X')
                sym = 'O';
            else
                sym = 'X';
            //horizontal
            if (_field[0, 0] == sym && _field[0, 1] == sym && _field[0, 2] == ' ')
            {
                _field[0, 2] = orig;
                return true;
            }
            if (_field[0, 0] == sym && _field[0, 2] == sym && _field[0, 1] == ' ')
            {
                _field[0, 1] = orig;
                return true;
            }
            if (_field[0, 2] == sym && _field[0, 1] == sym && _field[0, 0] == ' ')
            {
                _field[0, 0] = orig;
                return true;
            }

            if (_field[1, 0] == sym && _field[1, 1] == sym && _field[1, 2] == ' ')
            {
                _field[1, 2] = orig;
                return true;
            }
            if (_field[1, 0] == sym && _field[1, 2] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = orig;
                return true;
            }
            if (_field[1, 2] == sym && _field[1, 1] == sym && _field[1, 0] == ' ')
            {
                _field[1, 0] = orig;
                return true;
            }

            if (_field[2, 0] == sym && _field[2, 1] == sym && _field[2, 2] == ' ')
            {
                _field[2, 2] = orig;
                return true;
            }
            if (_field[2, 0] == sym && _field[2, 2] == sym && _field[2, 1] == ' ')
            {
                _field[2, 1] = orig;
                return true;
            }
            if (_field[2, 2] == sym && _field[2, 1] == sym && _field[2, 0] == ' ')
            {
                _field[2, 0] = orig;
                return true;
            }

            //vertical
            if (_field[0, 0] == sym && _field[1, 0] == sym && _field[2, 0] == ' ')
            {
                _field[2, 0] = orig;
                return true;
            }
            if (_field[0, 0] == sym && _field[2, 0] == sym && _field[1, 0] == ' ')
            {
                _field[1, 0] = orig;
                return true;
            }
            if (_field[2, 0] == sym && _field[1, 0] == sym && _field[0, 0] == ' ')
            {
                _field[0, 0] = orig;
                return true;
            }

            if (_field[0, 1] == sym && _field[1, 1] == sym && _field[2, 1] == ' ')
            {
                _field[2, 1] = orig;
                return true;
            }
            if (_field[0, 1] == sym && _field[2, 1] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = orig;
                return true;
            }
            if (_field[2, 1] == sym && _field[1, 1] == sym && _field[0, 1] == ' ')
            {
                _field[0, 1] = orig;
                return true;
            }

            if (_field[0, 2] == sym && _field[1, 2] == sym && _field[2, 2] == ' ')
            {
                _field[2, 2] = orig;
                return true;
            }
            if (_field[0, 2] == sym && _field[2, 2] == sym && _field[1, 2] == ' ')
            {
                _field[1, 2] = orig;
                return true;
            }
            if (_field[2, 2] == sym && _field[1, 2] == sym && _field[0, 2] == ' ')
            {
                _field[0, 2] = orig;
                return true;
            }

            //diagonal
            if (_field[0, 0] == sym && _field[1, 1] == sym && _field[2, 2] == ' ')
            {
                _field[2, 2] = orig;
                return true;
            }
            if (_field[0, 0] == sym && _field[2, 2] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = orig;
                return true;
            }
            if (_field[2, 2] == sym && _field[1, 1] == sym && _field[0, 0] == ' ')
            {
                _field[0, 0] = orig;
                return true;
            }

            if (_field[0, 2] == sym && _field[1, 1] == sym && _field[2, 0] == ' ')
            {
                _field[2, 0] = orig;
                return true;
            }
            if (_field[0, 2] == sym && _field[2, 0] == sym && _field[1, 1] == ' ')
            {
                _field[1, 1] = orig;
                return true;
            }
            if (_field[2, 0] == sym && _field[1, 1] == sym && _field[0, 2] == ' ')
            {
                _field[0, 2] = orig;
                return true;
            }
            return false;
        }

        private void ChooseRandom(char sym)
        {
            Random rand = new Random();
            uint i, j;
            do
            {
                i = Convert.ToUInt16(rand.Next(3));
                j = Convert.ToUInt16(rand.Next(3));
                if (_field[i, j] == ' ') 
                {
                    _field[i, j] = sym;
                    return;
                }
            } while (true);
        }

        private bool Have_Empty_Places()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (_field[i, j] == ' ')
                        return true;
            return false;
        }

        private bool Have_Winner()
        {
            //horizontal
            if (_field[0, 0] == _field[0, 1] && _field[0, 1] == _field[0, 2] && _field[0, 0] != ' ') 
                return true;
            if (_field[1, 0] == _field[1, 1] && _field[1, 1] == _field[1, 2] && _field[1, 0] != ' ')
                return true;
            if (_field[2, 0] == _field[2, 1] && _field[2, 1] == _field[2, 2] && _field[2, 0] != ' ')
                return true;

            //vertical
            if (_field[0, 0] == _field[1, 0] && _field[1, 0] == _field[2, 0] && _field[0, 0] != ' ')
                return true;
            if (_field[0, 1] == _field[1, 1] && _field[1, 1] == _field[2, 1] && _field[0, 1] != ' ')
                return true;
            if (_field[0, 2] == _field[1, 2] && _field[1, 2] == _field[2, 2] && _field[0, 2] != ' ')
                return true;

            //diagonal
            if (_field[0, 0] == _field[1, 1] && _field[1, 1] == _field[2, 2] && _field[0, 0] != ' ')
                return true;
            if (_field[0, 2] == _field[1, 1] && _field[1, 1] == _field[2, 0] && _field[0, 2] != ' ')
                return true;

            return false;
        }

        private void Show()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {_field[0, 0]}  |  {_field[0, 1]}  |  {_field[0, 2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {_field[1, 0]}  |  {_field[1, 1]}  |  {_field[1, 2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {_field[2, 0]}  |  {_field[2, 1]}  |  {_field[2, 2]}");
            Console.WriteLine("     |     |      \n");
        }
    }
}
