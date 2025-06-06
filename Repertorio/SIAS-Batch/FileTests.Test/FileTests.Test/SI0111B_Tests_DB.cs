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
using static Code.SI0111B;

namespace FileTests.Test_DB
{
    [Collection("SI0111B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0111B_Tests_DB
    {

        [Fact]
        public static void SI0111B_Database()
        {
            var program = new SI0111B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_000_100_SELECT_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_000_200_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V1SISTEMA_DTMOVABE.Value = "2020-01-01";
                program.M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1(); program.M_000_300_DECLARE_RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.V1RELATORIOS_DATA1.Value = "2020-01-01";
                program.V1RELATORIOS_DATA2.Value = "2020-01-01";
                program.M_100_100_DECLARE_HISTMEST_DB_DECLARE_1(); program.M_100_100_DECLARE_HISTMEST_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.V1SISTEMA_DTMOVABE.Value = "2020-01-01";
                program.M_000_800_UPDATE_V1RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.V1HISTMEST_NUM_SINISTRO.Value = 101100000001;
                program.V1HISTSINI_OPERACAO1.Value = 101;
                program.V1HISTSINI_OPERACAO2.Value = 101;
                program.V1HISTMEST_OCORHIST.Value = 1;
                program.M_200_200_SELECT_V1HISTSINI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V1HISTMEST_MODALIDA.Value = 0;
                program.V1HISTMEST_RAMO.Value = 0;
                program.M_200_300_SELECT_V1RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.V1HISTMEST_NUM_APOLICE.Value = 0;
                program.V1HISTMEST_CODSUBES.Value = 0;
                program.V1HISTMEST_NRCERTIF.Value = 0;
                program.V1HISTMEST_IDTPSEGU.Value = "0";
                program.M_300_100_SELECT_V1CLIENTE1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ 
                program.V1HISTMEST_NUM_SINISTRO.Value = 0;
                program.M_300_200_SELECT_V1CLIENTE2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.V1HISTMEST_NUM_APOLICE.Value = 0;
                program.M_300_300_SELECT_V1CLIENTE3_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.V1HISTMEST_FONTE.Value = 0; 
                program.M_300_400_SELECT_V1FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}