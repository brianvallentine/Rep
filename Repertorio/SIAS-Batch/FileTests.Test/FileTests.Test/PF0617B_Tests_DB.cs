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
using static Code.PF0617B;

namespace FileTests.Test_DB
{
    [Collection("PF0617B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0617B_Tests_DB
    {

        [Fact]
        public static void PF0617B_Database()
        {
            var program = new PF0617B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0007_00_OBTER_DT_PROCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0350_00_LER_ENDERECO_DB_DECLARE_1(); program.R0350_00_LER_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.Value = 80000000017;
                program.R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0250_00_VERIFICA_HISTORICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0300_00_LER_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0340_00_LER_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0345_00_LER_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0573_00_LER_PARCELA_DB_DECLARE_1(); program.R0573_00_LER_PARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0410_00_LER_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0500_00_LER_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0500_00_LER_RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0573_00_LER_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0575_00_CURSOR_APOLCORRET_DB_DECLARE_1(); program.R0575_00_CURSOR_APOLCORRET_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0800_00_RELACIONAR_BENEFICIA_DB_DECLARE_1(); program.R0800_00_RELACIONAR_BENEFICIA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                program.NUM_APOL_ANT.Value = 80000000017;
                program.R0596_00_UPDATE_PROPOFID_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*23*/ program.R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.Value = "EMT";
                program.NUM_APOL_ANT.Value = 80000000017;
                program.R0599_00_SELECT_PROPOFID_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*25*/ program.R0620_00_DADOS_RG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/
                program.WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR.Value = "2020-01-01";
                program.WAREA_AUXILIAR.WHOST_DATA_REF_M1YEAR.Value = "2021-12-12";
                program.R1120_00_BUSCA_MENOR_DATA_DB_DECLARE_1(); 
                program.R1120_00_BUSCA_MENOR_DATA_DB_OPEN_1(); } 
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*27*/ program.R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/
                program.PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA.Value = 0;
                program.PRODUTOR.DCLPRODUTORES.PRODUTOR_TIPO_PRODUTOR.Value = "3";
                program.R0930_SELECIONAR_PRODUTOR_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*33*/ program.R0935_SELECIONAR_PRODUTOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2021-01-01";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2022-01-01";
                program.R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*35*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2021-01-01";
                program.R1110_00_UPDATE_RELATORIOS_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*36*/ program.R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R3136_RELACIONA_EMAIL_DB_DECLARE_1(); program.R3135_INCLUIR_END_EMAIL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/
                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2021-02-02";
                program.R3105_LER_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R3110_LER_PESSOA_JURIDICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/
                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2000-01-01";
                program.PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.Value = "2021-02-02";
                program.R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*45*/
                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2000-01-01";
                program.PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.Value = "2021-02-02";
                program.R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*46*/ program.R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R3205_RELACIONA_ENDERECO_DB_DECLARE_1(); program.R3201_TRATA_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R3140_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R3141_INCLUIR_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R3155_LER_TAB_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R3165_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R3170_LER_EMAIL_ATUAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R3225_OBTER_MAX_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R3230_INCLUIR_ENDERECO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R3255_LER_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R3265_OBTER_MAX_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R3270_INCLUIR_TELEFONE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R3330_GERA_RELACIONAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = "2022-01-02";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2021-02-02";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.Value = "2023-01-05";
                program.R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*64*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2022-01-01";
                program.R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*65*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2023-02-05";
                program.R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*66*/
                program.BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO.Value = "2000-01-01";
                program.R3400_TRATA_BENEFICIARIOS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*67*/ program.R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}