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
using static Code.SPBVG017;
using Sias.Outros.DB2.SPBVG017;

namespace FileTests.Test
{
    [Collection("SPBVG017_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SPBVG017_Tests
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

            #region P0112_05_INICIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "WH_STA_DPS_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0112_05_INICIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region P0114_05_INICIO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "VG142_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0114_05_INICIO_DB_SELECT_1_Query1", q2);

            #endregion

            #region P0115_05_INICIO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "VG143_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0115_05_INICIO_DB_SELECT_1_Query1", q3);

            #endregion

            #region P0130_05_INICIO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VG143_NUM_PROPOSTA" , ""},
                { "VG143_NUM_CPF_CNPJ" , ""},
                { "VG143_SEQ_PRODUTO_DPS" , ""},
                { "VG143_STA_DPS_PROPOSTA" , ""},
                { "VG143_IND_TP_PESSOA" , ""},
                { "VG143_IND_TP_SEGURADO" , ""},
                { "VG143_NUM_CERTIFICADO" , ""},
                { "VG143_VLR_IS" , ""},
                { "VG143_VLR_ACUMULO_IS" , ""},
                { "VG143_COD_USUARIO" , ""},
                { "VG143_NOM_PROGRAMA" , ""},
                { "VG143_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0130_05_INICIO_DB_SELECT_1_Query1", q4);

            #endregion

            #region SPBVG017_SPBVG017_EC001

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "A_NUM_PROPOSTA" , ""},
                { "A_NUM_CPF_CNPJ" , ""},
                { "A_DTH_CADASTRAMENTO" , ""},
                { "C_COD_PRODUTO" , ""},
                { "A_STA_DPS_PROPOSTA" , ""},
                { "B_DES_DPS_PROPOSTA" , ""},
                { "A_IND_TP_PESSOA" , ""},
                { "A_IND_TP_SEGURADO" , ""},
                { "A_NUM_CERTIFICADO" , ""},
                { "A_VLR_IS" , ""},
                { "A_VLR_ACUMULO_IS" , ""},
                { "A_COD_USUARIO" , ""},
                { "A_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SPBVG017_SPBVG017_EC001", q5);

            #endregion

            #region SPBVG017_SPBVG017_EC002

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "A_NUM_PROPOSTA" , ""},
                { "A_NUM_CPF_CNPJ" , ""},
                { "A_DTH_CADASTRAMENTO" , ""},
                { "C_COD_PRODUTO" , ""},
                { "A_STA_DPS_PROPOSTA" , ""},
                { "B_DES_DPS_PROPOSTA" , ""},
                { "A_IND_TP_PESSOA" , ""},
                { "A_IND_TP_SEGURADO" , ""},
                { "A_NUM_CERTIFICADO" , ""},
                { "A_VLR_IS" , ""},
                { "A_VLR_ACUMULO_IS" , ""},
                { "A_COD_USUARIO" , ""},
                { "A_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SPBVG017_SPBVG017_EC002", q6);

            #endregion

            #region P0820_05_INICIO_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "VG143_NUM_PROPOSTA" , ""},
                { "VG143_NUM_CPF_CNPJ" , ""},
                { "VG143_SEQ_PRODUTO_DPS" , ""},
                { "VG143_STA_DPS_PROPOSTA" , ""},
                { "VG143_IND_TP_PESSOA" , ""},
                { "VG143_IND_TP_SEGURADO" , ""},
                { "VG143_NUM_CERTIFICADO" , ""},
                { "VG143_VLR_IS" , ""},
                { "VG143_VLR_ACUMULO_IS" , ""},
                { "VG143_COD_USUARIO" , ""},
                { "VG143_NOM_PROGRAMA" , ""},
                { "VG143_DTH_CADASTRAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0820_05_INICIO_DB_INSERT_1_Insert1", q7);

            #endregion

