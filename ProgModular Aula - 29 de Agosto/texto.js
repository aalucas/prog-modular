export function ultimos(texto, qtd){
    let resp = "";
    for(var i = texto.length - qtd; i < texto.length; i++){
        resp += texto[i];
    }
    return resp;
}
console.log(ultimos("limao", 2)); 

export function terminaCom(texto, final){
    var qtd = final.length;
    var ult = ultimos(texto, qtd);
    var resp = "";
    if(ult == final){
        resp = true;
    } else {
        resp = false;
    }
    return resp;
}

// Versão Reduzida de "terminaCom"
export function terminaComReduzida(){
    return ultimos(texto, final.length) == final;
}

export function plural(palavra){
    if(terminaCom(palavra, "r")) return palavra + "es";
    // ToDo: Tratar o "ao" e casos especiais
    return palavra + "s";
} 


