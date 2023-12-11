using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext context;
        private RoleRepository _Roles;
        private UserRepository _Users;


        public UnitOfWork(DBContext _context)
        {
            context = _context;
        }


        public IRole Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = new RoleRepository(context);
                }
                return _Roles;
            }
        }

        public IUser Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(context);
                }
                return _Users;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

    }
}