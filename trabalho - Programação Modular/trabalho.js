// Implementar uma função que faça tags em textos,
// exemplo: paragrafo("Análise e Desenvolvimento")
// => <p>Análise e Desenvolvimento</p>
// Fazer "p", "strong" e "em"
// console.log(em("curso")) deve imprimir:  <em>curso</em>

function inserirTagTexto(texto){
    var newTexto;
    
    var tagAbertura = "<p>"; // Abertura da Tag
    var tagFechamento = "</p>"; // Fechamento da Tag

    if((tagAbertura == "<p>" && tagFechamento == "</p>") || (tagAbertura == "<strong>" && tagFechamento == "</strong>") || (tagAbertura == "<em>" && tagFechamento == "</em>")){
        newTexto = tagAbertura + texto + tagFechamento;
    } else {
        console.log("ERROR. Não são tags válidas!");
    }
    return newTexto;
}
console.log(inserirTagTexto('TADS'));


// Implementar uma função que imprime tags genéricas
// exemplo: tag("div", "Programação Modular") => <div>Programação Modular</div>
// console.log(tag("div", "Programação Modular")) <div>Programação Modular</div>
function inserirTagGenerica(texto){
    var newtexto = "";
    var tagAbertura = "<div>";
    var tagFechamento = "</div>";

    if((tagAbertura == "<div>" && tagFechamento == "</div>") || (tagAbertura == "<span>" && tagFechamento == "</span>")){
        newtexto = tagAbertura + texto + tagFechamento;
    } else {
        console.log("ERROR. Não são tags genéricas!");
    }

    return newtexto;    
}
console.log(inserirTagGenerica('JavaScript')); 


// Implementar uma função jogar moeda que dê cara ou coroa
// ex.: console.log(jogarMoeda()) // cara (ou coroa)
// essa é uma função sem entrada
function jogarMoeda(){
    var possibilidades = ['cara', 'coroa'];
    return possibilidades[Math.floor(Math.random() * 2)]
}
console.log(jogarMoeda());


// Implemente uma função IMC
// Adicionando a Classificação do IMC
let calculoImc;
function IMC(peso, altura){
    if(altura <= 0 || peso <= 0){
        return null;
    } else {
        calculoImc = peso / Math.pow(altura, 2);
    }
    return calculoImc;
}

function classificarIMC(calculoImc){
    if(calculoImc < 18.5) return `Baixo Peso`;
    if(calculoImc >= 18.5 &&  calculoImc < 25) return `Peso Normal`;
    if(calculoImc >= 25 &&  calculoImc <30) return `SobrePeso`;
    if(calculoImc >= 30 &&  calculoImc < 35) return `Obesidade I`;
    if(calculoImc >= 35 &&  calculoImc < 40) return `Obesidade II`;
    if(calculoImc >= 40 ) return `Obesidade III`;
}

console.log("IMC - Resultados");
console.log(IMC(82, 1.77));
console.log(classificarIMC(calculoImc));

