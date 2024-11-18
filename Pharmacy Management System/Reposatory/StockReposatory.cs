using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System.Data;
using Pharmacy_Management_System.Models;

namespace Pharmacy_Management_System.Reposatory
{
    public class StockReposatory : IReposatory<Stock>
    {
        PharamyContext Context;
        public StockReposatory(PharamyContext _Context) { 
            Context = _Context;
        }
        public void Add(Stock item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetAll()
        {
            return Context.Stocks.ToList();
        }

        public Stock GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Stock item)
        {
            throw new NotImplementedException();
        }
    }
}
