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
using static Code.EM0910S;

namespace FileTests.Test
{
    [Collection("EM0910S_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0910S_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_ORGAO" , ""},
                { "V1ENDO_RAMO" , ""},
                { "V1ENDO_FONTE" , ""},
                { "V1ENDO_NRPROPOS" , ""},
                { "V1ENDO_MOEDA_PRM" , ""},
                { "V1ENDO_MOEDA_IMP" , ""},
                { "V1ENDO_TIPO_ENDO" , ""},
                { "V1ENDO_TIPAPO" , ""},
                { "V1ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q2);

            #endregion

            #region EM0910S_V1AUTOPROP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1AUPR_COD_EMPRESA" , ""},
                { "V1AUPR_FONTE" , ""},
                { "V1AUPR_NRPROPOS" , ""},
                { "V1AUPR_NRITEM" , ""},
                { "V1AUPR_DTINIVIG" , ""},
                { "V1AUPR_DTTERVIG" , ""},
                { "V1AUPR_TIPOVEIC" , ""},
                { "V1AUPR_FABRICAN" , ""},
                { "V1AUPR_CDVEICL" , ""},
                { "V1AUPR_COMBUST" , ""},
                { "V1AUPR_ANOVEICL" , ""},
                { "V1AUPR_ANOMOD" , ""},
                { "V1AUPR_CORVEICL" , ""},
                { "V1AUPR_CAPACID" , ""},
                { "V1AUPR_LOTACAO" , ""},
                { "V1AUPR_PLACAUF" , ""},
                { "V1AUPR_PLACALET" , ""},
                { "V1AUPR_PLACANR" , ""},
                { "V1AUPR_CHASSIS" , ""},
                { "V1AUPR_UTILIZA" , ""},
                { "V1AUPR_QTACESS" , ""},
                { "V1AUPR_DTBAIXA" , ""},
                { "V1AUPR_CDVISTOR" , ""},
                { "V1AUPR_PROPRIET" , ""},
                { "V1AUPR_DTIVEXTP" , ""},
                { "V1AUPR_ACEITE" , ""},
                { "V1AUPR_NRPRRESS" , ""},
                { "V1AUPR_PROTSINI" , ""},
                { "V1AUPR_SITUACAO" , ""},
                { "V1AUPR_CODCLIEN" , ""},
                { "V1AUPR_TPMOVTO" , ""},
                { "V1AUPR_ZEROKM" , ""},
                { "V1AUPR_SEGBONUS" , ""},
                { "V1AUPR_FIDEL_AUTO" , ""},
                { "V1AUPR_FIDEL_VIDA" , ""},
                { "V1AUPR_FIDEL_PREV" , ""},
                { "V1AUPR_DANOS_MORAIS" , ""},
                { "V1AUPR_SEG_MERC_DET" , ""},
                { "V1AUPR_ADIC_VLR_MERCADO" , ""},
                { "V1AUPR_PERFIL" , ""},
                { "V1AUPR_DESPEXTR" , ""},
                { "V1AUPR_VLNOVO" , ""},
                { "V1AUPR_CODDESPEXTR" , ""},
                { "V1AUPR_DESPEXTR_PT" , ""},
                { "V1AUPR_VARIA_IS" , ""},
                { "V1AUPR_CANAL_PROPOSTA" , ""},
                { "V1AUPR_TIPO_COBRANCA" , ""},
                { "V1AUPR_NUM_PROP_CNV" , ""},
                { "V1AUPR_NUM_CERTIF" , ""},
                { "V1AUPR_NUM_RENAVAM" , ""},
                { "V1AUPR_IND_USO_VEIC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0910S_V1AUTOPROP", q3);

            #endregion

            #region EM0910S_V1AUTARIPROP

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1TAPR_COD_EMPRESA" , ""},
                { "V1TAPR_FONTE" , ""},
                { "V1TAPR_NRPROPOS" , ""},
                { "V1TAPR_NRITEM" , ""},
                { "V1TAPR_DTINIVIG" , ""},
                { "V1TAPR_DTTERVIG" , ""},
                { "V1TAPR_TERCEIXO" , ""},
                { "V1TAPR_CATTARIF" , ""},
                { "V1TAPR_TIPOCOB" , ""},
                { "V1TAPR_REGIAO" , ""},
                { "V1TAPR_FRANQFAC" , ""},
                { "V1TAPR_CLABONAT" , ""},
                { "V1TAPR_PCDESCAT" , ""},
                { "V1TAPR_CLABONDM" , ""},
                { "V1TAPR_CLABONDP" , ""},
                { "V1TAPR_CATTARIR" , ""},
                { "V1TAPR_DESCFROT" , ""},
                { "V1TAPR_NUMPASSG" , ""},
                { "V1TAPR_VRFROBR_IX" , ""},
                { "V1TAPR_VRFRFACC_IX" , ""},
                { "V1TAPR_VRFRFACA_IX" , ""},
                { "V1TAPR_VRFRADIC_IX" , ""},
                { "V1TAPR_VRPRREF" , ""},
                { "V1TAPR_CFFROBR" , ""},
                { "V1TAPR_CFFRFACC" , ""},
                { "V1TAPR_CFFRFACA" , ""},
                { "V1TAPR_CFPRREF" , ""},
                { "V1TAPR_PCDSCFRF" , ""},
                { "V1TAPR_PCISCASC" , ""},
                { "V1TAPR_PCINCROU" , ""},
                { "V1TAPR_PCAGPLCA" , ""},
                { "V1TAPR_PCAGPLAC" , ""},
                { "V1TAPR_VRPRRFDM" , ""},
                { "V1TAPR_VRPRRFDP" , ""},
                { "V1TAPR_EXTPER" , ""},
                { "V1TAPR_PERIODO" , ""},
                { "V1TAPR_PCFRADIC" , ""},
                { "V1TAPR_PRAZOSEG" , ""},
                { "V1TAPR_DESCIDAD" , ""},
                { "V1TAPR_TCFAPLPR" , ""},
                { "V1TAPR_TPCDSFRF" , ""},
                { "V1TAPR_TPCDSBAU" , ""},
                { "V1TAPR_TTXAPLIS" , ""},
                { "V1TAPR_TPCPZSEG" , ""},
                { "V1TAPR_TPRBRCDM" , ""},
                { "V1TAPR_TCFPBRDM" , ""},
                { "V1TAPR_TPRBRCDP" , ""},
                { "V1TAPR_TCFPBRDP" , ""},
                { "V1TAPR_TPCBONDM" , ""},
                { "V1TAPR_TPCBONDP" , ""},
                { "V1TAPR_TTXAPPM" , ""},
                { "V1TAPR_TTXAPPI" , ""},
                { "V1TAPR_TTXAPPA" , ""},
                { "V1TAPR_TTXAPPD" , ""},
                { "V1TAPR_TPCDSAPP" , ""},
                { "V1TAPR_DATEND" , ""},
                { "V1TAPR_TPCMAJOR" , ""},
                { "V1TAPR_PCDESAUT" , ""},
                { "V1TAPR_PCDESRCF" , ""},
                { "V1TAPR_PCDESAPP" , ""},
                { "V1TAPR_PCDESPLCA" , ""},
                { "V1TAPR_PCDESPLRF" , ""},
                { "V1TAPR_PCDESPLAP" , ""},
                { "V1TAPR_PCAGPLRF" , ""},
                { "V1TAPR_PCAGPLAP" , ""},
                { "V1TAPR_PCDESACE" , ""},
                { "V1TAPR_PCAGISCASC" , ""},
                { "V1TAPR_VALOR_AVARIA" , ""},
                { "V1TAPR_TPCBONDMO" , ""},
                { "V1TAPR_TCFPBRDMO" , ""},
                { "V1TAPR_IND_COML" , ""},
                { "V1TAPR_PCT_COML" , ""},
                { "V1TAPR_CODUSU" , ""},
                { "V1TAPR_IND_VLR_MIN" , "" },
            });
            AppSettings.TestSet.DynamicData.Add("EM0910S_V1AUTARIPROP", q4);

