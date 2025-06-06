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
using static Code.SI0005B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0005B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0005B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R010_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "HOST_DATA_CORRENTE" , ""},
                { "HOST_HORA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region R030_SELECT_FONTES_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NUM_PROTOCOLO_SINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R030_SELECT_FONTES_DB_SELECT_1_Query1", q2);

            #endregion

            #region R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R035_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R050_ALTERA_FONTES_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NUM_PROTOCOLO_SINI" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R050_ALTERA_FONTES_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "NUMERAES_SEQ_SINISTRO" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R105_ROTINA_CRITICA_HEADER_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R105_ROTINA_CRITICA_HEADER_DB_SELECT_1_Query1", q6);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_2_Query1", q8);

            #endregion

            #region R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_QT_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1_Query1", q9);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_3_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_3_Query1", q10);

            #endregion

            #region R111_VERIFICA_PGTO_PREMIO_DB_SELECT_2_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "HOST_PAGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R111_VERIFICA_PGTO_PREMIO_DB_SELECT_2_Query1", q11);

            #endregion

            #region R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HOST_PAGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1", q12);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_4_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_4_Query1", q13);

            #endregion

            #region R111_VERIFICA_PGTO_PREMIO_DB_SELECT_4_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HOST_PAGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R111_VERIFICA_PGTO_PREMIO_DB_SELECT_4_Query1", q14);

            #endregion

            #region R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1", q16);

            #endregion

            #region R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_DT_CANCELAMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2_Query1", q17);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1", q18);

            #endregion

            #region R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "LOTISG01_IMP_SEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1", q19);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_COD_LOT_CEF" , ""},
                { "LOTERI01_COD_LOT_FENAL" , ""},
                { "LOTERI01_COD_CLIENTE" , ""},
                { "LOTERI01_NUM_APOLICE" , ""},
                { "LOTERI01_DTINIVIG" , ""},
                { "LOTERI01_DTTERVIG" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_7_Query1", q20);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_MODALIDADE" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "APOLICES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_8_Query1", q21);

            #endregion

            #region R700_CRITICA_APOL_POR_LOT_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "OUTROCOB_IMP_SEGURADA_IX" , ""},
                { "OUTROCOB_DATA_INIVIGENCIA" , ""},
                { "OUTROCOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R700_CRITICA_APOL_POR_LOT_DB_SELECT_1_Query1", q22);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_9_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_GRUPO_CAUSAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_9_Query1", q23);

            #endregion

            #region R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "OUTROCOB_IMP_SEGURADA_IX" , ""},
                { "OUTROCOB_DATA_INIVIGENCIA" , ""},
                { "OUTROCOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1", q24);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1", q25);

            #endregion

            #region R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_TOT_PREMIO_TAR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1", q26);

            #endregion

            #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "HOST_DATA_INIVIGENCIA" , ""},
                { "HOST_DATA_TERVIGENCIA" , ""},
                { "HOST_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1", q27);

            #endregion

            #region R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_TOT_PREMIO_PAGO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2_Query1", q28);

            #endregion

            #region R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_FIM_PRAZO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3_Query1", q29);

            #endregion

            #region R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_COD_CLASSE_ADESAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R750_ACHA_VALOR_BASE_DB_SELECT_1_Query1", q30);

            #endregion

            #region R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "OUTROCOB_IMP_SEGURADA_IX" , ""},
                { "OUTROCOB_DATA_INIVIGENCIA" , ""},
                { "OUTROCOB_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4_Query1", q31);

            #endregion

            #region SI0005B_SINISTRO_APOL

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "W_HOST_VALOR_AVISADO_OPER_101" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0005B_SINISTRO_APOL", q32);

            #endregion

            #region SI0005B_DOCUMENTOS

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "SILOTDC2_COD_DOCUMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("SI0005B_DOCUMENTOS", q33);

            #endregion

            #region R8100_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_1" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8100_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1", q34);

            #endregion

            #region R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_FRANQUIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1", q35);

            #endregion

            #region R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_CALCULADO_99" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1", q36);

            #endregion

            #region R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "W_HOST_VALOR_ADIANTA2" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1", q37);

            #endregion

            #region R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "SIPARADI_COD_PRODUTO" , ""},
                { "SIPARADI_COD_COBERTURA" , ""},
                { "SIPARADI_PERC_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1", q38);

            #endregion

            #region R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "LOTERI01_BANCO" , ""},
                { "LOTERI01_AGENCIA" , ""},
                { "LOTERI01_OPERACAO_CONTA" , ""},
                { "LOTERI01_NUMERO_CONTA" , ""},
                { "LOTERI01_DV_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1", q39);

            #endregion

            #region R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2_Query1", q40);

            #endregion

            #region R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "SIPARADI_COD_PRODUTO" , ""},
                { "SIPARADI_COD_COBERTURA" , ""},
                { "SIPARADI_PERC_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1", q41);

            #endregion

            #region R1000_GRAVA_SINISTRO_DB_UPDATE_1_Update1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_GRAVA_SINISTRO_DB_UPDATE_1_Update1", q42);

            #endregion

            #region R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "HOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3_Query1", q43);

            #endregion

            #region R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "SINISCON_COD_FONTE" , ""},
                { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                { "SINISCON_NUM_APOLICE" , ""},
                { "SINISCON_COD_SUBGRUPO" , ""},
                { "SINISCON_OCORR_HISTORICO" , ""},
                { "SINISCON_PEND_VISTORIA" , ""},
                { "SINISCON_PEND_RESSEGURO" , ""},
                { "SINISCON_SIT_REGISTRO" , ""},
                { "SINISCON_PEND_VIST_COMPL" , ""},
                { "SINISCON_COD_EMPRESA" , ""},
                { "SINISCON_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R1020_INCLUI_SINISACO_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "SINISACO_COD_FONTE" , ""},
                { "SINISACO_NUM_PROTOCOLO_SINI" , ""},
                { "SINISACO_DAC_PROTOCOLO_SINI" , ""},
                { "SINISACO_COD_OPERACAO" , ""},
                { "SINISACO_DATA_OPERACAO" , ""},
                { "SINISACO_HORA_OPERACAO" , ""},
                { "SINISACO_OCORR_HISTORICO" , ""},
                { "SINISACO_COD_USUARIO" , ""},
                { "SINISACO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_INCLUI_SINISACO_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_COD_EMPRESA" , ""},
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINISMES_DAC_PROTOCOLO_SINI" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_ENDOSSO" , ""},
                { "SINISMES_COD_SUBGRUPO" , ""},
                { "SINISMES_NUM_CERTIFICADO" , ""},
                { "SINISMES_DAC_CERTIFICADO" , ""},
                { "SINISMES_TIPO_SEGURADO" , ""},
                { "SINISMES_NUM_EMBARQUE" , ""},
                { "SINISMES_REF_EMBARQUE" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_COD_LIDER" , ""},
                { "SINISMES_NUM_SINI_LIDER" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_TECNICA" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_NUM_IRB" , ""},
                { "SINISMES_NUM_AVISO_IRB" , ""},
                { "SINISMES_COD_MOEDA_SINI" , ""},
                { "SINISMES_SALDO_PAGAR_IX" , ""},
                { "SINISMES_TOT_PAGAMENTO_IX" , ""},
                { "SINISMES_SALDO_RECUPERAR_IX" , ""},
                { "SINISMES_TOT_RECUPERADO_IX" , ""},
                { "SINISMES_SALDO_RESSARCIR_IX" , ""},
                { "SINISMES_TOT_RESSARCIDO_IX" , ""},
                { "SINISMES_TOT_DESPESAS_IX" , ""},
                { "SINISMES_TOT_HONORARIOS_IX" , ""},
                { "SINISMES_ADIA_RECUPERAR_IX" , ""},
                { "SINISMES_ADIA_RECUPERADO_IX" , ""},
                { "SINISMES_IMP_SEGURADA_IX" , ""},
                { "SINISMES_PCT_PART_COSSEGURO" , ""},
                { "SINISMES_PCT_PART_RESSEGURO" , ""},
                { "SINISMES_APROVACAO_ALCADA" , ""},
                { "SINISMES_IND_SALVADO" , ""},
                { "SINISMES_INTEGRAL_ESPECIAL" , ""},
                { "SINISMES_NUM_MOV_SINI_ATU" , ""},
                { "SINISMES_NUM_MOV_SINI_ANT" , ""},
                { "SINISMES_DATA_ULT_MOVIMENTO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_BANCO_ORDEM_PAG" , ""},
                { "SINISMES_AGENCIA_ORDEM_PAG" , ""},
                { "SINISMES_TIPO_PAGAMENTO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_NUMERO_ORDEM" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1", q46);

            #endregion

            #region R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "SINILT01_COD_LOT_FENAL" , ""},
                { "SINILT01_NUM_APOLICE" , ""},
                { "SINILT01_NUM_APOL_SINISTRO" , ""},
                { "SINILT01_NUM_CONTROLE_FENAL" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "SINILT01_COD_CLIENTE" , ""},
                { "SINILT01_SITUACAO" , ""},
                { "SINILT01_DATA_GERA_MOV" , ""},
                { "SINILT01_COD_ORIGEM_AVISO" , ""},
                { "SINILT01_DTINIVIG" , ""},
                { "SINILT01_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1", q47);

            #endregion

            #region R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "SINIITEM_NUM_APOL_SINISTRO" , ""},
                { "SINIITEM_COD_CLIENTE" , ""},
                { "SINIITEM_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_INCLUI_SINIITEM_DB_INSERT_1_Insert1", q48);

            #endregion

            #region R1070_INCLUI_SINISHIS_DB_INSERT_1_Insert1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1070_INCLUI_SINISHIS_DB_INSERT_1_Insert1", q49);

            #endregion

            #region R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "SIMOLOT1_QTD_SINI_AVISADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1", q50);

            #endregion

            #region R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1

            var q51 = new DynamicData();
            q51.AddDynamic(new Dictionary<string, string>{
                { "SIMOLOT1_NUM_APOL_SINISTRO" , ""},
                { "SIMOLOT1_COD_LOT_CEF" , ""},
                { "SIMOLOT1_NOME_LOTERICO" , ""},
                { "SIMOLOT1_DATA_OCORRENCIA" , ""},
                { "SIMOLOT1_HORA_OCORRENCIA" , ""},
                { "SIMOLOT1_DATA_GERACAO_MOV" , ""},
                { "SIMOLOT1_DATA_AVISO" , ""},
                { "SIMOLOT1_HORA_AVISO" , ""},
                { "SIMOLOT1_VALOR_INFORMADO" , ""},
                { "SIMOLOT1_NATUREZA" , ""},
                { "SIMOLOT1_COD_CAUSA" , ""},
                { "SIMOLOT1_IND_CRITICA" , ""},
                { "SIMOLOT1_MENSAGEM" , ""},
                { "SIMOLOT1_VALOR_REGISTRADO" , ""},
                { "SIMOLOT1_VAL_IS" , ""},
                { "SIMOLOT1_VAL_ADIANTAMENTO" , ""},
                { "SIMOLOT1_PERC_ADIANTAMENTO" , ""},
                { "SIMOLOT1_COD_LOT_SASSE" , ""},
                { "SIMOLOT1_DATA_MOVIMENTO" , ""},
                { "SIMOLOT1_QTD_SINI_AVISADO" , ""},
                { "SIMOLOT1_QTD_SINI_PAGOS" , ""},
                { "SIMOLOT1_QTD_MESES" , ""},
                { "SIMOLOT1_DATA_ULT_DOC" , ""},
                { "SIMOLOT1_NUM_SINI_PREST" , ""},
                { "SIMOLOT1_QTD_PORTADORES" , ""},
                { "SIMOLOT1_IND_ADIANTAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1", q51);

            #endregion

            #region R1080_INCLUI_SIMOLOT1_DB_SELECT_2_Query1

            var q52 = new DynamicData();
            q52.AddDynamic(new Dictionary<string, string>{
                { "SIMOLOT1_QTD_SINI_PAGOS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1080_INCLUI_SIMOLOT1_DB_SELECT_2_Query1", q52);

            #endregion

            #region SI0005B_ADIANT_PEND

            var q53 = new DynamicData();
            q53.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINILT01_COD_LOT_CEF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "HOST_VALOR_AVISADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SIMOLOT1_VALOR_INFORMADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0005B_ADIANT_PEND", q53);

            #endregion

            #region R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1

            var q54 = new DynamicData();
            q54.AddDynamic(new Dictionary<string, string>{
                { "SINLOTDO_NUM_APOL_SINISTRO" , ""},
                { "SINLOTDO_COD_DOCUMENTO" , ""},
                { "SINLOTDO_DATA_RECEBE" , ""},
                { "SINLOTDO_CODUSU_RECEBE" , ""},
                { "SINLOTDO_DATA_SOLICITA" , ""},
                { "SINLOTDO_TMSP_MOV_SOLICITA" , ""},
                { "SINLOTDO_CODUSU_SOLICITA" , ""},
                { "SINLOTDO_SITUACAO" , ""},
                { "SINLOTDO_TMSP_MOV_SITUACAO" , ""},
                { "SINLOTDO_CODUSU_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1", q54);

            #endregion

            #region R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1

            var q55 = new DynamicData();
            q55.AddDynamic(new Dictionary<string, string>{
                { "LTMVPROP_COD_EXT_SEGURADO" , ""},
                { "LTMVPROP_COD_PESSOA_SOCIO" , ""},
                { "LTMVPROP_NUM_PROPOSTA" , ""},
                { "LTMVPROP_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1", q55);

            #endregion

            #region R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1

            var q56 = new DynamicData();
            q56.AddDynamic(new Dictionary<string, string>{
                { "GEPESJUR_NUM_CNPJ" , ""},
                { "GEPESJUR_NOM_FANTASIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1", q56);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("TRANS.SI.CLP.D241128", "RETORNO_00", "RCRITICA_00")]
        public static void SI0005B_Tests_TheoryD241128(string AVISO_FILE_NAME_P, string RETORNO_FILE_NAME_P, string RCRITICA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETORNO_FILE_NAME_P = $"{RETORNO_FILE_NAME_P}_{timestamp}.txt";
            RCRITICA_FILE_NAME_P = $"{RCRITICA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                                                                                                               "}
            });
                AppSettings.TestSet.DynamicData.Add("R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion
                #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1");
                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1", q16);

                #endregion
                /*#region R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1");
                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1", q25);

                #endregion*/
                #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1");
                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1", q18);
                #endregion

                #endregion
                var program = new SI0005B();
                program.Execute(AVISO_FILE_NAME_P, RETORNO_FILE_NAME_P, RCRITICA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RETORNO.FilePath));
                Assert.True(new FileInfo(program.RETORNO.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.RCRITICA.FilePath));
                Assert.True(new FileInfo(program.RCRITICA.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 0);

                var envList = AppSettings.TestSet.DynamicData["R050_ALTERA_FONTES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("FONTES_NUM_PROTOCOLO_SINI", out var valor) && valor == "000000000");


            }
        }

        [Theory]
        [InlineData("TRANS.SI.CLP.D241202", "RETORNO_01", "RCRITICA_01")]
        public static void SI0005B_Tests_TheoryD241202(string AVISO_FILE_NAME_P, string RETORNO_FILE_NAME_P, string RCRITICA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETORNO_FILE_NAME_P = $"{RETORNO_FILE_NAME_P}_{timestamp}.txt";
            RCRITICA_FILE_NAME_P = $"{RCRITICA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                                                                                                               "}
            });
                AppSettings.TestSet.DynamicData.Add("R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion
                #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1");
                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1", q16);

                #endregion
                /*#region R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1");
                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1", q25);

                #endregion*/
                #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1");
                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1", q18);
                #endregion

                #endregion
                var program = new SI0005B();
                program.Execute(AVISO_FILE_NAME_P, RETORNO_FILE_NAME_P, RCRITICA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RETORNO.FilePath));
                Assert.True(new FileInfo(program.RETORNO.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.RCRITICA.FilePath));
                Assert.True(new FileInfo(program.RCRITICA.FilePath)?.Length > 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("TRANS.SI.CLP.D241126", "RETORNO_02", "RCRITICA_02")]
        public static void SI0005B_Tests_TheoryD241126(string AVISO_FILE_NAME_P, string RETORNO_FILE_NAME_P, string RCRITICA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETORNO_FILE_NAME_P = $"{RETORNO_FILE_NAME_P}_{timestamp}.txt";
            RCRITICA_FILE_NAME_P = $"{RCRITICA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                                                                                                               "}
            });
                AppSettings.TestSet.DynamicData.Add("R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion
                #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1");
                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_5_Query1", q16);

                #endregion
                /*#region R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1");
                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1", q25);

                #endregion*/
                #region R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1
                AppSettings.TestSet.DynamicData.Remove("R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1");
                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "HOST_ACHA_LOTERICO" , "01"}
            });
                AppSettings.TestSet.DynamicData.Add("R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1", q18);
                #endregion

                #endregion
                var program = new SI0005B();
                program.Execute(AVISO_FILE_NAME_P, RETORNO_FILE_NAME_P, RCRITICA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.RETORNO.FilePath));
                Assert.True(new FileInfo(program.RETORNO.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.RCRITICA.FilePath));
                Assert.True(new FileInfo(program.RCRITICA.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R050_ALTERA_FONTES_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("FONTES_NUM_PROTOCOLO_SINI", out var valor) && valor == "000000000");

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("TRANS.SI.CLP.D241126", "RETORNO_03", "RCRITICA_03")]
        public static void SI0005B_Tests_TheoryErro(string AVISO_FILE_NAME_P, string RETORNO_FILE_NAME_P, string RCRITICA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RETORNO_FILE_NAME_P = $"{RETORNO_FILE_NAME_P}_{timestamp}.txt";
            RCRITICA_FILE_NAME_P = $"{RCRITICA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R010_LE_SISTEMAS_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R010_LE_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R010_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new SI0005B();
                program.Execute(AVISO_FILE_NAME_P, RETORNO_FILE_NAME_P, RCRITICA_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}