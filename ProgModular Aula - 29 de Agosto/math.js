// Export function para tornar a função disponível para o uso em outros módulos
// Resumo
/*
export function minhaFuncao(params) {
    // ... código ...
}
*/

export function potencia(base, expoente){ // Função com dois parâmetros
    let pow = 1;
    for(var i = 1; i <= expoente; i++){
        pow *= base;
    }
    return pow;
}
