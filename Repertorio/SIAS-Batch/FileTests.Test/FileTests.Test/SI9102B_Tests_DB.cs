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
using static Code.SI9102B;

namespace FileTests.Test_DB
{
    [Collection("SI9102B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class SI9102B_Tests_DB
    {

        [Fact]
        public static void SI9102B_Database()
        {
            var program = new SI9102B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1(); program.R0900_00_DECLARA_SIARDEVC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 123;
                program.R1100_00_LE_SINISMES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.Value = 1;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.Value =2 ;
                program.R1200_00_LE_SINISCAU_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 1;
                program.R1300_00_CONTA_INDENIZACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.Value = 123;
                program.R1400_00_SUM_PARCELA_PEND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ 
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.Value = 123;
                program.R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE.Value = 1;
                program.R1600_00_LE_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ 
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.Value = 0;
                program.IND_COD_ERRO.Value = 0;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.Value ="x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_RETORNO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.Value = 0;
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.Value = "x";
                program.SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.Value = 0;
                program.R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}