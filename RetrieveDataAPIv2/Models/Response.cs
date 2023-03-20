namespace RetrieveDataAPIv2.Models
{
    public class Response
    {
        public int Statuscode { get; set; }
        public string StatusMessage { get; set; }
        public CierreCajaInfo cierreCajaInfo { get; set; }
        public List<CierreCajaInfo> cierreCajaInfoList { get; set; }

    }
}
