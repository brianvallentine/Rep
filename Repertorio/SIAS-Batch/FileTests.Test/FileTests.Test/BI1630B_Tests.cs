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
using static Code.BI1630B;

namespace FileTests.Test
{
    [Collection("BI1630B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI1630B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados


        public static void Load_Parameters_BI0005S()
        {
            #region BI0005S

            #region M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_NOME_PESSOA" , "MARIA FRANCISCA DA SILVA AGOSTINHO"},
                { "BI0005L_S_TIPO_PESSOA" , "F"},
                { "BI0005L_S_SIGLA_PESSOA" , "1"},
                });
            AppSettings.TestSet.DynamicData.Remove("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1", q30);

            #endregion

            #region M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_CPF" , "99450330425"},
                { "BI0005L_S_DATA_NASC" , "1929-05-15"},
                { "BI0005L_S_SEXO" , "F"},
                { "BI0005L_S_ESTADO_CIVIL" , "C"},
                { "BI0005L_S_NUM_IDENT" , "000000000000000"},
                { "BI0005L_S_ORGAO_EXPED" , "X"},
                { "BI0005L_S_UF_EXPEDIDORA" , "X"},
                { "BI0005L_S_DATA_EXPED" , "2021-01-01"},
                { "BI0005L_S_COD_CBO" , "924"},
                { "BI0005L_S_TIP_IDE_SIVPF" , "X"},
                });
            AppSettings.TestSet.DynamicData.Remove("M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1");
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1", q31);

            #endregion

            #region M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "1"}
                });
            q32.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "2"}
                });
            q32.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_TEL" , "3"}
                });
            AppSettings.TestSet.DynamicData.Remove("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1", q32);

            #endregion

            #region M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_CGC" , "64414906415"},
                { "BI0005L_S_NOME_FANTASIA" , "NIEDJA BERTHOLINO CAFE SANTOS"},
                });
            AppSettings.TestSet.DynamicData.Remove("M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1");
            AppSettings.TestSet.DynamicData.Add("M_30000_00_TRATA_PESSOA_DB_SELECT_3_Query1", q33);

            #endregion

            #region M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , "1"},
                { "DDI" , "55"},
                { "DDD" , "82"},
                { "NUM_FONE" , "3362802"},
                { "SITUACAO_FONE" , "A"},
                });
            q34.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , "2"},
                { "DDI" , "55"},
                { "DDD" , "82"},
                { "NUM_FONE" , "3362802"},
                { "SITUACAO_FONE" , "A"},
                });
            q34.AddDynamic(new Dictionary<string, string>{
                { "TIPO_FONE" , "2"},
                { "DDI" , "55"},
                { "DDD" , "82"},
                { "NUM_FONE" , "3362802"},
                { "SITUACAO_FONE" , "A"},
                });

            AppSettings.TestSet.DynamicData.Remove("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1");
            AppSettings.TestSet.DynamicData.Add("M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1", q34);

            #endregion

            #region M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_SEQ_EMA" , "100"}
                });
            AppSettings.TestSet.DynamicData.Remove("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q35);

            #endregion

            #region M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_EMAIL" , "NAOPOSSUI10@HOTMAIL.COM"},
                { "BI0005L_S_SIT_EMAIL" , "A"},
                });
            AppSettings.TestSet.DynamicData.Remove("M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1");
            AppSettings.TestSet.DynamicData.Add("M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1", q36);

            #endregion

            #region M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , "1"}
                });
            AppSettings.TestSet.DynamicData.Remove("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1", q37);

            #endregion

            #region M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_ENDERECO_R" , "1"},
                { "BI0005L_S_OCC_END_R" , "1"},
                { "BI0005L_S_TIPO_ENDER_R" , "1"},
                { "BI0005L_S_COMPL_ENDER_R" , "1"},
                { "BI0005L_S_BAIRRO_R" , "1"},
                { "BI0005L_S_CEP_R" , "1"},
                { "BI0005L_S_CIDADE_R" , "1"},
                { "BI0005L_S_SIGLA_UF_R" , "1"},
                { "BI0005L_S_SIT_ENDER_R" , "1"},
                });
            AppSettings.TestSet.DynamicData.Remove("M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1");
            AppSettings.TestSet.DynamicData.Add("M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1", q38);

            #endregion

            #region B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_OCO_END" , "100"}
                });
            AppSettings.TestSet.DynamicData.Remove("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1", q39);

            #endregion

            #region B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_ENDERECO_C" , "1"},
                { "BI0005L_S_OCC_END_C" , "1"},
                { "BI0005L_S_TIPO_ENDER_C" , "1"},
                { "BI0005L_S_COMPL_ENDER_C" , "1"},
                { "BI0005L_S_BAIRRO_C" , "1"},
                { "BI0005L_S_CEP_C" , "1"},
                { "BI0005L_S_CIDADE_C" , "1"},
                { "BI0005L_S_SIGLA_UF_C" , "1"},
                { "BI0005L_S_SIT_ENDER_C" , "1"},
                });
            AppSettings.TestSet.DynamicData.Remove("B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1");
            AppSettings.TestSet.DynamicData.Add("B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1", q40);

            #endregion

            #endregion
        }

        public static void Load_Parameters_SPBVG009()
        {
            #region SPBVG009

            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q1000 = new DynamicData();
            q1000.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
            AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q1000);

            #endregion

            #region P0301_05_INICIO_DB_SELECT_1_Query1

            var q2000 = new DynamicData();
            q2000.AddDynamic(new Dictionary<string, string>{
                { "VG113_COD_PESSOA" , "1"},
                { "VG113_SEQ_PESSOA_HIST" , "2"},
                { "VG113_COD_CLASSIF_RISCO" , "3"},
                { "VG113_NUM_SCORE_RISCO" , "12"},
                { "VG113_DTA_CLASSIF_RISCO" , "2020-01-01"},
                { "VG113_IND_PEND_APROVACAO" , "1"},
                { "VG113_IND_DECL_AUTOMATICO" , "2"},
                { "VG113_IND_ATLZ_FAIXA_RISCO" , "2"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0301_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0301_05_INICIO_DB_SELECT_1_Query1", q2000);

            #endregion

            #region P3021_05_INICIO_DB_SELECT_1_Query1

            var q3000 = new DynamicData();
            q3000.AddDynamic(new Dictionary<string, string>{
                { "VG110_COD_PESSOA" , "1"},
                { "VG110_SEQ_PESSOA_HIST" , "1"},
            });
            AppSettings.TestSet.DynamicData.Remove("P3021_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P3021_05_INICIO_DB_SELECT_1_Query1", q3000);

            #endregion

            #endregion
        }

        public static void Load_Parameters_GE0070S()
        {
            #region GE0070S

            #region P0101_05_INICIO_DB_SELECT_1_Query1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_DESCR_PRODUTO" , "X"}
                });
            AppSettings.TestSet.DynamicData.Remove("P0101_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0101_05_INICIO_DB_SELECT_1_Query1", q41);

            #endregion

            #region P0201_05_INICIO_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "GE089_COD_PRODUTO" , ""},
                { "GE089_SEQ_PRODUTO_VRS" , ""},
                { "GE089_DTA_INI_VIGENCIA" , ""},
                { "GE089_DTA_FIM_VIGENCIA" , ""},
                { "GE089_IND_FLUXO_PARAMTRIZADO" , "S"},
                { "GE089_COD_PERIOD_VIGENCIA" , ""},
                { "GE089_QTD_PERIOD_VIGENCIA" , ""},
                { "GE089_COD_MOEDA" , ""},
                { "GE089_IND_RENOVA" , ""},
                { "GE089_IND_RENOVA_AUTOMATICA" , ""},
                { "GE089_QTD_RENOVA_AUTOMATICA" , ""},
                { "GE089_IND_DPS" , ""},
                { "GE089_IND_REENQUADRA_PREMIO" , ""},
                { "GE089_IND_REAJUSTE_PREMIO" , ""},
                { "GE089_COD_INDICE_REAJUSTE" , ""},
                { "GE089_COD_PERIOD_REAJUSTE" , ""},
                { "GE089_COD_INDICE_DEVOLUCAO" , ""},
                { "GE089_PCT_JUROS_DEVOLUCAO" , ""},
                { "GE089_PCT_MULTA_DEVOLUCAO" , ""},
                { "GE089_IND_FLUXO_COMISSAO" , "S"},
                { "GE089_IND_ACOPLADO" , ""},
                { "GE089_IND_FLUXO_SINISTRO" , "S"},
                { "GE089_IND_CONJUGE" , ""},
                { "GE089_COD_USUARIO" , ""},
                { "GE089_NOM_PROGRAMA" , ""},
                { "GE089_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Remove("P0201_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0201_05_INICIO_DB_SELECT_1_Query1", q42);

            #endregion

            #region P0202_05_INICIO_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "GE089_COD_PRODUTO" , ""},
                { "GE089_SEQ_PRODUTO_VRS" , ""},
                { "GE089_DTA_INI_VIGENCIA" , ""},
                { "GE089_DTA_FIM_VIGENCIA" , ""},
                { "GE089_IND_FLUXO_PARAMTRIZADO" , "S"},
                { "GE089_COD_PERIOD_VIGENCIA" , ""},
                { "GE089_QTD_PERIOD_VIGENCIA" , ""},
                { "GE089_COD_MOEDA" , ""},
                { "GE089_IND_RENOVA" , ""},
                { "GE089_IND_RENOVA_AUTOMATICA" , ""},
                { "GE089_QTD_RENOVA_AUTOMATICA" , ""},
                { "GE089_IND_DPS" , ""},
                { "GE089_IND_REENQUADRA_PREMIO" , ""},
                { "GE089_IND_REAJUSTE_PREMIO" , ""},
                { "GE089_COD_INDICE_REAJUSTE" , ""},
                { "GE089_COD_PERIOD_REAJUSTE" , ""},
                { "GE089_COD_INDICE_DEVOLUCAO" , ""},
                { "GE089_PCT_JUROS_DEVOLUCAO" , ""},
                { "GE089_PCT_MULTA_DEVOLUCAO" , ""},
                { "GE089_IND_FLUXO_COMISSAO" , "S"},
                { "GE089_IND_ACOPLADO" , ""},
                { "GE089_IND_FLUXO_SINISTRO" , "S"},
                { "GE089_IND_CONJUGE" , ""},
                { "GE089_COD_USUARIO" , ""},
                { "GE089_NOM_PROGRAMA" , ""},
                { "GE089_DTH_CADASTRAMENTO" , ""},
                });
            AppSettings.TestSet.DynamicData.Remove("P0202_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0202_05_INICIO_DB_SELECT_1_Query1", q43);

            #endregion

            #endregion
        }

        public static void Load_Parameters_GE0071S()
        {
            #region E0071S

            #region GE0071S_GE0071S_C01

            var q100 = new DynamicData();
            q100.AddDynamic(new Dictionary<string, string>{
                { "GE091_COD_COBERTURA" , "1"},
                { "GE091_VLR_IS" , "12,"},
                { "GE091_VLR_PREMIO" , "3"},
                { "GE091_PCT_PARTICIPACAO" , "4"},
                { "GE118_IND_TIPO_COBERTURA" , "5"},
                { "GE118_IND_SINISTRO_CANCELA" , "6"},
                { "GE118_IND_INDENIZA_MAIS_VEZES" , "0"},
                { "GE118_COD_RAMO_COBERTURA" , "1"},
                { "GE118_DES_APRESENTA_DOC" , "x"},
            });
            AppSettings.TestSet.DynamicData.Remove("GE0071S_GE0071S_C01");
            AppSettings.TestSet.DynamicData.Add("GE0071S_GE0071S_C01", q100);

            #endregion

            /*  #region P0050_05_INICIO_DB_SELECT_1_Query1

              var q101 = new DynamicData();
              q101.AddDynamic(new Dictionary<string, string>{
              { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
          });
              AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
              AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q101);

              #endregion*/

            #region P0101_05_INICIO_DB_SELECT_1_Query1

            var q200 = new DynamicData();
            q200.AddDynamic(new Dictionary<string, string>{
                { "GE089_IND_FLUXO_PARAMTRIZADO" , "S"}
            });
            AppSettings.TestSet.DynamicData.Remove("P0101_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0101_05_INICIO_DB_SELECT_1_Query1", q200);

            #endregion

            #region P0201_05_INICIO_DB_SELECT_1_Query1

            var q300 = new DynamicData();
            q300.AddDynamic(new Dictionary<string, string>{
                { "GE090_COD_OPC_COBERTURA" , "33"},
                { "GE090_NUM_IDADE_INI" , "1"},
                { "GE090_NUM_IDADE_FIM" , "10"},
                { "GE090_COD_OPC_PLANO" , "22"},
                { "GE090_VLR_INI_PREMIO" , "20"},
                { "GE090_VLR_FIM_PREMIO" , "100"},
                { "GE090_PCT_IOF" , "2"},
                { "GE090_PCT_REENQUADRAMENTO" , ""},
                { "GE090_IND_PERMIT_VENDA" , "1"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0201_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0201_05_INICIO_DB_SELECT_1_Query1", q300);

            #endregion

            #region P0202_05_INICIO_DB_SELECT_1_Query1

            var q400 = new DynamicData();
            q400.AddDynamic(new Dictionary<string, string>{
                { "GE090_COD_OPC_COBERTURA" , "1"},
                { "GE090_NUM_IDADE_INI" , "2"},
                { "GE090_NUM_IDADE_FIM" , "3"},
                { "GE090_COD_OPC_PLANO" , "3"},
                { "GE090_VLR_INI_PREMIO" , "40"},
                { "GE090_VLR_FIM_PREMIO" , "41"},
                { "GE090_PCT_IOF" , "0"},
                { "GE090_PCT_REENQUADRAMENTO" , "1"},
                { "GE090_IND_PERMIT_VENDA" , "2"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0202_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0202_05_INICIO_DB_SELECT_1_Query1", q400);

            #endregion

            #endregion
        }

        public static void Load_Parameters_SPBVG001()
        {
            #region SPBVG001

           /* #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q102 = new DynamicData();
            q102.AddDynamic(new Dictionary<string, string>{
            { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
             });
            AppSettings.TestSet.DynamicData.Remove("P0050_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q102);

            #endregion*/

            #region P0110_05_INICIO_DB_SELECT_1_Query1

            var q103 = new DynamicData();
            q103.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "x"}
                });
            AppSettings.TestSet.DynamicData.Remove("P0110_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0110_05_INICIO_DB_SELECT_1_Query1", q103);

            #endregion

            #region P0111_05_INICIO_DB_SELECT_1_Query1

            var q201 = new DynamicData();
            q201.AddDynamic(new Dictionary<string, string>{
                { "USUFILSE_COD_CO" , ""},
                { "USUFILSE_SENHA" , ""},
                { "USUFILSE_NIVEL_AUTORIZACAO" , ""},
                { "USUFILSE_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0111_05_INICIO_DB_SELECT_1_Query1", q201);

            #endregion

            #region P0112_05_INICIO_DB_SELECT_1_Query1

            var q301 = new DynamicData();
            q301.AddDynamic(new Dictionary<string, string>{
                { "VG101_STA_CRITICA" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("P0112_05_INICIO_DB_SELECT_1_Query1", q301);

            #endregion

            #region P0120_05_INICIO_DB_SELECT_1_Query1

            var q401 = new DynamicData();
            q401.AddDynamic(new Dictionary<string, string>{
                { "VG102_DES_ABREV_MSG_CRITICA" , "x"},
                { "VG102_COD_TP_MSG_CRITICA" , "x"},
            });
            AppSettings.TestSet.DynamicData.Add("P0120_05_INICIO_DB_SELECT_1_Query1", q401);

            #endregion

            #region P0121_05_INICIO_DB_SELECT_1_Query1

            var q500 = new DynamicData();
            q500.AddDynamic(new Dictionary<string, string>{
                { "VG099_DES_STA_CRITICA" , "x"}
            });
            AppSettings.TestSet.DynamicData.Add("P0121_05_INICIO_DB_SELECT_1_Query1", q500);

            #endregion

            #region P0130_05_INICIO_DB_SELECT_1_Query1

            var q601 = new DynamicData();
            q601.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "1"},
                { "VG103_SEQ_CRITICA" , "2"},
                { "VG103_IND_TP_PROPOSTA" , "3"},
                { "VG103_COD_MSG_CRITICA" , "4"},
                { "VG102_DES_MSG_CRITICA" , "x"},
                { "VG102_DES_ABREV_MSG_CRITICA" , "x"},
                { "VG103_NUM_CPF_CNPJ" , "123"},
                { "VG103_NUM_PROPOSTA" , "134"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "1110"},
                { "VG103_DTA_OCORRENCIA" , "2020-01-0"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
                { "VG103_STA_CRITICA" , "x"},
                { "VG099_DES_STA_CRITICA" , "x"},
                { "VG103_DES_COMPLEMENTAR" , "x"},
                { "VG103_COD_USUARIO" , "1"},
                { "VG103_NOM_PROGRAMA" , "x"},
                { "VG103_DTH_CADASTRAMENTO" , "2025-05-27 14:30:00"},
                { "VG102_IND_ALCADA" , "1"},
            });
            AppSettings.TestSet.DynamicData.Add("P0130_05_INICIO_DB_SELECT_1_Query1", q601);

            #endregion

            #region P0131_05_INICIO_DB_SELECT_1_Query1

            var q701 = new DynamicData();
            q701.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "1"},
                { "VG103_SEQ_CRITICA" , "1"},
                { "VG103_IND_TP_PROPOSTA" , "1"},
                { "VG103_COD_MSG_CRITICA" , "1"},
                { "VG102_DES_MSG_CRITICA" , "x"},
                { "VG102_DES_ABREV_MSG_CRITICA" , "x"},
                { "VG103_NUM_CPF_CNPJ" , "123"},
                { "VG103_NUM_PROPOSTA" , "123"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "120"},
                { "VG103_DTA_OCORRENCIA" , "2020-01-01"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
                { "VG103_STA_CRITICA" , "x"},
                { "VG099_DES_STA_CRITICA" , "x"},
                { "VG103_DES_COMPLEMENTAR" , "x"},
                { "VG103_COD_USUARIO" , "1"},
                { "VG103_NOM_PROGRAMA" , "X"},
                { "VG103_DTH_CADASTRAMENTO" , "2025-05-27 14:30:00"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0131_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0131_05_INICIO_DB_SELECT_1_Query1", q701);

            #endregion

            #region P0132_05_INICIO_DB_SELECT_1_Query1

            var q801 = new DynamicData();
            q801.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "12"},
                { "VG103_SEQ_CRITICA" , "1"},
                { "VG103_IND_TP_PROPOSTA" , "2"},
                { "VG103_COD_MSG_CRITICA" , "1"},
                { "VG102_DES_MSG_CRITICA" , "2"},
                { "VG102_DES_ABREV_MSG_CRITICA" , "X"},
                { "VG103_NUM_CPF_CNPJ" , "123"},
                { "VG103_NUM_PROPOSTA" , "123"},
                { "VG103_VLR_IS" , "12"},
                { "VG103_VLR_PREMIO" , "30"},
                { "VG103_DTA_OCORRENCIA" , "2020-01-01"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
                { "VG103_STA_CRITICA" , "X"},
                { "VG099_DES_STA_CRITICA" , "X"},
                { "VG103_DES_COMPLEMENTAR" , "X"},
                { "VG103_COD_USUARIO" , "1"},
                { "VG103_NOM_PROGRAMA" , "X"},
                { "VG103_DTH_CADASTRAMENTO" , "2025-05-27 14:30:00"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0132_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0132_05_INICIO_DB_SELECT_1_Query1", q801);

            #endregion

            #region SPBVG001_SPBVG001_VG001

            var q901 = new DynamicData();
            q901.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "123"},
                { "VG103_SEQ_CRITICA" , "0"},
                { "VG103_IND_TP_PROPOSTA" , "1"},
                { "VG103_COD_MSG_CRITICA" , "2"},
                { "VG102_DES_MSG_CRITICA" , "X"},
                { "VG102_DES_ABREV_MSG_CRITICA" , "X"},
                { "VG103_NUM_CPF_CNPJ" , "123"},
                { "VG103_NUM_PROPOSTA" , "123"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "100"},
                { "VG103_DTA_OCORRENCIA" , "2020-10-10"},
                { "VG103_DTA_RCAP" , "2020-10-10"},
                { "VG103_STA_CRITICA" , "X"},
                { "VG099_DES_STA_CRITICA" , "X"},
                { "VG103_DES_COMPLEMENTAR" , "X"},
                { "VG103_COD_USUARIO" , "1"},
                { "VG103_NOM_PROGRAMA" , "X"},
                { "VG103_DTH_CADASTRAMENTO" , "2025-05-27 14:30:00"},
                { "VG102_IND_ALCADA" , "1"},
            });
            AppSettings.TestSet.DynamicData.Remove("SPBVG001_SPBVG001_VG001");
            AppSettings.TestSet.DynamicData.Add("SPBVG001_SPBVG001_VG001", q901);

            #endregion

            #region P0351_05_INICIO_DB_SELECT_1_Query1

            var q1110 = new DynamicData();
            q1110.AddDynamic(new Dictionary<string, string>{
                { "VG101_STA_CRITICA" , "X"}
            });
            AppSettings.TestSet.DynamicData.Remove("P0351_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0351_05_INICIO_DB_SELECT_1_Query1", q1110);

            #endregion

            #region P0801_05_INICIO_DB_SELECT_1_Query1

            var q111 = new DynamicData();
            q111.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "123"},
                { "VG103_NUM_CPF_CNPJ" , "213"},
                { "VG103_DTA_OCORRENCIA" , "2020-10-01"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
                { "DATA_CREDITO" , "2020-01-01"},
                { "NUM_PROPOSTA_SIVPF" , "123"},
                { "BILHETE_COD_PRODUTO" , "1"},
                { "BILHETE_RAMO" , "2"},
                { "BILHETE_OPC_COBERTURA" , "3"},
                { "BILHETE_DATA_QUITACAO" , "2020-01-01"},
                { "BILHETE_DATA_VENDA" , "2020-01-01"},
                { "CLIENTES_DATA_NASCIMENTO" , "2020-01-01"},
                { "WH_IDADE" , "1"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0801_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0801_05_INICIO_DB_SELECT_1_Query1", q111);

            #endregion

            #region P0802_05_INICIO_DB_SELECT_1_Query1

            var q112 = new DynamicData();
            q112.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "123"},
                { "VG103_NUM_CPF_CNPJ" , "124"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "020"},
                { "VG103_DTA_OCORRENCIA" , "2020-01-01"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0802_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0802_05_INICIO_DB_SELECT_1_Query1", q112);

            #endregion

            #region P0803_05_INICIO_DB_SELECT_1_Query1

            var q130 = new DynamicData();
            q130.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_PROPOSTA" , "1"},
                { "VG103_NUM_CERTIFICADO" , "2"},
                { "VG103_NUM_CPF_CNPJ" , "123"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "120"},
                { "VG103_DTA_OCORRENCIA" , "2020-01-01"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0803_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0803_05_INICIO_DB_SELECT_1_Query1", q130);


            #endregion

            #region P0804_05_INICIO_DB_SELECT_1_Query1

            var q140 = new DynamicData();
            q140.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_PROPOSTA" , "1"},
                { "VG103_NUM_CERTIFICADO" , "2"},
                { "VG103_NUM_CPF_CNPJ" , "3"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "120"},
                { "VG103_DTA_OCORRENCIA" , "120"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0804_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0804_05_INICIO_DB_SELECT_1_Query1", q140);

            #endregion

            #region P0805_05_INICIO_DB_SELECT_1_Query1

            var q150 = new DynamicData();
            q150.AddDynamic(new Dictionary<string, string>{
                { "WS_ORIG_PRODUTO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Remove("P0805_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0805_05_INICIO_DB_SELECT_1_Query1", q150);

            #endregion

            #region P0820_05_INICIO_DB_INSERT_1_Insert1

            var q160 = new DynamicData();
            q160.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "1"},
                { "VG103_SEQ_CRITICA" , "2"},
                { "VG103_IND_TP_PROPOSTA" , "2"},
                { "VG103_COD_MSG_CRITICA" , "1"},
                { "VG103_NUM_CPF_CNPJ" , "123"},
                { "VG103_NUM_PROPOSTA" , "1"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "120"},
                { "VG103_DTA_OCORRENCIA" , "2020-01-01"},
                { "VG103_DTA_RCAP" , "2020-01-01"},
                { "VG103_STA_CRITICA" , "x"},
                { "VG103_DES_COMPLEMENTAR" , "x"},
                { "VG103_COD_USUARIO" , "1"},
                { "VG103_NOM_PROGRAMA" , "x"},
                { "VG103_DTH_CADASTRAMENTO" , "2025-05-27 14:30:00"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0820_05_INICIO_DB_INSERT_1_Insert1");
            AppSettings.TestSet.DynamicData.Add("P0820_05_INICIO_DB_INSERT_1_Insert1", q160);

            #endregion

            #region P0821_05_INICIO_DB_INSERT_1_Insert1

            var q170 = new DynamicData();
            q170.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , "1"},
                { "VG103_SEQ_CRITICA" , "1"},
                { "VG103_DTH_CADASTRAMENTO" , "2025-05-27 14:30:00"},
                { "VG103_IND_TP_PROPOSTA" , "1"},
                { "VG103_COD_MSG_CRITICA" , "2"},
                { "VG103_NUM_CPF_CNPJ" , "1"},
                { "VG103_NUM_PROPOSTA" , "1"},
                { "VG103_VLR_IS" , "120"},
                { "VG103_VLR_PREMIO" , "120"},
                { "VG103_DTA_OCORRENCIA" , "2025-05-27"},
                { "VG103_DTA_RCAP" , "2025-05-27"},
                { "VG103_STA_CRITICA" , "x"},
                { "VG103_DES_COMPLEMENTAR" , "x"},
                { "VG103_COD_USUARIO" , "1"},
                { "VG103_NOM_PROGRAMA" , "x"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0821_05_INICIO_DB_INSERT_1_Insert1");
            AppSettings.TestSet.DynamicData.Add("P0821_05_INICIO_DB_INSERT_1_Insert1", q170);

            #endregion

            #region P0822_05_INICIO_DB_UPDATE_1_Update1

            var q180 = new DynamicData();
            q180.AddDynamic(new Dictionary<string, string>{
                { "VG103_DES_COMPLEMENTAR" , "x"},
                { "WH_VG103IDES_COMPLEMENTAR" , "x"},
                { "VG103_DTH_CADASTRAMENTO" , "2025-05-27 14:30:00"},
                { "VG103_NOM_PROGRAMA" , "x"},
                { "VG103_STA_CRITICA" , "x"},
                { "VG103_COD_USUARIO" , "x"},
                { "VG103_NUM_CERTIFICADO" , "123"},
                { "VG103_SEQ_CRITICA" , "1"},
            });
            AppSettings.TestSet.DynamicData.Remove("P0822_05_INICIO_DB_UPDATE_1_Update1");
            AppSettings.TestSet.DynamicData.Add("P0822_05_INICIO_DB_UPDATE_1_Update1", q180);

            #endregion

            #region P0850_05_INICIO_DB_SELECT_1_Query1

            var q190 = new DynamicData();
            q190.AddDynamic(new Dictionary<string, string>{
                { "VG103_SEQ_CRITICA" , "1"}
            });
            AppSettings.TestSet.DynamicData.Remove("P0850_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0850_05_INICIO_DB_SELECT_1_Query1", q190);

            #endregion

            #region P0851_01_INICIO_DB_SELECT_1_Query1

            var q202 = new DynamicData();
            q202.AddDynamic(new Dictionary<string, string>{
                { "WH_CURRENT_TIMESTAMP" , "2025-05-27 15:42:17.000"}
                });
            AppSettings.TestSet.DynamicData.Remove("P0851_01_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P0851_01_INICIO_DB_SELECT_1_Query1", q202);

            #endregion

            #region P1010_05_INICIO_DB_SELECT_1_Query1

            var q210 = new DynamicData();
            q210.AddDynamic(new Dictionary<string, string>{
                { "VG103_VLR_IS" , "121"},
                { "VG103_VLR_PREMIO" , "125"},
            });
            AppSettings.TestSet.DynamicData.Remove("P1010_05_INICIO_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("P1010_05_INICIO_DB_SELECT_1_Query1", q210);

            #endregion

            #region P1010_05_INICIO_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "VG103_VLR_IS" , "125"},
                { "VG103_VLR_PREMIO" , "130"},
            });
            AppSettings.TestSet.DynamicData.Remove("P1010_05_INICIO_DB_SELECT_2_Query1");
            AppSettings.TestSet.DynamicData.Add("P1010_05_INICIO_DB_SELECT_2_Query1", q22);

            #endregion

            #endregion
        }


        public static void Load_Parameters()
        {
            #region PARAMETERS
           
            #region M_70000_00_INICIAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PROC" , ""},
                { "WS_DATA_PROC_AUX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI1630B_CUR_AGE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , ""},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_AGE", q1);

            #endregion

            #region BI1630B_CUR_CBO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_CBO", q2);

            #endregion

            #region M_70000_00_INICIAL_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_2_Query1", q3);

            #endregion

            #region BI1630B_CUR_PRO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPSSBI_RENOVACAO_AUTOM" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
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
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_TIMESTAMP" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_FAIXA_RENDA_IND" , ""},
                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_PRO", q4);

            #endregion

            #region M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_VAL_RCAP" , ""},
                { "BILHETE_DATA_MOVIMENTO" , ""},
                { "BILHETE_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1", q5);

            #endregion

            #region M_11000_00_ATUALIZA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_CREDITO" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "WS_SIT_ATU_BIL" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_11000_00_ATUALIZA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region M_11000_00_ATUALIZA_DB_UPDATE_2_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PROC" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_11000_00_ATUALIZA_DB_UPDATE_2_Update1", q7);

            #endregion

            #region M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO" , ""},
                { "PRDSIVPF_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , ""},
                { "BI0005L_S_NOME_PESSOA" , ""},
                { "BI0005L_S_CPF" , ""},
                { "BI0005L_S_DATA_NASC" , ""},
                { "BI0005L_S_SEXO" , ""},
                { "BI0005L_S_ESTADO_CIVIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1", q12);

            #endregion

            #region M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , ""},
                { "BI0005L_S_NUM_IDENT" , ""},
                { "BI0005L_S_ORGAO_EXPED" , ""},
                { "BI0005L_S_DATA_EXPED" , ""},
                { "BI0005L_S_UF_EXPEDIDORA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1", q13);

            #endregion

            #region M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WS_OCC_END_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_COD_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1", q15);

            #endregion

            #region M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , ""},
                { "WS_OCC_END_ATU" , ""},
                { "BI0005L_S_ENDERECO_R" , ""},
                { "BI0005L_S_BAIRRO_R" , ""},
                { "BI0005L_S_CIDADE_R" , ""},
                { "BI0005L_S_SIGLA_UF_R" , ""},
                { "BI0005L_S_CEP_R" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1", q16);

            #endregion

            #region M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WS_SEQ_EMA_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1", q18);

            #endregion

            #region M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , ""},
                { "WS_SEQ_EMA_ATU" , ""},
                { "BI0005L_S_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1", q19);

            #endregion

            #region M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_EMAIL" , ""},
                { "WS_COD_CLI_ATU" , ""},
                { "WS_SEQ_EMA_ATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1", q20);

            #endregion

            #region M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WS_OCC_CMO_ATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1", q21);

            #endregion

            #region M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , ""},
                { "WS_OCC_CMO_ATU" , ""},
                { "WS_DATA_PROC" , ""},
                { "BI0005L_S_NOME_PESSOA" , ""},
                { "BI0005L_S_TIPO_PESSOA" , ""},
                { "BI0005L_S_SEXO" , ""},
                { "BI0005L_S_ESTADO_CIVIL" , ""},
                { "WS_OCC_END_ATU" , ""},
                { "BI0005L_S_ENDERECO_R" , ""},
                { "BI0005L_S_BAIRRO_R" , ""},
                { "BI0005L_S_CIDADE_R" , ""},
                { "BI0005L_S_SIGLA_UF_R" , ""},
                { "BI0005L_S_CEP_R" , ""},
                { "GECLIMOV_DDD" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "GECLIMOV_FAX" , ""},
                { "BI0005L_S_CPF" , ""},
                { "BI0005L_S_DATA_NASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1", q22);

            #endregion

            #region M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "BI0005L_S_ESTADO_CIVIL" , ""},
                { "VIND_NULL09" , ""},
                { "BI0005L_S_NOME_PESSOA" , ""},
                { "VIND_NULL06" , ""},
                { "BI0005L_S_TIPO_PESSOA" , ""},
                { "VIND_NULL07" , ""},
                { "BI0005L_S_ENDERECO_R" , ""},
                { "VIND_NULL11" , ""},
                { "BI0005L_S_SIGLA_UF_R" , ""},
                { "VIND_NULL14" , ""},
                { "BI0005L_S_DATA_NASC" , ""},
                { "VIND_NULL20" , ""},
                { "BI0005L_S_BAIRRO_R" , ""},
                { "VIND_NULL12" , ""},
                { "BI0005L_S_CIDADE_R" , ""},
                { "VIND_NULL13" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "VIND_NULL17" , ""},
                { "BI0005L_S_CEP_R" , ""},
                { "VIND_NULL15" , ""},
                { "BI0005L_S_SEXO" , ""},
                { "VIND_NULL08" , ""},
                { "WS_OCC_END_ATU" , ""},
                { "VIND_NULL10" , ""},
                { "BI0005L_S_CPF" , ""},
                { "VIND_NULL19" , ""},
                { "GECLIMOV_DDD" , ""},
                { "VIND_NULL16" , ""},
                { "GECLIMOV_FAX" , ""},
                { "VIND_NULL18" , ""},
                { "WS_DATA_PROC" , ""},
                { "WS_COD_CLI_ATU" , ""},
                { "WS_OCC_CMO_ATU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1", q23);

            #endregion

            #region M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_SICOB" , ""},
                { "BILHETE_FONTE" , ""},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "WS_COD_CLI_ATU" , ""},
                { "BILHETE_PROFISSAO" , ""},
                { "BI0005L_S_SEXO" , ""},
                { "BI0005L_S_ESTADO_CIVIL" , ""},
                { "WS_OCC_END_ATU" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "BILHETE_RAMO" , ""},
                { "WS_DATA_PROC" , ""},
                { "BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "WS_SIT_BIL" , ""},
                { "BILHETE_BI_FAIXA_RENDA_IND" , ""},
                { "BILHETE_BI_FAIXA_RENDA_FAM" , ""},
                { "PRDSIVPF_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1", q24);

            #endregion

            #region M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_PROFISSAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1", q25);

            #endregion

            #region M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "WS_SIT_PRO" , ""},
                { "WS_SIT_ENV" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1", q26);

            #endregion

            #region M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "WS_DATA_PROC" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1", q27);

            #endregion

            #region M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PROC" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1", q28);

            #endregion

            #region M_80000_00_FINAL_DB_UPDATE_1_Update1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_80000_00_FINAL_DB_UPDATE_1_Update1", q29);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI1630B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();
                Load_Parameters_BI0005S();
                Load_Parameters_SPBVG001();
                Load_Parameters_SPBVG009();
                Load_Parameters_GE0070S();
                Load_Parameters_GE0071S();


                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_70000_00_INICIAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PROC" , "2021-01-01"},
                { "WS_DATA_PROC_AUX" , "2021-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_INICIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI1630B_CUR_AGE

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , "1"},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI1630B_CUR_AGE");
                AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_AGE", q1);

                #endregion

                #region BI1630B_CUR_CBO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "1"},
                { "CBO_DESCR_CBO" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI1630B_CUR_CBO");
                AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_CBO", q2);

                #endregion

                #region M_70000_00_INICIAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , "X"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_INICIAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region BI1630B_CUR_PRO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PROPSSBI_RENOVACAO_AUTOM" , "1"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "2"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "3"},
                { "PROPOFID_COD_PESSOA" , "1"},
                { "PROPOFID_NUM_SICOB" , "4"},
                { "PROPOFID_DATA_PROPOSTA" , "2000-01-01"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "7"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "8"},
                { "PROPOFID_AGECOBR" , "9"},
                { "PROPOFID_DIA_DEBITO" , "10"},
                { "PROPOFID_OPCAOPAG" , "11"},
                { "PROPOFID_AGECTADEB" , "12"},
                { "PROPOFID_OPRCTADEB" , "13"},
                { "PROPOFID_NUMCTADEB" , "14"},
                { "PROPOFID_DIGCTADEB" , "15"},
                { "PROPOFID_PERC_DESCONTO" , "16"},
                { "PROPOFID_NRMATRVEN" , "17"},
                { "PROPOFID_AGECTAVEN" , "18"},
                { "PROPOFID_OPRCTAVEN" , "19"},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , "20"},
                { "PROPOFID_CGC_CONVENENTE" , "21"},
                { "PROPOFID_NOME_CONVENENTE" , "22"},
                { "PROPOFID_NRMATRCON" , "23"},
                { "PROPOFID_DTQITBCO" , "24"},
                { "PROPOFID_VAL_PAGO" , "25"},
                { "PROPOFID_AGEPGTO" , "26"},
                { "PROPOFID_VAL_TARIFA" , "27"},
                { "PROPOFID_VAL_IOF" , "28"},
                { "PROPOFID_DATA_CREDITO" , "29"},
                { "PROPOFID_VAL_COMISSAO" , "30"},
                { "PROPOFID_SIT_PROPOSTA" , "31"},
                { "PROPOFID_COD_USUARIO" , "32"},
                { "PROPOFID_CANAL_PROPOSTA" , "33"},
                { "PROPOFID_NSAS_SIVPF" , "34"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "35"},
                { "PROPOFID_TIMESTAMP" , "36"},
                { "PROPOFID_NSL" , "37"},
                { "PROPOFID_NSAC_SIVPF" , "38"},
                { "PROPOFID_NOME_CONJUGE" , "39"},
                { "PROPOFID_DATA_NASC_CONJUGE" , "40"},
                { "PROPOFID_PROFISSAO_CONJUGE" , "41"},
                { "PROPOFID_OPCAO_COBER" , "42"},
                { "PROPOFID_COD_PLANO" , "43"},
                { "PROPOFID_FAIXA_RENDA_IND" , "44"},
                { "PROPOFID_FAIXA_RENDA_FAM" , "45"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI1630B_CUR_PRO");
                AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_PRO", q4);

                #endregion

                #region M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1

                 var q5 = new DynamicData();
                 q5.AddDynamic(new Dictionary<string, string>{
                 { "BILHETE_DATA_QUITACAO" , "1994-01-10"},
                 { "BILHETE_VAL_RCAP" , "22.12"},
                 { "BILHETE_DATA_MOVIMENTO" , "2001-08-31"},
                 { "BILHETE_SITUACAO" , "2"},
                 });
                AppSettings.TestSet.DynamicData.Remove("M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "1"},
                { "RCAPS_NUM_RCAP" , "2"},
                { "RCAPS_VAL_RCAP" , "100"},
                { "RCAPS_AGE_COBRANCA" , "123"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "1"},
                { "RCAPS_NUM_RCAP" , "2"},
                { "RCAPS_VAL_RCAP" , "123"},
                { "RCAPS_AGE_COBRANCA" , "123"},
               });
                AppSettings.TestSet.DynamicData.Remove("M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO" , "1"},
                { "PRDSIVPF_COD_PLANO" , "123"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                /*q11.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , "123"}
                });*/
                AppSettings.TestSet.DynamicData.Remove("M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WS_OCC_END_ATU" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1", q14);

                #endregion

                #region M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_CEP" , "11000"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1", q15);

                #endregion

                #region M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "WS_SEQ_EMA_ATU" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q17);

                #endregion

                #region M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , "XXXX"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1", q18);

                #endregion

                #region M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "WS_OCC_CMO_ATU" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1", q21);

                #endregion

                #region M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_PROFISSAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1", q25);

                #endregion

                #endregion

                var program = new BI1630B();
                 
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);
             
                #region M_11000_00_ATUALIZA_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["M_11000_00_ATUALIZA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("PROPOFID_DATA_CREDITO", out var PROPOFID_DATA_CREDITO) && PROPOFID_DATA_CREDITO == "29        ");
                Assert.True(envList1[1].TryGetValue("PROPOFID_DTQITBCO", out var PROPOFID_DTQITBCO) && PROPOFID_DTQITBCO == "24        ");
                Assert.True(envList1[1].TryGetValue("PROPOFID_VAL_PAGO", out var PROPOFID_VAL_PAGO) && PROPOFID_VAL_PAGO == "0000000000025.00");
                Assert.True(envList1[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF) && PROPOFID_NUM_PROPOSTA_SIVPF == "000000000000002");
                #endregion

                #region M_11000_00_ATUALIZA_DB_UPDATE_2_Update1

                var envList2 = AppSettings.TestSet.DynamicData["M_11000_00_ATUALIZA_DB_UPDATE_2_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);
                Assert.True(envList2[1].TryGetValue("WS_DATA_PROC", out var WS_DATA_PROC) && WS_DATA_PROC == "2021-01-01");
                Assert.True(envList2[1].TryGetValue("PROPOFID_NUM_IDENTIFICACAO", out var PROPOFID_NUM_IDENTIFICACAO) && PROPOFID_NUM_IDENTIFICACAO == "000000000000003");

                #endregion

                #region M_80000_00_FINAL_DB_UPDATE_1_Update1               

                var envList14 = AppSettings.TestSet.DynamicData["M_80000_00_FINAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList14?.Count > 1);
                Assert.True(envList14[1].TryGetValue("NUM_CLIENTE", out var NUM_CLIENTE) && NUM_CLIENTE == "000000000");

                #endregion
              
                //***** Entra quando ha retorno 100 em  M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1
               /*  #region M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1

                var envList3 = AppSettings.TestSet.DynamicData["M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("WS_COD_CLI_ATU", out var WS_COD_CLI_ATU) && WS_COD_CLI_ATU == "000000001");
                Assert.True(envList3[1].TryGetValue("BI0005L_S_NOME_PESSOA", out var BI0005L_S_NOME_PESSOA) && BI0005L_S_NOME_PESSOA == "MARIA FRANCISCA DA SILVA AGOSTINHO      ");
                Assert.True(envList3[1].TryGetValue("BI0005L_S_CPF", out var BI0005L_S_CPF) && BI0005L_S_CPF == "99450330425");
                Assert.True(envList3[1].TryGetValue("BI0005L_S_DATA_NASC", out var BI0005L_S_DATA_NASC) && BI0005L_S_DATA_NASC == "1929-05-15");
                Assert.True(envList3[1].TryGetValue("BI0005L_S_SEXO", out var BI0005L_S_SEXO) && BI0005L_S_SEXO == "F");
                Assert.True(envList3[1].TryGetValue("BI0005L_S_ESTADO_CIVIL", out var BI0005L_S_ESTADO_CIVIL) && BI0005L_S_ESTADO_CIVIL == "C");

                #endregion

                #region M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1

                var envList4 = AppSettings.TestSet.DynamicData["M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4?.Count > 1);
                Assert.True(envList4[1].TryGetValue("WS_COD_CLI_ATU", out var WS_COD_CLI_ATU3) && WS_COD_CLI_ATU3 == "000000001");
                Assert.True(envList4[1].TryGetValue("BI0005L_S_NUM_IDENT", out var BI0005L_S_NUM_IDENT) && BI0005L_S_NUM_IDENT == "000000000000000");
                Assert.True(envList4[1].TryGetValue("BI0005L_S_ORGAO_EXPED", out var BI0005L_S_ORGAO_EXPED) && BI0005L_S_ORGAO_EXPED == "X    ");
                Assert.True(envList4[1].TryGetValue("BI0005L_S_DATA_EXPED", out var BI0005L_S_DATA_EXPED) && BI0005L_S_DATA_EXPED == "2021-01-01");
                Assert.True(envList4[1].TryGetValue("BI0005L_S_UF_EXPEDIDORA", out var BI0005L_S_UF_EXPEDIDORA) && BI0005L_S_UF_EXPEDIDORA == "X ");

                #endregion

                #region M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1

                var envList5 = AppSettings.TestSet.DynamicData["M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5?.Count > 1);
                Assert.True(envList5[1].TryGetValue("WS_COD_CLI_ATU", out var WS_COD_CLI_ATU4) && WS_COD_CLI_ATU4 == "000000001");
                Assert.True(envList5[1].TryGetValue("WS_OCC_END_ATU", out var WS_OCC_END_ATU) && WS_OCC_END_ATU == "0001");
                Assert.True(envList5[1].TryGetValue("BI0005L_S_ENDERECO_R", out var BI0005L_S_ENDERECO_R) && BI0005L_S_ENDERECO_R == "1                                       ");
                Assert.True(envList5[1].TryGetValue("BI0005L_S_BAIRRO_R", out var BI0005L_S_BAIRRO_R) && BI0005L_S_BAIRRO_R == "1                   ");
                Assert.True(envList5[1].TryGetValue("BI0005L_S_CIDADE_R", out var BI0005L_S_CIDADE_R) && BI0005L_S_CIDADE_R == "1                   ");
                Assert.True(envList5[1].TryGetValue("BI0005L_S_SIGLA_UF_R", out var BI0005L_S_SIGLA_UF_R) && BI0005L_S_SIGLA_UF_R == "1 ");
                Assert.True(envList5[1].TryGetValue("BI0005L_S_CEP_R", out var BI0005L_S_CEP_R) && BI0005L_S_CEP_R == "000000001");
                Assert.True(envList5[1].TryGetValue("ENDERECO_DDD", out var ENDERECO_DDD) && ENDERECO_DDD == "0082");
                Assert.True(envList5[1].TryGetValue("ENDERECO_TELEFONE", out var ENDERECO_TELEFONE) && ENDERECO_TELEFONE == "003362802");
                Assert.True(envList5[1].TryGetValue("ENDERECO_FAX", out var ENDERECO_FAX) && ENDERECO_FAX == "000000000");
                Assert.True(envList5[1].TryGetValue("ENDERECO_TELEX", out var ENDERECO_TELEX) && ENDERECO_TELEX == "000000000");


                #endregion

                #region M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1

                var envList6 = AppSettings.TestSet.DynamicData["M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6?.Count > 1);
                Assert.True(envList6[1].TryGetValue("WS_COD_CLI_ATU", out var WS_COD_CLI_ATU5) && WS_COD_CLI_ATU5 == "000000001");
                Assert.True(envList6[1].TryGetValue("WS_SEQ_EMA_ATU", out var WS_SEQ_EMA_ATU) && WS_SEQ_EMA_ATU == "0001");
                Assert.True(envList6[1].TryGetValue("BI0005L_S_EMAIL", out var BI0005L_S_EMAIL) && BI0005L_S_EMAIL == "NAOPOSSUI10@HOTMAIL.COM                 ");

                #endregion

                #region M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1

                var envList9 = AppSettings.TestSet.DynamicData["M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList9?.Count > 1);
                Assert.True(envList9[1].TryGetValue("BI0005L_S_ESTADO_CIVIL", out var BI0005L_S_ESTADO_CIVIL1) && BI0005L_S_ESTADO_CIVIL1 == "C");
                Assert.True(envList9[1].TryGetValue("VIND_NULL09", out var VIND_NULL09) && VIND_NULL09 == "0000");
                Assert.True(envList9[1].TryGetValue("VIND_NULL06", out var VIND_NULL06) && VIND_NULL06 == "0000");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_TIPO_PESSOA", out var BI0005L_S_TIPO_PESSOA1) && BI0005L_S_TIPO_PESSOA1 == "F");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_ENDERECO_R", out var BI0005L_S_ENDERECO_R1) && BI0005L_S_ENDERECO_R1 == "1                                       ");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_SIGLA_UF_R", out var BI0005L_S_SIGLA_UF_R1) && BI0005L_S_SIGLA_UF_R1 == "1 ");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_DATA_NASC", out var BI0005L_S_DATA_NASC1) && BI0005L_S_DATA_NASC1 == "1929-05-15");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_BAIRRO_R", out var BI0005L_S_BAIRRO_R1) && BI0005L_S_BAIRRO_R1 == "1                   ");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_CIDADE_R", out var BI0005L_S_CIDADE_R1) && BI0005L_S_CIDADE_R1 == "1                   ");
                Assert.True(envList9[1].TryGetValue("VIND_NULL13", out var VIND_NULL13) && VIND_NULL13 == "0000");
                Assert.True(envList9[1].TryGetValue("GECLIMOV_TELEFONE", out var GECLIMOV_TELEFONE1) && GECLIMOV_TELEFONE1 == "003362802");
                Assert.True(envList9[1].TryGetValue("VIND_NULL17", out var VIND_NULL17) && VIND_NULL17 == "0000");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_CEP_R", out var BI0005L_S_CEP_R1) && BI0005L_S_CEP_R1 == "000000001");
                Assert.True(envList9[1].TryGetValue("VIND_NULL15", out var VIND_NULL15) && VIND_NULL15 == "0000");
                Assert.True(envList9[1].TryGetValue("BI0005L_S_SEXO", out var BI0005L_S_SEXO1) && BI0005L_S_SEXO1 == "F");
                Assert.True(envList9[1].TryGetValue("VIND_NULL08", out var VIND_NULL08) && VIND_NULL08 == "0000");
                
                #endregion

                #region M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1

                var envList10 = AppSettings.TestSet.DynamicData["M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList10?.Count > 1);
                Assert.True(envList10[1].TryGetValue("PROPOFID_NUM_SICOB", out var PROPOFID_NUM_SICOB) && PROPOFID_NUM_SICOB == "000000000000004");
                Assert.True(envList10[1].TryGetValue("BILHETE_FONTE", out var BILHETE_FONTE) && BILHETE_FONTE == "0005");
                Assert.True(envList10[1].TryGetValue("PROPOFID_AGECOBR", out var PROPOFID_AGECOBR) && PROPOFID_AGECOBR == "0009");
                Assert.True(envList10[1].TryGetValue("PROPOFID_NRMATRVEN", out var PROPOFID_NRMATRVEN) && PROPOFID_NRMATRVEN == "000000000000017");
               

                #endregion

                #region M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1

                var envList11 = AppSettings.TestSet.DynamicData["M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList11?.Count > 1);
                Assert.True(envList11[1].TryGetValue("WS_SIT_PRO", out var WS_SIT_PRO) && WS_SIT_PRO == "PAI");
                Assert.True(envList11[1].TryGetValue("WS_SIT_ENV", out var WS_SIT_ENV) && WS_SIT_ENV == " ");
                Assert.True(envList11[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var PROPOFID_NUM_PROPOSTA_SIVPF2) && PROPOFID_NUM_PROPOSTA_SIVPF2 == "000000000000002");

                #endregion

                #region M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1

                var envList13 = AppSettings.TestSet.DynamicData["M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList13?.Count > 1);
                Assert.True(envList13[1].TryGetValue("WS_DATA_PROC", out var WS_DATA_PROC13) && WS_DATA_PROC13 == "2021-01-01");
                Assert.True(envList13[1].TryGetValue("PROPOFID_NUM_IDENTIFICACAO", out var PROPOFID_NUM_IDENTIFICACAO13) && PROPOFID_NUM_IDENTIFICACAO13 == "000000000000003");

                #endregion
              */
               

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Fact]
        public static void BI1630B_Tests99_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();              
                Load_Parameters_BI0005S();
                Load_Parameters_SPBVG001();
                Load_Parameters_SPBVG009();
                Load_Parameters_GE0070S();
                Load_Parameters_GE0071S();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_70000_00_INICIAL_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "WS_DATA_PROC" , "2021-01-01"},
                { "WS_DATA_PROC_AUX" , "2021-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_INICIAL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_1_Query1", q0);

                #endregion

                #region BI1630B_CUR_AGE

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , "1"},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI1630B_CUR_AGE");
                AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_AGE", q1);

                #endregion

                #region BI1630B_CUR_CBO

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , "1"},
                { "CBO_DESCR_CBO" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("BI1630B_CUR_CBO");
                AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_CBO", q2);

                #endregion

                #region M_70000_00_INICIAL_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "NUM_CLIENTE" , "X"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_70000_00_INICIAL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_70000_00_INICIAL_DB_SELECT_2_Query1", q3);

                #endregion

                #region BI1630B_CUR_PRO

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
              //  { "PROPSSBI_RENOVACAO_AUTOM" , "1"},
              //  { "PROPOFID_NUM_PROPOSTA_SIVPF" , "2"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "3"},
                { "PROPOFID_COD_PESSOA" , "1"},
                { "PROPOFID_NUM_SICOB" , "4"},
                { "PROPOFID_DATA_PROPOSTA" , "6"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "7"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "8"},
                { "PROPOFID_AGECOBR" , "9"},
                { "PROPOFID_DIA_DEBITO" , "10"},
                { "PROPOFID_OPCAOPAG" , "11"},
                { "PROPOFID_AGECTADEB" , "12"},
                { "PROPOFID_OPRCTADEB" , "13"},
                { "PROPOFID_NUMCTADEB" , "14"},
                { "PROPOFID_DIGCTADEB" , "15"},
                { "PROPOFID_PERC_DESCONTO" , "16"},
                { "PROPOFID_NRMATRVEN" , "17"},
                { "PROPOFID_AGECTAVEN" , "18"},
                { "PROPOFID_OPRCTAVEN" , "19"},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , "20"},
                { "PROPOFID_CGC_CONVENENTE" , "21"},
                { "PROPOFID_NOME_CONVENENTE" , "22"},
                { "PROPOFID_NRMATRCON" , "23"},
                { "PROPOFID_DTQITBCO" , "24"},
                { "PROPOFID_VAL_PAGO" , "25"},
                { "PROPOFID_AGEPGTO" , "26"},
                { "PROPOFID_VAL_TARIFA" , "27"},
                { "PROPOFID_VAL_IOF" , "28"},
                { "PROPOFID_DATA_CREDITO" , "29"},
                { "PROPOFID_VAL_COMISSAO" , "30"},
                { "PROPOFID_SIT_PROPOSTA" , "31"},
                { "PROPOFID_COD_USUARIO" , "32"},
                { "PROPOFID_CANAL_PROPOSTA" , "33"},
                { "PROPOFID_NSAS_SIVPF" , "34"},
                { "PROPOFID_ORIGEM_PROPOSTA" , "35"},
                { "PROPOFID_TIMESTAMP" , "36"},
                { "PROPOFID_NSL" , "37"},
                { "PROPOFID_NSAC_SIVPF" , "38"},
                { "PROPOFID_NOME_CONJUGE" , "39"},
                { "PROPOFID_DATA_NASC_CONJUGE" , "40"},
                { "PROPOFID_PROFISSAO_CONJUGE" , "41"},
                { "PROPOFID_OPCAO_COBER" , "42"},
                { "PROPOFID_COD_PLANO" , "43"},
                { "PROPOFID_FAIXA_RENDA_IND" , "44"},
                { "PROPOFID_FAIXA_RENDA_FAM" , "45"},
            });
                AppSettings.TestSet.DynamicData.Remove("BI1630B_CUR_PRO");
                AppSettings.TestSet.DynamicData.Add("BI1630B_CUR_PRO", q4);

                #endregion

                #region M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_DATA_QUITACAO" , "1994-01-10"},
                { "BILHETE_VAL_RCAP" , "22.12"},
                { "BILHETE_DATA_MOVIMENTO" , "2001-08-31"},
                { "BILHETE_SITUACAO" , "2"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1", q5);

                #endregion

                #region M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "1"},
                { "RCAPS_NUM_RCAP" , "2"},
                { "RCAPS_VAL_RCAP" , "100"},
                { "RCAPS_AGE_COBRANCA" , "123"},
            });
                AppSettings.TestSet.DynamicData.Remove("M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1", q8);

                #endregion

                #region M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "1"},
                { "RCAPS_NUM_RCAP" , "2"},
                { "RCAPS_VAL_RCAP" , "123"},
                { "RCAPS_AGE_COBRANCA" , "123"},
               });
                AppSettings.TestSet.DynamicData.Remove("M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1", q9);

                #endregion

                #region M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_PRODUTO" , "1"},
                { "PRDSIVPF_COD_PLANO" , "123"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1", q10);

                #endregion

                #region M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                /*q11.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_CLI_ATU" , "123"}
                });*/
                AppSettings.TestSet.DynamicData.Remove("M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1", q11);

                #endregion

                #region M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "WS_OCC_END_ATU" , "123"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1", q14);

                #endregion

                #region M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_CEP" , "11000"},
                { "ENDERECO_COD_ENDERECO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1", q15);

                #endregion

                #region M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "WS_SEQ_EMA_ATU" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1", q17);

                #endregion

                #region M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "CLIENEMA_EMAIL" , "XXXX"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1", q18);

                #endregion

                #region M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "WS_OCC_CMO_ATU" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1", q21);

                #endregion

                #region M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1

                var q25 = new DynamicData();
                q25.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_PROFISSAO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1", q25);

                #endregion

                #endregion

                var program = new BI1630B();
                program.Execute();

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);


                Assert.True(program.RETURN_CODE == 99);
            }
        }



    }
}