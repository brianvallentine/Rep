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
using static Code.PTFASESS;

namespace FileTests.Test_DB
{
    [Collection("PTFASESS_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTFASESS_Tests_DB
    {

        [Fact]
        public static void PTFASESS_Database()
        {
            var program = new PTFASESS();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV.Value = fullDataMock;
                program.SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA.Value = fullDataMock;
                program.SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA.Value = fullDataMock;

                program.R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}