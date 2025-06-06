using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VG0410B;

namespace FileTests.Test
{
    [Collection("VG0410B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VG0410B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region M_0000_PROCEDURE_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PROCEDURE_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0410B_MOVIMENTO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVTO_NUM_APOLICE" , ""},
                { "MOVTO_COD_SUBES" , ""},
                { "MOVTO_NUM_CERTIFIC" , ""},
                { "MOVTO_COD_USUARIO" , ""},
                { "MOVTO_COD_OPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0410B_MOVIMENTO", q1);

            #endregion

            #region M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PRDVG_ESTR_EMISS" , ""},
                { "PRDVG_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SEGUVG_SITUACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1", q3);

            #endregion

            #region M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "RELAT_CODRELAT" , ""},
                { "RELAT_IDSISTEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVTO_COD_USUARIO" , ""},
                { "SISTEMA_DTMOVABE" , ""},
                { "RELAT_IDSISTEM" , ""},
                { "RELAT_CODRELAT" , ""},
                { "MOVTO_NUM_APOLICE" , ""},
                { "RELAT_NRPARCEL" , ""},
                { "MOVTO_NUM_CERTIFIC" , ""},
                { "MOVTO_COD_SUBES" , ""},
                { "RELAT_OPERACAO" , ""},
                { "RELAT_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "RELAT_NUM_APOLICE" , ""},
                { "RELAT_COD_SUBES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0090_INCLUI_DADOS_V0RELATORIOS_DB_SELECT_2_Query1", q6);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0410B_NoErrors_ReturnCode0()
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
                var program = new VG0410B();
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToDictionary();

                var insert1 = inserts["M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1"].DynamicList;

                var cursor1 = AppSettings.TestSet.DynamicData["VG0410B_MOVIMENTO"];

                Assert.Equal(5, selects.Count);

                Assert.Equal("0000000000000", insert1[1]["MOVTO_NUM_APOLICE"]);
                Assert.True(inserts.Count == 1);

                Assert.Empty(cursor1.DynamicList);

                Assert.True(program.RETURN_CODE.Value == 0);
            }
        }

        [Theory]
        [InlineData("M_0000_PROCEDURE_DB_SELECT_1_Query1")]
        [InlineData("VG0410B_MOVIMENTO")]
        [InlineData("M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1")]
        [InlineData("M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1")]
        [InlineData("M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1")]
        public static void VG0410B_SqlCodeNotEqualToZero_ReturnCode9(string command)
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

                var q0 = new DynamicData();

                switch (command)
                {
                    case "M_0000_PROCEDURE_DB_SELECT_1_Query1":
                        q0.AddDynamic(
                            new Dictionary<string, string>
                            {
                                { "SISTEMA_DTMOVABE" , ""}
                            },
                            new SQLCA(99));

                        break;

                    case "VG0410B_MOVIMENTO":
                        q0.AddDynamic(
                            new Dictionary<string, string>
                            {
                                { "MOVTO_NUM_APOLICE" , ""},
                                { "MOVTO_COD_SUBES" , ""},
                                { "MOVTO_NUM_CERTIFIC" , ""},
                                { "MOVTO_COD_USUARIO" , ""},
                                { "MOVTO_COD_OPER" , ""}
                            },
                            new SQLCA(99));

                        break;

                    case "M_0010_ACESSA_MOVIMENTO_DB_SELECT_1_Query1":

                        q0.AddDynamic(
                            new Dictionary<string, string>{
                                { "PRDVG_ESTR_EMISS" , ""},
                                { "PRDVG_ORIG_PRODU" , ""},
                            }, 
                            new SQLCA(99));

                        break;
                                            
                    case "M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1":

                        q0.AddDynamic(
                            new Dictionary<string, string>{
                                { "SEGUVG_SITUACAO" , ""}
                            }, 
                            new SQLCA(99));

                        break;

                    case "M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1":

                        q0.AddDynamic(
                            new Dictionary<string, string>
                            {
                                { "MOVTO_COD_USUARIO" , ""},
                                { "SISTEMA_DTMOVABE" , ""},
                                { "RELAT_IDSISTEM" , ""},
                                { "RELAT_CODRELAT" , ""},
                                { "MOVTO_NUM_APOLICE" , ""},
                                { "RELAT_NRPARCEL" , ""},
                                { "MOVTO_NUM_CERTIFIC" , ""},
                                { "MOVTO_COD_SUBES" , ""},
                                { "RELAT_OPERACAO" , ""},
                                { "RELAT_SITUACAO" , ""}
                            }, 
                            new SQLCA(99));

                        break;
                }

                AppSettings.TestSet.DynamicData.Remove(command);
                AppSettings.TestSet.DynamicData.Add(command, q0);

                #endregion

                var program = new VG0410B();
                program.Execute();

                Assert.Equal(9, program.RETURN_CODE.Value);
            }
        }
    }
}