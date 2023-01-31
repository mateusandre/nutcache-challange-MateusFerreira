using FluentValidation;
using Nutcache.Application.DTO;

namespace Nutcache.Application.Validations
{
    public class EmployeeDtoValidation : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please inform a valid E-mail.");
            RuleFor(x => x.Cpf).Must(IsCpfValid).WithMessage("Please inform a valid CPF.");
            RuleFor(x => x.StartDate).NotNull();
            RuleFor(x => x.Team).IsInEnum();
        }

        private bool IsCpfValid(string item)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var cpf = item.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (!cpf.EndsWith(digito))
                return false;

            return true;
        }
    }
}
