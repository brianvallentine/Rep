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
using static Code.VG4267B;

namespace FileTests.Test
{
    [Collection("VG4267B_Tests")]
   [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
   [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
   public class VG4267B_Tests
   {
       //é de extrema importancia que este método seja modificado com cautela, 
       //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
       public static void Load_Parameters()
       {
           #region PARAMETERS
           #region R0100_00_SELECT_V1SISTEMA_Query1

           var q0 = new DynamicData();
           q0.AddDynamic(new Dictionary<string, string>{
               { "V1SIST_DTMOVABE" , "2024-02-01"},
               { "V1SIST_MESREFER" , "2"},
               { "V1SIST_ANOREFER" , "2024"},
               { "V1SIST_DATA_LIMITE" , "2024-12-30"},
           });
           AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_Query1", q0);

           #endregion

           #region VG4267B_CFAIXACEP

           var q1 = new DynamicData();
           q1.AddDynamic(new Dictionary<string, string>{
               { "V0FAIC_FAIXA" , "1"},
               { "V0FAIC_CEPINI" , "1001000"},
               { "V0FAIC_CEPFIM" , "1028999"},
               { "V0FAIC_DESC_FAIXA" , "CDD SE/SPM                                                              "},
               { "V0FAIC_CENTRALIZA" , "CTC/MOOCA/SPM   01                                                      "},
           });
           AppSettings.TestSet.DynamicData.Add("VG4267B_CFAIXACEP", q1);

           #endregion

           #region VG4267B_V1AGENCEF

           var q2 = new DynamicData();
           q2.AddDynamic(new Dictionary<string, string>{
               { "V1MCEF_COD_FONTE" , "1"},
               { "V1FONT_NOMEFTE" , "RIO DE JANEIRO                          "},
               { "V1FONT_ENDERFTE" , "AV GRACA ARANHA,182 - 2 ANDAR -         "},
               { "V1FONT_BAIRRO" , "CASTELO             "},
               { "V1FONT_CIDADE" , "RIO DE JANEIRO      "},
               { "V1FONT_CEP" , "20030001"},
               { "V1FONT_UF" , "RJ"},
           });
           AppSettings.TestSet.DynamicData.Add("VG4267B_V1AGENCEF", q2);

           #endregion

           #region VG4267B_CHISTCOB

           var q3 = new DynamicData();
           q3.AddDynamic(new Dictionary<string, string>{
               { "V0HIST_NRCERTIF" , "8464327676"},
               { "V0HIST_NRPARCEL" , "146"},
               { "V0HIST_NRTIT" , "9300115783830"},
               { "V0HIST_DTVENCTO" , "2019-11-11"},
               { "V0HIST_VLPRMTOT" , "449.17"},
               { "V0HIST_CODOPER" , "0"},
               { "V0HIST_OPCAOPAG" , "3"},
               { "V0HIST_NRTITCOMP" , "0"},
               { "V0HIST_CODPRODU" , "9329"},
               { "V0HIST_OCORHIST" , "70"},
               { "V0HIST_CODCLIEN" , "10175892"},
               { "V0HIST_IDE_SEXO" , " "},
               { "V0HIST_OPCAO_COBER" , " "},
               { "V0HIST_NUM_APOLICE" , "109300000959"},
               { "V0HIST_CODSUBES" , "10240"},
               { "V0HIST_OCOREND" , "1"},
               { "V0HIST_AGECOBR" , "1557"},
               { "V0HIST_FONTE" , "16"},
               { "V0HIST_DTQITBCO" , "2007-10-10"},
               { "V0PARC_DTVENCTO" , "2019-11-10"},
               { "PRODUTO_COD_EMPRESA" , "10"},
           });
           AppSettings.TestSet.DynamicData.Add("VG4267B_CHISTCOB", q3);

           #endregion

           #region R1200_00_SELECT_V0CLIENTE_Query1

           var q4 = new DynamicData();
           q4.AddDynamic(new Dictionary<string, string>{
               { "V0CLIE_NOME_RAZAO" , ""},
               { "V0CLIE_CNPJ" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V0CLIENTE_Query1", q4);

           #endregion

           #region R1300_00_SELECT_V0ENDERECO_Query1

           var q5 = new DynamicData();
           q5.AddDynamic(new Dictionary<string, string>{
               { "V0ENDE_ENDERECO" , ""},
               { "V0ENDE_BAIRRO" , ""},
               { "V0ENDE_CIDADE" , ""},
               { "V0ENDE_UF" , ""},
               { "V0ENDE_CEP" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_V0ENDERECO_Query1", q5);

           #endregion

           #region R1500_00_SELECT_V1AGENCEF_Query1

           var q6 = new DynamicData();
           q6.AddDynamic(new Dictionary<string, string>{
               { "V1MCEF_COD_FONTE" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_V1AGENCEF_Query1", q6);

           #endregion

           #region R1510_00_SELECT_V0OPCAOPAGVA_Query1

           var q7 = new DynamicData();
           q7.AddDynamic(new Dictionary<string, string>{
               { "V0OPCP_PERIPGTO" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_V0OPCAOPAGVA_Query1", q7);

           #endregion

           #region R2200_00_PROCESSA_FAC_Query1

           var q8 = new DynamicData();
           q8.AddDynamic(new Dictionary<string, string>{
               { "WHOST_DATA2" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_Query1", q8);

           #endregion

           #region R2200_00_PROCESSA_FAC_Query2

           var q9 = new DynamicData();
           q9.AddDynamic(new Dictionary<string, string>{
               { "V0SUBG_IND_IOF" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2200_00_PROCESSA_FAC_Query2", q9);

           #endregion

           #region R2315_00_SELECT_V0MULTIMENS_Query1

           var q10 = new DynamicData();
           q10.AddDynamic(new Dictionary<string, string>{
               { "V0MENS_JDE" , ""},
               { "V0MENS_JDL" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2315_00_SELECT_V0MULTIMENS_Query1", q10);

           #endregion

           #region R2340_00_SELECT_V0PARCELVA_Query1

           var q11 = new DynamicData();
           q11.AddDynamic(new Dictionary<string, string>{
               { "V0PARC_VLPRMTOT" , ""},
               { "V0PARC_DTVENCTO" , ""},
               { "V0PARC_PRMVG" , ""},
               { "V0PARC_PRMAP" , ""},
               { "V0PARC_VLMULTA" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2340_00_SELECT_V0PARCELVA_Query1", q11);

           #endregion

           #region R2450_00_SELECT_V0COBERPROPVA_Query1

           var q12 = new DynamicData();
           q12.AddDynamic(new Dictionary<string, string>{
               { "V0COBE_IMPMORNATU" , ""},
               { "V0COBE_VLPREMIO" , ""},
               { "V0COBE_DTINIVIG" , ""},
               { "V0COBE_IMPSEGCDG" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2450_00_SELECT_V0COBERPROPVA_Query1", q12);

           #endregion

           #region R2600_00_UPDATE_V0HISTCOBVA_Update1

           var q13 = new DynamicData();
           q13.AddDynamic(new Dictionary<string, string>{
               { "WHOST_NRCERTIF" , ""},
               { "WHOST_NRPARCEL" , ""},
               { "WHOST_NRTIT" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2600_00_UPDATE_V0HISTCOBVA_Update1", q13);

           #endregion

           #region R2651_00_BUSCA_ESTIPULANTE_Query1

           var q14 = new DynamicData();
           q14.AddDynamic(new Dictionary<string, string>{
               { "V0SUBG_COD_CLIENTE" , ""},
               { "V0SUBG_OCOREND" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2651_00_BUSCA_ESTIPULANTE_Query1", q14);

           #endregion

           #region R2651_00_BUSCA_ESTIPULANTE_Query2

           var q15 = new DynamicData();
           q15.AddDynamic(new Dictionary<string, string>{
               { "V0CLIE_NOME_RAZAO_E" , ""},
               { "V0CLIE_CNPJ_E" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2651_00_BUSCA_ESTIPULANTE_Query2", q15);

           #endregion

           #region R2651_00_BUSCA_ESTIPULANTE_Query3

           var q16 = new DynamicData();
           q16.AddDynamic(new Dictionary<string, string>{
               { "V0ENDE_ENDERECO_E" , ""},
               { "V0ENDE_BAIRRO_E" , ""},
               { "V0ENDE_CIDADE_E" , ""},
               { "V0ENDE_UF_E" , ""},
               { "V0ENDE_CEP_E" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2651_00_BUSCA_ESTIPULANTE_Query3", q16);

           #endregion

           #region R2652_00_BUSCA_PARCELA_Query1

           var q17 = new DynamicData();
           q17.AddDynamic(new Dictionary<string, string>{
               { "V0PARC_DTVENCTO_ORIG" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2652_00_BUSCA_PARCELA_Query1", q17);

           #endregion

           #region R2652_00_BUSCA_PARCELA_Query2

           var q18 = new DynamicData();
           q18.AddDynamic(new Dictionary<string, string>{
               { "V0COBP_DTINIVIG_PARC" , ""},
               { "V0COBP_QUANT_VIDAS" , ""},
               { "V0COBP_IMPSEGUR" , ""},
               { "V0COBP_OCORHIST" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2652_00_BUSCA_PARCELA_Query2", q18);

           #endregion

           #region R2652_00_BUSCA_PARCELA_Query3

           var q19 = new DynamicData();
           q19.AddDynamic(new Dictionary<string, string>{
               { "V0COBP_DTINIVIG_PARC" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2652_00_BUSCA_PARCELA_Query3", q19);

           #endregion

           #region R2652_00_BUSCA_PARCELA_Query4

           var q20 = new DynamicData();
           q20.AddDynamic(new Dictionary<string, string>{
               { "SQL_PCIOF" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2652_00_BUSCA_PARCELA_Query4", q20);

           #endregion

           #region R2655_00_CALCULA_INIVIGENCIA_Query1

           var q21 = new DynamicData();
           q21.AddDynamic(new Dictionary<string, string>{
               { "V0COBP_DTINIVIG_PARC" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2655_00_CALCULA_INIVIGENCIA_Query1", q21);

           #endregion

           #region R2657_00_CALCULA_TERVIGENCIA_Query1

           var q22 = new DynamicData();
           q22.AddDynamic(new Dictionary<string, string>{
               { "WS_DTTERVIG_PARC" , ""},
               { "WS_QTD_DIAS_PARC" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2657_00_CALCULA_TERVIGENCIA_Query1", q22);

           #endregion

           #region R2700_00_SELECT_V0PRODUTOSVG_Query1

           var q23 = new DynamicData();
           q23.AddDynamic(new Dictionary<string, string>{
               { "V0PROD_NOMPRODU" , ""},
               { "V0PROD_CODCDT" , ""},
               { "V0PROD_CODPRODU" , ""},
               { "V0PROD_TEM_CDG" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2700_00_SELECT_V0PRODUTOSVG_Query1", q23);

           #endregion

           #region R2710_00_SELECT_V0PRODUTOSVG_Query1

           var q24 = new DynamicData();
           q24.AddDynamic(new Dictionary<string, string>{
               { "V0PROD_NUM_APOLICE" , "93010000890"},
               { "V0PROD_CODSUBES" , ""},
               { "V0PROD_ESTR_COBR" , "MULT"},
               { "V0PROD_ORIG_PRODU" , "AVERB"},
           });
           AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_V0PRODUTOSVG_Query1", q24);

           #endregion

           #region R2711_00_SELECT_V0PRODUTOSVG_Query1

           var q25 = new DynamicData();
           q25.AddDynamic(new Dictionary<string, string>{
               { "V0PROD_CODCDT" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2711_00_SELECT_V0PRODUTOSVG_Query1", q25);

           #endregion

           #region R2800_00_SELECT_V0CEDENTE_Query1

           var q26 = new DynamicData();
           q26.AddDynamic(new Dictionary<string, string>{
               { "V0CEDE_NOMECED" , ""},
               { "V0CEDE_AGENCIA" , ""},
               { "V0CEDE_OPERACAO" , ""},
               { "V0CEDE_CONTA" , ""},
               { "V0CEDE_DIGCC" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_V0CEDENTE_Query1", q26);

           #endregion

           #region R2910_00_OBTEM_NUMERACAO_Query1

           var q27 = new DynamicData();
           q27.AddDynamic(new Dictionary<string, string>{
               { "V0RELA_NRCOPIAS" , ""}
           });
           AppSettings.TestSet.DynamicData.Add("R2910_00_OBTEM_NUMERACAO_Query1", q27);

           #endregion

           #region R2910_10_INCLUI_RELATORIO_Insert1

           var q28 = new DynamicData();
           q28.AddDynamic(new Dictionary<string, string>{
               { "V1SIST_DTMOVABE" , ""},
               { "V0RELA_NRCOPIAS" , ""},
               { "V1SIST_MESREFER" , ""},
               { "V1SIST_ANOREFER" , ""},
               { "WHOST_NRAPOLICE" , ""},
               { "WHOST_CODSUBES" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R2910_10_INCLUI_RELATORIO_Insert1", q28);

           #endregion

           #region R9100_00_INSERT_GEOBJECT_Insert1

           var q29 = new DynamicData();
           q29.AddDynamic(new Dictionary<string, string>{
               { "GEOBJECT_NUM_CEP" , ""},
               { "GEOBJECT_NOM_PROGRAMA" , ""},
               { "GEOBJECT_COD_FORMULARIO" , ""},
               { "GEOBJECT_STA_REGISTRO" , ""},
               { "GEOBJECT_COD_PRODUTO" , ""},
               { "GEOBJECT_NUM_INI_POS_VERSO" , ""},
               { "GEOBJECT_QTD_PESO_GRAMAS" , ""},
               { "GEOBJECT_VLR_DECLARADO" , ""},
               { "GEOBJECT_COD_IDENT_OBJETO" , ""},
               { "GEOBJECT_DES_OBJETO" , ""},
           });
           AppSettings.TestSet.DynamicData.Add("R9100_00_INSERT_GEOBJECT_Insert1", q29);

           #endregion

           #endregion
       }

       [Theory]
       [InlineData("VG4267B_1_t1", "VG4267B_2_t1", "VG4267B_3_t1")]
       public static void VG4267B_Tests_Theory_Processing_ReturnCode_0(string RVG4267B_FILE_NAME_P, string SVG4267B_FILE_NAME_P, string FVG4267B_FILE_NAME_P)
       {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG4267B_FILE_NAME_P = $"{RVG4267B_FILE_NAME_P}_{timestamp}.txt";
            SVG4267B_FILE_NAME_P = $"{SVG4267B_FILE_NAME_P}_{timestamp}.txt";
            FVG4267B_FILE_NAME_P = $"{FVG4267B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               AppSettings.TestSet.Clear();
               Load_Parameters();

               //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
               //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
               //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

               #region VARIAVEIS_TESTE

               #region R2710_00_SELECT_V0PRODUTOSVG_Query1

               var q24 = new DynamicData();
               q24.AddDynamic(new Dictionary<string, string>{
               { "V0PROD_NUM_APOLICE" , "109300000635"},
               { "V0PROD_CODSUBES" , "1"},
               { "V0PROD_ESTR_COBR" , "MULT"},
               { "V0PROD_ORIG_PRODU" , "AVERB"},
               });
               AppSettings.TestSet.DynamicData.Remove("R2710_00_SELECT_V0PRODUTOSVG_Query1");
               AppSettings.TestSet.DynamicData.Add("R2710_00_SELECT_V0PRODUTOSVG_Query1", q24);

               #endregion
               #region R2800_00_SELECT_V0CEDENTE_Query1

               var q26 = new DynamicData();
               q26.AddDynamic(new Dictionary<string, string>{
               { "V0CEDE_NOMECED" , "SASSE CIA NACIONAL DE SEGUROS GERAIS    "},
               { "V0CEDE_AGENCIA" , "0001"},
               { "V0CEDE_OPERACAO" , "3"},
               { "V0CEDE_CONTA" , "1454125"},
               { "V0CEDE_DIGCC" , "1"},
               });
               q26.AddDynamic(new Dictionary<string, string>{
               { "V0CEDE_NOMECED" , "SASSE CIA NACIONAL DE SEGUROS GERAIS    "},
               { "V0CEDE_AGENCIA" , "0001"},
               { "V0CEDE_OPERACAO" , "3"},
               { "V0CEDE_CONTA" , "178953"},
               { "V0CEDE_DIGCC" , "3"},
               });
               AppSettings.TestSet.DynamicData.Remove("R2800_00_SELECT_V0CEDENTE_Query1");
               AppSettings.TestSet.DynamicData.Add("R2800_00_SELECT_V0CEDENTE_Query1", q26);

               #endregion


               #endregion
               var program = new VG4267B();
               program.Execute(RVG4267B_FILE_NAME_P, SVG4267B_FILE_NAME_P, FVG4267B_FILE_NAME_P);

               Assert.True(program.RETURN_CODE == 0);
               //R2600_00_UPDATE_V0HISTCOBVA_Update1
               var envList0 = AppSettings.TestSet.DynamicData["R2600_00_UPDATE_V0HISTCOBVA_Update1"].DynamicList;
               Assert.True(envList0[1].TryGetValue("WHOST_NRTIT", out var val0r) && val0r.Contains("9300115783830"));

               //R2910_10_INCLUI_RELATORIO_Insert1
               var envList1 = AppSettings.TestSet.DynamicData["R2910_10_INCLUI_RELATORIO_Insert1"].DynamicList;
               Assert.True(envList1[1].TryGetValue("WHOST_NRAPOLICE", out var val1r) && val1r.Contains("0109300000959"));
               Assert.True(envList1.Count > 1);

               //R9100_00_INSERT_GEOBJECT_Insert1
               var envList2 = AppSettings.TestSet.DynamicData["R9100_00_INSERT_GEOBJECT_Insert1"].DynamicList;
               Assert.True(envList2[3].TryGetValue("GEOBJECT_STA_REGISTRO", out var val2r) && val2r.Contains("D"));
               Assert.True(envList2[3].TryGetValue("GEOBJECT_COD_PRODUTO", out var val3r) && val3r.Contains("9329"));
               Assert.True(envList2[3].TryGetValue("GEOBJECT_QTD_PESO_GRAMAS", out var val4r) && val4r.Contains("04.600"));
               Assert.True(envList2.Count > 1);

           }
       }
       [Theory]
        [InlineData("VG4267B_1_t2", "VG4267B_2_t2", "VG4267B_3_t2")]
        public static void VG4267B_Tests_Theory_SemMovimento_ReturnCode_0(string RVG4267B_FILE_NAME_P, string SVG4267B_FILE_NAME_P, string FVG4267B_FILE_NAME_P)
       {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG4267B_FILE_NAME_P = $"{RVG4267B_FILE_NAME_P}_{timestamp}.txt";
            SVG4267B_FILE_NAME_P = $"{SVG4267B_FILE_NAME_P}_{timestamp}.txt";
            FVG4267B_FILE_NAME_P = $"{FVG4267B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               AppSettings.TestSet.Clear();
               Load_Parameters();

               //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
               //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
               //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

               #region VARIAVEIS_TESTE


               #region VG4267B_CHISTCOB

               var q3 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("VG4267B_CHISTCOB");
               AppSettings.TestSet.DynamicData.Add("VG4267B_CHISTCOB", q3);

               #endregion


               #endregion
               var program = new VG4267B();
               program.Execute(RVG4267B_FILE_NAME_P, SVG4267B_FILE_NAME_P, FVG4267B_FILE_NAME_P);

               Assert.True(program.RETURN_CODE == 0);
               Assert.True(program.CHISTCOB.AllData.Count == 0);


           }
       }
       [Theory]
        [InlineData("VG4267B_1_t3", "VG4267B_2_t3", "VG4267B_3_t3")]
        public static void VG4267B_Tests_Theory_Error_ReturnCode_99(string RVG4267B_FILE_NAME_P, string SVG4267B_FILE_NAME_P, string FVG4267B_FILE_NAME_P)
       {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            RVG4267B_FILE_NAME_P = $"{RVG4267B_FILE_NAME_P}_{timestamp}.txt";
            SVG4267B_FILE_NAME_P = $"{SVG4267B_FILE_NAME_P}_{timestamp}.txt";
            FVG4267B_FILE_NAME_P = $"{FVG4267B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
           {
               AppSettings.TestSet.IsTest = true;
               AppSettings.TestSet.Clear();
               Load_Parameters();

               //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
               //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
               //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

               #region VARIAVEIS_TESTE

               #region R0100_00_SELECT_V1SISTEMA_Query1

               var q0 = new DynamicData();
               AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_V1SISTEMA_Query1");
               AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_Query1", q0);

               #endregion


               #endregion
               var program = new VG4267B();
               program.Execute(RVG4267B_FILE_NAME_P, SVG4267B_FILE_NAME_P, FVG4267B_FILE_NAME_P);

               Assert.True(program.RETURN_CODE == 99);

           }
       }
   }
}