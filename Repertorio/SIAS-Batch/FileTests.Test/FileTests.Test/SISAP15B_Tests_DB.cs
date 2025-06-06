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
using static Code.SISAP15B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("SISAP15B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SISAP15B_Tests_DB
    {

        [Fact]
        public static void SISAP15B_Database()
        {
            var program = new SISAP15B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_VALIDA_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE.Value = 123;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE.Value = 123;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO.Value = 123;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA.Value = 123;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NSAS.Value = 123;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.Value = "123";
                program.R0100_DECLARE_MOVDEBCE_DB_DECLARE_1(); program.R0100_DECLARE_MOVDEBCE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 1123;
                program.R4000_DECLARE_IMPOSTOS_DB_DECLARE_1(); program.R4000_DECLARE_IMPOSTOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.R3010_ACESSA_SCPJUD_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.R3010_ACESSA_SCPJUD_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.Value = 1;
                program.R3210_LE_FORNECEDOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2000_CADASTRAIS_ODS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2010_CADASTRAIS_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 1;
                program.R2010_CADASTRAIS_LOTERICO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 2;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 1;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 1;
                program.R2020_CADASTRAIS_FORNECED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2030_PEGA_NOTA_FISCAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2040_PEGA_SERVICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R7777_ACESSA_TIMESTAMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}