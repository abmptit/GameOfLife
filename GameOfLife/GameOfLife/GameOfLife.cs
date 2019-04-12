using System.Linq;

namespace GameOfLife
{
    public class GameOfLife
    {
        private readonly CellState[,] _matrix;
        private CellState[,] _nextGenMatrix;

        public GameOfLife(CellState[,] matrix)
        {
            _matrix = matrix;
        }

        public CellState[,] ComputeNextGeneration()
        {
            _nextGenMatrix = (CellState[,])_matrix.Clone();
            
            ApplyRules();

            return _nextGenMatrix;
        }
        private void ApplyRules()
        {
            for (int i = 0; i < _nextGenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _nextGenMatrix.GetLength(1); j++)
                {
                    int count = CountAliveCellNeighbors(i, j);
                    if (count < 2)
                    {
                        _nextGenMatrix[i, j] = CellState.Dead;
                    }
                    if (count > 3)
                    {
                        _nextGenMatrix[i, j] = CellState.Dead;
                    }
                    if (count == 3)
                    {
                        _nextGenMatrix[i, j] = CellState.Alive;
                    }
                }
            }

        }


        private void ApplyUnderPopulation()
        {
            for (int i = 0; i < _nextGenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _nextGenMatrix.GetLength(1); j++)
                {
                    int count = CountAliveCellNeighbors(i, j);
                    if (count < 2)
                    {
                        _nextGenMatrix[i, j] = CellState.Dead;
                    }

                    
                }
            }
        }
        private int CountAliveCellNeighbors(int x, int y)
        {
            int count = 0;
            if (y > 0 && _matrix[x, y - 1] == CellState.Alive)
            {
                count++;
            }
            if (x > 0 && _matrix[x - 1, y] == CellState.Alive)
            {
                count++;
            }
            if (y > 0 && x > 0 && _matrix[x - 1, y - 1] == CellState.Alive)
            {
                count++;
            }
            if (x < (_matrix.GetLength(0) - 1) && _matrix[x + 1, y] == CellState.Alive)
            {
                count++;
            }
            if (y < (_matrix.GetLength(1) - 1) && _matrix[x, y + 1] == CellState.Alive)
            {
                count++;
            }
            if (y < (_matrix.GetLength(1) - 1) && x < (_matrix.GetLength(0) - 1) && _matrix[x + 1, y + 1] == CellState.Alive)
            {
                count++;
            }
            if (y < (_matrix.GetLength(1) - 1) && x > 0 && _matrix[x - 1, y + 1] == CellState.Alive)
            {
                count++;
            }
            if (x < (_matrix.GetLength(0) - 1) && y > 0 && _matrix[x + 1, y - 1] == CellState.Alive)
            {
                count++;
            }
            return count;
        }
        private void ApplyOverCrowding()
        {
            for (int i = 0; i < _nextGenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _nextGenMatrix.GetLength(1); j++)
                {
                    int count = CountAliveCellNeighbors(i, j);
                    if (count > 3)
                    {
                        _nextGenMatrix[i, j] = CellState.Dead;
                    }
                }
            }
        }
        private void ApplyOverCrowding_New()
        {
            for (int i = 0; i < _nextGenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _nextGenMatrix.GetLength(1); j++)
                {
                    int count = CountAliveCellNeighbors(i, j);
                    if (count == 3)
                    {
                        _nextGenMatrix[i, j] = CellState.Alive;
                    }
                }
            }
        }
        private void KillAllCells()
        {
            for (int i = 0; i < _nextGenMatrix.GetLength(0); i++)
                for (int j = 0; j < _nextGenMatrix.GetLength(1); j++)
                    _nextGenMatrix[i, j] = CellState.Dead;
        }

        private void MakeAliveAllCells()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
                for (int j = 0; j < _matrix.GetLength(1); j++)
                    _matrix[i, j] = CellState.Alive;
        }
    }
}
