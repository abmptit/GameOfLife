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
            //Row / Column
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
            CellState[,] expectedMatrix = new CellState[3, 3]
           {
                 { CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead}
           };
            Assert.Equal(expectedMatrix, matrix);
        }

        /// <summary>
        /// Test UnderPopulation
        /// </summary>
        [Fact]
        public void ComputeNextGeneration_CellWithLessThanTwoLiveNeighboor_Dead()
        {
            //Arrange
            //Row/Column
            CellState[,] matrix = new CellState[6, 6]
            {
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead}
            };
            var game = new GameOfLife(matrix);

            //Act
            var matrixResult = game.ComputeNextGeneration();

            //Assert
            var cell1 = matrixResult[1, 0];
            Assert.Equal(CellState.Dead, cell1);
        }

        /// <summary>
        /// Test UnderPopulation
        /// </summary>
        [Fact]
        public void ComputeNextGeneration_CellWithMoreThanTwoLiveNeighboor_Alive()
        {
            //Arrange
            //Row/Column
            CellState[,] matrix = new CellState[6, 6]
            {
                 { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Alive, CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead}
            };
            var game = new GameOfLife(matrix);

            //Act
            var matrixResult = game.ComputeNextGeneration();

            //Assert
            var cell1 = matrixResult[1, 0];
            Assert.Equal(CellState.Alive, cell1);


        }
        [Fact]
        public void ComputeNextGeneration_CellWithMoreThenThreeLiveNeighboor_Dead()
        {
            //Arrange
            //Row/Column
            CellState[,] matrix = new CellState[6, 6]
            {
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Alive, CellState.Alive, CellState.Alive},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Alive, CellState.Alive}
            };
            var game = new GameOfLife(matrix);

            //Act
            var matrixResult = game.ComputeNextGeneration();

            //Assert
            var cell1 = matrixResult[4, 4];
            Assert.Equal(CellState.Dead, cell1);
        }
        [Fact]
        public void ComputeNextGeneration_DeadCellWithMoreThenThreeLiveNeighboor_Alive()
        {
            //Arrange
            //Row/Column
            CellState[,] matrix = new CellState[6, 6]
            {
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Alive, CellState.Alive, CellState.Alive},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Alive, CellState.Alive}
            };
            var game = new GameOfLife(matrix);

            //Act
            var matrixResult = game.ComputeNextGeneration();

            //Assert
            var cell1 = matrixResult[3, 4];
            Assert.Equal(CellState.Alive, cell1);
        }

        [Fact]
        public void Test()
        {
            //Arrange
            //Row/Column
            CellState[,] matrix = new CellState[6, 6]
            {
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Alive, CellState.Alive, CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead}
            };
            var game = new GameOfLife(matrix);

            //Act
            var matrixResult = game.ComputeNextGeneration();

            //Assert
            var cell1 = matrixResult[1, 0];
            CellState[,] expectedmatrix = new CellState[6, 6]
           {
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Alive, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead},
                 { CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead, CellState.Dead}
           };
            Assert.Equal(expectedmatrix, matrix);


        }



    }
}
