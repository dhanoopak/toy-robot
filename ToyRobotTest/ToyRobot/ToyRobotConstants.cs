using System.ComponentModel;

namespace ToyRobot
{
    public class ToyRobotConstants
    {
        // ToyRobot Directions
        public enum Directions
        {
            [Description("North")] North = 0,
            [Description("East")] East = 90,
            [Description("South")] South = 180,
            [Description("West")] West = 270,
            [Description("Invalid Direction")] Invalid = -1
        }

        // ToyRobot Commands
        public const string Place = "PLACE";
        public const string Move = "MOVE";
        public const string Left = "LEFT";
        public const string Right = "RIGHT";
        public const string Report = "REPORT";

        // Error message
        public const string ErrorPlaceCommandNotCalled = "Please place toy robot on the table";
        public const string ErrorPlaceCommandWithIncorrectFormat = "Please provide X,Y,DIRECTION";
        public const string ErrorPlaceCommandHasIncorrectDirection = "Provide valid direction (NORTH/SOUTH/WEST/EAST)";
        public const string ErrorPlaceCommandHasIncorrectPosition = "Place robot in valid positions (between 0 to 4)";

        // Constants
        public const int NumberOfInputsForPlaceCmd = 3;
        public const int MaxDegree = 360;
        public const int MaxTableUnits = 5;
    }
}
