import { substring, formatarCpf } from "./substr.js";

// Aula de Programação Modular - TADS
// 05 - 09 - 2025
console.log("teste"); // Teste -> node index.js || node .
// Utilize ' Ctrl + "" + p ' para usaro Quokka Js para executar o código

console.log("🙂".length); // 2 

// UTF-8 => é um padrão de codificação de caracteres de 
// comprimento variável que representa qualquer caractere 
// Unicode usando entre um e quatro bytes


console.log(substring("Hello World", 0, 5)); // Hello
console.log(substring("Hello World", 0, 8)); // Hello Wo
console.log(substring("Hello World", 0, 9)); // Hello Wor
console.log(substring("Hello World", 0, 11)); // Hello World


console.log(formatarCpf('12345678901')); // 123.456.789-01