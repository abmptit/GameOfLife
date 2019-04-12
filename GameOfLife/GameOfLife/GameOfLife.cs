namespace GameOfLife
{
    public class GameOfLife
    {
        private readonly CellState[,] _matrix;

        public GameOfLife(CellState[,] matrix)
        {
            _matrix = matrix;
        }

        public CellState[,] ComputeNextGeneration()
        {
            return _matrix;
        }

        private void ApplyUnderPopulation()
        {
        }

        private void ApplyOverCrowding()
        {
        }

        private void KillAllCells()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
                for (int j = 0; j < _matrix.GetLength(1); j++)
                    _matrix[i, j] = CellState.Dead;
        }

        private void MakeAliveAllCells()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
                for (int j = 0; j < _matrix.GetLength(1); j++)
                    _matrix[i, j] = CellState.Alive;
        }
    }
}
