using DailyShop.Main.Models;
using System.Linq;

namespace DailyShop.Main.Contracts
{
    public interface IRepository<P> where P : BaseE
    {
        IQueryable<P> Collection();
        void Delete(string Id);
        P Find(string Id);
        void Insert(P p);
        void Save();
        void Update(P p);
    }
}