using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0417B;

namespace FileTests.Test
{
    [Collection("VA0417B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0417B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , "2024-09-02"}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTREFER" , "2007-11-30"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTREFER" , "2007-12-28"}
            });
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_DTREFER" , "2008-01-31"}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1", q1);

            #endregion

            #region VA0417B_CHCONT

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCON_APOLICE" , "93010000890"},
                { "V0HCON_CODSUBES" , "12"},
                { "V0HCON_FONTE" , "10"},
                { "V0HCON_NRENDOS" , "0"},
                { "V0HCON_NRPARCEL" , "1"},
                { "V0HCON_CODOPER" , "260"},
                { "V0FONT_NOMEFTE" , "MATRIZ"},
                { "V0PROD_NOMPRODU" , "PREFERENCIAL VIDA PARENTES"},
                { "V0HCON_PRMTOTAL" , "59.20"},
                { "V0HCON_QTD" , "1"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCON_APOLICE" , "93010000890"},
                { "V0HCON_CODSUBES" , "13"},
                { "V0HCON_FONTE" , "1"},
                { "V0HCON_NRENDOS" , "0"},
                { "V0HCON_NRPARCEL" , "64"},
                { "V0HCON_CODOPER" , "250"},
                { "V0FONT_NOMEFTE" , "RIO DE JANEIRO"},
                { "V0PROD_NOMPRODU" , "PREF. VIDA - ATIVOS CEF"},
                { "V0HCON_PRMTOTAL" , "952.38"},
                { "V0HCON_QTD" , "1"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0HCON_APOLICE" , "93010000890"},
                { "V0HCON_CODSUBES" , "13"},
                { "V0HCON_FONTE" , "6"},
                { "V0HCON_NRENDOS" , "0"},
                { "V0HCON_NRPARCEL" , "27"},
                { "V0HCON_CODOPER" , "260"},
                { "V0FONT_NOMEFTE" , "CEARA"},
                { "V0PROD_NOMPRODU" , "PREF. VIDA - ATIVOS CEF"},
                { "V0HCON_PRMTOTAL" , "444.23"},
                { "V0HCON_QTD" , "7"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0417B_CHCONT", q2);

            #endregion

            #region R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOMEAPOL" , "FEDERACAO NAC ASSOC PESSOAL DA CEF"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOMEAPOL" , "FEDERACAO NAC ASSOC PESSOAL DA CEF"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOMEAPOL" , "FEDERACAO NAC ASSOC PESSOAL DA CEF"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APOL_NOMEAPOL" , "FEDERACAO NAC ASSOC PESSOAL DA CEF"}
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_SELECT_V1APOLICE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q4);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_VA0417B.txt")]
        public static void VA0417B_Tests_Theory(string RVA0417B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA0417B_FILE_NAME_P = $"{RVA0417B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA0417B();
                program.Execute(RVA0417B_FILE_NAME_P);

                // chamada de metodo comentado no COBOL, portanto query de update nao é acessada.
                //var envlist = AppSettings.TestSet.DynamicData["R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1"].DynamicList;
                

                Assert.True(program.RETURN_CODE == 0);
            }
        }
        [Theory]
        [InlineData("Saida_VA0417B.txt")]
        public static void VA0417B_Tests_Theory1(string RVA0417B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVA0417B_FILE_NAME_P = $"{RVA0417B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new VA0417B();
                program.Execute(RVA0417B_FILE_NAME_P);



                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}