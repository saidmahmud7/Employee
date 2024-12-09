﻿namespace Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int DepartmentId { get; set; }
    public int BranchId { get; set; }
}