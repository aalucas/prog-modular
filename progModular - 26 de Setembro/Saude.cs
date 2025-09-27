// Módulo do C# 
// Criando um IMC

// Escopo: Criar uma Classe, que é justamente o MÓDULO
// C# Nos indica a Criar uma Classe

// Equivale ao Export do JS
// o "public" torna a classe visível fora do arquivo
// A partir chamaremos de Métodos
// O ideal a criar apenas uma Classe por Arquivo!

/*
    "Fórmula" da Criação de Classe

    class nomeClasse
    {
        ... Código
    }

    "Fórmula" da Criação de Métodos
    * Método privado -> Só funciona Dentro da Classe, devido ao seu Escopo
    * Método public -> Funciona fora da Classe

    public static class nomeClasse
    {
        ... Código
    }

*/

public static class Saude
{
    // Criando os Métodos
    // Métodos são funções que estão inseridas
    // Dentro de Classes
    // OBS -> O Retorno do Método é OBRIGATÓRIO
    // Além disso, em Linguagens Tipadas, as regras são mais ESTRITAS!
    public static double Imc(double Peso, double Altura)
    {
        return Peso / Math.Pow(Altura, 2);
    }
}