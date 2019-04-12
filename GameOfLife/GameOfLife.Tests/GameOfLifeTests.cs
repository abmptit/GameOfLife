using System;
using Xunit;
using GameOfLife;

namespace GameOfLife.Tests
{
    public class GameOfLifeTests
    {
        public GameOfLifeTests()
        {
        }

        [Fact]
        public void ComputeNextGeneration_DeadMatrix_ReturnsDeadMatrix()
        {

            CellState[,] matrix = new CellState[3, 3]
            {
                 { CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead}
            };

            var game = new GameOfLife(matrix);

            var matrixResult = game.ComputeNextGeneration();

            foreach(var cell in matrix)
            {
                Assert.Equal(CellState.Dead, cell);
            }
        }

       
    }
}
