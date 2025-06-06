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
using static Code.VA0118B;

namespace FileTests.Test_DB
{
    [Collection("VA0118B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0118B_Tests_DB
    {

        [Fact]
        public static void VA0118B_Database()
        {
            var program = new VA0118B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/ program.M_0260_00_ABRIR_CSR_RISCO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0112_00_ABRIR_CSR_ERRO_DPS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0117_00_ABRIR_CSR_ERRO_ACAT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0010_LER_TITULO_V0BANCO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0010_LER_TITULO_V0BANCO_DB_DECLARE_1(); program.M_0010_LER_TITULO_V0BANCO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0010_LER_TITULO_V0BANCO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0000_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_0100_NEXT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_0100_PROCESSA_PROPOSTA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_11(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_12(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_13(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_0115_00_CONS_ERRO_DPS_FECHADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_0255_00_ACESSA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.M_0256_RECUPERA_PRODUTO_SIVPF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.M_1120_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.M_1120_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.M_0282_00_VERIFICA_PU_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.M_0282_00_VERIFICA_PU_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.M_0283_00_VERIFICA_VIGENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.M_0284_00_SOMA_IS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.M_0300_VERIFICA_CROT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.M_0300_VERIFICA_CROT_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.M_0320_UPDATE_CROT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.M_0330_INCLUI_CROT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R0398_00_MAX_V0FOLHETO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R0399_00_SELECT_V0FOLHETO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.M_0550_00_REALIZA_DEVOLUCAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.M_0560_00_INSERT_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.M_0580_00_DECLINA_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.M_1110_VERIFICA_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.M_1110_VERIFICA_RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.M_1110_VERIFICA_RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.M_1110_VERIFICA_RCAP_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.M_8100_MONTA_BENEFICIARIOS_DB_DECLARE_1(); program.M_8100_MONTA_BENEFICIARIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.M_1500_SELECT_PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.M_2100_INCLUI_CORRETOR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.M_5100_GERA_COMISSAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R6290_00_INSERT_MOVFEDCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R6290_10_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.R6300_00_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.R6400_10_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/ program.R6500_10_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/ program.R7290_00_INSERT_MOVFEDCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/ program.R7400_10_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*68*/ program.M_8000_INTEGRA_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*69*/ program.R8000_PROPAUTOM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/ program.R8000_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*71*/ program.M_8000_INTEGRA_VG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.R8000_PROPAUTOM_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/ program.R8000_PROPAUTOM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/ program.R8000_PROPAUTOM_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.M_8000_INTEGRA_VG_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/ program.R8000_PROPAUTOM_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*77*/ program.R8000_PROPAUTOM_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/ program.M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/ program.R8000_PROPAUTOM_DB_UPDATE_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*80*/ program.M_8000_INTEGRA_VG_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*81*/ program.M_8000_INTEGRA_VG_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*82*/ program.R7774_00_LER_RCAP_COMP_DB_DECLARE_1(); program.R7774_00_LER_RCAP_COMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*83*/ program.M_8000_INTEGRA_VG_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*84*/ program.M_8100_LOOP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*85*/ program.M_8120_INICIO_VERIFICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*86*/ program.M_8200_CONCEDE_CDG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*87*/ program.M_8200_CONCEDE_CDG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*88*/ program.M_8210_ELIMINA_CDG_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*89*/ program.M_8220_INCLUI_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*90*/ program.M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*91*/ program.M_8300_CONCEDE_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*92*/ program.M_8300_CONCEDE_SAF_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*93*/ program.M_8310_ELIMINA_SAF_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*94*/ program.M_8320_INCLUI_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*95*/ program.M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*96*/ program.M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*97*/ program.M_8500_CALC_PROP_AUTOM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*98*/ program.M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*99*/ program.M_8595_00_VERIFICA_CRTCA_PEND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*100*/ program.M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*101*/ program.M_8600_10_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*102*/ program.M_8600_10_CONTINUA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*103*/ program.M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*104*/ program.M_8600_CONTINUA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*105*/ program.M_8600_15_INSERT_V0HISTCOBVA_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*106*/ program.M_8605_00_VERIFICA_TP_MENS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*107*/ program.M_8700_GERA_DEBITO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*108*/ program.M_8700_GERA_DEBITO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*109*/ program.M_8800_APROPRIA_FUNDO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*110*/ program.M_8800_APROPRIA_FUNDO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*111*/ program.M_8800_APROPRIA_FUNDO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*112*/ program.M_8800_APROPRIA_FUNDO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*113*/ program.M_8800_APROPRIA_FUNDO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*114*/ program.R7771_00_LER_PROP_SIVPF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*115*/ program.M_8800_APROPRIA_FUNDO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*116*/ program.R7773_00_LER_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*117*/ program.R7774_00_LER_RCAP_COMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*118*/ program.R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*119*/ program.M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*120*/ program.M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*121*/ program.M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}