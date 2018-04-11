using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenData;

namespace mDB
{
    public class DataTable
    {

        private static int count = 0;
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        

        public void InsertData(FarmTran item)
        {
            count += 1;

            
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"insert into Farmtran (Id,交易日期,作物代號,作物名稱,市場代號,市場名稱,上價,中價,下價,平均價,交易量) " +
                                                        $"values ('{count}','{item.transactionDate}','{item.cropCode}',N'{item.cropName}','{item.marketCode}',N'{item.marketName}','{item.priceHigh}','{item.priceMid}','{item.priceLow}','{item.priceAvg}','{item.transactionNum}')");
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void QueryData(string Row, string Name) {
           connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"SELECT * FROM FarmTran WHERE {Row}= N'{Name}' ");
  
            SqlDataReader reader = cmd.ExecuteReader();

            try{
                while (reader.Read()){
                    Console.WriteLine("Execute Query");
                    Console.WriteLine(String.Format($"{reader[0]}, {reader[1]}, {reader[2]}, {reader[3]}, {reader[4]}, {reader[5]}"));
                }
            }
            finally{
                reader.Close();

            }
            connection.Close();
        }
    }
}
