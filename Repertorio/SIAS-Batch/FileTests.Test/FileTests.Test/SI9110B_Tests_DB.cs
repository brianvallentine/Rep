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
using static Code.SI9110B;

namespace FileTests.Test_DB
{
    [Collection("SI9110B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9110B_Tests_DB
    {

        [Fact]
        public static void SI9110B_Database()
        {
            var program = new SI9110B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ 
                program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.Value = "X";
                program.R0510_00_MAX_GEARDETA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.Value = "X";
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = 0;
                program.HOST_ANO_MOV_ABERTO.Value = 2020;
                program.HOST_MES_MOV_ABERTO.Value = 1;
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.Value = 1;
                program.R0520_00_INCLUI_GEARDETA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.Value = "X";
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = 1;
                program.SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO.Value = "x";
                program.SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO.Value = 1;
                program.SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_STA_PROCESSAMENTO.Value = "x";
                program.R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.Value = 1;
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.Value = "x";
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value =  0 ;
                program.R0700_00_ALTERA_GEARDETA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                 program.R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1(); program.R0900_00_DECLARA_SIARDEVC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.Value = 1;   
                program.R1100_00_LE_SIERRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R1250_00_LE_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.Value = "X";
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = 1;
                program.SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_TIPO_REGISTRO_VC.Value = "x";
                program.SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_SEQ_REGISTRO_VC.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.Value = 1;
                program.R1300_00_INCLUI_SIARREVC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.Value = "X";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.Value = 1;
                program.R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}