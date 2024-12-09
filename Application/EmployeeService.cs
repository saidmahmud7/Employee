using Dapper;
using Domain.Entities;
using Infrastructure;
using Npgsql;

namespace Application;

public class EmployeeService : IEmployeeService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=University_db;User Id=postgres;Password=2810;";

    public  List<Employee> GetAllEmployees()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from employees;";
            var employees = connection.Query<Employee>(sql).ToList();
            return employees;
        }
    }

    public  Employee GetEmployeeById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from employees where id = @Id;";
            var chosenEmployee = connection.QuerySingleOrDefault<Employee>(sql, new { Id = id });
            return chosenEmployee;
        }
    }

    public  bool AddEmployee(Employee employee)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into employees(fullname, email, departmentid, branchid) values(@fullname,@email,@departmentid, @branchid);";
            var addedEmployee = connection.Execute(sql, employee);
            return addedEmployee > 0;
        }
    }

    public  bool UpdateEmployee(Employee employee)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "update employees set fullname=@fullname, email=@email, departmentid=@departmentid, branchid=@branchid where id=@id;";
            var updatedEmployee = connection.Execute(sql, employee);
            return updatedEmployee > 0;
        }
    }

    public  bool DeleteEmployee(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from employees where id = @Id;";
            var deletedEmployee = connection.Execute(sql, new { Id = id });
            return deletedEmployee > 0;
        }
    }
}