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
using static Code.AC0005B;

namespace FileTests.Test_DB
{
    [Collection("AC0005B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0005B_Tests_DB
    {

        [Fact]
        public static void AC0005B_Database()
        {
            var program = new AC0005B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.R0200_00_CHECA_EXECUCAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.R0500_00_DECLARE_V0HISTOPARC_DB_DECLARE_1();
                program.R0500_00_DECLARE_V0HISTOPARC_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.R3100_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();
                program.R3100_00_DECLARE_V1HISTOPARC_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.R0900_00_SELECT_V0ENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.R0950_00_SELECT_V0COSSEGACE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.R1100_00_SELECT_V0PARCELA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.R1200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.R1700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.V0CHIS_DTMOVTO.Value = fullDataMock;
                program.V0CHIS_DTQITBCO.Value = fullDataMock;

                program.R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.R2000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.R3400_00_SELECT_V1PARCELA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.R4000_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}