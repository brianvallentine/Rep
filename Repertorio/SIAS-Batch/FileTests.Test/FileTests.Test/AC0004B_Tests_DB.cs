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
using static Code.AC0004B;

namespace FileTests.Test_DB
{
    [Collection("AC0004B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0004B_Tests_DB
    {

        [Fact]
        public static void AC0004B_Database()
        {
            var program = new AC0004B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R0200_00_SELECT_V0SISTEMA_FI_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R0500_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();
                program.R0500_00_DECLARE_V0RELATORIOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.V0CCHQ_DTMOVTO_AC.Value = fullDataMock;

                program.R1000_00_DECLARE_V1COSHISTPRE_DB_DECLARE_1();
                program.R1000_00_DECLARE_V1COSHISTPRE_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.V0RELA_PERI_INICIAL.Value = fullDataMock;
                program.V0RELA_PERI_FINAL.Value = fullDataMock;

                program.R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R2000_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1(); 
                program.R2000_00_DECLARE_V1COSHISTSIN_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R1300_00_SELECT_V0COSSEGPREM_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.V0CHSP_DTMOVTO.Value = fullDataMock;
                program.V1CHSP_DTQITBCO.Value = fullDataMock;

                program.R1400_00_INSERT_V0COSHISTPRE_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.R1500_00_UPDATE_V0COSHISTPRE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.R1600_00_UPDATE_V0COSSEGPREM_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.R2300_00_SELECT_GESISORL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.V1CHSI_DTMOVTO.Value = fullDataMock;

                program.R2400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.V0CHSI_DTMOVTO.Value = fullDataMock;

                program.R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}