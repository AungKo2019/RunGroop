using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces();
        Task<List<Club>>GetAllUserClubs();
        Task<AppUser> GetUserById(string Id);
        Task<AppUser> GetByIdNoTracking(string Name);   
        bool Update(AppUser user);
        bool Save();
    }
}
