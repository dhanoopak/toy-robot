using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace ToyRobotUnitTests
{
    [TestClass]
    public class ToyRobotTests
    {
        #region TestDrivenDevelopment TestCases
        [TestMethod]
        public void UnitTest_CommandsReturnErrorWhenPlaceCommandIsNotCalledTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            string message = toyRobot.Process("MOVE");

            // Assert
            Assert.AreEqual(ToyRobotConstants.ErrorPlaceCommandNotCalled, message);
        }

        [TestMethod]
        public void UnitTest_PlaceCommandWithIncorrectFormatReturnsErrorTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            string message = toyRobot.Process("PLACE");

            // Assert
            Assert.AreEqual(ToyRobotConstants.ErrorPlaceCommandWithIncorrectFormat, message);
        }

        [TestMethod]
        public void UnitTest_PlaceCommandWithIncorrectDirectionReturnsErrorTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            string message = toyRobot.Process("PLACE 0,0, TEST_DIRECTION");

            // Assert
            Assert.AreEqual(ToyRobotConstants.ErrorPlaceCommandHasIncorrectDirection, message);
        }

        [TestMethod]
        public void UnitTest_PlaceCommandAndReportCommandsReturnsPositionAndDirectionTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 0,0, NORTH");
            var message = toyRobot.Process("REPORT");

            // Assert
            string expectedOutput = "0,0,NORTH";
            Assert.AreEqual(expectedOutput, message);
        }

        [TestMethod]
        public void UnitTest_MultiplePlaceCommandsReturnsPositionAndDirectionTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 0,0, NORTH");
            toyRobot.Process("PLACE 0,0, NORTH");
            toyRobot.Process("PLACE 0,0, NORTH");
            var message = toyRobot.Process("REPORT");

            // Assert
            string expectedOutput = "0,0,NORTH";
            Assert.AreEqual(expectedOutput, message);
        }

        [TestMethod]
        public void UnitTest_ToyRobotMustNotFallOffTheTableDuringPlaceCommandTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            var message1 = toyRobot.Process("PLACE 5,5, NORTH");
            var message2 = toyRobot.Process("REPORT"); 

            // Assert
            Assert.AreEqual(ToyRobotConstants.ErrorPlaceCommandHasIncorrectPosition, message1);

            // First PLACE command will be ignored as its falling outside the table boundary
            Assert.AreEqual(ToyRobotConstants.ErrorPlaceCommandNotCalled, message2);
        }

        [TestMethod]
        public void UnitTest_ToyRobotTurnLeftTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 0,0, NORTH");
            toyRobot.Process("LEFT");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "0,0,WEST";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void UnitTest_ToyRobotTurnLeftTwoTimesTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 1,0, NORTH");
            toyRobot.Process("LEFT");
            toyRobot.Process("LEFT");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "1,0,SOUTH";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void UnitTest_ToyRobotTurnRightTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 2,1, NORTH");
            toyRobot.Process("RIGHT");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "2,1,EAST";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void UnitTest_ToyRobotTurnRightTwoTimesTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 1,0, NORTH");
            toyRobot.Process("RIGHT");
            toyRobot.Process("RIGHT");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "1,0,SOUTH";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void UnitTest_ToyRobotTurnOneLeftAndTwoRightTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 2,2, NORTH");
            toyRobot.Process("LEFT");
            toyRobot.Process("RIGHT");
            toyRobot.Process("RIGHT");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "2,2,EAST";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void UnitTest_ToyRobotMoveAfterPlaceTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 3,1, EAST");
            toyRobot.Process("MOVE");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "4,1,EAST";
            Assert.AreEqual(expectedOutput, actualOutput);
        }


        [TestMethod]
        public void UnitTest_ToyRobotIgnoreMoveCommandIfFallOfTheTableTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 4,1, EAST");
            toyRobot.Process("MOVE");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "4,1,EAST";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void UnitTest_ToyRobotTurnLeftAndMoveOneStepTest()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 1,1, EAST");
            toyRobot.Process("LEFT");
            toyRobot.Process("MOVE");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "1,2,NORTH";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        #endregion

        #region IntegrationTestCases
        [TestMethod]
        public void IntegrationTest_ExampleA_FromProvidedTestData()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 0,0, NORTH");
            toyRobot.Process("MOVE");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "0,1,NORTH";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void IntegrationTest_ExampleB_FromProvidedTestData()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 0,0, NORTH");
            toyRobot.Process("LEFT");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "0,0,WEST";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void IntegrationTest_ExampleC_FromProvidedTestData()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("PLACE 1,2, EAST");
            toyRobot.Process("MOVE");
            toyRobot.Process("MOVE");
            toyRobot.Process("LEFT");
            toyRobot.Process("MOVE");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "3,3,NORTH";
            Assert.AreEqual(expectedOutput, actualOutput);
        }


        [TestMethod]
        public void IntegrationTest_ManyInputCombinations()
        {
            // Arrange
            ToyRobot.ToyRobot toyRobot = new ToyRobot.ToyRobot();

            // Act
            toyRobot.Process("MOVE");
            toyRobot.Process("PLACE 3,4, SOUTH");
            toyRobot.Process("MOVE");
            toyRobot.Process("PLACE 4,4, WEST");
            toyRobot.Process("RIGHT");
            toyRobot.Process("MOVE");
            toyRobot.Process("LEFT");
            toyRobot.Process("MOVE");
            toyRobot.Process("MOVE");
            var actualOutput = toyRobot.Process("REPORT");

            // Assert
            var expectedOutput = "2,4,WEST";
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        #endregion
    }
}
