using Template.Domain.Entities;
using Template.Infra.Data.Context;

namespace Template.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
