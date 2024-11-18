using Microsoft.AspNetCore.Identity;
using Pharmacy_Management_System.Data;
using Pharmacy_Management_System.Models;

namespace Pharmacy_Management_System.Reposatory
{
    public class RolesReposatory : IReposatory<IdentityRole>
    {
        PharamyContext Context;
        RoleManager<IdentityRole> _RoleManager;
        public RolesReposatory(PharamyContext _Context, RoleManager<IdentityRole> roleManager)
        {
            Context = _Context;
            _RoleManager = roleManager;
        }

        public void Add(IdentityRole item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<IdentityRole> GetAll()
        {            
            
           return _RoleManager.Roles.ToList();
        }

        public IdentityRole GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(IdentityRole item)
        {
            throw new NotImplementedException();
        }
    }
}
