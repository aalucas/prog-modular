// console.log("Hello World"); 

import {contaVogais, contaConsoantes} from "./alfabeto.js";
import {contaCaractere} from "./alfabeto.js";
import {eliminar} from "./alfabeto.js";
import {tifanofaufoAlfabeto} from "./tifanofaufo.js";

let s = "ifrs";
let vogais = contaVogais(s);
let consoantes = contaConsoantes(s);

console.log(vogais); // 1
console.log(vogais === 1); // true
console.log(vogais === 2); // false
console.log(consoantes); // 3
console.log(consoantes === 3); // true
console.log(consoantes === 2); // false

console.log(""); // Quebra de linha => Organizar o Terminal
s = 'instituto federal';
console.log(contaVogais(s) === 7); // true
console.log(contaConsoantes(s) === 9); // false

console.log(""); // Quebra de linha => Organizar o Terminal
console.log(contaVogais("informatica") === 4); // true
console.log(contaConsoantes("informatica") === 6); // false

console.log(""); // Quebra de linha => Organizar o Terminal
console.log(contaVogais("computação") === 4); // true
console.log(contaConsoantes("computação") === 4); // false

console.log(""); // Quebra de linha => Organizar o Terminal

let umaString = 'uma string de teste';
let umCaractere = 's';
console.log(contaCaractere(umaString, umCaractere)); // 2
console.log(contaCaractere(umaString, umCaractere) === 2); // true

console.log(""); // Quebra de linha => Organizar o Terminal

console.log(contaCaractere(umaString, 'e') === 3); // true
console.log(contaCaractere(umaString, 'o') === 0); // true

console.log(""); // Quebra de linha => Organizar o Terminal

console.log(contaCaractere('', ' ')  === 0); // true
console.log(contaCaractere(' ', ' ') === 1); // true

console.log(""); // Quebra de linha => Organizar o Terminal
console.log(contaCaractere('ABC', 'b') === 0); // true
console.log(contaCaractere('ABC', 'B') === 1); // true
console.log(contaCaractere('POO', 'O') === 2); // true

console.log("");

let str1 = 'aula';
let str2 = eliminar(str1, 'a'); // Eliminando o 'a' de "aula"
console.log(str1 === 'aula'); // true
console.log(str2 === 'ul'); // true

console.log("");

let str3 = eliminar(str1, str2);
console.log(str3 === 'aa'); // false

console.log("");
// Eliminando os Caracteres independete da ordem

console.log(eliminar('texto de teste', 'tx')); // eo de ese
console.log(eliminar('palavra', 'rlv')); // paaa
console.log(eliminar('exemplo', 'ertyui')); // xmplo
console.log(eliminar('exemplo', '')); // exemplo
console.log(eliminar('TESTE', 'e')); // TESTE
console.log(eliminar('teste', 'eeeeee')); // tst
console.log(eliminar('POO', 'OP')); // ''
console.log(eliminar('', 'abc')); // ''
console.log(eliminar('', '') === ''); // ''
console.log(eliminar('aabbbbbccccc', 'cc')); // aabbbbb
console.log(eliminar('aabbbbbccccc', 'abbc')); // ''

console.log("");
console.log(tifanofaufoAlfabeto("lucas")); 



