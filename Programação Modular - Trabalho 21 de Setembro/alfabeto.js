export function contaVogais(palavra){
    let qtdVogais = 0;
    
    // Tratamento de Erro 
    if(typeof palavra != "string" || palavra.length === 0){
        console.log("Insira uma String não vazia");
        return 0;
    }

    for(let i = 0; i < palavra.length; i++){
        if(palavra[i] == 'a' || palavra[i] == 'e' || palavra[i] == 'i' || palavra[i] == 'o' || palavra[i] == 'u'){
            qtdVogais++;
        }
    }
    return qtdVogais;
}
// Teste da Função de Contar Vogais
// console.log(contaVogais("lucas"));

export function contaConsoantes(palavra){
    let qtdConsoantes = 0;

    // Tratamento de Erro
    if(typeof palavra != "string" || palavra.length === 0){
        console.log("Insira uma String não vazia");
        return 0;
    }

    for(let i = 0; i < palavra.length; i++){
        if(palavra[i] != 'a' && palavra[i] != 'e' && palavra[i] != 'i' && palavra[i] != 'o' && palavra[i] != 'u'){
            qtdConsoantes++;
        }
    }
    return qtdConsoantes;
}
// Teste da Função de Contar Consoante
// console.log(contaConsoantes("lucas")); 

export function contaCaractere(str, char){

    let foundChar = 0;

    // Tratamento de Erro
    if((typeof str != "string" || str.length === 0) || (typeof char != "string" || char.length === 0)){
        console.log("Parâmetros Inválidos");
        return 0;
    }

    for(let i = 0; i < str.length; i++){
        if(char === str[i]){
            foundChar++;
        }
    }
    return foundChar;
}
// Teste da Função de Contar Caracteres
// console.log(contaCaractere("palavra", "a")); // 3

export function eliminar(str, elimChar) {
    let finalStr = "";

    // Tratamento de Erro
    if ((typeof str !== "string" || str.length === 0) || 
        (typeof elimChar !== "string" || elimChar.length === 0)) {
        console.log("Parâmetros Inválidos");
        return "";
    }

    let elimLower = elimChar.toLowerCase();

    for (let i = 0; i < str.length; i++) {
        if (!elimLower.includes(str[i].toLowerCase())) {
            finalStr += str[i];
        }
    }

    return finalStr;
}

// Teste da Função Eliminar
// console.log(eliminar("lucas", "a")); // lucs

