using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// added
using System.Data;
using System.Data.SqlClient;

namespace ModelResultTableProcessing
{
      class Program
      {
		  /// <summary>
		  ///  Converts data stored in TXT files to the DWF_FLOW_DATA table on the server
		  /// </summary>
		  /// <param name="args">No args passed</param>
            static void Main(string[] args)
            {
                  try
                  {
                      string resultListLine;
					  //string resultTableName;
                      string modelSource;
					  string resultTablePath;
                        //int counter = 0;

                        //Read the text file that contains the list of result files to process
                        // Text file MUST be in following format:
                        // FULL result file path,modelsource
                        System.IO.StreamReader resultListFile =
                                   new System.IO.StreamReader("P:\\SCIP\\Phase_1\\Scripts\\C#\\FlowTableList.txt");
                        while (resultListFile.Peek() > -1)
                        {
                            resultListLine = resultListFile.ReadLine();
                            string[] split = resultListLine.Split(',');
                            resultTablePath = split[0];
                            modelSource = split[1];

							Console.WriteLine("Starting Table {0} from {1} model", resultTablePath, modelSource);

							DataTable inputDataTable;
							double savedTimeStep;
							ProcessRawInputTable(resultTablePath, out inputDataTable, out savedTimeStep);

							// Create a new output DataTable
							DataTable outputTable = new DataTable();

							Console.WriteLine("Creating Output DataTable");
							CreateOutputDataTable(outputTable);

							Console.WriteLine("Filling Output DataTable");
							PopulateOutputDataTable(inputDataTable, outputTable, modelSource, savedTimeStep);

							SaveFlowValuesToTable(outputTable);

							// Release the temp DataTables
							inputDataTable.Dispose();
							inputDataTable = null;
							outputTable.Dispose();
							outputTable = null;
						}
                        
                  }
                  catch
                  {
                  }
                  finally
                  {
                        // Release resources
                  }
            }

		  /// <summary>
		  ///  Takes the SYF->TXT csv file and transfers it to a local DataTable
		  /// </summary>
			/// <param name="resultTablePath">Path of the  SYF->TXT csv file</param>
		  /// <param name="inputDataTable">A local DataTable used to store flow data</param>
		  /// <param name="savedTimeStep">Time step that the model results were saved in.</param>
			private static void ProcessRawInputTable(string resultTablePath, out DataTable inputDataTable, out double savedTimeStep)
			{
				// This assigns default values outside the try/catch/finally block
				savedTimeStep = 0;
				inputDataTable = null;

				try
				{

					// Now we start working with individual result files
					// Create a DataTable
					inputDataTable = new DataTable();
					// Open the result file
					System.IO.StreamReader resultFile =
						new System.IO.StreamReader(resultTablePath);

					Console.WriteLine("Getting header and column information...");

					// Start by reading the first line of the resultFile.
					// It will contain the Column Headings
					string resultFileHeaderLineString = resultFile.ReadLine();

					// We know there are x commas and therefore x+1 columns so start counting at 1
					int columnCount = 1;
					foreach (char c in resultFileHeaderLineString)
					{
						if (c == ',')
						{
							columnCount++;
						}
					}
					// Now that we have the # of columns, define a string array to split the 
					// array into individual strings
					string[] resultFileHeaderLine = resultFileHeaderLineString.Split(',');
					// Create columns in the DataTable
					// Begin at the 3rd column because the first 3 are Date/Time information
					// and this is a zero-based index (zb idx)
					for (int col = 3; col <= columnCount - 1; col++)
					{
						inputDataTable.Columns.Add(resultFileHeaderLine[col]);
					}
					Console.WriteLine("Header and column information complete");
					Console.WriteLine("Writing result file data to temp DataTable...");

					savedTimeStep = 0;
					int rowCount = 0;
					// Move to row #2 and use a while... loop to move through all rows
					// Then write Columns 3 -> (columnCount-3) from the string[] array
					// to Columns 0 -> columnCount in the DataTable
					while (resultFile.Peek() > -1)
					{
						rowCount++;

						string resultFileLineString = resultFile.ReadLine();
						string[] resultFileLine = resultFileLineString.Split(',');

						// QA the columns and expected array size
						//Conssole.WriteLine("DataTable Columns: {0}", inputDataTable.Columns.Count);
						//Conole.WriteLine("Result String Array: {0}", resultFileLine.Count());

						// Need to grab the dT value (column 2 (zb idx))
						// Get the timestep first if it hasn't already been written
						if (savedTimeStep == 0)
						{ savedTimeStep = Convert.ToDouble(resultFileLine[2]); }

						// The column counter here is for the DataTable.
						// We will adjust to read the string[] array accordingly
						// Add a new row, then populate each column
						DataRow newRow = inputDataTable.NewRow();
						for (int col = 0; col < columnCount - 3; col++)
						{
							newRow[col] = resultFileLine[col + 3];
							//Console.WriteLine("Column {0} and Row {1}", col, rowCount);
						}	// Move to next column
						inputDataTable.Rows.Add(newRow);
					}	// Move to next row
					Console.WriteLine("Result file data to temp DataTable complete");
				}
				catch (IndexOutOfRangeException ex)
				{
					Console.WriteLine("Error: {0}", ex.Message);
				}
				finally
				{

				}

			}

