import {pop} from "./pop.js";
import {next} from "./next.js";
import {middle} from "./middle.js";

var numEx = 9;
var anotherNumEx = 123456789; 
var txtEx = 'adt';
var anotherTxtEx = 'libertadores' 
var arrayEx = [2, 3, 8, 2, 4];
var anotherArrayEx = [1, 2, 3, 4, 5, 6, 7, 8, 9];
var boolean = true;

console.log(pop(numEx)); // 9
console.log(pop(txtEx)); // ad
console.log(pop(arrayEx)); // [2, 3, 8, 2]
console.log(pop(boolean)); // null

console.log();

console.log(pop(pop(pop(pop(pop(numEx)))))); // undefined
console.log(pop(pop(pop(pop(pop(anotherNumEx)))))); // 1234
console.log(pop(pop(pop(pop(pop(txtEx)))))); // undefined
console.log(pop(pop(pop(pop(pop(anotherTxtEx)))))); // libertador
console.log(pop(pop(pop(pop(pop(arrayEx)))))); // null
console.log(pop(pop(pop(pop(pop(anotherArrayEx)))))); // [1, 2, 3, 4]

console.log();

console.log(next(numEx)); // 9
console.log(next(txtEx)); // adt
console.log(next(arrayEx)); // [ 2, 3, 8, 4 ]
console.log(next(boolean)); // null

console.log();

console.log(next(next(next(numEx)))); // 9
console.log(next(next(next(anotherNumEx)))); // 123789
console.log(next(next(next(txtEx)))); // adt
console.log(next(next(next(anotherTxtEx)))); // libertores
console.log(next(next(next(arrayEx)))); // [ 2, 3, 8 ]
console.log(next(next(next(anotherArrayEx)))); // [ 1, 2, 3, 7, 8, 9 ]

console.log();

console.log(middle(numEx)); // 0
console.log(middle(txtEx)); // at
console.log(middle(arrayEx)); // [ 2, 3, 2, 4 ]
console.log(middle(boolean)); // null