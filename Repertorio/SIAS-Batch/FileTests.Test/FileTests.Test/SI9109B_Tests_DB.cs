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
using static Code.SI9109B;

namespace FileTests.Test_DB
{
    [Collection("SI9109B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    public class SI9109B_Tests_DB
    {

        [Fact]
        public static void SI9109B_Database()
        {
            var program = new SI9109B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ 
                program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0200_00_LE_CALENDAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1(); program.R0900_00_DECLARA_SIARDEVC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 123;
                program.R1100_00_LE_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 123;
                program.R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 123;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = 12;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = 12;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01" ;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.Value = "X";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = 120;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.Value = "X";
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.Value = 1;
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.Value = "X";
                program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.Value = 1;
                program.R2100_00_INCLUI_SINISHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R2300_00_ALTERA_SINISMES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.Value = 1;
                program.IND_COD_ERRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.Value = 1;
                program.R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}