using App.Infra.Data.SqlService.Ef;

namespace App.Infra.DataAccess.EF.UserAggrigate;

public class UserRepository
{
    private readonly TaskManagerDb _context;
    public UserRepository(TaskManagerDb context)
    {
        _context = context;
    }
}