            #region P0821_05_INICIO_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VG143_NUM_PROPOSTA" , ""},
                { "VG143_NUM_CPF_CNPJ" , ""},
                { "VG143_DTH_CADASTRAMENTO" , ""},
                { "VG143_SEQ_PRODUTO_DPS" , ""},
                { "VG143_STA_DPS_PROPOSTA" , ""},
                { "VG143_IND_TP_PESSOA" , ""},
                { "VG143_IND_TP_SEGURADO" , ""},
                { "VG143_NUM_CERTIFICADO" , ""},
                { "VG143_VLR_IS" , ""},
                { "VG143_VLR_ACUMULO_IS" , ""},
                { "VG143_COD_USUARIO" , ""},
                { "VG143_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0821_05_INICIO_DB_INSERT_1_Insert1", q8);

            #endregion

            #region P0822_05_INICIO_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "VG143_DTH_CADASTRAMENTO" , ""},
                { "VG143_STA_DPS_PROPOSTA" , ""},
                { "VG143_SEQ_PRODUTO_DPS" , ""},
                { "VG143_IND_TP_SEGURADO" , ""},
                { "VG143_NUM_CERTIFICADO" , ""},
                { "VG143_VLR_ACUMULO_IS" , ""},
                { "VG143_IND_TP_PESSOA" , ""},
                { "VG143_NOM_PROGRAMA" , ""},
                { "VG143_COD_USUARIO" , ""},
                { "VG143_VLR_IS" , ""},
                { "VG143_NUM_PROPOSTA" , ""},
                { "VG143_NUM_CPF_CNPJ" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("P0822_05_INICIO_DB_UPDATE_1_Update1", q9);

            #endregion

            #region P0851_01_INICIO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WH_CURRENT_TIMESTAMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("P0851_01_INICIO_DB_SELECT_1_Query1", q10);

            #endregion

            #endregion
        }

        [Fact]
        public static void SPBVG017_Tests_Fact()
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
                SPVG017W sPVG017W = new SPVG017W();
                StringBasis LK_VG017_E_IDE_SISTEMA  = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                StringBasis LK_VG017_E_COD_USUARIO = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                StringBasis LK_VG017_E_NOM_PROGRAMA = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                IntBasis LK_VG017_E_TIPO_ACAO = new IntBasis(new PIC("S9", "4", "S9(004)"));
                IntBasis LK_VG017_E_NUM_CPF_CNPJ = new IntBasis(new PIC("S9", "18", "S9(018)"));
                IntBasis LK_VG017_E_NUM_PROPOSTA = new IntBasis(new PIC("S9", "18", "S9(018)"));
                StringBasis LK_VG017_E_IND_TP_PESSOA = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                StringBasis LK_VG017_E_IND_TP_SEGURADO = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                IntBasis LK_VG017_E_STA_PROPOSTA_SIAS = new IntBasis(new PIC("S9", "4", "S9(004)"));

                LK_VG017_E_IDE_SISTEMA.SetValue("IDE_SISTEMA");
                LK_VG017_E_COD_USUARIO.SetValue("USUARIO");
                LK_VG017_E_NOM_PROGRAMA.SetValue("NOME_PROGRAMA");
                LK_VG017_E_TIPO_ACAO.SetValue(2);
                LK_VG017_E_NUM_CPF_CNPJ.SetValue(0123456789);
                LK_VG017_E_NUM_PROPOSTA.SetValue(123123);
                LK_VG017_E_IND_TP_PESSOA.SetValue("J");
                LK_VG017_E_IND_TP_SEGURADO.SetValue("S");
                LK_VG017_E_STA_PROPOSTA_SIAS.SetValue(1);

                sPVG017W.LK_VG017_E_IDE_SISTEMA = LK_VG017_E_IDE_SISTEMA;
                sPVG017W.LK_VG017_E_COD_USUARIO = LK_VG017_E_COD_USUARIO;
                sPVG017W.LK_VG017_E_NOM_PROGRAMA = LK_VG017_E_NOM_PROGRAMA;
                sPVG017W.LK_VG017_E_TIPO_ACAO = LK_VG017_E_TIPO_ACAO;
                sPVG017W.LK_VG017_E_NUM_CPF_CNPJ = LK_VG017_E_NUM_CPF_CNPJ;
                sPVG017W.LK_VG017_E_NUM_PROPOSTA = LK_VG017_E_NUM_PROPOSTA;
                sPVG017W.LK_VG017_E_IND_TP_PESSOA = LK_VG017_E_IND_TP_PESSOA;
                sPVG017W.LK_VG017_E_IND_TP_SEGURADO = LK_VG017_E_IND_TP_SEGURADO;
                sPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS = LK_VG017_E_STA_PROPOSTA_SIAS;