		  /// <summary>
		  ///  Writes flow values in the output DataTable to the server using a stored procedure
		  /// </summary>
		  /// <param name="outputTable">A local DataTable used to store transposed flow data</param>
            private static void SaveFlowValuesToTable(DataTable outputTable)
            {
                  using (SqlConnection scipConnection = new SqlConnection())
                  {
                        // Open a connection to the local SCIP Database
					  // OLD
						//scipConnection.ConnectionString = "Integrated Security=true;" +
						//                                                                  "Initial Catalog=SCIP_Test;" +
						//                                                                  "Data Source=WS11285\\SQLEXPRESS";
					  // Open a connection to Sirtoby\SCIP
						scipConnection.ConnectionString = "Integrated Security=true;" +
																						  "Initial Catalog=SCIP;" +
																						  "Data Source=SIRTOBY";
                        scipConnection.Open();

						double counter = 0;

                        Console.WriteLine("Saving Flow Values to Server");
                        foreach (DataRow writeRow in outputTable.Rows)
                        {
							counter++;
							if (counter / 1000 == Math.Round(counter / 1000))
								Console.WriteLine("Writing Record # {0}", counter);
							SqlDataReader myReader = null;
							SqlCommand cmdInsert = new SqlCommand("SP_INSERT_DWF_FLOW_DATA", scipConnection);
							
                            // Set the command object so it knows to execute a stored procedure
                            cmdInsert.CommandType = CommandType.StoredProcedure;

                            // Add the MLinkID
                            cmdInsert.Parameters.AddWithValue("@mlinkid", writeRow[0]);
                            cmdInsert.Parameters.AddWithValue("@simlinkid", writeRow[1]);
                            cmdInsert.Parameters.AddWithValue("@model_source", writeRow[2]);
                            cmdInsert.Parameters.AddWithValue("@flow_date", writeRow[3]);
                            cmdInsert.Parameters.AddWithValue("@flow_value_cfs", writeRow[4]);

							myReader = cmdInsert.ExecuteReader();
                              if (myReader != null)
                                    myReader.Close();
                        }

                        //Cleanup

                        if (scipConnection != null)
                              scipConnection.Close();
                        Console.WriteLine("Finished saving to Server");
                        Console.WriteLine();
                  }
            }

		  /// <summary>
		  ///  Transferrs and transposes data from the input DataTable to an output DataTable
		  /// </summary>
			/// <param name="inputTable">A local DataTable used to store flow data</param>
			/// <param name="outputTable">A local DataTable used to store transposed flow data</param>
		  /// <param name="modelSource">The abbreviated code used to denote  the model where the flow data came from</param>
			/// <param name="timeStep">Time step that the model results were saved in.</param>
            private static void PopulateOutputDataTable(DataTable inputTable, 
																											DataTable outputTable, 
																											string modelSource, 
																											double timeStep)
            {
                  // the 'M' character usually differentiates between the MLinkID and the SimlinkID
                  char[] mChar = { 'M' };
                  // Assume all models start at 1/1/25
                  DateTime flowDate = new DateTime(2025,1,1,00,00,00);

                  // Add rows by looping columns
                  for (int rowCount = 0; rowCount <= inputTable.Columns.Count - 1; rowCount++)
                  {
                        // Now we loop through inputTable ROWS  and assign the values to the 
                        // outputTable COLUMNS
                        for (int columnCount = 0; columnCount <= inputTable.Rows.Count - 1; columnCount++)
                        {
                              // Create a new row
                              DataRow newRow = outputTable.NewRow();
 
                              // Strip the 'M' to get MLinkID
                              newRow[0] = ConvertStringToInt(inputTable.Columns[rowCount].ColumnName.ToString().TrimStart(mChar));
                              // Use base value for SimlinkID
                              newRow[1] = inputTable.Columns[rowCount].ColumnName.ToString();
                              // Add the model the data is from
                              newRow[2] = modelSource;
                              // Write the FlowDate value
                              newRow[3] = flowDate.AddSeconds(timeStep * (columnCount));
                              // Write the FlowValue
                              newRow[4] = Convert.ToDouble(inputTable.Rows[columnCount][rowCount].ToString());

                              // Add the new DataRow to the output DataTable
                              outputTable.Rows.Add(newRow);
                        }
                  }
            }

		  /// <summary>
		  ///  Creates a blank DataTable used to store transposed flow values
		  /// </summary>
			/// <param name="outputTable">A local DataTable used to store transposed flow data</param>
            private static void CreateOutputDataTable(DataTable outputTable)
            {
                  // Set the first column to be the MLinkID
                  outputTable.Columns.Add("MLinkID");
                  outputTable.Columns.Add("SimlinkID");
                  outputTable.Columns.Add("ModelSource");
                  outputTable.Columns.Add("FlowDate");
                  outputTable.Columns.Add("FlowValue");
            }

            public static DataTable GetDataTable(string sqlString)
            {
				SqlConnection scipConnection = new SqlConnection();
				  // Open a connection to the local SCIP Database
				  // OLD
				  //scipConnection.ConnectionString = "Integrated Security=true;" +
				  //                                                                  "Initial Catalog=SCIP_Test;" +
				  //                                                                  "Data Source=WS11285\\SQLEXPRESS";
				  // Open a connection to Sirtoby\SCIP
				  scipConnection.ConnectionString = "Integrated Security=true;" +
																					"Initial Catalog=SCIP;" +
																					"Data Source=SIRTOBY";

				  SqlCommand sqlCommand = new SqlCommand(sqlString, scipConnection);
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
					  if (scipConnection != null)
                        {
							scipConnection.Close();
                        }
                  }
                  return dataTable;
            }     //    public DataTable GetDataTable(string sqlString)

		  /// <summary>
		  ///  Converts a String to Interger, checking for and catching errors
		  /// </summary>
		  /// <param name="inputString">Input string value</param>
		  /// <returns>converted Interger value</returns>
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

      }     //      class Program
}     //    namespace ModelResultTableProcessing

