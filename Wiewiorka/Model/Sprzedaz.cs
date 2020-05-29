using System;

namespace Wiewiorka.Model
{
    public class Sprzedaz
    {
        public int productId { get; set; }
        public int ilosc { get; set; }
        public double cena { get; set; }
        public DateTime data { get; set; }
        public int pracownikId { get; set; }
        public int sklepId { get; set; }

    }
}