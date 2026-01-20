using System.Linq;
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

    System.Console.WriteLine("Nome do aluno: ");
    while (string.IsNullOrWhiteSpace(nomeAluno = Console.ReadLine()))
        Console.WriteLine("Nome inválido.");

    System.Console.WriteLine("Qual a porcentagem de frequência do aluno?");
    while (!double.TryParse(Console.ReadLine(), out frequencia) || frequencia > 100 || frequencia < 0)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    System.Console.WriteLine("Digite a primeira nota.");
    while (!double.TryParse(Console.ReadLine(), out nota1) || nota1 < 0 || nota1 > 10)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    System.Console.WriteLine("Digite a segunda nota.");
    while (!double.TryParse(Console.ReadLine(), out nota2) || nota2 < 0 || nota2 > 10)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    System.Console.WriteLine("Digite a terceira nota.");
    while (!double.TryParse(Console.ReadLine(), out nota3) || nota3 < 0 || nota3 > 10)
        System.Console.WriteLine("ERRO. Digite uma entrada válida(Número positivo)");

    double mediaPonderada = ((nota1 * 1) + (nota2 * 5) + (nota3 * 4)) / 10;

    if (frequencia < frequenciaMinima)
        statusAluno = "Reprovado";
    else if (mediaPonderada >= 7)
        statusAluno = "Aprovado";
    else if (mediaPonderada < 7 && mediaPonderada >= 5)
        statusAluno = "Recuperação";
    else
        statusAluno = "Reprovado";

    System.Console.WriteLine("=== BOLETIM FINAL ===");
    System.Console.WriteLine($"Aluno: {nomeAluno}");
    System.Console.WriteLine($"Notas: {nota1}, {nota2}, {nota3}");
    System.Console.WriteLine($"Média: {mediaPonderada}");
    System.Console.WriteLine($"Frequência: {(frequencia / 100):P2}");
    System.Console.WriteLine();
    System.Console.WriteLine($"Situação: {statusAluno}");
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

    System.Console.WriteLine("Qual a quantidade de alunos da turma de estagiários?");
    while (!int.TryParse(Console.ReadLine(), out quantidadeAlunos) || quantidadeAlunos <= 0)
        System.Console.WriteLine("Quantidade de alunos inválida.");

    double maiorNota = double.MinValue;
    double menorNota = double.MaxValue;

    for (int i = 0; i < quantidadeAlunos; i++)
    {
        double nota;
        System.Console.WriteLine($"Informe a nota do aluno {i + 1}");
        while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            System.Console.WriteLine("Digite um número válido");

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

    System.Console.WriteLine("=== RELATÓRIO DA TURMA ===");
    for (int i = 0; i < quantidadeAlunos; i++)
        System.Console.WriteLine($"Nota {i + 1}: {notaDosAlunosEstagio[i]}");

    System.Console.WriteLine();
    System.Console.WriteLine($"Média: {mediaNotaAlunos}");
    System.Console.WriteLine($"Maior: {maiorNota}");
    System.Console.WriteLine($"Menor: {menorNota}");
    System.Console.WriteLine($"Aprovados: {notasExcelentes}");
    System.Console.WriteLine($"Reprovados: {notasFracas}");
    System.Console.WriteLine($"Desempenho da turma: {desempenhoTurma}");
}

enum EnumDesempenhoTurma
{
    EXCELENTE,
    BOA,
    REGULAR,
    FRACA
}
