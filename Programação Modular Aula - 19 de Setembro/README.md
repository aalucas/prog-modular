# 2025-09-19-tipagem-polimorfismo

TIPAGEM (tipos)
SISTEMA
TEMPO
ESTADO
Instante
1, 2, 3, 4, 5, 6, 7, ...
estado é o valor de todas as variáveis
As variáveis (todas) podem assumir qualquer valor?
Não, pois existem diversas restrições (constraints)
Qual é a primeira constraint? TIPO

Todo sistema é um conjunto de _constraints_, para garantir que o sistema tenha sempre um estado válido, a começar pela tipagem.

Tipagem => Constraint
var x;
x = "assdasdasd"
x = 2
x = "ddfndcnvcx"
x = []

Em JS existem tipos?
SIM
Eles são pré-definidos ou pós-definidos?
Pós-definido (Tipagem Dinâmica (flexível))
Misturar tipos diferentes?
SIM

JS:
Tipagem Dinâmica
Tipagem Fraca (misturar os tipos porque ocorre conversão implícita)

Python:
Tipagem Dinâmica
Tipagem Forte (é necessário converter os tipos explicitamente)

```js
function imc(peso, altura) {
    if (typeof(peso) != 'number') throw 'erro'
}