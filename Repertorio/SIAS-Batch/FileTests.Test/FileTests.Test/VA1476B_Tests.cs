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
using static Code.VA1476B;

namespace FileTests.Test
{

    [Collection("VA1476B_Tests")]

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA1476B_Tests
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
                { "SISTEMAS_DATA_MOV_ABERTO_30" , ""},
                { "SISTEMAS_DTCURREN" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q2);

            #endregion

            #region VA1476B_MOVDIARIO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_CERTIFICADO" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
                { "MOVIMVGA_OCORR_ENDERECO" , ""},
                { "MOVIMVGA_NUM_APOLICE" , ""},
                { "MOVIMVGA_COD_SUBGRUPO" , ""},
                { "WHOST_TIPO_MOVIMENTO" , ""},
                { "WS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA1476B_MOVDIARIO", q3);

            #endregion

            #region R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_OCOREND" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_OCOREND" , ""},
                { "WS_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_NOME_RAZAO" , ""},
                { "GECLIMOV_ENDERECO" , ""},
                { "GECLIMOV_BAIRRO" , ""},
                { "GECLIMOV_CIDADE" , ""},
                { "GECLIMOV_SIGLA_UF" , ""},
                { "GECLIMOV_CEP" , ""},
                { "GECLIMOV_DDD" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "GECLIMOV_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
                { "BILHETE_DATA_QUITACAO" , ""},
                { "BILHETE_COD_CLIENTE" , ""},
                { "BILHETE_OCORR_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_OCORR_ENDERECO" , ""},
                { "SEGURVGA_IDE_SEXO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_IDE_SEXO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
                { "ENDOSSOS_COD_PRODUTO" , ""},
                { "WHOST_NOME_ESTIP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_IND_TIPO_CONTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CONVENIO" , ""},
                { "VGCOBSUB_COD_COBERTURA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1", q16);

            #endregion

            #region R5200_00_SELECT_PARAM_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_CLIENTE" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_PARAM_INTG01" , ""},
                { "LTSOLPAR_PARAM_INTG02" , ""},
                { "LTSOLPAR_PARAM_INTG03" , ""},
                { "LTSOLPAR_PARAM_DEC01" , ""},
                { "LTSOLPAR_DATA_SOLICITACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_SELECT_PARAM_DB_SELECT_1_Query1", q17);

            #endregion

            #region R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1", q18);

            #endregion

            #region R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_PRODUTO" , ""},
                { "LTSOLPAR_COD_CLIENTE" , ""},
                { "LTSOLPAR_COD_PROGRAMA" , ""},
                { "LTSOLPAR_TIPO_SOLICITACAO" , ""},
                { "LTSOLPAR_DATA_SOLICITACAO" , ""},
                { "LTSOLPAR_COD_USUARIO" , ""},
                { "LTSOLPAR_DATA_PREV_PROC" , ""},
                { "LTSOLPAR_SIT_SOLICITACAO" , ""},
                { "LTSOLPAR_PARAM_DATE01" , ""},
                { "LTSOLPAR_PARAM_DATE02" , ""},
                { "LTSOLPAR_PARAM_DATE03" , ""},
                { "LTSOLPAR_PARAM_SMINT01" , ""},
                { "LTSOLPAR_PARAM_SMINT02" , ""},
                { "LTSOLPAR_PARAM_SMINT03" , ""},
                { "LTSOLPAR_PARAM_INTG01" , ""},
                { "LTSOLPAR_PARAM_INTG02" , ""},
                { "LTSOLPAR_PARAM_INTG03" , ""},
                { "LTSOLPAR_PARAM_DEC01" , ""},
                { "LTSOLPAR_PARAM_DEC02" , ""},
                { "LTSOLPAR_PARAM_DEC03" , ""},
                { "LTSOLPAR_PARAM_FLOAT01" , ""},
                { "LTSOLPAR_PARAM_FLOAT02" , ""},
                { "LTSOLPAR_PARAM_CHAR01" , ""},
                { "LTSOLPAR_PARAM_CHAR02" , ""},
                { "LTSOLPAR_PARAM_CHAR03" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1", q19);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MVA1476B", "PVA1476B", "PVA1476B", "M1476BHM", "M1476BHM", "P1476BHM")]
        public static void VA1476B_Tests_Theory(string MVA1476B_FILE_NAME_P, string PVA1476B_FILE_NAME_P, string RVA1476B_FILE_NAME_P, string M1476BHM_FILE_NAME_P, string P1476BHM_FILE_NAME_P, string R1476BHM_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MVA1476B_FILE_NAME_P = $"{MVA1476B_FILE_NAME_P}_{timestamp}.txt";
            PVA1476B_FILE_NAME_P = $"{PVA1476B_FILE_NAME_P}_{timestamp}.txt";
            M1476BHM_FILE_NAME_P = $"{M1476BHM_FILE_NAME_P}_{timestamp}.txt";
            P1476BHM_FILE_NAME_P = $"{P1476BHM_FILE_NAME_P}_{timestamp}.txt";
            R1476BHM_FILE_NAME_P = $"{R1476BHM_FILE_NAME_P}_{timestamp}.txt";
            RVA1476B_FILE_NAME_P = $"{RVA1476B_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , "2020-01-01"},
                { "SISTEMAS_DTCURREN" , "2020-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1", q1);

                #endregion

                #region VA1476B_MOVDIARIO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_CERTIFICADO" , "123456"},
                { "MOVIMVGA_COD_OPERACAO" , "1"},
                { "MOVIMVGA_OCORR_ENDERECO" , "X"},
                { "MOVIMVGA_NUM_APOLICE" , "123456"},
                { "MOVIMVGA_COD_SUBGRUPO" , "1"},
                { "WHOST_TIPO_MOVIMENTO" , "X"},
                { "WS_COD_PRODUTO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("VA1476B_MOVDIARIO");
                AppSettings.TestSet.DynamicData.Add("VA1476B_MOVDIARIO", q3);

                #endregion

                #region R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "12346"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_DATA_QUITACAO" , "2020-01-01"},
                { "PROPOVA_NUM_CERTIFICADO" , "123456"},
                { "PROPOVA_COD_CLIENTE" , "1"},
                { "PROPOVA_COD_PRODUTO" , "1"},
                { "PROPOVA_OCOREND" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "123456"},
                { "PROPOVA_OCOREND" , "1"},
                { "WS_COD_PRODUTO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_NOME_RAZAO" , "IGREJA BATISTA 2 DE JULHO"},
                { "GECLIMOV_ENDERECO" , "RUA CARLOS GOMES 120"},
                { "GECLIMOV_BAIRRO" , "CENTRO"},
                { "GECLIMOV_CIDADE" , "SALVADOR"},
                { "GECLIMOV_SIGLA_UF" , "BA"},
                { "GECLIMOV_CEP" , "40060330"},
                { "GECLIMOV_DDD" , "71"},
                { "GECLIMOV_TELEFONE" , "70707070"},
                { "GECLIMOV_DATA_NASCIMENTO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "78"},
                { "BILHETE_NUM_APOLICE" , "0"},
                { "BILHETE_DATA_QUITACAO" , "1994-01-10"},
                { "BILHETE_COD_CLIENTE" , "5607194"},
                { "BILHETE_OCORR_ENDERECO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
                { "SEGURVGA_NUM_CERTIFICADO" , "10000342585"},
                { "SEGURVGA_COD_CLIENTE" , "640712"},
                { "SEGURVGA_OCORR_ENDERECO" , "1"},
                { "SEGURVGA_IDE_SEXO" , "F"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "3707"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"},
                { "CLIENTES_CGCCPF" , "0"},
                { "CLIENTES_DATA_NASCIMENTO" , "202-01-01"},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_IDE_SEXO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "Q 18 C 29 SETOR B"},
                { "ENDERECO_BAIRRO" , "MOCAMBINHO"},
                { "ENDERECO_CIDADE" , "TERESINA"},
                { "ENDERECO_SIGLA_UF" , "PI"},
                { "ENDERECO_CEP" , "64010220"},
                { "ENDERECO_DDD" , "0"},
                { "ENDERECO_TELEFONE" , "0"},
                { "ENDERECO_FAX" , "0"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
                { "SEGURVGA_NUM_ITEM" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2038-01-24"},
                { "ENDOSSOS_COD_PRODUTO" , "6800"},
                { "WHOST_NOME_ESTIP" , "CAIXA ECONOMICA FEDERAL                 "},
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1", q14);
                #endregion

                #region R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_IND_TIPO_CONTA" , "N"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CONVENIO" , "40000527273"},
                { "VGCOBSUB_COD_COBERTURA" , "83"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1", q16);

                #endregion

                #region R5200_00_SELECT_PARAM_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_CLIENTE" , "50191853"},
                { "LTSOLPAR_PARAM_SMINT01" , "0"},
                { "LTSOLPAR_PARAM_INTG01" , "0"},
                { "LTSOLPAR_PARAM_INTG02" , "0"},
                { "LTSOLPAR_PARAM_INTG03" , "0"},
                { "LTSOLPAR_PARAM_DEC01" , "0"},
                { "LTSOLPAR_DATA_SOLICITACAO" , "2019-05-28"},
            });
                AppSettings.TestSet.DynamicData.Remove("R5200_00_SELECT_PARAM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5200_00_SELECT_PARAM_DB_SELECT_1_Query1", q17);
                #endregion



                #endregion
                var program = new VA1476B();
                program.Execute(new VA1476B_WPAR_PARAMETROS(), MVA1476B_FILE_NAME_P, PVA1476B_FILE_NAME_P, RVA1476B_FILE_NAME_P, M1476BHM_FILE_NAME_P, P1476BHM_FILE_NAME_P, R1476BHM_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                #region R0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

                var envList1 = AppSettings.TestSet.DynamicData["R0300_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1?.Count > 1);
                Assert.True(envList1[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var SISTEMAS_DATA_MOV_ABERTO) && SISTEMAS_DATA_MOV_ABERTO == "2020-01-01");

                #endregion

                #region R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1

                var envList2 = AppSettings.TestSet.DynamicData["R5300_00_UPDATE_PARAM_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList2?.Count > 1);

                #endregion

                #region R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1

                var envList3 = AppSettings.TestSet.DynamicData["R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3?.Count > 1);
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_COD_PRODUTO", out var LTSOLPAR_COD_PRODUTO) && LTSOLPAR_COD_PRODUTO == "4000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_COD_CLIENTE", out var LTSOLPAR_COD_CLIENTE) && LTSOLPAR_COD_CLIENTE == "000000000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_COD_PROGRAMA", out var LTSOLPAR_COD_PROGRAMA) && LTSOLPAR_COD_PROGRAMA == "VA1476B     ");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_TIPO_SOLICITACAO", out var LTSOLPAR_TIPO_SOLICITACAO) && LTSOLPAR_TIPO_SOLICITACAO == "0000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_DATA_SOLICITACAO", out var LTSOLPAR_DATA_SOLICITACAO) && LTSOLPAR_DATA_SOLICITACAO == "2020-01-01");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_DATA_PREV_PROC", out var LTSOLPAR_DATA_PREV_PROC) && LTSOLPAR_DATA_PREV_PROC == "9999-12-31");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_SIT_SOLICITACAO", out var LTSOLPAR_SIT_SOLICITACAO) && LTSOLPAR_SIT_SOLICITACAO == "0");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_DATE01", out var LTSOLPAR_PARAM_DATE01) && LTSOLPAR_PARAM_DATE01 == "9999-12-31");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_DATE02", out var LTSOLPAR_PARAM_DATE02) && LTSOLPAR_PARAM_DATE02 == "9999-12-31");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_DATE03", out var LTSOLPAR_PARAM_DATE03) && LTSOLPAR_PARAM_DATE03 == "9999-12-31");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_SMINT01", out var LTSOLPAR_PARAM_SMINT01) && LTSOLPAR_PARAM_SMINT01 == "0001");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_SMINT02", out var LTSOLPAR_PARAM_SMINT02) && LTSOLPAR_PARAM_SMINT02 == "0000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_SMINT03", out var LTSOLPAR_PARAM_SMINT03) && LTSOLPAR_PARAM_SMINT03 == "0000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_INTG01", out var LTSOLPAR_PARAM_INTG01) && LTSOLPAR_PARAM_INTG01 == "000000000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_INTG02", out var LTSOLPAR_PARAM_INTG02) && LTSOLPAR_PARAM_INTG02 == "000000000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_INTG03", out var LTSOLPAR_PARAM_INTG03) && LTSOLPAR_PARAM_INTG03 == "000000000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_DEC01", out var LTSOLPAR_PARAM_DEC01) && LTSOLPAR_PARAM_DEC01 == "00000000000000000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_DEC02", out var LTSOLPAR_PARAM_DEC02) && LTSOLPAR_PARAM_DEC02 == "00000000000000000");
                Assert.True(envList3[1].TryGetValue("LTSOLPAR_PARAM_DEC03", out var LTSOLPAR_PARAM_DEC03) && LTSOLPAR_PARAM_DEC03 == "00000000000000000");

                #endregion


                Assert.True(program.RETURN_CODE == 0);
            }
        }


        [Theory]
        [InlineData("MVA1476B", "PVA1476B", "PVA1476B", "M1476BHM", "M1476BHM", "P1476BHM")]
        public static void VA1476B_Tests99_Theory(string MVA1476B_FILE_NAME_P, string PVA1476B_FILE_NAME_P, string RVA1476B_FILE_NAME_P, string M1476BHM_FILE_NAME_P, string P1476BHM_FILE_NAME_P, string R1476BHM_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MVA1476B_FILE_NAME_P = $"{MVA1476B_FILE_NAME_P}_{timestamp}.txt";
            PVA1476B_FILE_NAME_P = $"{PVA1476B_FILE_NAME_P}_{timestamp}.txt";
            M1476BHM_FILE_NAME_P = $"{M1476BHM_FILE_NAME_P}_{timestamp}.txt";
            P1476BHM_FILE_NAME_P = $"{P1476BHM_FILE_NAME_P}_{timestamp}.txt";
            R1476BHM_FILE_NAME_P = $"{R1476BHM_FILE_NAME_P}_{timestamp}.txt";
            RVA1476B_FILE_NAME_P = $"{RVA1476B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                /*  q0.AddDynamic(new Dictionary<string, string>{
                  { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"},
                  { "SISTEMAS_DATA_MOV_ABERTO_30" , "2020-01-01"},
                  { "SISTEMAS_DTCURREN" , "2020-01-01"},
                  });*/
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2020-01-01"}
            });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1", q1);

                #endregion

                #region VA1476B_MOVDIARIO

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "MOVIMVGA_NUM_CERTIFICADO" , "123456"},
                { "MOVIMVGA_COD_OPERACAO" , "1"},
                { "MOVIMVGA_OCORR_ENDERECO" , "X"},
                { "MOVIMVGA_NUM_APOLICE" , "123456"},
                { "MOVIMVGA_COD_SUBGRUPO" , "1"},
                { "WHOST_TIPO_MOVIMENTO" , "X"},
                { "WS_COD_PRODUTO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("VA1476B_MOVDIARIO");
                AppSettings.TestSet.DynamicData.Add("VA1476B_MOVDIARIO", q3);

                #endregion

                #region R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "12346"},
                { "PROPOVA_COD_SUBGRUPO" , "1"},
                { "PROPOVA_DATA_QUITACAO" , "2020-01-01"},
                { "PROPOVA_NUM_CERTIFICADO" , "123456"},
                { "PROPOVA_COD_CLIENTE" , "1"},
                { "PROPOVA_COD_PRODUTO" , "1"},
                { "PROPOVA_OCOREND" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "123456"},
                { "PROPOVA_OCOREND" , "1"},
                { "WS_COD_PRODUTO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_PROPOVA_DB_SELECT_1_Query1", q5);

                #endregion

                #region R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_NOME_RAZAO" , "IGREJA BATISTA 2 DE JULHO"},
                { "GECLIMOV_ENDERECO" , "RUA CARLOS GOMES 120"},
                { "GECLIMOV_BAIRRO" , "CENTRO"},
                { "GECLIMOV_CIDADE" , "SALVADOR"},
                { "GECLIMOV_SIGLA_UF" , "BA"},
                { "GECLIMOV_CEP" , "40060330"},
                { "GECLIMOV_DDD" , "71"},
                { "GECLIMOV_TELEFONE" , "70707070"},
                { "GECLIMOV_DATA_NASCIMENTO" , "2020-01-01"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_GECLIMOV_DB_SELECT_1_Query1", q6);

                #endregion

                #region R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , "78"},
                { "BILHETE_NUM_APOLICE" , "0"},
                { "BILHETE_DATA_QUITACAO" , "1994-01-10"},
                { "BILHETE_COD_CLIENTE" , "5607194"},
                { "BILHETE_OCORR_ENDERECO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1040_00_SELECT_BILHETE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "VGCOBSUB_COD_COBERTURA" , "1"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1050_00_SEL_VGCOBSUB_DB_SELECT_1_Query1", q8);

                #endregion

                #region R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "81010000001"},
                { "SEGURVGA_COD_SUBGRUPO" , "1"},
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
                { "SEGURVGA_NUM_CERTIFICADO" , "10000342585"},
                { "SEGURVGA_COD_CLIENTE" , "640712"},
                { "SEGURVGA_OCORR_ENDERECO" , "1"},
                { "SEGURVGA_IDE_SEXO" , "F"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1060_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_COD_PRODUTO" , "3707"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1070_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q10);

                #endregion

                #region R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "JOAO FORTES ENGENHARIA S/A"},
                { "CLIENTES_CGCCPF" , "0"},
                { "CLIENTES_DATA_NASCIMENTO" , "202-01-01"},
                { "CLIENTES_TIPO_PESSOA" , "F"},
                { "CLIENTES_IDE_SEXO" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_CLIENTE_DB_SELECT_1_Query1", q11);

                #endregion

                #region R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "ENDERECO_ENDERECO" , "Q 18 C 29 SETOR B"},
                { "ENDERECO_BAIRRO" , "MOCAMBINHO"},
                { "ENDERECO_CIDADE" , "TERESINA"},
                { "ENDERECO_SIGLA_UF" , "PI"},
                { "ENDERECO_CEP" , "64010220"},
                { "ENDERECO_DDD" , "0"},
                { "ENDERECO_TELEFONE" , "0"},
                { "ENDERECO_FAX" , "0"},
                { "ENDERECO_SIT_REGISTRO" , "0"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_ENDERECO_DB_SELECT_1_Query1", q12);

                #endregion

                #region R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_DATA_INIVIGENCIA" , "1990-07-10"},
                { "SEGURVGA_NUM_ITEM" , "1"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q13);

                #endregion

                #region R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , "2038-01-24"},
                { "ENDOSSOS_COD_PRODUTO" , "6800"},
                { "WHOST_NOME_ESTIP" , "CAIXA ECONOMICA FEDERAL                 "},
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_ENDOSSO_DB_SELECT_1_Query1", q14);
                #endregion

                #region R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_IND_TIPO_CONTA" , "N"}
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q15);

                #endregion

                #region R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_CONVENIO" , "40000527273"},
                { "VGCOBSUB_COD_COBERTURA" , "83"},
            });
                AppSettings.TestSet.DynamicData.Remove("R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1600_SELECT_NOVA_ASSIST_DB_SELECT_1_Query1", q16);

                #endregion

                #region R5200_00_SELECT_PARAM_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "LTSOLPAR_COD_CLIENTE" , "50191853"},
                { "LTSOLPAR_PARAM_SMINT01" , "0"},
                { "LTSOLPAR_PARAM_INTG01" , "0"},
                { "LTSOLPAR_PARAM_INTG02" , "0"},
                { "LTSOLPAR_PARAM_INTG03" , "0"},
                { "LTSOLPAR_PARAM_DEC01" , "0"},
                { "LTSOLPAR_DATA_SOLICITACAO" , "2019-05-28"},
            });
                AppSettings.TestSet.DynamicData.Remove("R5200_00_SELECT_PARAM_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R5200_00_SELECT_PARAM_DB_SELECT_1_Query1", q17);
                #endregion



                #endregion
                var program = new VA1476B();
                program.Execute(new VA1476B_WPAR_PARAMETROS(), MVA1476B_FILE_NAME_P, PVA1476B_FILE_NAME_P, RVA1476B_FILE_NAME_P, M1476BHM_FILE_NAME_P, P1476BHM_FILE_NAME_P, R1476BHM_FILE_NAME_P);

                AppSettings.TestSet.DynamicData.Where(x => (x.Key.Contains("Update") || x.Key.Contains("Insert")) && x.Value.DynamicList.Count > 1);

                Assert.True(program.RETURN_CODE == 9);
            }
        }




    }
}