using Solaria.Models;
using System;
using System.Collections.Generic;

namespace Solaria.Services
{
    public class PosteDeLuzService
    {
        private static PosteDeLuz _posteDeLuz = new PosteDeLuz
        {
            EnergiaDisponivel = 75,
            Intensidade = 50,
            PresencaDetectada = false,
            SensorPresenca = false,
            EconomiaEnergia = 0,
            CargaBateriaSolar = 100,
            UltimaManutencao = DateTime.Now,
            RelatorioEconomia = new List<string>(),
            RelatorioPreditivo = new List<string>()
        };

        public PosteDeLuz ObterPosteDeLuz()
        {
            return _posteDeLuz;
        }

        public void AjustarInteligente(bool presencaDetectada)
        {
            _posteDeLuz.SensorPresenca = presencaDetectada;

            if (_posteDeLuz.SensorPresenca)
            {
                _posteDeLuz.PresencaDetectada = true;
                _posteDeLuz.Intensidade = 100; 
                _posteDeLuz.EconomiaEnergia = 0; 
            }
            else
            {
                _posteDeLuz.PresencaDetectada = false;
                _posteDeLuz.Intensidade = 30; 
                _posteDeLuz.EconomiaEnergia = 50; 
            }

            _posteDeLuz.RelatorioEconomia.Add($"Ajuste Inteligente: {DateTime.Now} - Intensidade: {_posteDeLuz.Intensidade}% - Economia: {_posteDeLuz.EconomiaEnergia}%");
        }

        public void MonitorarBateria(int cargaBateria)
        {
            _posteDeLuz.CargaBateriaSolar = cargaBateria; 

            if (_posteDeLuz.CargaBateriaSolar < 20)
            {
                _posteDeLuz.RelatorioPreditivo.Add($"Alerta Bateria Baixa: {DateTime.Now} - Carga: {_posteDeLuz.CargaBateriaSolar}%");
            }
        }

        public void RealizarManutencao()
        {
            _posteDeLuz.UltimaManutencao = DateTime.Now; 
            _posteDeLuz.RelatorioPreditivo.Add($"Manutenção Preventiva Realizada: {_posteDeLuz.UltimaManutencao}");
        }
    }
}
