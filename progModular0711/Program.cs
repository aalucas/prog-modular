// See https://aka.ms/new-console-template for more information

// Usings: trazem tipos/funcionalidades de namespaces para uso direto.
// Nem todos os usings são necessários aqui; 'System' costuma ser usado para Console.
// 'System.Security.Cryptography.X509Certificates' não é utilizado neste exemplo — pode ser removido.
using System.Security.Cryptography.X509Certificates;
using System.Text; // usado no trecho comentado com StringBuilder

// ----------------------------------------------------
// INÍCIO DO PROGRAMA
// ----------------------------------------------------

Console.WriteLine("Hello, World!");

// Comentários explicativos rápidos sobre tipos:
// - Tipo de Valor (primitivo): armazenado diretamente na variável (ex: int, double, struct).
// - Tipo Referenciado (objeto): a variável guarda uma referência para o objeto na heap (ex: classes, StringBuilder).

// ---------------------------
// Boxing and Unboxing (comentário)
// ---------------------------
// Observação: "Boxing" é quando um ValueType (ex: int) é colocado dentro de um object (caixa).
// No seu exemplo abaixo você está criando instâncias de 'Numero', que é uma classe -> tipo referência.
// Portanto isso **não** é boxing. (Boxing/Unboxing acontece com tipos valor -> object).

// Cria um objeto do tipo Numero (classe — tipo referência) e já inicializa o campo Valor = 5.
// Como é uma classe, a variável 'x' guarda uma referência para o objeto na heap.
Numero x = new Numero { Valor = 5 };

// Atribuição de referência: y passa a apontar para o mesmo objeto que x.
// Não ocorre cópia do conteúdo; ambos referenciam a mesma instância.
Numero y = x;

// Comentário original: "Isolamento do que há no Program.cs e no Teste.cs"
// -> lembrete: código pode estar distribuído em diferentes arquivos; em runtime as referências funcionam igual.

// Chamada de método que altera o objeto recebido.
// Teste.Dobro(Numero) (implementado anteriormente) modifica internamente num.Valor.
// Isso é um exemplo claro de **efeito colateral**: o estado do objeto referenciado é alterado.
Teste.Dobro(x); // após essa chamada, o objeto referenciado por x e y teve Valor dobrado.

// Como x e y referenciam a mesma instância, ambos veem a alteração — imprimem o novo Valor.
Console.WriteLine(x.Valor);
Console.WriteLine(y.Valor);

// Exemplo com DateOnly (struct — tipo valor).
// DateOnly.FromDateTime retorna uma instância (cópia) contendo apenas a data (sem hora).
DateOnly hoje = DateOnly.FromDateTime(DateTime.Now);
Console.WriteLine(hoje);

// Chamada usando ref: Amanha(ref DateOnly)
// IMPORTANTE: no seu Teste original o método foi nomeado Amanha (sem acento).
// No Program original você usou 'Amanhã' com acento — isso gera erro de compilação.
// Aqui usamos exatamente o mesmo identificador do Teste: Amanha (sem acento).
// Como DateOnly é struct (value type), sem 'ref' a chamada receberia uma cópia.
// Com 'ref' estamos passando uma referência para a variável original — o método pode alterar 'hoje'.
Teste.Amanha(ref hoje); // altera o valor da variável 'hoje' no chamador (efeito colateral intencional)

Console.WriteLine(hoje); // agora mostra o dia seguinte

// Exemplo de 'out' — o método Hoje(out DateOnly data) atribui data antes de retornar.
// 'out' é usado para devolver valores adicionais; a variável passada não precisa ter sido inicializada.
DateOnly data2;
Teste.Hoje(out data2);
Console.WriteLine(data2);

// ---------------------------
// Entrada do usuário e TryParse
// ---------------------------
Console.Write("Digite um número: ");

// Console.ReadLine() lê uma linha do usuário; pode retornar null em alguns contextos (considere checar).
string valor = Console.ReadLine();

// Declarar a variável onde o resultado do TryParse será armazenado.
// 'valorInteiro' será preenchido pelo TryParse via parâmetro out se a conversão for bem-sucedida.
int valorInteiro;

// int.TryParse tenta converter a string em inteiro.
// - retorna true/false indicando sucesso;
// - se true, 'valorInteiro' contém o inteiro convertido.
// - usa 'out' para devolver o valor convertido sem lançar exceção (bom para I/O).
if (int.TryParse(valor, out valorInteiro))
{
    // Função pura na expressão (valorInteiro + 1) — não altera valorInteiro em si.
    // Aqui só exibimos o resultado. Ainda há efeito colateral: escrita no console.
    Console.WriteLine("O novo valor é " + (valorInteiro + 1));
}
else
{
    // Interpolação de string com escape para mostrar aspas: usamos $"..."
    // Aqui informamos que a string informada não é um inteiro válido.
    Console.WriteLine($"A string \"{valor}\" não é um número inteiro");
}

// ---------------------------
// Trecho comentado: exemplos de comportamento de Value Types e Reference Types
// ---------------------------

/* 
Value Types: são copiados (não há referência)
int x = 5;
int y = x;   // cópia do valor
// x = 5
// y = 5
x++;         // incrementa apenas x
Console.WriteLine(x); // 6
Console.WriteLine(y); // 5

StringBuilder texto1 = new StringBuilder(); // StringBuilder é classe (referência)
texto1.Append("teste");
Console.WriteLine(texto1);

StringBuilder texto2 = texto1; // copia a referência — ambos apontam para o mesmo objeto
Console.WriteLine(texto2);

texto2.Append(", mais um teste");
Console.WriteLine(texto2);

Console.WriteLine(texto1); // texto1 também reflete a alteração (mesma instância)
texto1.Append(". Alguma coisa!");
Console.WriteLine(texto1);
Console.WriteLine(texto2);

// Exemplo avançado: alias por referência (ref local) — pontos avançados, evite sem necessidade
ref int a = ref x;
*/

