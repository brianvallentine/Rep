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
using static Code.BI1466B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test
{
    [Collection("BI1466B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI1466B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTMOVABE_1Y" , ""},
                { "V1SIST_DTHOJE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0CONT_DATCEF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1", q1);

            #endregion

            #region BI1466B_TCOMIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUMBIL" , ""},
                { "V0PROP_RAMO" , ""},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_CODUSU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_OCOREND" , ""},
                { "V0PROP_VLPREMIO" , ""},
                { "V0PROP_PROFISSAO" , ""},
                { "V0PROP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI1466B_TCOMIS", q2);

            #endregion

            #region BI1466B_CFONTES

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_CODFTE" , ""},
                { "V0FONT_NOMEFTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI1466B_CFONTES", q3);

            #endregion

            #region R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CONV_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CODPRODU" , ""},
                { "WHOST_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , ""},
                { "V0CLIE_CGCCPF" , ""},
                { "V0CLIE_DTNASC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0ENDE_ENDERECO" , ""},
                { "V0ENDE_BAIRRO" , ""},
                { "V0ENDE_CIDADE" , ""},
                { "V0ENDE_SIGLA_UF" , ""},
                { "V0ENDE_CEP" , ""},
                { "V0ENDE_DDD" , ""},
                { "V0ENDE_TELEFONE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0MALHA_CDFONTE" , ""},
                { "V0MALHA_CDESCNEG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "BILHEERR_NUM_BILHETE" , ""},
                { "BILHEERR_COD_ERRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1", q9);

            #endregion

            #region BI1466B_CESCNEG

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0ESCN_CODESC" , ""},
                { "V0ESCN_NOMEESC" , ""},
                { "V0ESCN_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI1466B_CESCNEG", q10);

            #endregion

            #region R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0ESCN_CODESC" , ""},
                { "V0ESCN_NOMEESC" , ""},
                { "V0ESCN_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SBI1466B.txt", "ABI1466B.txt", "DBI1466B")]
        public static void BI1466B_Tests_Theory(string SBI1466B_FILE_NAME_P, string ABI1466B_FILE_NAME_P, string DBI1466B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SBI1466B_FILE_NAME_P = $"{SBI1466B_FILE_NAME_P}_{timestamp}.txt";
            ABI1466B_FILE_NAME_P = $"{ABI1466B_FILE_NAME_P}_{timestamp}.txt";
            DBI1466B_FILE_NAME_P = $"{DBI1466B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region BI1466B_TCOMIS
                AppSettings.TestSet.DynamicData.Remove("BI1466B_TCOMIS");

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUMBIL" , ""},
                { "V0PROP_RAMO" , "81"},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_CODUSU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_OCOREND" , ""},
                { "V0PROP_VLPREMIO" , ""},
                { "V0PROP_PROFISSAO" , ""},
                { "V0PROP_SITUACAO" , ""},
            }); q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUMBIL" , ""},
                { "V0PROP_RAMO" , "81"},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_CODUSU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_OCOREND" , ""},
                { "V0PROP_VLPREMIO" , ""},
                { "V0PROP_PROFISSAO" , ""},
                { "V0PROP_SITUACAO" , ""},
            }); q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NUMBIL" , ""},
                { "V0PROP_RAMO" , "81"},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_CODUSU" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_OCOREND" , ""},
                { "V0PROP_VLPREMIO" , ""},
                { "V0PROP_PROFISSAO" , ""},
                { "V0PROP_SITUACAO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("BI1466B_TCOMIS", q2);

                #endregion
                #region BI1466B_CFONTES
                AppSettings.TestSet.DynamicData.Remove("BI1466B_CFONTES");

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_CODFTE" , ""},
                { "V0FONT_NOMEFTE" , ""},
            }); q3.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_CODFTE" , ""},
                { "V0FONT_NOMEFTE" , ""},
            }); q3.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_CODFTE" , ""},
                { "V0FONT_NOMEFTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("BI1466B_CFONTES", q3);

                #endregion

                #endregion
                var program = new BI1466B();
                program.Execute(SBI1466B_FILE_NAME_P, ABI1466B_FILE_NAME_P, DBI1466B_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("SBI1466B.txt", "ABI1466B.txt", "DBI1466B")]
        public static void BI1466B_Tests_TheoryErro(string SBI1466B_FILE_NAME_P, string ABI1466B_FILE_NAME_P, string DBI1466B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SBI1466B_FILE_NAME_P = $"{SBI1466B_FILE_NAME_P}_{timestamp}.txt";
            ABI1466B_FILE_NAME_P = $"{ABI1466B_FILE_NAME_P}_{timestamp}.txt";
            DBI1466B_FILE_NAME_P = $"{DBI1466B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new BI1466B();
                program.Execute(SBI1466B_FILE_NAME_P, ABI1466B_FILE_NAME_P, DBI1466B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}