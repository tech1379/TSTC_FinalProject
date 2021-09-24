using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FA21_Final_Project
{
    class clsSQL
    {
        public static string message = "I'm sorry an error has occurred in the program. \n\n" +
    "Please inform the Program Developer that the following error occurred: \n\n\n";
        //connection string
        private const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database= inew2332fa21;User Id=tekelle21fa2332;password=1517940";
        //build a connection to database
        private static SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
        private static SqlCommand _sqlLogOnCommand;
        private static SqlCommand _sqlUpdateCommand;
        private static string strTableName = "tekelle21fa2332.Inventory";
        private static string strTableName2 = "tekelle21fa2332.Coupons";

        public static void ConnectDatabase()
        {
            try
            {
                SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
                //open the connection to db
                _cntDatabase.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message,"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string DatabaseCommandLogon(string query)
        {
            string result = "";
            try
            {
                SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
                //open the connection to db
                _cntDatabase.Open();
                //establish command object
                _sqlLogOnCommand = new SqlCommand(query, _cntDatabase);
                result = Convert.ToString(_sqlLogOnCommand.ExecuteScalar());
                _cntDatabase.Close();
                //dispose
                _cntDatabase.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return result;
        }
        public static void UpdateDatabase(string strQuery)
        {
            try
            {
                SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
                //OPEN DB
                _cntDatabase.Open();
                //string to build query
                //establish command object
                _sqlUpdateCommand = new SqlCommand(strQuery, _cntDatabase);
                _sqlUpdateCommand.ExecuteNonQuery();
                //dispose of pub objects
                _sqlUpdateCommand.Dispose();
                //close connection
                _cntDatabase.Close();
                //dispose
                _cntDatabase.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message,"Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static List<clsInventory> ReloadImageList()
        {
            //TODO: Change the SELECT statement to the column names you are trying to use.
            string strCommand = $"SELECT InventoryID, ItemName, ItemDescription, RetailPrice, Cost, Quantity, ItemImage, Discontinued FROM {strTableName};"; // Query to pull two columns of data from Images table            
            SqlCommand SelectCommand = new SqlCommand(strCommand, _cntDatabase);
            SqlDataReader sqlReader;
            
            List<clsInventory> lstInventory = new List<clsInventory>();
            lstInventory.Clear();// Empty the list before loading new images to prevent duplications
            try
            {
                _cntDatabase.Open();
                sqlReader = SelectCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    clsInventory inventory = new clsInventory();
                    inventory.intInventoryID = sqlReader.GetInt32(0); // MS SQL Datatype int
                    inventory.strItemName = sqlReader.GetString(1);
                    inventory.strItemDescription = sqlReader.GetString(2); // MS SQL Datatype int
                    inventory.decRetailPrice = (sqlReader.GetDecimal(3));
                    inventory.decCost = (sqlReader.GetDecimal(4));
                    inventory.intQuantity = sqlReader.GetInt32(5);
                    inventory.bytImage = (byte[])sqlReader[6];
                    if (!(sqlReader.IsDBNull(7)))                  
                    {
                        inventory.boolDiscontinued = Convert.ToBoolean(sqlReader.GetBoolean(7));
                    }
                    lstInventory.Add(inventory); // Add image object to list

                    // You can use a constructor for this class to accept two parameters
                    // and add it all at the same time. Just for demo purposes

                    // lstImages.Add(new Images(sqlReader.GetInt32(0), (byte[])sqlReader[1]));
                }
                _cntDatabase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error reloading images.", "Error with Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstInventory;
        }
        public static List<clsCoupon> LoadCoupons()
        {
            //TODO: Change the SELECT statement to the column names you are trying to use.
            string strCommand = $"SELECT CouponID, CouponPercent FROM {strTableName2};"; // Query to pull two columns of data from Images table            
            SqlCommand SelectCommand = new SqlCommand(strCommand, _cntDatabase);
            SqlDataReader sqlReader;

            List<clsCoupon> lstCoupon = new List<clsCoupon>();
            lstCoupon.Clear();// Empty the list before loading new images to prevent duplications
            try
            {
                _cntDatabase.Open();
                sqlReader = SelectCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    clsCoupon coupon = new clsCoupon();
                    coupon.intCouponID = sqlReader.GetInt32(0); // MS SQL Datatype int
                    coupon.decCouponPercent = sqlReader.GetDecimal(1);
                    lstCoupon.Add(coupon); // Add image object to list

                    // You can use a constructor for this class to accept two parameters
                    // and add it all at the same time. Just for demo purposes

                    // lstImages.Add(new Images(sqlReader.GetInt32(0), (byte[])sqlReader[1]));
                }
                _cntDatabase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error reloading images.", "Error with Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstCoupon;
        }
    }
}

