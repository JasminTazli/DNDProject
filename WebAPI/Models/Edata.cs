namespace WebAPI.Models
{
    public class Edata
    {
        public int Environmentid { get; set; }
        public string? Unit { get; set; }
        public double TotalEnergy { get; set; }
        public double CrudeFuel { get; set; }
        public double GasFuel { get; set; }
        public double PurchElec { get; set; }
        public double RenewEnergy { get; set; }
        public double FossilEnergy { get; set; }
        public DateTime Year { get; set; }
    }
}