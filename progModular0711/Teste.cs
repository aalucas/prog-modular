using System.Data.Common;

class Numero
{
    // Um campo Público p/ "Valor"
    // Lembre-se que as Classes em C# são Reference Type
    // Logo, as variáveis do tipo numero armazenam um Ponteiro ao Obj Real na Memória Heap

    public int Valor;
}

// Criando Uma classe "Static"
// Indica que ela não pode ser instanciada - Isto é, não se usa "new Teste();"
// Além disso, todos os seus Métodos e membros são acessados diretamente pelo nome da Classe
// Ex ==> Teste.Dobro(num);
static class Teste
{
    // passam os parâmetros por cópia 
    // não têm transparência referencial
    // não é pura 
    // (não depende puramente da entrada, não produz um retorno)
    public static void Dobro(Numero num)
    {
        // ---------------------------------------------------------------
        // MÉTODO 1: void Dobro(Numero num)
        // ---------------------------------------------------------------
        // tal Método recebe um Objeto "Numero" por Referencia Implicita
        // Porque "Numero" é uma Classe, e classes são tipos de referencia
        // Logo, qualquer Modificação dentro de "num.Valor" no método altera o objeto original fora dele
        // 
        // 🧠 CONCEITOS:
        // - Não se trata de um Função Pura
        // - Não tem uma Transparencia Referencial, isto é, não pode ser substituível por seu valor sem mudar o programa. 
        // - produz um EFEITO COLATERAL -> Modificação do Objeto recebido
        // 
        // 🔁 Exemplo:
        // Numero n = new Numero { Valor = 5 };
        // Teste.Dobro(n);
        // Console.WriteLine(n.Valor); // Agr vale 

        num.Valor = num.Valor * 2;
    }

    public static int Dobro(int num)
    {
        // ---------------------------------------------------------------
        // MÉTODO 2: int Dobro(int num)
        // ---------------------------------------------------------------
        // Este método trata-se de uma Função Pura
        // Ela recebe um tipo Primitivo (int) por valor (value type)
        // realiza uma operação, e retorna o resultado - NÃO MODIFICA NADA EXTERNAMENTE
        // 
        // 🧠 CONCEITOS:
        // - Função pura = sem efeitos colaterais.
        // - Possui transparência referencial (pode ser substituída por seu resultado).
        // - Entrada e saída são independentes do ambiente.
        //
        // 🔁 Exemplo:
        // int resultado = Teste.Dobro(5);
        // Console.WriteLine(resultado); // 10

        num = num * 2; // Calculo Interno
        return num; // Retorna o dobro do valor e não modifica o ambiente Externo
    }

    public static void Amanha(ref DateOnly data)
    {
        // ---------------------------------------------------------------
        // MÉTODO 3: void Amanha(ref DateOnly data)
        // ---------------------------------------------------------------
        // Este método usa o modificador 'ref' — ou seja, o parâmetro é passado por REFERÊNCIA explícita.
        // Diferente de uma classe, o tipo DateOnly é um STRUCT (Value Type).
        // Normalmente, structs são copiados, mas com 'ref' passamos uma referência direta ao dado original.
        //
        // Assim, qualquer modificação feita em 'data' dentro do método
        // também é refletida na variável usada na chamada.
        //
        // 🧠 CONCEITOS:
        // - ref = permite alterar a variável original (efeito colateral possível).
        // - AddDays(1) retorna uma nova data (imutável), mas aqui ela é atribuída de volta ao original.
        // - Boa para alterar valores em funções utilitárias, mas perigosa se usada sem cuidado.
        //
        // 🔁 Exemplo:
        // DateOnly hoje = DateOnly.FromDateTime(DateTime.Now);
        // Teste.Amanha(ref hoje);
        // Console.WriteLine(hoje); // mostra o dia seguinte

        data = data.AddDays(1); // Altera o valor da variável original
    }

    public static bool Hoje(out DateOnly data)
    {
        // ---------------------------------------------------------------
        // MÉTODO 4: bool Hoje(out DateOnly data)
        // ---------------------------------------------------------------
        // 'out' significa que a variável passada ainda não tem valor definido,
        // e o método é responsável por atribuí-lo antes de retornar.
        // Ao contrário de 'ref', o valor inicial da variável é irrelevante.
        //
        // 🧠 CONCEITOS:
        // - Útil para retornar múltiplos valores (ou valores calculados).
        // - O método deve obrigatoriamente inicializar o parâmetro 'out'.
        // - Aqui, retorna a data atual.
        //
        // 🔁 Exemplo:
        // Teste.Hoje(out DateOnly hoje);
        // Console.WriteLine(hoje); // mostra a data atual
        data = DateOnly.FromDateTime(DateTime.Now);
        return true;
    }
}

// =====================================================================
// OUTRAS CLASSES E STRUCTS
// =====================================================================

class Aluno
{
    string cpf;
}

class Historico
{
    int matricula;
}

// Struct Nota — exemplo de tipo valor
// Structs são copiados na atribuição, e não compartilham a mesma instância.
struct Nota
{
    int Valor;
}

// =====================================================================
// RESUMO DOS CONCEITOS CHAVE
// =====================================================================

/*
| Conceito                             | Tipo de exemplo                           | Explicação                                                                                                                                            |
| ------------------------------------ | ----------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Classe (`class`)**                 | `Numero`, `Aluno`, `Historico`            | Tipo de **referência** — variáveis armazenam um *ponteiro* para o objeto na memória. Modificações em uma instância afetam todas as referências a ela. |
| **Struct (`struct`)**                | `Nota`, `DateOnly`                        | Tipo de **valor** — copiado quando atribuído a outra variável. Alterações em uma cópia não afetam o original (a menos que seja passado por `ref`).    |
| **Função pura**                      | `int Dobro(int num)`                      | Não tem efeitos colaterais, depende só da entrada e retorna saída previsível.                                                                         |
| **Função impura / efeito colateral** | `void Dobro(Numero num)`                  | Modifica o estado do objeto original (`num.Valor`).                                                                                                   |
| **Transparência referencial**        | `Dobro(int)` tem; `Dobro(Numero)` não tem | Um método tem transparência referencial se pode ser substituído por seu valor sem alterar o comportamento do programa.                                |
| **`ref`**                            | `Amanha(ref DateOnly data)`               | Passa o parâmetro por referência, permitindo alteração direta da variável original.                                                                   |
| **`out`**                            | `Hoje(out DateOnly data)`                 | Serve para devolver valores adicionais (método atribui antes de retornar).                                                                            |
| **`static class`**                   | `Teste`                                   | Classe que não pode ser instanciada; usada para funções utilitárias e agrupamento modular.                                                            |
*/