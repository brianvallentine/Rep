using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.LT3151S;

namespace FileTests.Test_DB
{
    [Collection("LT3151S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class LT3151S_Tests_DB
    {
        private static string pData = "2020-01-02";
        [Fact]
        public static void LT3151S_Database()
        {
            var program = new LT3151S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0105_00_LER_PERIODO_VIGENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.WS_AREA_TRABALHO.WS_DTINIVIG_APOLICE.Value = pData;
                program.WS_AREA_TRABALHO.WS_DTTERVIG_APOLICE.Value = pData;
                program.R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.WS_AREA_TRABALHO.HOST_DATA_INI.Value = pData;
                program.WS_AREA_TRABALHO.HOST_DATA_FIM.Value = pData;
                program.R1100_00_OBTEM_QTD_DIAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1200_00_LE_PRAZOSEG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}