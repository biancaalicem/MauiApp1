using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Models;


namespace MauiApp1.Data
{
    public class PensiuneDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public PensiuneDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pensiune>().Wait();
            _database.CreateTableAsync<Experienta>().Wait();
            _database.CreateTableAsync<ListExperienta>().Wait();
            _database.CreateTableAsync<Locatie>().Wait();
        }
        public Task<List<Locatie>> GetLocatiiAsync()
        {
            return _database.Table<Locatie>().ToListAsync();
        }
        public Task<int> SaveLocatieAsync(Locatie locatie)
        {
            if (locatie.ID != 0)
            {
                return _database.UpdateAsync(locatie);
            }
            else
            {
                return _database.InsertAsync(locatie);
            }
        }
        public Task<int> SaveExperientaAsync(Experienta experienta)
        {
            if (experienta.ID != 0)
            {
                return _database.UpdateAsync(experienta);
            }
            else
            {
                return _database.InsertAsync(experienta);
            }
        }
        public Task<int> DeleteExperientaAsync(Experienta experienta) { return _database.DeleteAsync(experienta); }
        public Task<List<Experienta>> GetExperienteAsync()
        { return _database.Table<Experienta>().ToListAsync(); }
        public Task<List<Pensiune>> GetPensiuniAsync() { return _database.Table<Pensiune>().ToListAsync(); }
        public Task<Pensiune> GetPensiuneAsync(int id) { return _database.Table<Pensiune>().Where(i => i.ID == id).FirstOrDefaultAsync(); }
        public Task<int> SavePensiuneAsync(Pensiune slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeletePensiuneAsync(Pensiune slist) { return _database.DeleteAsync(slist); }
        public Task<int> SaveListExperientaAsync(ListExperienta listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<Pensiune>> GetListExperienteAsync(int shoplistid)
        {
            return _database.QueryAsync<Pensiune>("select P.ID, P.Description from Pensiune P" + " inner join ListExperienta LP" + " on P.ID = LP.ExperientaID where LP.PensiuneID = ?", shoplistid);
        }
    }
    
}
