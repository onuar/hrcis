using NUnit.Framework;
using HRC.Library.DBAccessLayer;
using System.Linq;
using HRCIS.DataLoader.Entities;
using HRCIS.DataLoader.Lists;
using HRCIS.SchemaLoader.Lists;

namespace HRCIS.Tests
{
    [TestFixture]
    public class DataLoaderTests
    {
        #region Init and tear down
        ///// <summary>
        /////  add dumb datas to hrctesttable
        ///// </summary>

        [TestFixtureSetUp]
        public void Init()
        {
            using (var db = new DbManager() { KeepConnection = true })
            {
                db.ExecuteNonQuery(string.Format(@"
                delete from hrctesttable

                insert into {0}(
	                nvarcharcolumn
	                ,varcharcolumn
	                ,bitcolumn
	                ,Intcolumn
	                ,datetimecolumn
	                ,floatcolumn
	                ,decimalcolumn
	                ,charcolumn
	                ,moneycolumn
	                ,guidcolumn
	                ,xmlcolumn
	                ,datecolumn)
                values
	                (
	                'nvarchar''value',--apos mecburi
	                'varchar''value',--apos mecburi
	                1,--bit apos opsiyonel
	                666,--int apos opsiyonel
	                '2012-8-31',--datetime apos mecburi (format kayıyor)
	                '666.5',--float nokta, apos opsiyonel
	                '777.4',--decimal nokta, apos opsiyonel
	                'char''value',--char apos mecburi
	                '555.55',--money nokta, apos opsiyonel
	                '64128963-C8F1-4E96-B5EC-7DFCF138B09E',--guid, apos mecburi
	                '<xml> hede ''hodo''</xml>'--xml, apos mecburi
	                ,GETDATE())", Tools.HrcTestTableName));
            }
        }

        //[TestFixtureTearDown]
        public void KillThemAll() 
        {
            using (var db = new DbManager())
            {
                db.ExecuteNonQuery(string.Format("delete from {0}", Tools.HrcTestTableName));
            }
        }
        #endregion

        [Test]
        public void Should_Table_All_Datas_Added()
        {
            var schemaLoader = new SchemaLoader.SchemaLoader();
            TableList tableList = schemaLoader.GetTableList();
            var schemas = new SchemaList();
            schemas.AddRange(tableList.Select(schemaLoader.GetSchema));

            var loader = new DataLoader.DataLoader(schemas);
            SchemaDataList datas = loader.GetSchemaDatas();
            HrcSchemaData sd = datas.GetSchemaDataByTableName(Tools.HrcTestTableName);
            Assert.AreNotEqual(sd.Datas.Rows.Count, 0);
        }
    }
}
