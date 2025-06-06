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
using static Code.VG0123B;

namespace FileTests.Test_DB
{
    [Collection("VG0123B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0123B_Tests_DB
    {
        private static string pData = "2000-01-01";

        [Fact]
        public static void VG0123B_Database()
        {
            var program = new VG0123B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_000_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0000_000_PRINCIPAL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0100_000_DECLARA_RELATORIO_DB_DECLARE_1(); program.M_0100_000_DECLARA_RELATORIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.WORK.DATA_REF1.Value = pData;
                program.WORK.DATA_REF2.Value = pData;
                program.M_0121_120_DECLARA_SEGURADOS_DB_DECLARE_1(); 
                program.M_0121_120_DECLARA_SEGURADOS_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/ program.M_0110_020_FETCH_RELATORIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0122_120_DECLARA_SEGURADOS_DB_DECLARE_1(); program.M_0122_120_DECLARA_SEGURADOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.M_0123_120_DECLARA_SEGURADOS_DB_DECLARE_1(); 
                program.M_0123_120_DECLARA_SEGURADOS_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.HISTSEGVG_DATA_MOV.Value = pData;
                program.M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0220_200_ACESSA_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_300_150_240_COBERTURAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_300_150_240_COBERTURAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_300_150_240_COBERTURAS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_300_150_240_COBERTURAS_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_0700_000_UPDATE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}