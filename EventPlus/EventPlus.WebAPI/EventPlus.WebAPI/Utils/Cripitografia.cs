namespace EventPlus.WebAPI.Utils;

public class Cripitografia
{
    public static string GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    } 
     
    public static bool compararHash(string senhaInformal,string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaInformal, senhaBanco);
    }
}
