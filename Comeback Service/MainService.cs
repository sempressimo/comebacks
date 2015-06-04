using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;

namespace Comeback_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MainService : IService1
    {
        ComebackEntities db = new ComebackEntities();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string GetFilesPath(string Key, int Setting_ID)
        {
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["PointsCs"]);
                cn.Open();

                string Sql = "SELECT FilesPath FROM Settings WHERE Setting_ID = " + Setting_ID.ToString();

                SqlCommand cm = new SqlCommand(Sql, cn);
                cm.CommandType = CommandType.Text;

                object FPath = cm.ExecuteScalar();

                if (FPath != DBNull.Value)
                {
                    return FPath.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public void ImportComeback(string SecKey, string RO_Number, string VIN, DateTime ComebackDate, string Notes, int IsOpen)
        {
            try
            {
                Comeback C = new Comeback();

                C.ComebackDate = ComebackDate;
                C.ComebackReason_ID = null;
                C.Is_Comeback = false;
                C.IsOpen = 1;
                C.Notes = Notes;
                C.RO_Number = RO_Number;
                C.VIN = VIN;

                this.db.Comebacks.Add(C);
                this.db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
