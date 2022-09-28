using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-40IUGLP;Initial Catalog=DbTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
