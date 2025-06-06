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
using static Code.VF0402B;

namespace FileTests.Test_DB
{
    [Collection("VF0402B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class VF0402B_Tests_DB
    {

        [Fact]
        public static void VF0402B_Database()
        {
            var program = new VF0402B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_SELECT_V0RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0010_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_UPDATE_V0RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.DTINIMES.Value = "2025-01-01";
                program.DTFIMMES.Value = "2025-01-01";
                program.R1000_00_SELECIONA_DB_DECLARE_1(); program.R1000_00_SELECIONA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.V0EVEN_NRCERTIF.Value = 123;
                program.R1100_00_MONTA_SORT_DB_DECLARE_1(); program.R1100_00_MONTA_SORT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.V0EVEN_NRCERTIF.Value = 123;
                program.R1100_00_MONTA_SORT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.V0PRVA_CODCLIEN.Value = 123 ;
                program.R1100_00_MONTA_SORT_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V0EVEN_NRCERTIF.Value = 123;
                program.R1100_00_MONTA_SORT_DB_DECLARE_2(); program.R1100_00_MONTA_SORT_DB_OPEN_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.V0EVEN_NRCERTIF.Value = 123 ;
                program.R1100_00_MONTA_SORT_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V0ASST_CODAST.Value = 32;
                program.R1100_00_MONTA_SORT_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.V0ASST_CODAST.Value = 123;
                program.R1100_00_MONTA_SORT_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.V0GERE_CODGER.Value = 123;
                program.R2100_00_IMPRIME_REPRESENTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.V0FONT_FONTE.Value = 123;
                program.R2200_00_IMPRIME_FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.V0ASST_CODAST.Value = 123;
                program.R2300_00_IMPRIME_ASSISTENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.V0SUBG_NUM_APOLICE.Value = 123;
                program.V0SUBG_CODSUBES.Value = 123;
                program.R2400_00_IMPRIME_SUBESTIP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.V0SUBG_CODCLIEN.Value = 123;
                program.R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.V0PROD_CODPDT.Value = 123 ;
                program.R2500_00_IMPRIME_VENDEDOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.V0PROD_CODPDT.Value = 123 ;
                program.R2600_00_IMPRIME_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}