            #endregion

            #region R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V0AUTO_COD_EMPRESA" , ""},
                { "V0AUTO_FONTE" , ""},
                { "V0AUTO_NRPROPOS" , ""},
                { "V0AUTO_NRITEM" , ""},
                { "V0AUTO_DTINIVIG" , ""},
                { "V0AUTO_DTTERVIG" , ""},
                { "V0AUTO_TIPOVEIC" , ""},
                { "V0AUTO_FABRICAN" , ""},
                { "V0AUTO_CDVEICL" , ""},
                { "V0AUTO_COMBUST" , ""},
                { "V0AUTO_ANOVEICL" , ""},
                { "V0AUTO_ANOMOD" , ""},
                { "V0AUTO_CORVEICL" , ""},
                { "V0AUTO_CAPACID" , ""},
                { "V0AUTO_LOTACAO" , ""},
                { "V0AUTO_PLACAUF" , ""},
                { "V0AUTO_PLACALET" , ""},
                { "V0AUTO_PLACANR" , ""},
                { "V0AUTO_CHASSIS" , ""},
                { "V0AUTO_UTILIZA" , ""},
                { "V0AUTO_QTACESS" , ""},
                { "V0AUTO_DTBAIXA" , ""},
                { "V0AUTO_CDVISTOR" , ""},
                { "V0AUTO_PROPRIET" , ""},
                { "V0AUTO_DTIVEXTP" , ""},
                { "V0AUTO_ACEITE" , ""},
                { "V0AUTO_NRPRRESS" , ""},
                { "V0AUTO_PROTSINI" , ""},
                { "V0AUTO_SITUACAO" , ""},
                { "V0AUTO_CODCLIEN" , ""},
                { "V0AUTO_NUM_APOL" , ""},
                { "V0AUTO_NRENDOS" , ""},
                { "V0AUTO_TPMOVTO" , ""},
                { "V0AUTO_ZEROKM" , ""},
                { "V0AUTO_SEGBONUS" , ""},
                { "V0AUTO_FIDEL_AUTO" , ""},
                { "V0AUTO_FIDEL_VIDA" , ""},
                { "V0AUTO_FIDEL_PREV" , ""},
                { "V0AUTO_DANOS_MORAIS" , ""},
                { "V0AUTO_SEG_MERC_DET" , ""},
                { "V0AUTO_ADIC_VLR_MERCADO" , ""},
                { "V0AUTO_PERFIL" , ""},
                { "V0AUTO_DESPEXTR" , ""},
                { "V0AUTO_VLNOVO" , ""},
                { "V0AUTO_CODDESPEXTR" , ""},
                { "V0AUTO_DESPEXTR_PT" , ""},
                { "V0AUTO_VARIA_IS" , ""},
                { "V0AUTO_CANAL_PROPOSTA" , ""},
                { "V0AUTO_TIPO_COBRANCA" , ""},
                { "V0AUTO_NUM_PROP_CONV" , ""},
                { "V0AUTO_NUM_CERTIF" , ""},
                { "V0AUTO_NUM_RENAVAM" , ""},
                { "V0AUTO_IND_USO_VEIC" , ""},
                { "WHOST_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1", q5);

            #endregion

