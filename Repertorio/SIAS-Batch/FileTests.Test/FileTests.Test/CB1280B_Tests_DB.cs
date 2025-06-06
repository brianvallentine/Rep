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
using static Code.CB1280B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("CB1280B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB1280B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void CB1280B_Database()
        {
            var program = new CB1280B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.WS_DT_CORTE.Value = pData;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
                program.Execute_DB_DECLARE_1(); program.P2000_00_PRINCIPAL_DB_OPEN_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.P1000_00_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.Execute_DB_DECLARE_2(); program.P2000_00_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.P2111_00_VALIDA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.P2111_00_VALIDA_APOLICE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.P2112_00_CALCULA_VIGENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.P2111_00_VALIDA_APOLICE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ 
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = pData;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.Value = pData;
                program.P2112_00_CALCULA_VIGENCIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.P2111_00_VALIDA_APOLICE_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.P2113_00_CALCULA_VALORES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.P2111_00_VALIDA_APOLICE_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.P2113_00_CALCULA_VALORES_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.P2113_00_CALCULA_VALORES_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.P2113_00_CALCULA_VALORES_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.P2113_00_CALCULA_VALORES_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO.Value = pData;
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO.Value = pData;
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP.Value = pData;
                program.CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO.Value = pData;
                program.P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.P2113_00_CALCULA_VALORES_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}