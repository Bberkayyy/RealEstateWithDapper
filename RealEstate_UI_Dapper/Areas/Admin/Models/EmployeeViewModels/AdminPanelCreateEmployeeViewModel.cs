﻿namespace RealEstate_UI_Dapper.Areas.Admin.Models.EmployeeViewModels;

public class AdminPanelCreateEmployeeViewModel
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}
