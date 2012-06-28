using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace TractiveForceAnalysis
{
    class TractiveForceRecord
    {
        public TractiveForceRecord()
        {
         }

        public void SetBaseParameters()
        {
            // Define the basics
           // this.pipeDiam_ft = diamWidth_in / 12;
            //this.mannings = SetMannings(diamWidth_in);
            //this.analysisSlope = SetMinimumSlope(slope);
 
            //CalculateForces();
        }

        /// <summary>
        ///  calculates Sewer Invert Angle, Flow Depth, y/D ratio, Shear Stress, and Particle Size
        /// </summary>
        public void CalculateForces()
        {
			if (qMin != 8888)
			{
				try
				{
					leftSide = LeftSideMannings();
					sewerInvertAngle = angleCalculation();
					flowDepth = (pipeDiam_ft / 2) * (1 - Math.Cos(sewerInvertAngle));
					yD = flowDepth / pipeDiam_ft;
					// Area and Hydraulic Radius were calculated in the angleCalculation Method
					shearStress = 62.43 * rH * analysisSlope;
					particleSize = Math.Pow((shearStress / 0.0181), 3.6101083);
				}
				catch
				{
				}
			}
			else
			{
				// This MLinkID has no flow values
				// Set 0 values for the tractive force parameters
				sewerInvertAngle = 0;
				flowDepth = 0;
				yD = 0;
				flowArea = 0;
				rH = 0;
				shearStress = 0;
				particleSize = 999999;
			}
              
        }

        /// <summary>
        ///  This will iterate through an empty (angle = 0) to a full (angle = PI) pipe
        ///  The denominator in the FOR increment defines the precision of the angle
        ///  e.g. 90 = 1°, 180 = 1/2°, 720 = 1/8°...
        /// </summary>
        /// <returns>Angle of sewer invert from horizontal, in radians</returns>
        private double angleCalculation()
        {
            double solution = 100;
            double angle = 0;

            try
            {
                  //This will iterate through an empty (angle = 0) to a full (angle = PI) pipe
                  //The denominator in the FOR increment defines the precision of the angle
                  //e.g. 90 = 1°, 180 = 1/2°, 720 = 1/8°...
                  for (double testAngle = 0; testAngle < Math.PI; testAngle += (Math.PI / 720))
                  {
                        //The calculation components are discretized to allow simpler QA
                        double a1 = Math.Pow(pipeDiam_ft, 2);
                        double a2 = a1 / 4;
                        double a3 = Math.Sin(2 * testAngle);
                        double a4 = a3 / 2;
                        double a5 = testAngle - a4;
                        double area = a5 * a2;
                        double rh1 = pipeDiam_ft / 4;
                        double rh2 = a3 / (2 * testAngle);
                        double rh3 = 1 - rh2;
                        double hydraulicRadius = rh1 * rh3;
                        double rh5 = Math.Pow(hydraulicRadius, 0.6666667);
                        double rightSide = area * rh5;

                        if (Math.Abs(leftSide - rightSide) < solution)
                        {
                              solution = Math.Abs(leftSide - rightSide);
                              angle = testAngle;
                              flowArea = area;
                              rH = hydraulicRadius;
                        }
                  }
            }
            catch
            {
            }
           
            return angle;
        }

        /// <summary>
        /// Manning equation is reconfigured to isloate the sewer invert angle on the right side
        /// and all known parameters (i.e. flow (Q), Manning n, and slope)
        /// This value is then used to determine the Sewer Angle using an interative process (angleCalculation())
        /// </summary>
        /// <returns>Value </returns>
        private double LeftSideMannings()
        {
              double ls = 0;
              try
              {
                    ls = (qMin * mannings) / (1.486 * Math.Sqrt(analysisSlope));
              }
              catch
              {
              }
              return ls;
        }

        /// <summary>
        ///  0% slope pipes will throw an error during calculations.
        ///  This method sets a minimum slope of 0.0001 ft/ft.
        /// </summary>
        /// <param name="pipeSlope">Calculated pipe slope f(USIE, DSIE, L)</param>
        /// <returns>A minimum slope of 0.0001 ft/ft</returns>
        private double SetMinimumSlope(double pipeSlope)
        {
            // Define a minimum slope.  This should catch any flat (0 slope) pipes
            //The equation needs something to nibble on
            if (pipeSlope <= 0.0001)
                return 0.0001;
            else
                return pipeSlope;
        }

        /// <summary>
        ///  Extracts data from mst_links based on the MLinkID value
        /// </summary>
        /// <param name="conn">Connection to the location of SA Master data</param>
        public  void ExtractSAMasterData()
        {
            SqlConnection conn = null;
            SqlDataReader mstLinksDataReader = null;

            try
            {
                  // Create and open a connection object
                  conn = new SqlConnection();
                  //Open a connection to Sirtoby\Modeling_Dev
                  conn.ConnectionString = "User ID=ModelAdmin;" +
                                                                      "Password=daW7horn;" +
                                                                      "Initial Catalog=MODELING_DEV;" +
                                                                      "Data Source=SIRTOBY";
                  conn.Open();

                  // 1 Create a command object identifying the stored procedure
                  SqlCommand command = new SqlCommand("ReturnTractiveForcePipeData", conn);

                  // 2. Set the command object so it knows to execute a stored procedure
                  command.CommandType = CommandType.StoredProcedure;

                  // 2a.  Add MLinkID parameter
                  command.Parameters.AddWithValue("@MLinkID", mLinkID);

                  // 3. Execute the command
                  mstLinksDataReader = command.ExecuteReader();

                  // Iterate through the results, assigning values to variables
                  while (mstLinksDataReader.Read())
                  {
                        // Set some default values
                        pipeMaterial = "";
                        //Used (Double)...  Got some 'Specified Cast is nto valid...' exceptions.  Use Convert.ToDouble
                        // Check data type being returned
                        //Type type = mstLinksDataReader.GetFieldType(5);
                        compKey = (int)mstLinksDataReader["CompKey"];
                        diamWidth_in = Convert.ToDouble(mstLinksDataReader["DiamWidth_in"]);
                        pipeDiam_ft = Convert.ToDouble(mstLinksDataReader["PipeDiamFt"]);
                        pipeMaterial = (string)mstLinksDataReader["Material"];
                        mannings = Convert.ToDouble(mstLinksDataReader["ManningN"]);
                        analysisSlope = Convert.ToDouble(mstLinksDataReader["PipeSlope"]);
                  }

            }
            catch
            {
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (mstLinksDataReader != null)
                {
                    mstLinksDataReader.Close();
                }
            }
        }

		public void ExtractFlowData()
		{
			SqlConnection conn = null;
            SqlDataReader dwfDataReader = null;

			try
			{
				// Create and open a connection object
				conn = new SqlConnection();
				conn.ConnectionString = "Integrated Security=true;" +
																  "Initial Catalog=SCIP;" +
																  "Data Source=SIRTOBY";
				conn.Open();

				string sqlString = "SELECT " +
													"[qavg], " +
													"[qmin] " +
													"FROM " +
													"[dbo].[DWF_Flow_Statistics] " +
													"WHERE   [mst_link_mlinkid] = " + mLinkID;
				SqlCommand sqlCommand = new SqlCommand(sqlString, conn);

				sqlCommand.CommandType = CommandType.Text;

				dwfDataReader = sqlCommand.ExecuteReader();

				if (dwfDataReader.HasRows)
				{
					// This MLinkID has valid flow data.  Read the row and set the Q values accordingly
					while (dwfDataReader.Read())
					{
						qAvg1 = Convert.ToDouble(dwfDataReader["qavg"]);
						qMin = Convert.ToDouble(dwfDataReader["qmin"]);
					}
				}
				else 
					// This MLinkID does NOT have valid flow data.  
					// Need to set out-of-range flow values that can be caught later
				{
					qAvg1 = 8888;
					qMin = 8888;
				}

			}
			catch
			{
			}
			finally
			{
				if (conn != null)
				{
					conn.Close();
				}
				if (dwfDataReader != null)
				{
					dwfDataReader.Close();
				}
			}
		}

        /// <summary>
        ///  Calculates the Qmin and QAvg for this pipe
        /// </summary>
        /// <param name="scipConnection">Connection to the database that holds the SYF to TXT data table</param>
        /// <param name="resultTableName">Name of the SYF to TXT data table</param>
        public void ExtractFlowStatistics(SqlConnection scipConnection, string resultTableName)
        {

              try
              {
                    string flowDataQuery =
                                        "SELECT " + modelID + " FROM " + resultTableName;
                    SqlCommand cmd = new SqlCommand(flowDataQuery, scipConnection);
                    SqlDataReader flowDataReader = cmd.ExecuteReader();

                    // Use a List<> because it has Average and Max Methods
                    List<double> flowDataList = new List<double>();

                    while (flowDataReader.Read())
                    {
                          flowDataList.Add(Convert.ToDouble(flowDataReader[0]));
                    }
                    flowDataReader.Close();

                    qMin = flowDataList.Max(num => Convert.ToDouble(num));
                    qAvg1 = flowDataList.Average(num => Convert.ToDouble(num));
              }
              catch
              {
              }

            
        }
                
        /// <summary>
        ///  Returns a Manning n Recommended Value based on historic studies
        ///  Manning n varies with pipe diameter
        ///  (Haestad et al. 2004). 
        ///  Bizier, Paul. Gravity Sanitary Sewer Design and Construction. 2nd ed. Reston, VA: 
        ///  American Society of Civil Engineers, 2007. Print. 
        ///  ASCE Manials and Reports on Engineering Practice No. 60.
        /// </summary>
        /// <param name="pipeDiamIn"></param>
        /// <returns>Suggested value of manning n for Sewer Design Calculations</returns>
        private double SetMannings(double pipeDiamIn)
        {
            if (pipeDiamIn <= 6)
                return 0.0106;
            else if (pipeDiamIn <=8)
                return 0.0107;
            else if (pipeDiamIn <= 10)
                return 0.0109;
            else if (pipeDiamIn <= 12)
                return 0.0110;
            else if (pipeDiamIn <= 15)
                return 0.0112;
            else if (pipeDiamIn <= 18)
                return 0.0113;
            else if (pipeDiamIn <= 24)
                return 0.0115;
            else if (pipeDiamIn <= 30)
                return 0.0117;
            else if (pipeDiamIn <= 36)
                return 0.0118;
            else if (pipeDiamIn <= 48)
                return 0.0121;
            else if (pipeDiamIn <=60)
                return 0.0123;
            else
                return 0.013;
        }

        private double SquareRoot(double number)
        {
            double sqrt = 0;
            double tempNumber1, tempNumber2;
            double e = 0.00000000000000000001;

            sqrt = number;
            tempNumber2 = sqrt * sqrt;

            while (tempNumber2 - number >=e)
            {
                tempNumber1 = (sqrt + (number/sqrt))/2;
                sqrt = tempNumber1;
                tempNumber2 = sqrt * sqrt;
            }

            return sqrt;
        }

        #region Interface Properties
        private double sewerInvertAngle, flowDepth, yD, flowArea;
        private double rH, shearStress, particleSize;
        private string modelID;
        private int mLinkID;
        private int compKey;
        private string pipeMaterial;
        private double diamWidth_in;
        private double pipeDiam_ft;
        private double mannings;
        //private double slope;
        private double qMin;
        private double qAvg1;
        private double leftSide;
        private double analysisSlope;

        public double SewerInvertAngle
        { get { return sewerInvertAngle; } }

        public double FlowDepth
        { get { return flowDepth; } }

        public double YD
        {
              get
              {
                    if(double.IsNaN(yD))
                          return 0;
                    else
                          return yD;
              }
        }
       


        public double FlowArea
        { get { return flowArea; } }

        public double HydraulicRadius
        { get { return rH; } }

        public double ShearStress
        { get { return shearStress; } }

        public double ParticleSize
        { 
              get 
                    {
                          if (double.IsNaN(particleSize))
                                return 0;
                          else if (particleSize > 999999)
                                return 999998;
                          else
                                return particleSize;
                    }
        }

        public string SimlinkID
        {
            get { return modelID; }
            set { modelID = value; }
        }

        public int MLinkID
        {
            get { return mLinkID; }
            set { mLinkID = value; }
        }

        public int CompKey
        {
            get { return compKey; }
            set { compKey = value; }
        }

        public double DiamWidth_in
        {
            get { return diamWidth_in; }
            set { diamWidth_in = value; }
        }

		public double DiamWidth_ft
		{
			get { return pipeDiam_ft; }
			set { pipeDiam_ft = value; }
		}

		public double ManningsN
		{
			get { return mannings; }
			set { mannings = value; }
		}

        public string PipeMaterial
        {
              get
              {
                    if (pipeMaterial != null)
                    {
                          return pipeMaterial;
                    }
                    else
                    {
                          return string.Empty;
                    }
              }
            set { pipeMaterial = value; }
        }

        public double PipeSlope
        {
            get { return analysisSlope; }
            set { analysisSlope = value; }
        }

        public double QMin
        {
            get { return qMin; }
            set { qMin = value; }
        }

        public double QAvg1
        {
            get { return qAvg1; }
            set { qAvg1 = value; }
        }

        #endregion
    }
}
