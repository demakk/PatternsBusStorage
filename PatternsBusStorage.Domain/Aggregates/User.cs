﻿namespace PatternsBusStorage.Domain.Aggregates;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
}