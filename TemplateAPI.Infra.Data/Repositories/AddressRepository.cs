using Template.Domain.Entities;
using Template.Infra.Data.Context;

namespace Template.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
