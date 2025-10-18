// Classe dos Produtos
// Uma classe traz a ideia de Classificar as coisas
// Isto e, criar um tipo de alguma coisa
// NEsse caso, um TIPO de PRODUTO

namespace Modelo;
public record class Produto
{
    // Propriedades
    public string Descricao{get; set;} = "Desconhecido";
    public decimal Preco{get; set;} = 0.01m;
    // m -> Monetary
    public byte Quantidade{get; set;} = 1;
    // uint -> Inteiros Positivos (É uma alternativa para byte)
    // 1 int = 4 bytes
    public decimal ValorTotal => Preco * Quantidade;
    // Mentalize que "=>" é um Return Simbólico 
    // Uma ideia Mais Simplificada do ValorTotal
    /*
    public decimal ValorTotal{
        get
        {
            return Preco * Quantidade;
        }
    }
    */ 
}