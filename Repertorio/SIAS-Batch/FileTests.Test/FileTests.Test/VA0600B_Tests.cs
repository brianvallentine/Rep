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
using static Code.VA0600B;

namespace FileTests.Test
{
    [Collection("VA0600B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0600B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-08-21"}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DESCR_ARQUIVO" , "PROPOSTA CAIXA SEGUROS VIDA EM GRUPO                        "}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_DATA_GERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            for (int i = 0; i < 2000; i++)
            {
                q5.AddDynamic(new Dictionary<string, string>{
                { "VG130_NUM_APOLICE" , "1412"},
                { "VG130_COD_SUBGRUPO" , "10"},
                { "VG130_COD_PRODUTO" , "10"},
            });
            }
            AppSettings.TestSet.DynamicData.Add("R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0352_00_VALIDA_PLANO_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_APOLICE_PLANO" , ""},
                { "WHOST_CODSUBES_PLANO" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0352_00_VALIDA_PLANO_DB_SELECT_2_Query1", q6);

            #endregion

            #region R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_APOLICE_PLANO" , ""},
                { "WHOST_CODSUBES_PLANO" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0354_00_VALIDA_PLANO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0490_00_OBTER_CBO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_DESCR_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0490_00_OBTER_CBO_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PF062_NUM_PROPOSTA_SIVPF" , ""},
                { "PF062_COD_CBO" , ""},
                { "PF062_DES_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CBO" , ""},
                { "COD_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0495_00_INCLUIR_PF_CBO_DB_UPDATE_1_Update1", q10);

            #endregion

            #region R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "TIPO_IDENT_SIVPF" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "COD_CBO" , ""},
                { "COD_USUARIO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ORGAO_EXPEDIDOR" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "ESTADO_CIVIL" , ""},
                { "WHOST_DATA_EXP_RG" , ""},
                { "COD_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CPF" , ""},
                { "DATA_NASCIMENTO" , ""},
                { "SEXO" , ""},
                { "COD_USUARIO" , ""},
                { "ESTADO_CIVIL" , ""},
                { "NUM_IDENTIDADE" , ""},
                { "ORGAO_EXPEDIDOR" , ""},
                { "UF_EXPEDIDORA" , ""},
                { "DATA_EXPEDICAO" , ""},
                { "COD_CBO" , ""},
                { "TIPO_IDENT_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1", q17);

            #endregion

            #region VA0600B_EMAIL

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_EMAIL_COD_PESSOA" , ""},
                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0600B_EMAIL", q18);

            #endregion

            #region VA0600B_ENDERECOS

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , "1"},
                { "DCLPESSOA_ENDERECO_COD_PESSOA" , "1"},
                { "DCLPESSOA_ENDERECO_ENDERECO" , "BARAO DE MESQUITA S/N950950 LOJA A                "},
                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , "1"},
                { "DCLPESSOA_ENDERECO_BAIRRO" , "asd"},
                { "DCLPESSOA_ENDERECO_CEP" , "20540004"},
                { "DCLPESSOA_ENDERECO_CIDADE" , "RIO DE JANEIRO                     "},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , "RJ"},
                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , "A"},
            });
            q19.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , "1"},
                { "DCLPESSOA_ENDERECO_COD_PESSOA" , "1"},
                { "DCLPESSOA_ENDERECO_ENDERECO" , "BARAO DE MESQUITA S/N950950 LOJA A                "},
                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , "1"},
                { "DCLPESSOA_ENDERECO_BAIRRO" , "asd"},
                { "DCLPESSOA_ENDERECO_CEP" , "20540004"},
                { "DCLPESSOA_ENDERECO_CIDADE" , "RIO DE JANEIRO                     "},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , "RJ"},
                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , "A"},
            });
            q19.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , "1"},
                { "DCLPESSOA_ENDERECO_COD_PESSOA" , "1"},
                { "DCLPESSOA_ENDERECO_ENDERECO" , "BARAO DE MESQUITA S/N950950 LOJA A                "},
                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , "1"},
                { "DCLPESSOA_ENDERECO_BAIRRO" , "asd"},
                { "DCLPESSOA_ENDERECO_CEP" , "20540004"},
                { "DCLPESSOA_ENDERECO_CIDADE" , "RIO DE JANEIRO                     "},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , "RJ"},
                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , "A"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0600B_ENDERECOS", q19);

            #endregion

            #region R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q21);

            #endregion

            #region R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1", q22);

            #endregion

            #region R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , "1"},
                { "PESSOA_NOME_PESSOA" , "gu"},
                { "PESSOA_TIPO_PESSOA" , "1"},
                { "PESSOA_TIMESTAMP" , ""},
                { "PESSOA_COD_USUARIO" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1", q23);

            #endregion

            #region R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1", q24);

            #endregion

            #region R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q25);

            #endregion

            #region R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1", q26);

            #endregion

            #region VA0600B_FUNDOCOMISVA

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0600B_FUNDOCOMISVA", q27);

            #endregion

            #region R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "OCORR_ENDERECO" , ""},
                { "ENDERECO" , ""},
                { "TIPO_ENDER" , ""},
                { "BAIRRO" , ""},
                { "CEP" , ""},
                { "CIDADE" , ""},
                { "SIGLA_UF" , ""},
                { "SITUACAO_ENDERECO" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R0655_LER_TELEFONE_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0655_LER_TELEFONE_DB_SELECT_1_Query1", q29);

            #endregion

            #region R0655_LER_TELEFONE_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "TIPO_FONE" , ""},
                { "NUM_FONE" , ""},
                { "DDD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0655_LER_TELEFONE_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1", q31);

            #endregion

            #region R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "TIPO_FONE" , ""},
                { "SEQ_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "01"},
                { "PRDSIVPF_COD_RELAC" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1", q33);

            #endregion

            #region R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1", q34);

            #endregion

            #region R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1", q35);

            #endregion

            #region R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""},
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1", q37);

            #endregion

            #region R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_OPCAOPAG" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPOFID_PERC_DESCONTO" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "OCORR_ENDERECO" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "PROPOFID_NOME_CONVENENTE" , ""},
                { "PROPOFID_NRMATRCON" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_VAL_TARIFA" , ""},
                { "PROPOFID_VAL_IOF" , ""},
                { "PROPOFID_DATA_CREDITO" , ""},
                { "PROPOFID_VAL_COMISSAO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "PROPOFID_FAIXA_RENDA_IND" , ""},
                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
                { "PROPOFID_IND_TP_PROPOSTA" , ""},
                { "PROPOFID_IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q39);

            #endregion

            #region VA0600B_CFONTES

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "DCLFONTES_FONTES_COD_FONTE" , "22"},
                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "14185"},
            });
            q40.AddDynamic(new Dictionary<string, string>{
                { "DCLFONTES_FONTES_COD_FONTE" , "1"},
                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "950013065"},
            });
            q40.AddDynamic(new Dictionary<string, string>{
                { "DCLFONTES_FONTES_COD_FONTE" , "2"},
                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "9206804"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0600B_CFONTES", q40);

            #endregion

            #region R0763_LER_RCAP_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0763_LER_RCAP_DB_SELECT_1_Query1", q41);

            #endregion

            #region R0764_LER_RCAPCOMP_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0764_LER_RCAPCOMP_DB_SELECT_1_Query1", q42);

            #endregion

            #region R0764_LER_RCAPCOMP_DB_SELECT_2_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0764_LER_RCAPCOMP_DB_SELECT_2_Query1", q43);

            #endregion

            #region R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PFACOPRO_DTH_INCLUSAO" , ""},
                { "PFACOPRO_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R77100_10_NEXT_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_IDENTIFICACAO" , ""},
                { "PROPSSVD_DPS_TITULAR" , ""},
                { "PROPSSVD_DPS_CONJUGE" , ""},
                { "PROPSSVD_APOS_INVALIDEZ" , ""},
                { "PROPSSVD_COD_USUARIO" , ""},
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
                { "PROPSSVD_COD_CORRESP_BANC" , ""},
                { "PROPSSVD_NUM_PRAZO_FIN" , ""},
                { "PROPSSVD_COD_OPER_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R77100_10_NEXT_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "VG130_NUM_APOLICE" , ""},
                { "VG130_COD_SUBGRUPO" , ""},
                { "VG130_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R77210_00_OBTER_APO_SUB_VG130_DB_SELECT_1_Query1", q46);

            #endregion

            #region R77230_00_PESQ_PLANOS_DB_SELECT_1_Query1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "WHOST_APOLICE_PLANO" , ""},
                { "WHOST_CODSUBES_PLANO" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R77230_00_PESQ_PLANOS_DB_SELECT_1_Query1", q47);

            #endregion

            #region R77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "GE406_COD_IDE_CONSULTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R77233_00_INS_GE_RETENCAO_PROP_DB_SEQUENCE_1_Query1", q48);

            #endregion

            #region R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "GE406_NUM_CERTIFICADO" , ""},
                { "GE406_NUM_CPF" , ""},
                { "GE406_COD_IDE_CONSULTA" , ""},
                { "GE406_IND_SERV_CONSULTA" , ""},
                { "GE406_IND_PROCESSAMENTO" , ""},
                { "GE406_COD_USUARIO" , ""},
                { "GE406_IND_RET_SUBSCRICAO" , ""},
                { "GE406_PCT_AGRAVO" , ""},
                { "GE406_VLR_PRM_SEM_AGR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1", q49);

            #endregion

            #region R0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "GETPMOIM_DES_TP_MORA_IMOVEL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1", q50);

            #endregion

            #region R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "PROPSSBI_NUM_IDENTIFICACAO" , ""},
                { "PROPSSBI_RENOVACAO_AUTOM" , ""},
                { "PROPSSBI_COD_USUARIO" , ""},
                { "PROPSSBI_NUM_TP_MORA_IMOVEL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1", q51);

            #endregion

            #region R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "NUM_SICOB" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1", q52);

            #endregion

            #region R0793_NUMERAR_SICOB_DB_SELECT_1_Query1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_NUM_TITULO_MAX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0793_NUMERAR_SICOB_DB_SELECT_1_Query1", q53);

            #endregion

            #region R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "CEDENTE_NUM_TITULO" , ""},
                { "CEDENTE_COD_CEDENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1", q54);

            #endregion

            #region R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_SICOB" , ""},
                { "COD_EMPRESA_SIVPF" , ""},
                { "PRODUTO_SIVPF" , ""},
                { "AGEPGTO" , ""},
                { "DATA_OPERACAO" , ""},
                { "DATA_QUITACAO" , ""},
                { "VAL_RCAP" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1", q55);

            #endregion

            #region R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1", q56);

            #endregion

            #region R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_AZUL" , ""},
                { "COD_AGENCIA_LOTE" , ""},
                { "DATA_LOTE" , ""},
                { "NUM_LOTE" , ""},
                { "NUM_SEQ_LOTE" , ""},
                { "NUM_BENEFICIARIO" , ""},
                { "NOME_BENEFICIARIO" , ""},
                { "GRAU_PARENTESCO" , ""},
                { "PCT_PART_BENEFICIA" , ""},
                { "DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1", q57);

            #endregion

            #region R0865_INCLUIR_FAX_DB_SELECT_1_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0865_INCLUIR_FAX_DB_SELECT_1_Query1", q58);

            #endregion

            #region R0865_INCLUIR_FAX_DB_INSERT_1_Insert1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "TIPO_FONE" , ""},
                { "SEQ_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0865_INCLUIR_FAX_DB_INSERT_1_Insert1", q59);

            #endregion

            #region R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
                { "PROFIDCO_INFORMACAO_COMPL" , ""},
                { "PROFIDCO_COD_USUARIO" , ""},
                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1", q60);

            #endregion

            #region R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
                { "PROFIDCO_INFORMACAO_COMPL" , ""},
                { "PROFIDCO_COD_USUARIO" , ""},
                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1", q61);

            #endregion

            #region R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
                { "PROFIDCO_INFORMACAO_COMPL" , ""},
                { "PROFIDCO_COD_USUARIO" , ""},
                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1", q62);

            #endregion

            #region R0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1_Insert1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
                { "PROFIDCO_INFORMACAO_COMPL" , ""},
                { "PROFIDCO_COD_USUARIO" , ""},
                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0952_INF_EMPRESA_PEXECUTIVA_DB_INSERT_1_Insert1", q63);

            #endregion

            #region R0960_INF_PRESTAMISTA_DB_SELECT_1_Query1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "GE372_COD_OPER_CREDITO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0960_INF_PRESTAMISTA_DB_SELECT_1_Query1", q64);

            #endregion

            #region R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1", q65);

            #endregion

            #region R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1", q66);

            #endregion

            #region R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1

            var q67 = new DynamicData();
            q67.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1", q67);

            #endregion

            #region R8230_00_PLANO_SEM_DATA_DB_SELECT_1_Query1

            var q68 = new DynamicData();
            q68.AddDynamic(new Dictionary<string, string>{
                { "WHOST_APOLICE_PLANO" , ""},
                { "WHOST_CODSUBES_PLANO" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8230_00_PLANO_SEM_DATA_DB_SELECT_1_Query1", q68);

            #endregion

            #region R8240_00_PLANO_SEM_PREMIO_DB_SELECT_1_Query1

            var q69 = new DynamicData();
            q69.AddDynamic(new Dictionary<string, string>{
                { "WHOST_APOLICE_PLANO" , ""},
                { "WHOST_CODSUBES_PLANO" , ""},
                { "PLAVAVGA_VLPREMIOTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8240_00_PLANO_SEM_PREMIO_DB_SELECT_1_Query1", q69);

            #endregion

            #region R9971_LER_RCAP_DB_SELECT_1_Query1

            var q70 = new DynamicData();
            q70.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9971_LER_RCAP_DB_SELECT_1_Query1", q70);

            #endregion

            #region R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1

            var q71 = new DynamicData();
            q71.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_DATA_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1", q71);

            #endregion

            #region R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1

            var q72 = new DynamicData();
            q72.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_SIT_REGISTRO" , "2"}
            });
            AppSettings.TestSet.DynamicData.Add("R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1", q72);

            #endregion

            #region R9984_00_LER_BILHETE_DB_SELECT_1_Query1

            var q73 = new DynamicData();
            q73.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R9984_00_LER_BILHETE_DB_SELECT_1_Query1", q73);

            #endregion

            #region R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1

            var q74 = new DynamicData();
            q74.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_DATA_CREDITO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1", q74);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("PRD.PF.D240805.PF0110B.ARQVG", "MOV_VDEMP_FILE_NAME_P", "RVA0600B_FILE_NAME_P")]
        public static void VA0600B_Tests_Theory(string MOV_SIGAT_FILE_NAME_P, string MOV_VDEMP_FILE_NAME_P, string RVA0600B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV_VDEMP_FILE_NAME_P = $"{MOV_VDEMP_FILE_NAME_P}_{timestamp}.txt";
            RVA0600B_FILE_NAME_P = $"{RVA0600B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1", q2);

                #endregion

                #region GEJVS002_GE074_CURSOR

                var q110 = new DynamicData();
                q110.AddDynamic(new Dictionary<string, string>{
                { "PARAMGER_DATA_INIVIGENCIA" , ""},
                { "PARAMGER_DATA_TERVIGENCIA" , ""},
                { "PARAMGER_COD_MOEDA" , ""},
                { "PARAMGER_COD_BANCO" , ""},
                { "PARAMGER_COD_AGENCIA" , ""},
                { "PARAMGER_OPCAO_BANCO" , ""},
                { "PARAMGER_DIF_PREMIOS" , ""},
                { "PARAMGER_FAIXA_APOL_MANUAL" , ""},
                { "PARAMGER_FAIXA_ENDOSCOB_MAN" , ""},
                { "PARAMGER_DATA_FATURAVG_AUT" , ""},
                { "PARAMGER_CAPITAL_SOCIAL" , ""},
                { "PARAMGER_CAPITAL_REALIZADO" , ""},
                { "PARAMGER_CAPITAL_VINCULADO" , ""},
                { "PARAMGER_ULT_AVISO_CREDITO" , ""},
                { "PARAMGER_CODIGO_LIDER" , "123"},
                { "PARAMGER_NUM_RELACAO" , ""},
                { "PARAMGER_COD_EMPRESA" , ""},
                { "PARAMGER_COD_CGCCPF" , ""},
                { "PARAMGER_COD_EMPRESA_CAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q110);

                #endregion
                #endregion
                var program = new VA0600B();
                program.Execute(MOV_SIGAT_FILE_NAME_P, MOV_VDEMP_FILE_NAME_P, RVA0600B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                var envList0 = AppSettings.TestSet.DynamicData["R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0507_CORRIGE_PESSOA_FISICA_DB_UPDATE_1_Update1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1"].DynamicList;
                var envList5 = AppSettings.TestSet.DynamicData["R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R0655_LER_TELEFONE_DB_UPDATE_1_Update1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1"].DynamicList;
                var envList8 = AppSettings.TestSet.DynamicData["R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1"].DynamicList;
                var envList9 = AppSettings.TestSet.DynamicData["R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
                var envList10 = AppSettings.TestSet.DynamicData["R77100_10_NEXT_DB_INSERT_1_Insert1"].DynamicList;
                var envList11 = AppSettings.TestSet.DynamicData["R77233_00_INS_GE_RETENCAO_PROP_DB_INSERT_1_Insert1"].DynamicList;
                var envList12 = AppSettings.TestSet.DynamicData["R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1"].DynamicList;
                var envList13 = AppSettings.TestSet.DynamicData["R0865_INCLUIR_FAX_DB_INSERT_1_Insert1"].DynamicList;
                var envList14 = AppSettings.TestSet.DynamicData["R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList0?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList5?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);
                Assert.True(envList8?.Count > 1);
                Assert.True(envList9?.Count > 1);
                Assert.True(envList10?.Count > 1);
                Assert.True(envList11?.Count > 1);
                Assert.True(envList12?.Count > 1);
                Assert.True(envList13?.Count > 1);


                Assert.True(envList0[1].TryGetValue("PF062_NUM_PROPOSTA_SIVPF", out var PF062_NUM_PROPOSTA_SIVPF) && PF062_NUM_PROPOSTA_SIVPF == "082083130322441");
                Assert.True(envList1[1].TryGetValue("ORGAO_EXPEDIDOR", out var ORGAO_EXPEDIDOR) && ORGAO_EXPEDIDOR.Contains("SSP"));
                Assert.True(envList2[1].TryGetValue("PESSOA_COD_PESSOA", out var PESSOA_COD_PESSOA) && PESSOA_COD_PESSOA == "000000002");
                Assert.True(envList3[1].TryGetValue("COD_PESSOA", out var COD_PESSOA) && COD_PESSOA == "000000002");
                Assert.True(envList4[1].TryGetValue("COD_PESSOA", out var COD_PESSOA1) && COD_PESSOA1 == "000000002");
                Assert.True(envList5[1].TryGetValue("ENDERECO", out var ENDERECO) && ENDERECO.Contains("OPTAIDES MARIO DE AGUIAR 134"));
                Assert.True(envList6[1].TryGetValue("COD_PESSOA", out var COD_PESSOA2) && COD_PESSOA2 == "000000002");
                Assert.True(envList7[1].TryGetValue("COD_PESSOA", out var COD_PESSOA3) && COD_PESSOA3 == "000000002");
                Assert.True(envList8[1].TryGetValue("COD_PESSOA", out var COD_PESSOA4) && COD_PESSOA4 == "000000000");
                Assert.True(envList9[1].TryGetValue("PROPOFID_COD_PESSOA", out var PROPOFID_COD_PESSOA) && PROPOFID_COD_PESSOA == "000000002");
                Assert.True(envList10[1].TryGetValue("PROPSSVD_COD_USUARIO", out var PROPSSVD_COD_USUARIO) && PROPSSVD_COD_USUARIO == "VA0600B ");
                Assert.True(envList11[1].TryGetValue("GE406_NUM_CERTIFICADO", out var GE406_NUM_CERTIFICADO) && GE406_NUM_CERTIFICADO == "082083130322441");
                Assert.True(envList12[1].TryGetValue("NOME_BENEFICIARIO", out var NOME_BENEFICIARIO) && NOME_BENEFICIARIO.Contains("MARIA EDUARDA MONTEVERDE FIGUEIRA"));
                Assert.True(envList13[1].TryGetValue("COD_PESSOA", out var COD_PESSOA5) && COD_PESSOA5 == "000000002");
                Assert.True(envList14[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var ARQSIVPF_SIGLA_ARQUIVO) && ARQSIVPF_SIGLA_ARQUIVO.Contains("PRPVG"));



                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("PRD.PF.D240805.PF0110B.ARQVG_LIMITED", "MOV_VDEMP_FILE_NAME_P", "RVA0600B_FILE_NAME_P")]
        public static void VA0600B_Tests_TheoryErro(string MOV_SIGAT_FILE_NAME_P, string MOV_VDEMP_FILE_NAME_P, string RVA0600B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV_VDEMP_FILE_NAME_P = $"{MOV_VDEMP_FILE_NAME_P}_{timestamp}.txt";
            RVA0600B_FILE_NAME_P = $"{RVA0600B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                 q2.AddDynamic(new Dictionary<string, string>{
                    { "ARQSIVPF_DATA_GERACAO" , "2017-10-03"}
                 });
                AppSettings.TestSet.DynamicData.Remove("R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                var program = new VA0600B();
                program.Execute(MOV_SIGAT_FILE_NAME_P, MOV_VDEMP_FILE_NAME_P, RVA0600B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

                Assert.True(true);
            }
        }
    }
}