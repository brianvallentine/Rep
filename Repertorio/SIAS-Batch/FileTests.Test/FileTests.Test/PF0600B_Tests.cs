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

//namespace FileTests.Test
//{
//    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
//    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
//    public class PF0600B_Tests
//    {
//        //é de extrema importancia que este método seja modificado com cautela, 
//        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
//        public static void Load_Parameters()
//        {
//            #region PARAMETERS
//            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

//            var q0 = new DynamicData();
//            q0.AddDynamic(new Dictionary<string, string>{
//                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

//            #endregion

//            #region R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1

//            var q1 = new DynamicData();
//            q1.AddDynamic(new Dictionary<string, string>{
//                { "DESCR_ARQUIVO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1", q1);

//            #endregion

//            #region R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1

//            var q2 = new DynamicData();
//            q2.AddDynamic(new Dictionary<string, string>{
//                { "ARQSIVPF_DATA_GERACAO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0115_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1", q2);

//            #endregion

//            #region R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1

//            var q3 = new DynamicData();
//            q3.AddDynamic(new Dictionary<string, string>{
//                { "ARQSIVPF_NSAS_SIVPF" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1", q3);

//            #endregion

//            #region R0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1

//            var q4 = new DynamicData();
//            q4.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_SIT_PROPOSTA" , "AGE"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0305_00_LER_PROP_SICOB_DB_SELECT_1_Query1", q4);

//            #endregion

//            #region R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1

//            var q5 = new DynamicData();
//            q5.AddDynamic(new Dictionary<string, string>{
//                { "ARQSIVPF_NSAS_SIVPF" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1", q5);

//            #endregion

//            #region R0490_00_OBTER_CBO_DB_SELECT_1_Query1

//            var q6 = new DynamicData();
//            q6.AddDynamic(new Dictionary<string, string>{
//                { "CBO_DESCR_CBO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0490_00_OBTER_CBO_DB_SELECT_1_Query1", q6);

//            #endregion

//            #region R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1

//            var q7 = new DynamicData();
//            q7.AddDynamic(new Dictionary<string, string>{
//                { "PF062_NUM_PROPOSTA_SIVPF" , ""},
//                { "PF062_COD_CBO" , ""},
//                { "PF062_DES_CBO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1", q7);

//            #endregion

//            #region R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1

//            var q8 = new DynamicData();
//            q8.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "CPF" , ""},
//                { "DATA_NASCIMENTO" , ""},
//                { "SEXO" , ""},
//                { "TIPO_IDENT_SIVPF" , ""},
//                { "NUM_IDENTIDADE" , ""},
//                { "ORGAO_EXPEDIDOR" , ""},
//                { "UF_EXPEDIDORA" , ""},
//                { "DATA_EXPEDICAO" , ""},
//                { "COD_CBO" , ""},
//                { "COD_USUARIO" , ""},
//                { "ESTADO_CIVIL" , ""},
//                { "TIMESTAMP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1", q8);

//            #endregion

//            #region R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

//            var q9 = new DynamicData();
//            q9.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "CGC" , ""},
//                { "NOME_FANTASIA" , ""},
//                { "COD_USUARIO" , ""},
//                { "TIMESTAMP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q9);

//            #endregion

//            #region R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1

//            var q10 = new DynamicData();
//            q10.AddDynamic(new Dictionary<string, string>{
//                { "PESSOA_COD_PESSOA" , ""},
//                { "PESSOA_NOME_PESSOA" , ""},
//                { "PESSOA_COD_USUARIO" , ""},
//                { "PESSOA_TIPO_PESSOA" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1", q10);

//            #endregion

//            #region R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1

//            var q11 = new DynamicData();
//            q11.AddDynamic(new Dictionary<string, string>{
//                { "PESSOA_COD_PESSOA" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1", q11);

//            #endregion

//            #region R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1

//            var q12 = new DynamicData();
//            q12.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "CPF" , ""},
//                { "DATA_NASCIMENTO" , ""},
//                { "SEXO" , ""},
//                { "COD_USUARIO" , ""},
//                { "ESTADO_CIVIL" , ""},
//                { "NUM_IDENTIDADE" , ""},
//                { "ORGAO_EXPEDIDOR" , ""},
//                { "UF_EXPEDIDORA" , ""},
//                { "DATA_EXPEDICAO" , ""},
//                { "COD_CBO" , ""},
//                { "TIPO_IDENT_SIVPF" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1", q12);

//            #endregion

//            #region R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1

//            var q13 = new DynamicData();
//            q13.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "CGC" , ""},
//                { "NOME_FANTASIA" , ""},
//                { "COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1", q13);

//            #endregion

//            #region PF0600B_EMAIL

//            var q14 = new DynamicData();
//            q14.AddDynamic(new Dictionary<string, string>{
//                { "DCLPESSOA_EMAIL_COD_PESSOA" , "1"},
//                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , "1"},
//                { "DCLPESSOA_EMAIL_EMAIL" , "info@teste.com.br"},
//                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , "A"},
//            });
//            q14.AddDynamic(new Dictionary<string, string>{
//                { "DCLPESSOA_EMAIL_COD_PESSOA" , "1"},
//                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , "1"},
//                { "DCLPESSOA_EMAIL_EMAIL" , "teste@info.com.br"},
//                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , "A"},
//            });
//            q14.AddDynamic(new Dictionary<string, string>{
//                { "DCLPESSOA_EMAIL_COD_PESSOA" , "1"},
//                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , "1"},
//                { "DCLPESSOA_EMAIL_EMAIL" , "teste@info.com.br"},
//                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , "A"},
//            });
//            q14.AddDynamic(new Dictionary<string, string>{
//                { "DCLPESSOA_EMAIL_COD_PESSOA" , "1"},
//                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , "1"},
//                { "DCLPESSOA_EMAIL_EMAIL" , "teste@info.com.br"},
//                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , "A"},
//            });
//            AppSettings.TestSet.DynamicData.Add("PF0600B_EMAIL", q14);

