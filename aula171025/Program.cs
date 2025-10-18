using Modelo;
using Logica;
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!"); TESTE!!

// Codigos Aula - Programação Modular 10 de Outubro
var p1 = new Produto
{
    Descricao = "Mouse Logitech",
    Quantidade = 255,
    Preco = 39.9m
};
// Console.WriteLine(p1); Testanto p1

var compra = Logica.Carrinho.CalcularCompra(p1);
Console.WriteLine(compra.Parcelas);
Console.WriteLine(compra.ValorParcela);
Console.WriteLine(compra.ValorTotal);
         

