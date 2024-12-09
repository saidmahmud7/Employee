using Domain.Entities;

namespace Infrastructure;
public interface ICompanyService
{
    List<Company> GetAllCompanies();
    Company GetCompanyById(int id);
    bool AddCompany(Company company);
    bool UpdateCompany(Company company);
    bool DeleteCompany(int id);
}
