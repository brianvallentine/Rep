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
using Dclgens;
using Code;
using static Code.PTACOMPS;

namespace FileTests.Test_DB
{
    [Collection("PTACOMPS_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTACOMPS_Tests_DB
    {

        [Fact]
        public static void PTACOMPS_Database()
        {
            var program = new PTACOMPS();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.GECARACO.DCLGE_CARTA_ACOMP.GECARACO_DATA_MOVTO_CARTACO.Value = fullDataMock;

                program.R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}