//            #endregion

//            #region PF0600B_ENDERECOS

//            var q15 = new DynamicData();
//            q15.AddDynamic(new Dictionary<string, string>{
//                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
//                { "DCLPESSOA_ENDERECO_COD_PESSOA" , "1"},
//                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
//                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , ""},
//                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
//                { "DCLPESSOA_ENDERECO_CEP" , ""},
//                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
//                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
//                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , ""},
//            });
//            q15.AddDynamic(new Dictionary<string, string>{
//                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
//                { "DCLPESSOA_ENDERECO_COD_PESSOA" , "2"},
//                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
//                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , ""},
//                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
//                { "DCLPESSOA_ENDERECO_CEP" , ""},
//                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
//                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
//                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , ""},
//            });
//            q15.AddDynamic(new Dictionary<string, string>{
//                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
//                { "DCLPESSOA_ENDERECO_COD_PESSOA" , "3"},
//                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
//                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , ""},
//                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
//                { "DCLPESSOA_ENDERECO_CEP" , ""},
//                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
//                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
//                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("PF0600B_ENDERECOS", q15);

//            #endregion

//            #region R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1

//            var q16 = new DynamicData();
//            q16.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "EMAIL" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0538_VERIFICA_EXISTE_EMAIL_DB_UPDATE_1_Update1", q16);

//            #endregion

//            #region R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

//            var q17 = new DynamicData();
//            q17.AddDynamic(new Dictionary<string, string>{
//                { "SEQ_EMAIL" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q17);

//            #endregion

//            #region R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1

//            var q18 = new DynamicData();
//            q18.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "SEQ_EMAIL" , ""},
//                { "EMAIL" , ""},
//                { "SITUACAO_EMAIL" , ""},
//                { "COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1", q18);

//            #endregion

//            #region R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1

//            var q19 = new DynamicData();
//            q19.AddDynamic(new Dictionary<string, string>{
//                { "PESSOA_COD_PESSOA" , ""},
//                { "PESSOA_NOME_PESSOA" , ""},
//                { "PESSOA_TIPO_PESSOA" , ""},
//                { "PESSOA_TIMESTAMP" , ""},
//                { "PESSOA_COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1", q19);

//            #endregion

//            #region R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1

//            var q20 = new DynamicData();
//            q20.AddDynamic(new Dictionary<string, string>{
//                { "PESSOA_NOME_PESSOA" , ""},
//                { "PESSOA_COD_PESSOA" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1", q20);

//            #endregion

//            #region R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

//            var q21 = new DynamicData();
//            q21.AddDynamic(new Dictionary<string, string>{
//                { "SEQ_EMAIL" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q21);

//            #endregion

//            #region R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1

//            var q22 = new DynamicData();
//            q22.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "SEQ_EMAIL" , ""},
//                { "EMAIL" , ""},
//                { "SITUACAO_EMAIL" , ""},
//                { "COD_USUARIO" , ""},
//                { "TIMESTAMP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1", q22);

//            #endregion

//            #region PF0600B_FUNDOCOMISVA

//            var q23 = new DynamicData();
//            q23.AddDynamic(new Dictionary<string, string>{
//                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , ""},
//                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , ""},
//                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("PF0600B_FUNDOCOMISVA", q23);

//            #endregion

//            #region R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1

//            var q24 = new DynamicData();
//            q24.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "OCORR_ENDERECO" , ""},
//                { "ENDERECO" , ""},
//                { "TIPO_ENDER" , ""},
//                { "BAIRRO" , ""},
//                { "CEP" , ""},
//                { "CIDADE" , ""},
//                { "SIGLA_UF" , ""},
//                { "SITUACAO_ENDERECO" , ""},
//                { "COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1", q24);

//            #endregion

//            #region R0655_LER_TELEFONE_DB_SELECT_1_Query1

//            var q25 = new DynamicData();
//            q25.AddDynamic(new Dictionary<string, string>{
//                { "SITUACAO_FONE" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0655_LER_TELEFONE_DB_SELECT_1_Query1", q25);

//            #endregion

//            #region R0655_LER_TELEFONE_DB_UPDATE_1_Update1

//            var q26 = new DynamicData();
//            q26.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "TIPO_FONE" , ""},
//                { "NUM_FONE" , ""},
//                { "DDD" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0655_LER_TELEFONE_DB_UPDATE_1_Update1", q26);

//            #endregion

//            #region R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1

//            var q27 = new DynamicData();
//            q27.AddDynamic(new Dictionary<string, string>{
//                { "SEQ_FONE" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1", q27);

//            #endregion

//            #region R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1

//            var q28 = new DynamicData();
//            q28.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "TIPO_FONE" , ""},
//                { "SEQ_FONE" , ""},
//                { "DDI" , ""},
//                { "DDD" , ""},
//                { "NUM_FONE" , ""},
//                { "SITUACAO_FONE" , ""},
//                { "COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1", q28);

//            #endregion

//            #region R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1

//            var q29 = new DynamicData();
//            q29.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0705_CONSULTA_COD_PRODUTO_DB_SELECT_1_Query1", q29);

//            #endregion

//            #region R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1

//            var q30 = new DynamicData();
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "1"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            q30.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_PRODUTO_SIVPF" , "3"},
//                { "PRDSIVPF_COD_RELAC" , "1"},
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1", q30);

