namespace UI {
    
    
    public partial class SCIPDataSet {
      partial class FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSRootDataTable
      {
      }
    
      partial class FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSInspectionDataTable
      {
      }
    
      partial class SP_CHART_CLTDDataTable
      {
      }
    }
}

namespace UI.SCIPDataSetTableAdapters {
  partial class FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSCleaningTableAdapter
  {
    public int SelectCommandTimeOut
    {
      get { return this.CommandCollection[0].CommandTimeout; }
      set
      {
        for (int i = 0; i < this.CommandCollection.Length; i++)
        {
          if (this.CommandCollection[i] != null)
            ((System.Data.SqlClient.SqlCommand)
              (this.CommandCollection[i])).CommandTimeout = value;
        }
      }
    }
  }

  partial class FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSInspectionTableAdapter
  {
    public int SelectCommandTimeOut
    {
      get { return this.CommandCollection[0].CommandTimeout; }
      set
      {
        for (int i = 0; i < this.CommandCollection.Length; i++)
        {
          if (this.CommandCollection[i] != null)
            ((System.Data.SqlClient.SqlCommand)
              (this.CommandCollection[i])).CommandTimeout = value;
        }
      }
    }
  }
    
    
    public partial class FN_CHART_PROGRESSIVE_ACTIVITIES_COUNT_BETWEEN_YEARSRootTableAdapter {
      public int SelectCommandTimeOut
      {
        get { return this.CommandCollection[0].CommandTimeout; }
        set
        {
          for (int i = 0; i < this.CommandCollection.Length; i++)
          {
            if (this.CommandCollection[i] != null)
              ((System.Data.SqlClient.SqlCommand)
                (this.CommandCollection[i])).CommandTimeout = value;
          }
        }
      }
    }
}
