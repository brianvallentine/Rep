using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VP0118B;

namespace FileTests.Test_DB
{
    [Collection("VP0118B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VP0118B_Tests_DB
    {

        [Fact]
        public static void VP0118B_Database()
        {
            var program = new VP0118B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.R0000_00_PRINCIPAL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R0000_00_PRINCIPAL_DB_DECLARE_1();
                program.R0000_00_PRINCIPAL_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.AREA_WORK.HOST_DTINIVIG_PARM.Value = fullDataMock;

                program.R0100_00_GERA_MOVIMENTO_DB_DECLARE_1();
                program.R0100_00_GERA_MOVIMENTO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.AREA_WORK.HOST_DTINIVIG.Value = fullDataMock;

                program.R0800_00_VERIFICA_CDG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.AREA_WORK.HOST_DTINIVIG_1DAY.Value = fullDataMock;
                program.AREA_WORK.HOST_DTINIVIG.Value = fullDataMock;

                program.R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.AREA_WORK.HOST_DTINIVIG.Value = fullDataMock;
                program.AREA_WORK.HOST_DTTERVIG.Value = fullDataMock;

                program.R0820_00_INSERT_CDG_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}