using System.ComponentModel.DataAnnotations;

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

static void questao02Prova02()
{
    decimal rendaMensal;
    decimal scoreCliente;
    int tempoDeEmpresaMeses;
    bool emprestimoAprovado;
    decimal valorEmprestimo = 0m;

    System.Console.WriteLine("Digite seu nome completo:");
    string nomeCliente = Console.ReadLine();

    System.Console.WriteLine("Digite sua renda mensal:");
    while(!decimal.TryParse(Console.ReadLine(), out rendaMensal) || rendaMensal < 1)
        System.Console.WriteLine("Digite um número válido.");

    System.Console.WriteLine("Digite seu score de crédito:");
    while(!decimal.TryParse(Console.ReadLine(), out scoreCliente) || scoreCliente < 1)
        System.Console.WriteLine("Digite um número válido.");

    System.Console.WriteLine("Quantos meses você está no emprego atual?");
    while(!int.TryParse(Console.ReadLine(), out tempoDeEmpresaMeses) || tempoDeEmpresaMeses < 1)
        System.Console.WriteLine("Digite um número válido.");
    
    if(rendaMensal >= 4000 || (rendaMensal >= 2800 && tempoDeEmpresaMeses >= 6))
    {
        emprestimoAprovado = true;
        valorEmprestimo = rendaMensal * 0.40m;
    }else if (rendaMensal >= 2000 && scoreCliente >= 650 && tempoDeEmpresaMeses > 10)
    {
        emprestimoAprovado = true;
        valorEmprestimo = rendaMensal * 0.25m;
    } else
        emprestimoAprovado = false;
    
    System.Console.WriteLine("=== ANÁLISE DE CRÉDITO ===");
    System.Console.WriteLine($"Cliente: {nomeCliente}");
    System.Console.WriteLine($"Renda Mensal: {rendaMensal:C}");
    System.Console.WriteLine($"Score: {scoreCliente}");
    System.Console.WriteLine($"Tempo de Emprega: {tempoDeEmpresaMeses} meses");
    System.Console.WriteLine($"Status {(emprestimoAprovado ? "Aprovado" : "Reprovado")}");
    System.Console.WriteLine($"Limite de Crédito: {valorEmprestimo:C}");
}

static void Questao03Prova02()
{
    List<decimal> listaDeVendas = new List<decimal>(){};
    int quantidadeDeVendas;
    int contadorVendasPremium = 0;
    decimal maiorVenda = decimal.MinValue;
    decimal menorVenda = decimal.MaxValue;
    string classificacaoVendas;
    

    System.Console.WriteLine("Quantas vendas foram realizadas?");
    while(!int.TryParse(Console.ReadLine(), out quantidadeDeVendas) || quantidadeDeVendas < 1)
        System.Console.WriteLine("Digite uma quantidade válida.");
    
    for(int i = 1; i <= quantidadeDeVendas; i++)
    {
        decimal valorVenda;
        System.Console.WriteLine($"Digite o valor da venda {i}:");
        while(!decimal.TryParse(Console.ReadLine(), out valorVenda) || valorVenda < 1)
            System.Console.WriteLine("Digite um valor válido.");
        
        if(valorVenda > 30)
            contadorVendasPremium++;
        
        if(valorVenda > maiorVenda)
            maiorVenda = valorVenda;
        
        if(valorVenda < menorVenda)
            menorVenda = valorVenda;

        listaDeVendas.Add(valorVenda);
    }
    
    decimal mediaDeVendas = listaDeVendas.Average();
    if(listaDeVendas.Sum() >= 200)
        classificacaoVendas = "Ótimo";
    else if(listaDeVendas.Sum() >= 120)
        classificacaoVendas = "Bom";
    else if(listaDeVendas.Sum() >= 60)
        classificacaoVendas = "Regular";
    else
        classificacaoVendas = "Fraco";

    System.Console.WriteLine("=== RELATÓRIO DO DIA ===");
    System.Console.WriteLine($"Faturamento total: {listaDeVendas.Sum():C}");
    System.Console.WriteLine($"Quantidade pedidos maior que R$ 30: {contadorVendasPremium}");
    System.Console.WriteLine($"Maior venda: {maiorVenda:C}");
    System.Console.WriteLine($"Menor venda: {menorVenda:C}");
    System.Console.WriteLine($"Status do dia: {classificacaoVendas}");
}

static void Questao04Prova02()
{
    List<string> listaRotina = new List<string>(){"Estudar lógica", "Fazer Exercícios", "Revisar conteúdo", "Enviar atividade"};
    
    listaRotina.ForEach(lista => System.Console.WriteLine(lista));
    System.Console.WriteLine("--------------------------------------\n");
    listaRotina.Add("Ler apostila");
    listaRotina.Insert(2, "Assistir Aula");
    bool temNaLista = listaRotina.Contains("Almoçar");
    if(temNaLista == false)
        listaRotina.Add("Almoçar");
    
    listaRotina.Remove("Revisar conteúdo");

    listaRotina.ForEach(lista => System.Console.WriteLine(lista));
}

Questao05Prova02();
static void Questao05Prova02()
{
    decimal salarioBruto;
    double horasExtras;
    decimal valorHorasExtras;
    bool valeTransporteConvertido;

    System.Console.WriteLine("Digite o nome do funcionário:");
    string nomeFucionario = Console.ReadLine();

    System.Console.WriteLine("Digite o Salário Bruto:");
    while(!decimal.TryParse(Console.ReadLine(), out salarioBruto) || salarioBruto < 1)
        System.Console.WriteLine("Digite uma entrada válida.");
    
    System.Console.WriteLine("Digite as horas extras:");
    while(!double.TryParse(Console.ReadLine(), out horasExtras) || horasExtras < 0)
        System.Console.WriteLine("Digite uma entrada válida");

    System.Console.WriteLine("Digite o valor por hora extras:");
    while(!decimal.TryParse(Console.ReadLine(), out valorHorasExtras) || valorHorasExtras < 1)
        System.Console.WriteLine("Digite uma entrada válida");


    System.Console.WriteLine("Recebe vale-transporte? (digite 'sim' ou 'não')");
    while(true)
    {
        string valeTransporte = Console.ReadLine().ToLower();
        if(valeTransporte == "sim")
        {
            valeTransporteConvertido = true;
            salarioBruto -= salarioBruto * 0.06m;
            break;
        }
        else if (valeTransporte == "não")
        {
            valeTransporteConvertido = false;
            break;
        }
        else
            System.Console.WriteLine("Digite sim ou não");
        
    }
    
    decimal calculoHoraExtra = (decimal)horasExtras * valorHorasExtras;
    decimal salarioBrutoComHoraExtra = salarioBruto + calculoHoraExtra;
    decimal salarioBrutoComDescontoInss = salarioBrutoComHoraExtra - (salarioBrutoComHoraExtra * 0.08m);

    System.Console.WriteLine("=== FOLHA DE PAGAMENTO ===");
    System.Console.WriteLine($"Bruto Total: {salarioBrutoComHoraExtra:C}");
    System.Console.WriteLine($"Horas Extras: {calculoHoraExtra:C}");
    System.Console.WriteLine($"Vale-Trasporte: {(valeTransporteConvertido ? "Sim" : "Não")}");
    System.Console.WriteLine($"INSS: {salarioBrutoComHoraExtra * 0.08m}");
}
enum EnumDesempenhoTurma
{
    EXCELENTE,
    BOA,
    REGULAR,
    FRACA,
}
