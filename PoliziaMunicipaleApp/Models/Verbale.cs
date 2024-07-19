using System;
using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipaleApp.Models
{
    public class Verbale
    {
        public int Idverbale { get; set; }

        [Required]
        [Display(Name = "Data Violazione")]
        public DateTime DataViolazione { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Indirizzo Violazione")]
        public string IndirizzoViolazione { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nominativo Agente")]
        public string Nominativo_Agente { get; set; }

        [Required]
        [Display(Name = "Data Trascrizione Verbale")]
        public DateTime DataTrascrizioneVerbale { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Importo { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Decurtamento Punti")]
        public int DecurtamentoPunti { get; set; }

        [Required]
        public int Idanagrafica { get; set; }

        [Required]
        public int Idviolazione { get; set; }

        public virtual Anagrafica Anagrafica { get; set; }
        public virtual TipoViolazione TipoViolazione { get; set; }
    }
}
