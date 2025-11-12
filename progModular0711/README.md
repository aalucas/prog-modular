## Índice
1. Visão Geral  
2. Organização dos arquivos sugerida  
3. Principais conceitos abordados  
   - Tipos: `class` vs `struct`  
   - Tipos por valor (Value Types) vs tipos por referência (Reference Types)  
   - Transparência referencial / Funções puras vs impuras  
   - Efeitos colaterais (side effects)  
   - `ref` e `out`  
   - `static` e classes utilitárias  
   - `namespace` e `using`  
   - Boxing / Unboxing (quando ocorre)  
   - Mutabilidade: `StringBuilder` e objetos mutáveis  
   - I/O com `Console` e parsing seguro (`TryParse`)  
   - Nomes de identificadores e acentuação  
4. Comportamento linha-a-linha (resumo por trechos)  
5. Modelo mental / o que muda na memória (stack/heap) — exemplos ASCII  
6. Boas práticas e sugestões de estilo  
7. Problemas comuns e como resolvê-los  
8. Como compilar/executar (exemplos)  
9. Exercícios recomendados para fixação  
10. FAQ rápido  
11. Conclusão e próximos passos

---

# 1. Visão Geral

Os exemplos estudados mostram **diferenças fundamentais** entre `class` (tipo referência) e `struct` (tipo valor), como métodos podem produzir **efeitos colaterais** ao alterar estado de objetos, como usar `ref`/`out` para trabalhar com valores por referência em tipos-valor, e o que significa ser uma **função pura** vs **impura**. Também abordamos entrada/saída com `Console`, parsing seguro (`TryParse`), e problemas práticos (ex.: nome de método com acento que quebra compilação).

---

# 2. Organização dos arquivos (sugestão)

Estruture o projeto assim para clareza:

```
/ProgModular0711
  ├─ Program.cs        // top-level statements ou classe Program com Main
  ├─ Teste.cs          // classe estática Teste com métodos Dobro, Amanha, Hoje
```

---

# 3. Principais conceitos (explicações completas)

## `class` vs `struct`
- **`class`**: tipo por referência. Variáveis armazenam um *endereço* (referência) para um objeto na *heap*. Atribuições copiam referências, não objetos.
  - Exemplo:  
    ```csharp
    Numero a = new Numero { Valor = 5 };
    Numero b = a; // b referencia o mesmo objeto que a
    ```
  - Se você modificar `a.Valor`, `b.Valor` também muda (mesma instância).

- **`struct`**: tipo por valor. Variáveis armazenam o valor diretamente (tipicamente no stack ou inline em arrays/objetos). Atribuições copiam o conteúdo.
  - Exemplo:
    ```csharp
    DateOnly d1 = DateOnly.FromDateTime(DateTime.Now);
    DateOnly d2 = d1; // cópia independente
    ```

## Value Types vs Reference Types (semântica)
- **Value types** (ex.: `int`, `double`, `DateOnly`, `structs` customizados): copiar = novo valor independente.
- **Reference types** (ex.: `class`, `StringBuilder`, `object`): copiar = duas referências apontando para o mesmo objeto.

## Transparência referencial & Função pura vs impura
- **Função pura**: mesma entrada → sempre mesma saída; **sem efeitos colaterais**. Ex.:  
  ```csharp
  public static int Dobro(int num) { return num * 2; }
  ```
- **Função impura**: pode alterar estado externo, fazer I/O, lançar exceções inesperadas. Ex.:  
  ```csharp
  public static void Dobro(Numero num) { num.Valor *= 2; } // altera o objeto recebido
  ```
- **Transparência referencial** é a propriedade que permite substituir chamadas por seus valores sem alterar o comportamento do programa — só válida para funções puras.

## Efeitos colaterais (side effects)
- Qualquer operação que altera o estado externo ao escopo da função: modificar campos de objetos, escrever no console, alterar arquivo, banco etc.
- Efeitos colaterais tornam raciocínio/testes mais difíceis, portanto reduza-os quando possível.

