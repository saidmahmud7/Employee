using Domain.Entities;
using Dapper;
using Infrastructure;
using Npgsql;

namespace Application;

public class CompanyService : ICompanyService
{
    private const string connectionString =
        "Server=127.0.0.1;Port=5432;Database=University_db;User Id=postgres;Password=2810;";


    public List<Company> GetAllCompanies()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from employees;";
            var companies = connection.Query<Company>(sql).ToList();
            return companies;
        }
    }

    public Company GetCompanyById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from companies where id = @id;";
            var chosenCompany = connection.QueryFirst<Company>(sql, new { Id = id });
            return chosenCompany;
        }
    }

    public bool AddCompany(Company company)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into company(name,description) values(@name,@description);";
            var addedCompany = connection.Execute(sql);
            return addedCompany > 0;
        }
    }

    public bool UpdateCompany(Company company)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "update companies set name=@name, description=@description where id=@id;";
            var updatedCompany = connection.Execute(sql, company);
            return updatedCompany > 0;
        }
    }

    public bool DeleteCompany(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from company where id=@id;";
            var deletedCompany = connection.Execute(sql, new { Id = id });
            return deletedCompany > 0;
        }
    }
}