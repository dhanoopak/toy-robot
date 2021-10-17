namespace ToyRobot
{
    public class ToyRobotReport
    {
        private int X { get; }
        private int Y { get; }
        private string Direction { get; }

        public ToyRobotReport(int inputX, int inputY, string direction)
        {
            X = inputX;
            Y = inputY;
            Direction = direction;
        }

        /// <summary>
        /// Returns current position and direction of Toy robot
        /// </summary>
        /// <returns>Current position and direction of robot</returns>
        public string GetPositionAndDirection()
        {
            return $"{X},{Y},{Direction}";
        }
    }
}
