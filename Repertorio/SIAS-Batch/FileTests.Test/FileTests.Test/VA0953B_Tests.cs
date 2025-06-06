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
using static Code.VA0953B;

namespace FileTests.Test
{
    [Collection("VA0953B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0953B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE_1" , ""},
                { "V0SIST_DTMOVABE" , ""},
                { "V0SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_NOME_EMPR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q1);

            #endregion

            #region VA0953B_V0SINISTROS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0953B_V0SINISTROS", q2);

            #endregion

            #region VA0953B_C_SINISACO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CODIGOPE_COD_OPERACAO" , ""},
                { "CODIGOPE_DESCR_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0953B_C_SINISACO", q3);

            #endregion

            #region R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0MSIN_NUM_SINI" , ""},
                { "V0MSIN_NUM_APOL" , ""},
                { "V0MSIN_TIPREG" , ""},
                { "V0MSIN_FONTE" , ""},
                { "V0MSIN_PROTSINI" , ""},
                { "V0MSIN_RAMO" , ""},
                { "V0MSIN_CODLIDER" , ""},
                { "V0MSIN_SINLID" , ""},
                { "V0MSIN_DATCMD" , ""},
                { "V0MSIN_DATORR" , ""},
                { "V0MSIN_DATTEC" , ""},
                { "V0MSIN_NRCERTIF" , ""},
                { "V0MSIN_CODCAU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_VAL_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1205_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_CODUSU_PRE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1205_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_CODUSU_LIB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1206_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0HSIN_VAL_JURO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1207_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "SEGURVGA_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1210_00_SELECT_SEGURVGA_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_SEGURVGA_DB_SELECT_2_Query1", q10);

            #endregion

            #region R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "SEGURVGA_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1215_00_SELECT_BILHETE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1210_00_SELECT_SEGURVGA_DB_SELECT_3_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_SEGURVGA_DB_SELECT_3_Query1", q12);

            #endregion

            #region R1215_00_SELECT_BILHETE_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1215_00_SELECT_BILHETE_DB_SELECT_2_Query1", q13);

            #endregion

            #region R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1215_00_SELECT_BILHETE_DB_SELECT_3_Query1", q14);

            #endregion

            #region R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1", q15);

            #endregion

            #region R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1220_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1410_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_SELECT_FONTES_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1420_00_SELECT_AGENCCEF_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_NOME_AGENCIA" , ""},
                { "AGENCCEF_COD_ESCNEG" , ""},
                { "ESCRINEG_REGIAO_ESCNEG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1420_00_SELECT_AGENCCEF_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "SINISCAU_DESCR_CAUSA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1430_00_SELECT_SINISCAU_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1", q21);

            #endregion

            #region R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "SISINCHE_NUM_CHEQUE_INTERNO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1", q22);

            #endregion

            #region R1600_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q23);

            #endregion

            #region R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_COD_AGENCIA_DEB" , ""},
                { "MOVDEBCE_OPER_CONTA_DEB" , ""},
                { "MOVDEBCE_NUM_CONTA_DEB" , ""},
                { "MOVDEBCE_DIG_CONTA_DEB" , ""},
                { "MOVDEBCE_COD_RETORNO_CEF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q24);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VA0953B_Sort.txt", "VA0953B_AUDTSINI.txt")]
        public static void VA0953B_Tests_Theory_Ramo_77_ReturnCode_0(string ARQSORT_FILE_NAME_P, string AUDTSINI_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            AUDTSINI_FILE_NAME_P = $"{AUDTSINI_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0953B_V0SINISTROS

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "10019790324"},
                { "SINISHIS_COD_OPERACAO" , "1004"},
                { "SINISHIS_OCORR_HISTORICO" , "3"},
                { "SINISHIS_NOME_FAVORECIDO" , "CAIXA ECONOMICA FEDERAL                 "},
                { "SINISHIS_DATA_MOVIMENTO" , "2025-01-24"},
                { "SINISHIS_SIT_CONTABIL" , "1"},
                { "SINISHIS_VAL_OPERACAO" , "579.28"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA0953B_V0SINISTROS");
                AppSettings.TestSet.DynamicData.Add("VA0953B_V0SINISTROS", q2);

                #endregion
                #region R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V0MSIN_NUM_SINI" , ""},
                { "V0MSIN_NUM_APOL" , ""},
                { "V0MSIN_TIPREG" , ""},
                { "V0MSIN_FONTE" , ""},
                { "V0MSIN_PROTSINI" , ""},
                { "V0MSIN_RAMO" , "77"},
                { "V0MSIN_CODLIDER" , ""},
                { "V0MSIN_SINLID" , ""},
                { "V0MSIN_DATCMD" , ""},
                { "V0MSIN_DATORR" , ""},
                { "V0MSIN_DATTEC" , ""},
                { "V0MSIN_NRCERTIF" , "1010"},
                { "V0MSIN_CODCAU" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_MATRI_VENDEDOR" , "895043"},
                { "PROPOVA_COD_PRODUTO" , "9321"},
                { "PROPOVA_AGE_COBRANCA" , "1880"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1");
                AppSettings.TestSet.DynamicData.Add("R1210_00_SELECT_SEGURVGA_DB_SELECT_4_Query1", q15);

                #endregion
                #region R1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "PREFERENCIAL VIDA             "}
                });
                AppSettings.TestSet.DynamicData.Remove("R1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1440_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                var program = new VA0953B();
                program.Execute(ARQSORT_FILE_NAME_P, AUDTSINI_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.V0MSIN_RAMO == 77);
                Assert.True(program.V0MSIN_NRCERTIF == 1010);

            }
        }
        [Theory]
        [InlineData("VA0953B_Sort.txt", "VA0953B_AUDTSINI.txt")]
        public static void VA0953B_Tests_Theory_ReturnCode_99(string ARQSORT_FILE_NAME_P, string AUDTSINI_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            ARQSORT_FILE_NAME_P = $"{ARQSORT_FILE_NAME_P}_{timestamp}.txt";
            AUDTSINI_FILE_NAME_P = $"{AUDTSINI_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0953B_V0SINISTROS

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("VA0953B_V0SINISTROS");
                AppSettings.TestSet.DynamicData.Add("VA0953B_V0SINISTROS", q2);

                #endregion

                #endregion
                var program = new VA0953B();
                program.Execute(ARQSORT_FILE_NAME_P, AUDTSINI_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);


            }
        }
    }
}