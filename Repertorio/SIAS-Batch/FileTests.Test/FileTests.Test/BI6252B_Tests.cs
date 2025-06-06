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
using static Code.BI6252B;

namespace FileTests.Test
{
    [Collection("BI6252B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI6252B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DTMOVABE20" , ""},
                { "WSHOST_DTTERCOT" , ""},
                { "WSHOST_DTINICOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI6252B_V0COTACAO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , ""},
                { "MOEDACOT_DATA_TERVIGENCIA" , ""},
                { "MOEDACOT_VAL_VENDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6252B_V0COTACAO", q1);

            #endregion

            #region BI6252B_V0MOVIMCOB

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_DATA_QUITACAO" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_VAL_CREDITO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NOME_SEGURADO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "WSGER00_DATA_INIVIGENCIA" , ""},
                { "WSGER00_DATA_TERVIGENCIA" , ""},
                { "WSGER00_DATA_VENCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6252B_V0MOVIMCOB", q2);

            #endregion

            #region R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""},
                { "CONVERSI_COD_PRODUTO_SIVPF" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_AGE_COBRANCA" , ""},
                { "BILHETE_NUM_MATRICULA" , ""},
                { "BILHETE_COD_AGENCIA" , ""},
                { "BILHETE_OPERACAO_CONTA" , ""},
                { "BILHETE_NUM_CONTA" , ""},
                { "BILHETE_DIG_CONTA" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
                { "BILHETE_COD_AGENCIA_DEB" , ""},
                { "BILHETE_OPERACAO_CONTA_DEB" , ""},
                { "BILHETE_NUM_CONTA_DEB" , ""},
                { "BILHETE_DIG_CONTA_DEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "WSHOST_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_ESTADO_CIVIL" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "WSHOST_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "WSHOST_SIGLA_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FONTES_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "FONTES_COD_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""},
                { "PESSOFIS_CPF" , ""},
                { "PESSOFIS_DATA_NASCIMENTO" , ""},
                { "PESSOFIS_SEXO" , ""},
                { "PESSOFIS_COD_USUARIO" , ""},
                { "PESSOFIS_ESTADO_CIVIL" , ""},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_ORGAO_EXPEDIDOR" , ""},
                { "PESSOFIS_UF_EXPEDIDORA" , ""},
                { "PESSOFIS_DATA_EXPEDICAO" , ""},
                { "PESSOFIS_COD_CBO" , ""},
                { "PESSOFIS_TIPO_IDENT_SIVPF" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1150_00_INSERT_PESSOA_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_INSERT_PESSOA_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_PESSOA" , ""},
                { "PESSOFIS_CPF" , ""},
                { "PESSOFIS_DATA_NASCIMENTO" , ""},
                { "PESSOFIS_SEXO" , ""},
                { "PESSOFIS_COD_USUARIO" , ""},
                { "PESSOFIS_ESTADO_CIVIL" , ""},
                { "PESSOFIS_NUM_IDENTIDADE" , ""},
                { "PESSOFIS_ORGAO_EXPEDIDOR" , ""},
                { "PESSOFIS_UF_EXPEDIDORA" , ""},
                { "PESSOFIS_DATA_EXPEDICAO" , ""},
                { "PESSOFIS_COD_CBO" , ""},
                { "PESSOFIS_TIPO_IDENT_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "IDENTREL_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "IDENTREL_NUM_IDENTIFICACAO" , ""},
                { "IDENTREL_COD_PESSOA" , ""},
                { "IDENTREL_COD_RELAC" , ""},
                { "IDENTREL_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
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
                { "PROPOFID_IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_MOEDA" , ""},
                { "BILHECOB_PCT_COM_CORRETOR" , ""},
                { "BILHECOB_IMP_SEGURADA_IX" , ""},
                { "BILHECOB_PRM_TARIFARIO_IX" , ""},
                { "BILHECOB_PRM_TOTAL" , ""},
                { "BILHECOB_PCT_IOCC" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""},
                { "WSHOST_PCT_IOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WSGER01_DATA_INIVIGENCIA" , ""},
                { "WSGER01_DATA_TERVIGENCIA" , ""},
                { "WSGER02_DATA_INIVIGENCIA" , ""},
                { "WSGER02_DATA_TERVIGENCIA" , ""},
                { "WSGER03_DATA_INIVIGENCIA" , ""},
                { "WSGER03_DATA_TERVIGENCIA" , ""},
                { "WSGER04_DATA_INIVIGENCIA" , ""},
                { "WSGER04_DATA_TERVIGENCIA" , ""},
                { "WSGER05_DATA_INIVIGENCIA" , ""},
                { "WSGER05_DATA_TERVIGENCIA" , ""},
                { "WSGER06_DATA_INIVIGENCIA" , ""},
                { "WSGER06_DATA_TERVIGENCIA" , ""},
                { "WSGER07_DATA_INIVIGENCIA" , ""},
                { "WSGER07_DATA_TERVIGENCIA" , ""},
                { "WSGER08_DATA_INIVIGENCIA" , ""},
                { "WSGER08_DATA_TERVIGENCIA" , ""},
                { "WSGER09_DATA_INIVIGENCIA" , ""},
                { "WSGER09_DATA_TERVIGENCIA" , ""},
                { "WSGER10_DATA_INIVIGENCIA" , ""},
                { "WSGER10_DATA_TERVIGENCIA" , ""},
                { "WSGER11_DATA_INIVIGENCIA" , ""},
                { "WSGER11_DATA_TERVIGENCIA" , ""},
                { "WSGER12_DATA_INIVIGENCIA" , ""},
                { "WSGER12_DATA_TERVIGENCIA" , ""},
                { "WSGER13_DATA_INIVIGENCIA" , ""},
                { "WSGER13_DATA_TERVIGENCIA" , ""},
                { "WSGER14_DATA_INIVIGENCIA" , ""},
                { "WSGER14_DATA_TERVIGENCIA" , ""},
                { "WSGER15_DATA_INIVIGENCIA" , ""},
                { "WSGER15_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DTH_ULT_DIA_MES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q19);

            #endregion

            #region R2550_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ORGAO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2550_00_SELECT_FONTES_DB_SELECT_1_Query1", q20);

            #endregion

            #region R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1", q21);

            #endregion

            #region R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_APOLICE" , ""},
                { "NUMERAES_ORGAO_EMISSOR" , ""},
                { "NUMERAES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_CLIENTE" , ""},
                { "APOLICES_NUM_APOLICE" , ""},
                { "APOLICES_NUM_ITEM" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
                { "APOLICES_NUM_APOL_ANTERIOR" , ""},
                { "APOLICES_NUM_BILHETE" , ""},
                { "APOLICES_TIPO_SEGURO" , ""},
                { "APOLICES_TIPO_APOLICE" , ""},
                { "APOLICES_TIPO_CALCULO" , ""},
                { "APOLICES_IND_SORTEIO" , ""},
                { "APOLICES_NUM_ATA" , ""},
                { "APOLICES_ANO_ATA" , ""},
                { "APOLICES_IND_ENDOS_MANUAL" , ""},
                { "APOLICES_PCT_DESC_PREMIO" , ""},
                { "APOLICES_PCT_IOCC" , ""},
                { "APOLICES_TIPO_COSSEGURO_CED" , ""},
                { "APOLICES_QTD_COSSEGURADORA" , ""},
                { "APOLICES_PCT_COSSEGURO_CED" , ""},
                { "APOLICES_DATA_SORTEIO" , ""},
                { "APOLICES_COD_EMPRESA" , ""},
                { "APOLICES_TIPO_CORRETAGEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1", q23);

            #endregion

            #region R3250_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ORGAO_EMISSOR" , ""},
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3250_00_SELECT_FONTES_DB_SELECT_1_Query1", q24);

            #endregion

            #region R3300_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q25);

            #endregion

            #region R3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "FONTES_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1", q26);

            #endregion

            #region R3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_LIBERACAO" , ""},
                { "ENDOSSOS_DATA_EMISSAO" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_BCO_RCAP" , ""},
                { "ENDOSSOS_AGE_RCAP" , ""},
                { "ENDOSSOS_DAC_RCAP" , ""},
                { "ENDOSSOS_TIPO_RCAP" , ""},
                { "ENDOSSOS_BCO_COBRANCA" , ""},
                { "ENDOSSOS_AGE_COBRANCA" , ""},
                { "ENDOSSOS_DAC_COBRANCA" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_PLANO_SEGURO" , ""},
                { "ENDOSSOS_PCT_ENTRADA" , ""},
                { "ENDOSSOS_PCT_ADIC_FRACIO" , ""},
                { "ENDOSSOS_QTD_DIAS_PRIMEIRA" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "ENDOSSOS_QTD_PRESTACOES" , ""},
                { "ENDOSSOS_QTD_ITENS" , ""},
                { "ENDOSSOS_COD_TEXTO_PADRAO" , ""},
                { "ENDOSSOS_COD_ACEITACAO" , ""},
                { "ENDOSSOS_COD_MOEDA_IMP" , ""},
                { "ENDOSSOS_COD_MOEDA_PRM" , ""},
                { "ENDOSSOS_TIPO_ENDOSSO" , ""},
                { "ENDOSSOS_COD_USUARIO" , ""},
                { "ENDOSSOS_OCORR_ENDERECO" , ""},
                { "ENDOSSOS_SIT_REGISTRO" , ""},
                { "ENDOSSOS_DATA_RCAP" , ""},
                { "ENDOSSOS_COD_EMPRESA" , ""},
                { "ENDOSSOS_TIPO_CORRECAO" , ""},
                { "ENDOSSOS_ISENTA_CUSTO" , ""},
                { "ENDOSSOS_DATA_VENCIMENTO" , ""},
                { "ENDOSSOS_COEF_PREFIX" , ""},
                { "ENDOSSOS_VAL_CUSTO_EMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCELAS_DAC_PARCELA" , ""},
                { "PARCELAS_COD_FONTE" , ""},
                { "PARCELAS_NUM_TITULO" , ""},
                { "PARCELAS_PRM_TARIFARIO_IX" , ""},
                { "PARCELAS_VAL_DESCONTO_IX" , ""},
                { "PARCELAS_PRM_LIQUIDO_IX" , ""},
                { "PARCELAS_ADICIONAL_FRAC_IX" , ""},
                { "PARCELAS_VAL_CUSTO_EMIS_IX" , ""},
                { "PARCELAS_VAL_IOCC_IX" , ""},
                { "PARCELAS_PRM_TOTAL_IX" , ""},
                { "PARCELAS_OCORR_HISTORICO" , ""},
                { "PARCELAS_QTD_DOCUMENTOS" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "PARCELAS_COD_EMPRESA" , ""},
                { "PARCELAS_SITUACAO_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_COD_USUARIO" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_OCORR_HISTORICO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_MODALI_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_IMP_SEGURADA_VAR" , ""},
                { "APOLICOB_PRM_TARIFARIO_VAR" , ""},
                { "APOLICOB_PCT_COBERTURA" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
                { "APOLICOB_COD_EMPRESA" , ""},
                { "APOLICOB_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q30);

            #endregion

            #region R5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_EMPRESA" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_MOVIMENTO" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_DATA_ENVIO" , ""},
                { "MOVDEBCE_DATA_RETORNO" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
                { "MOVDEBCE_NSAS" , ""},
                { "MOVDEBCE_COD_USUARIO" , ""},
                { "MOVDEBCE_NUM_REQUISICAO" , ""},
                { "MOVDEBCE_NUM_CARTAO" , ""},
                { "MOVDEBCE_SEQUENCIA" , ""},
                { "MOVDEBCE_NUM_LOTE" , ""},
                { "MOVDEBCE_DTCREDITO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
                { "MOVDEBCE_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1", q31);

            #endregion

            #region R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "WSCOR99_DATA_INIVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q32);

            #endregion

            #region R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1", q33);

            #endregion

            #region R6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "APOLICOR_NUM_APOLICE" , ""},
                { "APOLICOR_RAMO_COBERTURA" , ""},
                { "APOLICOR_MODALI_COBERTURA" , ""},
                { "APOLICOR_COD_CORRETOR" , ""},
                { "APOLICOR_COD_SUBGRUPO" , ""},
                { "APOLICOR_DATA_INIVIGENCIA" , ""},
                { "APOLICOR_DATA_TERVIGENCIA" , ""},
                { "APOLICOR_PCT_PART_CORRETOR" , ""},
                { "APOLICOR_PCT_COM_CORRETOR" , ""},
                { "APOLICOR_TIPO_COMISSAO" , ""},
                { "APOLICOR_IND_CORRETOR_PRIN" , ""},
                { "APOLICOR_COD_EMPRESA" , ""},
                { "APOLICOR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1", q34);

            #endregion

            #region R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_FONTE" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1", q35);

            #endregion

            #region R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1", q36);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("BI6252B1_Saida1.txt")]
        public static void BI6252B_Tests_Theory_ProcessingOK_ReturnCode_0(string BI6252B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            BI6252B1_FILE_NAME_P = $"{BI6252B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-02-16"},
                { "WSHOST_DTMOVABE20" , "2025-02-16"},
                { "WSHOST_DTTERCOT" , "2024-12-27"},
                { "WSHOST_DTINICOT" , "2023-10-27"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #region BI6252B_V0COTACAO

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_DATA_INIVIGENCIA" , "2009-04-01"},
                { "MOEDACOT_DATA_TERVIGENCIA" , "2009-04-30"},
                { "MOEDACOT_VAL_VENDA" , "0.480000000"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6252B_V0COTACAO");
                AppSettings.TestSet.DynamicData.Add("BI6252B_V0COTACAO", q1);

                #endregion
                #region BI6252B_V0MOVIMCOB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , "0"},
                { "MOVIMCOB_COD_MOVIMENTO" , "0"},
                { "MOVIMCOB_COD_BANCO" , "104"},
                { "MOVIMCOB_COD_AGENCIA" , "7581"},
                { "MOVIMCOB_NUM_AVISO" , "21000"},
                { "MOVIMCOB_NUM_FITA" , "6946"},
                { "MOVIMCOB_DATA_MOVIMENTO" , "2025-02-16"},
                { "MOVIMCOB_DATA_QUITACAO" , "2025-02-16"},
                { "MOVIMCOB_NUM_TITULO" , "0"},
                { "MOVIMCOB_NUM_APOLICE" , "10019790324"},
                { "MOVIMCOB_NUM_ENDOSSO" , "1"},
                { "MOVIMCOB_NUM_PARCELA" , "0"},
                { "MOVIMCOB_VAL_TITULO" , "38.50"},
                { "MOVIMCOB_VAL_CREDITO" , "38.50"},
                { "MOVIMCOB_SIT_REGISTRO" , "3"},
                { "MOVIMCOB_NOME_SEGURADO" , "000000002                               "},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , "0"},
                { "MOVIMCOB_TIPO_MOVIMENTO" , "Y"},
                { "WSGER00_DATA_INIVIGENCIA" , ""},
                { "WSGER00_DATA_TERVIGENCIA" , "2025-02-16"},
                { "WSGER00_DATA_VENCIMENTO" , "2025-02-20"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6252B_V0MOVIMCOB");
                AppSettings.TestSet.DynamicData.Add("BI6252B_V0MOVIMCOB", q2);

                #endregion
                #region R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , "90351090005436"},
                { "CONVERSI_COD_PRODUTO_SIVPF" , "3701"},
                { "BILHETE_NUM_BILHETE" , "000095414536254"},
                { "BILHETE_NUM_APOLICE" , "103700256083"},
                { "BILHETE_FONTE" , "21"},
                { "BILHETE_AGE_COBRANCA" , "351"},
                { "BILHETE_NUM_MATRICULA" , "210145072"},
                { "BILHETE_COD_AGENCIA" , "0"},
                { "BILHETE_OPERACAO_CONTA" , "0"},
                { "BILHETE_NUM_CONTA" , "0"},
                { "BILHETE_DIG_CONTA" , "0"},
                { "BILHETE_COD_CLIENTE" , "4091"},
                { "BILHETE_OCORR_ENDERECO" , "6"},
                { "BILHETE_COD_AGENCIA_DEB" , "0"},
                { "BILHETE_OPERACAO_CONTA_DEB" , "0"},
                { "BILHETE_NUM_CONTA_DEB" , "0"},
                { "BILHETE_DIG_CONTA_DEB" , "0"},
                { "BILHETE_OPC_COBERTURA" , "1"},
                { "BILHETE_DATA_QUITACAO" , "2014-02-05"},
                { "BILHETE_VAL_RCAP" , "30.00"},
                { "BILHETE_RAMO" , "37"},
                { "BILHETE_DATA_VENDA" , "2014-02-05"},
                { "BILHETE_SITUACAO" , "L"},
                { "CLIENTES_NOME_RAZAO" , "PEDRO RODRIGUES DA COSTA DORIA          "},
                { "WSHOST_NOME_RAZAO" , "PEDRO RODRIGUES DA COSTA DORIA          "},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_CGCCPF" , "2961253853"},
                { "CLIENTES_DATA_NASCIMENTO" , "1944-03-07"},
                { "CLIENTES_IDE_SEXO" , ""},
                { "CLIENTES_ESTADO_CIVIL" , ""},
                { "ENDERECO_CIDADE" , "SAO JOSE DOS CAMPOS                                                     "},
                { "WSHOST_CIDADE" , "SAO JOSE DOS CAMPOS                                                     "},
                { "ENDERECO_SIGLA_UF" , "SP"},
                { "WSHOST_SIGLA_UF" , "SP"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1", q3);

                #endregion
                #region R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1", q6);

                #endregion
                #region R1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1", q10);

                #endregion
                #region R1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q14);

                #endregion

                #region R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "BILHECOB_COD_MOEDA" , "1"},
                { "BILHECOB_PCT_COM_CORRETOR" , "23.65"},
                { "BILHECOB_IMP_SEGURADA_IX" , "20000.00"},
                { "BILHECOB_PRM_TARIFARIO_IX" , "40.00000"},
                { "BILHECOB_PRM_TOTAL" , "38.50"},
                { "BILHECOB_PCT_IOCC" , "4.00"},
                { "RAMOCOMP_PCT_IOCC_RAMO" , "7.00"},
                { "WSHOST_PCT_IOCC" , "0.0700000000000000000000"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1", q17);

                #endregion
                #region R1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-15"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                q19.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , "1991-01-01"},
                { "CALENDAR_DTH_ULT_DIA_MES" , "2025-02-17"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q19);

                #endregion

                #region R3250_00_SELECT_FONTES_DB_SELECT_1_Query1

                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ORGAO_EMISSOR" , "10"},
                { "FONTES_ULT_PROP_AUTOMAT" , "14209"},
                }); 
                q24.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ORGAO_EMISSOR" , "10"},
                { "FONTES_ULT_PROP_AUTOMAT" , "9020279"},
                });
                q24.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ORGAO_EMISSOR" , "10"},
                { "FONTES_ULT_PROP_AUTOMAT" , "950544902"},
                });
                q24.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ORGAO_EMISSOR" , "10"},
                { "FONTES_ULT_PROP_AUTOMAT" , "950961111"},
                });
                q24.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ORGAO_EMISSOR" , "10"},
                { "FONTES_ULT_PROP_AUTOMAT" , "9024805"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3250_00_SELECT_FONTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3250_00_SELECT_FONTES_DB_SELECT_1_Query1", q24);

                #endregion
                #region R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1

                var q33 = new DynamicData();
                q33.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "60"}
                });
                q33.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "60"}
                });
                q33.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_EMPRESA" , "60"}
                });
                AppSettings.TestSet.DynamicData.Remove("R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1", q33);

                #endregion

                #endregion
                var program = new BI6252B();
                program.Execute(BI6252B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.W.LD_MOVIMCOB == 1);
                
                //R1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("PESSOA_NOME_PESSOA", out var valor00) && valor00.Contains("PEDRO RODRIGUES DA COSTA DORIA          "));
                Assert.True(envList0.Count > 1);

                //R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PESSOFIS_CPF", out var valor01) && valor01.Contains("02961253853"));
                Assert.True(envList1.Count > 1);
                
                //R1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("COD_RELAC", out var valor02) && valor02.Contains("0004"));
                Assert.True(envList2.Count > 1);

                //R1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("IDENTREL_COD_USUARIO", out var valor03) && valor03.Contains("BI6252B"));
                Assert.True(envList3.Count > 1);

                //R1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("PROPOFID_NUM_SICOB", out var valor04) && valor04.Contains("000095414536254"));
                Assert.True(envList4.Count > 1);

                //R3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("APOLICES_NUM_APOLICE", out var valor05) && valor05.Contains("0103700256083"));
                Assert.True(envList5.Count > 1);

                //R3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1
                var envList6 = AppSettings.TestSet.DynamicData["R3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("FONTES_ULT_PROP_AUTOMAT", out var valor06) && valor06.Contains("000014211"));

                //R3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["R3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("ENDOSSOS_COD_PRODUTO", out var valor07) && valor07.Contains("3701"));
                Assert.True(envList7[1].TryGetValue("ENDOSSOS_NUM_PROPOSTA", out var valor071) && valor071.Contains("000014211"));
                Assert.True(envList7.Count > 1);

                //R3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1
                var envList8 = AppSettings.TestSet.DynamicData["R3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("PARCELAS_NUM_APOLICE", out var valor08) && valor08.Contains("0103700256083"));
                Assert.True(envList8.Count > 1);

                //R3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1
                var envList9 = AppSettings.TestSet.DynamicData["R3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("PARCEHIS_BCO_COBRANCA", out var valor09) && valor09.Contains("0104"));
                Assert.True(envList9[1].TryGetValue("PARCEHIS_COD_OPERACAO", out var valor091) && valor091.Contains("0101"));
                Assert.True(envList9.Count > 1);

                //R3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1
                var envList10 = AppSettings.TestSet.DynamicData["R3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("APOLICOB_RAMO_COBERTURA", out var valor10) && valor10.Contains("0037"));
                Assert.True(envList10.Count > 1);

                //R5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1
                var envList11 = AppSettings.TestSet.DynamicData["R5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList11[1].TryGetValue("MOVDEBCE_NUM_APOLICE", out var valor11) && valor11.Contains("0103700256083"));
                Assert.True(envList11[1].TryGetValue("MOVDEBCE_NUM_ENDOSSO", out var valor111) && valor111.Contains("000000013"));
                Assert.True(envList11.Count > 1);
                
                //R6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1
                var envList12 = AppSettings.TestSet.DynamicData["R6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList12[1].TryGetValue("APOLICOR_RAMO_COBERTURA", out var valor12) && valor12.Contains("0037"));
                Assert.True(envList12[1].TryGetValue("APOLICOR_COD_CORRETOR", out var valor121) && valor121.Contains("000100081"));
                Assert.True(envList12.Count > 1);

                //R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1
                var envList13 = AppSettings.TestSet.DynamicData["R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList13[1].TryGetValue("BILHETE_SITUACAO", out var valor13) && valor13.Contains("9"));
                Assert.True(envList13[1].TryGetValue("BILHETE_NUM_BILHETE", out var valor131) && valor131.Contains("000095414536254"));

                //R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1
                var envList14 = AppSettings.TestSet.DynamicData["R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList14[1].TryGetValue("MOVIMCOB_NUM_APOLICE", out var valor14) && valor14.Contains("0010019790324"));

            }
        }
        [Theory]
        [InlineData("BI6252B1_Saida2.txt")]
        public static void BI6252B_Tests_Theory_NoProcessing_ReturnCode_0(string BI6252B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            BI6252B1_FILE_NAME_P = $"{BI6252B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-02-16"},
                { "WSHOST_DTMOVABE20" , "2025-02-16"},
                { "WSHOST_DTTERCOT" , "2024-12-27"},
                { "WSHOST_DTINICOT" , "2023-10-27"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI6252B_V0MOVIMCOB

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("BI6252B_V0MOVIMCOB");
                AppSettings.TestSet.DynamicData.Add("BI6252B_V0MOVIMCOB", q2);


                #endregion
                #endregion

                var program = new BI6252B();
                program.Execute(BI6252B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.W.LD_MOVIMCOB == 0);
            }
        }
        [Theory]
        [InlineData("BI6252B1_Saida3.txt")]
        public static void BI6252B_Tests_Theory_Error_ReturnCode_99(string BI6252B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            BI6252B1_FILE_NAME_P = $"{BI6252B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2025-02-16"},
                { "WSHOST_DTMOVABE20" , "2025-02-16"},
                { "WSHOST_DTTERCOT" , "2024-12-27"},
                { "WSHOST_DTINICOT" , "2023-10-27"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI6252B_V0MOVIMCOB

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_EMPRESA" , ""},
                { "MOVIMCOB_COD_MOVIMENTO" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_NUM_FITA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("BI6252B_V0MOVIMCOB");
                AppSettings.TestSet.DynamicData.Add("BI6252B_V0MOVIMCOB", q2);


                #endregion
                #endregion

                var program = new BI6252B();
                program.Execute(BI6252B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
                Assert.True(program.W.LD_MOVIMCOB == 0);
            }
        }
    }
}