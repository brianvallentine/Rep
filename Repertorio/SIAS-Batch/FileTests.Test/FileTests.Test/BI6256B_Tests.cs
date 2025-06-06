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
using static Code.BI6256B;
using System.IO;
using Sias.Bilhetes.DB2.BI6256B;

namespace FileTests.Test
{
    [Collection("BI6256B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI6256B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DTMOVABE20" , ""},
                { "WSHOST_DATA_CURRENT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_PROCESSA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_DATA_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_PROCESSA_DB_SELECT_1_Query1", q1);

            #endregion

            #region BI6256B_V0MOVDEBCE

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
                { "MOVDEBCE_DIA_DEBITO" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_STATUS_CARTAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI6256B_V0MOVDEBCE", q2);

            #endregion

            #region R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_NSAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0510_00_SELECT_GE381_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOSTA_COD_FONTE" , ""},
                { "PROPOSTA_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "GE381_COD_BCO" , ""},
                { "GE381_COD_AGENCIA" , ""},
                { "GE381_COD_AGENCIA_DV" , ""},
                { "GE381_COD_OPERACAO" , ""},
                { "GE381_NUM_CONTA" , ""},
                { "GE381_NUM_CONTA_DV1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0510_00_SELECT_GE381_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PARCELAS_NUM_APOLICE" , ""},
                { "PARCELAS_NUM_ENDOSSO" , ""},
                { "PARCELAS_NUM_PARCELA" , ""},
                { "PARCELAS_SIT_REGISTRO" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_QTD_PARCELAS" , ""},
                { "GE381_COD_BCO" , ""},
                { "GE381_COD_AGENCIA" , ""},
                { "GE381_COD_AGENCIA_DV" , ""},
                { "GE381_COD_OPERACAO" , ""},
                { "GE381_NUM_CONTA" , ""},
                { "GE381_NUM_CONTA_DV1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "PARAMCON_NSAS" , ""},
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_DATA_VENCIMENTO" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_NUM_APOLICE" , ""},
                { "MOVDEBCE_NUM_ENDOSSO" , ""},
                { "MOVDEBCE_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1", q6);

            #endregion

            #region R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_QTD_PARCELAS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WSHOST_DTMOVABE20" , ""},
                { "PARAMCON_NSAS" , ""},
                { "PARAMCON_TIPO_MOVTO_CC" , ""},
                { "PARAMCON_COD_CONVENIO" , ""},
                { "PARAMCON_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1", q8);

            #endregion

            GEJVS002_Tests.Load_Parameters();

            #endregion
        }

        [Theory]
        [InlineData(" BI6256B_MOV1.TXT", "BI6256B1_SAIDA1.TXT")]
        public static void BI6256B_Tests_Theory(string MOV012000_CC_FILE_NAME_P, string BI6256B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV012000_CC_FILE_NAME_P = $"{MOV012000_CC_FILE_NAME_P}_{timestamp}.txt";
            BI6256B1_FILE_NAME_P = $"{BI6256B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #region R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

                AppSettings.TestSet.DynamicData.Remove("R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_QTD_PARCELAS" , "60"}
            });
                AppSettings.TestSet.DynamicData.Add("R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q7);

                #endregion
                #endregion
                var program = new BI6256B();
                program.Execute(MOV012000_CC_FILE_NAME_P, BI6256B1_FILE_NAME_P);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete")) && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                Assert.True(File.Exists(program.MOV012000_CC.FilePath));
                Assert.True(new FileInfo(program.MOV012000_CC.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.BI6256B1.FilePath));
                Assert.True(new FileInfo(program.BI6256B1.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("MOVDEBCE_COD_CONVENIO", out var valor) && valor == "000012000");

                envList = AppSettings.TestSet.DynamicData["R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("PARAMCON_NSAS", out valor) && valor == "0001");


                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData(" BI6256B_MOV2.TXT", "BI6256B1_SAIDA2.TXT")]
        public static void BI6256B_Tests_TheoryErro(string MOV012000_CC_FILE_NAME_P, string BI6256B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV012000_CC_FILE_NAME_P = $"{MOV012000_CC_FILE_NAME_P}_{timestamp}.txt";
            BI6256B1_FILE_NAME_P = $"{BI6256B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                #region VARIAVEIS_TESTE
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);
                #endregion
                #endregion
                var program = new BI6256B();
                program.Execute(MOV012000_CC_FILE_NAME_P, BI6256B1_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }

    }
}