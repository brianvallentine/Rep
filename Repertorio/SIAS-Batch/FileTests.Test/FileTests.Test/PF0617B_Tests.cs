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
using static Code.PF0617B;

namespace FileTests.Test
{
    [Collection("PF0617B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0617B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_REF_M1YEAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "WHOST_DATA_REF_CURSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region PF0617B_C01_BILHETE

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DCLBILHETE_BILHETE_NUM_BILHETE" , ""},
                { "DCLBILHETE_BILHETE_NUM_APOLICE" , ""},
                { "DCLBILHETE_BILHETE_FONTE" , ""},
                { "DCLBILHETE_BILHETE_AGE_COBRANCA" , ""},
                { "DCLBILHETE_BILHETE_NUM_MATRICULA" , ""},
                { "DCLBILHETE_BILHETE_COD_AGENCIA" , ""},
                { "DCLBILHETE_BILHETE_OPERACAO_CONTA" , ""},
                { "DCLBILHETE_BILHETE_NUM_CONTA" , ""},
                { "DCLBILHETE_BILHETE_DIG_CONTA" , ""},
                { "DCLBILHETE_BILHETE_COD_CLIENTE" , ""},
                { "DCLBILHETE_BILHETE_PROFISSAO" , ""},
                { "DCLBILHETE_BILHETE_IDE_SEXO" , ""},
                { "DCLBILHETE_BILHETE_ESTADO_CIVIL" , ""},
                { "DCLBILHETE_BILHETE_OCORR_ENDERECO" , ""},
                { "DCLBILHETE_BILHETE_COD_AGENCIA_DEB" , ""},
                { "DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "DCLBILHETE_BILHETE_NUM_CONTA_DEB" , ""},
                { "DCLBILHETE_BILHETE_DIG_CONTA_DEB" , ""},
                { "DCLBILHETE_BILHETE_OPC_COBERTURA" , ""},
                { "DCLBILHETE_BILHETE_DATA_QUITACAO" , ""},
                { "DCLBILHETE_BILHETE_VAL_RCAP" , ""},
                { "DCLBILHETE_BILHETE_RAMO" , "14"},
                { "DCLBILHETE_BILHETE_DATA_VENDA" , ""},
                { "DCLBILHETE_BILHETE_DATA_MOVIMENTO" , ""},
                { "DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR" , "1"},
                { "DCLBILHETE_BILHETE_SITUACAO" , ""},
                { "DCLBILHETE_BILHETE_TIP_CANCELAMENTO" , ""},
                { "DCLBILHETE_BILHETE_SIT_SINISTRO" , ""},
                { "DCLBILHETE_BILHETE_COD_USUARIO" , ""},
                { "WHOST_DATA_REFERENCIA" , ""},
                { "DCLENDOSSOS_ENDOSSOS_NUM_APOLICE" , ""},
                { "DCLENDOSSOS_ENDOSSOS_NUM_ENDOSSO" , ""},
                { "DCLENDOSSOS_ENDOSSOS_NUM_PROPOSTA" , ""},
                { "DCLENDOSSOS_ENDOSSOS_DATA_PROPOSTA" , ""},
                { "DCLENDOSSOS_ENDOSSOS_DATA_EMISSAO" , ""},
                { "DCLENDOSSOS_ENDOSSOS_NUM_RCAP" , ""},
                { "DCLENDOSSOS_ENDOSSOS_VAL_RCAP" , ""},
                { "DCLENDOSSOS_ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "DCLENDOSSOS_ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "DCLENDOSSOS_ENDOSSOS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_C01_BILHETE", q3);

            #endregion

            #region R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , "1"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "12"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "9"},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_SIT_PROPOSTA" , ""}
            });
            //AppSettings.TestSet.DynamicData.Add("R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "TIPO_PESSOA" , ""},
                { "CGCCPF" , "12345678909"},
                { "SIT_REGISTRO" , ""},
                { "DATA_NASCIMENTO" , "19880101"},
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "TIPO_PESSOA" , ""},
                { "CGCCPF" , "12345678909"},
                { "SIT_REGISTRO" , ""},
                { "DATA_NASCIMENTO" , "19880101"},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0345_00_LER_ENDERECO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , ""},
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
                { "ENDERECO_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0345_00_LER_ENDERECO_DB_SELECT_1_Query1", q8);

            #endregion

            #region PF0617B_C01_ENDERECO

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DCLENDERECOS_ENDERECO_COD_CLIENTE" , ""},
                { "DCLENDERECOS_ENDERECO_COD_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_BAIRRO" , ""},
                { "DCLENDERECOS_ENDERECO_CIDADE" , ""},
                { "DCLENDERECOS_ENDERECO_SIGLA_UF" , ""},
                { "DCLENDERECOS_ENDERECO_CEP" , ""},
                { "DCLENDERECOS_ENDERECO_DDD" , "13"},
                { "DCLENDERECOS_ENDERECO_TELEFONE" , "12312311231231123123112312311231231"},
                { "DCLENDERECOS_ENDERECO_FAX" , ""},
                { "DCLENDERECOS_ENDERECO_TELEX" , ""},
                { "DCLENDERECOS_ENDERECO_SIT_REGISTRO" , ""},
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "DCLENDERECOS_ENDERECO_COD_CLIENTE" , ""},
                { "DCLENDERECOS_ENDERECO_COD_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_BAIRRO" , ""},
                { "DCLENDERECOS_ENDERECO_CIDADE" , ""},
                { "DCLENDERECOS_ENDERECO_SIGLA_UF" , ""},
                { "DCLENDERECOS_ENDERECO_CEP" , ""},
                { "DCLENDERECOS_ENDERECO_DDD" , "22"},
                { "DCLENDERECOS_ENDERECO_TELEFONE" , "222222222"},
                { "DCLENDERECOS_ENDERECO_FAX" , ""},
                { "DCLENDERECOS_ENDERECO_TELEX" , ""},
                { "DCLENDERECOS_ENDERECO_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_C01_ENDERECO", q9);

            #endregion

            #region R0410_00_LER_CBO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_LER_CBO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
            });
            q11.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0500_00_LER_RCAP_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LER_RCAP_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0500_00_LER_RCAP_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LER_RCAP_DB_SELECT_2_Query1", q13);

            #endregion

            #region R0573_00_LER_PARCELA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TARIFARIO_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0573_00_LER_PARCELA_DB_SELECT_1_Query1", q14);

            #endregion

            #region PF0617B_PARCELS

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_PRM_TARIFARIO_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_PARCELS", q15);

            #endregion

            #region PF0617B_V0APOLCORRET

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "APOLICOR_COD_CORRETOR" , ""},
                { "APOLICOR_PCT_PART_CORRETOR" , ""},
                { "APOLICOR_PCT_COM_CORRETOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_V0APOLCORRET", q16);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "NUM_SICOB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , "1"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "12"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "9"},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "NUM_APOL_ANT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_APOL_ANTERIOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1", q21);

            #endregion

            #region R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q22);

            #endregion

            #region R0620_00_DADOS_RG_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_DADOS_RG_DB_SELECT_1_Query1", q23);

            #endregion

            #region PF0617B_BENEFICIARIOS

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "DCLBENEFICIARIOS_BENEFICI_NUM_APOLICE" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_COD_SUBGRUPO" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_NUM_CERTIFICADO" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_DAC_CERTIFICADO" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_NUM_BENEFICIARIO" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_NOME_BENEFICIARIO" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_GRAU_PARENTESCO" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_PCT_PART_BENEFICIA" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_DATA_INIVIGENCIA" , ""},
                { "DCLBENEFICIARIOS_BENEFICI_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_BENEFICIARIOS", q24);

            #endregion

            #region R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "FCLOTERI_NUM_DV_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1", q25);

            #endregion

            #region R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "FCLOTERI_NUM_DV_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1", q26);

            #endregion

            #region R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "FCLOTERI_NUM_DV_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1", q27);

            #endregion

            #region R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "FCLOTERI_NUM_DV_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1", q28);

            #endregion

            #region R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "FCLOTERI_NUM_DV_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1", q29);

            #endregion

            #region R0930_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_HIERARQUIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0930_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1", q30);

            #endregion

            #region R0935_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "PRODUTOR_COD_HIERARQUIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0935_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1", q31);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "WS_DIA_SEMANA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1", q33);

            #endregion

            #region R1110_00_UPDATE_RELATORIOS_DB_UPDATE_2_Update1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_UPDATE_RELATORIOS_DB_UPDATE_2_Update1", q34);

            #endregion

            #region PF0617B_DTHBILHETE

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WS_DTH_BILHETE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_DTHBILHETE", q35);

            #endregion

            #region R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1", q36);

            #endregion

            #region R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1", q38);

            #endregion

            #region R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q39);

            #endregion

            #region R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1", q41);

            #endregion

            #region R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1", q43);

            #endregion

            #region R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1", q44);

            #endregion

            #region PF0617B_EMAIL

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_EMAIL_COD_PESSOA" , ""},
                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_EMAIL", q45);

            #endregion

            #region R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q46);

            #endregion

            #region R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1", q47);

            #endregion

            #region R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
                { "PESSOA_TIMESTAMP" , ""},
                { "PESSOA_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1", q48);

            #endregion

            #region R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q49);

            #endregion

            #region R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1", q50);

            #endregion

            #region PF0617B_ENDERECOS

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_COD_PESSOA" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0617B_ENDERECOS", q51);

            #endregion

            #region R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1", q52);

            #endregion

            #region R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1", q53);

            #endregion

            #region R3255_LER_TELEFONE_DB_SELECT_1_Query1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3255_LER_TELEFONE_DB_SELECT_1_Query1", q54);

            #endregion

            #region R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1", q55);

            #endregion

            #region R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "TIPO_FONE" , ""},
                { "SEQ_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1", q56);

            #endregion

            #region R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1

            var q57 = new DynamicData();
            q57.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1", q57);

            #endregion

            #region R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1

            var q58 = new DynamicData();
            q58.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1", q58);

            #endregion

            #region R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1

            var q59 = new DynamicData();
            q59.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1", q59);

            #endregion

            #region R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1

            var q60 = new DynamicData();
            q60.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""},
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1", q60);

            #endregion

            #region R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1

            var q61 = new DynamicData();
            q61.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1", q61);

            #endregion

            #region R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1

            var q62 = new DynamicData();
            q62.AddDynamic(new Dictionary<string, string>{
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
                { "PROPOFID_DIGCTAVEN" , ""},
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
                { "PROPOFID_CANAL_PROPOSTA" , "1"},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "PROPOFID_IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1", q62);

            #endregion

            #region R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1

            var q63 = new DynamicData();
            q63.AddDynamic(new Dictionary<string, string>{
                { "PROPSSBI_NUM_IDENTIFICACAO" , ""},
                { "PROPSSBI_RENOVACAO_AUTOM" , ""},
                { "PROPSSBI_COD_USUARIO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1", q63);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q64 = new DynamicData();
            q64.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
                { "PROPFIDH_DATA_SITUACAO" , ""},
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , ""},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , ""},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q64);

            #endregion

            #region R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1

            var q65 = new DynamicData();
            q65.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1", q65);

            #endregion

            #region R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1

            var q66 = new DynamicData();
            q66.AddDynamic(new Dictionary<string, string>{
                { "NUM_BENEFICIARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1", q66);

            #endregion

            SPBGE053_Tests.Load_Parameters();
            #endregion
        }

        [Theory]
        [InlineData("MOVTO_PRP_BILHETE_FILE.txt")]
        public static void PF0617B_Tests_Theory(string MOVTO_PRP_BILHETE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_BILHETE_FILE_NAME_P = $"{MOVTO_PRP_BILHETE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0617B();
                program.Execute(MOVTO_PRP_BILHETE_FILE_NAME_P);

                var envList = AppSettings.TestSet.DynamicData["R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("PROPOFID_NUM_SICOB", out var valor) && valor == "000000000000000");
                Assert.True(envList1[1].TryGetValue("PROPOFID_SIT_PROPOSTA", out valor) && valor == "EMT");
                Assert.True(envList1[1].TryGetValue("NUM_APOL_ANT", out valor) && valor == "0000000000001");
            }
        }
    }
}