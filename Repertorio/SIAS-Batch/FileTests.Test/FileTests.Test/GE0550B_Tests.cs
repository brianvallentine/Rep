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
using static Code.GE0550B;

namespace FileTests.Test
{
    [Collection("GE0550B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0550B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region Execute_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
            });
            //AppSettings.TestSet.DynamicData.Add("Execute_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0300_00_SELECT_OD001_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "OD001_NUM_DV_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_SELECT_OD001_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0310_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0315_00_SELECT_GE354_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "GE354_DES_EVENTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0315_00_SELECT_GE354_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "ADPROGRA_DTH_INCLUSAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_SELECT_ADPROGRA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ADPROGRA_NOM_PROGRAMA" , ""},
                { "ADPROGRA_DTH_INCLUSAO" , ""},
                { "ADPROGRA_DTH_COMPILACAO" , ""},
                { "ADPROGRA_IND_PROGRAMA" , ""},
                { "ADPROGRA_STA_DCLGEN" , ""},
                { "ADPROGRA_STA_AMBIENTE" , ""},
                { "ADPROGRA_DES_PROGRAMA" , ""},
                { "ADPROGRA_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1", q5);

            #endregion

            #region R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_FONTE" , ""},
                { "USUARIOS_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0420_00_SELECT_FONTES_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "FONTES_NOME_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0420_00_SELECT_FONTES_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0900_00_SELECT_GE366_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "GE366_NUM_OCORR_MOVTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_GE366_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0910_00_INSERT_GE366_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "GE366_NUM_OCORR_MOVTO" , ""},
                { "GE366_COD_EVENTO" , ""},
                { "GE366_IDE_SISTEMA" , ""},
                { "GE366_DTH_MOVIMENTO" , ""},
                { "GE366_IND_ESTRUTURA" , ""},
                { "GE366_IND_ORIGEM_FUNC" , ""},
                { "GE366_IND_EVENTO" , ""},
                { "GE366_NOM_PROGRAMA" , ""},
                { "GE366_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0910_00_INSERT_GE366_DB_INSERT_1_Insert1", q9);

            #endregion

            #region R0920_00_INSERT_GE367_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "GE367_NUM_PESSOA" , ""},
                { "GE367_NUM_OCORR_MOVTO" , ""},
                { "GE367_IND_RELACIONAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0920_00_INSERT_GE367_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R0930_00_INSERT_GE368_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "GE368_NUM_PESSOA" , ""},
                { "GE368_NUM_OCORR_MOVTO" , ""},
                { "GE368_SEQ_ENTIDADE" , ""},
                { "GE368_IND_ENTIDADE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0930_00_INSERT_GE368_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "CB039_NUM_OCORR_MOVTO" , ""},
                { "CB039_NUM_APOLICE" , ""},
                { "CB039_NUM_ENDOSSO" , ""},
                { "CB039_NUM_PARCELA" , ""},
                { "CB039_DATA_MOVIMENTO" , ""},
                { "CB039_HORA_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1_Insert1", q12);

            #endregion

            #region R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "CB040_NUM_OCORR_MOVTO" , ""},
                { "CB040_COD_FONTE" , ""},
                { "CB040_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "CB041_NUM_OCORR_MOVTO" , ""},
                { "CB041_NUM_APOLICE" , ""},
                { "CB041_NUM_ENDOSSO" , ""},
                { "CB041_NUM_PARCELA" , ""},
                { "CB041_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SI175_NUM_OCORR_MOVTO" , ""},
                { "SI175_NUM_APOL_SINISTRO" , ""},
                { "SI175_OCORR_HISTORICO" , ""},
                { "SI175_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "VG079_NUM_OCORR_MOVTO" , ""},
                { "VG079_NUM_CERTIFICADO" , ""},
                { "VG079_NUM_PARCELA" , ""},
                { "VG079_NUM_TITULO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1_Insert1", q16);

            #endregion

            #endregion
        }

        [Fact]
        public static void GE0550B_Tests_Fact()
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
                var program = new GE0550B();
                program.Execute(new GE0550B_PARAMETROS());

                Assert.True(true);
            }
        }
    }
}