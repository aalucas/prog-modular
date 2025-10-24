using System;
using System.Collections.Generic;
using System.Linq;


namespace SistemaHorista
{
    public record EntradaDia(DateOnly Data, TimeOnly Entrada, TimeOnly Saida);

    public class SemanaTrabalho
    {
        public string Horista { get; init; } = "";
        public decimal ValorHora { get; init; }
        public DateOnly DataReferencia { get; init; } = DateOnly.FromDateTime(DateTime.Today);

        readonly List<EntradaDia> _entradas = new();
        public IReadOnlyList<EntradaDia> Entradas => _entradas.AsReadOnly();

        public SemanaTrabalho() { }

        public SemanaTrabalho(string horista, decimal valorHora, DateOnly dataReferencia)
        {
            Horista = horista ?? "";
            ValorHora = valorHora;
            DataReferencia = dataReferencia;
        }

        public void AdicionarEntrada(EntradaDia entrada)
        {
            if (entrada is null) throw new ArgumentNullException(nameof(entrada));
            if (_entradas.Count >= 7) throw new InvalidOperationException("Máximo de 7 entradas por semana.");
            _entradas.Add(entrada);
        }

        public void AdicionarEntradas(IEnumerable<EntradaDia> entradas)
        {
            if (entradas is null) throw new ArgumentNullException(nameof(entradas));
            foreach (var e in entradas) AdicionarEntrada(e);
        }
    }

    public record ResultadoPagamento
    {
        public decimal ValorPago { get; init; }
        public double HorasPagas { get; init; }
        public TimeSpan BancoDeHoras { get; init; }
        public DateOnly DataDeposito { get; init; }
        public double HorasTotais { get; init; }
    }

    public static class CalculadoraSalario
    {
        const double LIMITE_PAGAVEL = 44.0;

        // Calcula salário conforme regras do exercício.
        public static ResultadoPagamento Salario(SemanaTrabalho semana)
        {
            if (semana is null) throw new ArgumentNullException(nameof(semana));
            if (semana.ValorHora < 0) throw new ArgumentOutOfRangeException(nameof(semana.ValorHora));

            var entradas = semana.Entradas
                .OrderBy(e => e.Data)
                .ThenBy(e => e.Entrada)
                .ToList();

            double acumuladoHorasPagas = 0.0;
            TimeSpan banco = TimeSpan.Zero;
            decimal totalValor = 0m;
            double horasTotais = 0.0;

            foreach (var e in entradas)
            {
                var duracao = DuracaoEntre(e.Entrada, e.Saida);
                horasTotais += duracao.TotalHours;

                // Apenas horas inteiras contam para pagamento (floor). Minutos/segundos vão para banco.
                int horasInteiras = (int)Math.Floor(duracao.TotalHours);
                var minutosRestantes = duracao - TimeSpan.FromHours(horasInteiras);

                double multiplicador = MultiplicadorPorDia(e.Data.DayOfWeek);

                if (acumuladoHorasPagas >= LIMITE_PAGAVEL)
                {
                    // tudo para banco (inclui minutos)
                    banco += duracao;
                    continue;
                }

                var restantePagavel = Math.Max(0.0, LIMITE_PAGAVEL - acumuladoHorasPagas);

                if (horasInteiras <= restantePagavel + 1e-9)
                {
                    // paga todas as horas inteiras; minutos -> banco
                    acumuladoHorasPagas += horasInteiras;
                    totalValor += (decimal)horasInteiras * (decimal)multiplicador * semana.ValorHora;
                    if (minutosRestantes > TimeSpan.Zero) banco += minutosRestantes;
                }
                else
                {
                    // paga parte inteira até completar 44h; resto (horas inteiras remanescentes + minutos) -> banco
                    int horasApenasPagaveis = (int)Math.Floor(restantePagavel);
                    if (horasApenasPagaveis > 0)
                    {
                        acumuladoHorasPagas += horasApenasPagaveis;
                        totalValor += (decimal)horasApenasPagaveis * (decimal)multiplicador * semana.ValorHora;
                    }

                    var horasNaoPagas = horasInteiras - horasApenasPagaveis;
                    if (horasNaoPagas > 0) banco += TimeSpan.FromHours(horasNaoPagas);
                    if (minutosRestantes > TimeSpan.Zero) banco += minutosRestantes;
                }
            }

            var valorArredondado = Decimal.Round(totalValor, 2, MidpointRounding.AwayFromZero);
            var diasUteis = DiasUteisParaDeposito(valorArredondado);
            // considera a data referência + 1 dia como início para contagem (fluxo: pagamento na próxima data útil após fechamento)
            var dataDeposito = AdicionarDiasUteis(semana.DataReferencia.AddDays(1), diasUteis);

            return new ResultadoPagamento
            {
                ValorPago = valorArredondado,
                HorasPagas = Math.Round(acumuladoHorasPagas, 2),
                BancoDeHoras = banco,
                DataDeposito = dataDeposito,
                HorasTotais = Math.Round(horasTotais, 2)
            };
        }

        static TimeSpan DuracaoEntre(TimeOnly entrada, TimeOnly saida)
        {
            if (saida >= entrada) return saida - entrada;
            // atravessou meia-noite
            return saida.AddHours(24) - entrada;
        }

        static double MultiplicadorPorDia(DayOfWeek dia) =>
            dia switch
            {
                DayOfWeek.Saturday => 1.5,
                DayOfWeek.Sunday => 2.0,
                _ => 1.0
            };

        static int DiasUteisParaDeposito(decimal valor)
        {
            if (valor < 500m) return 1;
            if (valor < 1000m) return 3;
            return 5;
        }

        static DateOnly AdicionarDiasUteis(DateOnly inicio, int diasUteis)
        {
            if (diasUteis <= 0) return inicio;
            var d = inicio;
            int adicionados = 0;
            while (adicionados < diasUteis)
            {
                d = d.AddDays(1);
                if (EhDiaUtil(d)) adicionados++;
            }
            return d;
        }

        static bool EhDiaUtil(DateOnly data)
        {
            var dow = data.DayOfWeek;
            return dow != DayOfWeek.Saturday && dow != DayOfWeek.Sunday;
        }
    }
}