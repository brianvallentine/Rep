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
using static Code.AC0017B;

namespace FileTests.Test
{
    [Collection("AC0017B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AC0017B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion //ok

            #region R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WHOST_QTDE_REG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1", q1);

            #endregion //ok

            #region AC0017B_V1MESTSINI

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1MSIN_NUM_SINI" , ""},
                { "V1MSIN_NUM_APOL" , ""},
                { "V1MSIN_NRENDOS" , ""},
                { "V1MSIN_COD_MOEDA" , ""},
                { "V1MSIN_TIPREG" , ""},
                { "V1MSIN_RAMO" , ""},
                { "V1MSIN_CODCAU" , ""},
                { "V1MSIN_DATORR" , ""},
                { "V1MSIN_PCTRES" , ""},
                { "V1HSIN_OCORHIST" , ""},
                { "V1HSIN_OPERACAO" , ""},
                { "V1HSIN_DTMOVTO" , ""},
                { "V1HSIN_VAL_OPER" , ""},
                { "V1HSIN_TIPREG" , ""},
                { "V1HSIN_SITUACAO" , ""},
                { "GEOPERAC_FUNCAO_OPERACAO" , ""},
                { "GEOPERAC_IND_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0017B_V1MESTSINI", q2);

            #endregion

            #region AC0017B_V1APOLCOSCED

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1APCD_CODCOSS" , ""},
                { "V1APCD_PCPARTIC" , ""},
                { "V1APCD_PCCOMCOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("AC0017B_V1APOLCOSCED", q3);

            #endregion

            #region R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0700_00_SELECT_OPER_3035_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_OPERACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0700_00_SELECT_OPER_3035_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_AVS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1000_00_SELECT_GESISFUO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "GESISFUO_IDE_SISTEMA" , ""},
                { "GESISFUO_COD_FUNCAO" , ""},
                { "GESISFUO_IDE_SISTEMA_OPER" , ""},
                { "GESISFUO_NUM_FATOR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_SELECT_GESISFUO_DB_SELECT_1_Query1", q7);

            #endregion//ok

            #region R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTMOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_NUM_APOL" , ""},
                { "V0APOL_TIPSGU" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q9);

            #endregion//ok

            #region R1300_00_SELECT_SX010_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SX010_NUM_APOLICE" , ""},
                { "SX010_DTA_APOLICE" , ""},
                { "SX010_COD_FONTE" , ""},
                { "SX017_NUM_RAMO" , ""},
                { "SX017_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_SX010_DB_SELECT_1_Query1", q10);

            #endregion//ok

            #region R1500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0COTA_VL_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VAL_OPER" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1CSIN_CONGENER" , ""},
                { "V1CSIN_NUM_SINI" , ""},
                { "V1CSIN_TIPSGU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0CSIN_COD_EMP" , ""},
                { "V0CSIN_TIPSGU" , ""},
                { "V0CSIN_CONGENER" , ""},
                { "V0CSIN_NUM_SINI" , ""},
                { "V0CSIN_VAL_OPER" , ""},
                { "V0CSIN_SITUACAO" , ""},
                { "V0CSIN_SIT_CONG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V0CHSI_COD_EMP" , ""},
                { "V0CHSI_CONGENER" , ""},
                { "V0CHSI_NUM_SINI" , ""},
                { "V0CHSI_OCORHIST" , ""},
                { "V0CHSI_OPERACAO" , ""},
                { "V0CHSI_DTMOVTO" , ""},
                { "V0CHSI_VAL_OPER" , ""},
                { "V0CHSI_SITUACAO" , ""},
                { "V0CHSI_TIPSGU" , ""},
                { "V0CHSI_SIT_LIBRECUP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SITUACAO" , ""},
                { "V1CSIN_CONGENER" , ""},
                { "V1CSIN_NUM_SINI" , ""},
                { "V1CSIN_TIPSGU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V2HSIN_VAL_OPER" , ""},
                { "V2HSIN_DTMOVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1", q17);

            #endregion

            #region R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V1COTA_VL_VENDA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1", q18);

            #endregion

            #region R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V2CSIN_COD_EMP" , ""},
                { "V2CSIN_TIPSGU" , ""},
                { "V2CSIN_CONGENER" , ""},
                { "V2CSIN_NUM_SINI" , ""},
                { "V2CSIN_VAL_OPER" , ""},
                { "V2CSIN_SITUACAO" , ""},
                { "V2CSIN_SIT_CONG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1", q19);

            #endregion

            #region R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V2CHSI_COD_EMP" , ""},
                { "V2CHSI_CONGENER" , ""},
                { "V2CHSI_NUM_SINI" , ""},
                { "V2CHSI_OCORHIST" , ""},
                { "V2CHSI_OPERACAO" , ""},
                { "V2CHSI_DTMOVTO" , ""},
                { "V2CHSI_VAL_OPER" , ""},
                { "V2CHSI_SITUACAO" , ""},
                { "V2CHSI_TIPSGU" , ""},
                { "V2CHSI_SIT_LIBRECUP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1", q20);

            #endregion

            #endregion
        }

        [Fact]
        public static void AC0017B_Tests_Fact()
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
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "V0APOL_NUM_APOL" , ""},
                    { "V0APOL_TIPSGU" , ""},
                    { "V0APOL_ORGAO" , ""},
                    { "V0APOL_RAMO" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1", q9);
                #endregion
                var program = new AC0017B();
                program.V1MESTSINI.V1HSIN_OPERACAO = "0101";
                program.Execute();

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                Assert.Empty(AppSettings.TestSet.DynamicData["AC0017B_V1MESTSINI"].DynamicList.ToList());
                Assert.Empty(AppSettings.TestSet.DynamicData["AC0017B_V1APOLCOSCED"].DynamicList.ToList());

                Assert.True(selects.Count >= 5);

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}