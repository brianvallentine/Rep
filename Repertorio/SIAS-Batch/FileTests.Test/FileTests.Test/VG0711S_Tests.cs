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
using static Code.VG0711S;

namespace FileTests.Test
{
    [Collection("VG0711S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0711S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "WS_SISTEMA_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1", q1);

            #endregion

            #region M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TAXA_VG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1", q2);

            #endregion

            #region M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_CARREGA_CONJUGE" , ""},
                { "CONDITEC_CARREGA_FILHOS" , ""},
                { "TAXA_AP_MORACID" , ""},
                { "TAXA_AP_INVPERM" , ""},
                { "TAXA_AP_AMDS" , ""},
                { "TAXA_AP_DH" , ""},
                { "TAXA_AP_DIT" , ""},
                { "GARAN_ADIC_IEA" , ""},
                { "GARAN_ADIC_IPA" , ""},
                { "GARAN_ADIC_IPD" , ""},
                { "GARAN_ADIC_HD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0040_ACESSA_COND_TECNICAS_DB_SELECT_1_Query1", q3);

            #endregion

            #region VG0711S_COBER

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , ""},
                { "VGCOBSUB_IMP_SEGURADA_IX" , ""},
                { "VGCOBSUB_DATA_INIVIGENCIA" , ""},
                { "VG033_DES_ACESSORIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0711S_COBER", q4);

            #endregion

            #region VG0711S_COBER491

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "VG087_NOM_GRUPO_COBERTURA" , ""},
                { "VG087_IND_CONJUGE" , ""},
                { "VGARANTI_NUM_GARANTIA" , ""},
                { "VGARANTI_DES_GARANTIA" , ""},
                { "VG085_NUM_FAIXA_INICIAL" , ""},
                { "VG085_NUM_FAIXA_FINAL" , ""},
                { "VG086_VLR_FAIXA_CS_INICIAL" , ""},
                { "VG086_VLR_FAIXA_CS_FINAL" , ""},
                { "VG088_PCT_COB_PREMIO" , ""},
                { "VG088_DTA_INI_VIGENCIA_GRUPO" , ""},
                { "VG088_DTA_FIM_VIGENCIA_GRUPO" , ""},
                { "VG091_DES_COB_CARENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0711S_COBER491", q5);

            #endregion

            #region M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_IDADE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_1_Query1", q6);

            #endregion

            #region VG0711S_CAREN491

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_NUM_GARANTIA" , ""},
                { "VG091_DES_COB_CARENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0711S_CAREN491", q7);

            #endregion

            #region M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WS_MAX_VLR_CONSULTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1", q8);

            #endregion

            #region M_0700_SELECT_APOLICE_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_MODALIDA" , ""},
                { "WS_RAMO" , ""},
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0700_SELECT_APOLICE_DB_SELECT_1_Query1", q9);

            #endregion

            #region M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WS_COD_SUBGRUPO" , ""},
                { "WS_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1_Update1", q10);

            #endregion

            #region M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "V0SUBG_IND_IOF" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "SEGVGAP_PERI_PAGAMENTO" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0800_SELECT_SEGURVGA_DB_SELECT_1_Query1", q11);

            #endregion

            #region M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAPH_DATA_MOVIMENTO" , ""},
                { "SEGVGAPH_COD_MOEDA_PRM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0900_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1", q12);

            #endregion

            #region M_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_COMPRA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1000_SELECT_MOEDA_COTACAO_DB_SELECT_1_Query1", q13);

            #endregion

            #region M_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "MOEDACOT_VAL_COMPRA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_1100_CALCULAR_IOF_PREMIO_DB_SELECT_1_Query1", q14);

            #endregion

            #region M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_QTMDIT" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1", q15);

            #endregion

            #region M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_FATOR_MULTIPLICA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1", q16);

            #endregion

            #region VG0711S_CHINT491

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "VGARANTI_NUM_GARANTIA" , ""},
                { "VG087_SEQ_GRUPO_COBERTURA" , ""},
                { "VGARANTI_TP_GARANTIA" , ""},
                { "VG091_DES_MSG_HINT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0711S_CHINT491", q17);

            #endregion

            #region M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "PESSOFIS_COD_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3100_00_SEL_PESSOA_FISICA_DB_SELECT_1_Query1", q18);

            #endregion

            #region M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "PF062_COD_CBO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_3200_00_SEL_PF_CBO_DB_SELECT_1_Query1", q19);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0711S_Tests_Fact()
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
                var program = new VG0711S();
                var LK_NUM_APOLICES = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 2);
                var LK_SUBGRUPOS = new IntBasis(new PIC("S9", "4", "S9(004)"));
                var LK_CERTIFICADOS = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
                var LK_IDADES = new IntBasis(new PIC("S9", "4", "S9(004)"));
                var LK_DT_QUITACAOS = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                var LK_SALARIOS = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);

                LK_NUM_APOLICES.Value = 2;
                LK_SUBGRUPOS.Value = 2;
                LK_CERTIFICADOS.Value = 2;
                LK_IDADES.Value = 5;
                LK_DT_QUITACAOS.Value = "";
                LK_SALARIOS.Value = 2000;

                var param = new VG0711S_PARAMETROS() { LK_NUM_APOLICE = LK_NUM_APOLICES, LK_SUBGRUPO = LK_SUBGRUPOS, LK_CERTIFICADO = LK_CERTIFICADOS,
                    LK_IDADE = LK_IDADES, LK_DT_QUITACAO  = LK_DT_QUITACAOS, LK_SALARIO = LK_SALARIOS};
                program.Execute(param);

                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["M_0722_UPDATE_PAGA_IOF_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("WS_COD_SUBGRUPO", out var valor) && valor == "0002");

                Assert.True(program.PARAMETROS.LK_RETURN_CODE == 0);
            }
        }
        [Fact]
        public static void VG0711S_Tests_SemDados()
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
                AppSettings.TestSet.DynamicData.Remove("Execute_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);
                #endregion
                var program = new VG0711S();
               
                var param = new VG0711S_PARAMETROS()
                {
                };
                program.Execute(param);


                Assert.True(program.PARAMETROS.LK_RETURN_CODE == 100);
            }
        }
    }
}