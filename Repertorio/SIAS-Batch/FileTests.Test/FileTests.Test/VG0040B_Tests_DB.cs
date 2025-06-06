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
using static Code.VG0040B;

namespace FileTests.Test_DB
{
    [Collection("VG0040B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0040B_Tests_DB
    {

        [Fact]
        public static void VG0040B_Database()
        {
            var program = new VG0040B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_060_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_070_000_LER_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_080_000_LER_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1(); program.M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_430_000_MIGRACAO_VIDAZUL_DB_DECLARE_1(); program.M_430_000_MIGRACAO_VIDAZUL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*7*/
                program.MDATA_MOVIMENTO.Value = "2024-12-10";
                program.M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_210_010_VERIFICA_PREMIO_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*9*/ 
                program.VGDATA_INIVIGENCIA.Value = "2024-12-10";
                program.VGDATA_TERVIGENCIA.Value = "2024-12-10";
                program.M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*10*/ 
                program.V1SISTEMA_DTMOVABE.Value = "2024-12-10";
                program.MDATA_MOVIMENTO.Value = "2024-12-10";
                program.MDATA_REFERENCIA.Value = "2024-12-10";
                program.HHORA_OPERACAO.Value = "00:00:00";
                program.M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*11*/
                program.SDATA_DTTERVIG.Value = "2024-12-10";
                program.M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*16*/ 
                program.MDATA_OPERACAO.Value = "2024-12-10";
                program.M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}