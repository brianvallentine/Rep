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
using static Code.SI0851B;

namespace FileTests.Test_DB
{
    [Collection("SI0851B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0851B_Tests_DB
    {

        [Fact]
        public static void SI0851B_Database()
        {
            var program = new SI0851B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.M_005_SELECT_V0SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.M_007_SELECT_V0RELAT_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.M_007_SELECT_V0RELAT_DB_DECLARE_1();
                program.M_007_SELECT_V0RELAT_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.M_009_DECLARE_LOTERICO_DB_DECLARE_1();
                program.M_009_DECLARE_LOTERICO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.V0REL_PERI_INICIAL.Value = fullDataMock;
                program.V0REL_PERI_FINAL.Value = fullDataMock;

                program.M_030_PROCESSA_LOTERICO_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.M_100_SELECT_CANCELAMENTO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_3();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_4();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.M_200_ATUALIZA_RELATORIO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_5();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_6();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_7();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_8();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_9();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_10();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_11();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_12();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_13();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.M_030_PROCESSA_LOTERICO_DB_SELECT_14();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}