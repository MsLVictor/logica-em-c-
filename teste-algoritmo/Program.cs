static void Questao01()
{
    Console.Clear();
    decimal fretePadrao = 35m;
    decimal precoProduto;
    int quantidadeProduto;
    bool promocaoAtivaConvertida;

    Console.WriteLine("Digite o nome do produto que o cliente deseja.");
    string nomeProduto = Console.ReadLine();

    Console.WriteLine("Digite o preço do produto");
    while (!decimal.TryParse(Console.ReadLine(), out precoProduto) || precoProduto < 0)
        Console.WriteLine("ERRO. Digite uma entrada válida(decimal) e maior que zero.");

    Console.WriteLine("Digite a quantidade do produto no pedido.");
    while (!int.TryParse(Console.ReadLine(), out quantidadeProduto) || quantidadeProduto < 1)
        Console.WriteLine("ERRO. Digite uma entrada válida(Número doubleeiro) e maior que zero.");

    Console.WriteLine("Promoção do dia ativa? true/false");
    while (!bool.TryParse(Console.ReadLine().ToLower(), out promocaoAtivaConvertida))
        Console.WriteLine("ERRO: Digite true ou false.");

    bool freteAplicado = false;
    decimal valorFinalSemDesconto = precoProduto * quantidadeProduto;
    decimal desconto = valorFinalSemDesconto * 0.12m;
    decimal valorFinalComDesconto = valorFinalSemDesconto - desconto;
    if (valorFinalSemDesconto >= 800)
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
    Console.WriteLine($"Promoção ativa: {(promocaoAtivaConvertida ? "Sim" : "Não")}");
    Console.WriteLine($"Desconto(12%): {desconto:C}");
    Console.WriteLine();
    Console.WriteLine($"Frete aplicado: {(freteAplicado ? "Sim" : "Não")}");
    Console.WriteLine($"VALOR FINAL: {valorFinalComDesconto + fretePadrao}");
}

static void Questao02()
{
    double nota1 = 0;
    double nota2 = 0;
    double nota3 = 0;
    double frequenciaMinima = 75;
    double frequencia;
    string nomeAluno;
    string statusAluno;

    Console.WriteLine("Nome do aluno: ");
    while (string.IsNullOrWhiteSpace(nomeAluno = Console.ReadLine()))
        Console.WriteLine("Nome inválido.");

    Console.WriteLine("Qual a porcentagem de frequência do aluno?");
    while (!double.TryParse(Console.ReadLine(), out frequencia) || frequencia > 100 || frequencia < 0)
        Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    Console.WriteLine("Digite a primeira nota.");
    while (!double.TryParse(Console.ReadLine(), out nota1) || nota1 < 0 || nota1 > 10)
        Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    Console.WriteLine("Digite a segunda nota.");
    while (!double.TryParse(Console.ReadLine(), out nota2) || nota2 < 0 || nota2 > 10)
        Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    Console.WriteLine("Digite a terceira nota.");
    while (!double.TryParse(Console.ReadLine(), out nota3) || nota3 < 0 || nota3 > 10)
        Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    double mediaPonderada = ((nota1 * 1) + (nota2 * 5) + (nota3 * 4)) / 10;

    if (frequencia < frequenciaMinima)
        statusAluno = "Reprovado";
    else if (mediaPonderada >= 7)
        statusAluno = "Aprovado";
    else if (mediaPonderada < 7 && mediaPonderada >= 5)
        statusAluno = "Recuperação";
    else
        statusAluno = "Reprovado";

    Console.WriteLine("=== BOLETIM FINAL ===");
    Console.WriteLine($"Aluno: {nomeAluno}");
    Console.WriteLine($"Notas: {nota1}, {nota2}, {nota3}");
    Console.WriteLine($"Média: {mediaPonderada}");
    Console.WriteLine($"Frequência: {(frequencia / 100):P2}");
    Console.WriteLine();
    Console.WriteLine($"Situação: {statusAluno}");
}

