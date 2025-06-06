using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0095B;

namespace FileTests.Test
{
    [Collection("VG0095B_Tests")]
    //programa desativado
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    //[Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG0095B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region M_0000_PRINCIPAL_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2024-10-30"}
            });
            AppSettings.TestSet.DynamicData.Add("M_0000_PRINCIPAL_DB_SELECT_1_Query1", q0);

            #endregion

            #region VG0095B_TMOVIMENTO

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "MNUM_APOLICE" , ""},
                { "MCOD_SUBGRUPO" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
                { "MNUM_CERTIFICADO" , ""},
                { "MDAC_CERTIFICADO" , ""},
                { "MTIPO_INCLUSAO" , ""},
                { "MCOD_CLIENTE" , ""},
                { "MCOD_AGENCIADOR" , ""},
                { "MCOD_CORRETOR" , ""},
                { "MCOD_PLANOVGAP" , ""},
                { "MCOD_PLANOAP" , ""},
                { "MFAIXA" , ""},
                { "MAUTOR_AUM_AUTOMAT" , ""},
                { "MTIPO_BENEFICIARIO" , ""},
                { "MPERI_PAGAMENTO" , ""},
                { "MPERI_RENOVACAO" , ""},
                { "MCOD_OCUPACAO" , ""},
                { "MESTADO_CIVIL" , ""},
                { "MIDE_SEXO" , ""},
                { "MCOD_PROFISSAO" , ""},
                { "MNATURALIDADE" , ""},
                { "MOCORR_ENDERECO" , ""},
                { "MOCORR_END_COBRAN" , ""},
                { "MBCO_COBRANCA" , ""},
                { "MAGE_COBRANCA" , ""},
                { "MDAC_COBRANCA" , ""},
                { "MNUM_MATRICULA" , ""},
                { "MNUM_CTA_CORRENTE" , ""},
                { "MDAC_CTA_CORRENTE" , ""},
                { "MVAL_SALARIO" , ""},
                { "MTIPO_SALARIO" , ""},
                { "MTIPO_PLANO" , ""},
                { "MPCT_CONJUGE_VG" , ""},
                { "MPCT_CONJUGE_AP" , ""},
                { "MQTD_SAL_MORNATU" , ""},
                { "MQTD_SAL_MORACID" , ""},
                { "MQTD_SAL_INVPERM" , ""},
                { "MTAXA_AP_MORACID" , ""},
                { "MTAXA_AP_INVPERM" , ""},
                { "MTAXA_AP_AMDS" , ""},
                { "MTAXA_AP_DH" , ""},
                { "MTAXA_AP_DIT" , ""},
                { "MTAXA_VG" , ""},
                { "MIMP_MORNATU_ANT" , ""},
                { "MIMP_MORNATU_ATU" , ""},
                { "MIMP_MORACID_ANT" , ""},
                { "MIMP_MORACID_ATU" , ""},
                { "MIMP_INVPERM_ANT" , ""},
                { "MIMP_INVPERM_ATU" , ""},
                { "MIMP_AMDS_ANT" , ""},
                { "MIMP_AMDS_ATU" , ""},
                { "MIMP_DH_ANT" , ""},
                { "MIMP_DH_ATU" , ""},
                { "MIMP_DIT_ANT" , ""},
                { "MIMP_DIT_ATU" , ""},
                { "MPRM_VG_ANT" , ""},
                { "MPRM_VG_ATU" , ""},
                { "MPRM_AP_ANT" , ""},
                { "MPRM_AP_ATU" , ""},
                { "MCOD_OPERACAO" , ""},
                { "MDATA_OPERACAO" , ""},
                { "COD_SUBGRUPO_TRANS" , ""},
                { "MSIT_REGISTRO" , ""},
                { "MCOD_USUARIO" , ""},
                { "MDATA_AVERBACAO" , ""},
                { "MDATA_ADMISSAO" , ""},
                { "MDATA_INCLUSAO" , ""},
                { "MDATA_NASCIMENTO" , ""},
                { "MDATA_FATURA" , ""},
                { "MDATA_REFERENCIA" , ""},
                { "MDATA_MOVIMENTO" , ""},
                { "MCOD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VG0095B_TMOVIMENTO", q1);

            #endregion

            #region R0010_10_LEITURA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V0SEG_FONTE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_10_LEITURA_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0010_10_LEITURA_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPAUTOM" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_10_LEITURA_DB_SELECT_2_Query1", q3);

            #endregion

            #region R0010_10_LEITURA_DB_UPDATE_1_Update1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPAUTOM" , ""},
                { "V0SEG_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0010_10_LEITURA_DB_UPDATE_1_Update1", q4);

            #endregion

            #region R0020_10_UPDATE_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0SEG_FONTE" , ""},
                { "PROPAUTOM" , ""},
                { "MCOD_FONTE" , ""},
                { "MNUM_PROPOSTA" , ""},
                { "MTIPO_SEGURADO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_10_UPDATE_DB_UPDATE_1_Update1", q5);

            #endregion

            #endregion
        }

        [Fact]
        public static void VG0095B_Tests_Fact()
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new VG0095B();
                program.Execute();

                var envList0 = AppSettings.TestSet.DynamicData["R0010_10_LEITURA_DB_UPDATE_1_Update1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R0020_10_UPDATE_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList0.Count > 1);
                Assert.True(envList1.Count > 1);

                Assert.True(envList0[1].TryGetValue("PROPAUTOM", out var PROPAUTOM) && PROPAUTOM == "000000001");
                Assert.True(envList1[1].TryGetValue("PROPAUTOM", out PROPAUTOM) && PROPAUTOM == "000000001");
            }
        }
    }
}