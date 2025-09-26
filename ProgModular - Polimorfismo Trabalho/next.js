// Função next -> exluir o PRÓXIMO valor referente a um índice específico
export function next(a){
    if(typeof a == "number"){

        // índice fixo para TESTES
        // Pode ser Alterado a critério do usuário
        // Ou pode ser passado como parâmetro na função
        // Nesse caso, a função teria dois parâmetros (a, indice)
        // Onde "a" é o valor (número, string ou array) e "indice" é o índice do elemento a ser removido
        // Exemplo: next(12345, 2) -> removeria o elemento no índice 2 (terceiro dígito '3')
        // Contudo, como o exercício específicou que as funções teriam apenas um parâmetro, mantive o índice fixo para testes!
        
        // O índice fixo escolhido foi "2" (terceiro elemento)
        // Portanto, a função sempre removerá o terceiro elemento do valor passado
        let indice = 2;
        let nxt = indice + 1;
        let str1, str2, result;

        // Tratamento de Erro
        // Verificando se o Número é Válido
        if(isNaN(a) && a.length == 0){
            return null;
        }
        
        // Tratamento de Erro
        // Verificando se o índice é válido
        // Se for negativo ou maior que o tamanho da String
        if(a < 0 || nxt >= str.length){
            // Nestes caso, retorna o próprio valor sem alterações
            return a;
        }
        let str = a.toString(); // Se for válido, converte para String para avaliação

        // Removendo o elemento no índice específico
        str1 = str.substring(0, nxt);
        str2 = str.substring(nxt + 1);
        result = str1 + str2;

        // Imprimindo o resultado depois da Conversão para Number
        return Number(result);
    }

    if(typeof a == "string"){
        let indice = 2;
        let nxt = indice + 1;
        let str1, str2, result;

        // Tratamento de Erro
        // Verificando se a String está vazia ou é nula
        if(a.length == 0 || a == null){
            return null;
        }

        // Tratamento de Erro
        // Verificando se o índice é válido
        // Se for negativo ou maior que o tamanho da String
        if(a < 0 || nxt >= a.length){
            // Nestes caso, retorna o próprio valor sem alterações
            return a;
        }

        str1 = a.substring(0, nxt);
        str2 = a.substring(nxt + 1);
        result = str1 + str2;

        return result;
    }

    if(Array.isArray(a)){

        let indice = 2;
        let nxt = indice + 1;
        let result;

        // Tratamento de Erro
        // Verificando se o Array está vazio ou é nulo
        if(a.length == 0 || a == null){
            return null;
        }

        // Tratamento de Erro
        if(a < 0 || nxt >= a.length){
            return a;
        }

        // Removendo o elemento no índice específico usando Slice()
        // O método slice() retorna uma cópia de uma parte do array dentro de um novo array
        // Sem modificar o array original
        result = [... a.slice(0, nxt), ... a.slice(nxt + 1)];
        return result;
    }

    if(typeof a == "boolean"){
        return null;
    }
}
/*

// Teste para Números
console.log(next(12345)); // 1235
console.log(next(98765)); // 9875
console.log(next(125)); // 125 

// Teste para String
console.log(next("internacioal")); // intrnacioal
console.log(next("gremio")); // greio
console.log(next("proximo")); // proimo

// Teste para Arrays
let lista = [1, 2, 3, 4, 5];
let outraLista = ['a', 'e', 'i', 'o', 'u'];
let maisUmaLista = ['arroz', 'feijao', 'salada', 'carne'];

console.log(next(lista)); // [1, 2, 3, 5]
console.log(next(outraLista)); // ['a', 'e', 'i', 'u']
console.log(next(maisUmaLista)); // ['arroz', 'feijao', 'salada']

*/