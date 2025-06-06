using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.FI0100S;

namespace FileTests.Test_DB
{
    [Collection("FI0100S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class FI0100S_Tests_DB
    {

        [Fact]
        public static void FI0100S_Database()
        {
            var program = new FI0100S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.V1SIST_DTMOVABE.Value = fullDataMock;

                program.R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R0210_00_ACESSA_CEPFXFIL_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R0220_00_ACESSA_V1FONTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R0210_00_ACESSA_CEPFXFIL_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.R0420_00_ACESSA_V1FORNECEDOR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R0430_00_ACESSA_V1PRODUTOR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R0860_00_UPDATE_V1FORNECEDOR_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R0870_00_UPDATE_V1PRODUTOR_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.V0REND_DATRDT.Value = fullDataMock;

                program.R0890_00_INSERE_V0RENDIMENTO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.V0IMPO_DATIPT.Value = fullDataMock;

                program.R0910_00_INSERT_V0IMPOSTOS_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.WS_DTINIREF.Value = fullDataMock;
                program.WS_DTFIMREF.Value = fullDataMock;

                program.R0930_00_SOMA_RENDIMENTO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.R0940_00_SOMA_IMPOSTO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.R0945_00_CALC_DEDUCAO_DEP_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.R0946_00_APLICA_DEDUCOES_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.R0950_00_ACESSA_V1IRFONTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.R0960_00_ACESSA_IRJ_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.R0978_00_LE_AGRUPA_CH1_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}