//            #endregion

//            #region R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1

//            var q31 = new DynamicData();
//            q31.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "COD_RELAC" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1", q31);

//            #endregion

//            #region R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1

//            var q32 = new DynamicData();
//            q32.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "COD_RELAC" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1", q32);

//            #endregion

//            #region R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1

//            var q33 = new DynamicData();
//            q33.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , ""},
//                { "COD_PESSOA" , ""},
//                { "COD_RELAC" , ""},
//                { "COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1", q33);

//            #endregion

//            #region R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1

//            var q34 = new DynamicData();
//            q34.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , "12"}
//            });
//            q34.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , "13"}
//            });
//            q34.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , "31"}
//            });
//            q34.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , "22"}
//            });
//            q34.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , ""}
//            });
//            q34.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , "21"}
//            });
//            q34.AddDynamic(new Dictionary<string, string>{
//                { "NUM_IDENTIFICACAO" , "4"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1", q34);

//            #endregion

//            #region R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1

//            var q35 = new DynamicData();
//            q35.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
//                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
//                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
//                { "PROPOFID_COD_PESSOA" , ""},
//                { "PROPOFID_NUM_SICOB" , ""},
//                { "PROPOFID_DATA_PROPOSTA" , ""},
//                { "PROPOFID_COD_PRODUTO_SIVPF" , "77"},
//                { "PROPOFID_AGECOBR" , ""},
//                { "PROPOFID_DIA_DEBITO" , ""},
//                { "PROPOFID_OPCAOPAG" , ""},
//                { "PROPOFID_AGECTADEB" , ""},
//                { "PROPOFID_OPRCTADEB" , ""},
//                { "PROPOFID_NUMCTADEB" , ""},
//                { "PROPOFID_DIGCTADEB" , ""},
//                { "PROPOFID_PERC_DESCONTO" , ""},
//                { "PROPOFID_NRMATRVEN" , ""},
//                { "PROPOFID_AGECTAVEN" , ""},
//                { "PROPOFID_OPRCTAVEN" , ""},
//                { "PROPOFID_NUMCTAVEN" , ""},
//                { "PROPOFID_DIGCTAVEN" , ""},
//                { "PROPOFID_CGC_CONVENENTE" , ""},
//                { "PROPOFID_NOME_CONVENENTE" , ""},
//                { "PROPOFID_NRMATRCON" , ""},
//                { "PROPOFID_DTQITBCO" , ""},
//                { "PROPOFID_VAL_PAGO" , ""},
//                { "PROPOFID_AGEPGTO" , ""},
//                { "PROPOFID_VAL_TARIFA" , ""},
//                { "PROPOFID_VAL_IOF" , ""},
//                { "PROPOFID_DATA_CREDITO" , ""},
//                { "PROPOFID_VAL_COMISSAO" , ""},
//                { "PROPOFID_SIT_PROPOSTA" , ""},
//                { "PROPOFID_COD_USUARIO" , ""},
//                { "PROPOFID_CANAL_PROPOSTA" , ""},
//                { "PROPOFID_NSAS_SIVPF" , ""},
//                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
//                { "PROPOFID_NSL" , ""},
//                { "PROPOFID_NSAC_SIVPF" , ""},
//                { "PROPOFID_SITUACAO_ENVIO" , ""},
//                { "PROPOFID_OPCAO_COBER" , ""},
//                { "PROPOFID_COD_PLANO" , ""},
//                { "PROPOFID_NOME_CONJUGE" , ""},
//                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
//                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
//                { "PROPOFID_FAIXA_RENDA_IND" , ""},
//                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
//                { "PROPOFID_IND_TIPO_CONTA" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1", q35);

//            #endregion

//            #region R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

//            var q36 = new DynamicData();
//            q36.AddDynamic(new Dictionary<string, string>{
//                { "VAL_TARIFA" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q36);

//            #endregion

//            #region PF0600B_C_PRODUTO

//            var q37 = new DynamicData();
//            q37.AddDynamic(new Dictionary<string, string>{
//                { "PRODUVG_NUM_APOLICE" , ""},
//                { "PRODUVG_COD_SUBGRUPO" , ""},
//                { "PRODUVG_COD_PRODUTO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("PF0600B_C_PRODUTO", q37);

//            #endregion

//            #region R0763_LER_RCAP_DB_SELECT_1_Query1

//            var q38 = new DynamicData();
//            q38.AddDynamic(new Dictionary<string, string>{
//                { "RCAPS_COD_FONTE" , ""},
//                { "RCAPS_NUM_RCAP" , ""},
//                { "RCAPS_VAL_RCAP" , ""},
//                { "RCAPS_AGE_COBRANCA" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0763_LER_RCAP_DB_SELECT_1_Query1", q38);

//            #endregion

//            #region R0764_LER_RCAPCOMP_DB_SELECT_1_Query1

//            var q39 = new DynamicData();
//            q39.AddDynamic(new Dictionary<string, string>{
//                { "RCAPCOMP_BCO_AVISO" , ""},
//                { "RCAPCOMP_AGE_AVISO" , ""},
//                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
//                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
//                { "RCAPCOMP_DATA_RCAP" , ""},
//                { "RCAPCOMP_VAL_RCAP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0764_LER_RCAPCOMP_DB_SELECT_1_Query1", q39);

//            #endregion

//            #region R0764_LER_RCAPCOMP_DB_SELECT_2_Query1

//            var q40 = new DynamicData();
//            q40.AddDynamic(new Dictionary<string, string>{
//                { "RCAPCOMP_BCO_AVISO" , ""},
//                { "RCAPCOMP_AGE_AVISO" , ""},
//                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
//                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
//                { "RCAPCOMP_DATA_RCAP" , ""},
//                { "RCAPCOMP_VAL_RCAP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0764_LER_RCAPCOMP_DB_SELECT_2_Query1", q40);

