using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0460B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0460B_Tests
    {
        [Theory]
        [InlineData("VA0460B1_FILE.txt")]
        public static void VA0460B_Tests_Theory(string VA0460B1_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            VA0460B1_FILE_NAME_P = $"{VA0460B1_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.Clear();
                var fileName = Path.GetFileNameWithoutExtension(VA0460B1_FILE_NAME_P);
                VA0460B1_FILE_NAME_P = VA0460B1_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                AppSettings.TestSet.IsTest = true;
                var program = new VA0460B();

                Console.WriteLine($"#### Arquivo {VA0460B1_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");
                #region PARAMETERS
                #region R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0150_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "CAIXA ECONOMICA     "}
            });
                AppSettings.TestSet.DynamicData.Add("R0150_00_SELECT_V0EMPRESA_DB_SELECT_1_Query1", q1);

                #endregion

                #region VA0460B_V0HISTCOBVA

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "NUM_CERTIFICADO" , ""},
                    { "NUM_PARCELA" , ""},
                    { "NUM_TITULO" , ""},
                    { "PRM_TOTAL" , ""},
                    { "OCORR_HISTORICO" , ""},
                    { "COD_DEVOLUCAO" , ""},
                    { "COD_CLIENTE" , "1"},
                    { "OCOREND" , ""},
                    { "AGE_COBRANCA" , ""},
                    { "DATA_QUITACAO" , ""},
                    { "COD_USUARIO" , ""},
                    { "NUM_APOLICE" , ""},
                    { "COD_SUBGRUPO" , ""},
                    { "COD_PRODUTO" , "7"},
                    { "RAMO" , ""},
                    { "PREMIO_VG" , ""},
                    { "PREMIO_AP" , ""},
                });
                q2.AddDynamic(new Dictionary<string, string>{
                    { "NUM_CERTIFICADO" , ""},
                    { "NUM_PARCELA" , ""},
                    { "NUM_TITULO" , ""},
                    { "PRM_TOTAL" , ""},
                    { "OCORR_HISTORICO" , ""},
                    { "COD_DEVOLUCAO" , ""},
                    { "COD_CLIENTE" , "1"},
                    { "OCOREND" , ""},
                    { "AGE_COBRANCA" , ""},
                    { "DATA_QUITACAO" , ""},
                    { "COD_USUARIO" , ""},
                    { "NUM_APOLICE" , ""},
                    { "COD_SUBGRUPO" , ""},
                    { "COD_PRODUTO" , "7"},
                    { "RAMO" , ""},
                    { "PREMIO_VG" , ""},
                    { "PREMIO_AP" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("VA0460B_V0HISTCOBVA", q2);

                #endregion

                #region R0380_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_COD_CLIENTE" , "0"},
                    { "CLIENTES_NOME_RAZAO" , ""},
                });
                q3.AddDynamic(new Dictionary<string, string>{
                    { "CLIENTES_COD_CLIENTE" , "1"},
                    { "CLIENTES_NOME_RAZAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R0380_00_SELECT_V0CLIENTES_DB_SELECT_1_Query1", q3);

                #endregion

                #region R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_CODIGO_PRODUTO" , ""},
                { "VIND_CODPRODU" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
                { "VIND_AGECOBR" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_AGENCIA" , "2"},
                { "AGENCCEF_COD_ESCNEG" , ""},
                { "MALHACEF_COD_FONTE" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1", q5);

                #endregion

                #region R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "ESCRINEG_COD_ESCNEG" , "3"}
            });
                AppSettings.TestSet.DynamicData.Add("R0440_00_SELECT_V0ESCNEG_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "FONTES_COD_FONTE" , "4"}
            });
                AppSettings.TestSet.DynamicData.Add("R0460_00_SELECT_V0FONTE_DB_SELECT_1_Query1", q7);

                #endregion

                #region R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_ENDERECO" , "1"},
                { "VIND_CODENDER" , "1"},
            });
                AppSettings.TestSet.DynamicData.Add("R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1", q8);

                #endregion

                #region R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "DEVOLVID_COD_DEVOLUCAO" , "5"}
            });
                AppSettings.TestSet.DynamicData.Add("R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1_Query1", q9);

                #endregion

                #region R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "HISLANCT_COD_USUARIO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0540_00_SELECT_V0USUARIOS_DB_SELECT_1_Query1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , "6"}
            });
                AppSettings.TestSet.DynamicData.Add("R0540_00_SELECT_V0USUARIOS_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_RAMO_EMISSOR" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R0560_00_SELECT_V0PRODUTO_DB_SELECT_1_Query1", q12);

                #endregion

                #region R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_NUM_TITULO" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R3600_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1", q13);

                #endregion

                #region VA0460B_V0RCAPCOMP

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "COD_FONTE" , ""},
                { "NUM_RCAP" , ""},
                { "NUM_RCAP_COMPLEMEN" , ""},
                { "COD_OPERACAO" , ""},
                { "DATA_MOVIMENTO" , ""},
                { "HORA_OPERACAO" , ""},
                { "SIT_REGISTRO" , ""},
                { "BCO_AVISO" , ""},
                { "AGE_AVISO" , ""},
                { "NUM_AVISO_CREDITO" , ""},
                { "VAL_RCAP" , ""},
                { "DATA_RCAP" , ""},
                { "DATA_CADASTRAMENTO" , ""},
                { "SIT_CONTABIL" , ""},
                { "COD_EMPRESA" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("VA0460B_V0RCAPCOMP", q14);

                #endregion

                #region R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_HORA_OPERACAO" , ""},
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , ""},
                { "RCAPCOMP_COD_OPERACAO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q15);

                #endregion

                #region R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , "1"},
                { "RCAPCOMP_NUM_RCAP" , "1"},
                { "RCAPCOMP_NUM_RCAP_COMPLEMEN" , "1"},
                { "RCAPCOMP_COD_OPERACAO" , "1"},
                { "RCAPCOMP_DATA_MOVIMENTO" , "1"},
                { "RCAPCOMP_HORA_OPERACAO" , "1"},
                { "RCAPCOMP_SIT_REGISTRO" , "1"},
                { "RCAPCOMP_BCO_AVISO" , "1"},
                { "RCAPCOMP_AGE_AVISO" , "1"},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "1"},
                { "RCAPCOMP_VAL_RCAP" , "1"},
                { "RCAPCOMP_DATA_RCAP" , "1"},
                { "RCAPCOMP_DATA_CADASTRAMENTO" , "1"},
                { "RCAPCOMP_SIT_CONTABIL" , "1"},
                { "RCAPCOMP_COD_EMPRESA" , "1"},
            });
                AppSettings.TestSet.DynamicData.Add("R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1", q16);

                #endregion

                #region R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_COD_FONTE" , ""},
                { "RCAPCOMP_NUM_RCAP" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R4100_00_SELECT_V0AVISO_DB_SELECT_1_Query1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_SALDO_ATUAL" , ""}
            });
                AppSettings.TestSet.DynamicData.Add("R4100_00_SELECT_V0AVISO_DB_SELECT_1_Query1", q18);

                #endregion

                #region R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                { "AVISOSAL_SALDO_ATUAL" , ""},
                { "AVISOSAL_BCO_AVISO" , ""},
                { "AVISOSAL_AGE_AVISO" , ""},
                { "AVISOSAL_NUM_AVISO_CREDITO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1", q19);

                #endregion

                #region R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_MES_REFERENCIA" , ""},
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_ORGAO_EMISSOR" , ""},
                { "RELATORI_COD_FONTE" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_MODALIDADE" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_PLANO" , ""},
                { "RELATORI_OCORR_HISTORICO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_PARC_LIDER" , ""},
                { "RELATORI_NUM_SINISTRO" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_COD_EMPRESA" , ""},
                { "RELATORI_PERI_RENOVACAO" , ""},
                { "RELATORI_PCT_AUMENTO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1", q20);

                #endregion

                #region R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "COBHISVI_NUM_CERTIFICADO" , ""},
                { "COBHISVI_NUM_PARCELA" , ""},
                { "COBHISVI_NUM_TITULO" , ""},
            });
                AppSettings.TestSet.DynamicData.Add("R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1", q21);

                #endregion

                #endregion

                program.Execute(VA0460B1_FILE_NAME_P);
                Assert.True(File.Exists(program.VA0460B1.FilePath));

                Assert.True(new FileInfo(program.VA0460B1.FilePath)?.Length > 0);

                //var envList = AppSettings.TestSet.DynamicData["R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1);
                //Assert.True(envList[1].TryGetValue("RELATORI_IDE_SISTEMA", out var valOr) && valOr == "CB");

            }
        }
    }
}