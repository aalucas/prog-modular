/**
 * @param {Peso do Indivíduo} peso 
 * @param {Altura do Indivíduo} altura 
 * @returns {Retorna o IMC - Índice de Massa Corporal}
 */

// De maneira Análoga
// util.js => Servidor / Back-End

// Função Para Calcular o IMC
export function calcularImc(peso, altura){

    // Tratamento de Erro 1
    // peso || altura != Number
    if(typeof peso != "number" || typeof altura != "number"){
        peso = Number(peso);var imcClass;
        altura = Number(altura);
    }


    // Tratamento de Erro 2
    // variável Peso Vazia, null, undefined ou NaN
    // Peso e Altura
    // Para o caso de NaN é possível usar:
    // peso != peso || isNaN(peso)
    // altura != altura || isNaN(altura)
    if((!peso || peso.length === 0) || (!altura || altura.length === 0) || (isNaN(peso) || isNaN(altura))){
        throw "Valores Inválidos. Insira Novos Valores";
    }

    // Tratamento de Erro 3
    // Valores Negativos para as Variáveis
    if(peso < 0 || altura < 0){
        peso = peso * (-1);
        altura = altura * (-1);
    }

    let calcImc;
    calcImc = peso / Math.pow(altura, 2);

    // Retornando o valor de Imc em Ternário
    // "Fórmula do Ternário"
    // variavel ? codigo_true : codigo_false
    return calcImc ? calcImc.toFixed(2): null;
}

// Função para Classificar um IMC, o qual foi previamente calculado na função anterior
export function classificarImc(imc){

    // Tratamento de Erro 1
    // imc Vazio, null ou undefine
    if(!imc || imc.length === 0 || isNaN(imc)){
        throw "IMC Inválido";
    }

    // Tratamento de Erro 2
    // Imc Negativo
    if(imc < 0){
        imc = imc * (-1);
    }

    // Classificando os IMC de acordo com seu respectivo valor
    if(imc <= 18.5) return "Abaixo do Peso";
    if(imc > 18.5 && imc <= 24.9) return "Peso Normal";
    if(imc > 25 && imc <= 29.9) return "SobrePeso";
    if(imc > 30 && imc <= 34.9) return "Obesidade Grau I";
    if(imc > 35 && imc <= 39.9) return "Obesidade Grau II";
    if(imc >= 40) return "Obesidade Grau III ou Obesidade Mórbida";
}