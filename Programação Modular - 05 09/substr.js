/**
 * 
 * @param {variável que armazenará a String} str 
 * @param {índice inicial} inicio 
 * @param {índice inicial} fim 
 * @returns  
 */
export function substring(str, inicio, fim){

    // A ideia da Função é fazer uma SubString a partir da Definição de
    // índices Finais e inicias e concatená-los em uma Variável através de um laço de repetição (for)
    // Isto é, concatenar todos os caracteres do índice inicial até o índice "fim - 1" !!
    // "TADS", 0, 2

    // T = 0  índ inicial  |
    // A = 1               |   TA = 2 - 0
    // D = 2  índ final    | 

    // Tratamento de Condições
    // Se o fim não for fornecido
    // Usaremos o comprimento da String fornecida
    if(fim == undefined || fim == null){
        fim = str.length;
    }

    // No Caso da String for Indefinida - undefined
    // Isto é, no caso dela não ter sido fornecida
    if(str == undefined){
        console.log("Forneça Uma String!");
    }

    if(inicio < 0){ // Se o início for Negativo
        inicio = 0; // Ele terá o índice 0 -> o primeiro Caractere da String
    } else if(fim > str.length){ // Se o Fim for maior do que o Tamanho da String
        fim = str.length; // fim será exatamente o Tamanho da String
    } else if(inicio > fim) { // Se o ínicio for maior do que o fim
        return null; // A Função Retornará Um valor Null
    }

    let resultado = ''; // Inicia o 'resultado' como uma nova String vazia

    // Implementando um for para gerar a SubString
    // Enquanto a Variável de Iteração - que é igual ao parâmetro de inicio -
    // for menor do que o fim, a SubString será gerada e será concatenada
    // Dentro da variável resultado
    for(let i = inicio; i < fim; i++){
        resultado += str[i]; // Concatena os caracteres na String 
    }
    return resultado; // Retorna uma SubString !
}
console.log(substring("TADS", 0, 2)); // TA

// Para fazer a Função de formatar uma String de Números para o formato CPF
// reaproveitaremos a função subString

let cpf = '01234567890'; // Definindo um CPF exemplo
export function formatarCpf(cpf){

    // Tratamento de Erro 1
    // Tipo de Dado != string
    if(typeof cpf != 'string'){ // Se o tipo de dado de cpf for diferente de string
        cpf = String(cpf); // Converte cpf para string;
    }

    // Tratamento de Erro 2
    // cpf == null || cpf == undefined || cpf vazio
    if(!cpf || cpf.length === 0){  // !cpf => Verifica se Cpf é false. Isso cobre automaticamente: null, undefined e String vazia
        console.log("Insira um valor para CPF");
    }

    // Tratamento de Erro 3
    // CPF com tamanho inválido
    if(cpf.length != 11){
        console.log("CPF deve conter 11 Dígitos");
        return null;
    }

    // Chamamos a função e passamos novos parâmetros para ela
    // A ideia é separar a String em várias SubStrings e Juntá-las
    // Posteriormente com os devidos símbolos

    // cpf => seria o nosso 'str' que armazenará os números
    // 0 => indíce inicial que armazenará o primeiro dígito
    // 3 => indíce que armazenará a dígito daquela posição
    // E assim sucessivamente...

    let p1 = substring(cpf, 0, 3);
    let p2 = substring(cpf, 3, 6);
    let p3 = substring(cpf, 6, 9); 
    let p4 = substring(cpf, 9, 11);

    // Concatenando e Formatando a String
    return p1 + "." + p2 + "." + p3 + "-" + p4;
}
console.log(formatarCpf(cpf)); // 012.345.678-90