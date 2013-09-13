using HRC.Library.DBAccessLayer;

namespace HRCIS.Tests
{
    internal class Tools
    {
        internal const string HrcTestTableName = "HRCTestTable";

        internal static void DropCreateTable()
        {
            using (var db = new DbManager { KeepConnection = true })
            {
                #region Query
                string query = string.Format(@"

                    /****** Object:  Table [dbo].[HRCTestTable]    Script Date: 08/29/2012 15:27:25 ******/
                    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))
                    DROP TABLE [dbo].[{0}]


                    /****** Object:  Table [dbo].[{0}]    Script Date: 08/29/2012 15:27:25 ******/
                    SET ANSI_NULLS ON

                    SET QUOTED_IDENTIFIER ON

                    SET ANSI_PADDING ON

                    CREATE TABLE [dbo].[{0}](
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
	                    [NVarCharColumn] [nvarchar](50) NULL,
	                    [VarCharColumn] [varchar](50) NULL,
	                    [BitColumn] [bit] NULL,
	                    [IntColumn] [int] NULL,
	                    [DateTimeColumn] [datetime] NULL,
	                    [FloatColumn] [float] NULL,
	                    [DecimalColumn] [decimal](18, 0) NULL,
	                    [CharColumn] [char](10) NULL,
	                    [MoneyColumn] [money] NULL,
	                    [GuidColumn] [uniqueidentifier] NULL,
	                    [XmlColumn] [xml] NULL,
                        [DateColumn] [date] NULL,
                     CONSTRAINT [PK_HRCTestTable] PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC
                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                    ) ON [PRIMARY]


                    SET ANSI_PADDING OFF", HrcTestTableName);
                #endregion
                db.ExecuteNonQuery(query);
            }
        }

        internal static void DropTable()
        {
            #region Query
            string query = string.Format(@"
            /****** Object:  Table [dbo].[{0}]    Script Date: 08/29/2012 15:27:54 ******/
            IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))
            DROP TABLE [dbo].[{0}]", Tools.HrcTestTableName);
            #endregion
            using (var db = new DbManager { KeepConnection = true })
            {
                db.ExecuteNonQuery(query);
            }
        }
    }
}
