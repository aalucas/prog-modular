// See https://aka.ms/new-console-template for more information

// Program.cs -> Equivale ao "index.js"

// console.log("Hello, World");
// System.out.println("Hello, World);
// print("Hello, World");
Console.WriteLine("Hello, World!"); // dotnet run --> Executa o código pelo Terminal
// equivale ao "node ." ou "node.js"

// Criando uma Variáve que guardará o "peso"
// O que muda de JS para C#?
// Em C# as variáveis são tipadas e são pré-definidos
// Além disso, as variáveis em C# possuem escopo de Bloco/Função igual ao Js

// int -> integer -> inteiro -> 32 bits
// 2³¹ -- 2³¹ - 1

// double Peso = 78;

// Declarando as Variáveis
var peso = 78;
var altura = 1.70;

// Chamando a função através de uma variável
var imc = Saude.Imc(peso, altura);

// Concatenando Strings
// Para cada "+", será criada uma nova String
// Nesse caso, 5 Strings
// Pode defazar a performace do algoritmo, além de desperdiçar bytes de memória
// Em aplicações de larga escala, esse pensamento pode ser útil
Console.WriteLine("Para o peso " + peso + " e altura " + altura + " ... " + " o resultado do IMC será de " + imc);

// Algumas Ling suportam a Interpolação de Strings -> Colocar Variáveis dentro da String
// $ -> String Interpolada
// Gera apenas uma String, a fim de ganhar mais performace 
Console.WriteLine($"Para o Peso {peso} e altura {altura}, o IMC será de {imc}");

// Declarando os Parâmetros direto do Console
Console.WriteLine($"Para o Peso 85 e Altura 1.68, o IMC será de {Saude.Imc(85, 1.68)}");

// Sugestão de Exercício
// Implementar os Códigos em JavaScript em C#