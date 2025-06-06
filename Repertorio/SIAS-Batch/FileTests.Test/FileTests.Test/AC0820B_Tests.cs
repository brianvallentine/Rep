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
using static Code.AC0820B;

namespace FileTests.Test
{
    [Collection("AC0820B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class AC0820B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE_AC" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_AC_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE_FI" , ""},
                { "V0SIST_DTCURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V0SISTEMA_FI_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_NOM_EMP" , ""},
                { "V0EMPR_CGCCPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q2);

            #endregion

            #region AC0820B_V0COSCEDCHQ

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCCH_COD_EMPR" , ""},
                { "V0CCCH_CONGENER" , ""},
                { "V0CCCH_DTMOVTAC" , ""},
                { "V0CCCH_DTLIBERA" , ""},
                { "V0CCCH_VLPREMIO" , ""},
                { "V0CCCH_VLRSINI" , ""},
                { "V0CCCH_VLDESPESA" , ""},
                { "V0CCCH_VLRHONOR" , ""},
                { "V0CCCH_VLRSALVD" , ""},
                { "V0CCCH_VLRESSARC" , ""},
                { "V0CCCH_VLDESPADM" , ""},
                { "V0CCCH_OUTRDEBIT" , ""},
                { "V0CCCH_OUTRCREDT" , ""},
                { "V0CCCH_VLRSLDANT" , ""},
                { "V0CCCH_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0820B_V0COSCEDCHQ", q3);

            #endregion

            #region AC0820B_V0COSSEGCED

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("AC0820B_V0COSSEGCED", q4);

            #endregion

            #region R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_COD_EMP" , ""},
                { "V0EMPR_NOM_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONG_CONGENER" , ""},
                { "V0CONG_NOMECONG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1", q6);

            #endregion

            #region AC0820B_V0COSHISTPRE

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0CHSP_NUM_APOL" , ""},
                { "V0CHSP_NRENDOS" , ""},
                { "V0CHSP_NRPARCEL" , ""},
                { "V0CHSP_OCORHIST" , ""},
                { "V0CHSP_DTMOVTO" , ""},
                { "V0CHSP_OPERACAO" , ""},
                { "V0CHSP_PRM_TAR" , ""},
                { "V0CHSP_VAL_DESC" , ""},
                { "V0CHSP_VLPRMLIQ" , ""},
                { "V0CHSP_VLADIFRA" , ""},
                { "V0CHSP_VLCOMIS" , ""},
                { "V0CHSP_VLPRMTOT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0820B_V0COSHISTPRE", q7);

            #endregion

            #region AC0820B_V0COSHISTSIN

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0CHIS_NUM_SINI" , ""},
                { "V0CHIS_OCORHIST" , ""},
                { "V0CHIS_OPERACAO" , ""},
                { "V0CHIS_DTMOVTO" , ""},
                { "V0CHIS_VAL_OPER" , ""},
                { "GESISFUO_IDE_SISTEMA" , ""},
                { "GESISFUO_COD_FUNCAO" , ""},
                { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                { "GESISFUO_NUM_FATOR" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0820B_V0COSHISTSIN", q8);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_AC0820B11.txt", "Saida_AC0820B21.txt", "Saida_AC0820B31.txt")]
        public static void AC0820B_Tests_Theory_Empresa_REG_AC0820B1_REG_AC0820B2(string AC0820B1_FILE_NAME_P, string AC0820B2_FILE_NAME_P, string AC0820B3_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AC0820B1_FILE_NAME_P = $"{AC0820B1_FILE_NAME_P}_{timestamp}.txt";
            AC0820B2_FILE_NAME_P = $"{AC0820B2_FILE_NAME_P}_{timestamp}.txt";
            AC0820B3_FILE_NAME_P = $"{AC0820B3_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region AC0820B_V0COSCEDCHQ

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCCH_COD_EMPR" , "00"},
                { "V0CCCH_CONGENER" , ""},
                { "V0CCCH_DTMOVTAC" , ""},
                { "V0CCCH_DTLIBERA" , ""},
                { "V0CCCH_VLPREMIO" , ""},
                { "V0CCCH_VLRSINI" , ""},
                { "V0CCCH_VLDESPESA" , ""},
                { "V0CCCH_VLRHONOR" , ""},
                { "V0CCCH_VLRSALVD" , ""},
                { "V0CCCH_VLRESSARC" , ""},
                { "V0CCCH_VLDESPADM" , ""},
                { "V0CCCH_OUTRDEBIT" , ""},
                { "V0CCCH_OUTRCREDT" , ""},
                { "V0CCCH_VLRSLDANT" , ""},
                { "V0CCCH_SITUACAO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCCH_COD_EMPR" , "10"},
                { "V0CCCH_CONGENER" , ""},
                { "V0CCCH_DTMOVTAC" , ""},
                { "V0CCCH_DTLIBERA" , ""},
                { "V0CCCH_VLPREMIO" , ""},
                { "V0CCCH_VLRSINI" , ""},
                { "V0CCCH_VLDESPESA" , ""},
                { "V0CCCH_VLRHONOR" , ""},
                { "V0CCCH_VLRSALVD" , ""},
                { "V0CCCH_VLRESSARC" , ""},
                { "V0CCCH_VLDESPADM" , ""},
                { "V0CCCH_OUTRDEBIT" , ""},
                { "V0CCCH_OUTRCREDT" , ""},
                { "V0CCCH_VLRSLDANT" , ""},
                { "V0CCCH_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0820B_V0COSCEDCHQ");
                AppSettings.TestSet.DynamicData.Add("AC0820B_V0COSCEDCHQ", q3);

                #endregion

                #region R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_NOM_EMP" , "00"},
                { "V0EMPR_CGCCPF" , "EMPRESA 00"},
            });
                q2.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_NOM_EMP" , "10"},
                { "V0EMPR_CGCCPF" , "EMPRESA 10"},
            });
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_COD_EMP" , "00"},
                { "V0EMPR_NOM_EMP" , "EMPRESA 00"},
                });
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_COD_EMP" , "10"},
                { "V0EMPR_NOM_EMP" , "EMPRESA 10"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q5);

                #endregion
                #region R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONG_CONGENER" , "11"},
                { "V0CONG_NOMECONG" , "NOME CONGENERE 11"},
                }); 
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONG_CONGENER" , "12"},
                { "V0CONG_NOMECONG" , "NOME CONGENERE 12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new AC0820B();
                program.Execute(AC0820B1_FILE_NAME_P, AC0820B2_FILE_NAME_P, AC0820B3_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(!program.REG_AC0820B1.IsEmpty());
                Assert.True(!program.REG_AC0820B2.IsEmpty());
                Assert.True(program.REG_AC0820B3.IsEmpty());
                Assert.True(program.AREA_DE_WORK.AC_L_V0COSCEDCHQ.Value == 2);

            }
        }
        [Theory]
        [InlineData("Saida_AC0820B12.txt", "Saida_AC0820B22.txt", "Saida_AC0820B32.txt")]
        public static void AC0820B_Tests_Theory_Empresa_REG_AC0820B1_REG_AC0820B3(string AC0820B1_FILE_NAME_P, string AC0820B2_FILE_NAME_P, string AC0820B3_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AC0820B1_FILE_NAME_P = $"{AC0820B1_FILE_NAME_P}_{timestamp}.txt";
            AC0820B2_FILE_NAME_P = $"{AC0820B2_FILE_NAME_P}_{timestamp}.txt";
            AC0820B3_FILE_NAME_P = $"{AC0820B3_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region AC0820B_V0COSCEDCHQ

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCCH_COD_EMPR" , "00"},
                { "V0CCCH_CONGENER" , ""},
                { "V0CCCH_DTMOVTAC" , ""},
                { "V0CCCH_DTLIBERA" , ""},
                { "V0CCCH_VLPREMIO" , ""},
                { "V0CCCH_VLRSINI" , ""},
                { "V0CCCH_VLDESPESA" , ""},
                { "V0CCCH_VLRHONOR" , ""},
                { "V0CCCH_VLRSALVD" , ""},
                { "V0CCCH_VLRESSARC" , ""},
                { "V0CCCH_VLDESPADM" , ""},
                { "V0CCCH_OUTRDEBIT" , ""},
                { "V0CCCH_OUTRCREDT" , ""},
                { "V0CCCH_VLRSLDANT" , ""},
                { "V0CCCH_SITUACAO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                { "V0CCCH_COD_EMPR" , "20"},
                { "V0CCCH_CONGENER" , ""},
                { "V0CCCH_DTMOVTAC" , ""},
                { "V0CCCH_DTLIBERA" , ""},
                { "V0CCCH_VLPREMIO" , ""},
                { "V0CCCH_VLRSINI" , ""},
                { "V0CCCH_VLDESPESA" , ""},
                { "V0CCCH_VLRHONOR" , ""},
                { "V0CCCH_VLRSALVD" , ""},
                { "V0CCCH_VLRESSARC" , ""},
                { "V0CCCH_VLDESPADM" , ""},
                { "V0CCCH_OUTRDEBIT" , ""},
                { "V0CCCH_OUTRCREDT" , ""},
                { "V0CCCH_VLRSLDANT" , ""},
                { "V0CCCH_SITUACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("AC0820B_V0COSCEDCHQ");
                AppSettings.TestSet.DynamicData.Add("AC0820B_V0COSCEDCHQ", q3);

                #endregion

                #region R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_COD_EMP" , "00"},
                { "V0EMPR_NOM_EMP" , "EMPRESA 00"},
                });
                q5.AddDynamic(new Dictionary<string, string>{
                { "V0EMPR_COD_EMP" , "20"},
                { "V0EMPR_NOM_EMP" , "EMPRESA 20"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q5);

                #endregion
                #region R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1");
                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "V0EMPR_NOM_EMP" , "00"},
                    { "V0EMPR_CGCCPF" , "EMPRESA 00"},
                }); q2.AddDynamic(new Dictionary<string, string>{
                    { "V0EMPR_NOM_EMP" , "20"},
                    { "V0EMPR_CGCCPF" , "EMPRESA 20"},
                });
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q2);

                #endregion
                #region R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONG_CONGENER" , "11"},
                { "V0CONG_NOMECONG" , "NOME CONGENERE 11"},
                });
                q6.AddDynamic(new Dictionary<string, string>{
                { "V0CONG_CONGENER" , "13"},
                { "V0CONG_NOMECONG" , "NOME CONGENERE 12"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0800_00_SELECT_V0CONGENERE_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new AC0820B();
                program.Execute(AC0820B1_FILE_NAME_P, AC0820B2_FILE_NAME_P, AC0820B3_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(!program.REG_AC0820B1.IsEmpty());
                Assert.True(program.REG_AC0820B2.IsEmpty());
                Assert.True(!program.REG_AC0820B3.IsEmpty());
                Assert.True(program.AREA_DE_WORK.AC_L_V0COSCEDCHQ.Value == 2);

            }
        }
        [Theory]
        [InlineData("Saida_AC0820B1.txt", "Saida_AC0820B2.txt", "Saida_AC0820B3.txt")]
        public static void AC0820B_Tests_Theory_ReturnCode_99(string AC0820B1_FILE_NAME_P, string AC0820B2_FILE_NAME_P, string AC0820B3_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AC0820B1_FILE_NAME_P = $"{AC0820B1_FILE_NAME_P}_{timestamp}.txt";
            AC0820B2_FILE_NAME_P = $"{AC0820B2_FILE_NAME_P}_{timestamp}.txt";
            AC0820B3_FILE_NAME_P = $"{AC0820B3_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q2);

                #endregion
                #endregion
                var program = new AC0820B();
                program.Execute(AC0820B1_FILE_NAME_P, AC0820B2_FILE_NAME_P, AC0820B3_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
                Assert.True(program.REG_AC0820B1.IsEmpty());
                Assert.True(program.REG_AC0820B2.IsEmpty());
                Assert.True(program.REG_AC0820B3.IsEmpty());
                Assert.True(program.AREA_DE_WORK.AC_L_V0COSCEDCHQ.Value == 0);

            }
        }
    }
}