static void Questao03()
{
    List<double> notaDosAlunosEstagio = new List<double>() { };
    int quantidadeAlunos;
    int notasExcelentes = 0;
    int notasBoas = 0;
    int notasRegulares = 0;
    int notasFracas = 0;
    EnumDesempenhoTurma desempenhoTurma;

    Console.WriteLine("Qual a quantidade de alunos da turma de estagiários?");
    while (!int.TryParse(Console.ReadLine(), out quantidadeAlunos) || quantidadeAlunos <= 0)
        Console.WriteLine("Quantidade de alunos inválida.");

    double maiorNota = double.MinValue;
    double menorNota = double.MaxValue;

    for (int i = 0; i < quantidadeAlunos; i++)
    {
        double nota;
        Console.WriteLine($"Informe a nota do aluno {i + 1}");
        while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            Console.WriteLine("Digite um número válido");

        if (nota > maiorNota)
            maiorNota = nota;
        if (nota < menorNota)
            menorNota = nota;

        if (nota >= 8)
            notasExcelentes++;
        else if (nota >= 6)
            notasBoas++;
        else if (nota >= 5)
            notasRegulares++;
        else
            notasFracas++;

        notaDosAlunosEstagio.Add(nota);
    }

    double mediaNotaAlunos = notaDosAlunosEstagio.Sum() / notaDosAlunosEstagio.Count;

    if (mediaNotaAlunos >= 8)
        desempenhoTurma = EnumDesempenhoTurma.EXCELENTE;
    else if (mediaNotaAlunos >= 6)
        desempenhoTurma = EnumDesempenhoTurma.BOA;
    else if (mediaNotaAlunos >= 5)
        desempenhoTurma = EnumDesempenhoTurma.REGULAR;
    else
        desempenhoTurma = EnumDesempenhoTurma.FRACA;

    Console.WriteLine("=== RELATÓRIO DA TURMA ===");
    for (int i = 0; i < quantidadeAlunos; i++)
        Console.WriteLine($"Nota {i + 1}: {notaDosAlunosEstagio[i]}");

    Console.WriteLine();
    Console.WriteLine($"Média: {mediaNotaAlunos}");
    Console.WriteLine($"Maior: {maiorNota}");
    Console.WriteLine($"Menor: {menorNota}");
    Console.WriteLine($"Aprovados: {notasExcelentes}");
    Console.WriteLine($"Reprovados: {notasFracas}");
    Console.WriteLine($"Desempenho da turma: {desempenhoTurma}");
}


static void Questao04()
{
    Console.Clear();
    Dictionary<string, int> produtosEstoque = new() { { "Mouse", 10 }, { "Teclado", 6 }, { "Monitor", 4 }, { "Cabo HDMI", 18 }, { "Cadeira", 5 } };
    int produtosMenorQueOito = 0;

    Console.WriteLine("=== ESTOQUE INICIAL ===");
    foreach (var produto in produtosEstoque)
        Console.WriteLine($"{produto.Key} - {produto.Value} unidades");


    Console.WriteLine();
    Console.WriteLine("=== OPERAÇÕES ===");
    produtosEstoque.Add("SSD", 7);
    Console.WriteLine($"Adicionado: SSD ({produtosEstoque["SSD"]})");

    produtosEstoque["Teclado"] = 12;
    Console.WriteLine($"Adicionado: Teclado ({produtosEstoque["Teclado"]})");

    bool existeProdutoNoEstoque = produtosEstoque.ContainsKey("Webcam");
    Console.WriteLine($"Existe Webcam? {(existeProdutoNoEstoque ? "Sim" : "Não")}");


    produtosEstoque.Remove("Monitor");
    Console.WriteLine("Removido: Monitor");

    Console.WriteLine();
    Console.WriteLine($"== ITENS COM MENOS DE 8 NO ESTOQUE ===");
    foreach (var produto in produtosEstoque)
    {
        if (produto.Value < 8)
        {
            Console.WriteLine($"Produto: {produto.Key}");
            produtosMenorQueOito++;
        }
    }
    Console.WriteLine($"Estoque baixo ( menor que 8): {produtosMenorQueOito}\n");

    Console.WriteLine("=== ESTOQUE FINAL ===");
    foreach (var produto in produtosEstoque)
        Console.WriteLine($"{produto.Key} - {produto.Value} unidades");
}

