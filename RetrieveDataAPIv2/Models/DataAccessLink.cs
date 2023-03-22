using System.Data;
using System.Data.SqlClient;

namespace RetrieveDataAPIv2.Models
{
    public class DataAccessLink
    {
        public Response GetAllSitrnTable(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter queryAdapter = new SqlDataAdapter(
                "select sit.sitrnntra, sit.sitrnnvia, sit.sitrncusr , sit.sitrnnomb, sit.sitrnndoc, sit.sitrnimpt, sit.sitrnuser, sit.sitrnhora, sit.sitrnftra, sit.sitrncser, si.sisevdesc, si.sisevcser, sit.sitrncmon from sitrn sit inner join sisev si on si.sisevcser  = sit.sitrncser  where sit.sitrnftra = '2019-06-23' and sit.sitrnnvia = 2 and sit.sitrncvia = 1 order by si.sisevcser asc",
                connection);
            DataTable dt = new DataTable();
            List<CierreCajaInfo> cierreCajaInfoList = new List<CierreCajaInfo>();
            queryAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CierreCajaInfo info = new CierreCajaInfo();
                    info.SITRNNTRA = Convert.ToInt32(dt.Rows[i]["sitrnntra"]);
                    info.SITRNNVIA = Convert.ToString(dt.Rows[i]["sitrnnvia"]);
                    info.SITRNCUSR = Convert.ToString(dt.Rows[i]["sitrncusr"]);
                    info.SITRNNOMB = Convert.ToString(dt.Rows[i]["sitrnnomb"]);
                    info.SITRNNDOC = Convert.ToString(dt.Rows[i]["sitrnndoc"]);
                    info.SITRNIMPT = Convert.ToString(dt.Rows[i]["sitrnimpt"]);
                    info.SITRNUSER = Convert.ToString(dt.Rows[i]["sitrnuser"]);
                    info.SITRNCSER = Convert.ToString(dt.Rows[i]["sitrncser"]);
                    info.SITRNHORA = Convert.ToString(dt.Rows[i]["sitrnhora"]);
                    info.SITRNCMON = Convert.ToString(dt.Rows[i]["sitrncmon"]);
                    info.SITRNFTRA = Convert.ToString(dt.Rows[i]["sitrnftra"]);//-----------
                  //  info.SITRNAGEN = Convert.ToString(dt.Rows[i]["sitrnagen"]);
                  //  info.SITRNCVIA = Convert.ToString(dt.Rows[i]["sitrncvia"]);
                    info.SISEVDESC = Convert.ToString(dt.Rows[i]["sisevdesc"]);
                    info.SISEVCSER = Convert.ToString(dt.Rows[i]["sisevcser"]);
                    cierreCajaInfoList.Add(info);
                }
            }

            ConnectionHelper helper = new ConnectionHelper(connection);

            if(!helper.isConnected())
            {
                response.Statuscode = 500;
                response.StatusMessage = "Connection failed";
                response.cierreCajaInfoList = null;
            }
           
            if(cierreCajaInfoList.Count > 0)
            {
                response.Statuscode = 200;
                response.StatusMessage = "Data found";
                response.cierreCajaInfoList = cierreCajaInfoList;
            }
            else
            {
                response.Statuscode = 400;
                response.StatusMessage = "No data found";
                response.cierreCajaInfoList = null;
            }

            return response;
        }
    }
}
//https://localhost:7088/api/CCInfo/GetAllSitrnTable
//sit.sitrnftra = '2019-06-23' and
