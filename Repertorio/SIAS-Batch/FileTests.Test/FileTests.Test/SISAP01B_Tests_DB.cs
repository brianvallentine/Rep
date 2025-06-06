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
using static Code.SISAP01B;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("SISAP01B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SISAP01B_Tests_DB
    {

        [Fact]
        public static void SISAP01B_Database()
        {
            var program = new SISAP01B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.Value = "A";
                program.REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO.Value = 1;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE.Value = 2;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO.Value = 3;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA.Value = 4;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NSAS.Value = 5;
                program.R0020_VALIDA_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
               
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE.Value = 123456789;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO.Value = 123456789;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA.Value = 123456789;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_NSAS.Value = 123456789;
                program.REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.Value = "X"; 
                program.R0100_DECLARE_MOVDEBCE_DB_DECLARE_1(); program.R0100_DECLARE_MOVDEBCE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 12456;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.R4000_DECLARE_IMPOSTOS_DB_DECLARE_1(); program.R4000_DECLARE_IMPOSTOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.R3010_ACESSA_SCPJUD_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.R3010_ACESSA_SCPJUD_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.Value = 123;
                program.R3210_LE_FORNECEDOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 132;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.R5000_SELECT_DOC_FISCAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.R2000_CADASTRAIS_ODS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 123;
                program.R2010_CADASTRAIS_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.R2010_CADASTRAIS_LOTERICO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 123;
                program.R2020_CADASTRAIS_FORNECED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123 ;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123 ;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 123;
                program.R2030_PEGA_NOTA_FISCAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 123;
                program.R2040_PEGA_SERVICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value =123;
                program.FORNECED.DCLFORNECEDORES.FORNECED_CEP.Value = 123;
                program.R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ 
                program.R7777_ACESSA_TIMESTAMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = 123;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.Value = 123;
                program.AREA_DE_WORK.W_PRE.Value = "x";
                program.AREA_DE_WORK.W_LIB.Value = "x";
                program.R19200_SELECT_REINF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS.Value =123;
                program.R19300_SELECT_INSS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO.Value = 123 ;
                program.R19400_VERIFICA_OPERACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}