//            #endregion

//            #region R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1

//            var q41 = new DynamicData();
//            q41.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
//                { "PFACOPRO_DTH_INCLUSAO" , ""},
//                { "PFACOPRO_COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1", q41);

//            #endregion

//            #region R0771_10_NEXT_DB_INSERT_1_Insert1

//            var q42 = new DynamicData();
//            q42.AddDynamic(new Dictionary<string, string>{
//                { "PROPSSVD_NUM_IDENTIFICACAO" , ""},
//                { "PROPSSVD_DPS_TITULAR" , ""},
//                { "PROPSSVD_DPS_CONJUGE" , ""},
//                { "PROPSSVD_APOS_INVALIDEZ" , ""},
//                { "PROPSSVD_COD_USUARIO" , ""},
//                { "PROPSSVD_NUM_APOLICE" , ""},
//                { "PROPSSVD_COD_SUBGRUPO" , ""},
//                { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
//                { "PROPSSVD_COD_CORRESP_BANC" , ""},
//                { "PROPSSVD_NUM_PRAZO_FIN" , ""},
//                { "PROPSSVD_COD_OPER_CREDITO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0771_10_NEXT_DB_INSERT_1_Insert1", q42);

//            #endregion

//            #region PF0600B_CCBO

//            var q43 = new DynamicData();
//            q43.AddDynamic(new Dictionary<string, string>{
//                { "DCLCBO_CBO_COD_CBO" , ""},
//                { "DCLCBO_CBO_DESCR_CBO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("PF0600B_CCBO", q43);

//            #endregion

//            #region R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1

//            var q44 = new DynamicData();
//            q44.AddDynamic(new Dictionary<string, string>{
//                { "PRODUVG_NUM_APOLICE" , ""},
//                { "PRODUVG_COD_SUBGRUPO" , ""},
//                { "PRODUVG_COD_PRODUTO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0772B_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1", q44);

//            #endregion

//            #region R0772C_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1

//            var q45 = new DynamicData();
//            q45.AddDynamic(new Dictionary<string, string>{
//                { "PRODUVG_NUM_APOLICE" , ""},
//                { "PRODUVG_COD_SUBGRUPO" , ""},
//                { "PRODUVG_COD_PRODUTO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0772C_OBTER_APOLICE_SUBES_DB_SELECT_1_Query1", q45);

//            #endregion

//            #region R0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1

//            var q46 = new DynamicData();
//            q46.AddDynamic(new Dictionary<string, string>{
//                { "GETPMOIM_DES_TP_MORA_IMOVEL" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0773_GERA_PROP_BILHETE_DB_SELECT_1_Query1", q46);

//            #endregion

//            #region R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1

//            var q47 = new DynamicData();
//            q47.AddDynamic(new Dictionary<string, string>{
//                { "PROPSSBI_NUM_IDENTIFICACAO" , ""},
//                { "PROPSSBI_RENOVACAO_AUTOM" , ""},
//                { "PROPSSBI_COD_USUARIO" , ""},
//                { "PROPSSBI_NUM_TP_MORA_IMOVEL" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1", q47);

//            #endregion

//            #region R0790_GERA_HIST_FIDELIZACAO_DB_SELECT_1_Query1

//            var q48 = new DynamicData();
//            q48.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "1"}
//            });
//            q48.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "2"}
//            });
//            q48.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "3"}
//            });
//            q48.AddDynamic(new Dictionary<string, string>{
//                { "PRDSIVPF_COD_EMPRESA_SIVPF" , "4"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0790_GERA_HIST_FIDELIZACAO_DB_SELECT_1_Query1", q48);

//            #endregion

//            #region R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

//            var q49 = new DynamicData();
//            q49.AddDynamic(new Dictionary<string, string>{
//                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
//                { "PROPFIDH_DATA_SITUACAO" , ""},
//                { "PROPFIDH_NSAS_SIVPF" , ""},
//                { "PROPFIDH_NSL" , ""},
//                { "PROPFIDH_SIT_PROPOSTA" , ""},
//                { "PROPFIDH_SIT_COBRANCA_SIVPF" , ""},
//                { "PROPFIDH_SIT_MOTIVO_SIVPF" , ""},
//                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
//                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q49);

//            #endregion

//            #region R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1

//            var q50 = new DynamicData();
//            q50.AddDynamic(new Dictionary<string, string>{
//                { "NUM_SICOB" , ""},
//                { "DATA_OPERACAO" , ""},
//                { "DATA_QUITACAO" , ""},
//                { "VAL_RCAP" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1", q50);

//            #endregion

//            #region R0793_NUMERAR_SICOB_DB_SELECT_1_Query1

//            var q51 = new DynamicData();
//            //q51.AddDynamic(new Dictionary<string, string>{
//            //    { "CEDENTE_NUM_TITULO" ,   "1000"},
//            //    { "CEDENTE_NUM_TITULO_MAX" , "2000"},
//            //});
//            q51.AddDynamic(new Dictionary<string, string>{
//                { "CEDENTE_NUM_TITULO" ,   "95322401400"},
//                { "CEDENTE_NUM_TITULO_MAX" , "95322401410"},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0793_NUMERAR_SICOB_DB_SELECT_1_Query1", q51);

//            #endregion

//            #region R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1

//            var q52 = new DynamicData();
//            q52.AddDynamic(new Dictionary<string, string>{
//                { "CEDENTE_NUM_TITULO" , ""},
//                { "CEDENTE_COD_CEDENTE" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1", q52);

