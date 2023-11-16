using MCCityFinanceConsole;

public class TaxCalculator
{
    private readonly EconomicData _economicData;

    public TaxCalculator(EconomicData economicData)
    {
        _economicData = economicData;
    }

    public double CalculateCitizenTaxRevenue()
    {
        double taxRevenue = 0;

        foreach (var bracket in _economicData.TaxBrackets)
        {
            double income = bracket.Min;
            int count = 0;

            if (income == _economicData.CitizenIncomeBrackets.Low)
            {
                count = _economicData.CitizenIncomeBrackets.LowCount;
            }
            else if (income == _economicData.CitizenIncomeBrackets.Median)
            {
                count = _economicData.CitizenIncomeBrackets.MedianCount;
            }
            else if (income == _economicData.CitizenIncomeBrackets.High)
            {
                count = _economicData.CitizenIncomeBrackets.HighCount;
            }
            
            taxRevenue += bracket.Rate * income * count;
        }

        return taxRevenue;
    }

    public double CalculateCompanyTaxRevenue()
    {
        double corporateRevenue = _economicData.Gdp * 0.3; // 30% of GDP is corporate revenue.
        double companyTaxRevenue = corporateRevenue * _economicData.CompanyIncome; // CompanyIncome is the tax rate.

        return companyTaxRevenue;
    }

    public double CalculateTotalTaxRevenue()
    {
        double citizenTaxRevenue = CalculateCitizenTaxRevenue();
        double companyTaxRevenue = CalculateCompanyTaxRevenue();
        
        return citizenTaxRevenue + companyTaxRevenue;
    }
}