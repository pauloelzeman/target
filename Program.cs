using System;
using System.Linq;
class Program
{
    static void Main()
    {
        // Exemplo de vetor com faturamento diário (0 representa dias sem faturamento)
        double[] faturamento = new double[]
        {
            0, 0, 0, 0, 0, 0, 0, // Finais de semana e feriados
            200, 250, 300, 0, 100, // Faturamento de alguns dias
            // ... (adicione aqui o resto do vetor com 365 elementos)
        };

        var resultado = CalcularFaturamento(faturamento);

        Console.WriteLine($"Menor valor de faturamento: {resultado.MenorValor}");
        Console.WriteLine($"Maior valor de faturamento: {resultado.MaiorValor}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {resultado.DiasAcimaDaMedia}");
    }

    public static FaturamentoResult CalcularFaturamento(double[] faturamento)
    {
        // Filtra os valores de faturamento válidos (não-zero)
        var faturamentoValidos = faturamento.Where(valor => valor > 0).ToArray();

        // Verifica se há dados de faturamento válidos
        if (!faturamentoValidos.Any())
        {
            return new FaturamentoResult
            {
                MenorValor = null,
                MaiorValor = null,
                DiasAcimaDaMedia = 0
            };
        }

        // Calcula o menor valor de faturamento
        double menorValor = faturamentoValidos.Min();
        
        // Calcula o maior valor de faturamento
        double maiorValor = faturamentoValidos.Max();
        
        // Calcula a média anual de faturamento
        double mediaAnual = faturamentoValidos.Average();
        
        // Conta o número de dias com faturamento acima da média
        int diasAcimaDaMedia = faturamentoValidos.Count(valor => valor > mediaAnual);
        
        return new FaturamentoResult
        {
            MenorValor = menorValor,
            MaiorValor = maiorValor,
            DiasAcimaDaMedia = diasAcimaDaMedia
        };
    }
}

// Classe para armazenar os resultados
public class FaturamentoResult
{
    public double? MenorValor { get; set; }
    public double? MaiorValor { get; set; }
    public int DiasAcimaDaMedia { get; set; }
}
