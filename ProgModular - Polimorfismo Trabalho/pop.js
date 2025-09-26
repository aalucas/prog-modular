export function pop(a){
    let result;
    if(typeof a == "number"){

        // Tratamento de Erro
        // Verificando se o Número é válido
        if(isNaN(a) || !Number.isInteger(a)){
            return null;
        }

        // Se o Número tiver uma tamanho igual a "1"
        if(a.length === 1){
            return a;
        }

        let str = a.toString();

        // Removendo o Último Dígito e imprimindo o Resultado depois da Conversão para Number
        result = str.substring(0, str.length - 1);
        return Number(result);
    }

    if(typeof a == "string"){

        // Tratamento de Erro
        // Verificando se a String está vazia ou é nula
        if(a === null || a.length === 0){
            return null;
        }

        // Tratamento de Erro
        // Se a String tem tamanho "1"
        if(a.length === 1){
            return null;
        }

        // Removendo o Último Caractere e imprimindo o Resultado depois da remoção do último char
        result = a.substring(0, a.length - 1);
        return result;
    }

    if(Array.isArray(a)){

        // Tratamento de Erro
        // Array Vazio ou de Tamanho "1"
        if(a.length === 0 || a.length === 1){
            return null;
        }

        // Removendo o Último Elemento do Array e imprimindo o Resultado
        result = a.slice(0, -1);
        return result;
    }

    // No caso de tipo Boolean
    // A função não pode ser avaliada e retorna um Null
    if(typeof a == "boolean"){
        return null;
    }

}
/*

// Teste para Números
console.log(pop(123)); // 12
console.log(pop(9876)); // 9876
console.log(pop(120019)); // 12001

// Teste para String
console.log(pop('lucas')); // luca
console.log(pop('tads')); // tad
console.log(pop('ifrs')); // ifr

// Teste Para Arrays
let lista = [1, 2, 3, 4, 5];
let outraLista = ['a', 'e', 'i', 'o', 'u'];
let maisUmaLista = ['arroz', 'feijao', 'salada', 'carne'];

console.log(pop(lista)); // [1, 2, 3, 4]
console.log(pop(outraLista)); // ['a', 'e', 'i', 'o', 'u'];
console.log(pop(maisUmaLista)); // ['arroz', 'feijao', 'salada']

*/
