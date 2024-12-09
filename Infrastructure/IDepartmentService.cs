using Domain.Entities;

namespace DefaultNamespace;

public interface IDepartmentService
{
    List<Department> GetAllDepartment();
    Department GetDepartmentById(int id);
    bool AddDepartment(Department department);
    bool UpdateDepartment(Department department);
    bool DeleteDepartment(int id);
}