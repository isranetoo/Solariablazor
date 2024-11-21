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

        // Obtém o estado atual do poste de luz
        public PosteDeLuz ObterPosteDeLuz()
        {
            return _posteDeLuz;
        }

        // Ajusta a iluminação com base na presença detectada
        public void AjustarInteligente()
        {
            if (_posteDeLuz.SensorPresenca)
            {
                _posteDeLuz.PresencaDetectada = true;
                _posteDeLuz.Intensidade = 100; // Iluminação máxima
                _posteDeLuz.EconomiaEnergia = 0; // Nenhuma economia quando a intensidade está no máximo
            }
            else
            {
                _posteDeLuz.PresencaDetectada = false;
                _posteDeLuz.Intensidade = 30; // Iluminação reduzida
                _posteDeLuz.EconomiaEnergia = 50; // Economia de 50% quando a intensidade é reduzida
            }

            // Adiciona ao relatório de economia
            _posteDeLuz.RelatorioEconomia.Add($"Ajuste Inteligente: {DateTime.Now} - Intensidade: {_posteDeLuz.Intensidade}% - Economia: {_posteDeLuz.EconomiaEnergia}%");
        }

        // Monitora a carga da bateria solar
        public void MonitorarBateria()
        {
            _posteDeLuz.CargaBateriaSolar = Math.Max(0, _posteDeLuz.CargaBateriaSolar - 10); // Simula a diminuição da carga da bateria

            // Se a carga da bateria ficar abaixo de 20%, gera um alerta
            if (_posteDeLuz.CargaBateriaSolar < 20)
            {
                _posteDeLuz.RelatorioPreditivo.Add($"Alerta Bateria Baixa: {DateTime.Now} - Carga: {_posteDeLuz.CargaBateriaSolar}%");
            }
        }

        // Realiza a manutenção preventiva do poste de luz
        public void RealizarManutencao()
        {
            _posteDeLuz.UltimaManutencao = DateTime.Now; // Atualiza a data da última manutenção
            _posteDeLuz.RelatorioPreditivo.Add($"Manutenção Preventiva Realizada: {_posteDeLuz.UltimaManutencao}");
        }
    }
}
