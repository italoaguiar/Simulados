using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simulados
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;

            string sql = "SELECTK_Table = FK.TABLE_NAME,FK_Column = CU.COLUMN_NAME,PK_Table = PK.TABLE_NAME,PK_Column = PT.COLUMN_NAME,Constraint_Name = C.CONSTRAINT_NAMEFROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS CINNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAMEINNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAMEINNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAMEINNER JOIN (SELECT i1.TABLE_NAME, i2.COLUMN_NAMEFROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAMEWHERE i1.CONSTRAINT_TYPE = \"PRIMARY KEY\") PT ON PT.TABLE_NAME = PK.TABLE_NAME";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Connect to the database then retrieve the schema information.
                connection.Open();
                DataTable table = connection.GetSchema("Tables");

                var sqlCnn = new SqlConnection(connectionString);
                try
                {
                    sqlCnn.Open();
                    var sqlCmd = new SqlCommand(sql, sqlCnn);
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    //DataTable schemaTable = sqlReader.GetSchemaTable();

                    GridView1.DataSource = sqlReader;
                    GridView1.DataBind();

                    //foreach (DataRow row in schemaTable.Rows)
                    //{
                    //    foreach (DataColumn column in schemaTable.Columns)
                    //    {
                    //        MessageBox.Show(string.Format("{0} = {1}", column.ColumnName, row[column]));
                    //    }
                    //}
                    sqlReader.Close();
                    sqlCmd.Dispose();
                    sqlCnn.Close();
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }

                

            }
        }
    }
}