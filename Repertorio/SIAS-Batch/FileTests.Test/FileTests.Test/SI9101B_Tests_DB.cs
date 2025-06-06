using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SI9101B;

namespace FileTests.Test_DB
{
    [Collection("SI9101B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9101B_Tests_DB
    {

        [Fact]
        public static void SI9101B_Database()
        {
            var program = new SI9101B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1(); program.R0900_00_DECLARA_SIARDEVC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 1;
                program.HOST_NUM_ITEM_INI.Value = 2;
                program.HOST_NUM_ITEM_FIM.Value = 3;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.Value = "2020-01-01";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.Value = "2020-01-01";
                program.R1200_00_LE_APOLIAUT_DB_DECLARE_1(); program.R1200_00_LE_APOLIAUT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 123;
                program.R1100_00_LE_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 12;
                program.R1300_00_LE_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ 
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.Value = "2020-01-01";
                program.AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 2;
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM.Value = 3;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value = 4;
                program.R1400_00_LE_AUTOCOBE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.Value = "2020-01-01";
                program.AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_COD_COBERTURA.Value =1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 2;
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO.Value = 3;
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM.Value = 4;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value = 5;
                program.R1410_00_LE_AUTOCOBE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value = 2;
                program.R1500_LE_SINISCAU_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 1;
                program.R1610_00_LE_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 1;
                program.R1620_00_LE_PARCEHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ 
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.Value = 1;
                program.R2100_00_MAX_SINISCON_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.Value = 1;
                program.SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.Value = 2;
                program.SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 4;
                program.R2200_00_INCLUI_SINISCON_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.Value = 1;
                program.SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.Value = 2;
                program.SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.Value = "x";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R2300_00_INCLUI_SINISACO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 123;
                program.R2400_00_SUM_APOLCOSS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value = 2;
                program.R2500_00_MAX_NUMERAES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_SINISTRO.Value = 1;
                program.APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.Value = 2;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value = 3;
                program.R2550_00_ALTERA_NUMERAES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.Value = 1;
                program.SINISCON.DCLSINISTRO_CONTROLE.SINISCON_NUM_PROTOCOLO_SINI.Value = 2;
                program.SINISCON.DCLSINISTRO_CONTROLE.SINISCON_DAC_PROTOCOLO_SINI.Value = "X";
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 4;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 5;
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ENDOSSO.Value = 6;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_COMUNICADO.Value = "2020-01-01";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.Value = "2020-01-01";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.Value = 10;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_MOEDA_SINI.Value = 11;
                program.AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_IMP_SEGURADA_IX.Value = 12;
                program.APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_PART_COSSEGURO.Value = 13;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_PCT_PART_RESSEGURO.Value = 14;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value = 15;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.Value = 16;
                program.R2600_00_INCLUI_SINISMES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 1;
                program.APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.Value = 2;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.Value = 3;
                program.R2700_00_INCLUI_SINIITEM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.Value = 2;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2002-01-01";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO.Value = 3;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 4;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.Value = 5;
                program.R2800_00_INCLUI_SINISHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 2;
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_ITEM.Value = 3;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value = 4;
                program.R2900_00_INCLUI_SINISAUT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value =1 ;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.Value = 2;
                program.AUTOCOBE.DCLAUTO_COBERTURAS.AUTOCOBE_IMP_SEGURADA_IX.Value = 3;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA.Value = "2020-01-01";
                program.R3000_00_INCLUI_SINIMPSE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.Value = 1;
                program.IND_COD_ERRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.Value = 1;
                program.R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}