            #region EM0910S_V1AUTCOBPROP

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V1AUCP_COD_EMPRESA" , ""},
                { "V1AUCP_FONTE" , ""},
                { "V1AUCP_NRPROPOS" , ""},
                { "V1AUCP_NRITEM" , ""},
                { "V1AUCP_RAMOFR" , ""},
                { "V1AUCP_MODALIFR" , ""},
                { "V1AUCP_COD_COBER" , ""},
                { "V1AUCP_DTINIVIG" , ""},
                { "V1AUCP_DTTERVIG" , ""},
                { "V1AUCP_IMP_SEG_IX" , ""},
                { "V1AUCP_IMP_SEG_VR" , ""},
                { "V1AUCP_TAXA_IS" , ""},
                { "V1AUCP_PRM_ANU_IX" , ""},
                { "V1AUCP_PRM_TAR_IX" , ""},
                { "V1AUCP_PRM_TAR_VR" , ""},
                { "V1AUCP_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0910S_V1AUTCOBPROP", q6);

            #endregion

            #region R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V0TARI_COD_EMPRESA" , ""},
                { "V0TARI_FONTE" , ""},
                { "V0TARI_NRPROPOS" , ""},
                { "V0TARI_NRITEM" , ""},
                { "V0TARI_DTINIVIG" , ""},
                { "V0TARI_DTTERVIG" , ""},
                { "V0TARI_TERCEIXO" , ""},
                { "V0TARI_CATTARIF" , ""},
                { "V0TARI_TIPOCOB" , ""},
                { "V0TARI_REGIAO" , ""},
                { "V0TARI_FRANQFAC" , ""},
                { "V0TARI_CLABONAT" , ""},
                { "V0TARI_PCDESCAT" , ""},
                { "V0TARI_CLABONDM" , ""},
                { "V0TARI_CLABONDP" , ""},
                { "V0TARI_CATTARIR" , ""},
                { "V0TARI_DESCFROT" , ""},
                { "V0TARI_NUMPASSG" , ""},
                { "V0TARI_VRFROBR_IX" , ""},
                { "V0TARI_VRFRFACC_IX" , ""},
                { "V0TARI_VRFRFACA_IX" , ""},
                { "V0TARI_VRFRADIC_IX" , ""},
                { "V0TARI_VRPRREF" , ""},
                { "V0TARI_CFFROBR" , ""},
                { "V0TARI_CFFRFACC" , ""},
                { "V0TARI_CFFRFACA" , ""},
                { "V0TARI_CFPRREF" , ""},
                { "V0TARI_PCDSCFRF" , ""},
                { "V0TARI_PCISCASC" , ""},
                { "V0TARI_PCINCROU" , ""},
                { "V0TARI_PCAGPLCA" , ""},
                { "V0TARI_PCAGPLAC" , ""},
                { "V0TARI_VRPRRFDM" , ""},
                { "V0TARI_VRPRRFDP" , ""},
                { "V0TARI_EXTPER" , ""},
                { "V0TARI_PERIODO" , ""},
                { "V0TARI_PCFRADIC" , ""},
                { "V0TARI_PRAZOSEG" , ""},
                { "V0TARI_DESCIDAD" , ""},
                { "V0TARI_TCFAPLPR" , ""},
                { "V0TARI_TPCDSFRF" , ""},
                { "V0TARI_TPCDSBAU" , ""},
                { "V0TARI_TTXAPLIS" , ""},
                { "V0TARI_TPCPZSEG" , ""},
                { "V0TARI_TPRBRCDM" , ""},
                { "V0TARI_TCFPBRDM" , ""},
                { "V0TARI_TPRBRCDP" , ""},
                { "V0TARI_TCFPBRDP" , ""},
                { "V0TARI_TPCBONDM" , ""},
                { "V0TARI_TPCBONDP" , ""},
                { "V0TARI_TTXAPPM" , ""},
                { "V0TARI_TTXAPPI" , ""},
                { "V0TARI_TTXAPPA" , ""},
                { "V0TARI_TTXAPPD" , ""},
                { "V0TARI_TPCDSAPP" , ""},
                { "V0TARI_DATEND" , ""},
                { "V0TARI_TPCMAJOR" , ""},
                { "V0TARI_PCDESAUT" , ""},
                { "V0TARI_PCDESRCF" , ""},
                { "V0TARI_PCDESAPP" , ""},
                { "V0TARI_PCDESPLCA" , ""},
                { "V0TARI_PCDESPLRF" , ""},
                { "V0TARI_PCDESPLAP" , ""},
                { "V0TARI_PCAGPLRF" , ""},
                { "V0TARI_PCAGPLAP" , ""},
                { "V0TARI_PCDESACE" , ""},
                { "V0TARI_NUM_APOL" , ""},
                { "V0TARI_NRENDOS" , ""},
                { "V0TARI_PCAGISCASC" , ""},
                { "V0TARI_VALOR_AVARIA" , ""},
                { "V0TARI_TPCBONDMO" , ""},
                { "V0TARI_TCFPBRDMO" , ""},
                { "V0TARI_IND_COML" , ""},
                { "V0TARI_PCT_COML" , ""},
                { "V0TARI_CODUSU" , ""},
                { "V0TARI_IND_VLR_MIN" , ""},
                { "WHOST_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1", q7);

            #endregion

