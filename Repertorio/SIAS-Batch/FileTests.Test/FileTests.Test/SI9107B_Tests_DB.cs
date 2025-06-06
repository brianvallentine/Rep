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
using Dclgens;
using Code;
using static Code.SI9107B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Collection("SI9107B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9107B_Tests_DB
    {

        [Fact]
        public static void SI9107B_Database()
        {
            var program = new SI9107B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0200_00_LE_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1(); program.R0900_00_DECLARA_SIARDEVC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R1100_00_LE_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R1200_00_CONTA_INDENIZACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R1300_00_CONTA_LIBERACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR.Value = 1; 
                program.SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA.Value = 1;
                program.R1400_00_LE_SINISCAU_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;   
                program.R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = 2;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 3;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.Value = "2020-01-01";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = 4;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.Value = "x";
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.Value = 5;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.Value = "x";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 3;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.Value = 7;
                program.R2100_00_INCLUI_SINISHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R2200_00_LE_SINIMPSE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO.Value = 2;
                program.R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.Value = 1;
                program.SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_VAL_IS_DATA_OCORR.Value = 1;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_DATA_OCORRENCIA.Value = "2020-01-01";
                program.R2400_00_INCLUI_SINIMPSE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R2500_00_ALTERA_SINISMES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.Value = 1;
                program.IND_COD_ERRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.Value = 2;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.Value = 3;
                program.R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}