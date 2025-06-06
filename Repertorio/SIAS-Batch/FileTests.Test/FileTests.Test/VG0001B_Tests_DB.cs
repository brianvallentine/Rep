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
using static Code.VG0001B;

namespace FileTests.Test_DB
{
    [Collection("VG0001B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0001B_Tests_DB
    {
        [Fact]
        public static void VG0001B_Database()
        {
            var program = new VG0001B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.WS_WORK_AREAS.WS_DATA_AUX.Value = "2000-10-10";
            program.VGSOLFAT.DCLVG_SOLICITA_FATURA.VGSOLFAT_DTVENCTO_FATURA.Value = "2000-10-10";
            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO.Value = "20:20:20";
            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value = "2000-10-10";

            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.Value = "2000-10-10";
            program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Value = "2000-10-10";

            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.Value = "2000-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.Value = "2000-10-10";
            program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";
            program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Value = "2000-10-10";
            program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Value = "2000-10-10";
            program.WS_DTVENC_1PARC.Value = "2000-10-10";

            program.HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.Value = "2000-10-10";
            program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";

            program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MAXVIGENCIA.Value = "2000-10-10";
            program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_DATA_MINVIGENCIA.Value = "2000-10-10";

            program.WS_INIVIGENCIA.Value = "2000-10-10";
            program.WS_TERVIGENCIA.Value = "2000-10-10";

            try { /*1*/ program.M_0889_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0900_DECLA_VGSOLFAT_DB_DECLARE_1(); program.M_0900_DECLA_VGSOLFAT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_1120_BAIXA_RCAP_DB_DECLARE_1(); program.M_1120_BAIXA_RCAP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_1000_UPDATE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_1100_SELECT_NUMEROS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_1110_VERIFICA_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_1110_VERIFICA_RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_1110_VERIFICA_RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_5000_DECLARA_PROPOVA_CRTCA_DB_DECLARE_1(); program.M_5000_DECLARA_PROPOVA_CRTCA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_1000_PROCESSA_VGSOLFAT_DB_SELECT_11(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_1200_SELECT_RCAP_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_1200_SELECT_RCAP_TITULO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_1250_SELECT_RCAP_NRCERTIF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.M_2000_INSERT_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.M_2000_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.M_2100_INSERT_COBERPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.M_2400_INSERT_OPCAOPAGVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.M_2500_INSERT_PARCELVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.M_2600_INSERT_HISTCOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.M_2700_NUM_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.M_2700_NUM_TITULO_SOMA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.M_2800_INSERT_HISTCONTAVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.M_2900_INSERT_HISTCONTABILVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.M_2900_INSERT_HISTCONTABILVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.M_2900_INSERT_HISTCONTABILVA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.M_3000_INSERT_CONVENIOSVG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.M_3100_INSERT_PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.M_3100_INSERT_PRODUTOSVG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.M_3100_INSERT_PRODUTOSVG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.M_3100_INSERT_PRODUTOSVG_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.M_5530_UPDATE_HISTCONTABILVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.M_5900_AJUSTA_INIVIGENCIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.M_7000_00_PROCURA_RISCO_PROP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}