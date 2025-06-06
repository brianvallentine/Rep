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
using static Code.SI0112B;

namespace FileTests.Test_DB
{
    [Collection("SI0112B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0112B_Tests_DB
    {

        [Fact]
        public static void SI0112B_Database()
        {
            var program = new SI0112B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.M_015_000_CABECALHOS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.M_090_000_CURSOR_V1RELATORIOS_DB_DECLARE_1();
                program.M_090_000_CURSOR_V1RELATORIOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.MEST_DATORR.Value = fullDataMock;

                program.M_360_000_LER_V1APOLCOSCED_DB_DECLARE_1();
                program.M_360_000_LER_V1APOLCOSCED_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.M_160_000_LER_V1CONGENERE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.M_180_000_LER_V1HISTSINI_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.M_210_000_LER_V1MESTSINI_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.M_240_000_LER_V1APOLICE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.M_270_000_LER_V1ENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.M_300_000_LER_V1RAMO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.M_330_000_LER_V1ORDECOSCED_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.THIST_DTMOVTO.Value = fullDataMock;

                program.M_370_000_LER_V1MOEDA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.M_410_000_LER_V1APOLITEM_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.M_570_000_LER_V1SEGURAVG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.M_575_000_LER_V1CLIENTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.M_576_000_LER_V1CONDTEC_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.M_800_000_ATUALIZA_V0RELATORIOS_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}