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
using static Code.SPBVG001;

namespace FileTests.Test
{
    [Collection("SPBVG001_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SPBVG001_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region P0050_05_INICIO_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0050_05_INICIO_DB_SELECT_1_Query1", q0);

            #endregion

            #region P0110_05_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0110_05_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region P0111_05_INICIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "USUFILSE_COD_CO" , ""},
                { "USUFILSE_SENHA" , ""},
                { "USUFILSE_NIVEL_AUTORIZACAO" , ""},
                { "USUFILSE_TIPO_FUNCAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0111_05_INICIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region P0112_05_INICIO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VG101_STA_CRITICA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0112_05_INICIO_DB_SELECT_1_Query1", q3);

            #endregion

            #region P0120_05_INICIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VG102_DES_ABREV_MSG_CRITICA" , ""},
                { "VG102_COD_TP_MSG_CRITICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0120_05_INICIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region P0121_05_INICIO_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VG099_DES_STA_CRITICA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0121_05_INICIO_DB_SELECT_1_Query1", q5);

            #endregion

            #region P0130_05_INICIO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_IND_TP_PROPOSTA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
                { "VG102_DES_MSG_CRITICA" , ""},
                { "VG102_DES_ABREV_MSG_CRITICA" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG099_DES_STA_CRITICA" , ""},
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
                { "VG102_IND_ALCADA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0130_05_INICIO_DB_SELECT_1_Query1", q6);

            #endregion

            #region P0131_05_INICIO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_IND_TP_PROPOSTA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
                { "VG102_DES_MSG_CRITICA" , ""},
                { "VG102_DES_ABREV_MSG_CRITICA" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG099_DES_STA_CRITICA" , ""},
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0131_05_INICIO_DB_SELECT_1_Query1", q7);

            #endregion

            #region P0132_05_INICIO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_IND_TP_PROPOSTA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
                { "VG102_DES_MSG_CRITICA" , ""},
                { "VG102_DES_ABREV_MSG_CRITICA" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG099_DES_STA_CRITICA" , ""},
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0132_05_INICIO_DB_SELECT_1_Query1", q8);

            #endregion

            #region SPBVG001_SPBVG001_VG001

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_IND_TP_PROPOSTA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
                { "VG102_DES_MSG_CRITICA" , ""},
                { "VG102_DES_ABREV_MSG_CRITICA" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG099_DES_STA_CRITICA" , ""},
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
                { "VG102_IND_ALCADA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SPBVG001_SPBVG001_VG001", q9);

            #endregion

            #region P0351_05_INICIO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "VG101_STA_CRITICA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0351_05_INICIO_DB_SELECT_1_Query1", q10);

            #endregion

            #region P0801_05_INICIO_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "DATA_CREDITO" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
                { "BILHETE_COD_PRODUTO" , ""},
                { "BILHETE_RAMO" , ""},
                { "BILHETE_OPC_COBERTURA" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_DATA_VENDA" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "WH_IDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0801_05_INICIO_DB_SELECT_1_Query1", q11);

            #endregion

            #region P0802_05_INICIO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0802_05_INICIO_DB_SELECT_1_Query1", q12);

            #endregion

            #region P0803_05_INICIO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0803_05_INICIO_DB_SELECT_1_Query1", q13);

            #endregion

            #region P0804_05_INICIO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0804_05_INICIO_DB_SELECT_1_Query1", q14);

            #endregion

            #region P0805_05_INICIO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "WS_ORIG_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0805_05_INICIO_DB_SELECT_1_Query1", q15);

            #endregion

            #region P0820_05_INICIO_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_IND_TP_PROPOSTA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0820_05_INICIO_DB_INSERT_1_Insert1", q16);

            #endregion

            #region P0821_05_INICIO_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
                { "VG103_IND_TP_PROPOSTA" , ""},
                { "VG103_COD_MSG_CRITICA" , ""},
                { "VG103_NUM_CPF_CNPJ" , ""},
                { "VG103_NUM_PROPOSTA" , ""},
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
                { "VG103_DTA_OCORRENCIA" , ""},
                { "VG103_DTA_RCAP" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0821_05_INICIO_DB_INSERT_1_Insert1", q17);

            #endregion

            #region P0822_05_INICIO_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "VG103_DES_COMPLEMENTAR" , ""},
                { "WH_VG103IDES_COMPLEMENTAR" , ""},
                { "VG103_DTH_CADASTRAMENTO" , ""},
                { "VG103_NOM_PROGRAMA" , ""},
                { "VG103_STA_CRITICA" , ""},
                { "VG103_COD_USUARIO" , ""},
                { "VG103_NUM_CERTIFICADO" , ""},
                { "VG103_SEQ_CRITICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0822_05_INICIO_DB_UPDATE_1_Update1", q18);

            #endregion

            #region P0850_05_INICIO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "VG103_SEQ_CRITICA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0850_05_INICIO_DB_SELECT_1_Query1", q19);

            #endregion

            #region P0851_01_INICIO_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "WH_CURRENT_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0851_01_INICIO_DB_SELECT_1_Query1", q20);

            #endregion

            #region P1010_05_INICIO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P1010_05_INICIO_DB_SELECT_1_Query1", q21);

            #endregion

            #region P1010_05_INICIO_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "VG103_VLR_IS" , ""},
                { "VG103_VLR_PREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P1010_05_INICIO_DB_SELECT_2_Query1", q22);

            #endregion

            #endregion
        }


        [Fact]
        public static void SPBVG001_Tests_Fact()
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
                SPVG001W SPVG001W_P = new SPVG001W();
                IntBasis intBasis = new IntBasis();
                StringBasis stringBasis = new StringBasis();
                intBasis.SetValue(02);
                stringBasis.SetValue("01");
                SPVG001W_P.LK_VG001_TIPO_ACAO = intBasis;
                intBasis = new IntBasis();
                intBasis.SetValue(000000000000001);
                SPVG001W_P.LK_VG001_NUM_CERTIFICADO.Value = intBasis;

                SPVG001W_P.LK_VG001_COD_USUARIO = stringBasis;
                SPVG001W_P.LK_VG001_NOM_PROGRAMA = stringBasis;
                stringBasis.SetValue("BI");
                SPVG001W_P.LK_VG001_IND_TP_PROPOSTA = stringBasis;


                AppSettings.TestSet.DynamicData.Remove("P0120_05_INICIO_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "VG102_DES_ABREV_MSG_CRITICA" , ""},
                { "VG102_COD_TP_MSG_CRITICA" , "001"},

                });
                AppSettings.TestSet.DynamicData.Add("P0120_05_INICIO_DB_SELECT_1_Query1", q4);
                #endregion
                var program = new SPBVG001();
                program.Execute(SPVG001W_P);

                var envList = AppSettings.TestSet.DynamicData["P0820_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["P0821_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("VG103_NUM_CERTIFICADO", out string valor) && valor == "000000000000001");
                Assert.True(envList1[1].TryGetValue("VG103_NUM_CERTIFICADO", out valor) && valor == "000000000000001");

            }
        }
    }
}