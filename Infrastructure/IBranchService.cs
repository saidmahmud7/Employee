using Domain.Entities;

namespace DefaultNamespace;

public interface IBranchService
{
    List<Branch> GetAllBranch();
    Branch GetBranchById(int id);
    bool AddBranch(Branch branch);
    bool UpdateBranch(Branch branch);
    bool DeleteBranch(int id);
    
}