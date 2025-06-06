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
using static Code.EM0202B;

namespace FileTests.Test_DB
{
    [Collection("EM0202B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0202B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void EM0202B_Database()
        {
            var program = new EM0202B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_ULTIMO_NUMERO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0310_00_DECLARE_V1RELATORIOS_DB_DECLARE_1(); program.R0310_00_DECLARE_V1RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0800_00_DECLARA_TRELAT_DB_DECLARE_1(); program.R0800_00_DECLARA_TRELAT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ 
                program.V1EDIA_DTMOVTO.Value = pData;
                program.R0330_00_PROCESSA_REGISTRO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0400_00_LER_FINANCEIRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1100_00_LER_HISTOPARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1200_00_LER_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1200_00_LER_PARCELA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1300_00_LER_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1400_00_LER_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1400_00_LER_APOLICE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1410_00_LER_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1500_00_LER_FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1500_00_LER_FONTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/
                program.V0CHEQ_DTMOVTO.Value = pData;
                program.V0CHEQ_DATCMP.Value = pData;
                program.V0CHEQ_DATLAN.Value = pData;
                program.R1710_00_GRAVA_TCHEQUES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.V0HCHE_DTMOVTO.Value = pData;
                program.R1710_00_GRAVA_TCHEQUES_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/
                program.V1HIST_DTMOVTO.Value = pData;
                program.V1HIST_DTVENCTO.Value = pData;
                program.V1HIST_DTQITBCO.Value = pData;
                program.R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2100_00_VERIFICA_CB041_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R3020_00_SELECT_CB041_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R3030_00_SELECT_GE368_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R3040_00_SELECT_OD009_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R3105_00_SELECT_AGENCCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.Value = pData;
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA.Value = pData;
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO.Value = pData;
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO.Value = pData;
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO.Value = pData;
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_HORA_OPERACAO.Value = "01:00:00";
                program.R3110_00_INSERT_CBCONDEV_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R9000_00_ALTERA_SITUACAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}