// Um registro -> Traz a ideia de um Substantivo
// Pessoa, Pagamento, Veículo, ...
public record class Pessoa
{
    // Propriedades
    // As propriedades Definem, nesse caso, Pessoa
    public string Nome { get; set; }
    public int Idade { get; set; }
    public Double Altura { get; set; }
    public Double Peso { get; set; }
}
