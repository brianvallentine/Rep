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
using static Code.VG9521B;

namespace FileTests.Test
{
    [Collection("VG9521B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG9521B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0000_00_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0000_00_PRINCIPAL_DB_UPDATE_1_Update1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_UPDATE_1_Update1", q1);

            #endregion

            #region R0000_00_PRINCIPAL_DB_SELECT_2_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0000_00_PRINCIPAL_DB_SELECT_2_Query1", q2);

            #endregion

            #region R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "SEGURVGA_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_CERTIFICADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0050_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1", q5);

            #endregion

            #region R0060_00_INTEGRA_VG_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NASCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_INTEGRA_VG_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0060_01_CLIENTE_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_01_CLIENTE_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0060_00_INTEGRA_VG_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("R0060_00_INTEGRA_VG_DB_SELECT_2_Query1", q8);

            #endregion

            #region R0060_01_CLIENTE_DB_SELECT_2_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_01_CLIENTE_DB_SELECT_2_Query1", q9);

            #endregion

            #region R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_09_CRIA_CLIENTE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_09_CRIA_CLIENTE_DB_UPDATE_1_Update1", q11);

            #endregion

            #region R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R0060_10_CONTINUA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_09_CRIA_CLIENTE_DB_SELECT_2_Query1", q14);

            #endregion

            #region R0060_10_CONTINUA_DB_SELECT_2_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_SELECT_2_Query1", q15);

            #endregion

            #region R0060_10_CONTINUA_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_UPDATE_1_Update1", q16);

            #endregion

            #region R0060_10_CONTINUA_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "MOVIMVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_ESTADO_CIVIL" , ""},
                { "MOVIMVGA_IDE_SEXO" , ""},
                { "MOVIMVGA_NUM_MATRICULA" , ""},
                { "MOVIMVGA_VAL_SALARIO" , ""},
                { "MOVIMVGA_TIPO_SALARIO" , ""},
                { "MOVIMVGA_TIPO_PLANO" , ""},
                { "MOVIMVGA_QTD_SAL_MORNATU" , ""},
                { "MOVIMVGA_TAXA_VG" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_IMP_MORACID_ATU" , ""},
                { "MOVIMVGA_IMP_INVPERM_ATU" , ""},
                { "MOVIMVGA_PRM_VG_ATU" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "MOVIMVGA_DATA_AVERBACAO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "FATURCON_DATA_REFERENCIA" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0060_09_CRIA_CLIENTE_DB_INSERT_2_Insert1", q18);

            #endregion

            #region R0060_10_CONTINUA_DB_SELECT_3_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0060_10_CONTINUA_DB_SELECT_3_Query1", q19);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NASCIMENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_1_Query1", q20);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1", q21);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
                { "APOLICOB_PRM_TARIFARIO_IX" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_3_Query1", q22);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_4_Query1", q23);

            #endregion

            #region R7310_00_MAX_GECLIMOV_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_HIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7310_00_MAX_GECLIMOV_DB_SELECT_1_Query1", q24);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1_Update1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_UPDATE_1_Update1", q25);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_COD_FONTE" , ""},
                { "FONTES_ULT_PROP_AUTOMAT" , ""},
                { "SEGURVGA_NUM_CERTIFICADO" , ""},
                { "SEGURVGA_COD_CLIENTE" , ""},
                { "MOVIMVGA_COD_AGENCIADOR" , ""},
                { "MOVIMVGA_NUM_MATRICULA" , ""},
                { "MOVIMVGA_VAL_SALARIO" , ""},
                { "MOVIMVGA_TIPO_SALARIO" , ""},
                { "MOVIMVGA_TIPO_PLANO" , ""},
                { "MOVIMVGA_QTD_SAL_MORNATU" , ""},
                { "MOVIMVGA_TAXA_VG" , ""},
                { "MOVIMVGA_IMP_MORNATU_ANT" , ""},
                { "MOVIMVGA_IMP_MORNATU_ATU" , ""},
                { "MOVIMVGA_IMP_MORACID_ANT" , ""},
                { "MOVIMVGA_IMP_MORACID_ATU" , ""},
                { "MOVIMVGA_IMP_INVPERM_ANT" , ""},
                { "MOVIMVGA_IMP_INVPERM_ATU" , ""},
                { "MOVIMVGA_PRM_VG_ANT" , ""},
                { "MOVIMVGA_PRM_VG_ATU" , ""},
                { "MOVIMVGA_COD_OPERACAO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "MOVIMVGA_DATA_AVERBACAO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
                { "FATURCON_DATA_REFERENCIA" , ""},
                { "SEGURVGA_DATA_INIVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_INSERT_1_Insert1", q26);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5_Query1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_IMP_SEGURADA_IX" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_5_Query1", q27);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_6_Query1", q28);

            #endregion

            #region VG9521B_C01_GECLIMOV

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_TIPO_MOVIMENTO" , ""},
                { "GECLIMOV_DATA_ULT_MANUTEN" , ""},
                { "GECLIMOV_NOME_RAZAO" , ""},
                { "GECLIMOV_TIPO_PESSOA" , ""},
                { "GECLIMOV_IDE_SEXO" , ""},
                { "GECLIMOV_ESTADO_CIVIL" , ""},
                { "GECLIMOV_OCORR_ENDERECO" , ""},
                { "GECLIMOV_ENDERECO" , ""},
                { "GECLIMOV_BAIRRO" , ""},
                { "GECLIMOV_CIDADE" , ""},
                { "GECLIMOV_SIGLA_UF" , ""},
                { "GECLIMOV_CEP" , ""},
                { "GECLIMOV_DDD" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "GECLIMOV_FAX" , ""},
                { "GECLIMOV_OCORR_HIST" , ""},
                { "GECLIMOV_CGCCPF" , ""},
                { "GECLIMOV_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG9521B_C01_GECLIMOV", q29);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "FATURCON_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_7_Query1", q30);

            #endregion

            #region R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "FONTES_ULT_PROP_AUTOMAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1", q31);

            #endregion

            #region R7400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_COD_CLIENTE" , ""},
                { "GECLIMOV_TIPO_MOVIMENTO" , ""},
                { "GECLIMOV_DATA_ULT_MANUTEN" , ""},
                { "GECLIMOV_NOME_RAZAO" , ""},
                { "GECLIMOV_TIPO_PESSOA" , ""},
                { "GECLIMOV_IDE_SEXO" , ""},
                { "GECLIMOV_ESTADO_CIVIL" , ""},
                { "GECLIMOV_OCORR_ENDERECO" , ""},
                { "GECLIMOV_ENDERECO" , ""},
                { "GECLIMOV_BAIRRO" , ""},
                { "GECLIMOV_CIDADE" , ""},
                { "GECLIMOV_SIGLA_UF" , ""},
                { "GECLIMOV_CEP" , ""},
                { "GECLIMOV_DDD" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "GECLIMOV_FAX" , ""},
                { "GECLIMOV_OCORR_HIST" , ""},
                { "GECLIMOV_CGCCPF" , ""},
                { "GECLIMOV_DATA_NASCIMENTO" , ""},
                { "GECLIMOV_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1", q32);

            #endregion

            #region R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "GECLIMOV_OCORR_ENDERECO" , ""},
                { "VIND_OCORR_END" , ""},
                { "GECLIMOV_TIPO_PESSOA" , ""},
                { "VIND_TIPO_PESSOA" , ""},
                { "GECLIMOV_ESTADO_CIVIL" , ""},
                { "VIND_EST_CIVIL" , ""},
                { "GECLIMOV_DATA_NASCIMENTO" , ""},
                { "VIND_DTNASC" , ""},
                { "GECLIMOV_NOME_RAZAO" , ""},
                { "VIND_NOME_RAZAO" , ""},
                { "GECLIMOV_IDE_SEXO" , ""},
                { "VIND_IDE_SEXO" , ""},
                { "GECLIMOV_ENDERECO" , ""},
                { "VIND_ENDERECO" , ""},
                { "GECLIMOV_SIGLA_UF" , ""},
                { "VIND_SIGLA_UF" , ""},
                { "GECLIMOV_TELEFONE" , ""},
                { "VIND_TELEFONE" , ""},
                { "GECLIMOV_BAIRRO" , ""},
                { "VIND_BAIRRO" , ""},
                { "GECLIMOV_CIDADE" , ""},
                { "VIND_CIDADE" , ""},
                { "GECLIMOV_CGCCPF" , ""},
                { "VIND_CGCCPF" , ""},
                { "GECLIMOV_DATA_ULT_MANUTEN" , ""},
                { "GECLIMOV_TIPO_MOVIMENTO" , ""},
                { "GECLIMOV_CEP" , ""},
                { "VIND_CEP" , ""},
                { "GECLIMOV_DDD" , ""},
                { "VIND_DDD" , ""},
                { "GECLIMOV_FAX" , ""},
                { "VIND_FAX" , ""},
                { "GECLIMOV_COD_USUARIO" , ""},
                { "GECLIMOV_COD_CLIENTE" , ""},
                { "GECLIMOV_OCORR_HIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1", q33);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("123456789")]
        public static void VG9521B_Tests_Theory(string ENTRADA_FILE_NAME_P)
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
                var program = new VG9521B();
                program.Execute(ENTRADA_FILE_NAME_P);

                Assert.True(true);
            }
        }
    }
}