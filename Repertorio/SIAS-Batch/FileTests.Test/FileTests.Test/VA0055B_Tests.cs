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
using static Code.VA0055B;

namespace FileTests.Test
{
    [Collection("VA0055B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA0055B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT_1800" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1", q3);

            #endregion

            #region R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1400_00_LE_PROPOFID_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_IND_TP_PROPOSTA" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_LE_PROPOFID_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_LOC_ATIVIDADE" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_COD_USUARIO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R2100_00_INSERT_RELATORI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERT_RELATORI_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2100_00_INSERT_RELATORI_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERT_RELATORI_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "VG078_DES_ANDAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Entrada_VA0055B.txt")]
        public static void VA0055B_Tests_TheoryComSucesso(string ARQUIVO_LEITURA_FILE_NAME_P)
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
                #region R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "123456"},
                { "PROPOVA_COD_SUBGRUPO" , "2"},
                { "PROPOVA_COD_USUARIO" , "555"},
                });
                q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "9874"},
                { "PROPOVA_COD_SUBGRUPO" , "3"},
                { "PROPOVA_COD_USUARIO" , "777"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new VA0055B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                
                //R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val0r) && val0r.Contains("082158110323276"));
                
                //R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPOVA_NUM_CERTIFICADO", out var val1r) && val1r.Contains("082158110323276"));
                Assert.True(envList1.Count > 1);

                //R2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1
                var envList2 = AppSettings.TestSet.DynamicData["R2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1"].DynamicList;
                Assert.True(envList2.Count == 1);

            }
        }
        [Theory]
        [InlineData("Entrada_VA0055B.txt")]
        public static void VA0055B_Tests_TheoryErro_99(string ARQUIVO_LEITURA_FILE_NAME_P)
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
                #region R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1
                var q0 = new DynamicData();
                //q0.AddDynamic(new Dictionary<string, string> { });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1", q0);


                #endregion
                #endregion
                var program = new VA0055B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
        [Theory]
        [InlineData("Entrada_VA0055B_sem_mov.txt")]
        public static void VA0055B_Tests_TheorySemMovimento(string ARQUIVO_LEITURA_FILE_NAME_P)
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
                #endregion
                var program = new VA0055B();
                program.Execute(ARQUIVO_LEITURA_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 01);
            }
        }
    }
}