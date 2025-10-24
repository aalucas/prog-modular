using System;
using System.Collections.Generic;
using SistemaHorista;
namespace SistemaHorista;

public record class Semana
{
    public decimal valorHora { get; init; }
    public int DiasTrabalhados { get; init; }
    public decimal ValorTotal => valorHora * DiasTrabalhados;


}
