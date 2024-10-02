namespace depsmvp.application.Validators;

public class CPFValidator
{
    public static bool IsValidCpf(string cpf)
    {
        cpf = cpf.Trim().Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        if (cpf.All(c => c == cpf[0]))
            return false;

        if (!ValidarDigitoVerificador(cpf, 9))
            return false;

        if (!ValidarDigitoVerificador(cpf, 10))
            return false;

        return true;
    }

    private static bool ValidarDigitoVerificador(string cpf, int posicao)
    {
        int soma = 0;
        int peso = posicao + 1;

        for (int i = 0; i < posicao; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * peso--;
        }

        int resultado = (soma * 10) % 11;
        if (resultado == 10)
        {
            resultado = 0;
        }

        return resultado == int.Parse(cpf[posicao].ToString());
    }

}