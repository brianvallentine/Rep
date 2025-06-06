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
using static Code.VA0601B;

namespace FileTests.Test_DB
{
    [Collection("VA0601B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0601B_Tests_DB
    {

        [Fact]
        public static void VA0601B_Database()
        {
            var program = new VA0601B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_INICIALIZA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_INICIALIZA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1(); program.R0900_00_DECLARE_PROPOSTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1(); program.R1510_00_SELECT_RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0911_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0911_00_SELECT_RCAPS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1000_CONSISTE_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*10*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2024-12-10";
                program.R1400_00_SELECT_PLANOS_VA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1400_00_SELECT_PLANOS_VA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1401_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1410_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1410_00_SELECT_PLANOS_VA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1420_VERIFICA_MATRIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1500_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1505_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1510_00_SELECT_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1(); program.R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1600_00_UPDATE_PROPFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1900_CONSULTA_CARENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2110_00_SELECT_FUNCIOCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2203_00_SELECT_CONDITEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2205_00_SELECT_HISTCOBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2200_00_SELECT_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R2215_00_SELECT_PROPOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1(); program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1(); program.R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*34*/
                program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 93010000890;
                program.R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1();
                program.R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R2240_00_SELECT_PROPFIDC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R2242_00_SELECT_ACUM_RISCO_DB_DECLARE_1(); program.R2242_00_SELECT_ACUM_RISCO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R2241_10_FETCH_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R2243_00_SELECT_ACUM_RISCO_DB_DECLARE_1(); program.R2243_00_SELECT_ACUM_RISCO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R2242_10_FETCH_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R22421_00_ACUM_RISCO_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R2244_00_SELECT_ACUM_RISCO_DB_DECLARE_1(); program.R2244_00_SELECT_ACUM_RISCO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R2243_10_FETCH_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R2300_00_TRATA_CLIENTES_DB_DECLARE_1(); program.R2300_00_TRATA_CLIENTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R2244_10_FETCH_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*50*/
                var dt = "2021-11-19-10.22.15.289410";

                program.SPGE051W.LK_GE051_TRACE.Value = "N";
                program.SPGE051W.LK_GE051_S_DTH_CAD_PREST.Value = dt;
                program.SPGE051W.LK_GE051_S_DTH_CAD_VIDA.Value = dt;
                program.SPGE051W.LK_GE051_S_DTH_CAD_PREV.Value = dt;
                program.SPGE051W.LK_GE051_S_DTH_CAD_HABIT.Value = dt;
                program.SPGE051W.LK_GE051_S_DTH_CADASTRAMENTO.Value = dt;
                /*
                 var sEGUROS_SPBGE051_Call1 = new SEGUROS_SPBGE051_Call1()
                {
                    LK_GE051_TRACE = SPGE051W.LK_GE051_TRACE.ToString(),
                    LK_GE051_NUM_CPF_CNPJ = SPGE051W.LK_GE051_NUM_CPF_CNPJ.ToString(),
                    LK_GE051_S_QTD_CNTR_PREST = SPGE051W.LK_GE051_S_QTD_CNTR_PREST.ToString(),
                    LK_GE051_S_VLR_IS_ACUM_PREST = SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREST.ToString(),
                    LK_GE051_S_DTH_CAD_PREST = SPGE051W.LK_GE051_S_DTH_CAD_PREST.ToString(),
                    LK_GE051_S_QTD_CONTR_VIDA = SPGE051W.LK_GE051_S_QTD_CONTR_VIDA.ToString(),
                    LK_GE051_S_VLR_IS_ACUM_VIDA = SPGE051W.LK_GE051_S_VLR_IS_ACUM_VIDA.ToString(),
                    LK_GE051_S_DTH_CAD_VIDA = SPGE051W.LK_GE051_S_DTH_CAD_VIDA.ToString(),
                    LK_GE051_S_QTD_CNTR_PREV = SPGE051W.LK_GE051_S_QTD_CNTR_PREV.ToString(),
                    LK_GE051_S_VLR_IS_ACUM_PREV = SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREV.ToString(),
                    LK_GE051_S_DTH_CAD_PREV = SPGE051W.LK_GE051_S_DTH_CAD_PREV.ToString(),
                    LK_GE051_S_QTD_CONTR_HABIT = SPGE051W.LK_GE051_S_QTD_CONTR_HABIT.ToString(),
                    LK_GE051_S_VLR_IS_ACUM_HABIT = SPGE051W.LK_GE051_S_VLR_IS_ACUM_HABIT.ToString(),
                    LK_GE051_S_DTH_CAD_HABIT = SPGE051W.LK_GE051_S_DTH_CAD_HABIT.ToString(),
                    LK_GE051_S_QTD_TOTAL_CNTR = SPGE051W.LK_GE051_S_QTD_TOTAL_CNTR.ToString(),
                    LK_GE051_S_VLR_TOTAL_CNTR = SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR.ToString(),
                    LK_GE051_S_DTH_CADASTRAMENTO = SPGE051W.LK_GE051_S_DTH_CADASTRAMENTO.ToString(),
                    LK_GE051_IND_ERRO = SPGE051W.LK_GE051_IND_ERRO.ToString(),
                    LK_GE051_MSG_ERRO = SPGE051W.LK_GE051_MSG_ERRO.ToString(),
                    LK_GE051_NOM_TABELA = SPGE051W.LK_GE051_NOM_TABELA.ToString(),
                    LK_GE051_SQLCODE = SPGE051W.LK_GE051_SQLCODE.ToString(),
                    LK_GE051_SQLERRMC = SPGE051W.LK_GE051_SQLERRMC.ToString(),
                };
                 */

                program.R2245_00_VERIFICA_ACUM_CPF_DB_CALL_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1(); program.R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R2310_00_INSERT_CLIENTES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R2314_00_TRATA_GE_DOC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R2315_00_INSERT_GE_DOC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*56*/
                long UFLong;
                UFLong = Convert.ToInt64("11");
                program.VIND_UF_EXPEDIDORA.Value = UFLong;
                program.VIND_UF_EXPEDIDORA.Value = UFLong;
                program.R2316_00_UPDATE_GE_DOC_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R2350_00_TRATA_ERRO_1864_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.R2400_00_TRATA_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R2420_00_INSERT_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R2420_00_INSERT_ENDERECOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R2450_00_VALIDA_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R2500_00_TRATA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.R2510_00_ALTERA_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.R2520_00_INSERT_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/ program.R2520_00_INSERT_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/ program.R2600_00_TRATA_ESTADO_CIVIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/ program.R2610_00_ALTERA_ESTADO_CIVIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*68*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2024-12-10";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-12-10";
                program.WHOST_DTPROXVEN.Value = "2024-12-10";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = "2024-12-10";
                program.R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*69*/
                program.VG084.DCLVG_COMPL_SICAQWEB.VG084_DTA_CONTRATACAO.Value = "2024-12-10";
                program.VG084.DCLVG_COMPL_SICAQWEB.VG084_HRA_CONTRATACAO.Value = "00:00:00";
                program.R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/ program.R3020_00_INSERE_ANDAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*71*/ program.R3100_00_INSERT_COBERPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.R3105_00_SELECT_HISCOBPR_AZUL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/ program.R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1(); program.R3150_00_DECLARE_VGPLAACES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/ program.R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.R4300_00_TRATA_CLIENTE_EMPRESA_DB_DECLARE_1(); program.R4300_00_TRATA_CLIENTE_EMPRESA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/ program.R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*77*/ program.R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/ program.R3300_00_INSERT_COMISICOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/ program.R3400_00_INSERT_PARCELVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*80*/ program.R3410_00_INSERT_PARCELVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*81*/ program.R3500_00_INSERT_HISTCOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*82*/ program.R3510_00_INSERT_HISTCOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*83*/
                program.HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO.Value = "2024-12-10";
                program.R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*84*/ program.R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*85*/ program.R3600_00_INSERT_HISTCONTABILVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*86*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-12-10";
                program.HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR.Value = "2024-12-10";
                program.R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*87*/ program.R3610_00_INSERT_HISTCONTABILVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*88*/ program.R3610_00_INSERT_HISTCONTABILVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*89*/ program.R3700_00_INSERT_RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*90*/ program.R3700_00_INSERT_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*91*/ program.R3700_00_INSERT_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*92*/ program.R6000_00_DECLARE_AGENCEF_DB_DECLARE_1(); program.R6000_00_DECLARE_AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*93*/
                program.CLIENTE.DCLCLIENTES.DATA_NASCIMENTO.Value = "2024-12-10";
                program.R4310_00_INSERT_CLIENTES_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*94*/ program.R4310_10_INSERT_CLIENTES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*95*/ program.R4400_00_TRATA_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*96*/ program.R4420_00_INSERT_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*97*/ program.R4420_00_INSERT_ENDERECOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*98*/ program.R4500_00_TRATA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*99*/ program.R4510_00_ALTERA_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*100*/ program.R4520_00_INSERT_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*101*/ program.R4520_00_INSERT_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*102*/ program.R4600_00_INSERT_CLIENTE_EMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*103*/ program.R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*104*/ program.R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*105*/ program.R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*106*/ program.R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*107*/ program.R5650_00_INSERE_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*108*/ program.R6100_00_DECLARE_CBO_DB_DECLARE_1(); program.R6100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*109*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = "2024-12-10";
                program.R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1();
                program.R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*110*/ program.R8350_FECHAR_MSG_ERRO_DPS_DB_DECLARE_1(); program.R8360_ABRIR_CSR_ERRO_DPS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*111*/ program.R8200_00_INSERT_VGHISTCONT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*112*/ program.R9320_00_SELECT_GECLIMOV_DB_DECLARE_1(); program.R9320_00_SELECT_GECLIMOV_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*113*/ program.R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*114*/ program.R9310_00_MAX_GECLIMOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*115*/
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.Value = "2024-12-10";
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.Value = "2024-12-10";

                program.R9400_00_INSERT_GECLIMOV_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*116*/ program.R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}