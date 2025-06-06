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
using Code;
using static Code.VA0469B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA0469B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0469B_Tests_DB
    {

        [Fact]
        public static void VA0469B_Database()
        {
            var program = new VA0469B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0900_00_DECLARE_RELATORIOS_DB_DECLARE_1(); program.R0900_00_DECLARE_RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1005_00_LER_HISTLANCTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1010_00_UPDATE_RELATORI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1100_00_SELECT_HISTCOBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1110_00_SELECT_HISLANCT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1120_00_SELECT_HISLANCT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1125_00_SELECT_HISLANCT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1130_00_SELECT_PARCELVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1140_00_SELECT_PROPOFID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*13*/
                program.WHOST_DATA_CRED.Value = "2024-12-10";
                program.R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2010_00_SELECT_USUFILSE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2020_00_VER_CANCELAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2021_00_VER_CANCELAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2022_00_VER_CANCELAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2200_00_UPDATE_PARCELVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*23*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-12-10";
                program.WDTA_DECLINIO.Value = "2024-12-10";
                program.R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2500_00_INSERT_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*27*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Value = "2024-12-10";
                program.WHOST_DATA_CRED.Value = "2024-12-10";
                program.R3040_00_CONTA_DIAS_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*28*/
                program.PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.Value = "2024-12-10";
                program.WHOST_DATA_CRED.Value = "2024-12-10";
                program.R3040_00_CONTA_DIAS_DB_SELECT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R3150_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R3250_00_SELECT_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*32*/ 
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value = "2024-12-10";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Value = "2024-12-10";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.Value = "2024-12-10";
                program.R3320_00_INSERT_RCAPCOMP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R3330_00_UPDATE_RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R3405_00_SELECT_GE408_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*35*/
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = "2024-12-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "2024-12-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.Value = "2024-12-10";
                //program.VIND_DTENV.Value = "2024-12-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = "2024-12-10";
                //program.VIND_DTRET.Value = "2024-12-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = "2024-12-10";
                //program.VIND_DTCRED.Value = "2024-12-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTA_ORIGINAL.Value = "2024-12-10";

                program.R3410_05_INSERT_MOVIMENTO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R3505_00_SELECT_GE408_SIT0_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}