## `ref` e `out`
- `ref`: o parâmetro deve estar inicializado antes da chamada; o método pode ler e escrever; passa referência para um value type (ou alias para uma variável).
  - Uso: `Teste.Amanha(ref hoje);`
- `out`: a variável passada não precisa ser inicializada; o método é obrigado a atribuir antes de retornar; ideal para métodos que querem devolver múltiplos valores sem tuplas.
  - Uso: `Teste.Hoje(out data2);`

## `static` e classes utilitárias
- `static class Teste { ... }` é um agrupamento de métodos utilitários que não requerem instância.
- Métodos estáticos pertencem à classe, não a objetos.

## `namespace` e `using`
- `using` importa namespaces para reduzir verbosidade. Remova `using` não usados para ficar limpo.
- `namespace` organiza código e previne colisão de nomes.

## Boxing / Unboxing
- Ocorre quando um ValueType (ex.: `int`) é convertido para `object` — o runtime cria uma caixa na heap. Inverso: unboxing.
- No código estudado não havia boxing explícito — `Numero` é classe (referência), logo não é boxing.

## Mutabilidade — `StringBuilder` e objetos mutáveis
- `StringBuilder` é mutável: operações `Append` mudam a mesma instância.
- Objetos mutáveis + referências = cuidado com aliasing (mesma instância vista por várias variáveis).

## I/O com `Console` e `TryParse`
- `Console.ReadLine()` lê texto do usuário; pode retornar `null` dependendo do ambiente.
- `int.TryParse(string, out int)` tenta converter sem lançar exceção — padrão mais seguro para input.

## Nomes de identificadores e acentuação
- C# aceita Unicode em identificadores, mas usar acentos (ex.: `Amanhã`) é **problemático** por legibilidade e compatibilidade — use nomes ASCII (`Amanha`) para evitar erros e confusão.

---

# 4. Comportamento linha-a-linha (resumo por trechos do `Program.cs`)

### Criação e aliasing de `Numero`
```csharp
Numero x = new Numero { Valor = 5 };
Numero y = x;
Teste.Dobro(x); // método que altera num.Valor
Console.WriteLine(x.Valor);
Console.WriteLine(y.Valor);
```
- `x` e `y` apontam para o **mesmo** objeto. `Teste.Dobro(x)` modifica o objeto na heap; impressão mostra valor alterado para ambas as variáveis.

### Trabalhando com `DateOnly` e `ref`
```csharp
DateOnly hoje = DateOnly.FromDateTime(DateTime.Now);
Teste.Amanha(ref hoje);
Console.WriteLine(hoje);
```
- `DateOnly` é `struct` (valor). Sem `ref`, passar para método resultaria em cópia; com `ref`, a função recebe referência e pode modificar a variável original.

### Usando `out`
```csharp
DateOnly data2;
Teste.Hoje(out data2);
Console.WriteLine(data2);
```
- `out` permite que o método atribua um valor e devolva ao chamador, sem inicialização prévia.

### Entrada do usuário e `TryParse`
```csharp
Console.Write("Digite um número: ");
string valor = Console.ReadLine();
int valorInteiro;
if (int.TryParse(valor, out valorInteiro)) { ... }
else { ... }
```
- `TryParse` evita exceção em entrada inválida e devolve um booleano indicando sucesso, preenchendo `valorInteiro` via `out`.

---

# 5. Modelo mental — Stack vs Heap (exemplos simples)

**Antes de `Teste.Dobro(x)`**
```
Stack:
 x -> referência para objetoA
 y -> referência para objetoA

Heap:
 objectA (Numero) { Valor = 5 }
```

**Depois de `Teste.Dobro(x)` (que faz num.Valor *= 2;)**
```
Heap:
 objectA (Numero) { Valor = 10 }

Stack:
 x -> objectA
 y -> objectA
```

**Para `DateOnly` sem `ref`**
```
DateOnly hoje = ...;   // hoje contém valor diretamente (no stack)
Ao passar sem ref: cópia do valor é feita para o método (ou para parametro local)
```

