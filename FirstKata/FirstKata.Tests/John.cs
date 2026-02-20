namespace FirstKata.Tests;

public record John : Employee {
    John(float annualGrossSalary) : base(1234, "John", annualGrossSalary) {
        
    }

    public static John WithAnnualGross(float annualGross) => new(annualGross);
}