using Microsoft.AspNetCore.Mvc;

namespace prefinals_auth_ampong_jemicholouise.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            var bytes = new byte[256 / 8];
            rng.GetBytes(bytes);
            Console.WriteLine(Convert.ToBase64String(bytes));
        }
    }
}
