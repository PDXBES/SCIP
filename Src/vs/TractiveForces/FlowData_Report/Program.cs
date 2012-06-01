using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using RavSoft;

namespace TractiveForceAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
			uint logLevels = (uint)(EZLogger.Level.Debug | 
                                                            EZLogger.Level.Error | 
                                                            EZLogger.Level.Fatal | 
                                                            EZLogger.Level.Success |
                                                            EZLogger.Level.Warning);
            EZLogger logger =
                    new EZLogger("P:\\SCIP\\Phase_1\\Scripts\\C#\\TractiveForceTest.log",
                          false,
                          logLevels);
            bool bStatus = logger.Start();

             try
            {
				DataTable mstLinkDataTable = GetDataTable("SELECT * FROM [MODELING_DEV].[ModelAdmin].[v_mst_link_tractive_force_data]");
				//DataTable flowDataTable = GetDataTable("SELECT *  FROM [SCIP].[dbo].[VW_DWF_FLOW_STATISTICS]");

				double counter = 0;
				for (int i = 0; i <= mstLinkDataTable.Rows.Count - 1; i++)
				{
					counter++;
					if (counter / 1 == Math.Round(counter / 1))
						Console.WriteLine("Writing Record # {0}", counter);
					
					// Create a new TractiveForceRecord
					logger.Info("Initializing TractiveForceRecord");
					TractiveForceRecord tractiveForceRecord = new TractiveForceRecord();

					// Extract data from vwDWF_Flow_Statistics
					logger.Info("Extract data from v_mst_link_tractive_force_data");
					tractiveForceRecord.MLinkID = ConvertStringToInt(mstLinkDataTable.Rows[i][0].ToString());
					tractiveForceRecord.SimlinkID = "M" + mstLinkDataTable.Rows[i][0].ToString();
					tractiveForceRecord.CompKey = ConvertStringToInt(mstLinkDataTable.Rows[i][1].ToString());
					tractiveForceRecord.DiamWidth_in = Convert.ToDouble(mstLinkDataTable.Rows[i][2].ToString());
					tractiveForceRecord.DiamWidth_ft = Convert.ToDouble(mstLinkDataTable.Rows[i][3].ToString());
					if (string.IsNullOrEmpty(mstLinkDataTable.Rows[i][4].ToString()))
						tractiveForceRecord.PipeMaterial = "";
					else
						tractiveForceRecord.PipeMaterial = mstLinkDataTable.Rows[i][4].ToString();
					tractiveForceRecord.ManningsN = Convert.ToDouble(mstLinkDataTable.Rows[i][5].ToString());
					tractiveForceRecord.PipeSlope = Convert.ToDouble(mstLinkDataTable.Rows[i][6].ToString());

					// Get flow data from SCIP
					logger.Info("start ExtractFlowData");
					tractiveForceRecord.ExtractFlowData();

					// Now that all other parameters have been set, CalculateForces will
					// run all the Tractive Force calculations
					logger.Info("CalculateForces");
					tractiveForceRecord.CalculateForces();

					logger.Info("AddNewTractiveForceRecord");
					AddNewTractiveForceRecord(tractiveForceRecord, logger);

				}
			}
			catch (Exception e)
			{
				logger.Fatal("A " + e.Message + " error occurred accessing the database");
			}
			finally
			{
				logger.Success("Process Completed!!!!");
			}

        }

        /// <summary>
        ///  Adds a new TractiveForceRecord to the database using a Stored Procedure
        /// </summary>
        /// <param name="scipConnection">Connection to the database</param>
        /// <param name="tractiveForceRecord">A TractiveForceRecord </param>
        private static void AddNewTractiveForceRecord(TractiveForceRecord tractiveForceRecord, EZLogger logger)
        {
			SqlConnection conn = new SqlConnection();
			// Open a connection to the local SCIP Database
			// OLD
			//scipConnection.ConnectionString = "Integrated Security=true;" +
			//                                                                  "Initial Catalog=SCIP_Test;" +
			//                                                                  "Data Source=WS11285\\SQLEXPRESS";
			// Open a connection to Sirtoby\SCIP
			conn.ConnectionString = "Integrated Security=true;" +
																			  "Initial Catalog=SCIP;" +
																			  "Data Source=SIRTOBY";
			conn.Open();

			SqlDataReader reader = null;

            try
            {
                  // Create a Command object identifying the stored procedure
				SqlCommand cmdInsert = new SqlCommand("SP_INSERT_TRACTIVE_FORCE_DATA", conn);

                  // Set the command object so it knows to execute a stored procedure
                  cmdInsert.CommandType = CommandType.StoredProcedure;

                  // Add parameters to the command, which will be passed to the stored procedure
                  // Apparently Add(string, value) is obsolete.  Use AddWithValue now.
                  cmdInsert.Parameters.AddWithValue("@simlinkid", tractiveForceRecord.SimlinkID);
                  cmdInsert.Parameters.AddWithValue("@mlinkid", tractiveForceRecord.MLinkID);
                  cmdInsert.Parameters.AddWithValue("@compkey", tractiveForceRecord.CompKey);
                  cmdInsert.Parameters.AddWithValue("@diamwidth_in", tractiveForceRecord.DiamWidth_in);
                  cmdInsert.Parameters.AddWithValue("@material", tractiveForceRecord.PipeMaterial);
                  cmdInsert.Parameters.AddWithValue("@slope", tractiveForceRecord.PipeSlope);
                  cmdInsert.Parameters.AddWithValue("@qmin", tractiveForceRecord.QMin);
                  cmdInsert.Parameters.AddWithValue("@qavg1", tractiveForceRecord.QAvg1);
				  cmdInsert.Parameters.AddWithValue("@angle_of_sewer_invert_from_horiz_rad", tractiveForceRecord.SewerInvertAngle);
				  cmdInsert.Parameters.AddWithValue("@flow_depth_ft", tractiveForceRecord.FlowDepth);
				  cmdInsert.Parameters.AddWithValue("@depth_to_diameter_ratio", tractiveForceRecord.YD);
				  cmdInsert.Parameters.AddWithValue("@flow_area_sqft", tractiveForceRecord.FlowArea);
				  cmdInsert.Parameters.AddWithValue("@hydraulic_ratio_ft", tractiveForceRecord.HydraulicRadius);
				  cmdInsert.Parameters.AddWithValue("@shear_stress_psf", tractiveForceRecord.ShearStress);
				  cmdInsert.Parameters.AddWithValue("@particle_size_mm", tractiveForceRecord.ParticleSize);

                  if (tractiveForceRecord.ParticleSize == 0)
                        logger.Warning(tractiveForceRecord.MLinkID + " has 0 Particle Size");

				  Int32 rowsAffected = cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                  logger.Fatal("A TractiveForceDataInsert" + ex.Message + " error occurred"); 
            }
            finally
            {
				if (conn != null)
				{
					conn.Close();
				}
                if (reader != null)
                {
                    reader.Close();
                }
                logger.Success("Record added");
            }
  
        }

        /// <summary>
        /// Creates a SchemaTable for the table that will be opened.
        /// </summary>
        /// <param name="conn">Connection string to the database that contains the SYF to TXT model result file</param>
        /// <param name="schemaTable">Schema Table that contains metadata about each column in the SqlDataReader's table</param>
        private static void FlowResultTableSchema(SqlConnection conn, 
                                                                                                      string resultTableName,
                                                                                                      out DataTable schemaTable)
        {
            SqlDataReader myReader;
            SqlCommand cmd = new SqlCommand();

            // Retrieve records from the HO_EX_dwf_Q table
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM " + resultTableName;
            myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);

            //Retrieve column schema into a DataTable
            //The GetSchemaTable method returns metadata about each column
            //SchemaTable is kind of like the original table transposed 
            //where each column is now a row and the new columns are the metadata
            //We only want rows that have a ColumnName that starts with "M"
            schemaTable = myReader.GetSchemaTable();

            // Clean up
            myReader.Close();
        }

        static int ConvertStringToInt(string inputString)
        {
            int intVal = -1;
            // ToInt32 can throw FormatException or OverflowException.
            try
            {
                intVal = Convert.ToInt32(inputString);
            }
            catch (FormatException)
            {
                //Console.WriteLine("Input string is not a sequence of digits.");
                intVal = -1;
            }
            catch (OverflowException)
            {
                //Console.WriteLine("The number cannot fit in an Int32.");
                intVal = -2;
            }
            return intVal;
            }

        public static DataTable GetDataTable(string sqlString)
        {
              SqlConnection conn = new SqlConnection();
			  // Open a connection to the local SCIP Database
			  // OLD
			  //scipConnection.ConnectionString = "Integrated Security=true;" +
			  //                                                                  "Initial Catalog=SCIP_Test;" +
			  //                                                                  "Data Source=WS11285\\SQLEXPRESS";
			  // Open a connection to Sirtoby\SCIP
			  conn.ConnectionString = "Initial Catalog=MODELING_DEV;" +
																				"Data Source=SIRTOBY;" +
																				"User ID=ModelAdmin;" +
																				"Password=daW7horn;";
              conn.Open();

              SqlCommand sqlCommand = new SqlCommand(sqlString, conn);
              SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

              sqlDataAdapter.SelectCommand = sqlCommand;

              DataTable dataTable = new DataTable();

              try
              {
                    sqlDataAdapter.Fill(dataTable);
              }
              catch (Exception ex)
              {
                    // Error occurred while trying to execute reader
                    Console.WriteLine(ex.Message);

                    return null;
              }
              finally
              {
                    if (conn != null)
                    {
                          conn.Close();
                    }
              }
              return dataTable;
        }     //    public DataTable GetDataTable(string sqlString)

    }

}
