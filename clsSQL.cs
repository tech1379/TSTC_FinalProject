using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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
        private static SqlCommand _sqlResultsCommand;
        private static SqlDataAdapter _daResults = new SqlDataAdapter();
        //add the data tables
        private static DataTable _dtResultsTable = new DataTable();
        private static string strTableName = "tekelle21fa2332.Inventory";
        private static string strTableName2 = "tekelle21fa2332.Coupons";
        private static string strTableName3 = "tekelle21fa2332.DayPrice";
        private static string strTableName4 = "tekelle21fa2332.State";

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
            string strCommand = $"SELECT CouponID, CouponPercent, ExpirationDate FROM {strTableName2};"; // Query to pull two columns of data from Images table            
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
                    coupon.dtExpirationDate = sqlReader.GetDateTime(2);
                    lstCoupon.Add(coupon); // Add image object to list

                    // You can use a constructor for this class to accept two parameters
                    // and add it all at the same time. Just for demo purposes

                    // lstImages.Add(new Images(sqlReader.GetInt32(0), (byte[])sqlReader[1]));
                }
                _cntDatabase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading coupons.", "Error with Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstCoupon;
        }
        public static List<clsDayPrice> LoadPrice()
        {
            //TODO: Change the SELECT statement to the column names you are trying to use.
            string strCommand = $"SELECT DayPriceID, DayPrice FROM {strTableName3};"; // Query to pull two columns of data from Images table            
            SqlCommand SelectCommand = new SqlCommand(strCommand, _cntDatabase);
            SqlDataReader sqlReader;

            List<clsDayPrice> lstDayPrice = new List<clsDayPrice>();
            lstDayPrice.Clear();// Empty the list before loading new images to prevent duplications
            try
            {
                _cntDatabase.Open();
                sqlReader = SelectCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    clsDayPrice dayPrice = new clsDayPrice();
                    dayPrice.intDayPriceID = sqlReader.GetInt32(0); // MS SQL Datatype int
                    dayPrice.decDayPrice = sqlReader.GetDecimal(1);
                    lstDayPrice.Add(dayPrice); // Add image object to list
                    
                    // You can use a constructor for this class to accept two parameters
                    // and add it all at the same time. Just for demo purposes

                    // lstImages.Add(new Images(sqlReader.GetInt32(0), (byte[])sqlReader[1]));
                }
                _cntDatabase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading day price.", "Error with Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstDayPrice;
        }
        public static List<clsState> LoadState()
        {
            //TODO: Change the SELECT statement to the column names you are trying to use.
            string strCommand = $"SELECT StateName, StateAbbrev FROM {strTableName4};"; // Query to pull two columns of data from Images table            
            SqlCommand SelectCommand = new SqlCommand(strCommand, _cntDatabase);
            SqlDataReader sqlReader;

            List<clsState> lstState = new List<clsState>();
            lstState.Clear();// Empty the list before loading new images to prevent duplications
            try
            {
                _cntDatabase.Open();
                sqlReader = SelectCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    clsState state = new clsState();
                    state.strStateName = sqlReader.GetString(0); // MS SQL Datatype int
                    state.strStateAbbv = sqlReader.GetString(1);
                    lstState.Add(state); // Add image object to list

                    // You can use a constructor for this class to accept two parameters
                    // and add it all at the same time. Just for demo purposes

                    // lstImages.Add(new Images(sqlReader.GetInt32(0), (byte[])sqlReader[1]));
                }
                _cntDatabase.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading day price.", "Error with Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstState;
        }
        public static void DatabaseCommand(string query, DataGridView dgvResults)
        {
            try 
            { 
            SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
            //OPEN DB
            _cntDatabase.Open();
            //set cmd obj to null
            _sqlResultsCommand = null;
            //reset data adapter and data table to new
            _daResults = new SqlDataAdapter();
            _dtResultsTable = new DataTable();

         
                //est command obj
                _sqlResultsCommand = new SqlCommand(query, _cntDatabase);
                //est data adapter
                _daResults.SelectCommand = _sqlResultsCommand;
                //fill data table
                _daResults.Fill(_dtResultsTable);
                //bind to dgv to data table
                dgvResults.DataSource = _dtResultsTable;
                //dispose of cmd, adapter, and table obj
                _sqlResultsCommand.Dispose();
                _daResults.Dispose();
                _dtResultsTable.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public static void DatabaseCommandAddItem(string strItemName, string strItemDesc, decimal decRetailPrice, decimal decCost, int intQuantity)
        {

            MessageBox.Show("You must add an image to save to the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //OpenFileDialog Properties------------------------------------------
                OpenFileDialog openFile = new OpenFileDialog(); //New instance
                openFile.ValidateNames = true; //Prevent illegal characters
                openFile.AddExtension = false; //Auto fixes file extension problems
                openFile.Filter = "Image File|*.png|Image File|*.jpg"; //Allow types
                openFile.Title = "File to Upload"; //Title of dialog box
                                                   //-------------------------------------------------------------------

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    //TODO: Add some validation to make sure the file is an image.

                    byte[] image = File.ReadAllBytes(openFile.FileName); //Convert image into a byte array
                    try
                    {
                        _cntDatabase.Open();
                        //TODO: Change (Image) to the name of your image column [e.g (ProductImages)]
                        string insertQuery = $"INSERT INTO {strTableName} VALUES('" + strItemName + "', '" + strItemDesc + "', " + decRetailPrice + ", " + decCost + ", " + intQuantity + ", @Image, NULL)"; // @Image is a parameter we will fill in later                        
                        SqlCommand insertCmd = new SqlCommand(insertQuery, _cntDatabase);
                        SqlParameter sqlParams = insertCmd.Parameters.AddWithValue("@Image", image); // The parameter will be the image as a byte array
                        sqlParams.DbType = System.Data.DbType.Binary; // The type of data we are sending to the server will be a binary file
                        insertCmd.ExecuteNonQuery();
                        _cntDatabase.Close();

                        MessageBox.Show("File was successfully added to the database.", "File Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error During Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }
    }

}

