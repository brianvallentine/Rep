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
using static Code.VG9545B;

namespace FileTests.Test
{
    [Collection("VG9545B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG9545B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q1);

            #endregion

            #region VG9545B_CCURSOR

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_TIPO_INCLUSAO" , ""},
                { "SEGURVGA_COD_AGENCIADOR" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "SEGURVGA_NATURALIDADE" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG9545B_CCURSOR", q2);

            #endregion

            #region R0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARAMRAM_RAMO_VGAPC" , ""},
                { "PARAMRAM_RAMO_VG" , ""},
                { "PARAMRAM_RAMO_AP" , ""},
                { "PARAMRAM_NUM_RAMO_PRSTMISTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0040_00_VERIFICA_APOLICE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_PRMVG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1", q6);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_PRMAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1", q7);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPINVPERM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1", q8);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_IMPDIT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1", q9);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CONTACOR_COD_AGENCIA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1", q10);

            #endregion

            #region R6000_00_CANCELA_SEGURO_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_TIPO_INCLUSAO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_PERI_PAGAMENTO" , ""},
                { "SEGURVGA_NATURALIDADE" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
                { "CONTACOR_COD_AGENCIA" , ""},
                { "SEGURVGA_NUM_MATRICULA" , ""},
                { "CONTACOR_NUM_CTA_CORRENTE" , ""},
                { "CONTACOR_DAC_CTA_CORRENTE" , ""},
                { "V0COBA_IMPMORNATU" , ""},
                { "V0COBA_IMPMORACID" , ""},
                { "V0COBA_IMPINVPERM" , ""},
                { "V0COBA_IMPDIT" , ""},
                { "V0COBA_PRMVG" , ""},
                { "V0COBA_PRMAP" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "MOVIMVGA_DATA_OPERACAO" , ""},
                { "DATA_REFERENCIA" , ""},
                { "MOVIMVGA_DATA_MOVIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6000_00_CANCELA_SEGURO_DB_INSERT_1_Insert1", q11);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG9545B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG9545B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R6000_00_CANCELA_SEGURO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                

                //var envList1 = AppSettings.TestSet.DynamicData["R6000_00_CANCELA_SEGURO_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList1.Count > 1);

                Assert.True(envList[1].TryGetValue("FONTES_ULT_PROP_AUTOMAT", out var valor) && valor.Contains("000000001"));
                //Assert.True(envList1[1].TryGetValue("MOVIMVGA_PERI_PAGAMENTO", out valor) && valor.Contains("0001"));

            }
        }
    }
}