**Com `ref`**
```
Ao passar com ref: o método recebe um alias para a variável 'hoje' — alterações afetam a variável original.
```

---

# 6. Boas práticas e sugestões

- Use **nomes ASCII** (sem acentos) para métodos/identificadores: `Amanha` em vez de `Amanhã`.
- Prefira **funções puras** quando possível (facilitam teste e raciocínio).
- Evite efeitos colaterais desnecessários; centralize I/O em camadas de fronteira (ex.: `Program`).
- Remova `using` não utilizados (IDE/`dotnet` podem sugerir/limpar automaticamente).
- Use `TryParse` para entradas do usuário — mais robusto que `int.Parse`.
- Prefira `readonly struct` para structs imutáveis e pequenas (se fizer sentido).
- Evite structs muito grandes (custo de cópia).
- Faça validações antes de usar `ref`/`out` — documente claramente o comportamento do método.

---

# 7. Problemas comuns e soluções

- **Erro de compilação por acento/identificador incorreto**  
  *Sintoma:* `Teste.Amanhã` não existe se o método foi definido como `Amanha`.  
  *Solução:* alinhe nomes ou renomeie método para `Amanha`.

- **Pensou que `y = x` criou cópia do objeto**  
  *Sintoma:* alterar `x.Valor` e ainda ver a alteração em `y`.  
  *Causa:* `class` copia referência, não objeto.  
  *Solução:* clone explicitamente se precisar de cópia de estado: `var clone = new Numero { Valor = x.Valor };`

- **String concatenation de muitos dados (performance)**  
  *Use:* `StringBuilder` quando for construir strings de forma incremental em loops.

- **NullReferenceException em `Console.ReadLine()`**  
  *Solução:* trate `null` ou use `string?` e validação (`if (valor is null) ...`).

---

# 8. Como compilar e executar

### 1) Projeto console usando top-level statements (C# 9+)
- `dotnet new console -n MeuApp`
- Substitua o conteúdo de `Program.cs` pelo seu código (top-level).
- `dotnet run --project MeuApp`

### 2) Alternativa: criar `Program` com `Main`
Se preferir estilo clássico:
```csharp
class Program
{
    static void Main(string[] args)
    {
        // cole aqui o conteúdo das top-level statements
    }
}
```
- Compilar e executar pelo `dotnet run` do mesmo jeito.

---

# 9. Exercícios práticos (para fixação)

1. **Clonagem**: Crie um método `Clone` para `Numero` que retorne uma nova instância com o mesmo `Valor`. Teste a diferença entre atribuição por referência e clonagem.
2. **Imutabilidade**: Reescreva `Nota` como `readonly struct` com propriedade `Value` só leitura e um construtor. Explique por que pode ser melhor em alguns cenários.
3. **Sem efeitos colaterais**: Reescreva o método `Teste.Dobro(Numero)` para retornar um `Numero` novo em vez de alterar o existente (tornando-o puro). Compare os usos.
4. **Explorar `ref`**: Implemente um método que troca dois inteiros usando `ref`: `Swap(ref int a, ref int b)`. Teste e explique o que acontece na memória.
5. **Teste de `TryParse` robusto**: Faça um laço que solicita número ao usuário até receber um inteiro válido.

---

# 10. FAQ rápido

- **Quando usar `struct`?**  
  Use para tipos pequenos, imutáveis, que representam valores (ex.: `Point`, `DateOnly`), e quando custo de alocação na heap for relevante.

- **Quando usar `class`?**  
  Para objetos com identidade, estado mutável, ciclos de vida mais longos, ou quando o objeto é grande/complexo.

- **`ref` ou retorno de objeto novo?**  
  Se você quer deixar claro que o método modifica o input, `ref` é direto; para imutabilidade e menos efeitos colaterais, retorne uma nova instância.

- **Boxing é ruim?**  
  Boxing tem custo de performance (alocação e cópia). Evite quando possível, especialmente em loops críticos.

---

