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
                {   int count = CountAliveCellNeighbors(i, j);
                    if ((count == 3) || (count == 2 && _matrix[i, j] == CellState.Alive)) { _nextGenMatrix[i, j] = CellState.Alive; }
                    else { _nextGenMatrix[i, j] = CellState.Dead; }
                }
            }
        }
        private int CountAliveCellNeighbors(int x, int y)
        {   int count = 0;
            if(x>0)
            {   if (y > 0 && _matrix[x - 1, y - 1] == CellState.Alive) { count++; }
                if (_matrix[x - 1, y] == CellState.Alive) { count++; }
                if (y < (_matrix.GetLength(1) - 1) && _matrix[x - 1, y + 1] == CellState.Alive) { count++; }
            }
            if (x < (_matrix.GetLength(0) - 1))
            {   if (_matrix[x + 1, y] == CellState.Alive) { count++; }
                if (y > 0 && _matrix[x + 1, y - 1] == CellState.Alive) { count++; }
                if (y < (_matrix.GetLength(1) - 1) && _matrix[x + 1, y + 1] == CellState.Alive) { count++; }
            }
            if (y< (_matrix.GetLength(1) - 1)&&_matrix[x, y + 1] == CellState.Alive) { count++; }
            if (y > 0 && _matrix[x, y - 1] == CellState.Alive) { count++; }
            return count;
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
