using Domain.Entities;
using Dapper;
using DefaultNamespace;
using Npgsql;

namespace Application;

public class DepartmentService:IDepartmentService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=University_db;User Id=postgres;Password=2810;";

    public List<Department> GetAllDepartment()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from departments;";
            var departments = connection.Query<Department>(sql).ToList();
            return departments;
        }
    }

    public Department GetDepartmentById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from departments where id = @id;";
            var chosenDepartment = connection.QuerySingleOrDefault<Department>(sql, new { Id=id });
            return chosenDepartment;
        }
    }

    public bool AddDepartment(Department department)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into departments(name,description) values(@name,@description);";
            var addedDepartment = connection.Execute(sql, department);
            return addedDepartment > 0;
        }
    }

    public bool UpdateDepartment(Department department)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "update departments set name=@name, description=@description where id=@id;";
            var updatedDepartment = connection.Execute(sql, department);
            return updatedDepartment > 0;
        }
    }

    public bool DeleteDepartment(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from departments where id=@id;";
            var deletedDepartment = connection.Execute(sql, new { Id = id });
            return deletedDepartment > 0;
        }
    }
}