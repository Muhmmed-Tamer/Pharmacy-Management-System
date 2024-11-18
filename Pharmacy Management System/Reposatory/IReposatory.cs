namespace Pharmacy_Management_System.Reposatory
{
    public interface IReposatory<T> where T : class
    {
        void Add(T item);   
        void Update(T item);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
        void Save();
    }
}
