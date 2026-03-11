namespace FirstKata.Tests;

public record Salary(float AnnualGrossSalary) {
    public const int MinimumAnnualGrossToApplyNationalInsuranceTramo1 = 8_060;
    public const int MinimumAnnualGrossToApplyNationalInsuranceTramo2 = 43_000;
    public const float MinimumNationalInsuranceTaxTramo1 = .12f;
    public const float MinimumNationalInsuranceTaxTramo2 = .02f;
    public const int MinimumAnnualGrossToApplyTaxPayableTramo1 = 11_000;
    public const int MinimumAnnualGrossToApplyTaxPayableTramo2 = 43_000;
    public const float TaxPayablePercentageTramo1 = .2f;
    public const float TaxPayablePercentageTramo2 = .4f;

    public float NationalInsuranceContribution() {
        var tramo1 = NationalInsuranceContributionTramo1();
        var tramo2 = NationalInsuranceContributionTramo2();
        return (tramo1 + tramo2).Monthly();
    }

    float NationalInsuranceContributionTramo1() {
        if (AnnualGrossSalary <= MinimumAnnualGrossToApplyNationalInsuranceTramo1)
            return 0;
        
        return (Math.Min(AnnualGrossSalary, MinimumAnnualGrossToApplyNationalInsuranceTramo2) - MinimumAnnualGrossToApplyNationalInsuranceTramo1) * MinimumNationalInsuranceTaxTramo1;
    }
    
    float NationalInsuranceContributionTramo2() {
        if (AnnualGrossSalary <= MinimumAnnualGrossToApplyNationalInsuranceTramo2)
            return 0;
        
        return (AnnualGrossSalary - MinimumAnnualGrossToApplyNationalInsuranceTramo2) * MinimumNationalInsuranceTaxTramo2;
    }

    public float MonthlyGross() {
        return AnnualGrossSalary.Monthly();
    }

    public float MonthlyTaxPayable() {
        if (AnnualGrossSalary <= MinimumAnnualGrossToApplyTaxPayableTramo1) {
            return 0;
        }

        var tramo1 = TaxableIncomeTramo1() * TaxPayablePercentageTramo1;
        var tramo2 = TaxableIncomeTramo2() * TaxPayablePercentageTramo2;
        return (tramo1 + tramo2).RoundTwoDecimals();
    }

    public float TaxFreeAllowance() {
        if (AnnualGrossSalary <= MinimumAnnualGrossToApplyTaxPayableTramo1) {
            return 0;
        }

        return (MonthlyGross() - TaxableIncome()).RoundTwoDecimals();
    }

    public float TaxableIncome() {
        return (TaxableIncomeTramo1() + TaxableIncomeTramo2()).RoundTwoDecimals();
    }

    float TaxableIncomeTramo1() {
        if (AnnualGrossSalary <= MinimumAnnualGrossToApplyTaxPayableTramo1) {
            return 0;
        }

        var maxGross = Math.Min(AnnualGrossSalary, 43_000);
        return (maxGross - MinimumAnnualGrossToApplyTaxPayableTramo1).Monthly();
    }

    float TaxableIncomeTramo2() {
        if (AnnualGrossSalary <= MinimumAnnualGrossToApplyTaxPayableTramo2) {
            return 0;
        }

        return (AnnualGrossSalary - MinimumAnnualGrossToApplyTaxPayableTramo2).Monthly();
    }
}