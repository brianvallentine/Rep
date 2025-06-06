//using System;
//using IA_ConverterCommons;
//using System.Collections.Generic;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using System.Linq;
//using _ = IA_ConverterCommons.Statements;
//using DB = IA_ConverterCommons.DatabaseBasis;
//using Xunit;
//using Copies;
//using Code;
//using static Code.PF0600B;

//namespace FileTests.Test_DB
//{
//    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
//    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
//    public class PF0600B_Tests_DB
//    {

//        [Fact]
//        public static void PF0600B_Database()
//        {
//            var program = new PF0600B();
//            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
//            var pData = "2000-01-01";
//            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*2*/ program.R0110_00_VALIDAR_CONVENIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*3*/ program.R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*4*/ program.R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*5*/ program.R0305_00_LER_PROP_SICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*6*/ program.R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*7*/ program.R0490_00_OBTER_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*8*/ program.R0495_00_INCLUIR_PF_CBO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*9*/
//                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = pData;
//                program.R0505_LER_PESSOA_FISICA_DB_SELECT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*10*/ program.R0510_LER_PESSOA_JURIDICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*11*/ program.R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*12*/ program.R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*13*/
//                program.PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.Value = pData;
//                program.R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*14*/ program.R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*15*/ program.R0536_RELACIONA_EMAIL_DB_DECLARE_1(); program.R0535_INCLUIR_END_EMAIL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*16*/ program.R0605A_RELACIONA_ENDERECO_DB_DECLARE_1(); program.R0605A_RELACIONA_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*17*/ program.R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*18*/ program.R0540_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*19*/ program.R0541_INCLUIR_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*20*/ program.R0555_LER_TAB_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*21*/ program.R05551_CORRIGE_PESSOA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*22*/ program.R0565_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*23*/ program.R0570_LER_EMAIL_ATUAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*24*/ program.R0762_00_OBTER_COMISSAO_DB_DECLARE_1(); program.R0762_00_OBTER_COMISSAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*25*/ program.R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*26*/ program.R0655_LER_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*27*/ program.R0655_LER_TELEFONE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*28*/ program.R0665_OBTER_MAX_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*29*/ program.R0670_INCLUIR_TELEFONE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*30*/ program.R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*31*/
//                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
//                program.R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1(); 
//            } catch (Exception ex) 
//            { _.ThreatableTestError(ex); }

//            try { /*32*/ program.R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*33*/ program.R0730_GERA_RELACIONAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*34*/ program.R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*35*/ program.R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*36*/
//                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = pData;
//                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = pData;
//                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.Value = pData;
//                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = pData;
//                program.R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*37*/ program.R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*38*/
//                program.WHOST_DATA_PROPOSTA.Value = pData;
//                program.R0772A_OBTER_APOLICE_SUBES_DB_DECLARE_1(); 
//                program.R0772A_OBTER_APOLICE_SUBES_DB_OPEN_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*39*/ program.R0763_LER_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*40*/ program.R0764_LER_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*41*/ program.R0764_LER_RCAPCOMP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*42*/
//                program.PFACOPRO.DCLPF_ACOMP_PROPOSTAS.PFACOPRO_DTH_INCLUSAO.Value = pData;
//                program.R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*43*/ program.R0771_10_NEXT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*44*/ program.R6100_00_DECLARE_CBO_DB_DECLARE_1(); program.R6100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*45*/ program.R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*46*/ program.R0772C_OBTER_APOLICE_SUBES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*47*/ program.R0773_GERA_PROP_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*48*/ program.R0773_GERA_PROP_BILHETE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*49*/ program.R0790_GERA_HIST_FIDELIZACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*50*/
//                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = pData;
//                program.R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*51*/ program.R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*52*/ program.R0793_NUMERAR_SICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*53*/ program.R0793_NUMERAR_SICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*54*/
//                program.COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO.Value = pData;
//                program.COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO.Value = pData;
//                program.R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*55*/ program.R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*56*/
//                program.BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO.Value = pData;
//                program.R0810_TRATA_BENEFICIARIO_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*57*/
//                program.WHOST_DTPROXVEN.Value = pData;
//                program.R0860_TRATA_INC_CARTAO_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*58*/ program.R0860_TRATA_INC_CARTAO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*59*/ program.R0862_TRATA_INC_CARTAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*60*/ program.R0865_INCLUIR_FAX_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*61*/ program.R0865_INCLUIR_FAX_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*62*/ program.R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*63*/ program.R0910_TRATA_INF_SICAQWEB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*64*/ program.R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*65*/ program.R0960_INF_PRESTAMISTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*66*/ program.R0971_00_INS_PROP_FIDELIZ_COMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*67*/
//                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = pData;
//                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = pData;
//                program.R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1(); 
//            } catch (Exception ex) { _.ThreatableTestError(ex); }

//            try { /*68*/ program.R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*69*/ program.R2100_00_TB_CONTROLE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*70*/ program.R6200_00_DECLARE_FONTES_DB_DECLARE_1(); program.R6200_00_DECLARE_FONTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*71*/ program.R7000_00_CARREGA_SUBGRUPOS_DB_DECLARE_1(); program.R7000_00_CARREGA_SUBGRUPOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*72*/ program.R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*73*/ program.R7200_00_MOVE_TABELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*74*/ program.R9971_LER_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*75*/ program.R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*76*/ program.R9983_00_LER_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*77*/ program.R9984_00_LER_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
//            try { /*78*/ program.R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

//        }
//    }
//}