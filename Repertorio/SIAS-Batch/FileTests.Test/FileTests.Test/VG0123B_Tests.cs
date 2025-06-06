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
using static Code.VG0123B;

namespace FileTests.Test
{
    [Collection("VG0123B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0123B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , "2024-01-01"},
                { "SISTEMA_DTCURRENT" , "2024-05-05"},

            });
            AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NOME_EMPRESA" , "CAIXA SEGURADORA VIDA"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region M_0000_000_PRINCIPAL_DB_SELECT_3_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PARAM_RAMO_VG" , ""},
                { "PARAM_RAMO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_3_Query1", q2);

            #endregion

            #region VG0123B_RELATORIO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RELAT_IDSISTEM" , "VG"},
                { "RELAT_CODRELAT" , "VG0122B"},
                { "RELAT_NUM_APOLICE" , "19790324"},
                { "RELAT_NUM_CERTIFIC" , "1234"},
                { "RELAT_COD_SUBES" , "547"},
                { "RELAT_OPERACAO" , "1"},
                { "RELAT_SITUACAO" , "1"},
                { "RELAT_MES_REFERENCIA" , "5"},
                { "RELAT_ANO_REFERENCIA" , "2024"},
            });
            AppSettings.TestSet.DynamicData.Add("VG0123B_RELATORIO", q3);

            #endregion

            #region VG0123B_SEGURADO1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURAVG_NUM_APOL" , "19790324"},
                { "SEGURAVG_COD_SUBG" , "1"},
                { "SEGURAVG_COD_CLI" , "222"},
                { "SEGURAVG_NUM_CERT" , "4561235"},
                { "SEGURAVG_DAC_CERT" , "2"},
                { "SEGURAVG_TIPO_SEG" , "3"},
                { "SEGURAVG_NUM_ITEM" , "1"},
                { "SEGURAVG_OCORR_HI" , "2"},
                { "SEGURAVG_EST_CIVIL" , "C"},
                { "SEGURAVG_IDE_SEXO" , "M"},
                { "SEGURAVG_MATRICULA" , "33"},
                { "SEGURAVG_DT_INIVI" , "2024-01-01"},
                { "SEGURAVG_SIT_REG" , "1"},
                { "SEGURAVG_DT_NASCI" , "2000-01-01"},
                { "CLIENTE_COD_CLI" , "456"},
                { "CLIENTE_NOME_RAZAO" , "NOME RAZAO CLIENTE"},
                { "CLIENTE_CGC_CPF" , "123456789"},
            });
            AppSettings.TestSet.DynamicData.Add("VG0123B_SEGURADO1", q4);

            #endregion

            #region M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "DATA_REF2" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0110_020_FETCH_RELATORIO_DB_SELECT_1_Query1", q5);

            #endregion

            #region VG0123B_SEGURADO2

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SEGURAVG_NUM_APOL" , ""},
                { "SEGURAVG_COD_SUBG" , ""},
                { "SEGURAVG_COD_CLI" , ""},
                { "SEGURAVG_NUM_CERT" , ""},
                { "SEGURAVG_DAC_CERT" , ""},
                { "SEGURAVG_TIPO_SEG" , ""},
                { "SEGURAVG_NUM_ITEM" , ""},
                { "SEGURAVG_OCORR_HI" , ""},
                { "SEGURAVG_EST_CIVIL" , ""},
                { "SEGURAVG_IDE_SEXO" , ""},
                { "SEGURAVG_MATRICULA" , ""},
                { "SEGURAVG_DT_INIVI" , ""},
                { "SEGURAVG_SIT_REG" , ""},
                { "SEGURAVG_DT_NASCI" , ""},
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0123B_SEGURADO2", q6);

            #endregion

            #region VG0123B_SEGURADO3

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SEGURAVG_NUM_APOL" , ""},
                { "SEGURAVG_COD_SUBG" , ""},
                { "SEGURAVG_COD_CLI" , ""},
                { "SEGURAVG_NUM_CERT" , ""},
                { "SEGURAVG_DAC_CERT" , ""},
                { "SEGURAVG_TIPO_SEG" , ""},
                { "SEGURAVG_NUM_ITEM" , ""},
                { "SEGURAVG_OCORR_HI" , ""},
                { "SEGURAVG_EST_CIVIL" , ""},
                { "SEGURAVG_IDE_SEXO" , ""},
                { "SEGURAVG_MATRICULA" , ""},
                { "SEGURAVG_DT_INIVI" , ""},
                { "SEGURAVG_SIT_REG" , ""},
                { "SEGURAVG_DT_NASCI" , ""},
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0123B_SEGURADO3", q7);

            #endregion

            #region M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , ""},
                { "HISTSEGVG_NUM_ITEM" , ""},
                { "HISTSEGVG_COD_OPER" , ""},
                { "HISTSEGVG_DATA_MOV" , ""},
                { "HISTSEGVG_OCORR_HI" , ""},
                { "HISTSEGVG_COD_MOEDA_IMP" , ""},
                { "HISTSEGVG_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGURAVG_NUM_APOL" , ""},
                { "SEGURAVG_COD_SUBG" , ""},
                { "SEGURAVG_COD_CLI" , ""},
                { "SEGURAVG_NUM_CERT" , ""},
                { "SEGURAVG_DAC_CERT" , ""},
                { "SEGURAVG_TIPO_SEG" , ""},
                { "SEGURAVG_NUM_ITEM" , ""},
                { "SEGURAVG_OCORR_HI" , ""},
                { "SEGURAVG_EST_CIVIL" , ""},
                { "SEGURAVG_IDE_SEXO" , ""},
                { "SEGURAVG_MATRICULA" , ""},
                { "SEGURAVG_DT_INIVI" , ""},
                { "SEGURAVG_SIT_REG" , ""},
                { "SEGURAVG_DT_NASCI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""},
                { "APOLICE_MODALIDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , ""},
                { "COBERAPOL_PREM_IX" , ""},
                { "COBERAPOL_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1", q15);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_3_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1", q16);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_4_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "COBERPR_VLCUSTCAP" , ""},
                { "COBERPR_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_4_Query1", q17);

            #endregion

            #region M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SUBGRUPO_NUM_APOL" , ""},
                { "SUBGRUPO_COD_SUBG" , ""},
                { "SUBGRUPO_COD_CLI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_BANCO" , ""},
                { "CONTACOR_AGENCIA" , ""},
                { "CONTACOR_CTA_COR" , ""},
                { "CONTACOR_DAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1", q19);

            #endregion

            #region M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1", q20);

            #endregion

            #region M_0700_000_UPDATE_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0700_000_UPDATE_DB_UPDATE_1_Update1", q21);

            #endregion

            #endregion
        }
        [Theory]
        [InlineData("RVG0123B_FILE_NAME_P")]
        public static void VG0123B_Tests_Theory_Update_ReturnCode_0(string RVG0123B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0123B_FILE_NAME_P = $"{RVG0123B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , "19790324"},
                { "HISTSEGVG_NUM_ITEM" , "1"},
                { "HISTSEGVG_COD_OPER" , "2"},
                { "HISTSEGVG_DATA_MOV" , "2024-10-10"},
                { "HISTSEGVG_OCORR_HI" , "1"},
                { "HISTSEGVG_COD_MOEDA_IMP" , "1"},
                { "HISTSEGVG_COD_MOEDA_PRM" , "2"},
                });
                q8.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , "20100826"},
                { "HISTSEGVG_NUM_ITEM" , "2"},
                { "HISTSEGVG_COD_OPER" , "4"},
                { "HISTSEGVG_DATA_MOV" , "2024-05-05"},
                { "HISTSEGVG_OCORR_HI" , "3"},
                { "HISTSEGVG_COD_MOEDA_IMP" , "2"},
                { "HISTSEGVG_COD_MOEDA_PRM" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1", q8);

                #endregion
                #region M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "1"}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1", q9);

                #endregion
                #region M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "1"}
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1", q10);

                #endregion
                #region M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , "1"},
                { "COBERAPOL_PREM_IX" , "2"},
                { "COBERAPOL_FATOR_MULTIPLICA" , "1"},
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , "2"},
                { "COBERAPOL_PREM_IX" , "3"},
                { "COBERAPOL_FATOR_MULTIPLICA" , "2"},
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , "2"},
                { "COBERAPOL_PREM_IX" , "3"},
                { "COBERAPOL_FATOR_MULTIPLICA" , "3"},
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , "2"},
                { "COBERAPOL_PREM_IX" , "3"},
                { "COBERAPOL_FATOR_MULTIPLICA" , "4"},
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , "2"},
                { "COBERAPOL_PREM_IX" , "3"},
                { "COBERAPOL_FATOR_MULTIPLICA" , "5"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1", q14);

                #endregion
                #region M_300_150_240_COBERTURAS_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , "10"},
                { "APOLICE_MODALIDA" , "11"},
                });
                q13.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , "11"},
                { "APOLICE_MODALIDA" , "12"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1", q13);

                #endregion
                #region M_300_150_240_COBERTURAS_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , "100"},
                { "CONDTEC_GAR_IPA" , "100"},
                { "CONDTEC_GAR_IPD" , "0"},
                { "CONDTEC_GAR_HD" , "0"},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , "0"},
                { "CONDTEC_GAR_IPA" , "0"},
                { "CONDTEC_GAR_IPD" , "100"},
                { "CONDTEC_GAR_HD" , "100"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1", q15);

                #endregion

                #region M_300_150_240_COBERTURAS_DB_SELECT_3_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , "1000"}
                });
                q16.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , "2000"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1", q16);

                #endregion
                #region M_0700_000_UPDATE_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>
                {
                });
                q21.AddDynamic(new Dictionary<string, string>
                {
                });
                AppSettings.TestSet.DynamicData.Remove("M_0700_000_UPDATE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0700_000_UPDATE_DB_UPDATE_1_Update1", q21);

                #endregion
                #endregion
                var program = new VG0123B();
                program.Execute(RVG0123B_FILE_NAME_P);
                Assert.True(program.RETURN_CODE == 0);
                var envList0 = AppSettings.TestSet.DynamicData["M_0700_000_UPDATE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0.Count > 1);
            }
        }
        [Theory]
        [InlineData("RVG0123B_FILE_NAME_P")]
        public static void VG0123B_Tests_Theory_SemDados_ReturnCode_9(string RVG0123B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0123B_FILE_NAME_P = $"{RVG0123B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("M_0000_000_PRINCIPAL_DB_SELECT_2_Query1");
                #region M_0000_000_PRINCIPAL_DB_SELECT_2_Query1
                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_2_Query1", q1);

                #endregion
                #region M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , "19790324"},
                { "HISTSEGVG_NUM_ITEM" , "1"},
                { "HISTSEGVG_COD_OPER" , "2"},
                { "HISTSEGVG_DATA_MOV" , "2024-10-10"},
                { "HISTSEGVG_OCORR_HI" , "1"},
                { "HISTSEGVG_COD_MOEDA_IMP" , "1"},
                { "HISTSEGVG_COD_MOEDA_PRM" , "2"},
                });
                q8.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , "20100826"},
                { "HISTSEGVG_NUM_ITEM" , "2"},
                { "HISTSEGVG_COD_OPER" , "4"},
                { "HISTSEGVG_DATA_MOV" , "2024-05-05"},
                { "HISTSEGVG_OCORR_HI" , "3"},
                { "HISTSEGVG_COD_MOEDA_IMP" , "2"},
                { "HISTSEGVG_COD_MOEDA_PRM" , "3"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1", q8);

                #endregion
                #region M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "1"}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1", q9);

                #endregion
                #region M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "1"}
                });
                q10.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1", q10);

                #endregion
                #region M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , "1"},
                { "COBERAPOL_PREM_IX" , "2"},
                { "COBERAPOL_FATOR_MULTIPLICA" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1", q14);

                #endregion
                #region M_300_150_240_COBERTURAS_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , "10"},
                { "APOLICE_MODALIDA" , "11"},
                });
                q13.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , "11"},
                { "APOLICE_MODALIDA" , "12"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1", q13);

                #endregion
                #region M_300_150_240_COBERTURAS_DB_SELECT_2_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , "100"},
                { "CONDTEC_GAR_IPA" , "100"},
                { "CONDTEC_GAR_IPD" , "0"},
                { "CONDTEC_GAR_HD" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1", q15);

                #endregion

                #region M_300_150_240_COBERTURAS_DB_SELECT_3_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , "1000"}
                });
                q16.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , "2000"}
                });
                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1", q16);

                #endregion
                #region M_0700_000_UPDATE_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0700_000_UPDATE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("M_0700_000_UPDATE_DB_UPDATE_1_Update1", q21);

                #endregion
                #endregion
                var program = new VG0123B();
                program.Execute(RVG0123B_FILE_NAME_P);
                Assert.True(program.RETURN_CODE == 9);
                var envList0 = AppSettings.TestSet.DynamicData["M_0700_000_UPDATE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0.Count == 0);
            }
        }
    }
}