﻿namespace Shared.DTOs.UserApplication;

public class UserApplicationRegisterDTO
{
    public Guid Id { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }
}