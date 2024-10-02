namespace depsmvp.application.Validators;

public class CNPJValidator
{
    public static bool IsValidCnpj(string cnpj)
    {
        cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

        if ((cnpj.Length != 14) || new string(cnpj[0], cnpj.Length) == cnpj)
        {
            return false;
        }

        var cnpjTemp = cnpj.Substring(0, 12);
        var firstVerifyingDigit = CalculateVerifyingDigit(cnpjTemp);
        var secondVerifyingDigit = CalculateVerifyingDigit(cnpjTemp + firstVerifyingDigit);

        return cnpj.EndsWith(firstVerifyingDigit.ToString() + secondVerifyingDigit.ToString());
    }

    private static int CalculateVerifyingDigit(string cnpj)
    {
        int[] weight = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        if (cnpj.Length == 13) 
        {
            weight = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        }

        int sum = 0;
        for (int i = 0; i < cnpj.Length; i++)
        {
            sum += int.Parse(cnpj[i].ToString()) * weight[i];
        }

        var remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}