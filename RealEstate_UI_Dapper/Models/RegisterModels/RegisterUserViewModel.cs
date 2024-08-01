﻿namespace RealEstate_UI_Dapper.Models.RegisterModels;

public class RegisterUserViewModel
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
}
