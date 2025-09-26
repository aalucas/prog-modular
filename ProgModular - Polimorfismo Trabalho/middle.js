// Função middle -> Excluir o elemento do meio com base na verificação do tamanho (par ou ímpar)
// Se for par, remove os dois elementos centrais
// Se for ímpar, remove o elemento central 
export function middle(a){

    if(typeof a == "number"){

        let result;
        let mid = Math.floor(str.length / 2);
        let str1, str2;

        // Tratamento de Erro
        // Verificando se o Número é Válido
        if(isNaN(a) || a.length == 0 || a.length == 1){
            return null;
        }

        // No caso do Número Válido
        let str = a.toString(); // Convertendo o Número para String para avaliação

        // Verificando o Tamanho da String
        // Caso de Ímpar
        if(str.length % 2 !== 0){
            str1 = str.substring(0, mid);
            str2 = str.substring(mid + 1);

        // Caso Par
        } else {
            str1 = str.substring(0, mid - 1);
            str2 = str.substring(mid + 1);
        }

        // Concatenando as duas partes da String 
        // e Imprimindo o resultado depois da Conversão para Number
        return Number(result);
    }

    if(typeof a == "string"){

        // Tratamento de Erro
        // Verificando se a String está vazia ou tem tamanho "1"
        if(a.length == 0 || a.length == 1){
            return null;
        }

        let result;
        let mid = Math.floor(a.length / 2);
        let str1, str2;

        // Verificando o Tamanho da String
        // Caso de Ímpar
        if(a.length % 2 !== 0){
            str1 = a.substring(0, mid);
            str2 = a.substring(mid + 1);

        // Caso Par
        } else {
            str1 = a.substring(0, mid - 1);
            str2 = a.substring(mid + 1);
        }

        result = str1 + str2;
        return result;
    }

    if(Array.isArray(a)){

        // Tratamento de Erro
        // Array Vazio ou de Tamanho "1"
        if(a.length === 0 || a.length === 1){
            return null;
        }

        let result;
        let mid = Math.floor(a.length / 2); // Criando uma variável para armazenar o índice do meio

        // No caso do Array Válido
        // Usando Slice para criar um novo Array sem o(s) elemento(s) do meio
        // Verificando Casos
        // Caso ímpar
        if(a.length % 2 !== 0){
            result = [...a.slice(0, mid), ...a.slice(mid + 1)];
        // Caso Par
        } else {
            result = [...a.slice(0, mid - 1), ...a.slice(mid + 1)];
        }

        return result;
    }

    if(typeof a == "boolean"){
        return null;
    }

}
/*

// Teste para Números;
console.log(middle(123)); // 13
console.log(middle(12345)); // 1245
console.log(middle(1234)); // 14
console.log(middle(123456)); // 1256

// Teste para String
console.log(middle("lucas")); // luas
console.log(middle("maça")); // ma
console.log(middle("mar")); // mr 

// Teste Para Arrasalada4, 5];
let lista = [1, 2, 3, 4, 5];
let outraLista = ['a', 'e', 'i', 'o', 'u'];
let maisUmaLista = ['arroz', 'feijao', 'salada', 'carne'];

console.log(middle(lista)); // [1, 2, 4, 5]
console.log(middle(outraLista)); // ['a', 'e', 'o', 'u']
console.log(middle(maisUmaLista)); // ['arroz', 'carne']

console.log();

*/