//            #endregion

//            #region R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1

//            var q53 = new DynamicData();
//            q53.AddDynamic(new Dictionary<string, string>{
//                { "NUM_PROPOSTA_SIVPF" , ""},
//                { "NUM_SICOB" , ""},
//                { "COD_EMPRESA_SIVPF" , ""},
//                { "PRODUTO_SIVPF" , ""},
//                { "AGEPGTO" , ""},
//                { "DATA_OPERACAO" , ""},
//                { "DATA_QUITACAO" , ""},
//                { "VAL_RCAP" , ""},
//                { "COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1", q53);

//            #endregion

//            #region R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1

//            var q54 = new DynamicData();
//            q54.AddDynamic(new Dictionary<string, string>{
//                { "NUM_BENEFICIARIO" , "13456"}
//            });
//            q54.AddDynamic(new Dictionary<string, string>{
//                { "NUM_BENEFICIARIO" , "13457"}
//            });
//            q54.AddDynamic(new Dictionary<string, string>{
//                { "NUM_BENEFICIARIO" , "13458"}
//            });
//            q54.AddDynamic(new Dictionary<string, string>{
//                { "NUM_BENEFICIARIO" , "13459"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0805_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1", q54);

//            #endregion

//            #region R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1

//            var q55 = new DynamicData();
//            q55.AddDynamic(new Dictionary<string, string>{
//                { "NUM_PROPOSTA_AZUL" , ""},
//                { "COD_AGENCIA_LOTE" , ""},
//                { "DATA_LOTE" , ""},
//                { "NUM_LOTE" , ""},
//                { "NUM_SEQ_LOTE" , ""},
//                { "NUM_BENEFICIARIO" , ""},
//                { "NOME_BENEFICIARIO" , ""},
//                { "GRAU_PARENTESCO" , ""},
//                { "PCT_PART_BENEFICIA" , ""},
//                { "DATA_NASCIMENTO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1", q55);

//            #endregion

//            #region R0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1

//            var q56 = new DynamicData();
//            q56.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
//                { "PRODUVG_COD_PRODUTO" , ""},
//                { "OCORR_ENDERECO" , ""},
//                { "WHOST_FONTE" , ""},
//                { "PROPOFID_AGECOBR" , ""},
//                { "PROPOFID_OPCAO_COBER" , ""},
//                { "PROPOFID_DTQITBCO" , ""},
//                { "PROPOFID_AGECTAVEN" , ""},
//                { "PROPOFID_OPRCTAVEN" , ""},
//                { "PROPOFID_NUMCTAVEN" , ""},
//                { "PROPOFID_DIGCTAVEN" , ""},
//                { "PROPOFID_NRMATRVEN" , ""},
//                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
//                { "WHOST_SIT_REGISTRO" , ""},
//                { "PROPSSVD_NUM_APOLICE" , ""},
//                { "PROPSSVD_COD_SUBGRUPO" , ""},
//                { "WHOST_DTPROXVEN" , ""},
//                { "SEXO" , ""},
//                { "ESTADO_CIVIL" , ""},
//                { "PROPSSVD_APOS_INVALIDEZ" , ""},
//                { "PROPSSVD_DPS_TITULAR" , ""},
//                { "PROPSSVD_DPS_CONJUGE" , ""},
//                { "PROPOFID_FAIXA_RENDA_IND" , ""},
//                { "PROPSSVD_NUM_CONTR_VINCULO" , ""},
//                { "PROPSSVD_COD_CORRESP_BANC" , ""},
//                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
//                { "PROPSSVD_NUM_PRAZO_FIN" , ""},
//                { "PROPSSVD_COD_OPER_CREDITO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0860_TRATA_INC_CARTAO_DB_INSERT_1_Insert1", q56);

//            #endregion

//            #region R0860_TRATA_INC_CARTAO_DB_INSERT_2_Insert1

//            var q57 = new DynamicData();
//            q57.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
//                { "PROPOFID_DTQITBCO" , ""},
//                { "PRODUVG_PERI_PAGAMENTO" , ""},
//                { "PROPOFID_DIA_DEBITO" , ""},
//                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
//                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
//                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
//                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
//                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0860_TRATA_INC_CARTAO_DB_INSERT_2_Insert1", q57);

//            #endregion

//            #region R0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1

//            var q58 = new DynamicData();
//            q58.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
//                { "PROPOFID_DTQITBCO" , ""},
//                { "PRODUVG_PERI_PAGAMENTO" , ""},
//                { "PROPOFID_DIA_DEBITO" , ""},
//                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
//                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
//                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
//                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
//                { "OPCPAGVI_NUM_CARTAO_CREDITO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0862_TRATA_INC_CARTAO_DB_INSERT_1_Insert1", q58);

//            #endregion

//            #region R0865_INCLUIR_FAX_DB_SELECT_1_Query1

//            var q59 = new DynamicData();
//            q59.AddDynamic(new Dictionary<string, string>{
//                { "SEQ_FONE" , "6101"}
//            });
//            q59.AddDynamic(new Dictionary<string, string>{
//                { "SEQ_FONE" , "6102"}
//            });
//            q59.AddDynamic(new Dictionary<string, string>{
//                { "SEQ_FONE" , "6103"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0865_INCLUIR_FAX_DB_SELECT_1_Query1", q59);

//            #endregion

//            #region R0865_INCLUIR_FAX_DB_INSERT_1_Insert1

