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
using static Code.VG0121B;

namespace FileTests.Test
{
    [Collection("VG0121B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0121B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0000_000_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "NOME_EMPRESA" , ""}
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

            #region VG0121B_RELATORIO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RELAT_IDSISTEM" , ""},
                { "RELAT_CODRELAT" , ""},
                { "RELAT_NUM_APOLICE" , ""},
                { "RELAT_NUM_CERTIFIC" , ""},
                { "RELAT_COD_SUBES" , ""},
                { "RELAT_OPERACAO" , ""},
                { "RELAT_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0121B_RELATORIO", q3);

            #endregion

            #region VG0121B_SEGURADO1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VG0121B_SEGURADO1", q4);

            #endregion

            #region VG0121B_SEGURADO2

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VG0121B_SEGURADO2", q5);

            #endregion

            #region VG0121B_SEGURADO3

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
            AppSettings.TestSet.DynamicData.Add("VG0121B_SEGURADO3", q6);

            #endregion

            #region M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , ""},
                { "HISTSEGVG_NUM_ITEM" , ""},
                { "HISTSEGVG_COD_OPER" , ""},
                { "HISTSEGVG_DATA_MOV" , ""},
                { "HISTSEGVG_OCORR_HI" , ""},
                { "HISTSEGVG_COD_MOEDA_IMP" , ""},
                { "HISTSEGVG_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1", q7);

            #endregion

            #region M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1", q8);

            #endregion

            #region M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1", q10);

            #endregion

            #region M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , ""},
                { "COBERAPOL_PREM_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SUBGRUPO_NUM_APOL" , ""},
                { "SUBGRUPO_COD_SUBG" , ""},
                { "SUBGRUPO_COD_CLI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_BANCO" , ""},
                { "CONTACOR_AGENCIA" , ""},
                { "CONTACOR_CTA_COR" , ""},
                { "CONTACOR_DAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1", q16);

            #endregion

            #region M_0700_000_UPDATE_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0700_000_UPDATE_DB_UPDATE_1_Update1", q17);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RVG0121B_FILE_NAME_P")]
        public static void VG0121B_Tests_Theory_ReturnCode_0(string RVG0121B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0121B_FILE_NAME_P = $"{RVG0121B_FILE_NAME_P}_{timestamp}.txt";
            
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
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                   "}
                });
                AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_2_Query1", q1);


                AppSettings.TestSet.DynamicData.Remove("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , ""},
                { "HISTSEGVG_NUM_ITEM" , ""},
                { "HISTSEGVG_COD_OPER" , ""},
                { "HISTSEGVG_DATA_MOV" , ""},
                { "HISTSEGVG_OCORR_HI" , ""},
                { "HISTSEGVG_COD_MOEDA_IMP" , ""},
                { "HISTSEGVG_COD_MOEDA_PRM" , ""},
                });

                q7.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , ""},
                { "HISTSEGVG_NUM_ITEM" , ""},
                { "HISTSEGVG_COD_OPER" , ""},
                { "HISTSEGVG_DATA_MOV" , ""},
                { "HISTSEGVG_OCORR_HI" , ""},
                { "HISTSEGVG_COD_MOEDA_IMP" , ""},
                { "HISTSEGVG_COD_MOEDA_PRM" , ""},
                });

                q7.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , ""},
                { "HISTSEGVG_NUM_ITEM" , ""},
                { "HISTSEGVG_COD_OPER" , ""},
                { "HISTSEGVG_DATA_MOV" , ""},
                { "HISTSEGVG_OCORR_HI" , ""},
                { "HISTSEGVG_COD_MOEDA_IMP" , ""},
                { "HISTSEGVG_COD_MOEDA_PRM" , ""},
                });
                q7.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , ""},
                { "HISTSEGVG_NUM_ITEM" , ""},
                { "HISTSEGVG_COD_OPER" , ""},
                { "HISTSEGVG_DATA_MOV" , ""},
                { "HISTSEGVG_OCORR_HI" , ""},
                { "HISTSEGVG_COD_MOEDA_IMP" , ""},
                { "HISTSEGVG_COD_MOEDA_PRM" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1", q7);

                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1");
                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q8.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q8.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q8.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1", q8);

                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1", q9);

                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1");
                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });
                q12.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });
                q12.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });
                q12.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1", q12);

                AppSettings.TestSet.DynamicData.Remove("M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1");
                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_BANCO" , ""},
                { "CONTACOR_AGENCIA" , ""},
                { "CONTACOR_CTA_COR" , ""},
                { "CONTACOR_DAC" , ""},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_BANCO" , ""},
                { "CONTACOR_AGENCIA" , ""},
                { "CONTACOR_CTA_COR" , ""},
                { "CONTACOR_DAC" , ""},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_BANCO" , ""},
                { "CONTACOR_AGENCIA" , ""},
                { "CONTACOR_CTA_COR" , ""},
                { "CONTACOR_DAC" , ""},
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_BANCO" , ""},
                { "CONTACOR_AGENCIA" , ""},
                { "CONTACOR_CTA_COR" , ""},
                { "CONTACOR_DAC" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1", q15);
                #endregion
                var program = new VG0121B();
                program.Execute(RVG0121B_FILE_NAME_P);
                Assert.True(program.RETURN_CODE == 0);

                var envList = AppSettings.TestSet.DynamicData["M_0700_000_UPDATE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("UpdateCheck", out var valOr) && valOr == "UpdateCheck");

            }
        }
        [Theory]
        [InlineData("RVG0121B_FILE_NAME_P")]
        public static void VG0121B_Tests_Theory_ReturnCode_9(string RVG0121B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0121B_FILE_NAME_P = $"{RVG0121B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region M_0000_000_PRINCIPAL_DB_SELECT_3_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("M_0000_000_PRINCIPAL_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_3_Query1", q2);

                AppSettings.TestSet.DynamicData.Remove("M_0000_000_PRINCIPAL_DB_SELECT_2_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "NOME_EMPRESA" , "CAIXA SEGURADORA S.A.                   "}
                });
                AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_2_Query1", q1);



                #endregion
                #endregion
                var program = new VG0121B();
                program.Execute(RVG0121B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}