using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Poliklinik_Defteri
{
    internal class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=PoliklinikDefteri;Integrated Security=True");
            baglanti.Open();
            return baglanti;

        }
        
        
    }
}
