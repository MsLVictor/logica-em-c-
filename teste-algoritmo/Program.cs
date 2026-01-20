static void questao01()
{
    Console.Clear();
    decimal fretePadrao = 35m;
    decimal precoProduto;
    double quantidadeProduto;
    bool promocaoAtivaConvertida;

    Console.WriteLine("Digite o nome do produto que o cliente deseja.");
    string nomeProduto = Console.ReadLine();

    Console.WriteLine("Digite o preço do produto");
    while(!decimal.TryParse(Console.ReadLine(), out precoProduto) || precoProduto < 0)
        Console.WriteLine("ERRO. Digite uma entrada válida(decimal) e maior que zero.");

    Console.WriteLine("Digite a quantidade do produto no pedido.");
    while(!double.TryParse(Console.ReadLine(), out quantidadeProduto) || quantidadeProduto < 0)
        Console.WriteLine("ERRO. Digite uma entrada válida(Número doubleeiro) e maior que zero.");

    Console.WriteLine("Promoção do dia ativa? true/false");
    while(!bool.TryParse(Console.ReadLine().ToLower(), out promocaoAtivaConvertida))
        Console.WriteLine("ERRO: Digite true ou false.");

    bool freteAplicado = false;
    decimal valorFinalSemDesconto = precoProduto * quantidadeProduto;
    decimal desconto = valorFinalSemDesconto * 0.12m;
    decimal valorFinalComDesconto = valorFinalSemDesconto - desconto;
    if(valorFinalSemDesconto >= 800)
    {
        fretePadrao = 0m;
        freteAplicado = true;
    }


    Console.WriteLine("=== FECHAMENTO DE COMPRA ===");
    Console.WriteLine($"Produto: {nomeProduto}");
    Console.WriteLine($"Preço Unitário: {precoProduto:C}");
    Console.WriteLine($"Quantidade: {quantidadeProduto}");
    Console.WriteLine();
    Console.WriteLine($"Subtotal: {valorFinalSemDesconto:C}");
    Console.WriteLine($"Promoção ativa: {(promocaoAtivaConvertida ? "Sim":"Não")}");
    Console.WriteLine($"Desconto(12%): {desconto:C}");
    Console.WriteLine();
    Console.WriteLine($"Frete aplicado: {(freteAplicado ? "Sim" : "Não")}");
    Console.WriteLine($"VALOR FINAL: {valorFinalComDesconto + fretePadrao}");
}

// Questão 2 — Classificação de Aluno (Média + Frequência)
// “U aluno recebe três notas, a primeira tem peso 1, a segunda nota tem peso 5 e a ultima nota peso 4, para o aluno ser aprovado ele precisa ter uma frequência de pelo menos 75% de assiduidade, caso contrario ele será reprovado diretamente. O aluno será aprovado se sua média for pelo menos 7.0, caso a média seja entre e 5 e 7, o aluno irá para recuperação, caso contrario o aluno será reprovado por nota. ”

// Saída Esperada

// === BOLETIM FINAL ===
// Aluno: <nome>
// Notas: <n1>, <n2>, <n3>
// Média: <media>
// Frequência: <freq>%

// Situação: <situação final>

Questao02();
static void Questao02()
{   
    double nota1 = 0;
    double nota2 = 0;
    double nota3 = 0;
    double frequencia = 0;
    string nomeAluno;

    System.Console.WriteLine("Nome do aluno: ");
    while(string.IsNullOrWhiteSpace(nomeAluno = Console.ReadLine()))
        Console.WriteLine("Nome inválido.");

    System.Console.WriteLine("Qual a porcentagem de frequência do aluno?");
    while(!double.TryParse(Console.ReadLine(), out frequencia) || frequencia > 100 || frequencia < 0)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número doubleeiro positivo)");

    System.Console.WriteLine("Digite a primeira nota.");
    while(!double.TryParse(Console.ReadLine(), out nota1) || nota1 < 0 || nota1 > 10)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número doubleeiro positivo)");
    
    System.Console.WriteLine("Digite a segunda nota.");
    while(!double.TryParse(Console.ReadLine(), out nota2) || nota2 < 0 || nota2 > 10)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número doubleeiro positivo)");

    System.Console.WriteLine("Digite a terceira nota.");
    while(!double.TryParse(Console.ReadLine(), out nota3) || nota3 < 0 || nota3 > 10)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número doubleeiro positivo)");
    
    double mediaPonderada = ((nota1 * 1) + (nota2 * 5) + (nota3 * 4)) / 10;



    
}


