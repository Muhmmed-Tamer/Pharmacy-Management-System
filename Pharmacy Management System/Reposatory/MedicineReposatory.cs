using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System.Data;
using Pharmacy_Management_System.Models;

namespace Pharmacy_Management_System.Reposatory
{

    public class MedicineReposatory : IReposatory<Medicine>
    {
        PharamyContext context;
        public MedicineReposatory(PharamyContext _context) {
            context = _context;
        }
        public void Add(Medicine item)
        {
            context.Add(item);
        }

        public void Delete(int id)
        {            
            context.Remove(GetById(id));
        }

        public List<Medicine> GetAll()
        {
            return context.Medicines.Include(M=>M.Stock).ToList();  
        }

        public Medicine GetById(int id)
        {
            return context.Medicines.FirstOrDefault(M => M.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Medicine item)
        {

            context.Update(item);
        }
    }
}
