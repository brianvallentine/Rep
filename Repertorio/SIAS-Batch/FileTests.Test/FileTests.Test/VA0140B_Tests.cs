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
using static Code.VA0140B;
using Newtonsoft.Json;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0140B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0140B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA10" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0140B_V0HISCONPA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_COD_FONTE" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "HISCONPA_DATA_MOVIMENTO" , ""},
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "PROPOVA_DTPROXVEN" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "PRODUVG_COD_PRODUTO" , ""},
                { "PRODUVG_ESTR_COBR" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
                { "APOLICES_COD_MODALIDADE" , ""},
                { "APOLICES_ORGAO_EMISSOR" , ""},
                { "APOLICES_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "WHOST_DATAMES1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0140B_V0HISCONPA", q1);

            #endregion

            #region R0230_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_IND_IOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_IND_IOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PARCEVID_DATA_VENCIMENTO" , ""},
                { "WHOST_DATA_GEROU_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0260_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_DATA_INIVIGENCIA" , ""},
                { "OPCPAGVI_DATA_TERVIGENCIA" , ""},
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_BCO_AVISO" , ""},
                { "COBHISVI_AGE_AVISO" , ""},
                { "COBHISVI_NUM_AVISO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SELECT_COBHISVI_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0310_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "CONDITEC_GARAN_ADIC_IEA" , ""},
                { "CONDITEC_GARAN_ADIC_IPA" , ""},
                { "CONDITEC_GARAN_ADIC_IPD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0340_00_SELECT_SEGVGAP_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGVGAP_NUM_ITEM" , ""},
                { "SEGVGAP_DATA_INIVIGENCIA" , ""},
                { "SEGVGAP_DATA_ADMISSAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0340_00_SELECT_SEGVGAP_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0350_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINI01" , ""},
                { "WHOST_PERI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTINI01" , ""},
                { "WHOST_DTTER01" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0370_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_RCAPS_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "MOVIMCOB_SIT_REGISTRO" , ""},
                { "MOVIMCOB_VAL_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1", q16);

            #endregion

            #region R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "MOVDEBCE_SITUACAO_COBRANCA" , ""},
                { "MOVDEBCE_VALOR_DEBITO" , ""},
                { "MOVDEBCE_COD_CONVENIO" , ""},
                { "MOVDEBCE_VLR_CREDITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_SALDO_ATUAL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_AVISOSAL_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATAMES2" , ""},
                { "WHOST_DATAMES1" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0530_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0610_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0610_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q20);

            #endregion

            #region R0620_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_ENDOSSO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q21);

            #endregion

            #region R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q22);

            #endregion

            #region R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_RAMO_EMISSOR" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "ENDOSSOS_COD_SUBGRUPO" , ""},
                { "ENDOSSOS_COD_FONTE" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "WHOST_DATA_INIVIGENCIA" , ""},
                { "WHOST_DATA_TERVIGENCIA" , ""},
                { "HISCONPA_DTFATUR" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0640_00_SELECT_HISCONPA_DB_SELECT_1_Query1", q23);

            #endregion

            #region R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""},
                { "CALENDAR_DTH_ULT_DIA_MES" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0650_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q24);

            #endregion

            #region R0680_00_SELECT_CALENDAR_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DATA_CALENDARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0680_00_SELECT_CALENDAR_DB_SELECT_1_Query1", q25);

            #endregion

            #region R0760_00_SELECT_VG082_DB_SELECT_1_Query1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""},
                { "VG082_VLR_PREMIO_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0760_00_SELECT_VG082_DB_SELECT_1_Query1", q26);

            #endregion

            #region R0765_00_SELECT_VG082_DB_SELECT_1_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""},
                { "VG082_VLR_PREMIO_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0765_00_SELECT_VG082_DB_SELECT_1_Query1", q27);

            #endregion

            #region R0770_00_SELECT_APOLICOB_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0770_00_SELECT_APOLICOB_DB_SELECT_1_Query1", q28);

            #endregion

            #region R1320_00_SELECT_RCAPS_DB_SELECT_1_Query1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1320_00_SELECT_RCAPS_DB_SELECT_1_Query1", q29);

            #endregion

            #region R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1330_00_UPDATE_RCAP_DB_UPDATE_1_Update1", q30);

            #endregion

            #region R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_NUM_RCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1340_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1", q31);

            #endregion

            #region R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_SIT_REGISTRO" , ""},
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_VAL_RCAP" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , ""},
                { "RCAPCOMP_SIT_CONTABIL" , ""},
                { "RCAPCOMP_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1", q33);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SVA0140B.txt", "SAIDA01.txt", "SAIDA02.txt")]
        public static void VA0140B_Tests_Theory(string SVA0140B_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0140B_FILE_NAME_P = $"{SVA0140B_FILE_NAME_P}_{timestamp}.txt";
            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA02_FILE_NAME_P = $"{SAIDA02_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();


                var program = new VA0140B();

                var fileName1 = Path.GetFileNameWithoutExtension(SAIDA01_FILE_NAME_P);
                SAIDA01_FILE_NAME_P = SAIDA02_FILE_NAME_P.Replace(fileName1, fileName1 + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));

                Console.WriteLine($"#### Arquivo {JsonConvert.SerializeObject(AppSettings.Settings, Formatting.Indented)}");
                Console.WriteLine($"#### Arquivo {SAIDA01_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                Load_Parameters();

                #region VARIAVEIS_TESTE
                #endregion
                program.Execute(SVA0140B_FILE_NAME_P, SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P);

                Assert.True(File.Exists(program.SAIDA01.FilePath));
                Assert.True(new FileInfo(program.SAIDA01.FilePath)?.Length > 0);


                AppSettings.TestSet.DynamicData
                    .Where(x => (x.Key.Contains("Update")
                    || x.Key.Contains("Insert")
                    || x.Key.Contains("Delete"))
                    && x.Value.DynamicList.Count > 1
                    || x.Value.DynamicList.Count == 0);

                var envList = AppSettings.TestSet.DynamicData["R4000_00_UPDATE_HISCONPA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList.Count > 1);
                Assert.True(envList[1].TryGetValue("HISCONPA_SIT_REGISTRO", out var valor) && valor == "1");

            }
        }

        [Theory]
        [InlineData("SVA0140B.txt", "SAIDA01.txt", "SAIDA02.txt")]
        public static void VA0140B_Tests_SemDados(string SVA0140B_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SVA0140B_FILE_NAME_P = $"{SVA0140B_FILE_NAME_P}_{timestamp}.txt";
            SAIDA01_FILE_NAME_P = $"{SAIDA01_FILE_NAME_P}_{timestamp}.txt";
            SAIDA02_FILE_NAME_P = $"{SAIDA02_FILE_NAME_P}_{timestamp}.txt";
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
                var program = new VA0140B();

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                program.Execute(SVA0140B_FILE_NAME_P, SAIDA01_FILE_NAME_P, SAIDA02_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}