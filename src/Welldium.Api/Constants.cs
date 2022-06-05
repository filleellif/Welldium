namespace Welldium.Api;

public static class Constants
{
    public static class Routes
    {
        public const string Simulation = "/simulation";

        public const string Robot = "/robot";
    }

    public static class RouteNames
    {
        public const string CreateSimulation = nameof(CreateSimulation);

        public const string GetSimulation = nameof(GetSimulation);

        public const string CreateRobot = nameof(CreateRobot);

        public const string RemoveRobot = nameof(RemoveRobot);

        public const string MoveRobot = nameof(MoveRobot);

        public const string AdvanceRobot = nameof(AdvanceRobot);

        public const string TurnRobotLeft = nameof(TurnRobotLeft);

        public const string TurnRobotRight = nameof(TurnRobotRight);
    }
}
