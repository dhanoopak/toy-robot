using System;
using System.ComponentModel;

namespace ToyRobot
{
    public class ToyRobot
    {
        private bool IsRobotPlaced { get; set; }
        private int X { get; set; }
        private int Y { get; set; }
        private ToyRobotConstants.Directions RobotDirection { get; set; }

        /// <summary>
        /// Processes the toy robot input commands
        /// </summary>
        /// <param name="command">Input command</param>
        public string Process(string command)
        {
            if (command.StartsWith(ToyRobotConstants.Place))
            {
                var parseCommand = command.Replace(ToyRobotConstants.Place, "");
                var inputArray = parseCommand.Split(',');
                if (inputArray.Length < ToyRobotConstants.NumberOfInputsForPlaceCmd)
                    return ToyRobotConstants.ErrorPlaceCommandWithIncorrectFormat;

                int.TryParse(inputArray[0], out var xValue);
                int.TryParse(inputArray[1], out var yValue);

                if (!ValidatePosition(xValue, yValue)) return ToyRobotConstants.ErrorPlaceCommandHasIncorrectPosition;

                X = xValue;
                Y = yValue;

                // Find the degree
                var inputDirection = GetDirectionFromDescription(inputArray[2]?.Trim());
                if (inputDirection == ToyRobotConstants.Directions.Invalid)
                    return ToyRobotConstants.ErrorPlaceCommandHasIncorrectDirection;

                RobotDirection = inputDirection;

                IsRobotPlaced = true;
            }

            if (!IsRobotPlaced)
            {
                return ToyRobotConstants.ErrorPlaceCommandNotCalled;
            }

            switch (command)
            {
                case ToyRobotConstants.Left:
                    Left();
                    break;
                case ToyRobotConstants.Right:
                    Right();
                    break;
                case ToyRobotConstants.Move:
                    Move();
                    break;
                case ToyRobotConstants.Report:
                    return Report();
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the direction within defined boundaries (0 to 360 degree)
        /// </summary>
        /// <param name="degree">Current direction</param>
        /// <param name="angle">Angle to rotate</param>
        /// <returns>New direction of toy robot based on angle</returns>
        private int GetDirection(int degree, int angle)
        {
            return (ToyRobotConstants.MaxDegree + degree + angle) % ToyRobotConstants.MaxDegree;
        }

        /// <summary>
        /// Turn left
        /// </summary>
        private void Left()
        {
            RobotDirection = (ToyRobotConstants.Directions)GetDirection((int)RobotDirection, -90);
        }

        /// <summary>
        /// Turn right
        /// </summary>
        private void Right()
        {
            RobotDirection = (ToyRobotConstants.Directions)GetDirection((int)RobotDirection, 90);
        }

        /// <summary>
        /// Move by one unit based on given direction
        /// </summary>
        private void Move()
        {
            switch (RobotDirection)
            {
                case ToyRobotConstants.Directions.North:
                {
                    if (ValidatePosition(X, Y + 1)) Y++;

                    break;
                }
                case ToyRobotConstants.Directions.South:
                {
                    if (ValidatePosition(X, Y - 1)) Y--;

                    break;
                }
                case ToyRobotConstants.Directions.East:
                {
                    if (ValidatePosition(X + 1, Y)) X++;

                    break;
                }
                case ToyRobotConstants.Directions.West:
                {
                    if (ValidatePosition(X - 1, Y)) X--;

                    break;
                }
            }
        }

        /// <summary>
        /// Validate position against boundary values (-ve or > 4)
        /// </summary>
        /// <param name="inputX">X direction</param>
        /// <param name="inputY">Y direction</param>
        /// <returns>True if position is valid, else false</returns>
        private bool ValidatePosition(int inputX, int inputY)
        {
            return inputX >= 0 && inputX < ToyRobotConstants.MaxTableUnits && inputY >= 0 && inputY < ToyRobotConstants.MaxTableUnits;
        }

        /// <summary>
        /// Reports current position and direction of toy robot
        /// </summary>
        /// <returns>Returns current position and direction of toy robot</returns>
        private string Report()
        {
            var report = new ToyRobotReport(X, Y, RobotDirection.ToString()?.ToUpper());
            return report.GetPositionAndDirection();
        }

        /// <summary>
        /// Fetch enum direction from user input direction
        /// </summary>
        /// <param name="description">User input direction</param>
        /// <returns>Enum direction</returns>
        private ToyRobotConstants.Directions GetDirectionFromDescription(string description)
        {
            foreach (var field in typeof(ToyRobotConstants.Directions).GetFields())
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                    if (string.Equals(attribute.Description, description, StringComparison.CurrentCultureIgnoreCase))
                        return (ToyRobotConstants.Directions)field.GetValue(null);

            // If no valid direction is identified, return Invalid direction
            return ToyRobotConstants.Directions.Invalid;
        }
    }
}
