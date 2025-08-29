console.log("Hello World");

// Introdução as Funções

// Existem vários modos - paradigmas - de programação, mas vamos focar nas funções (módulos)
// Um módulo constitui uma parte reutilizável do Software (o tamnho da parte)!

// Nas plataformas e linguagens de prog em geral, temos alguns _construtos_ para declarar módulos!,
// ex.: funções, procedures, rotinas, classes, enumerados, interfaces, pacotes, namespaces e afins.

// Pq declarar uma função e criar códigos reutilizáveis?

// Objetivo obter o plural de uma palavra
// 1. Sem função => Código problemático, pois sua refatoração é trabalhosa e pouco dinâmica
var palavra = "gato";
var plural;
if(palavra[palavra.length - 1] == 'r'){ // .... Esta é a lógica
    plural = palavra + 'es';
} else {
    plural = palavra + 's';
} // ...
console.log(plural);

//Especificação da função "pluralizar"
// Entrada com uma Palavra no singular
// Sair com uma Palavra no Plural

// 2. Com Função => Código Idôneo, pois além de dinâmico, tem fácil manutenção
function pluralizar(word){ // function nomeFuncao (parametro){ ... códigos ... }
    var plur;
    if(word[word.length - 1] == 'r'){
        plur = word + 'es';
    } else if(word[word.length - 1] == 'ao'){
        plur = word + 'oes';
    } else {
        plur = word + 's';
    }
    return plur // Efeito Colateral de Saída
}

console.log(pluralizar('argumento'));