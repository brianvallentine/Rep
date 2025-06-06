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
using static Code.AC0816B;

namespace FileTests.Test_DB
{
    [Collection("AC0816B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class AC0816B_Tests_DB
    {

        [Fact]
        public static void AC0816B_Database()
        {
            var program = new AC0816B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DECLARE_V0RELATORIOS_DB_DECLARE_1(); program.R0200_00_DECLARE_V0RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.V0RELA_DATA_REF.Value = fullDataMock;

                program.R0700_00_DECLARE_V1COSHISTSIN_DB_DECLARE_1();
                program.R0700_00_DECLARE_V1COSHISTSIN_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.V0COTA_DTINIVIG.Value = fullDataMock;

                program.R0500_00_SELECT_V0COTACAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0900_00_SELECT_GESISORL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0950_00_SELECT_GESISORL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1000_00_SELECT_V0MESTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1050_00_SELECT_V0APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1100_00_SELECT_SX010_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1200_00_SELECT_V1COSHISTSIN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1250_00_SELECT_V1COSHISTSIN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.V1CHSI_DTMOVTO.Value = fullDataMock;

                program.R1400_00_UPDATE_V0COSHISTSIN_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1500_00_INSERT_V0COSHISTSIN_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1700_00_SELECT_V0HISTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.V0RELA_DATA_SOL.Value = fullDataMock;

                program.R1800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.V0RELA_DATA_SOL.Value = fullDataMock;

                program.R2000_00_UPDATE_COSCED_CHEQUE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.V0RELA_DATA_SOL.Value = fullDataMock;

                program.R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}