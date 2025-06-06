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
using static Code.VG0120B;

namespace FileTests.Test
{
    [Collection("VG0120B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0120B_Tests
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
                { "PARAM_RAMO_VGAP" , ""},
                { "PARAM_RAMO_VG" , ""},
                { "PARAM_RAMO_AP" , ""},
                { "PARAM_RAMO_PRSTMISTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_000_PRINCIPAL_DB_SELECT_3_Query1", q2);

            #endregion

            #region M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VG083_DTA_INI_FATURA" , ""},
                { "VG083_DTA_FIM_FATURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1", q3);

            #endregion

            #region M_0040_030_BUSCA_VIGENCIA_DB_SELECT_2_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_CERT_PROPVA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_030_BUSCA_VIGENCIA_DB_SELECT_2_Query1", q4);

            #endregion

            #region M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WS_NUM_CERT_PROPVA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_030_BUSCA_VIGENCIA_DB_SELECT_3_Query1", q5);

            #endregion

            #region M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_DTINIVIG_PARC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_030_BUSCA_VIGENCIA_DB_SELECT_4_Query1", q6);

            #endregion

            #region M_0040_030_BUSCA_VIGENCIA_DB_SELECT_5_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WS_PERIPGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_030_BUSCA_VIGENCIA_DB_SELECT_5_Query1", q7);

            #endregion

            #region M_0040_030_BUSCA_VIGENCIA_DB_SELECT_6_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA2" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_030_BUSCA_VIGENCIA_DB_SELECT_6_Query1", q8);

            #endregion

            #region VG0120B_RELATORIO

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RELAT_IDSISTEM" , ""},
                { "RELAT_CODRELAT" , ""},
                { "RELAT_NUM_APOLICE" , ""},
                { "RELAT_NUM_CERTIFIC" , ""},
                { "RELAT_COD_SUBES" , ""},
                { "RELAT_OPERACAO" , ""},
                { "RELAT_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0120B_RELATORIO", q9);

            #endregion

            #region VG0120B_SEGURADO1

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
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0120B_SEGURADO1", q10);

            #endregion

            #region VG0120B_SEGURADO2

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
                { "CLIENTE_COD_CLI" , ""},
                { "CLIENTE_NOME_RAZAO" , ""},
                { "CLIENTE_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0120B_SEGURADO2", q11);

            #endregion

            #region VG0120B_SEGURADO3

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VG0120B_SEGURADO3", q12);

            #endregion

            #region M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "HISTSEGVG_NUM_APOL" , ""},
                { "HISTSEGVG_NUM_ITEM" , ""},
                { "HISTSEGVG_COD_OPER" , ""},
                { "HISTSEGVG_DATA_MOV" , ""},
                { "HISTSEGVG_OCORR_HI" , ""},
                { "HISTSEGVG_COD_MOEDA_IMP" , ""},
                { "HISTSEGVG_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1", q16);

            #endregion

            #region M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLI" , ""},
                { "WHOST_NOME_RAZAO" , ""},
                { "WHOST_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1", q17);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "COBERAPOL_SEGUR_IX" , ""},
                { "COBERAPOL_PREM_IX" , ""},
                { "COBERAPOL_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1", q19);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_2_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""},
                { "APOLICE_MODALIDA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1", q20);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_3_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1", q21);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_4_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_4_Query1", q22);

            #endregion

            #region M_300_150_240_COBERTURAS_DB_SELECT_5_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "COBERPR_VLCUSTCAP" , ""},
                { "COBERPR_QTTITCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_5_Query1", q23);

            #endregion

            #region M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "SUBGRUPO_NUM_APOL" , ""},
                { "SUBGRUPO_COD_SUBG" , ""},
                { "SUBGRUPO_COD_CLI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1", q24);

            #endregion

            #region M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_BANCO" , ""},
                { "CONTACOR_AGENCIA" , ""},
                { "CONTACOR_CTA_COR" , ""},
                { "CONTACOR_DAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1", q25);

            #endregion

            #region M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CLI" , ""},
                { "WHOST_NOME_RAZAO" , ""},
                { "WHOST_CGC_CPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1", q26);

            #endregion

            #region M_0700_000_UPDATE_DB_UPDATE_1_Update1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "RELAT_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0700_000_UPDATE_DB_UPDATE_1_Update1", q27);

            #endregion

            #region M_0700_000_UPDATE_DB_UPDATE_2_Update1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "RELAT_NUM_APOLICE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0700_000_UPDATE_DB_UPDATE_2_Update1", q28);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("RVG0120B_FILE_NAME_P")]
        public static void VG0120B_Tests_Theory(string RVG0120B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG0120B_FILE_NAME_P = $"{RVG0120B_FILE_NAME_P}_{timestamp}.txt";
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

                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1");
                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1", q14);


                AppSettings.TestSet.DynamicData.Remove("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1");
                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                q15.AddDynamic(new Dictionary<string, string>{
                { "MOEDA_VLCRUZADO" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1", q15);

                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1");
                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""}
                });
                q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""}
                });
                q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""}
                });
                q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_1_Query1", q18);

                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1");
                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""},
                { "APOLICE_MODALIDA" , ""},
                });
                q20.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""},
                { "APOLICE_MODALIDA" , ""},
                });
                q20.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""},
                { "APOLICE_MODALIDA" , ""},
                });
                q20.AddDynamic(new Dictionary<string, string>{
                { "APOLICE_RAMO" , ""},
                { "APOLICE_MODALIDA" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_2_Query1", q20);


                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1");
                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });
                q21.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });
                q21.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });
                q21.AddDynamic(new Dictionary<string, string>{
                { "CONDTEC_GAR_IEA" , ""},
                { "CONDTEC_GAR_IPA" , ""},
                { "CONDTEC_GAR_IPD" , ""},
                { "CONDTEC_GAR_HD" , ""},
                });

                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_3_Query1", q21);

                AppSettings.TestSet.DynamicData.Remove("M_300_150_240_COBERTURAS_DB_SELECT_4_Query1");
                var q22 = new DynamicData();
                q22.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , ""}
                });
                q22.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , ""}
                });
                q22.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_CUSTOCAP_TOTAL" , ""}
                });
                AppSettings.TestSet.DynamicData.Add("M_300_150_240_COBERTURAS_DB_SELECT_4_Query1", q22);

                AppSettings.TestSet.DynamicData.Remove("VG0120B_RELATORIO");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "RELAT_IDSISTEM" , ""},
                { "RELAT_CODRELAT" , ""},
                { "RELAT_NUM_APOLICE" , "0000000000123"},
                { "RELAT_NUM_CERTIFIC" , ""},
                { "RELAT_COD_SUBES" , ""},
                { "RELAT_OPERACAO" , ""},
                { "RELAT_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VG0120B_RELATORIO", q9);
                #endregion
                var program = new VG0120B();
                program.Execute(RVG0120B_FILE_NAME_P);

                var envList1 = AppSettings.TestSet.DynamicData["M_0700_000_UPDATE_DB_UPDATE_2_Update1"].DynamicList;

                Assert.True(envList1?.Count > 1);

                Assert.True(envList1[1].TryGetValue("RELAT_NUM_APOLICE", out var val1r) && val1r.Equals("0000000000123"));
            }
        }
    }
}