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
using static Code.SI0103B;

namespace FileTests.Test_DB
{
    [Collection("SI0103B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0103B_Tests_DB
    {

        [Fact]
        public static void SI0103B_Database()
        {
            var program = new SI0103B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.V1HISTMEST_NUM_APOLICE.Value = 81010000001;
                program.V1HISTMEST_CODSUBES.Value = 1;
                program.V1HISTMEST_NRCERTIF.Value = 10000342585;
                program.V1HISTMEST_IDTPSEGU.Value = "1";
                program.M_500_100_SELECT_V1CLIENTE1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ 
                program.V1HISTMEST_NUM_SINISTRO.Value = 101100000001;  
                program.M_500_200_SELECT_V1CLIENTE2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V1HISTMEST_NUM_APOLICE.Value = 11001001961;
                program.M_500_300_SELECT_V1CLIENTE3_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.V1HISTMEST_FONTE.Value = 0;
                program.M_300_100_SELECT_V1FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_000_100_SELECT_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_000_200_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.V1SISTEMA_DTMOVABE.Value = "2024-12-31";
                program.M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1(); program.M_000_300_DECLARE_RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V1RELATORIOS_APOLICE1.Value = 66001000001;
                program.V1RELATORIOS_APOLICE2.Value = 101100000369;
                program.V1RELATORIOS_RAMO1.Value = 66;
                program.V1RELATORIOS_RAMO2.Value = 11;
                program.V1RELATORIOS_DATA1.Value = "1993-05-06";
                program.V1RELATORIOS_DATA2.Value = "2006-08-16";
                program.M_100_100_DECLARE_HISTMEST_DB_DECLARE_1(); program.M_100_100_DECLARE_HISTMEST_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_000_500_SELECT_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V1HISTMEST_MODALIDA.Value =0 ;
                program.V1HISTMEST_RAMO.Value = 0;
                program.M_200_100_SELECT_V1RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.V1HISTMEST_COD_MOEDA_SINI.Value = 1;
                program.M_000_000_ACESSA_MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.V1SISTEMA_DTMOVABE.Value = "2024-12-31";
                program.M_000_700_DELETE_V1RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}