using Dapper;
using Domain.Entities;
using Npgsql;

namespace Application;

public class BranchService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=Company_db;User Id=postgres;Password=2810;";

    public List<Branch> GetAllBranch()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from branches;";
            var branches = connection.Query<Branch>(sql).ToList();
            return branches;
        }
    }

    public Branch GetBranchById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from branches where id=@id";
            var chosenBranch = connection.QueryFirst<Branch>(sql,new {Id = id});
            return chosenBranch;
        }
    }

    public bool AddBranch(Branch branch)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into branches(name, location, companyId) values(@name,@location,@companyId);";
            var addedBranch = connection.Execute(sql,branch);
            return addedBranch > 0;
        }
    }

    public bool UpdateBranch(Branch branch)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "update branches set name=@name, location=@location, companyId=@companyId where id=@id;";
            var updatedBranch = connection.Execute(sql, branch);
            return updatedBranch > 0;
        }
    }

    public bool DeleteBranch(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from branches where id=@id;";
            var deletedBranch = connection.Execute(sql, new {id});
            return deletedBranch > 0;
        }
    }
}