                #endregion
                var program = new SPBVG017();
                program.Execute(sPVG017W);

                var envList = AppSettings.TestSet.DynamicData["P0822_05_INICIO_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);

                Assert.True(envList[1].TryGetValue("VG143_STA_DPS_PROPOSTA", out string valor) && valor == "0001");
            }
        }

        [Fact]
        public static void SPBVG017_Tests_Fact_P0820_05_INICIO_INSERT()
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
                SPVG017W sPVG017W = new SPVG017W();
                StringBasis LK_VG017_E_IDE_SISTEMA = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                StringBasis LK_VG017_E_COD_USUARIO = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                StringBasis LK_VG017_E_NOM_PROGRAMA = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                IntBasis LK_VG017_E_TIPO_ACAO = new IntBasis(new PIC("S9", "4", "S9(004)"));
                IntBasis LK_VG017_E_NUM_CPF_CNPJ = new IntBasis(new PIC("S9", "18", "S9(018)"));
                IntBasis LK_VG017_E_NUM_PROPOSTA = new IntBasis(new PIC("S9", "18", "S9(018)"));
                StringBasis LK_VG017_E_IND_TP_PESSOA = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                StringBasis LK_VG017_E_IND_TP_SEGURADO = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                IntBasis LK_VG017_E_STA_PROPOSTA_SIAS = new IntBasis(new PIC("S9", "4", "S9(004)"));

                LK_VG017_E_IDE_SISTEMA.SetValue("IDE_SISTEMA");
                LK_VG017_E_COD_USUARIO.SetValue("USUARIO");
                LK_VG017_E_NOM_PROGRAMA.SetValue("NOME_PROGRAMA");
                LK_VG017_E_TIPO_ACAO.SetValue(2);
                LK_VG017_E_NUM_CPF_CNPJ.SetValue(0123456789);
                LK_VG017_E_NUM_PROPOSTA.SetValue(123123);
                LK_VG017_E_IND_TP_PESSOA.SetValue("J");
                LK_VG017_E_IND_TP_SEGURADO.SetValue("S");
                LK_VG017_E_STA_PROPOSTA_SIAS.SetValue(1);

                sPVG017W.LK_VG017_E_IDE_SISTEMA = LK_VG017_E_IDE_SISTEMA;
                sPVG017W.LK_VG017_E_COD_USUARIO = LK_VG017_E_COD_USUARIO;
                sPVG017W.LK_VG017_E_NOM_PROGRAMA = LK_VG017_E_NOM_PROGRAMA;
                sPVG017W.LK_VG017_E_TIPO_ACAO = LK_VG017_E_TIPO_ACAO;
                sPVG017W.LK_VG017_E_NUM_CPF_CNPJ = LK_VG017_E_NUM_CPF_CNPJ;
                sPVG017W.LK_VG017_E_NUM_PROPOSTA = LK_VG017_E_NUM_PROPOSTA;
                sPVG017W.LK_VG017_E_IND_TP_PESSOA = LK_VG017_E_IND_TP_PESSOA;
                sPVG017W.LK_VG017_E_IND_TP_SEGURADO = LK_VG017_E_IND_TP_SEGURADO;
                sPVG017W.LK_VG017_E_STA_PROPOSTA_SIAS = LK_VG017_E_STA_PROPOSTA_SIAS;

                AppSettings.TestSet.DynamicData.Remove("P0130_05_INICIO_DB_SELECT_1_Query1");
                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("P0130_05_INICIO_DB_SELECT_1_Query1", q4);

                #endregion
                var program = new SPBVG017();
                program.Execute(sPVG017W);

                var envList = AppSettings.TestSet.DynamicData["P0820_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["P0821_05_INICIO_DB_INSERT_1_Insert1"].DynamicList;
                
                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("VG143_NUM_PROPOSTA", out string valor) && valor == "000000000000123123");
                Assert.True(envList1[1].TryGetValue("VG143_NUM_CPF_CNPJ", out valor) && valor == "000000000123456789");
            }
        }
        
    }
}