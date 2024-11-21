using System;
using System.Collections.Generic;

namespace Solaria.Models
{
    public class PosteDeLuz
    {
        public int EnergiaDisponivel { get; set; }
        public int Intensidade { get; set; }
        public bool PresencaDetectada { get; set; }
        public bool SensorPresenca { get; set; }
        
        public decimal EconomiaEnergia { get; set; }
        public int CargaBateriaSolar { get; set; }
        public DateTime UltimaManutencao { get; set; }
        public List<string> RelatorioEconomia { get; set; } = new List<string>();
        public List<string> RelatorioPreditivo { get; set; } = new List<string>();
        
        public PosteDeLuz()
        {
            RelatorioEconomia = new List<string>();
            RelatorioPreditivo = new List<string>();
            UltimaManutencao = DateTime.Now;
        }
    }
}