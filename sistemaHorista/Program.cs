// See https://aka.ms/new-console-template for more information
using SistemaHorista;

// Console.WriteLine("Hello, World!");

/*
Enunciado do problema

Considere um sistema para pagamento de horistas (pessoas que trabalham por hora).
As entradas e saídas são marcadas com um TimeOnly (Somente Hora).
O tempo trabalhado é o TimeSpan (Tempo Decorrido).
As horas inteiras nos dias de semana contam o valor hora normalmente.
Horas aos sábados contam 50% mais (* 1.5).
Horas aos domingos contam 100% mais (o dobro).
Os pagamentos são semanais.
Valores abaixo de 500 reais serão depositados no primeiro dia útil.
A partir de 500 e abaixo de 1000 tomam três dias úteis.
A partir de 1000 reais tomam cinco dias úteis.
Mais de 44 horas vão para o banco de horas e não são pagos.

*/

Console.WriteLine("Executando 10 casos de teste para CalculadoraSalario...\n");

DateOnly dataRef = new(2025, 10, 3); // referência usada em todos os testes (3/10/2025 - sexta)

void ExibirResultado(int caso, SemanaTrabalho semana, ResultadoPagamento resEsperado)
{
    var res = CalculadoraSalario.Salario(semana);
    Console.WriteLine($"Caso {caso}: Horista='{semana.Horista}', ValorHora={semana.ValorHora} DataRef={semana.DataReferencia:yyyy-MM-dd}");
    Console.WriteLine($"  Entrada(s):");
    foreach (var e in semana.Entradas)
        Console.WriteLine($"    {e.Data:yyyy-MM-dd} {e.Entrada:HH:mm} -> {e.Saida:HH:mm} (dur: {(CalculadoraSalarioDuracao(e.Entrada,e.Saida)).TotalHours} h)");

    Console.WriteLine($"  Resultado esperado -> ValorPago={resEsperado.ValorPago:F2}, HorasPagas={resEsperado.HorasPagas}, BancoHoras={resEsperado.BancoDeHoras.TotalHours:F2}h, DataDeposito={resEsperado.DataDeposito:yyyy-MM-dd}");
    Console.WriteLine($"  Resultado obtido   -> ValorPago={res.ValorPago:F2}, HorasPagas={res.HorasPagas}, BancoHoras={res.BancoDeHoras.TotalHours:F2}h, DataDeposito={res.DataDeposito:yyyy-MM-dd}");
    Console.WriteLine();
}

TimeSpan CalculadoraSalarioDuracao(TimeOnly entrada, TimeOnly saida)
{
    if (saida >= entrada) return saida - entrada;
    return saida.AddHours(24) - entrada;
}

/*
  Caso 1: Segunda, 08:00-17:00 (9h), ValorHora 10
    -> paga 9h * 10 = 90, banco 0, depósito 1 dia útil -> 2025-10-06
*/
{
    var s = new SemanaTrabalho("Caso1", 10m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,6), new TimeOnly(8,0), new TimeOnly(17,0)));
    var esperado = new ResultadoPagamento { ValorPago = 90m, HorasPagas = 9, BancoDeHoras = TimeSpan.Zero, DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(1, s, esperado);
}

/*
  Caso 2: Sábado, 08:00-12:30 (4h30), ValorHora 20
    -> paga 4h * 1.5 * 20 = 120, banco 0.5h, depósito 1 dia útil -> 2025-10-06
*/
{
    var s = new SemanaTrabalho("Caso2", 20m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,4), new TimeOnly(8,0), new TimeOnly(12,30)));
    var esperado = new ResultadoPagamento { ValorPago = 120m, HorasPagas = 4, BancoDeHoras = TimeSpan.FromMinutes(30), DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(2, s, esperado);
}

/*
  Caso 3: Domingo, 10:00-18:00 (8h), ValorHora 15
    -> paga 8h * 2 * 15 = 240, banco 0, depósito 1 dia útil -> 2025-10-06
*/
{
    var s = new SemanaTrabalho("Caso3", 15m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(10,0), new TimeOnly(18,0)));
    var esperado = new ResultadoPagamento { ValorPago = 240m, HorasPagas = 8, BancoDeHoras = TimeSpan.Zero, DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(3, s, esperado);
}

/*
  Caso 4: Semana com 45 horas (9h por dia seg-sex = 45h), ValorHora 10
    -> paga até 44h = 440, banco 1h, depósito 1 dia útil -> 2025-10-06
*/
{
    var s = new SemanaTrabalho("Caso4", 10m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,6), new TimeOnly(9,0), new TimeOnly(18,0))); // 9h
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,7), new TimeOnly(9,0), new TimeOnly(18,0))); // 9h
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,8), new TimeOnly(9,0), new TimeOnly(18,0))); // 9h
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,9), new TimeOnly(9,0), new TimeOnly(18,0))); // 9h
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,10), new TimeOnly(9,0), new TimeOnly(18,0))); // 9h => total 45
    var esperado = new ResultadoPagamento { ValorPago = 440m, HorasPagas = 44, BancoDeHoras = TimeSpan.FromHours(1), DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(4, s, esperado);
}

