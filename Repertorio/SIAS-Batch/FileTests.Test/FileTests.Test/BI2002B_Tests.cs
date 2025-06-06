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
using static Code.BI2002B;

namespace FileTests.Test
{
    [Collection("BI2002B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI2002B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region BI2002B_V0MOVIMCOB

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "MOVIMCOB_DATA_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_APOLICE" , ""},
                { "MOVIMCOB_NUM_ENDOSSO" , ""},
                { "MOVIMCOB_NUM_PARCELA" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_TIPO_MOVIMENTO" , ""},
                { "MOVIMCOB_NUM_NOSSO_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI2002B_V0MOVIMCOB", q1);

            #endregion

            #region BI2002B_V0CBCONDEV

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_TITULO" , ""},
                { "CBCONDEV_NUM_APOLICE" , ""},
                { "CBCONDEV_NUM_ENDOSSO" , ""},
                { "CBCONDEV_NUM_PARCELA" , ""},
                { "CBCONDEV_NUM_CERTIFICADO" , ""},
                { "CBCONDEV_NUM_MATRICULA" , ""},
                { "CBCONDEV_COD_PRODUTO" , ""},
                { "CBCONDEV_SIT_REGISTRO" , ""},
                { "CBCONDEV_VAL_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI2002B_V0CBCONDEV", q2);

            #endregion

            #region R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0500_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "CBCONDEV_NUM_APOLICE" , ""},
                { "CBCONDEV_NUM_ENDOSSO" , ""},
                { "CBCONDEV_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "CBCONDEV_NUM_APOLICE" , ""},
                { "CBCONDEV_NUM_ENDOSSO" , ""},
                { "CBCONDEV_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_NUM_APOLICE" , ""},
                { "CBCONDEV_NUM_ENDOSSO" , ""},
                { "CBCONDEV_NUM_PARCELA" , ""},
                { "CBCONDEV_COD_PRODUTO" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PARCEHIS_NUM_APOLICE" , ""},
                { "PARCEHIS_NUM_ENDOSSO" , ""},
                { "PARCEHIS_NUM_PARCELA" , ""},
                { "PARCEHIS_DAC_PARCELA" , ""},
                { "PARCEHIS_DATA_MOVIMENTO" , ""},
                { "PARCEHIS_COD_OPERACAO" , ""},
                { "PARCEHIS_OCORR_HISTORICO" , ""},
                { "PARCEHIS_PRM_TARIFARIO" , ""},
                { "PARCEHIS_VAL_DESCONTO" , ""},
                { "PARCEHIS_PRM_LIQUIDO" , ""},
                { "PARCEHIS_ADICIONAL_FRACIO" , ""},
                { "PARCEHIS_VAL_CUSTO_EMISSAO" , ""},
                { "PARCEHIS_VAL_IOCC" , ""},
                { "PARCEHIS_PRM_TOTAL" , ""},
                { "PARCEHIS_VAL_OPERACAO" , ""},
                { "PARCEHIS_DATA_VENCIMENTO" , ""},
                { "PARCEHIS_BCO_COBRANCA" , ""},
                { "PARCEHIS_AGE_COBRANCA" , ""},
                { "PARCEHIS_NUM_AVISO_CREDITO" , ""},
                { "PARCEHIS_ENDOS_CANCELA" , ""},
                { "PARCEHIS_SIT_CONTABIL" , ""},
                { "PARCEHIS_COD_USUARIO" , ""},
                { "PARCEHIS_RENUM_DOCUMENTO" , ""},
                { "PARCEHIS_DATA_QUITACAO" , ""},
                { "PARCEHIS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CBCONDEV_VAL_TITULO" , ""},
                { "MOVIMCOB_COD_AGENCIA" , ""},
                { "MOVIMCOB_COD_BANCO" , ""},
                { "MOVIMCOB_NUM_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1", q12);

            #endregion

            #endregion
        }

        [Fact]
        public static void BI2002B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                var program = new BI2002B();
                program.Execute();

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("CBCONDEV_NUM_CERTIFICADO", out var valor) && valor == "000000000000000");

                var envList1 = AppSettings.TestSet.DynamicData["R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("PARCEHIS_OCORR_HISTORICO", out valor) && valor == "0001");

                var envList2 = AppSettings.TestSet.DynamicData["R0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("PARCEHIS_COD_OPERACAO", out valor) && valor == "0201");

                var envList3 = AppSettings.TestSet.DynamicData["R0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3.Count > 1);
                Assert.True(envList3[1].TryGetValue("PARCEHIS_COD_OPERACAO", out valor) && valor == "0201");

                var envList4 = AppSettings.TestSet.DynamicData["R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4.Count > 1);
                Assert.True(envList4[1].TryGetValue("CBCONDEV_VAL_TITULO", out valor) && valor == "0000000000000.00");

                Assert.True(program.RETURN_CODE == 0);

            }
        }
        [Fact]
        public static void BI2002B_Tests_Erro()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new BI2002B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}