using System.Collections.Generic;
using PoliziaMunicipaleApp.DAO;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class AnagraficaService
    {
        private readonly AnagraficaDAO _anagraficaDao;

        public AnagraficaService(IConfiguration configuration)
        {
            _anagraficaDao = new AnagraficaDAO(configuration);
        }

        public IEnumerable<Anagrafica> GetAllAnagrafiche()
        {
            return _anagraficaDao.GetAll();
        }

        public void AddAnagrafica(Anagrafica anagrafica)
        {
            _anagraficaDao.Add(anagrafica);
        }
    }
}
