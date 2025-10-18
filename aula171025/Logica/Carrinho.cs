namespace Logica;
using Modelo;

// Nem toda Classe de Logica é Estática
// Tudo está ligado com os Paradigmas da Programação
// Nesse caso, o Paradigma é Procedural
// programação procedural é um paradigma de programação que ORGANIZA o código 
// em uma sequência de instruções, dividindo-o em blocos chamados procedimentos ou funções
// Por isso o nome Procedural

public static class Carrinho
{
    // Assinatura
    // Trata-se daquilo que ela vai "devolver"
    public static(byte Parcelas, decimal ValorParcela, decimal ValorTotal) CalcularCompra(Produto p)
    {
        var ValorTotal = p.ValorTotal; 
        byte Parcelas = 1;

        if(ValorTotal >= 500m)
        {
            Parcelas = 10;
        }  
        else if(ValorTotal >= 200m)
        {
            Parcelas = 5;
        }

        var ValorParcela = ValorTotal / Parcelas;

        return (Parcelas, ValorParcela, ValorTotal);
    }
}