Questao05();
static void Questao05()
{
    Console.Clear();
    string tipoPagamento;
    int descontoAdicional;
    int quantidadeDeParcela;
    decimal desconto = 0;
    decimal valorCompra;
    decimal taxaAdicional = 0;
    bool temDesconto;
    
    Console.WriteLine("Informe o nome do cliente.");
    string nomeCliente = Console.ReadLine();

    Console.WriteLine("Qual o valor da compra?");
    while (!decimal.TryParse(Console.ReadLine(), out valorCompra) || valorCompra < 1)
        Console.WriteLine("Digite um valor válido.");

    Console.WriteLine("Informe a forma de pagamento (DINHEIRO, PIX, DÉBITO OU CRÉDITO)");
    while (true)
    {
        tipoPagamento = Console.ReadLine();
        if (tipoPagamento != "DINHEIRO" && tipoPagamento != "PIX" && tipoPagamento != "DÉBITO" && tipoPagamento != "CRÉDITO")
            Console.WriteLine("Digite uma forma de pagamento válida.");
        else
            break;
    }

    if (tipoPagamento == "DINHEIRO")
        desconto += 5;
    else if (tipoPagamento == "PIX")
        desconto += 3;
    else if (tipoPagamento == "DÉBITO")
        desconto += 0;
    else
        taxaAdicional = 5;

    valorCompra += valorCompra * (taxaAdicional / 100m);
    bool possuiCupomConvertido;
    bool exit = true;

    Console.WriteLine("Possui cupom? s/n");
    while (exit)
    {
        var possuiCupom = Console.ReadLine().ToLower();
        switch (possuiCupom)
        {
            case "s":
                possuiCupomConvertido = true;
                desconto += 10;
                exit = false;
                break;

            case "n":
                possuiCupomConvertido = false;
                exit = false;
                break;
            default:
                Console.WriteLine("Digite s ou n");
                break;
        }
    }

    
    
    decimal valorCompraComDesconto = valorCompra * (desconto / 100m);    
    decimal valorFinal = valorCompra - valorCompraComDesconto;
    Console.WriteLine("=== COMPRA ONLINE ===");
    Console.WriteLine($"Cliente: {nomeCliente}\n");

    Console.WriteLine("CÁLCULO");
    Console.WriteLine($"Valor original: {valorCompra}");
    System.Console.WriteLine($"Cupom: {valorCompraComDesconto:C}");
    System.Console.WriteLine($"Valor final: {valorFinal:C}");
    System.Console.WriteLine($"Forma de pagamento: {tipoPagamento}");

    if(tipoPagamento == "CRÉDITO")
    {
        Console.WriteLine("Digite a quantidade de parcelas:");
        while(!int.TryParse(Console.ReadLine(), out quantidadeDeParcela) || quantidadeDeParcela < 1)
            Console.WriteLine("Digite uma quantidade válida.");
        
        if(quantidadeDeParcela > 0)
        {
            System.Console.WriteLine("Tipo: Parcelado.");
            Console.WriteLine($"Quantidade parcela: {quantidadeDeParcela} x {valorCompra/quantidadeDeParcela:C}");
        }
        else
            Console.WriteLine($"Tipo: À vista.");
    }
}

enum EnumDesempenhoTurma
{
    EXCELENTE,
    BOA,
    REGULAR,
    FRACA
}
