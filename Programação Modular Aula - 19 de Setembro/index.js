var t1 = 5
var t2 = t1
t2 = t2 + 1
console.log(t1)
console.log(t2)


var a1 = [1,2,3]
var a2 = a1
a2.push(4)
console.log(a1) // 1,2,3
console.log(a2) // 1,2,3,4


var w = ['if']
console.log(w) // ['if']
rs(w)
console.log(w) // ['if', 'rs']
// por que isso acontece?

function rs(array) {
    array.push('rs')
}





var x = 12
var y = "ifrs"
var z = ['pm', 'pmbd', 'di', 'md', 'oc', 'es']

console.log(double(x)) // 24
console.log(x) // 12 (não há alteração no original)
console.log(double(y)) // "ifrsifrs"
console.log(double(z)) // ['pm', 'pmbd', 'di', 'md', 'oc', 'es', 'pm', 'pmbd', 'di', 'md', 'oc', 'es']
console.log(z) // vem duplicado, há alteração

console.log(half(x)) // 6 
console.log(half(y)) // NaN
console.log(half(z)) // NaN
console.log(half()) // NaN
console.log(half({})) // NaN
console.log(half(null)) // 0
console.log(half(x, y, z)) // 6

// tipos "primitivos": number, string
// tipos "referenciados": arrays (vetores)

function double(a) {
    if (typeof(a) == 'number') return 2 * a
    if (typeof(a) == 'string') return a + a
    if (Array.isArray(a)) {  // return a.concat(a)
        var tam = a.length
        for (var i = 0; i < tam; i++) {
            a.push(a[i])
        }
        return a;
    }
}


// função polimórfica
// metade do quê? de tudo que é quantificável
function half(a) {   // half => metade ABSTRAÇÃO
    if (typeof(a) == 'number')
        return a / 2
    if (typeof(a) == 'string')
        return a.substring(0, a.length / 2)
    if (Array.isArray(a))
        return a.slice(0, a.length / 2)
    if (isNaN(a))
        return NaN
}

