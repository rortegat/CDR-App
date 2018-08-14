using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CDRTools.Models;
using System.IO;


namespace CDRTools.DBServices
{
    public class FilterDBService { 
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["CDRToolsConnection"].ConnectionString);
    
        public DataSet  Show_data(string ini,string fin, string ex)
        {
            SqlCommand com = new SqlCommand("Llamadas_Filtro", conex);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@dataINI",ini);
            com.Parameters.AddWithValue("@dataFIN", fin);
            com.Parameters.AddWithValue("@extList", ex);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}