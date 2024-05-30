using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafiofundamentos.Models
{
    public class Estacionamento
    {
        private List<Veiculo> veiculos = new List<Veiculo>();
        private decimal precoPorHora;

        public Estacionamento(decimal precoPorHora)
        {
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(string placa)
        {
            var veiculo = new Veiculo
            {
                Placa = placa,
                HoraEntrada = DateTime.Now
            };
            veiculos.Add(veiculo);
            Console.WriteLine("Veículo adicionado com sucesso.");
        }

        public void RemoverVeiculo(string placa)
        {
            var veiculo = veiculos.FirstOrDefault(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if (veiculo != null)
            {
                var horasEstacionado = (DateTime.Now - veiculo.HoraEntrada).TotalHours;
                var valorCobrado = Math.Ceiling(horasEstacionado) * precoPorHora;
                veiculos.Remove(veiculo);
                Console.WriteLine($"Veículo removido. Valor cobrado: {valorCobrado:C}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa}, Hora de entrada: {veiculo.HoraEntrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
