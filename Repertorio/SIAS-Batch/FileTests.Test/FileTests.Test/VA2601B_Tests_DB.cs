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
using static Code.VA2601B;

namespace FileTests.Test_DB
{
    [Collection("VA2601B_Tests_DB")]
   [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
   [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
   public class VA2601B_Tests_DB
   {

       [Fact]
       public static void VA2601B_Database()
       {
           var program = new VA2601B();
           AppSettings.TestSet.DB_Test.Is_DB_Test = true;
           try { /*1*/ program.R0100_00_INICIALIZA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*2*/ program.R0100_00_INICIALIZA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*3*/ program.R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1(); program.R0900_00_DECLARE_PROPOSTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*4*/ program.R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1(); program.R1510_00_SELECT_RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*5*/ program.R0911_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*6*/ program.R1000_CONSISTE_CX_TRAB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*7*/ program.R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*8*/ program.R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*9*/ program.R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*10*/ program.R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*11*/
               program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2024-10-10";
               program.R1400_00_SELECT_PLANOS_VA_DB_SELECT_1(); 
           } catch (Exception ex) { _.ThreatableTestError(ex); }

           try { /*12*/ program.R1400_00_SELECT_PLANOS_VA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*13*/ program.R1401_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*14*/ program.R1410_00_SELECT_PLANOS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*15*/ program.R1410_00_SELECT_PLANOS_VA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*16*/ program.R1500_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*17*/ program.R1505_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*18*/ program.R1510_00_SELECT_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*19*/ program.R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1(); program.R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*20*/ program.R1600_00_UPDATE_PROPFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*21*/ program.R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*22*/ program.R2203_00_SELECT_CONDITEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*23*/ program.R2205_00_SELECT_HISTCOBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*24*/ program.R2200_00_SELECT_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*25*/ program.R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*26*/ program.R2215_00_SELECT_PROPOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*27*/ program.R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*28*/ program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1(); program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*29*/ program.R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1(); program.R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*30*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*31*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*32*/
               program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO.Value = "PREFERENCIAL VIDA PLUS  FENAE ";
               program.PESFIS.DCLPESSOA_FISICA.CPF.Value = 95024794753;
               program.R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1(); 
               program.R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1(); 
           } catch (Exception ex) { _.ThreatableTestError(ex); }

           try { /*33*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*34*/ program.R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*35*/ program.R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*36*/ program.R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*37*/ program.R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*38*/ program.R2240_00_SELECT_PROPFIDC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*39*/ program.R2300_00_TRATA_CLIENTES_DB_DECLARE_1(); program.R2300_00_TRATA_CLIENTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*40*/ program.R2241_10_FETCH_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*41*/ program.R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1(); program.R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*42*/ program.R2310_00_INSERT_CLIENTES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*43*/
               program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.Value = "2021-01-01";
               program.R2315_00_INSERT_GE_DOC_DB_INSERT_1(); 
           } catch (Exception ex) { _.ThreatableTestError(ex); }

           try { /*44*/ program.R2350_00_TRATA_ERRO_1864_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*45*/ program.R2350_00_TRATA_ERRO_1864_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*46*/ program.R2400_00_TRATA_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*47*/ program.R2350_00_TRATA_ERRO_1864_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*48*/ program.R2350_00_TRATA_ERRO_1864_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*49*/ program.R2420_00_INSERT_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*50*/ program.R2420_00_INSERT_ENDERECOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*51*/ program.R2450_00_VALIDA_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*52*/ program.R2500_00_TRATA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*53*/ program.R2510_00_ALTERA_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*54*/ program.R2520_00_INSERT_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*55*/ program.R2520_00_INSERT_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*56*/
               program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = "2000-01-01";
               program.WHOST_DATA_AGENDAMENTO.Value = "2020-01-01";
               program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2021-01-01";
               program.WHOST_DTPROXVEN.Value = "2022-02-20";
               program.R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1(); 
           } catch (Exception ex) { _.ThreatableTestError(ex); }

           try { /*57*/ program.R3020_00_INSERE_ANDAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*58*/ program.R3100_00_INSERT_COBERPROPVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*59*/ program.R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1(); program.R3150_00_DECLARE_VGPLAACES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*60*/ program.R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*61*/ program.R6000_00_DECLARE_AGENCEF_DB_DECLARE_1(); program.R6000_00_DECLARE_AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*62*/ program.R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*63*/ program.R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*64*/ program.R3300_00_INSERT_COMISICOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*65*/ program.R3400_00_INSERT_PARCELVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*66*/ program.R3500_00_INSERT_HISTCOBVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*67*/ program.R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*68*/ program.R3525_00_CONSULTA_CONVENIOVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*69*/
               program.HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR.Value = "2021-01-02";
               program.R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1(); 
           } catch (Exception ex) { _.ThreatableTestError(ex); }

           try { /*70*/ program.R3700_00_INSERT_RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*71*/ program.R3700_00_INSERT_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*72*/ program.R3700_00_INSERT_RELATORIOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*73*/ program.R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*74*/ program.R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*75*/ program.R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*76*/ program.R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*77*/ program.R6100_00_DECLARE_CBO_DB_DECLARE_1(); program.R6100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*78*/ program.R6200_00_DECLARE_FONTES_DB_DECLARE_1(); program.R6200_00_DECLARE_FONTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*79*/
               program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = "2021-01-01";
               program.R7900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1(); 
               program.R7900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1(); 
           } catch (Exception ex) { _.ThreatableTestError(ex); }

           try { /*80*/ program.R9320_00_SELECT_GECLIMOV_DB_DECLARE_1(); program.R9320_00_SELECT_GECLIMOV_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*81*/ program.R8200_00_INSERT_VGHISTCONT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*82*/ program.R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*83*/ program.R9310_00_MAX_GECLIMOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           try { /*84*/
               program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.Value = "2019-01-01";
               program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.Value = "2020-12-12";
               program.R9400_00_INSERT_GECLIMOV_DB_INSERT_1(); 
           } catch (Exception ex) { _.ThreatableTestError(ex); }

           try { /*85*/ program.R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

       }
   }
}