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
using static Code.SI0110B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("SI0110B_Tests_DB")]
    public class SI0110B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void SI0110B_Database()
        {
            var program = new SI0110B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_000_100_SELECT_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.V1SISTEMA_DTMOVABE.Value = pData;
                program.V1SISTEMA_DTCURRENT.Value = pData;
                program.M_000_200_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.V1SISTEMA_DTMOVABE.Value = pData;
                program.M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1(); program.M_000_300_DECLARE_RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ 
                program.V1RELATORIOS_DATA1.Value = pData;
                program.V1RELATORIOS_DATA2.Value = pData;
                program.M_100_100_DECLARE_HISTMEST_DB_DECLARE_1(); program.M_100_100_DECLARE_HISTMEST_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ 
                program.V1SISTEMA_DTMOVABE.Value = pData;
                program.M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_200_200_SELECT_V1HISTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_200_300_SELECT_V1RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_300_400_SELECT_V1FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_000_00_ACESSA_NOME_SEGURADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}