//            var q60 = new DynamicData();
//            q60.AddDynamic(new Dictionary<string, string>{
//                { "COD_PESSOA" , ""},
//                { "TIPO_FONE" , ""},
//                { "SEQ_FONE" , ""},
//                { "DDI" , ""},
//                { "DDD" , ""},
//                { "NUM_FONE" , ""},
//                { "SITUACAO_FONE" , ""},
//                { "COD_USUARIO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0865_INCLUIR_FAX_DB_INSERT_1_Insert1", q60);

//            #endregion

//            #region R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1

//            var q61 = new DynamicData();
//            q61.AddDynamic(new Dictionary<string, string>{
//                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
//                { "PROFIDCO_INFORMACAO_COMPL" , ""},
//                { "PROFIDCO_COD_USUARIO" , ""},
//                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1", q61);

//            #endregion

//            #region R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1

//            var q62 = new DynamicData();
//            q62.AddDynamic(new Dictionary<string, string>{
//                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
//                { "PROFIDCO_INFORMACAO_COMPL" , ""},
//                { "PROFIDCO_COD_USUARIO" , ""},
//                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1", q62);

//            #endregion

//            #region R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1

//            var q63 = new DynamicData();
//            q63.AddDynamic(new Dictionary<string, string>{
//                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
//                { "PROFIDCO_INFORMACAO_COMPL" , ""},
//                { "PROFIDCO_COD_USUARIO" , ""},
//                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0950_INF_MEDICO_VIDA_MULHER_DB_INSERT_1_Insert1", q63);

//            #endregion

//            #region R0960_INF_PRESTAMISTA_DB_SELECT_1_Query1

//            var q64 = new DynamicData();
//            q64.AddDynamic(new Dictionary<string, string>{
//                { "GE372_COD_OPER_CREDITO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R0960_INF_PRESTAMISTA_DB_SELECT_1_Query1", q64);

//            #endregion

//            #region R0971_00_INS_PROP_FIDELIZ_COMP_DB_INSERT_1_Insert1

//            var q65 = new DynamicData();
//            q65.AddDynamic(new Dictionary<string, string>{
//                { "PROFIDCO_NUM_IDENTIFICACAO" , ""},
//                { "PROFIDCO_INFORMACAO_COMPL" , ""},
//                { "PROFIDCO_COD_USUARIO" , ""},
//                { "PROFIDCO_IND_TP_INFORMACAO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R0971_00_INS_PROP_FIDELIZ_COMP_DB_INSERT_1_Insert1", q65);

//            #endregion

//            #region R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1

//            var q66 = new DynamicData();
//            q66.AddDynamic(new Dictionary<string, string>{
//                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
//                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
//                { "ARQSIVPF_NSAS_SIVPF" , ""},
//                { "ARQSIVPF_DATA_GERACAO" , ""},
//                { "ARQSIVPF_QTDE_REG_GER" , ""},
//                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R2060_00_ATUALIZA_ARQSIVPF_DB_INSERT_1_Insert1", q66);

//            #endregion

//            #region R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1

//            var q67 = new DynamicData();
//            q67.AddDynamic(new Dictionary<string, string>{
//                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
//                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
//                { "ARQSIVPF_NSAS_SIVPF" , ""},
//                { "ARQSIVPF_DATA_GERACAO" , ""},
//                { "ARQSIVPF_QTDE_REG_GER" , ""},
//                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1", q67);

//            #endregion

//            #region R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1

//            var q68 = new DynamicData();
//            q68.AddDynamic(new Dictionary<string, string>{
//                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
//                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
//                { "ARQSIVPF_NSAS_SIVPF" , ""},
//                { "ARQSIVPF_DATA_GERACAO" , ""},
//                { "ARQSIVPF_QTDE_REG_GER" , ""},
//                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1", q68);

//            #endregion

//            #region PF0600B_CFONTES

//            var q69 = new DynamicData();
//            q69.AddDynamic(new Dictionary<string, string>{
//                { "DCLFONTES_FONTES_COD_FONTE" , "0"},
//                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "14204"},
//            });
//            q69.AddDynamic(new Dictionary<string, string>{
//                { "DCLFONTES_FONTES_COD_FONTE" , "1"},
//                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "37606254"},
//            });
//            q69.AddDynamic(new Dictionary<string, string>{
//                { "DCLFONTES_FONTES_COD_FONTE" , "2"},
//                { "DCLFONTES_FONTES_ULT_PROP_AUTOMAT" , "9215909"},
//            });
//            AppSettings.TestSet.DynamicData.Add("PF0600B_CFONTES", q69);

//            #endregion

//            #region PF0600B_CSUBGVGA

//            var q70 = new DynamicData();
//            q70.AddDynamic(new Dictionary<string, string>{
//                { "SUBGVGAP_NUM_APOLICE" , "107700000013"},
//                { "SUBGVGAP_DATA_INIVIGENCIA" , "2007-12-21"},
//                { "SUBGVGAP_COD_SUBGRUPO" , "1"},
//                { "PRODUVG_NOME_PRODUTO" , "PRESTAMISTA GITEL       "},
//                { "PRODUVG_PERI_PAGAMENTO" , "0"},
//                { "SUBGVGAP_OPCAO_CONJUGE" , "3"},
//            });
//            q70.AddDynamic(new Dictionary<string, string>{
//                { "SUBGVGAP_NUM_APOLICE" , "107700000011"},
//                { "SUBGVGAP_DATA_INIVIGENCIA" , "2007-12-21"},
//                { "SUBGVGAP_COD_SUBGRUPO" , "1"},
//                { "PRODUVG_NOME_PRODUTO" , "PRESTAMISTA CONSIGNAÇÃO       "},
//                { "PRODUVG_PERI_PAGAMENTO" , "0"},
//                { "SUBGVGAP_OPCAO_CONJUGE" , "3"},
//            });
//            AppSettings.TestSet.DynamicData.Add("PF0600B_CSUBGVGA", q70);

