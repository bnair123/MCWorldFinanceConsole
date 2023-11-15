namespace MCCityFinanceConsole;
using System.Collections.Generic;


public class EconomicData
{
    public int Population { get; set; }
    public double Gdp { get; set; }
    public double StockMarketValue { get; set; }
    public List<TaxBracket> TaxBrackets { get; set; }
    public IncomeBrackets CitizenIncome { get; set; }
    public IncomeBrackets CitizenIncomeBrackets { get; set; }
    public double CompanyIncome { get; set; }
    public int NumberOfCompanies { get; set; }
    public double SwfValue { get; set; }
    public double DividendRate { get; set; }
    public List<Loan> Loans { get; set; }
    public double AllocatedFunds { get; set; }
    public double SavingsRate { get; set; }
    public double CurrencyValue { get; set; }
    public double ElectricityKwhPerCitizen { get; set; }
    public double ElectricityExportPricePerKwh { get; set; }
    public double OilExportRevenue { get; set; }
    public Dictionary<string, int> PersonnelCosts { get; set; }
    public double PersonnelSalary { get; set; }
    public double InfrastructureCosts { get; set; }
    public double HealthcareCostsPerPerson { get; set; }
    public double RndExplorationCosts { get; set; }
    public double AdministrativeCosts { get; set; }
}