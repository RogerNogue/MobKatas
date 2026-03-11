namespace FirstKata.Tests;

public class SalarySlipGenerator {
    public SalarySlip GenerateFor(Employee employee) => SalarySlip.From(employee);
}