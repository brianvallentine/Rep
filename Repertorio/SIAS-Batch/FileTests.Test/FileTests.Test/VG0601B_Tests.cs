using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VG0601B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("VG0601B_Tests")]
    public class VG0601B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region VG0601B_C01_FONTES

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FONTES_COD_FONTE" , ""},
                { "FONTES_NOME_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0601B_C01_FONTES", q2);

            #endregion

            #region VG0601B_C01_PROPOVA

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_COD_FONTE" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0601B_C01_PROPOVA", q3);

            #endregion

            #region R1400_00_LE_CLIENTE_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_LE_CLIENTE_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1400_00_LE_CLIENTE_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_LE_CLIENTE_DB_SELECT_2_Query1", q5);

            #endregion

            #region R1500_00_LE_PRODUTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_LE_PRODUTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2000_00_LE_SUREG_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2000_00_LE_SUREG_DB_SELECT_2_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_SUREG_SASSE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_2_Query1", q8);

            #endregion

            #region R2100_00_LE_FUNCEF_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NOME_FUNCIONARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_LE_FUNCEF_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2000_00_LE_SUREG_DB_SELECT_3_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SUREGSAS_NOME_SUREG_SASSE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_3_Query1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VG0601BSaida")]
        public static void VG0601B_Tests_Theory(string ARQUIVO_QUADRO11_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "Seguros S.A." }
            });
            AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region VG0601B_C01_FONTES

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FONTES_COD_FONTE" , "1234" },
                { "FONTES_NOME_FONTE" , "Fonte Principal" },
            });
            AppSettings.TestSet.DynamicData.Remove("VG0601B_C01_FONTES");
AppSettings.TestSet.DynamicData.Add("VG0601B_C01_FONTES", q2);

                #endregion

                #region VG0601B_C01_PROPOVA

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "987654321" },
                { "PROPOVA_NUM_APOLICE" , "123456789" },
                { "PROPOVA_COD_SUBGRUPO" , "001" },
                { "PROPOVA_COD_FONTE" , "1234" },
                { "PROPOVA_SIT_REGISTRO" , "Ativo" },
                { "PROPOVA_AGE_COBRANCA" , "Agência Central" },
                { "PROPOVA_DATA_QUITACAO" , "2024-01-01" },
                { "PROPOVA_NUM_MATRI_VENDEDOR" , "VN001" },
                { "HISCOBPR_VLPREMIO" , "500.00" },
                { "HISCOBPR_IMPSEGUR" , "10000.00" },
            });
                
                AppSettings.TestSet.DynamicData.Remove("VG0601B_C01_PROPOVA");
AppSettings.TestSet.DynamicData.Add("VG0601B_C01_PROPOVA", q3);

                #endregion

                #region R1400_00_LE_CLIENTE_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "C001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_CLIENTE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_LE_CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1400_00_LE_CLIENTE_DB_SELECT_2_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "12345678901" },
                { "CLIENTES_NOME_RAZAO" , "Cliente Exemplo" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_CLIENTE_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R1400_00_LE_CLIENTE_DB_SELECT_2_Query1", q5);

                #endregion

                #region R1500_00_LE_PRODUTO_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "Seguro Vida" },
                { "PRODUVG_ORIG_PRODU" , "CAMP" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_PRODUTO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R1500_00_LE_PRODUTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2000_00_LE_SUREG_DB_SELECT_1_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , "EN001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_LE_SUREG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2000_00_LE_SUREG_DB_SELECT_2_Query1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_SUREG_SASSE" , "SR001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_LE_SUREG_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_2_Query1", q8);

                #endregion

                #region R2100_00_LE_FUNCEF_DB_SELECT_1_Query1

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NOME_FUNCIONARIO" , "João Silva" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2100_00_LE_FUNCEF_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R2100_00_LE_FUNCEF_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2000_00_LE_SUREG_DB_SELECT_3_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SUREGSAS_NOME_SUREG_SASSE" , "Superintendência Regional" }
            });
            AppSettings.TestSet.DynamicData.Remove("R2000_00_LE_SUREG_DB_SELECT_3_Query1");
AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_3_Query1", q10);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute(new VG0601B_WPARM_PARAMETRO(), ARQUIVO_QUADRO11_FILE_NAME_P);
                var program = new VG0601B();

                var param = new VG0601B_WPARM_PARAMETRO();
                param.WPARM_ROTINA.Value = "E";
                param.WPARM_DATINI.Value = "20240112";
                param.WPARM_DATTER.Value = "20250215";
                

                program.Execute(param, ARQUIVO_QUADRO11_FILE_NAME_P);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VG0601BSaida")]
        public static void VG0601B_Tests_Return99(string ARQUIVO_QUADRO11_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();


                #region VARIAVEIS_TESTE

                #region PARAMETERS

                #region R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "EMPRESAS_NOME_EMPRESA" , "Seguros S.A." }
            });
                AppSettings.TestSet.DynamicData.Remove("R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0110_00_SELECT_EMPRESAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" }
            });
                AppSettings.TestSet.DynamicData.Remove("R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0120_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q1);

                #endregion

                #region VG0601B_C01_FONTES

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "FONTES_COD_FONTE" , "1234" },
                { "FONTES_NOME_FONTE" , "Fonte Principal" },
            });
                AppSettings.TestSet.DynamicData.Remove("VG0601B_C01_FONTES");
                AppSettings.TestSet.DynamicData.Add("VG0601B_C01_FONTES", q2);

                #endregion

                #region VG0601B_C01_PROPOVA

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{

            });

                AppSettings.TestSet.DynamicData.Remove("VG0601B_C01_PROPOVA");
                AppSettings.TestSet.DynamicData.Add("VG0601B_C01_PROPOVA", q3);

                #endregion

                #region R1400_00_LE_CLIENTE_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , "C001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_CLIENTE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_LE_CLIENTE_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1400_00_LE_CLIENTE_DB_SELECT_2_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_CGCCPF" , "12345678901" },
                { "CLIENTES_NOME_RAZAO" , "Cliente Exemplo" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1400_00_LE_CLIENTE_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R1400_00_LE_CLIENTE_DB_SELECT_2_Query1", q5);

                #endregion

                #region R1500_00_LE_PRODUTO_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_NOME_PRODUTO" , "Seguro Vida" },
                { "PRODUVG_ORIG_PRODU" , "CAMP" },
            });
                AppSettings.TestSet.DynamicData.Remove("R1500_00_LE_PRODUTO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_LE_PRODUTO_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2000_00_LE_SUREG_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                { "AGENCCEF_COD_ESCNEG" , "EN001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_LE_SUREG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2000_00_LE_SUREG_DB_SELECT_2_Query1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "MALHACEF_COD_SUREG_SASSE" , "SR001" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_LE_SUREG_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_2_Query1", q8);

                #endregion

                #region R2100_00_LE_FUNCEF_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                { "FUNCICEF_NOME_FUNCIONARIO" , "João Silva" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_LE_FUNCEF_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_LE_FUNCEF_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2000_00_LE_SUREG_DB_SELECT_3_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "SUREGSAS_NOME_SUREG_SASSE" , "Superintendência Regional" }
            });
                AppSettings.TestSet.DynamicData.Remove("R2000_00_LE_SUREG_DB_SELECT_3_Query1");
                AppSettings.TestSet.DynamicData.Add("R2000_00_LE_SUREG_DB_SELECT_3_Query1", q10);

                #endregion

                #endregion

                #endregion
                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...program.Execute(new VG0601B_WPARM_PARAMETRO(), ARQUIVO_QUADRO11_FILE_NAME_P);
                var program = new VG0601B();

                var param = new VG0601B_WPARM_PARAMETRO();
                param.WPARM_ROTINA.Value = "E";
                param.WPARM_DATINI.Value = "20240112";
                param.WPARM_DATTER.Value = "20250215";

                program.Execute(param, ARQUIVO_QUADRO11_FILE_NAME_P);

                Assert.True(program.RETURN_CODE != 0);
            }
        }
    }
}