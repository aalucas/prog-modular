// Aula Programação Modular - 12 / 09 / 25
// TADS - 2 Semestre

console.log("Tads"); // Teste

// Sistema => trata-se um conjunto de elementos, componentes ou regras 'interligadas e interdependentes '
// que interagem de forma organizada para alcançar um objetivo comum ou manter um equilíbrio dinâmico
// atravé de um estado padronizado que pode sofrer variações

// Na programação e na TI, dizemos que um Sistema 
// é um conjunto de Constraints de Restrições

// Em sistemas bancários, por exemplo, o conjunto de variáveis
// Não pode assuimir qualquer valor que se deseja !
// Existem regras que limitam o ESTADO desses sistemas
// Além disso, para este exemplo tem-se que...
// Quem faz as regras => Os gestores do Banco ( Trata-se de quem está ambientado com as restrições do Sistema)
// Quem implementa as Regras => Os Devs

// Sistema Cliente-Servidor
// um modelo de arquitetura de rede e computação distribuída 
// em que as tarefas e responsabilidades são divididas entre dois papéis principais: Cliente / Servidor

// Cliente => Conjunto de Regras que validam o Estado do cliente, isto é, 
// é o lado do sistema que solicita recursos ou serviços.
// Ex: "um input que valida a idade"
// É o Front-End de um Sistema

// Servidor => É o lado que fornece esses recursos ou processa as solicitações
// diretamente para o cliente, ou seja, lida com o tráfego e a transição de dados
// fornecidos pelo cliente a fim de assegurar um estado válido para o processo
// o qual finaliza em meio persistente - Banco de Dados - a fim de que tais dados sejam válidos !
// É o Back-End de um Sistema

// Em suma, essa estrutura funciona a partir de um método de 
// Requisição / Resposta => API
// Além disso, esse mecanismo envolve o que se pode chamar de "contrato"
// que nada mais é do que as regras que delimitam e estipulam métricas e parâmetros para a API

// Application Programming Interface - APi - 
// em suma, trata-se de um conjunto de regras, protocolos e ferramentas que permite que diferentes softwares 
// ou componentes se comuniquem e troquem dados de forma padronizada, 
// sem a necessidade de conhecer os detalhes internos um do outro.

// ' TUDO QUE ENVOLVE A COMUNUICAÇÃO ENTRE UM CLIENTE/SERVIDOR É UMA API '

// No fluxo típico de um sistema cliente-servidor, a API opera como o intermediário lógico 
// que gerencia a comunicação entre o cliente e o servidor a fim de estruturar uma eficiente validação
// dos dados da comunicação Cliente/Servidor

// Estratégias de Validação
// 1. Leniente -> Tentar Aceitar
// 2. "Não Fazer Nada" -> Não executar o que foi pedido -> Retornar null
// 3. Código de Erro
// 4. Exceção 

// Documentar o Código
// " / + ** + Enter "

// OBS
// Numa Função temos:
// retorno -> Válido
// exceção -> Inválido

// Exemplo Prático
// De maneira Análoga
// index.js => Cliente / Front-End

import {calcularImc, classificarImc} from "./usefull.js";

var altura = 1.92;
var peso = 79;
var imc;
var imcClass;

try{
    imc = calcularImc(peso, altura);
    console.log("IMC: " + imc); // 21.43
} catch(e) {
    console.log("Valores Inválidos");
}

try{
    imcClass = classificarImc(imc);
    console.log(imcClass); // Peso Norma
} catch(e) {
    console.log("IMC Inválido");
}

