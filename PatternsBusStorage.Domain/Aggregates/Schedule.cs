﻿namespace PatternsBusStorage.Domain.Aggregates;

public class Schedule
{
    public int ScheduleId { get; set; }
    public int BusId { get; set; }
    public int RouteId { get; set; }
    public int StopId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
}