/*
  Caso 5: Sábado 08:00-13:45 (5h45) + Domingo 09:00-11:30 (2h30), ValorHora 30
    -> paga 5h *1.5*30 = 225  + 2h *2*30 = 120 -> total 345, banco 45min+30min = 1h15, depósito 1 dia útil -> 2025-10-06
*/
{
    var s = new SemanaTrabalho("Caso5", 30m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,4), new TimeOnly(8,0), new TimeOnly(13,45)));
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(9,0), new TimeOnly(11,30)));
    var esperado = new ResultadoPagamento { ValorPago = 345m, HorasPagas = 7, BancoDeHoras = TimeSpan.FromMinutes(75), DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(5, s, esperado);
}

/*
  Caso 6: Travessia meia-noite: Sábado 22:00 -> Domingo 02:30 (4h30), ValorHora 25
    -> toda entrada é marcada como sábado (multiplicador 1.5) -> paga 4h *1.5*25 = 150, banco 30min, depósito 1 dia útil -> 2025-10-06
*/
{
    var s = new SemanaTrabalho("Caso6", 25m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,4), new TimeOnly(22,0), new TimeOnly(2,30)));
    var esperado = new ResultadoPagamento { ValorPago = 150m, HorasPagas = 4, BancoDeHoras = TimeSpan.FromMinutes(30), DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(6, s, esperado);
}

/*
  Caso 7: ValorPago exato 500 -> exige 3 dias úteis
    Entradas: Seg 10h, Ter 10h, Qua 5h = 25h; ValorHora 20 => 25*20 = 500
    DataDeposito esperada (3 dias úteis a partir de dataRef) = 2025-10-08
*/
{
    var s = new SemanaTrabalho("Caso7", 20m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,6), new TimeOnly(8,0), new TimeOnly(18,0))); // 10h
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,7), new TimeOnly(8,0), new TimeOnly(18,0))); // 10h
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,8), new TimeOnly(8,0), new TimeOnly(13,0))); // 5h
    var esperado = new ResultadoPagamento { ValorPago = 500m, HorasPagas = 25, BancoDeHoras = TimeSpan.Zero, DataDeposito = new DateOnly(2025,10,8) };
    ExibirResultado(7, s, esperado);
}

/*
  Caso 8: ValorPago > 1000 -> exige 5 dias úteis
    Criamos 7 entradas no Domingo totalizando 44h (6h+6h+6h+6h+6h+6h+8h = 44h), ValorHora 12, multiplicador 2
    Valor = 44 * 12 * 2 = 1056 -> depósito 5 dias úteis = 2025-10-10
*/
{
    var s = new SemanaTrabalho("Caso8", 12m, dataRef);
    // sete fatias no domingo - mesmo dia, sequenciais para o teste
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(0,0), new TimeOnly(6,0))); //6
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(6,0), new TimeOnly(12,0))); //6
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(12,0), new TimeOnly(18,0))); //6
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(18,0), new TimeOnly(0,0))); //6 (through midnight not needed here)
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(1,0), new TimeOnly(7,0))); //6 (overlap ok for test)
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(7,0), new TimeOnly(13,0))); //6
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,5), new TimeOnly(13,0), new TimeOnly(21,0))); //8
    var esperado = new ResultadoPagamento { ValorPago = 1056m, HorasPagas = 44, BancoDeHoras = TimeSpan.Zero, DataDeposito = new DateOnly(2025,10,10) };
    ExibirResultado(8, s, esperado);
}

/*
  Caso 9: Exato 44 horas, todas pagas, sem banco
    Montagem: total 44h em dias úteis, ValorHora 10 -> Valor = 440, depósito 1 dia útil
*/
{
    var s = new SemanaTrabalho("Caso9", 10m, dataRef);
    // distribuir 44h (ex.: 5 dias: 9,9,9,9,8 = 44)
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,6), new TimeOnly(9,0), new TimeOnly(18,0))); //9
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,7), new TimeOnly(9,0), new TimeOnly(18,0))); //9
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,8), new TimeOnly(9,0), new TimeOnly(18,0))); //9
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,9), new TimeOnly(9,0), new TimeOnly(18,0))); //9
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,10), new TimeOnly(9,0), new TimeOnly(17,0))); //8
    var esperado = new ResultadoPagamento { ValorPago = 440m, HorasPagas = 44, BancoDeHoras = TimeSpan.Zero, DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(9, s, esperado);
}

/*
  Caso 10: Entrada de 30 minutos (0h30) em dia útil, ValorHora 100
    -> horas inteiras = 0 -> tudo para banco (0.5h), ValorPago = 0, depósito 1 dia útil
*/
{
    var s = new SemanaTrabalho("Caso10", 100m, dataRef);
    s.AdicionarEntrada(new EntradaDia(new DateOnly(2025,10,6), new TimeOnly(8,0), new TimeOnly(8,30)));
    var esperado = new ResultadoPagamento { ValorPago = 0m, HorasPagas = 0, BancoDeHoras = TimeSpan.FromMinutes(30), DataDeposito = new DateOnly(2025,10,6) };
    ExibirResultado(10, s, esperado);
}

Console.WriteLine("Testes executados. Verifique saída para comparar esperado vs obtido.");
