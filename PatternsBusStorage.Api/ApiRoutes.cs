namespace PatternsBusStorage.Api;

public static class ApiRoutes
{
    public const string BaseRoute = "api/[controller]";
    
    public static class BusStop
    {
        public const string IdRoute = "{id}";
    }
    
    public static class City
    {
        public const string IdRoute = "{id}";
    }
    
    public static class Schedule
    {
        public const string IdRoute = "{id}";
    }
    
    public static class Route
    {
        public const string IdRoute = "{id}";
    }

    public static class Bus
    {
        public const string IdRoute = "{id}";
        public const string NumberRoute = "n/{number}";
        public const string MementoTest = "{id}/memento";
    }
    
    public static class User
    {
        public const string ClosestBusesByStopId = "{stopId}";
        public const string BusesByStopId = "all/{stopId}";
    }
    
    
}