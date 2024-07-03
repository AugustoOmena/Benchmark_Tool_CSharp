using BenchmarkDotNet.Attributes;

namespace ConsoleApp;

public class ComparaBenchmark
{
    
    [Benchmark]
    public void solucaoAtual()
    {
        int maximumInstallments = checkoutConfig.MaximumNumberInstallments.HasValue ? checkoutConfig.MaximumNumberInstallments.Value : 12;
        int minimumAmount = checkoutConfig.MinimumAmountInstallment.HasValue ? checkoutConfig.MinimumAmountInstallment.Value : 1;

        while (paymentLink.Total / maximumInstallments < minimumAmount) { maximumInstallments--; }

        int valor = maximumInstallments; 
    }

    [Benchmark]
    public void solucaoAntica()
    {
        int maximumInstallments = checkoutConfig.MaximumNumberInstallments ?? 12;
        double minimumAmount = checkoutConfig.MinimumAmountInstallment ?? 1;
        
        double estimatedInstallments = (int)Math.Ceiling(paymentLink.Total / minimumAmount);
        
        if (paymentLink.Total / estimatedInstallments < minimumAmount){ estimatedInstallments--; }
        
        int var = Math.Min(maximumInstallments, (int)estimatedInstallments);
    }

    [Benchmark]
    public void solucaoColegas()
    {
        if (!checkoutConfig.MaximumNumberInstallments.HasValue ||
            !checkoutConfig.MinimumAmountInstallment.HasValue)
        {
            int valor = 12;
        }

        if (checkoutConfig.MinimumAmountInstallment.HasValue)
        {
            if (checkoutConfig.MinimumAmountInstallment.Value < paymentLink.Total)
            {
                var installments = (int)(paymentLink.Total / checkoutConfig.MinimumAmountInstallment.Value);

                if (checkoutConfig.MaximumNumberInstallments.HasValue)
                {
                    int valor = installments > checkoutConfig.MaximumNumberInstallments.Value ? 
                        checkoutConfig.MaximumNumberInstallments.Value : installments;
                }
            }
        }
    }
    
}

public static class paymentLink
{
    public static double Total { get; set; } = 157.70;
}
public static class checkoutConfig
{
    public static int? MaximumNumberInstallments { get; set; } = 24;
    public static int? MinimumAmountInstallment { get; set; } = 5;
}

