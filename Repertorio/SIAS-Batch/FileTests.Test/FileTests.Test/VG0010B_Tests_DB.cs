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
using static Code.VG0010B;

namespace FileTests.Test_DB
{
    [Collection("VG0010B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0010B_Tests_DB
    {

        [Fact]
        public static void VG0010B_Database()
        {
            var program = new VG0010B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_060_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_070_000_LER_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_080_000_LER_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1(); program.M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_420_000_CURSOR_V1BENEFIPROP_DB_DECLARE_1(); program.M_420_000_CURSOR_V1BENEFIPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_150_000_SELECT_V0APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_160_000_SELECT_V0CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_170_000_SELECT_NUMEROS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.MDATA_MOVIMENTO.Value = "2021-01-01";
                program.MDATA_RENOVACAO.Value = "2021-01-01";
                program.MDATA_NASCIMENTO.Value = "2010-01-01";
                program.M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/ program.M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.VGDATA_INIVIGENCIA.Value = "2021-01-01";
                program.VGDATA_TERVIGENCIA.Value = "2021-01-31";
                program.M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.V1SISTEMA_DTMOVABE.Value = "2021-01-01";
                program.HHORA_OPERACAO.Value = "12:12:12";
                program.MDATA_REFERENCIA.Value = "2022-11-11";
                program.M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*16*/ program.M_360_000_INSERE_V0CONTACOR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.DTTERVIG.Value = "2020-01-01";
                program.M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*22*/ program.M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_600_000_GERA_TERVIG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_600_010_GERA_TERVIG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_600_010_GERA_TERVIG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}