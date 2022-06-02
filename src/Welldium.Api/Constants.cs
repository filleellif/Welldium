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
    }
}
