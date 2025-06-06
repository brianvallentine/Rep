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
using static Code.BI6253B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("BI6253B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI6253B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void BI6253B_Database()
        {
            var program = new BI6253B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1(); program.R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0360_00_SELECT_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0370_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0530_00_SELECT_AVISOCRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1150_00_UPDATE_PARCELAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1200_00_SELECT_PARCEHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.Value = pData;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.Value = pData;
                program.PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.Value = pData;
                program.R1250_00_INSERT_PARCEHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1300_00_SELECT_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1350_00_UPDATE_ENDOSSOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1520_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1530_00_SELECT_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO.Value = pData;
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO.Value = "01:00:00";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO.Value = pData;
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO.Value = pData;
                program.R2100_00_INSERT_FOLLOWUP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_MOVIMENTO.Value = pData;
                program.AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_DATA_AVISO.Value = pData;
                program.R5100_00_INSERT_AVISOCRE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_AVISO.Value = pData;
                program.AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_DATA_MOVIMENTO.Value = pData;
                program.R5200_00_INSERT_AVISOSAL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO.Value = pData;
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO.Value = pData;
                program.R5300_00_INSERT_CONDESCE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = pData;
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = pData;
                program.R9000_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}