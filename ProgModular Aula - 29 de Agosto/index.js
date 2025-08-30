// Importando a função de math.js
// Modularizando
// Resumo
// import { minhaVariavel, minhaFuncao } from './moduloA.js';
import {potencia} from "./math.js";
import {ultimos, terminaCom, terminaComReduzida, plural} from "./texto.js";

// Teste
console.log("Hello World"); 

// Aula Prog Modular - 29/08/25

// Escrever no Terminal
// npm init -y => package.json

// O arquivo package.json esé o manifesto de um projeto JavaScript 
// no ecossistema Node.js, contendo metadados do projeto

// node index.html  ou  node .
// executa o arquivo buscando o Index!

// Obj => Desmembrar a função em várias funções!

// Devido ao conceito de Encapsulamento a função "potencia" 
// só pode ser executada no arquivo no qual ela foi definida
// Assim, se o código for rodado retornará "potencia is not defined"
// Logo, deve-se "exportar" a função potencia do arquivo "math.js"
// E depois importar a função para o index

console.log(potencia(2,8)); // 256
// String
// Conjunto Ordenado de Caracteres Posicional
// As posições são indexadas a partir do 0
// String é um Array de caracteres
// Ex...
let stringExample = "Hello World";
console.log(stringExample);

var tads = "tecnologia em analise e desenvolvimento de sistemas";
console.log(tads[2]); // Retorna o caractere do indíce "2" => c
console.log(tads.length); // Retorna o Tamanho da String
console.log(tads[100]); // undefined ==> Não exista nada no indíce 100
console.log(tads[tads.length - 1]); // Retornar o último caractere

// Chamando as funções de "texto.js"
console.log(ultimos("palavra", 3)); // vra
console.log(terminaCom("tads", "ads")); // true
console.log(plural("monitor")); // Monitores


