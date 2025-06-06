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
using static Code.PF0602B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("PF0602B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0602B_Tests_DB
    {

        [Fact]
        public static void PF0602B_Database()
        {
            var program = new PF0602B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_INICIALIZA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_INICIALIZA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1(); program.R0900_00_DECLARE_PROPOSTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R2220_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1(); program.R2220_00_OBTER_ENDERECO_CORRES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1100_00_LER_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*6*/
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.Value = "2024-12-09";
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.Value = "2024-12-09";
                program.R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_1(); 
            } 
            catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            try { /*7*/ program.R1150_ATUALIZA_ESTRUTURA_PF_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1200_00_SELECT_ESTIPULANTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1500_00_SELECT_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1550_00_SELECT_RCAPS_SFONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1600_00_UPDATE_PROPFID_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1610_00_INSERT_HISPROPFID_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2200_00_SELECT_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1(); program.R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2230_00_SELECT_PESSOA_FONE_DB_DECLARE_1(); program.R2230_00_SELECT_PESSOA_FONE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R2300_00_TRATA_CLIENTES_DB_DECLARE_1(); program.R2300_00_TRATA_CLIENTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2240_00_SELECT_PROPFIDC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2250_00_SELECT_PESSOA_EMAIL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*22*/ program.R6000_00_DECLARE_AGENCEF_DB_DECLARE_1(); program.R6000_00_DECLARE_AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*23*/ 
                Random random = new Random();
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = random.Next();
                program.R2310_00_INSERT_CLIENTES_DB_INSERT_1(); 
            } 
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*24*/
                program.GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.Value = "2024-12-09";
                program.R2315_00_INSERT_GE_DOC_DB_INSERT_1(); 
            } 
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*25*/ 
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.Value = "2024-12-09";
                program.R2350_00_OBTER_COBERTURA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2351_00_OBTER_COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R2352_00_OBTER_COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R2353_00_OBTER_COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R23541_00_OBTER_COBER_SEM_PRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R23543_00_OBTER_COBER_COM_PRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R2400_00_TRATA_ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R2410_00_ALTERA_ENDERECOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R2420_00_INSERT_ENDERECOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R2500_00_INSERT_PROP_EST_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R2600_00_TRATA_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R2600_00_TRATA_EMAIL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R2610_00_INSERE_CLIENTE_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R2620_00_UPDATE_CLIENTE_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*39*/
                program.BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO.Value = 1;
                program.R3000_10_CONTINUA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R3002_01_ESQ_DEBITO_CARTAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*41*/
                program.VG084.DCLVG_COMPL_SICAQWEB.VG084_DTA_CONTRATACAO.Value= "2024-12-09";
                program.VG084.DCLVG_COMPL_SICAQWEB.VG084_HRA_CONTRATACAO.Value = "12:28:03";
                program.VG084.DCLVG_COMPL_SICAQWEB.VG084_IND_ORIGEM_PROPOSTA.Value = "SICAQ";
                program.R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/
                program.CLIENTE.DCLCLIENTES.CGCCPF.Value = 12345678909;
                program.R4400_00_SEL_CLIENTE_JUR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*44*/
                Random random = new Random();
                program.CLIENTE.DCLCLIENTES.COD_CLIENTE.Value = random.Next();
                program.R4500_00_INS_CLIENTE_JUR_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R4510_00_INS_ENDERECO_JUR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R4530_00_INS_EMAIL_JUR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*47*/
                program.VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_FAT_ANUAL.Value = "2024-12-09";
                program.VG092.DCLVG_COMPL_CLI_EMP.VG092_DTA_CONSTITUICAO.Value = "2024-12-09";
                program.R4600_00_INS_COMPLEMENTO_JUR_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R4700_00_INS_RELACIONAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R6100_00_DECLARE_CBO_DB_DECLARE_1(); program.R6100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R9320_00_SELECT_GECLIMOV_DB_DECLARE_1(); program.R9320_00_SELECT_GECLIMOV_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R9200_00_UPDATE_PROPSSBI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R9310_00_MAX_GECLIMOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*55*/
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.Value = "2024-12-09";
                program.GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.Value = "2024-12-09";
                program.VIND_DTNASC.Value = 2024-12-09;
                program.R9400_00_INSERT_GECLIMOV_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}