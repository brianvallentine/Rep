using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.SI0045B;
using System.IO;

namespace FileTests.Test
{
    [Collection("SI0045B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0045B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region SI0045B_JOIN_1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_COD_FONTE" , ""},
                { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                { "SISINACO_NUM_OCORR_SINIACO" , ""},
                { "SISINACO_COD_EVENTO" , ""},
                { "SISINACO_DATA_MOVTO_SINIACO" , ""},
                { "WHOST_DIFERENCA_DIAS" , ""},
                { "SISINACO_COD_USUARIO" , ""},
                { "HOST_NUM_CARTA" , ""},
                { "GECARTA_SEQ_CARTA_REITERA" , ""},
                { "GECARTA_NUM_CARTA_REITERA" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0045B_JOIN_1", q1);

            #endregion

            #region SI0045B_LEITURA_FASES

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SIREFAEV_COD_FASE" , ""},
                { "SIREFAEV_DATA_INIVIG_REFAEV" , ""},
                { "SIREFAEV_IND_ALTERACAO_FASE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("SI0045B_LEITURA_FASES", q2);

            #endregion

            #region R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COD_FASE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1502_00_LEITURA_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "WHOST_CARTA_REITERA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1502_00_LEITURA_DB_SELECT_1_Query1", q5);

            #endregion

            #region R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_TIPO_REGISTRO" , ""},
                { "SINISMES_COD_FONTE" , ""},
                { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                { "SINISMES_DAC_PROTOCOLO_SINI" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
                { "SINISMES_NUM_APOLICE" , ""},
                { "SINISMES_NUM_ENDOSSO" , ""},
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SINISMES_DATA_COMUNICADO" , ""},
                { "SINISMES_DATA_OCORRENCIA" , ""},
                { "SINISMES_DATA_TECNICA" , ""},
                { "SINISMES_COD_CAUSA" , ""},
                { "SINISMES_NUM_IRB" , ""},
                { "SINISMES_NUM_AVISO_IRB" , ""},
                { "SINISMES_NUM_MOV_SINI_ATU" , ""},
                { "SINISMES_NUM_MOV_SINI_ANT" , ""},
                { "SINISMES_DATA_ULT_MOVIMENTO" , ""},
                { "SINISMES_SIT_REGISTRO" , ""},
                { "SINISMES_RAMO" , ""},
                { "SINISMES_COD_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1", q6);

            #endregion

            #region R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_HORA_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
                { "HOST_MES_OPERACAO_AVISO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1", q7);

            #endregion

            #region R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_EMPRESA" , ""},
                { "SINISHIS_TIPO_REGISTRO" , ""},
                { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                { "SINISHIS_OCORR_HISTORICO" , ""},
                { "SINISHIS_COD_OPERACAO" , ""},
                { "SINISHIS_DATA_MOVIMENTO" , ""},
                { "SINISHIS_HORA_OPERACAO" , ""},
                { "SINISHIS_NOME_FAVORECIDO" , ""},
                { "SINISHIS_VAL_OPERACAO" , ""},
                { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                { "SINISHIS_TIPO_FAVORECIDO" , ""},
                { "SINISHIS_DATA_NEGOCIADA" , ""},
                { "SINISHIS_FONTE_PAGAMENTO" , ""},
                { "SINISHIS_COD_PREST_SERVICO" , ""},
                { "SINISHIS_COD_SERVICO" , ""},
                { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                { "SINISHIS_NUM_RECIBO" , ""},
                { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                { "SINISHIS_COD_USUARIO" , ""},
                { "SINISHIS_SIT_CONTABIL" , ""},
                { "SINISHIS_SIT_REGISTRO" , ""},
                { "SINISHIS_NUM_APOLICE" , ""},
                { "SINISHIS_COD_PRODUTO" , ""},
                { "SINISHIS_NOM_PROGRAMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1", q8);

            #endregion

            #region R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                { "SIMOVSIN_COD_PRODUTO" , ""},
                { "SIMOVSIN_NUM_CONTR_ESTIP" , ""},
                { "SIMOVSIN_NOME_SEGURADO" , ""},
                { "SIMOVSIN_COD_ASHAB" , ""},
                { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                { "SIMOVSIN_RAMO_EMISSOR" , ""},
                { "SIMOVSIN_COD_CAUSA" , ""},
                { "SIMOVSIN_DATA_COMUNICADO" , ""},
                { "SIMOVSIN_COD_GIAFI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1", q9);

            #endregion

            #region R2810_00_MAX_SISINACO_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "SISINACO_NUM_OCORR_SINIACO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2810_00_MAX_SISINACO_DB_SELECT_1_Query1", q10);

            #endregion

            #region R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SIHISACO_COD_FONTE" , ""},
                { "SIHISACO_NUM_PROTOCOLO_SINI" , ""},
                { "SIHISACO_DAC_PROTOCOLO_SINI" , ""},
                { "SIHISACO_NUM_OCORR_SINIACO" , ""},
                { "SIHISACO_NUM_APOL_SINISTRO" , ""},
                { "SIHISACO_COD_OPERACAO" , ""},
                { "SIHISACO_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_OCORR_HISTORICO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SINISMES_NUM_APOL_SINISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1", q13);

            #endregion

            #region R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_APOL_SINISTRO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1", q14);

            #endregion

            #region R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SINISCON_COD_FONTE" , ""},
                { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                { "SINISCON_NUM_APOLICE" , ""},
                { "SINISCON_COD_SUBGRUPO" , ""},
                { "SINISCON_OCORR_HISTORICO" , ""},
                { "SINISCON_PEND_VISTORIA" , ""},
                { "SINISCON_PEND_RESSEGURO" , ""},
                { "SINISCON_SIT_REGISTRO" , ""},
                { "SINISCON_PEND_VIST_COMPL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "SINISACO_COD_FONTE" , ""},
                { "SINISACO_NUM_PROTOCOLO_SINI" , ""},
                { "SINISACO_DAC_PROTOCOLO_SINI" , ""},
                { "SINISACO_COD_OPERACAO" , ""},
                { "SINISACO_DATA_OPERACAO" , ""},
                { "SINISACO_HORA_OPERACAO" , ""},
                { "SINISACO_OCORR_HISTORICO" , ""},
                { "SINISACO_COD_USUARIO" , ""},
                { "SINISACO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "SINISCON_OCORR_HISTORICO" , ""},
                { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                { "SINISCON_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1", q17);

            #endregion

            #region R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SIHISACM_COD_FONTE" , ""},
                { "SIHISACM_NUM_PROTOCOLO_SINI" , ""},
                { "SIHISACM_DAC_PROTOCOLO_SINI" , ""},
                { "SIHISACM_OCORR_HISTORICO" , ""},
                { "SIHISACM_NUM_APOL_SINISTRO" , ""},
                { "SIHISACM_OCORR_HIST" , ""},
                { "SIHISACM_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_COD_USUARIO" , ""},
                { "USUARIOS_COD_FONTE" , ""},
                { "USUARIOS_NUM_CENTRO_CUSTO" , ""},
                { "USUARIOS_NUM_MATRICULA" , ""},
                { "USUARIOS_NOME_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1", q19);

            #endregion

            #region R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "GEDESTIN_COD_FILIAL" , ""},
                { "GEDESTIN_NOME_DESTINATARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1", q20);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("SI0045B_OUTPUT_202504100000")]
        public static void SI0045B_Tests_Theory(string RSI0045B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1001S_Tests.Load_Parameters();
                SI0502S_Tests.Load_Parameters2();
                PTACOMOS_Tests.Load_Parameters();
                PTFASESS_Tests.Load_Parameters();


                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2020-02-02"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0045B_JOIN_1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISINACO_COD_FONTE" , "1"},
                    { "SISINACO_NUM_PROTOCOLO_SINI" , "1"},
                    { "SISINACO_DAC_PROTOCOLO_SINI" , "2020-02-02"},
                    { "SISINACO_NUM_OCORR_SINIACO" , ""},
                    { "SISINACO_COD_EVENTO" , ""},
                    { "SISINACO_DATA_MOVTO_SINIACO" , "2020-02-02"},
                    { "WHOST_DIFERENCA_DIAS" , ""},
                    { "SISINACO_COD_USUARIO" , ""},
                    { "HOST_NUM_CARTA" , ""},
                    { "GECARTA_SEQ_CARTA_REITERA" , ""},
                    { "GECARTA_NUM_CARTA_REITERA" , "2"},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("SI0045B_JOIN_1");
                AppSettings.TestSet.DynamicData.Add("SI0045B_JOIN_1", q1);

                #endregion

                #region SI0045B_LEITURA_FASES

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SIREFAEV_COD_FASE" , "1"},
                    { "SIREFAEV_DATA_INIVIG_REFAEV" , "2020-02-02"},
                    { "SIREFAEV_IND_ALTERACAO_FASE" , "2"},
                });
                //}, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("SI0045B_LEITURA_FASES");
                AppSettings.TestSet.DynamicData.Add("SI0045B_LEITURA_FASES", q2);

                #endregion

                #region R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                //q3.AddDynamic(new Dictionary<string, string>{
                //    { "SINISHIS_NUM_APOL_SINISTRO" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_COD_FASE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1502_00_LEITURA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_CARTA_REITERA" , "1"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_CARTA_REITERA" , "1"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_CARTA_REITERA" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1502_00_LEITURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1502_00_LEITURA_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISMES_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_ENDOSSO" , ""},
                    { "SINISMES_OCORR_HISTORICO" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_DATA_TECNICA" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_NUM_IRB" , ""},
                    { "SINISMES_NUM_AVISO_IRB" , ""},
                    { "SINISMES_NUM_MOV_SINI_ATU" , ""},
                    { "SINISMES_NUM_MOV_SINI_ANT" , ""},
                    { "SINISMES_DATA_ULT_MOVIMENTO" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_EMPRESA" , ""},
                    { "SINISHIS_TIPO_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "SINISHIS_HORA_OPERACAO" , ""},
                    { "SINISHIS_NOME_FAVORECIDO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                    { "SINISHIS_TIPO_FAVORECIDO" , ""},
                    { "SINISHIS_DATA_NEGOCIADA" , ""},
                    { "SINISHIS_FONTE_PAGAMENTO" , ""},
                    { "SINISHIS_COD_PREST_SERVICO" , ""},
                    { "SINISHIS_COD_SERVICO" , ""},
                    { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                    { "SINISHIS_NUM_RECIBO" , ""},
                    { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                    { "SINISHIS_COD_USUARIO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_SIT_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOLICE" , ""},
                    { "SINISHIS_COD_PRODUTO" , ""},
                    { "SINISHIS_NOM_PROGRAMA" , ""},
                    { "HOST_MES_OPERACAO_AVISO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_EMPRESA" , ""},
                    { "SINISHIS_TIPO_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "SINISHIS_HORA_OPERACAO" , ""},
                    { "SINISHIS_NOME_FAVORECIDO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                    { "SINISHIS_TIPO_FAVORECIDO" , ""},
                    { "SINISHIS_DATA_NEGOCIADA" , ""},
                    { "SINISHIS_FONTE_PAGAMENTO" , ""},
                    { "SINISHIS_COD_PREST_SERVICO" , ""},
                    { "SINISHIS_COD_SERVICO" , ""},
                    { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                    { "SINISHIS_NUM_RECIBO" , ""},
                    { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                    { "SINISHIS_COD_USUARIO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_SIT_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOLICE" , ""},
                    { "SINISHIS_COD_PRODUTO" , ""},
                    { "SINISHIS_NOM_PROGRAMA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIMOVSIN_COD_PRODUTO" , ""},
                    { "SIMOVSIN_NUM_CONTR_ESTIP" , ""},
                    { "SIMOVSIN_NOME_SEGURADO" , ""},
                    { "SIMOVSIN_COD_ASHAB" , ""},
                    { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                    { "SIMOVSIN_RAMO_EMISSOR" , ""},
                    { "SIMOVSIN_COD_CAUSA" , ""},
                    { "SIMOVSIN_DATA_COMUNICADO" , ""},
                    { "SIMOVSIN_COD_GIAFI" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2810_00_MAX_SISINACO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SISINACO_NUM_OCORR_SINIACO" , "2"}
                });
                AppSettings.TestSet.DynamicData.Remove("R2810_00_MAX_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2810_00_MAX_SISINACO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "SIHISACO_COD_FONTE" , ""},
                    { "SIHISACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SIHISACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SIHISACO_NUM_OCORR_SINIACO" , ""},
                    { "SIHISACO_NUM_APOL_SINISTRO" , ""},
                    { "SIHISACO_COD_OPERACAO" , ""},
                    { "SIHISACO_OCORR_HISTORICO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_OCORR_HISTORICO" , ""},
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "SINISCON_COD_FONTE" , ""},
                    { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISCON_NUM_APOLICE" , ""},
                    { "SINISCON_COD_SUBGRUPO" , ""},
                    { "SINISCON_OCORR_HISTORICO" , ""},
                    { "SINISCON_PEND_VISTORIA" , ""},
                    { "SINISCON_PEND_RESSEGURO" , ""},
                    { "SINISCON_SIT_REGISTRO" , ""},
                    { "SINISCON_PEND_VIST_COMPL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "SINISACO_COD_FONTE" , ""},
                    { "SINISACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISACO_COD_OPERACAO" , ""},
                    { "SINISACO_DATA_OPERACAO" , ""},
                    { "SINISACO_HORA_OPERACAO" , ""},
                    { "SINISACO_OCORR_HISTORICO" , ""},
                    { "SINISACO_COD_USUARIO" , ""},
                    { "SINISACO_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1", q16);

                #endregion

                #region R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "SINISCON_OCORR_HISTORICO" , ""},
                    { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISCON_COD_FONTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "SIHISACM_COD_FONTE" , ""},
                    { "SIHISACM_NUM_PROTOCOLO_SINI" , ""},
                    { "SIHISACM_DAC_PROTOCOLO_SINI" , ""},
                    { "SIHISACM_OCORR_HISTORICO" , ""},
                    { "SIHISACM_NUM_APOL_SINISTRO" , ""},
                    { "SIHISACM_OCORR_HIST" , ""},
                    { "SIHISACM_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_COD_USUARIO" , ""},
                    { "USUARIOS_COD_FONTE" , ""},
                    { "USUARIOS_NUM_CENTRO_CUSTO" , ""},
                    { "USUARIOS_NUM_MATRICULA" , ""},
                    { "USUARIOS_NOME_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1", q19);

                #endregion

                #region R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "GEDESTIN_COD_FILIAL" , ""},
                    { "GEDESTIN_NOME_DESTINATARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                #endregion
                var program = new SI0045B();
                program.Execute(RSI0045B_FILE_NAME_P);

                Assert.True(File.Exists(program.RSI0045B.FilePath));
                Assert.True(new FileInfo(program.RSI0045B.FilePath).Length > 0);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();

                Assert.True(selects.Count >= allSelects.Count / 2);
                Assert.True(inserts.Count >= allInserts.Count / 2);
                Assert.True(updates.Count >= allUpdates.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("SI0045B_OUTPUT_202504100001")]
        public static void SI0045B_Tests_Theory_ReturnCode99(string RSI0045B_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                SI1001S_Tests.Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region PARAMETERS
                #region R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1", q0);

                #endregion

                #region SI0045B_JOIN_1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "SISINACO_COD_FONTE" , ""},
                    { "SISINACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SISINACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SISINACO_NUM_OCORR_SINIACO" , ""},
                    { "SISINACO_COD_EVENTO" , ""},
                    { "SISINACO_DATA_MOVTO_SINIACO" , ""},
                    { "WHOST_DIFERENCA_DIAS" , ""},
                    { "SISINACO_COD_USUARIO" , ""},
                    { "HOST_NUM_CARTA" , ""},
                    { "GECARTA_SEQ_CARTA_REITERA" , ""},
                    { "GECARTA_NUM_CARTA_REITERA" , "2"},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_COD_PRODUTO" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0045B_JOIN_1");
                AppSettings.TestSet.DynamicData.Add("SI0045B_JOIN_1", q1);

                #endregion

                #region SI0045B_LEITURA_FASES

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                    { "SIREFAEV_COD_FASE" , ""},
                    { "SIREFAEV_DATA_INIVIG_REFAEV" , ""},
                    { "SIREFAEV_IND_ALTERACAO_FASE" , ""},
                }, new SQLCA(99));
                AppSettings.TestSet.DynamicData.Remove("SI0045B_LEITURA_FASES");
                AppSettings.TestSet.DynamicData.Add("SI0045B_LEITURA_FASES", q2);

                #endregion

                #region R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1

                var q3 = new DynamicData();
                //q3.AddDynamic(new Dictionary<string, string>{
                //    { "SINISHIS_NUM_APOL_SINISTRO" , ""}
                //});
                AppSettings.TestSet.DynamicData.Remove("R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1", q3);

                #endregion

                #region R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_COD_FASE" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1501_00_SINISTRO_ENCERRADO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R1502_00_LEITURA_DB_SELECT_1_Query1

                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_CARTA_REITERA" , "1"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_CARTA_REITERA" , "1"}
                });
                q5.AddDynamic(new Dictionary<string, string>{
                    { "WHOST_CARTA_REITERA" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1502_00_LEITURA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1502_00_LEITURA_DB_SELECT_1_Query1", q5);

                #endregion

                #region R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_TIPO_REGISTRO" , ""},
                    { "SINISMES_COD_FONTE" , ""},
                    { "SINISMES_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISMES_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                    { "SINISMES_NUM_APOLICE" , ""},
                    { "SINISMES_NUM_ENDOSSO" , ""},
                    { "SINISMES_OCORR_HISTORICO" , ""},
                    { "SINISMES_DATA_COMUNICADO" , ""},
                    { "SINISMES_DATA_OCORRENCIA" , ""},
                    { "SINISMES_DATA_TECNICA" , ""},
                    { "SINISMES_COD_CAUSA" , ""},
                    { "SINISMES_NUM_IRB" , ""},
                    { "SINISMES_NUM_AVISO_IRB" , ""},
                    { "SINISMES_NUM_MOV_SINI_ATU" , ""},
                    { "SINISMES_NUM_MOV_SINI_ANT" , ""},
                    { "SINISMES_DATA_ULT_MOVIMENTO" , ""},
                    { "SINISMES_SIT_REGISTRO" , ""},
                    { "SINISMES_RAMO" , ""},
                    { "SINISMES_COD_PRODUTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2100_00_ACESSA_SINI_MESTRE_DB_SELECT_1_Query1", q6);

                #endregion

                #region R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1

                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_EMPRESA" , ""},
                    { "SINISHIS_TIPO_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "SINISHIS_HORA_OPERACAO" , ""},
                    { "SINISHIS_NOME_FAVORECIDO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                    { "SINISHIS_TIPO_FAVORECIDO" , ""},
                    { "SINISHIS_DATA_NEGOCIADA" , ""},
                    { "SINISHIS_FONTE_PAGAMENTO" , ""},
                    { "SINISHIS_COD_PREST_SERVICO" , ""},
                    { "SINISHIS_COD_SERVICO" , ""},
                    { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                    { "SINISHIS_NUM_RECIBO" , ""},
                    { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                    { "SINISHIS_COD_USUARIO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_SIT_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOLICE" , ""},
                    { "SINISHIS_COD_PRODUTO" , ""},
                    { "SINISHIS_NOM_PROGRAMA" , ""},
                    { "HOST_MES_OPERACAO_AVISO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_ACESSA_SINI_HISTOR_DB_SELECT_1_Query1", q7);

                #endregion

                #region R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "SINISHIS_COD_EMPRESA" , ""},
                    { "SINISHIS_TIPO_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOL_SINISTRO" , ""},
                    { "SINISHIS_OCORR_HISTORICO" , ""},
                    { "SINISHIS_COD_OPERACAO" , ""},
                    { "SINISHIS_DATA_MOVIMENTO" , ""},
                    { "SINISHIS_HORA_OPERACAO" , ""},
                    { "SINISHIS_NOME_FAVORECIDO" , ""},
                    { "SINISHIS_VAL_OPERACAO" , ""},
                    { "SINISHIS_DATA_LIM_CORRECAO" , ""},
                    { "SINISHIS_TIPO_FAVORECIDO" , ""},
                    { "SINISHIS_DATA_NEGOCIADA" , ""},
                    { "SINISHIS_FONTE_PAGAMENTO" , ""},
                    { "SINISHIS_COD_PREST_SERVICO" , ""},
                    { "SINISHIS_COD_SERVICO" , ""},
                    { "SINISHIS_ORDEM_PAGAMENTO" , ""},
                    { "SINISHIS_NUM_RECIBO" , ""},
                    { "SINISHIS_NUM_MOV_SINISTRO" , ""},
                    { "SINISHIS_COD_USUARIO" , ""},
                    { "SINISHIS_SIT_CONTABIL" , ""},
                    { "SINISHIS_SIT_REGISTRO" , ""},
                    { "SINISHIS_NUM_APOLICE" , ""},
                    { "SINISHIS_COD_PRODUTO" , ""},
                    { "SINISHIS_NOM_PROGRAMA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R2500_00_INSERE_SINI_HISTOR_DB_INSERT_1_Insert1", q8);

                #endregion

                #region R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1

                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "SIMOVSIN_COD_ESTIPULANTE" , ""},
                    { "SIMOVSIN_COD_PRODUTO" , ""},
                    { "SIMOVSIN_NUM_CONTR_ESTIP" , ""},
                    { "SIMOVSIN_NOME_SEGURADO" , ""},
                    { "SIMOVSIN_COD_ASHAB" , ""},
                    { "SIMOVSIN_NATUREZA_SINISTRO" , ""},
                    { "SIMOVSIN_RAMO_EMISSOR" , ""},
                    { "SIMOVSIN_COD_CAUSA" , ""},
                    { "SIMOVSIN_DATA_COMUNICADO" , ""},
                    { "SIMOVSIN_COD_GIAFI" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1", q9);

                #endregion

                #region R2810_00_MAX_SISINACO_DB_SELECT_1_Query1

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                    { "SISINACO_NUM_OCORR_SINIACO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R2810_00_MAX_SISINACO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2810_00_MAX_SISINACO_DB_SELECT_1_Query1", q10);

                #endregion

                #region R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1

                var q11 = new DynamicData();
                q11.AddDynamic(new Dictionary<string, string>{
                    { "SIHISACO_COD_FONTE" , ""},
                    { "SIHISACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SIHISACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SIHISACO_NUM_OCORR_SINIACO" , ""},
                    { "SIHISACO_NUM_APOL_SINISTRO" , ""},
                    { "SIHISACO_COD_OPERACAO" , ""},
                    { "SIHISACO_OCORR_HISTORICO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3000_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1", q11);

                #endregion

                #region R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_OCORR_HISTORICO" , ""},
                    { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"},
                });
                AppSettings.TestSet.DynamicData.Remove("R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1", q12);

                #endregion

                #region R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1

                var q13 = new DynamicData();
                q13.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1", q13);

                #endregion

                #region R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                    { "SINISMES_NUM_APOL_SINISTRO" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3300_00_ATUALI_SINI_HABIT1_DB_UPDATE_1_Update1", q14);

                #endregion

                #region R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1

                var q15 = new DynamicData();
                q15.AddDynamic(new Dictionary<string, string>{
                    { "SINISCON_COD_FONTE" , ""},
                    { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISCON_NUM_APOLICE" , ""},
                    { "SINISCON_COD_SUBGRUPO" , ""},
                    { "SINISCON_OCORR_HISTORICO" , ""},
                    { "SINISCON_PEND_VISTORIA" , ""},
                    { "SINISCON_PEND_RESSEGURO" , ""},
                    { "SINISCON_SIT_REGISTRO" , ""},
                    { "SINISCON_PEND_VIST_COMPL" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1

                var q16 = new DynamicData();
                q16.AddDynamic(new Dictionary<string, string>{
                    { "SINISACO_COD_FONTE" , ""},
                    { "SINISACO_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISACO_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISACO_COD_OPERACAO" , ""},
                    { "SINISACO_DATA_OPERACAO" , ""},
                    { "SINISACO_HORA_OPERACAO" , ""},
                    { "SINISACO_OCORR_HISTORICO" , ""},
                    { "SINISACO_COD_USUARIO" , ""},
                    { "SINISACO_COD_EMPRESA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3500_00_INSERE_SINI_ACOMPA_DB_INSERT_1_Insert1", q16);

                #endregion

                #region R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                    { "SINISCON_OCORR_HISTORICO" , ""},
                    { "SINISCON_NUM_PROTOCOLO_SINI" , ""},
                    { "SINISCON_DAC_PROTOCOLO_SINI" , ""},
                    { "SINISCON_COD_FONTE" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R3600_00_ATUALI_SINI_CONTRO_DB_UPDATE_1_Update1", q17);

                #endregion

                #region R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1

                var q18 = new DynamicData();
                q18.AddDynamic(new Dictionary<string, string>{
                    { "SIHISACM_COD_FONTE" , ""},
                    { "SIHISACM_NUM_PROTOCOLO_SINI" , ""},
                    { "SIHISACM_DAC_PROTOCOLO_SINI" , ""},
                    { "SIHISACM_OCORR_HISTORICO" , ""},
                    { "SIHISACM_NUM_APOL_SINISTRO" , ""},
                    { "SIHISACM_OCORR_HIST" , ""},
                    { "SIHISACM_COD_OPERACAO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R3700_00_INSERE_HIST_ACOMP_DB_INSERT_1_Insert1", q18);

                #endregion

                #region R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1

                var q19 = new DynamicData();
                q19.AddDynamic(new Dictionary<string, string>{
                    { "USUARIOS_COD_USUARIO" , ""},
                    { "USUARIOS_COD_FONTE" , ""},
                    { "USUARIOS_NUM_CENTRO_CUSTO" , ""},
                    { "USUARIOS_NUM_MATRICULA" , ""},
                    { "USUARIOS_NOME_USUARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4200_00_ACESSA_USUARIOS_DB_SELECT_1_Query1", q19);

                #endregion

                #region R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                    { "GEDESTIN_COD_FILIAL" , ""},
                    { "GEDESTIN_NOME_DESTINATARIO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4300_00_ACESSA_GIPRO_GITER_DB_SELECT_1_Query1", q20);

                #endregion

                #endregion
                #endregion
                var program = new SI0045B();
                program.Execute(RSI0045B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}