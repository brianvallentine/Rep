using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA0458B;

namespace FileTests.Test
{
    [Collection("VA0458B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0458B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "V1SIST_DTMOVABE_1" , ""},
                { "V1SIST_DTMOVABE_2" , ""},
                { "V1SIST_DTMOVABE_3" , ""},
                { "V1SIST_DTMOVABE_4" , ""},
                { "V1SIST_DTMOVABE_10" , ""},
                { "V1SIST_DTMOVABE_11" , ""},
                { "V1SIST_DTMOVABE_12" , ""},
                { "V1SIST_DTMOVABE_13" , ""},
                { "V1SIST_DTMOVABE_14" , ""},
                { "V1SIST_DTMOVABE_30" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0300_00_SELECT_CALENDARIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "CALENDAR_DIA_SEMANA" , ""},
                { "CALENDAR_FERIADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SELECT_CALENDARIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "FERIADOS_DATA_FERIADO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_FERIADO_DB_SELECT_1_Query1", q2);

            #endregion

            #region VA0458B_TCOMIS

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_DTQITBCO" , ""},
                { "V0PROP_DTQITBCO15" , ""},
                { "V0PROP_SITUACAO" , ""},
                { "V0PROP_DPS_TITULAR" , ""},
                { "V0PROP_DPS_CONJUGE" , ""},
                { "V0PROP_DTA_DECLINIO" , ""},
                { "V0PROP_ACATAMENTO" , ""},
                { "WHOST_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0458B_TCOMIS", q3);

            #endregion

            #region R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_SIN_RELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1015_00_SELECT_OPCAOPAG_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPC_PAGTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1015_00_SELECT_OPCAOPAG_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CONV_NUM_SICOB" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRRCAP" , ""},
                { "WHOST_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1025_00_SELECT_V0RCAP_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "WHOST_NRRCAP" , ""},
                { "WHOST_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1025_00_SELECT_V0RCAP_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATARCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1026_00_SELECT_V0RCAPCOMP_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1030_00_SELECT_VG078_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WHOST_ACOMP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1030_00_SELECT_VG078_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "WHOST_ERROS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_SELECT_V0ERROSPROPVA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1100_00_SELECT_FIDELIZ_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PF_NUM_PROP_SIVPF" , ""},
                { "PF_OPCAOPAG" , ""},
                { "PF_AGECTADEB" , ""},
                { "PF_OPRCTADEB" , ""},
                { "PF_NUMCTADEB" , ""},
                { "PF_DIGCTADEB" , ""},
                { "PF_VAL_PAGO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1110_00_SELECT_RELATORI_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0RELA_CODRELAT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_SELECT_RELATORI_DB_SELECT_1_Query1", q13);

            #endregion

            #region R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_RELATORIOS_DB_SELECT_1_Query1", q14);

            #endregion

            #region R2000_00_INSERT_RELATORIOS_DB_INSERT_2_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""},
                { "WHOST_COD_RELAT" , ""},
                { "WHOST_NUM_COPIAS" , ""},
                { "WHOST_BCO_RELAT" , ""},
                { "PF_AGECTADEB" , ""},
                { "PF_OPRCTADEB" , ""},
                { "PF_DIGCTADEB" , ""},
                { "V0PROP_APOLICE" , ""},
                { "V0PROP_NRCERTIF" , ""},
                { "V0PROP_CODSUBES" , ""},
                { "PF_NUMCTADEB" , ""},
                { "WHOST_SIN_RELAT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_INSERT_RELATORIOS_DB_INSERT_2_Insert1", q15);

            #endregion

            #region R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_INSERT_ERRPROVI_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DTA_DECLINIO" , ""},
                { "V1SIST_DTMOVABE" , ""},
                { "V0PROP_NRCERTIF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R3110_00_CONSULTA_PENDENTES_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_PENDENTES" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3110_00_CONSULTA_PENDENTES_DB_SELECT_1_Query1", q18);

            #endregion

            #region R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "WS_QTD_ERRO_VANEA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3120_00_CONSULTA_ERRO_VANEA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V0PROP_NRCERTIF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3170_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "WS_STA_INCONCLUSIVO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_CONS_DPS_INCONCLUSIVO_DB_SELECT_1_Query1", q21);

            #endregion


            #endregion
        }

        [Fact]
        public static void VA0458B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VA0458B();
                program.Execute();

                Assert.True(true);
            }
        }
    }
}