//            #endregion

//            #region R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1

//            var q71 = new DynamicData();
//            q71.AddDynamic(new Dictionary<string, string>{
//                { "PLAVAVGA_DTINIVIG" , "2024-04-02"}
//            });
//            q71.AddDynamic(new Dictionary<string, string>{
//                { "PLAVAVGA_DTINIVIG" , "2024-04-02"}
//            });
//            q71.AddDynamic(new Dictionary<string, string>{
//                { "PLAVAVGA_DTINIVIG" , "2024-04-02"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1", q71);

//            #endregion

//            #region R7200_00_MOVE_TABELA_DB_SELECT_1_Query1

//            var q72 = new DynamicData();
//            q72.AddDynamic(new Dictionary<string, string>{
//                { "WS_QTD" , "74"}
//            });
//            AppSettings.TestSet.DynamicData.Add("R7200_00_MOVE_TABELA_DB_SELECT_1_Query1", q72);

//            #endregion

//            #region R9971_LER_RCAP_DB_SELECT_1_Query1

//            var q73 = new DynamicData();
//            q73.AddDynamic(new Dictionary<string, string>{
//                { "RCAPS_COD_FONTE" , ""},
//                { "RCAPS_NUM_RCAP" , ""},
//                { "RCAPS_VAL_RCAP" , ""},
//                { "RCAPS_AGE_COBRANCA" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R9971_LER_RCAP_DB_SELECT_1_Query1", q73);

//            #endregion

//            #region R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1

//            var q74 = new DynamicData();
//            q74.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
//                { "PROPOFID_NUM_SICOB" , ""},
//                { "PROPOFID_DTQITBCO" , ""},
//                { "PROPOFID_VAL_PAGO" , ""},
//                { "PROPOFID_AGEPGTO" , ""},
//                { "PROPOFID_SIT_PROPOSTA" , ""},
//                { "PROPOFID_DATA_CREDITO" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1", q74);

//            #endregion

//            #region R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1

//            var q75 = new DynamicData();
//            q75.AddDynamic(new Dictionary<string, string>{
//                { "PROPOVA_SIT_REGISTRO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1", q75);

//            #endregion

//            #region R9984_00_LER_BILHETE_DB_SELECT_1_Query1

//            var q76 = new DynamicData();
//            q76.AddDynamic(new Dictionary<string, string>{
//                { "BILHETE_SITUACAO" , ""}
//            });
//            AppSettings.TestSet.DynamicData.Add("R9984_00_LER_BILHETE_DB_SELECT_1_Query1", q76);

//            #endregion

//            #region R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1

//            var q77 = new DynamicData();
//            q77.AddDynamic(new Dictionary<string, string>{
//                { "PROPOFID_SITUACAO_ENVIO" , ""},
//                { "PROPOFID_DATA_CREDITO" , ""},
//                { "PROPOFID_SIT_PROPOSTA" , ""},
//                { "PROPOFID_COD_USUARIO" , ""},
//                { "PROPOFID_DTQITBCO" , ""},
//                { "PROPOFID_VAL_PAGO" , ""},
//                { "PROPOFID_AGEPGTO" , ""},
//                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
//            });
//            AppSettings.TestSet.DynamicData.Add("R9985_00_ATUALIZAR_DADOS_SISPF_DB_UPDATE_1_Update1", q77);

//            #endregion

//            #endregion

//            #region Parameters Subs

//            GEJVS002_Tests.Load_Parameters();

//            #endregion
//        }
//        [Theory]
//        [InlineData("PF600B_SASSE_TESTE.txt", "Saida_PF0600B.txt", "Saida_PF0600B_5.txt", "Saida_PF0600B_4.txt", "Saida_PF0600B_3.txt", "Saida_PF0600B_2.txt")]
//        public static void PF0600B_Tests_Theory(string MOV_SIGAT_FILE_NAME_P, string MOV_AUTO_FILE_NAME_P, string MOV_RISCO_FILE_NAME_P, string MOV_VDEMP_FILE_NAME_P, string MOV_FILIAL_FILE_NAME_P, string RPF0600B_FILE_NAME_P)
//        {
//            lock (AppSettings.TestSet._lock)
//            {
//                AppSettings.TestSet.IsTest = true;
//                Load_Parameters();

//                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
//                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
//                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

//                #region VARIAVEIS_TESTE
//                #endregion
//                var program = new PF0600B();
//                program.Execute(MOV_SIGAT_FILE_NAME_P, MOV_AUTO_FILE_NAME_P, MOV_RISCO_FILE_NAME_P, MOV_VDEMP_FILE_NAME_P, MOV_FILIAL_FILE_NAME_P, RPF0600B_FILE_NAME_P);

//                //parametro do sub programa GEJVS002
//                Assert.True(program.GEJVW002.LK_GEJVW002_SIAS_COD_CGCCPF == 34020354000110);

//                Assert.True(program.WAREA_AUXILIAR.W_FIM_MOVTO_SIGAT == "FIM");
//                Assert.True(program.RETURN_CODE == 0);

//                Assert.True(program.WAREA_AUXILIAR.WS_QTD == 74);
//                Assert.True(program.PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_DTINIVIG == "2024-04-02");
                
//                //R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1
//                var envList0 = AppSettings.TestSet.DynamicData["R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList0[1].TryGetValue("PESSOA_NOME_PESSOA", out var val0r)&& val0r.Contains("MARIA JULIA SELEIRO DE LIMA SILVA       "));
//                Assert.True(envList0.Count > 1);

