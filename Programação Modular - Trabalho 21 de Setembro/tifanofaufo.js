export function tifanofaufoAlfabeto(str){
    let finalStr = "";
    let consoantes = ['c', 'd', 'p', 'l']; // Usando uma Lista para armazenar as consoantes que serão substituídas por "f"

    // Tratamento de Erro 
    // str diferente de String
    if(typeof str !== "string" || str.length === 0){
        console.log("Insira uma String válida");
        return "";
    }

    for(let i = 0; i < str.length; i++){
        let caractere = str[i];
        if(consoantes.includes(caractere.toLowerCase())){
            finalStr += 'f';
        } else {
            finalStr += caractere;
        }
    }

    return finalStr.toLowerCase();
}
// Casos de Teste
// console.log(tifanofaufoAlfabeto("me da um abraco"));
// console.log(tifanofaufoAlfabeto("lucas"));
// console.log(tifanofaufoAlfabeto("lucas")); // fufas
// console.log(tifanofaufoAlfabeto("LUCAS")); // fufas
