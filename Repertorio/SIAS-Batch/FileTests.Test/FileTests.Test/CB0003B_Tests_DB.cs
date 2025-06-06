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
using static Code.CB0003B;

namespace FileTests.Test_DB
{
    [Collection("CB0003B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB0003B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void CB0003B_Database()
        {
            var program = new CB0003B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SELECT_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_V1MOVICOB_DB_DECLARE_1(); program.R0900_00_DECLARE_V1MOVICOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1760_00_DECLARE_NOTASCRED_DB_DECLARE_1(); program.R1760_00_DECLARE_NOTASCRED_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1715_00_CORRECAO_NOTACRED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.V1SIST_DTMOVABE.Value = pData;
                program.HNOTCRE_HORAOPER.Value = "01:00:00";
                program.V1NOTA_DTVENCTO.Value = pData;
                program.R1715_30_INSERE_CORRECAO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1730_00_ACESSA_HISTNOTCRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R3450_00_DECLARE_AU071_DB_DECLARE_1(); program.R3450_00_DECLARE_AU071_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2100_00_SELECT_V1ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.WHOST_DTINIVIG.Value = pData;
                program.R2200_00_SELECT_V1MOEDA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2300_00_SELECT_V1PARAMETRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3000_00_CALCULA_CORRECAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R3100_00_SELECT_VENCIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R3150_00_SELECT_V1PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3200_00_SELECT_V1PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.V1PARC_NRPARCEL.Value = 100;
                program.V1MCOB_NRTIT.Value = 100;
                program.R3200_00_SELECT_V1PARCELA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R3220_00_SELECT_V1PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R3200_00_SELECT_V1PARCELA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R3250_00_SELECT_V1PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R3300_00_ACESSA_PARCELADEV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R3400_00_ACESSA_CBMALPAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_DTA_VENCIMENTO.Value = pData;
                program.V1MCOB_DTQITBCO.Value = pData;
                program.R3441_00_CALCULA_JUROS_MULTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                program.AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO.Value = pData;
                program.V1SIST_DTMOVABE.Value = pData;
                program.R3480_00_DECLARE_V0CALENDARIO_DB_DECLARE_1(); program.R3480_00_DECLARE_V0CALENDARIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R3500_00_SELECT_CBAPOVIG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R3600_00_SELECT_V1PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.V0HISP_DTMOVTO.Value = pData;
                program.V0HISP_HORAOPER.Value = "01:00:00";
                program.V0HISP_DTVENCTO.Value = pData;
                program.V0HISP_DTQITBCO.Value = pData;
                program.R5100_00_INSERT_V0HISTOPARC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/
                program.V0FOLP_DTMOVTO.Value = pData;
                program.V0FOLP_HORAOPER.Value = "01:00:00";
                program.V0FOLP_DTLIBER.Value = pData;
                program.V0FOLP_DTQITBCO.Value = pData;                
                program.R5200_00_INSERT_V0FOLLOWUP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R6100_00_UPDATE_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R6110_00_INCLUI_AUTO_COMPL_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R6110_00_INCLUI_AUTO_COMPL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R6110_00_INCLUI_AUTO_COMPL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R6150_00_UPDATE_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R6160_00_UPDATE_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R6200_00_UPDATE_V0ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R6210_00_VERIFICA_PARCELAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R6300_00_UPDATE_V0MOVICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R6400_00_UPDATE_V0AVISALDOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R7250_00_UPDATE_V0FOLLOW_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}