//                //R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1
//                var envList1 = AppSettings.TestSet.DynamicData["R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList1[1].TryGetValue("CPF", out var val1r) && val1r.Contains("09099251270"));
//                Assert.True(envList1.Count > 1);

//                //R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1
//                var envList2 = AppSettings.TestSet.DynamicData["R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList2[1].TryGetValue("EMAIL", out var val2r) && val2r.Contains("MJULIASDLIMA2123@GMAI.COM               "));
//                Assert.True(envList2.Count > 1);

//                //R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1
//                var envList3 = AppSettings.TestSet.DynamicData["R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList3[1].TryGetValue("CEP", out var val3r) && val3r.Contains("068705000"));
//                Assert.True(envList3.Count > 1);

//                //R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1
//                var envList4 = AppSettings.TestSet.DynamicData["R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList4[1].TryGetValue("NUM_FONE", out var val4r) && val4r.Contains("00992574666"));
//                Assert.True(envList4.Count > 1);

//                //R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1
//                var envList5 = AppSettings.TestSet.DynamicData["R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList5[1].TryGetValue("COD_PESSOA", out var val5r) && val5r.Contains("000000002"));
//                Assert.True(envList5.Count > 1);

//                //R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1
//                var envList6 = AppSettings.TestSet.DynamicData["R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList6[1].TryGetValue("NUM_IDENTIFICACAO", out var val6r) && val6r.Contains("000000000000013"));
//                Assert.True(envList6.Count > 1);

//                //R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1
//                var envList7 = AppSettings.TestSet.DynamicData["R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList7[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var val7r) && val7r.Contains("030025290003058"));
//                Assert.True(envList7.Count > 1);

//                //R0771_10_NEXT_DB_INSERT_1_Insert1
//                var envList8 = AppSettings.TestSet.DynamicData["R0771_10_NEXT_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList8[1].TryGetValue("PROPSSVD_NUM_PRAZO_FIN", out var val8r) && val8r.Contains("2901"));
//                Assert.True(envList8.Count > 1);

//                //R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1
//                var envList9 = AppSettings.TestSet.DynamicData["R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList9[1].TryGetValue("PROPFIDH_SIT_PROPOSTA", out var val9r) && val9r.Contains("ENV"));
//                Assert.True(envList9.Count > 1);

//                //R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1
//                var envList10 = AppSettings.TestSet.DynamicData["R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1"].DynamicList;
//                Assert.True(envList10[1].TryGetValue("CEDENTE_COD_CEDENTE", out var val10r) && val10r.Contains("0092"));

//                //R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1
//                var envList11 = AppSettings.TestSet.DynamicData["R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList11[1].TryGetValue("PRODUTO_SIVPF", out var val11r) && val11r.Contains("0077"));
//                Assert.True(envList11.Count > 1);

//                //R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1
//                var envList12 = AppSettings.TestSet.DynamicData["R0810_TRATA_BENEFICIARIO_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList12[1].TryGetValue("NUM_BENEFICIARIO", out var val12r) && val12r.Contains("1346"));
//                Assert.True(envList12.Count > 1);

//                //R0865_INCLUIR_FAX_DB_INSERT_1_Insert1
//                var envList13 = AppSettings.TestSet.DynamicData["R0865_INCLUIR_FAX_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList13[1].TryGetValue("SEQ_FONE", out var val13r) && val13r.Contains("6102"));
//                Assert.True(envList13.Count > 1);

//                //R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1
//                var envList14 = AppSettings.TestSet.DynamicData["R0910_TRATA_INF_SICAQWEB_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList14[1].TryGetValue("PROFIDCO_NUM_IDENTIFICACAO", out var val14r) && val14r.Contains("000000000000013"));
//                Assert.True(envList14.Count > 1);

//                //R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1
//                var envList15 = AppSettings.TestSet.DynamicData["R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1"].DynamicList;
//                Assert.True(envList15[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val15r) && val15r.Contains("PRPSASSE"));
//                Assert.True(envList15.Count > 1);

//            }

//        }

//        [Theory]
//        [InlineData("PF0600B_testes.txt", "Saida_PF0600B.txt", "Saida_PF0600B_5.txt", "Saida_PF0600B_4.txt", "Saida_PF0600B_3.txt", "Saida_PF0600B_2.txt")]
//        public static void PF0600B_Tests_Theory_ERRO99(string MOV_SIGAT_FILE_NAME_P, string MOV_AUTO_FILE_NAME_P, string MOV_RISCO_FILE_NAME_P, string MOV_VDEMP_FILE_NAME_P, string MOV_FILIAL_FILE_NAME_P, string RPF0600B_FILE_NAME_P)
//        {
//            lock (AppSettings.TestSet._lock)
//            {
//                AppSettings.TestSet.IsTest = true;
//                Load_Parameters();

//                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
//                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
//                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

//                #region VARIAVEIS_TESTE

//                #region GEJVS002_GE074_CURSOR

//                var q0 = new DynamicData();
//                AppSettings.TestSet.DynamicData.Remove("GEJVS002_GE074_CURSOR");
//                AppSettings.TestSet.DynamicData.Add("GEJVS002_GE074_CURSOR", q0);

//                #endregion
//                #endregion
//                var program = new PF0600B();
//                program.Execute(MOV_SIGAT_FILE_NAME_P, MOV_AUTO_FILE_NAME_P, MOV_RISCO_FILE_NAME_P, MOV_VDEMP_FILE_NAME_P, MOV_FILIAL_FILE_NAME_P, RPF0600B_FILE_NAME_P);

//                Assert.True(program.GEJVWCNT.LK_GEJVWCNT_IND_ERRO == 1);
//                Assert.True(program.RETURN_CODE == 99);


//            }
//        }

//    }
//}