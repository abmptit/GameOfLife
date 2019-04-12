using Xunit;

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
            //Arrange
            CellState[,] matrix = new CellState[3, 3]
            {
                 { CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead}
            };
            var game = new GameOfLife(matrix);

            //Act
            var matrixResult = game.ComputeNextGeneration();

            //Assert
            foreach(var cell in matrix)
            {
                Assert.Equal(CellState.Dead, cell);
            }
        }
    }
}
