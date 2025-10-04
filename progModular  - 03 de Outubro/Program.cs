// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!"); Teste


// Exemplo com Array
// Array -> Arranjo -> Vetor
// Array de Double => 64 bits

// Primeira forma de fazer um Array
double[] Altura = new double[4];
Altura[0] = 1.70;
Altura[1] = 1.72;
Altura[2] = 1.74;
Altura[3] = 1.82;

// Segunda forma de fazer um Array
double[] pesos = [76.4, 87.4, 56.7, 65.1];
String[] pessoas = ["Pedro", "João", "Ana", "Maria"];
int[] idade = [43, 23, 18, 67];

// OBS -> Os Arrays são HOMOGÊNEOS
// Estruturam dados de apenas um tipo
// Uma coisa que é POSSÍVEL, mas que não é recomendada
Object[] objetos = [1, "string", true]; // Array de Objeto!

// Imprimindo o Array - alturas - com for
for (int i = 0; i < 4; i++)
{
    Console.WriteLine("alturas [" + i + "]: " + Altura[i]);
}

Console.WriteLine(); // Quebra de Linha

// Imprimindo o Array - Pesos -  com for
for (int i = 0; i < 4; i++)
{
    Console.WriteLine("pesos [" + i + "]: " + pesos[i]);
}
Console.WriteLine(pesos.Length); // 4 -> Tamanho do Array
Console.WriteLine(); // Quebra de Linha

Console.WriteLine("Imprimindo de Forma Interpolada");
for (int i = 0; i < 4; i++)
{
    Console.WriteLine($"{pessoas[i]} altura {Altura[i]} peso {pesos[i]}");
}

Console.WriteLine(); // Quebra de Linha

// criando Instâncias
Pessoa p1 = new Pessoa // instanciar / inicializar
{
    Nome = "Pedro",
    Idade = 43,
    Peso = 76.4,
    Altura = 1.70
};
Console.WriteLine(p1); // Imprimindo a Instância
Console.WriteLine(p1.Idade); // Imprimindo apenas a Idade da Instância

// Instânciando Várias Pessoas
Pessoa[] galera = new Pessoa[10];
galera[0] = new Pessoa
{
    // Dados...
};
// E assim sucessivamente...
// Não é Recomendado

// Listas
List<Pessoa> povo = [];
Console.WriteLine(povo.Count); // 0
povo.Add(new Pessoa
{
    Nome = "Pedro",
    Idade = 43,
    Peso = 76.4,
    Altura = 1.70
});
Console.WriteLine(povo[0]);

// Para cada elemento
// forEach
foreach (var person in povo)
{
    Console.WriteLine($"Pessoa {person}");
}
// equivalente -> for(int i = 0; i < povo.Count; i++){ Console.WriteLine($"Pessoa {povo[i]}") };

// Outro Exemplo
Console.WriteLine(Saude.Imc(povo[0]));
Console.WriteLine(Saude.Imc(povo[1]));
var resultado = Saude.Imc(new Pessoa
{
    Nome = "Márcio",
    Altura = 1.72,
    Idade = 48,
    Peso = 80.3
});
Console.WriteLine($"O IMC: {resultado.Imc} SITUAÇÃO: {resultado.Situacao}"); // Retornando a Tupla