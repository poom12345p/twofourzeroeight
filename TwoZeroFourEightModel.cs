using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twozerofoureight
{
    class TwoZeroFourEightModel : Model
    {
        protected int boardSize; // default is 4
        protected int[,] board;
        protected Random rand;
        protected static int score = 0; 

        public TwoZeroFourEightModel() : this(4)
        {
            // default board size is 4 
        }
        /// <summary>
        /// return board 
        /// </summary>
        /// <returns></returns>
        public int[,] GetBoard()
        {
            return board;
        }
        /// <summary>
        /// create new board that  size*size
        /// </summary>
        /// <param name="size"></param>
        public TwoZeroFourEightModel(int size)
        {
            boardSize = size;
            board = new int[boardSize, boardSize];
            var range = Enumerable.Range(0, boardSize);
            foreach(int i in range) {
                foreach(int j in range) {
                    board[i,j] = 0;
                }
            }
            rand = new Random();
            board = Random(board);
            NotifyAll();
        }
        /// <summary>
        /// add 2 block to board with random position
        /// </summary>
        /// <param name="input"></param>
        /// <returns> board with new 2 block
        /// </returns>
        private int[,] Random(int[,] input)
        {
            while (!isfull(input))///
            {
                int x = rand.Next(boardSize);
                int y = rand.Next(boardSize);
                if (board[x, y] == 0)
                {
                    board[x, y] = 2;
                    score += 2;
                    break;
                }
            }
            return input;
        }
        /// <summary>
        /// calculate new board by direction
        /// </summary>
        public void PerformDown()
        {
            int[] buffer;
            int pos;
            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeY);
            foreach (int i in rangeX)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeX)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeY)
                {
                    if (board[j, i] != 0)
                    {
                        buffer[pos] = board[j, i];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in rangeX)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeX)
                {
                    if (buffer[j] != 0)
                    {
                        board[pos, i] = buffer[j];
                        pos--;
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[k, i] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
            if(isOver(board))
            {
                gotoOver();
            }
        }

        public void PerformUp()
        {
            int[] buffer;
            int pos;

            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[j, i] != 0)
                    {
                        buffer[pos] = board[j, i];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        board[pos, i] = buffer[j];
                        pos++;
                    }
                }
                // copy back
                for (int k = pos; k != boardSize; k++)
                {
                    board[k, i] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
            if (isOver(board))
            {
                gotoOver();
            }
        }

        public void PerformRight()
        {
            int[] buffer;
            int pos;

            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeX);
            foreach (int i in rangeY)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeY)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeX)
                {
                    if (board[i, j] != 0)
                    {
                        buffer[pos] = board[i, j];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in rangeY)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeY)
                {
                    if (buffer[j] != 0)
                    {
                        board[i, pos] = buffer[j];
                        pos--;
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[i, k] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
            if (isOver(board))
            {
                gotoOver();
            }
        }

        public void PerformLeft()
        {
            int[] buffer;
            int pos;
            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[boardSize];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[i, j] != 0)
                    {
                        buffer[pos] = board[i, j];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        board[i, pos] = buffer[j];
                        pos++;
                    }
                }
                for (int k = pos; k != boardSize; k++)
                {
                    board[i, k] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
            if (isOver(board))
            {
                gotoOver();
            }
        }
    /// <summary>
    /// check board is it fulll?
    /// </summary>
    /// <param name="board"></param>
    /// <returns>bool true if no 0 in board
    /// </returns>
        bool isfull(int[,] board)
        {
            var range = Enumerable.Range(0, boardSize);
            foreach (int i in range)
            {
                foreach (int j in range)
                {
                   if( board[i, j] ==0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// send score
        /// </summary>
        /// <returns></returns>
        public  int getscore()
        {
            return score;
        }

        /// <summary>
        /// check board 
        /// is it full and can't move ?
        /// </summary>
        /// <param name="board"></param>
        /// <returns>ture if board full and can't move else false
        /// </returns>
        public bool isOver(int[,] board)
        {
           
            var range = Enumerable.Range(0, boardSize);
            foreach (int i in range)
            {
                foreach (int j in range)
                {
                    int current = board[i, j];

                    if (i-1 >= 0 && current == board[i-1, j])
                    {
                        return false;
                    }
                    else if (i + 1 <= boardSize-1 && current == board[i + 1, j])
                    {
                        return false;
                    }
                    if (j - 1 >= 0 && current == board[i, j-1])
                    {
                        return false;
                    }
                    if (j + 1 <= boardSize - 1 && current == board[i, j+1])
                    {
                        return false;
                    }
                }
            }
            if(!isfull(board))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// go to Over form
        /// </summary>
        void gotoOver()
        {
            GameOver GO = new GameOver(score);
            GO.Show();
            
        }
    }
}
