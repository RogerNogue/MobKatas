using static FirstKata.Tests.SalarySlipGenerator;

namespace FirstKata.Tests;

public class UnitTest1 {
    [Fact]
    public void AnnualGrossOf_5000_DoesNotHaveTaxes() {
        var john = John.WithAnnualGross(5_000);

        var result = new SalarySlipGenerator().GenerateFor(john);
  
        var expected = SalarySlip.For(john).WithMonthlyGross(416.67f);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PayNationalInsuranceContribution() {
        var john = John.WithAnnualGross(9_060);

        var result = new SalarySlipGenerator().GenerateFor(john);

        var expected = SalarySlip.For(john)
            .WithMonthlyGross(755.00f)
            .WithNationalInsuranceContribution(10);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SkipNationalInsuranceContribution_UntilSurpassingLimit() {
        var john = John.WithAnnualGross(Salary.MinimumAnnualGrossToApplyNationalInsuranceTramo1);

        var result = new SalarySlipGenerator().GenerateFor(john);

        var expected = SalarySlip.For(john).WithMonthlyGross(671.67f);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PayNationalInsuranceAboveMinimumContribution() {
        var john = John.WithAnnualGross(10_000);

        var result = new SalarySlipGenerator().GenerateFor(john);

        var expected = SalarySlip.For(john)
            .WithMonthlyGross(833.33f)
            .WithNationalInsuranceContribution(19.4f);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ApplyTaxableIncome_Above11K() {
        var john = John.WithAnnualGross(12_000);
        
        var result = new SalarySlipGenerator().GenerateFor(john);

        var expected = SalarySlip.For(john)
            .WithMonthlyGross(1_000)
            .WithNationalInsuranceContribution(39.40f)
            .WithTaxFreeAllowance(916.67f)
            .WithTaxableIncome(83.33f)
            .WithTaxPayable(16.67f);
        
        Assert.Equal(expected, result);
    }
    
    // Employee ID: 12345
    // Employee Name: John J Doe
    //     Gross Salary: £3,750.00
    // National Insurance contributions: £352.73
    // Tax-free allowance: £916.67
    // Taxable income: £2,833.33
    // Tax Payable: £600.00
    [Fact]
    public void HigherTaxableIncome_AndNationalInsurance_Above43K() {
        var john = John.WithAnnualGross(45_000);
        
        var result = new SalarySlipGenerator().GenerateFor(john);

        var expected = SalarySlip.For(john)
            .WithMonthlyGross(3_750f)
            .WithNationalInsuranceContribution(352.73f)
            .WithTaxFreeAllowance(916.67f)
            .WithTaxableIncome(2833.33f)
            .WithTaxPayable(600.00f);
        
        Assert.Equal(expected, result);
    }
}