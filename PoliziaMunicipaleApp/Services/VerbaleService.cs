using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PoliziaMunicipaleApp.DAO;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class VerbaleService
    {
        private readonly VerbaleDAO _verbaleDao;

        public VerbaleService(IConfiguration configuration)
        {
            _verbaleDao = new VerbaleDAO(configuration);
        }

        public IEnumerable<Verbale> GetAllVerbali()
        {
            return _verbaleDao.GetAll();
        }

        public void AddVerbale(Verbale verbale)
        {
            _verbaleDao.Add(verbale);
        }

        public bool DeleteVerbale(int id)
        {
            return _verbaleDao.Delete(id);
        }
    }
}
