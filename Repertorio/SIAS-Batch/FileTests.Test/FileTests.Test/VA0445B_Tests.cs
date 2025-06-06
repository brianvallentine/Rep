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
using static Code.VA0445B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0445B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0445B_Tests
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

            #region VA0445B_TCOMIS

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_AGECOBR" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "WHOST_QTDIAS" , ""},
                { "V0PROP_CODUSU" , ""},
                { "V0PROP_NRMATRVEN" , ""},
                { "V0PROP_CODCLIEN" , ""},
                { "V0PROP_OCOREND" , ""},
                { "V0PROP_IMPSEGUR" , ""},
                { "V0PROP_VLPREMIO" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DTPROXVEN" , ""},
                { "V0PROP_CODPRODU" , ""},
                { "V0PROP_NOMPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0445B_TCOMIS", q2);

            #endregion

            #region VA0445B_CERROSP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ERROSP_DESCR_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA0445B_CERROSP", q3);

            #endregion

            #region R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V0CLIE_NOME_RAZAO" , ""},
                { "V0CLIE_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CONV_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q6);

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

            #region R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2215_00_VERIFICA_ERRO_DB_SELECT_1_Query1", q9);

            #endregion

            #region VA0445B_CFONTES

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0FONT_CODFTE" , ""},
                { "V0FONT_NOMEFTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0445B_CFONTES", q10);

            #endregion

            #region R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0PROD_NOMPRODU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q11);

            #endregion

            #region VA0445B_CESCNEG

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V0ESCN_CODESC" , ""},
                { "V0ESCN_NOMEESC" , ""},
                { "V0ESCN_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0445B_CESCNEG", q12);

            #endregion

            #region R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0ESCN_CODESC" , ""},
                { "V0ESCN_NOMEESC" , ""},
                { "V0ESCN_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1", q13);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SVA0445B.VA0445B.TXT", "AVA0445B.VA0445B.TXT", "DVA04455B.VA0445B.TXT", "DSAIDA.VA0445B.TXT", "SSAIDA.VA0445B.TXT")]
        public static void VA0445B_Tests_Theory(string SVA0445B_FILE_NAME_P, string AVA0445B_FILE_NAME_P, string DVA0445B_FILE_NAME_P, string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0445B_FILE_NAME_P = $"{SVA0445B_FILE_NAME_P}_{timestamp}.txt";
            AVA0445B_FILE_NAME_P = $"{AVA0445B_FILE_NAME_P}_{timestamp}.txt";
            DVA0445B_FILE_NAME_P = $"{DVA0445B_FILE_NAME_P}_{timestamp}.txt";
            DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA0445B();
                program.Execute(SVA0445B_FILE_NAME_P, AVA0445B_FILE_NAME_P, DVA0445B_FILE_NAME_P, DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P);

                
                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("SVA0445B.VA0445B.TXT", "AVA0445B.VA0445B.TXT", "DVA04455B.VA0445B.TXT", "DSAIDA.VA0445B.TXT", "SSAIDA.VA0445B.TXT")]
        public static void VA0445B_Tests_TheoryErro(string SVA0445B_FILE_NAME_P, string AVA0445B_FILE_NAME_P, string DVA0445B_FILE_NAME_P, string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0445B_FILE_NAME_P = $"{SVA0445B_FILE_NAME_P}_{timestamp}.txt";
            AVA0445B_FILE_NAME_P = $"{AVA0445B_FILE_NAME_P}_{timestamp}.txt";
            DVA0445B_FILE_NAME_P = $"{DVA0445B_FILE_NAME_P}_{timestamp}.txt";
            DSAIDA_FILE_NAME_P = $"{DSAIDA_FILE_NAME_P}_{timestamp}.txt";
            SSAIDA_FILE_NAME_P = $"{SSAIDA_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0445B();
                program.Execute(SVA0445B_FILE_NAME_P, AVA0445B_FILE_NAME_P, DVA0445B_FILE_NAME_P, DSAIDA_FILE_NAME_P, SSAIDA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 2);
            }
        }
    }
}