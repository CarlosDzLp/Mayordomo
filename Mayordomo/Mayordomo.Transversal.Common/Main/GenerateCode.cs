using Mayordomo.Transversal.Common.Interfaces;
using Mayordomo.Transversal.Logging.Main;

namespace Mayordomo.Transversal.Common.Main
{
    public class GenerateCode : IGenerateCode
    {
        public GenerateCode(IAppLogger<GenerateCode> logger)
        {
            this.logger = logger;
        }

        private readonly HashSet<int> _issued = new();
        private readonly Random _random = new();
        private readonly IAppLogger<GenerateCode> logger;

        /// <summary>
        /// Genera un número positivo (incluido cero) de N dígitos sin repetirse.
        /// </summary>
        /// <param name="n">Cantidad de dígitos</param>
        public int GenerateCodeAsync(int digits)
        {
            try
            {
                if (digits < 1 || digits > 9)
                    throw new ArgumentOutOfRangeException(nameof(digits), "N debe estar entre 1 y 9.");

                int min = (int)Math.Pow(10, digits - 1);
                int max = (int)Math.Pow(10, digits) - 1;

                // si piden 1 dígito, el mínimo debe ser 0
                if (digits == 1) min = 0;

                int number;
                do
                {
                    number = _random.Next(min, max + 1); // incluye el max
                }
                while (!_issued.Add(number)); // evita repetidos

                return number;
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return 0;
            }
        }
    }
}
