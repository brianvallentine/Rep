using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VA3118B;

namespace FileTests.Test
{
    [Collection("VA3118B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA3118B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMA_DTMOVABE" , ""},
                { "SISTEMA_CURRDATE" , ""},
                { "SISTEMA_DTMOVABE2" , ""},
                { "SISTEMA_DTMOVABE3" , ""},
                { "SISTEMA_DTMOVABE_15" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA3118B_CPROPVA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "PROPVA_NUM_APOLICE" , ""},
                { "PROPVA_CODSUBES" , ""},
                { "PROPVA_NRCERTIF" , ""},
                { "PROPVA_CODPRODU" , ""},
                { "PROPVA_CODCLIEN" , ""},
                { "PROPVA_OCOREND" , ""},
                { "PROPVA_FONTE" , ""},
                { "PROPVA_AGECOBR" , ""},
                { "PROPVA_OPCAO_COBER" , ""},
                { "PROPVA_DTQITBCO" , ""},
                { "PROPVA_DTINICDG" , ""},
                { "PROPVA_DTINISAF" , ""},
                { "PROPVA_DTPROXVEN" , ""},
                { "PROPVA_DTMINVEN" , ""},
                { "PROPVA_NRMATRVEN" , ""},
                { "PROPVA_CODOPER" , ""},
                { "PROPVA_DTMOVTO" , ""},
                { "PROPVA_SITUACAO" , ""},
                { "PROPVA_OCORHIST" , ""},
                { "PROPVA_NRPARCEL" , ""},
                { "PROPVA_SIT_INTERF" , ""},
                { "PROPVA_TIMESTAMP" , ""},
                { "PROPVA_IDADE" , ""},
                { "PROPVA_SEXO" , ""},
                { "PROPVA_EST_CIV" , ""},
                { "PROPVA_COD_CRM" , ""},
                { "PROPVA_NRMATRFUN" , ""},
                { "PROPVA_DTADMIS" , ""},
                { "PROPVA_NRPROPOS" , ""},
                { "PROPVA_CODCCT" , ""},
                { "PROPVA_CODUSU" , ""},
                { "PROPVA_DTVENCTO" , ""},
                { "PROPVA_FAIXA_RENDA_IND" , ""},
                { "PROPVA_DATA" , ""},
                { "PROPVA_DPS_TITULAR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA3118B_CPROPVA", q1);

            #endregion

            #region VA3118B_CURSOR01

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA3118B_CURSOR01", q2);

            #endregion

            #region VA3118B_CURSOR02

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_ERRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("VA3118B_CURSOR02", q3);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "COBERP_IMPMORNATU" , ""},
                { "COBERP_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1", q4);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_ERRO_COMUN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1", q5);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_ERRO_COMUN" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1", q6);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1", q7);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "COBERP_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1", q8);

            #endregion

            #region M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>
            {
            });
            AppSettings.TestSet.DynamicData.Add("M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1", q9);

            #endregion

            #endregion
        }

        [Fact]
        public static void VA3118B_Tests_Fact()
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
                var program = new VA3118B();
                program.Execute();

                Assert.True(program.RETURN_CODE == 0);
            }
        }
    }
}