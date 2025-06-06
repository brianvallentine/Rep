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
using static Code.VG0030B;

namespace FileTests.Test_DB
{
    [Collection("VG0030B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0030B_Tests_DB
    {

        [Fact]
        public static void VG0030B_Database()
        {
            var program = new VG0030B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_060_000_LER_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_070_000_LER_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_080_000_LER_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1(); program.M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SDATA_MOVIMENTO.Value = "2021-01-01";
                program.M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.VGDATA_INIVIGENCIA.Value = "2023-01-01";
                program.VGDATA_TERVIGENCIA.Value = "2023-01-31";
                program.M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.V1SISTEMA_DTMOVABE.Value = "2022-03-03";
                program.MDATA_MOVIMENTO.Value = "2021-02-02";
                program.MDATA_REFERENCIA.Value = "2021-02-02";
                program.HHORA_OPERACAO.Value = "12:12:12";
                program.M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/ program.M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.MDATA_OPERACAO.Value = "2015-02-02";
                program.M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/ program.M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_520_000_SELECT_V0PARCELVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.V0HCOB_DTVENCTO.Value = "2023-02-02";
                program.M_530_000_INCLUI_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*21*/ program.M_530_000_INCLUI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_530_000_INCLUI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.M_625_000_CONSULTA_HISCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.M_630_000_CONSULTA_HISCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}