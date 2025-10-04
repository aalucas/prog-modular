// Classe Estática -> Mão é ED
public static class Saude
{
    // Fazer uma Imc
    // Uma tupla
    public static (double Imc, string Situacao) Imc(Pessoa pessoa)
    {
        double imc = pessoa.Peso / Math.Pow(pessoa.Altura, 2);
        string situacao;

        if (imc < 17) situacao = "Muito Abaixo";
        else if (imc < 18.5) situacao = "Abaixo";
        else if (imc < 25) situacao = "Peso Normal";
        else if (imc < 30) situacao = "Sobrepeso";
        else if (imc < 35) situacao = "Obesidade I";
        else if (imc < 40) situacao = "Obesidade II";
        else situacao = "Obesidade III";

        return (Imc: imc, Situacao: situacao);
    }
}
