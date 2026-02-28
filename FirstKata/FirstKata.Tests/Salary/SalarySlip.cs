namespace FirstKata.Tests;

public record SalarySlip {
    public long Id;
    public string Name;
    public float MonthlyGrossSalary;
    public float NationalInsuranceContribution;
    public float TaxFreeAllowance { get; set; }
    public float TaxableIncome { get; set; }
    public float TaxPayable { get; set; }


    public SalarySlip(long id, string name) {
        Id = id;
        Name = name;
    }

    public SalarySlip WithMonthlyGross(float monthlyGross) {
        return this with { MonthlyGrossSalary = monthlyGross.RoundTwoDecimals() };
    }

    public SalarySlip WithNationalInsuranceContribution(float pounds) {
        return this with { NationalInsuranceContribution = pounds.RoundTwoDecimals() };
    }

    public SalarySlip WithTaxFreeAllowance(float pounds) {
        return this with { TaxFreeAllowance = pounds.RoundTwoDecimals() };
    }

    public SalarySlip WithTaxableIncome(float pounds) {
        return this with { TaxableIncome = pounds.RoundTwoDecimals() };
    }

    public SalarySlip WithTaxPayable(float pounds) {
        return this with { TaxPayable = pounds.RoundTwoDecimals() };
    }

    public override string ToString() {
        return $""" 
                Employee ID: {Id}
                Employee Name: {Name}
                Gross Salary: £{MonthlyGrossSalary}
                National Insurance Contribution: {NationalInsuranceContribution}
                Tax-free allowance: £{TaxFreeAllowance}
                Taxable income: £{TaxableIncome}
                Tax Payable: £{TaxPayable}
                """;
    }

    public static SalarySlip For(Employee employee) {
        return new(employee.Id, employee.Name);
    }

    public static SalarySlip From(Employee employee) {
        var salary = new Salary(employee.AnnualGrossSalary);
        
        return new SalarySlip(employee.Id, employee.Name)
            .WithMonthlyGross(salary.MonthlyGross())
            .WithNationalInsuranceContribution(salary.NationalInsuranceContribution())
            .WithTaxableIncome(salary.TaxableIncome())
            .WithTaxFreeAllowance(salary.TaxFreeAllowance())
            .WithTaxPayable(salary.MonthlyTaxPayable());
    }
}