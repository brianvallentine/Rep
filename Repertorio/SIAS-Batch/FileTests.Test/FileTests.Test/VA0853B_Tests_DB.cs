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
using static Code.VA0853B;

namespace FileTests.Test_DB
{
    [Collection("VA0853B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0853B_Tests_DB
    {

        [Fact]
        public static void VA0853B_Database()
        {
            var program = new VA0853B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try
            { /*1*/

                program.V1SIST_DT_18D_UTIL.Value = "2000-10-10";

                program.R0151_00_DECLARE_CRSR_LINK_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                //TimeOut
                program.V1SIST_DT_18D_UTIL.Value = "2000-10-10";
                program.WHOST_MIN_DTPROXVEN.Value = "2000-10-10";
                program.V1SIST_DTVENFIM_6D_UTIL.Value = "2000-10-10";

                program.R0152_00_DECLARE_CRSR_GERAL_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0100_00_INICIALIZA_PGM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/

                program.LK_PARAMETROS.LK_DT_PROCESSAMENTO.Value = "2000-10-10";

                program.R0100_00_INICIALIZA_PGM_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0111_00_DECLARE_ERRO_PROC_DB_DECLARE_1(); program.R0111_00_DECLARE_ERRO_PROC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                //X'00'
                program.R1100_00_REENVIAR_PARC_ATRASO_DB_DECLARE_1(); program.R1100_00_REENVIAR_PARC_ATRASO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1015_00_VER_RETORNO_SICOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1015_00_VER_RETORNO_SICOV_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1016_00_CONS_SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1017_00_CONS_HISTCOBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/

                program.V0PROP_DTPROXVEN.Value = "2000-10-10";

                program.R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/

                program.V0PROP_DTVENCTO.Value = "2000-10-10";

                program.R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1(); program.R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                //X'00'
                program.R1105_00_MIN_PARCELA_PEND_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1140_00_UPD_PARC_ATZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1140_00_UPD_PARC_ATZ_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.V0COBP_DTINIVIG_1.Value = "2000-10-10";
                program.R1200_00_GERA_PARCELAS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1200_00_GERA_PARCELAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1200_00_GERA_PARCELAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/

                program.V0PROP_DTADMISSAO.Value = "2000-10-10";

                program.R1200_00_GERA_PARCELAS_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1200_00_GERA_PARCELAS_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1200_00_GERA_PARCELAS_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1200_00_GERA_PARCELAS_DB_INSERT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1200_00_GERA_PARCELAS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1200_00_GERA_PARCELAS_DB_INSERT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*28*/

                program.V0COBP_DTINIVIG.Value = "2000-10-10";


                program.R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*30*/
                //Foreign Key
                program.V0HICB_DTVENCTO.Value = "2000-10-10";
                program.V0OPCP_CARTAO_CRED.Value = "0.00";

                program.R1300_00_GERA_DEBITO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*31*/

                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.Value = "2000-10-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.Value = "2000-10-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.Value = "2000-10-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.Value = "2000-10-10";
                program.MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Value = "2000-10-10";

                program.R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*34*/
                //foreign key
                program.R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R1415_00_SEL_TITULO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R1415_00_SEL_TITULO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R1415_00_SEL_TITULO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R1415_00_SEL_TITULO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*43*/
                //X '00'
                program.R7000_GERAR_PARC_ATRASO_DB_DECLARE_1(); program.R7000_GERAR_PARC_ATRASO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R1500_10_UPDATE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R1600_00_VERIFICA_REPASSE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R1600_00_VERIFICA_REPASSE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R1600_00_VERIFICA_REPASSE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*48*/

                program.V0RCDG_DTREFER.Value = "2000-10-10";

                program.R1650_00_REPASSA_CDG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R1650_00_REPASSA_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*50*/

                program.V0RSAF_DTREFER.Value = "2000-10-10";

                program.R1670_00_REPASSA_SAF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R4500_00_SOLIC_RELAT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R4500_00_SOLIC_RELAT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R5000_00_BUSCA_VLPREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R5000_00_BUSCA_VLPREMIO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*57*/

                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2000-10-10";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2000-10-10";

                program.R8100_00_GERAR_ARQSIVPF_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R8220_00_SELECT_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}