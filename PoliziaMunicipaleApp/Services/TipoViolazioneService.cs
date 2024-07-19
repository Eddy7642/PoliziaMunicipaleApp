using System.Collections.Generic;
using PoliziaMunicipaleApp.DAO;
using PoliziaMunicipaleApp.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class TipoViolazioneService
    {
        private readonly TipoViolazioneDAO _tipoViolazioneDao;

        public TipoViolazioneService(IConfiguration configuration)
        {
            _tipoViolazioneDao = new TipoViolazioneDAO(configuration);
        }

        public IEnumerable<TipoViolazione> GetAllTipoViolazioni()
        {
            return _tipoViolazioneDao.GetAll();
        }

        public void AddTipoViolazione(TipoViolazione tipoViolazione)
        {
            _tipoViolazioneDao.Add(tipoViolazione);
        }
    }
}