            #region EM0910S_V1PROPACES

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V1PRAC_FONTE" , ""},
                { "V1PRAC_NRPROPOS" , ""},
                { "V1PRAC_NRITEM" , ""},
                { "V1PRAC_CDACESS" , ""},
                { "V1PRAC_VRACESS" , ""},
                { "V1PRAC_DTINIVIG" , ""},
                { "V1PRAC_DTTERVIG" , ""},
                { "V1PRAC_VRPLACES" , ""},
                { "V1PRAC_VRPAACES" , ""},
                { "V1PRAC_VRPLAACE" , ""},
                { "V1PRAC_VRPRBACE" , ""},
                { "V1PRAC_TPMOVTO" , ""},
                { "V1PRAC_TTXISACE" , ""},
                { "V1PRAC_IDEACESS" , "" },
            });
            AppSettings.TestSet.DynamicData.Add("EM0910S_V1PROPACES", q8);

            #endregion

            #region R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V0AUCB_COD_EMPRESA" , ""},
                { "V0AUCB_FONTE" , ""},
                { "V0AUCB_NRPROPOS" , ""},
                { "V0AUCB_NRITEM" , ""},
                { "V0AUCB_RAMOFR" , ""},
                { "V0AUCB_MODALIFR" , ""},
                { "V0AUCB_COD_COBER" , ""},
                { "V0AUCB_DTINIVIG" , ""},
                { "V0AUCB_DTTERVIG" , ""},
                { "V0AUCB_IMP_SEG_IX" , ""},
                { "V0AUCB_IMP_SEG_VR" , ""},
                { "V0AUCB_TAXA_IS" , ""},
                { "V0AUCB_PRM_ANU_IX" , ""},
                { "V0AUCB_PRM_TAR_IX" , ""},
                { "V0AUCB_PRM_TAR_VR" , ""},
                { "V0AUCB_SITUACAO" , ""},
                { "V0AUCB_NUM_APOL" , ""},
                { "V0AUCB_NRENDOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1", q9);

            #endregion

            #region EM0910S_V1PROPCLAU

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V1PRCL_FONTE" , ""},
                { "V1PRCL_NRPROPOS" , ""},
                { "V1PRCL_NRITEM" , ""},
                { "V1PRCL_CODCLAUS" , ""},
                { "V1PRCL_TIPOCLAU" , ""},
                { "V1PRCL_TPMOVTO" , ""},
                { "V1PRCL_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0910S_V1PROPCLAU", q10);

            #endregion

            #region R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V0APAC_NUM_APOL" , ""},
                { "V0APAC_NRITEM" , ""},
                { "V0APAC_NRENDOS" , ""},
                { "V0APAC_CDACESS" , ""},
                { "V0APAC_DTINIVIG" , ""},
                { "V0APAC_DTTERVIG" , ""},
                { "V0APAC_VRACESS" , ""},
                { "V0APAC_VRPLACES" , ""},
                { "V0APAC_VRPAACES" , ""},
                { "V0APAC_VRPLAACE" , ""},
                { "V0APAC_VRPRBACE" , ""},
                { "V0APAC_TTXISACE" , ""},
                { "V0APAC_TPMOVTO" , ""},
                { "V0APAC_OTNACE" , ""},
                { "V0APAC_PREACEBT" , ""},
                { "V0APAC_COD_EMPRESA" , ""},
                { "V0APAC_IDEACESS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1", q11);

            #endregion

            #region EM0910S_AUPROPCOMPL

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "AU085_COD_FONTE" , ""},
                { "AU085_NUM_PROPOSTA" , ""},
                { "AU085_NUM_ITEM" , ""},
                { "AU085_COD_PARCEIRO" , ""},
                { "AU085_COD_PONTO_VENDA" , ""},
                { "AU085_NUM_CPF_OPERADOR" , ""},
                { "AU085_STA_RENOVACAO_AUT" , ""},
                { "AU085_STA_ENVIO_SMS" , ""},
                { "AU085_STA_ENVIO_EMAIL" , ""},
                { "AU085_NUM_TOKEN_PGTO" , ""},
                { "AU085_IND_FORMA_PAGTO_AD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0910S_AUPROPCOMPL", q12);

            #endregion

            #region R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V0APCL_COD_EMPRESA" , ""},
                { "V0APCL_NUM_APOL" , ""},
                { "V0APCL_NRENDOS" , ""},
                { "V0APCL_RAMOFR" , ""},
                { "V0APCL_MODALIFR" , ""},
                { "V0APCL_COD_COBERT" , ""},
                { "V0APCL_DTINIVIG" , ""},
                { "V0APCL_DTTERVIG" , ""},
                { "V0APCL_NRITEM" , ""},
                { "V0APCL_CODCLAUS" , ""},
                { "V0APCL_TIPOCLAU" , ""},
                { "V0APCL_LIM_IND_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1", q13);

            #endregion

            #region EM0910S_V1COBERPROP

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V1COBP_FONTE" , ""},
                { "V1COBP_NRPROPOS" , ""},
                { "V1COBP_NUM_ITEM" , ""},
                { "V1COBP_RAMOFR" , ""},
                { "V1COBP_MODALIFR" , ""},
                { "V1COBP_COD_COBER" , ""},
                { "V1COBP_IMP_SEG_IX" , ""},
                { "V1COBP_IMP_SEG_VR" , ""},
                { "V1COBP_PRM_TAR_IX" , ""},
                { "V1COBP_PRM_TAR_VR" , ""},
                { "V1COBP_DAT_INIVIG" , ""},
                { "V1COBP_DAT_TERVIG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0910S_V1COBERPROP", q14);

            #endregion

            #region R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "AU084_NUM_APOLICE" , ""},
                { "AU084_NUM_ENDOSSO" , ""},
                { "AU084_NUM_ITEM" , ""},
                { "AU084_COD_PARCEIRO" , ""},
                { "AU084_COD_PONTO_VENDA" , ""},
                { "AU084_NUM_CPF_OPERADOR" , ""},
                { "AU084_STA_RENOVACAO_AUT" , ""},
                { "AU084_STA_ENVIO_SMS" , ""},
                { "AU084_STA_ENVIO_EMAIL" , ""},
                { "AU084_NUM_TOKEN_PGTO" , ""},
                { "AU084_IND_FORMA_PAGTO_AD" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V0EDIA_CODRELAT" , ""},
                { "V0EDIA_NUM_APOL" , ""},
                { "V0EDIA_NRENDOS" , ""},
                { "V0EDIA_NRPARCEL" , ""},
                { "V0EDIA_DTMOVTO" , ""},
                { "V0EDIA_ORGAO" , ""},
                { "V0EDIA_RAMO" , ""},
                { "V0EDIA_FONTE" , ""},
                { "V0EDIA_CONGENER" , ""},
                { "V0EDIA_CODCORR" , ""},
                { "V0EDIA_SITUACAO" , ""},
                { "V0EDIA_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1", q16);

            #endregion

            #region R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "W1COBP_PRM_TAR_VR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1", q17);

            #endregion

            #region R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_RAMOFR" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_COD_COBER" , ""},
                { "V0COBA_IMP_SEG_IX" , ""},
                { "V0COBA_PRM_TAR_IX" , ""},
                { "V0COBA_IMP_SEG_VR" , ""},
                { "V0COBA_PRM_TAR_VR" , ""},
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_FATOR_MULT" , ""},
                { "V0COBA_DATA_INIVI" , ""},
                { "V0COBA_DATA_TERVI" , ""},
                { "V0COBA_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1", q18);

            #endregion

            #region R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V0COBA_PCT_COBERT" , ""},
                { "V0COBA_NUM_APOL" , ""},
                { "V0COBA_NUM_ITEM" , ""},
                { "V0COBA_OCORHIST" , ""},
                { "V0COBA_MODALIFR" , ""},
                { "V0COBA_NRENDOS" , ""},
                { "V0COBA_RAMOFR" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1", q19);

            #endregion

            #region R7010_00_INCLUI_AU055_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "AU055_SEQ_HISTORICO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R7010_00_INCLUI_AU055_DB_SELECT_1_Query1", q20);

            #endregion

            #region R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "AU055_NUM_PROPOSTA_VC" , ""},
                { "AU055_SEQ_HISTORICO" , ""},
                { "AU055_NOM_PROGRAMA" , ""},
                { "AU055_DTH_OPERACAO" , ""},
                { "AU055_IND_OPERACAO" , ""},
                { "AU055_DTH_MOVTO_ARQUIVO" , ""},
                { "AU055_NUM_ARQUIVO" , ""},
                { "AU055_STA_ERRO" , ""},
                { "AU055_COD_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R7010_00_INCLUI_AU055_DB_SELECT_2_Query1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "AU055_NUM_ARQUIVO" , ""},
                { "AU055_DTH_MOVTO_ARQUIVO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7010_00_INCLUI_AU055_DB_SELECT_2_Query1", q22);

            #endregion

            #region R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "AU057_COD_TIPO_ENDOSSO" , ""},
                { "AU057_IND_OPERACAO" , ""},
                { "AU057_NUM_PROPOSTA" , ""},
                { "AU057_NUM_APOLICE" , ""},
                { "AU057_NUM_ENDOSSO" , ""},
                { "AU057_COD_FONTE" , ""},
                { "AU057_NUM_PROPOSTA_VC" , ""},
                { "AU057_COD_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1", q23);

            #endregion

            #region R7030_00_SELECT_AU055_DB_SELECT_1_Query1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "AU055_DTH_OPERACAO" , ""},
                { "AU055_NUM_ARQUIVO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7030_00_SELECT_AU055_DB_SELECT_1_Query1", q24);

            #endregion

            #region R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "AU050_NUM_APOLICE" , ""},
                { "AU050_NUM_ENDOSSO" , ""},
                { "AU050_NUM_PARCELA" , ""},
                { "AU050_SEQ_HISTORICO" , ""},
                { "AU050_OCORR_HISTORICO" , ""},
                { "AU050_COD_OPERACAO" , ""},
                { "AU050_VLR_PARCELA" , ""},
                { "AU050_DTH_MOVIMENTO" , ""},
                { "AU050_NUM_ARQUIVO" , ""},
                { "AU050_COD_CONGENERE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1", q25);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0910S_Tests_Fact_Process_ReturnCode_0()
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
                #region param
                var param = new EM0910S_LK_PROPOSTA();
                param.LK_CODPRODU.Value = 100;
                param.LK_FONTE.Value = 1;
                param.LK_NRPROPOS.Value = 1;
                param.LK_NUM_APOL.Value = 1;
                param.LK_NRENDOS.Value = 1;
                param.LK_DTMOVABE.Value = "2024-01-01";
                param.LK_CODCORR.Value = 1;
                param.LK_QT_PARCEL.Value = 1;
                param.LK_VL_PARCEL.Value = 120;
                #endregion
                #region R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "V0SIST_DTMOVABE" , "2024-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0900_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1ENDO_ORGAO" , "10"},
                { "V1ENDO_RAMO" , "68"},
                { "V1ENDO_FONTE" , "10"},
                { "V1ENDO_NRPROPOS" , "790324"},
                { "V1ENDO_MOEDA_PRM" , "1"},
                { "V1ENDO_MOEDA_IMP" , "1"},
                { "V1ENDO_TIPO_ENDO" , "0"},
                { "V1ENDO_TIPAPO" , "4"},
                { "V1ENDO_CODPRODU" , "6800"},
                });
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q1);

                #endregion

                #region R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
                });
                q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
                });
                AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q2);

                #endregion

                #region EM0910S_V1AUTOPROP

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "V1AUPR_COD_EMPRESA" , "0"},
                { "V1AUPR_FONTE" , "1"},
                { "V1AUPR_NRPROPOS" , "871"},
                { "V1AUPR_NRITEM" , "101"},
                { "V1AUPR_DTINIVIG" , "1996-10-21"},
                { "V1AUPR_DTTERVIG" , "1997-10-21"},
                { "V1AUPR_TIPOVEIC" , "1"},
                { "V1AUPR_FABRICAN" , "4"},
                { "V1AUPR_CDVEICL" , "40712"},
                { "V1AUPR_COMBUST" , "G"},
                { "V1AUPR_ANOVEICL" , "1992"},
                { "V1AUPR_ANOMOD" , "1992"},
                { "V1AUPR_CORVEICL" , "0"},
                { "V1AUPR_CAPACID" , "5"},
                { "V1AUPR_LOTACAO" , "P"},
                { "V1AUPR_PLACAUF" , "RJ"},
                { "V1AUPR_PLACALET" , "UG "},
                { "V1AUPR_PLACANR" , "9927"},
                { "V1AUPR_CHASSIS" , "9BWZZZ30ZNT119618   "},
                { "V1AUPR_UTILIZA" , "P"},
                { "V1AUPR_QTACESS" , "0"},
                { "V1AUPR_DTBAIXA" , "1996-12-26"},
                { "V1AUPR_CDVISTOR" , "0"},
                { "V1AUPR_PROPRIET" , "WASHINGTON JOSE DE ALMEIDA ARANHA       "},
                { "V1AUPR_DTIVEXTP" , "1996-10-21"},
                { "V1AUPR_ACEITE" , "0"},
                { "V1AUPR_NRPRRESS" , "0"},
                { "V1AUPR_PROTSINI" , "0"},
                { "V1AUPR_SITUACAO" , " "},
                { "V1AUPR_CODCLIEN" , "1062029"},
                { "V1AUPR_TPMOVTO" , "1"},
                { "V1AUPR_ZEROKM" , "N"},
                { "V1AUPR_SEGBONUS" , "5631"},
                { "V1AUPR_FIDEL_AUTO" , "N"},
                { "V1AUPR_FIDEL_VIDA" , "N"},
                { "V1AUPR_FIDEL_PREV" , "N"},
                { "V1AUPR_DANOS_MORAIS" , "N"},
                { "V1AUPR_SEG_MERC_DET" , "S"},
                { "V1AUPR_ADIC_VLR_MERCADO" , "N"},
                { "V1AUPR_PERFIL" , "N"},
                { "V1AUPR_DESPEXTR" , "N"},
                { "V1AUPR_VLNOVO" , "N"},
                { "V1AUPR_CODDESPEXTR" , "0"},
                { "V1AUPR_DESPEXTR_PT" , "N"},
                { "V1AUPR_VARIA_IS" , "0.00"},
                { "V1AUPR_CANAL_PROPOSTA" , "0"},
                { "V1AUPR_TIPO_COBRANCA" , "0"},
                { "V1AUPR_NUM_PROP_CNV" , "0"},
                { "V1AUPR_NUM_CERTIF" , "0"},
                { "V1AUPR_NUM_RENAVAM" , "0"},
                { "V1AUPR_IND_USO_VEIC" , "99"},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0910S_V1AUTOPROP");
                AppSettings.TestSet.DynamicData.Add("EM0910S_V1AUTOPROP", q3);

                #endregion

                #region EM0910S_V1AUTARIPROP

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "V1TAPR_COD_EMPRESA" , "0"},
                { "V1TAPR_FONTE" , "1"},
                { "V1TAPR_NRPROPOS" , "871"},
                { "V1TAPR_NRITEM" , "101"},
                { "V1TAPR_DTINIVIG" , "1996-10-21"},
                { "V1TAPR_DTTERVIG" , "1997-10-21"},
                { "V1TAPR_TERCEIXO" , "N"},
                { "V1TAPR_CATTARIF" , "10"},
                { "V1TAPR_TIPOCOB" , "1"},
                { "V1TAPR_REGIAO" , "19"},
                { "V1TAPR_FRANQFAC" , "1  "},
                { "V1TAPR_CLABONAT" , "4"},
                { "V1TAPR_PCDESCAT" , "0.00"},
                { "V1TAPR_CLABONDM" , "0"},
                { "V1TAPR_CLABONDP" , "0"},
                { "V1TAPR_CATTARIR" , "10"},
                { "V1TAPR_DESCFROT" , "0.00"},
                { "V1TAPR_NUMPASSG" , "5"},
                { "V1TAPR_VRFROBR_IX" , "770.00"},
                { "V1TAPR_VRFRFACC_IX" , "0.00"},
                { "V1TAPR_VRFRFACA_IX" , "0.00"},
                { "V1TAPR_VRFRADIC_IX" , "0.00"},
                { "V1TAPR_VRPRREF" , "0.00"},
                { "V1TAPR_CFFROBR" , "1.00"},
                { "V1TAPR_CFFRFACC" , "0.00"},
                { "V1TAPR_CFFRFACA" , "0.00"},
                { "V1TAPR_CFPRREF" , "0.000"},
                { "V1TAPR_PCDSCFRF" , "0.00"},
                { "V1TAPR_PCISCASC" , "10.92"},
                { "V1TAPR_PCINCROU" , "0.00"},
                { "V1TAPR_PCAGPLCA" , "0.00"},
                { "V1TAPR_PCAGPLAC" , "0.00"},
                { "V1TAPR_VRPRRFDM" , "0.00"},
                { "V1TAPR_VRPRRFDP" , "0.00"},
                { "V1TAPR_EXTPER" , " "},
                { "V1TAPR_PERIODO" , "0"},
                { "V1TAPR_PCFRADIC" , "0.00"},
                { "V1TAPR_PRAZOSEG" , "365"},
                { "V1TAPR_DESCIDAD" , " "},
                { "V1TAPR_TCFAPLPR" , "0.000"},
                { "V1TAPR_TPCDSFRF" , "1.00"},
                { "V1TAPR_TPCDSBAU" , "25.00"},
                { "V1TAPR_TTXAPLIS" , "10.92"},
                { "V1TAPR_TPCPZSEG" , "0.00"},
                { "V1TAPR_TPRBRCDM" , "115.90"},
                { "V1TAPR_TCFPBRDM" , "1.37"},
                { "V1TAPR_TPRBRCDP" , "23.95"},
                { "V1TAPR_TCFPBRDP" , "2.61"},
                { "V1TAPR_TPCBONDM" , "25.00"},
                { "V1TAPR_TPCBONDP" , "25.00"},
                { "V1TAPR_TTXAPPM" , "0.10"},
                { "V1TAPR_TTXAPPI" , "0.10"},
                { "V1TAPR_TTXAPPA" , "0.00"},
                { "V1TAPR_TTXAPPD" , "0.00"},
                { "V1TAPR_TPCDSAPP" , "0.00"},
                { "V1TAPR_DATEND" , "9999-12-31"},
                { "V1TAPR_TPCMAJOR" , "0.0000"},
                { "V1TAPR_PCDESAUT" , "33.50"},
                { "V1TAPR_PCDESRCF" , "33.50"},
                { "V1TAPR_PCDESAPP" , "33.50"},
                { "V1TAPR_PCDESPLCA" , "0.00"},
                { "V1TAPR_PCDESPLRF" , "0.00"},
                { "V1TAPR_PCDESPLAP" , "0.00"},
                { "V1TAPR_PCAGPLRF" , "0.00"},
                { "V1TAPR_PCAGPLAP" , "0.00"},
                { "V1TAPR_PCDESACE" , "0.00"},
                { "V1TAPR_PCAGISCASC" , "0.00"},
                { "V1TAPR_VALOR_AVARIA" , "0.00"},
                { "V1TAPR_TPCBONDMO" , "0.00"},
                { "V1TAPR_TCFPBRDMO" , "0.00"},
                { "V1TAPR_IND_COML" , " "},
                { "V1TAPR_PCT_COML" , "0.00"},
                { "V1TAPR_CODUSU" , "        "},
                { "V1TAPR_IND_VLR_MIN" , "S" },
                });
                AppSettings.TestSet.DynamicData.Remove("EM0910S_V1AUTARIPROP");
                AppSettings.TestSet.DynamicData.Add("EM0910S_V1AUTARIPROP", q4);
                #endregion
                #region EM0910S_V1PROPACES

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "V1PRAC_FONTE" , "1"},
                { "V1PRAC_NRPROPOS" , "1378"},
                { "V1PRAC_NRITEM" , "401"},
                { "V1PRAC_CDACESS" , "2"},
                { "V1PRAC_VRACESS" , "2500.00"},
                { "V1PRAC_DTINIVIG" , "1996-07-31"},
                { "V1PRAC_DTTERVIG" , "1997-07-31"},
                { "V1PRAC_VRPLACES" , "900.00"},
                { "V1PRAC_VRPAACES" , "900.00"},
                { "V1PRAC_VRPLAACE" , "0.00"},
                { "V1PRAC_VRPRBACE" , "250.00"},
                { "V1PRAC_TPMOVTO" , "1"},
                { "V1PRAC_TTXISACE" , "0.00"},
                { "V1PRAC_IDEACESS" , "C" },
                });
                AppSettings.TestSet.DynamicData.Remove("EM0910S_V1PROPACES");
                AppSettings.TestSet.DynamicData.Add("EM0910S_V1PROPACES", q8);

                #endregion
                #region EM0910S_V1PROPCLAU

                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                { "V1PRCL_FONTE" , "1"},
                { "V1PRCL_NRPROPOS" , "871"},
                { "V1PRCL_NRITEM" , "1"},
                { "V1PRCL_CODCLAUS" , "001"},
                { "V1PRCL_TIPOCLAU" , "2"},
                { "V1PRCL_TPMOVTO" , "2"},
                { "V1PRCL_COD_EMPRESA" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0910S_V1PROPCLAU");
                AppSettings.TestSet.DynamicData.Add("EM0910S_V1PROPCLAU", q10);

                #endregion
                #region EM0910S_AUPROPCOMPL

                var q12 = new DynamicData();
                q12.AddDynamic(new Dictionary<string, string>{
                { "AU085_COD_FONTE" , "1"},
                { "AU085_NUM_PROPOSTA" , "100790324"},
                { "AU085_NUM_ITEM" , "1"},
                { "AU085_COD_PARCEIRO" , "0"},
                { "AU085_COD_PONTO_VENDA" , "0"},
                { "AU085_NUM_CPF_OPERADOR" , ""},
                { "AU085_STA_RENOVACAO_AUT" , ""},
                { "AU085_STA_ENVIO_SMS" , ""},
                { "AU085_STA_ENVIO_EMAIL" , ""},
                { "AU085_NUM_TOKEN_PGTO" , ""},
                { "AU085_IND_FORMA_PAGTO_AD" , "0"},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0910S_AUPROPCOMPL");
                AppSettings.TestSet.DynamicData.Add("EM0910S_AUPROPCOMPL", q12);

                #endregion
                #region EM0910S_V1COBERPROP

                var q14 = new DynamicData();
                q14.AddDynamic(new Dictionary<string, string>{
                { "V1COBP_FONTE" , "1"},
                { "V1COBP_NRPROPOS" , "871"},
                { "V1COBP_NUM_ITEM" , "1"},
                { "V1COBP_RAMOFR" , "31"},
                { "V1COBP_MODALIFR" , "0"},
                { "V1COBP_COD_COBER" , "3101"},
                { "V1COBP_IMP_SEG_IX" , "7300.00"},
                { "V1COBP_IMP_SEG_VR" , "7300.00"},
                { "V1COBP_PRM_TAR_IX" , "397.00"},
                { "V1COBP_PRM_TAR_VR" , "397.00"},
                { "V1COBP_DAT_INIVIG" , "2000-01-01"},
                { "V1COBP_DAT_TERVIG" , "2000-01-01"},
                });
                q14.AddDynamic(new Dictionary<string, string>{
                { "V1COBP_FONTE" , "2"},
                { "V1COBP_NRPROPOS" , "872"},
                { "V1COBP_NUM_ITEM" , "2"},
                { "V1COBP_RAMOFR" , "32"},
                { "V1COBP_MODALIFR" , "0"},
                { "V1COBP_COD_COBER" , "3101"},
                { "V1COBP_IMP_SEG_IX" , "7300.00"},
                { "V1COBP_IMP_SEG_VR" , "7300.00"},
                { "V1COBP_PRM_TAR_IX" , "397.00"},
                { "V1COBP_PRM_TAR_VR" , "397.00"},
                { "V1COBP_DAT_INIVIG" , "2000-01-01"},
                { "V1COBP_DAT_TERVIG" , "2000-01-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("EM0910S_V1COBERPROP");
                AppSettings.TestSet.DynamicData.Add("EM0910S_V1COBERPROP", q14);

                #endregion
                #region R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1

                var q17 = new DynamicData();
                q17.AddDynamic(new Dictionary<string, string>{
                { "W1COBP_PRM_TAR_VR" , "10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R4100_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1", q17);

                #endregion
                #endregion
                var program = new EM0910S();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 0);

                //R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1
                var envList0 = AppSettings.TestSet.DynamicData["R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("V0AUTO_PROPRIET", out var valor0) && valor0.Contains("WASHINGTON JOSE DE ALMEIDA ARANHA       "));
                Assert.True(envList0.Count > 1);

                //R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("V0TARI_NRPROPOS", out var valor1) && valor1.Contains("000000001"));
                Assert.True(envList1.Count > 1);

                //R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("V0AUCB_FONTE", out var valor2) && valor2.Contains("0001"));
                Assert.True(envList2.Count > 1);

                //R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1
                var envList3 = AppSettings.TestSet.DynamicData["R2410_00_INCLUI_V0APOLACES_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("V0APAC_DTINIVIG", out var valor3) && valor3.Contains("1996-07-31"));
                Assert.True(envList3.Count > 1);

                //R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1
                var envList4 = AppSettings.TestSet.DynamicData["R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("V0APCL_DTTERVIG", out var valor4) && valor4.Contains("1997-10-21"));
                Assert.True(envList4.Count > 1);

                //R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1
                var envList5 = AppSettings.TestSet.DynamicData["R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("AU084_NUM_APOLICE", out var valor5) && valor5.Contains("0000000000001"));
                Assert.True(envList5.Count > 1);

                //R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1
                var envList6 = AppSettings.TestSet.DynamicData["R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList6[1].TryGetValue("V0EDIA_RAMO", out var valor6) && valor6.Contains("0068"));
                Assert.True(envList6.Count > 1);

                //R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1
                var envList7 = AppSettings.TestSet.DynamicData["R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList7[1].TryGetValue("V0COBA_RAMOFR", out var valor7) && valor7.Contains("0031"));
                Assert.True(envList7.Count > 1);

                //R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1
                var envList8 = AppSettings.TestSet.DynamicData["R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList8[1].TryGetValue("V0COBA_RAMOFR", out var valor8) && valor8.Contains("0031"));

                //R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1
                var envList9 = AppSettings.TestSet.DynamicData["R7010_00_INCLUI_AU055_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList9[1].TryGetValue("AU055_COD_CONGENERE", out var valor9) && valor9.Contains("5631"));
                Assert.True(envList9.Count > 1);

                //R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1
                var envList10 = AppSettings.TestSet.DynamicData["R7020_00_UPDATE_AU057_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList10[1].TryGetValue("AU057_NUM_PROPOSTA", out var valor10) && valor10.Contains("000790324"));

                //R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1
                var envList11 = AppSettings.TestSet.DynamicData["R7040_00_INCLUI_AU050_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList11[1].TryGetValue("AU050_VLR_PARCELA", out var valor11) && valor11.Contains("0000000000120.00"));
                Assert.True(envList11.Count > 1);
            }
        }
        [Fact]
        public static void EM0910S_Tests_Fact_Produto_99()
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
                #region param
                var param = new EM0910S_LK_PROPOSTA();
                param.LK_CODPRODU.Value = 99;
                param.LK_FONTE.Value = 1;
                param.LK_NRPROPOS.Value = 1;
                param.LK_NUM_APOL.Value = 1;
                param.LK_NRENDOS.Value = 1;
                param.LK_DTMOVABE.Value = "2024-01-01";
                param.LK_CODCORR.Value = 1;
                param.LK_QT_PARCEL.Value = 1;
                param.LK_VL_PARCEL.Value = 120;
                #endregion
                #endregion
                var program = new EM0910S();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 0);
                Assert.True(program.LK_PROPOSTA.LK_CODPRODU.Value == 99);
            }
        }
        [Fact]
        public static void EM0910S_Tests_Fact_SemMov_ReturnCode_99()
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
                #region param
                var param = new EM0910S_LK_PROPOSTA();
                param.LK_CODPRODU.Value = 100;
                param.LK_FONTE.Value = 1;
                param.LK_NRPROPOS.Value = 1;
                param.LK_NUM_APOL.Value = 1;
                param.LK_NRENDOS.Value = 1;
                param.LK_DTMOVABE.Value = "2024-01-01";
                param.LK_CODCORR.Value = 1;
                param.LK_QT_PARCEL.Value = 1;
                param.LK_VL_PARCEL.Value = 120;
                #endregion

                #region R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new EM0910S();
                program.Execute(param);

                Assert.True(program.RETURN_CODE == 99);
                Assert.True(q1.DynamicList.Count == 0);
            }
        }

        public static void Load_Parameters_To_FactEM0005B()
        {
            Load_Parameters();

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "WHOST_VLCRUZAD" , "1"}
            });
            AppSettings.TestSet.DynamicData.Remove("R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1");
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1MOEDA_DB_SELECT_1_Query1", q2);
        }
    }
}
