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
using static Code.EM0913S;

namespace FileTests.Test
{
    [Collection("EM0913S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0913S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_ORGAO_EMISSOR" , "10"},
                { "APOLICES_RAMO_EMISSOR" , "68"},
                { "ENDOSSOS_COD_FONTE" , "10"},
                { "ENDOSSOS_TIPO_ENDOSSO" , "0"},
                { "APOLICES_COD_PRODUTO" , "6800"},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1", q0);

            #endregion

            #region EM0913S_CSR_MRPROITE

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MRPROITE_NUM_ITEM" , ""},
                { "MRPROITE_COD_PRODUTO" , ""},
                { "MRPROITE_NUM_VERSAO" , ""},
                { "MRPROITE_NUM_TP_MORA_IMOVEL" , ""},
                { "MRPROITE_NUM_TP_OCUP_IMOVEL" , ""},
                { "MRPROITE_DTH_INI_VIGENCIA" , ""},
                { "MRPROITE_DTH_FIM_VIGENCIA" , ""},
                { "MRPROITE_IND_TIPO_SEGURO" , ""},
                { "MRPROITE_QTD_RENOVACAO" , ""},
                { "MRPROITE_STA_PROPOSTA_ITEM" , ""},
                { "MRPROITE_NUM_PROPOSTA_SIMU" , ""},
                { "MRPROITE_OCORR_ENDERECO" , ""},
                { "MRPROITE_PCT_DESC_FIDEL" , ""},
                { "MRPROITE_PCT_DESC_AGRUP" , ""},
                { "MRPROITE_PCT_DESC_EXPER" , ""},
                { "MRPROITE_COD_CLIENTE" , ""},
                { "MRPROITE_COD_BENEFICIARIO" , ""},
                { "MRPROITE_IND_RENOVACAO_AUT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0913S_CSR_MRPROITE", q1);

            #endregion

            #region EM0913S_CSR_MR023

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MR023_COD_FONTE" , "1"},
                { "MR023_NUM_PROPOSTA" , "141136"},
                { "MR023_NUM_ITEM" , "1"},
                { "MR023_NUM_TP_CONDOMINIO" , "1"},
                { "MR023_NUM_PAVIMENTOS" , "13"},
                { "MR023_NUM_ELEVADORES" , "2"},
                { "MR023_NUM_PORTAO_ELETRON" , "1"},
                { "MR023_NUM_VAGAS" , "0"},
                { "MR023_NUM_UNID_AUTONOMA" , "0"},
                { "MR023_PCT_DESC_COBERTURA" , "10.0000"},
                { "MR023_PCT_BONUS_RENOVCAO" , "0.0000"},
                { "MR023_PCT_DESC_PROMOCAO" , "0.0000"},
                { "MR023_PCT_DESC_CORRETOR" , "0.0000"},
                { "MR023_COD_BENEFICIARIO" , ""},
                { "MR023_DES_CLAUSULA_BENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0913S_CSR_MR023", q2);

            #endregion

            #region R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MRAPOITE_NUM_APOLICE" , ""},
                { "MRAPOITE_NUM_ENDOSSO" , ""},
                { "MRAPOITE_NUM_ITEM" , ""},
                { "MRAPOITE_COD_PRODUTO" , ""},
                { "MRAPOITE_NUM_VERSAO" , ""},
                { "MRAPOITE_NUM_TP_MORA_IMOVEL" , ""},
                { "MRAPOITE_NUM_TP_OCUP_IMOVEL" , ""},
                { "MRAPOITE_DTH_INI_VIG_ITEM" , ""},
                { "MRAPOITE_DTH_FIM_VIG_ITEM" , ""},
                { "MRAPOITE_QTD_RENOVACAO" , ""},
                { "MRAPOITE_OCORR_ENDERECO" , ""},
                { "MRAPOITE_STA_PROP_ITEM" , ""},
                { "MRAPOITE_PCT_DESC_FIDEL" , ""},
                { "MRAPOITE_PCT_DESC_AGRUP" , ""},
                { "MRAPOITE_PCT_DESC_EXPER" , ""},
                { "MRAPOITE_COD_CLIENTE" , ""},
                { "MRAPOITE_COD_BENEFICIARIO" , ""},
                { "MRAPOITE_IND_RENOVACAO_AUT" , ""},
                { "MRAPOITE_NUM_PROPOSTA_SIMU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1", q3);

            #endregion

            #region EM0913S_CSR_MRPROCOR

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "MRPROCOR_COD_COBERTURA" , "2"},
                { "MRPROCOR_NUM_ITEM" , "1"},
                { "MRPROCOR_RAMO_COBERTURA" , "14"},
                { "MRPROCOR_MODALI_COBERTURA" , "50"},
                { "MRPROCOR_DTH_INI_VIGENCIA" , "2004-03-04"},
                { "MRPROCOR_DTH_FIM_VIGENCIA" , "2005-03-04"},
                { "MRPROCOR_IMP_SEGURADA_IX" , "100000.00"},
                { "MRPROCOR_IMP_SEGURADA_VAR" , "100000.00"},
                { "MRPROCOR_TAXA_IS_COBER" , "0.0194700"},
                { "MRPROCOR_PRM_TARIFARIO_IX" , "19.47000"},
                { "MRPROCOR_PRM_TARIFARIO_VAR" , "19.47000"},
                { "MRPROCOR_PCT_FRANQUIA" , "0.0000"},
                { "MRPROCOR_VAL_FRANQ_OBR_IX" , "0.00"},
                { "MRPROCOR_SIT_REGISTRO" , "A"},
                { "MRPROCOR_COD_EMPRESA" , "0"},
            });
            AppSettings.TestSet.DynamicData.Add("EM0913S_CSR_MRPROCOR", q4);

            #endregion

            #region R2210_00_INSERT_MR021_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MR021_NUM_APOLICE" , ""},
                { "MR021_NUM_ENDOSSO" , ""},
                { "MR021_NUM_ITEM" , ""},
                { "MR021_NUM_TP_CONDOMINIO" , ""},
                { "MR021_NUM_PAVIMENTOS" , ""},
                { "MR021_NUM_ELEVADORES" , ""},
                { "MR021_NUM_PORTAO_ELETRON" , ""},
                { "MR021_NUM_VAGAS" , ""},
                { "MR021_NUM_UNID_AUTONOMA" , ""},
                { "MR021_PCT_DESC_COBERTURA" , ""},
                { "MR021_PCT_BONUS_RENOVCAO" , ""},
                { "MR021_PCT_DESC_PROMOCAO" , ""},
                { "MR021_PCT_DESC_CORRETOR" , ""},
                { "MR021_COD_BENEFICIARIO" , ""},
                { "MR021_DES_CLAUSULA_BENEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_INSERT_MR021_DB_INSERT_1_Insert1", q5);

            #endregion

            #region EM0913S_V1PROPCLAU

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOCLA_COD_EMPRESA" , "0"},
                { "PROPOCLA_RAMO_COBERTURA" , "11"},
                { "PROPOCLA_MODALI_COBERTURA" , "0"},
                { "PROPOCLA_COD_COBERTURA" , "0"},
                { "PROPOCLA_DATA_INIVIGENCIA" , "2024-01-01"},
                { "PROPOCLA_DATA_TERVIGENCIA" , "2024-12-01"},
                { "PROPOCLA_NUM_ITEM" , "1"},
                { "PROPOCLA_COD_CLAUSULA" , "101     "},
                { "PROPOCLA_LIMITE_INDENIZA_IX" , "0"},
                { "PROPOCLA_TIPO_CLAUSULA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0913S_V1PROPCLAU", q6);

            #endregion

            #region R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "MRAPOCOB_NUM_APOLICE" , ""},
                { "MRAPOCOB_NUM_ENDOSSO" , ""},
                { "MRAPOCOB_COD_COBERTURA" , ""},
                { "MRAPOCOB_NUM_ITEM" , ""},
                { "MRAPOCOB_RAMO_COBERTURA" , ""},
                { "MRAPOCOB_MODALI_COBERTURA" , ""},
                { "MRAPOCOB_DTH_INI_VIG_COBER" , ""},
                { "MRAPOCOB_DTH_FIM_VIG_COBER" , ""},
                { "MRAPOCOB_IMP_SEGURADA_IX" , ""},
                { "MRAPOCOB_IMP_SEGURADA_VAR" , ""},
                { "MRAPOCOB_TAXA_IS" , ""},
                { "MRAPOCOB_PRM_TARIFARIO_IX" , ""},
                { "MRAPOCOB_PRM_TARIFARIO_VAR" , ""},
                { "MRAPOCOB_VAL_MIN_FRANQ_IX" , ""},
                { "MRAPOCOB_PCT_FRANQUIA" , ""},
                { "MRAPOCOB_SIT_REGISTRO" , ""},
                { "MRAPOCOB_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1", q7);

            #endregion

            #region R2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "APOLICLA_COD_EMPRESA" , ""},
                { "APOLICLA_NUM_APOLICE" , ""},
                { "APOLICLA_NUM_ENDOSSO" , ""},
                { "APOLICLA_RAMO_COBERTURA" , ""},
                { "APOLICLA_MODALI_COBERTURA" , ""},
                { "APOLICLA_COD_COBERTURA" , ""},
                { "APOLICLA_DATA_INIVIGENCIA" , ""},
                { "APOLICLA_DATA_TERVIGENCIA" , ""},
                { "APOLICLA_NUM_ITEM" , ""},
                { "APOLICLA_COD_CLAUSULA" , ""},
                { "APOLICLA_TIPO_CLAUSULA" , ""},
                { "APOLICLA_LIMITE_INDENIZA_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0913S_Tests_Fact_ReturnCode_00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region param
                var inputParam = new EM0913S_LK_PROPOSTA();

                inputParam.LK_CODPRODU.Value = 100;
                inputParam.LK_FONTE.Value = 1;
                inputParam.LK_NRPROPOS.Value = 3;
                inputParam.LK_NUM_APOL.Value = 100790324;
                inputParam.LK_NRENDOS.Value = 2;
                inputParam.LK_DTMOVABE.Value = "2024-01-01";
                inputParam.LK_CODCORR.Value = 3;

                #endregion
                #endregion
                var program = new EM0913S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 0);

                //R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R2110_00_INSERT_MR_APOL_ITEM_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("MRAPOITE_NUM_APOLICE", out var val0r) && val0r.Contains("0000100790324"));
                Assert.True(envList0.Count > 1);
                //R2210_00_INSERT_MR021_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2210_00_INSERT_MR021_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("MR021_NUM_APOLICE", out var val1r) && val1r.Contains("0000100790324"));
                Assert.True(envList1.Count > 1);

                //R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R2310_00_INSERT_MR_APOL_COBER_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("MRAPOCOB_RAMO_COBERTURA", out var val2r) && val2r.Contains("0014"));
                Assert.True(envList2.Count > 1);

                //R2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R2340_00_INSERT_APOLICOB_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("APOLICOB_MODALI_COBERTURA", out var val3r) && val3r.Contains("0050"));
                Assert.True(envList3.Count > 1);

                //R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R2610_00_INSERT_APOL_CLAUS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("APOLICLA_RAMO_COBERTURA", out var val4r) && val4r.Contains("0011"));
                Assert.True(envList4.Count > 1);
            }
        }
        [Fact]
        public static void EM0913S_Tests_Fact_Produto_99_ReturnCode_00()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region param
                var inputParam = new EM0913S_LK_PROPOSTA();
                inputParam.LK_CODPRODU.Value = 99;
    
                #endregion
                #endregion
                var program = new EM0913S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(program.LK_PROPOSTA.LK_CODPRODU == 99);

            }
        }
        [Fact]
        public static void EM0913S_Tests_Fact_ReturnCode_99()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region param
                var inputParam = new EM0913S_LK_PROPOSTA();
                inputParam.LK_CODPRODU.Value = 100;
                #endregion
                #region R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_APOL_ENDOSSO_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new EM0913S();
                program.Execute(inputParam);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}