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
using static Code.EM0006B;
using Sias.Emissao.DB2.EM0006B;

namespace FileTests.Test
{
    [Collection("EM0006B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0006B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Fact's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "V1SIST_DTMOVABE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region EM0006B_V1PROPOSTA

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_TPPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_RAMO" , ""},
                { "V1PROP_MODALIDA" , ""},
                { "V1PROP_NUM_APO_ANT" , ""},
                { "V1PROP_TIPAPO" , ""},
                { "V1PROP_CODCLIEN" , ""},
                { "V1PROP_DTINIVIG" , ""},
                { "V1PROP_DTTERVIG" , ""},
                { "V1PROP_PODPUBL" , ""},
                { "V1PROP_CORRECAO" , ""},
                { "V1PROP_MOEDA_IMP" , ""},
                { "V1PROP_MOEDA_PRM" , ""},
                { "V1PROP_PRESTA1" , ""},
                { "V1PROP_BCORCAP" , ""},
                { "V1PROP_AGERCAP" , ""},
                { "V1PROP_NRRCAP" , ""},
                { "V1PROP_VLRCAP" , ""},
                { "V1PROP_CDFRACIO" , ""},
                { "V1PROP_QTPARCEL" , ""},
                { "V1PROP_PCENTRAD" , ""},
                { "V1PROP_PCADICIO" , ""},
                { "V1PROP_IDIOF" , ""},
                { "V1PROP_ISENTA_CST" , ""},
                { "V1PROP_QTPRESTA" , ""},
                { "V1PROP_BCOCOBR" , ""},
                { "V1PROP_AGECOBR" , ""},
                { "V1PROP_TPCORRET" , ""},
                { "V1PROP_NRAUTCOR" , ""},
                { "V1PROP_QTCORR" , ""},
                { "V1PROP_QTCORRC" , ""},
                { "V1PROP_NUM_APO_MAN" , ""},
                { "V1PROP_TPCOSCED" , ""},
                { "V1PROP_QTCOSSGC" , ""},
                { "V1PROP_QTCOSSEG" , ""},
                { "V1PROP_QTITENSI" , ""},
                { "V1PROP_QTITENS" , ""},
                { "V1PROP_TPMOVTO" , ""},
                { "V1PROP_DTENTRAD" , ""},
                { "V1PROP_DTCADAST" , ""},
                { "V1PROP_TIPCALC" , ""},
                { "V1PROP_LIMIND" , ""},
                { "V1PROP_CDACEITA" , ""},
                { "V1PROP_NRAUTACE" , ""},
                { "V1PROP_PCDESCON" , ""},
                { "V1PROP_IDRCAP" , ""},
                { "V1PROP_CODTXT" , ""},
                { "V1PROP_NUM_RENOV" , ""},
                { "V1PROP_CONV_COBR" , ""},
                { "V1PROP_OCORR_END" , ""},
                { "V1PROP_SITUACAO" , ""},
                { "V1PROP_COD_USUAR" , ""},
                { "V1PROP_NUM_ATA" , ""},
                { "V1PROP_ANO_ATA" , ""},
                { "V1PROP_DATA_SORT" , ""},
                { "V1PROP_DTLIBER" , ""},
                { "V1PROP_DTAPOLM" , ""},
                { "V1PROP_DATARCAP" , ""},
                { "V1PROP_COD_EMPRESA" , ""},
                { "V1PROP_TIMESTAMP" , ""},
                { "V1PROP_TIPO_ENDO" , ""},
                { "V1PROP_NUM_APOLICE" , ""},
                { "V1PROP_INSPETOR" , ""},
                { "V1PROP_CANALPROD" , ""},
                { "V1PROP_CODPRODU" , ""},
                { "V1PROP_DTVENCTO" , ""},
                { "V1PROP_CFPREFIX" , ""},
                { "V1PROP_VLCUSEMI" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPOSTA", q1);

            #endregion

            #region EM0006B_V1PROPCORRET

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "V1PCOR_FONTE" , ""},
                { "V1PCOR_NRPROPOS" , ""},
                { "V1PCOR_RAMOFR" , ""},
                { "V1PCOR_MODALIFR" , ""},
                { "V1PCOR_CODCORR" , ""},
                { "V1PCOR_PCPARCOR" , ""},
                { "V1PCOR_PCCOMCOR" , ""},
                { "V1PCOR_INDCRT" , ""},
                { "V1PCOR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPCORRET", q2);

            #endregion

            #region R1100_00_SELECT_V1FONTE_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "V1FONT_ORGAOEMIS" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_V1FONTE_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "V1RAMO_PCIOF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1", q4);

            #endregion

            #region EM0006B_V1PROPCOSCED

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "V1PCOS_FONTE" , ""},
                { "V1PCOS_NRPROPOS" , ""},
                { "V1PCOS_CODCOSS" , ""},
                { "V1PCOS_RAMOFR" , ""},
                { "V1PCOS_PCPARTIC" , ""},
                { "V1PCOS_PCCOMCOS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPCOSCED", q5);

            #endregion

            #region R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "V0ACOR_NUM_APOL" , ""},
                { "V0ACOR_RAMOFR" , ""},
                { "V0ACOR_MODALIFR" , ""},
                { "V0ACOR_CODCORR" , ""},
                { "V0ACOR_CODSUBES" , ""},
                { "V0ACOR_DTINIVIG" , ""},
                { "V0ACOR_DTTERVIG" , ""},
                { "V0ACOR_PCPARCOR" , ""},
                { "V0ACOR_PCCOMCOR" , ""},
                { "V0ACOR_TIPCOM" , ""},
                { "V0ACOR_INDCRT" , ""},
                { "V0ACOR_COD_EMPRESA" , ""},
                { "V0ACOR_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1", q6);

            #endregion

            #region EM0006B_V1PROPLOCINC

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "V1PRLI_NUM_RISCO" , ""},
                { "V1PRLI_COD_LOCAL" , ""},
                { "V1PRLI_QTITENS" , ""},
                { "V1PRLI_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPLOCINC", q7);

            #endregion

            #region R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "V0ACOS_NUM_APOL" , ""},
                { "V0ACOS_CODCOSS" , ""},
                { "V0ACOS_RAMOFR" , ""},
                { "V0ACOS_DTINIVIG" , ""},
                { "V0ACOS_DTTERVIG" , ""},
                { "V0ACOS_PCPARTIC" , ""},
                { "V0ACOS_PCCOMCOS" , ""},
                { "V0ACOS_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1", q8);

            #endregion

            #region EM0006B_V1PROPINC

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "V1PRIN_COD_EMPRESA" , ""},
                { "V1PRIN_FONTE" , ""},
                { "V1PRIN_NRPROPOS" , ""},
                { "V1PRIN_NUM_RISCO" , ""},
                { "V1PRIN_CODCOBINC" , ""},
                { "V1PRIN_SUBRIS" , ""},
                { "V1PRIN_NRITEM" , ""},
                { "V1PRIN_COD_PLANTA" , ""},
                { "V1PRIN_COD_RUBRICA" , ""},
                { "V1PRIN_CLASOCUPA" , ""},
                { "V1PRIN_CLASCONST" , ""},
                { "V1PRIN_DTINIVIG" , ""},
                { "V1PRIN_DTTERVIG" , ""},
                { "V1PRIN_IMP_SEG_IX" , ""},
                { "V1PRIN_PRM_TAR_IX" , ""},
                { "V1PRIN_TIPCOND" , ""},
                { "V1PRIN_TAXA_PRM" , ""},
                { "V1PRIN_TIPO_TAXA" , ""},
                { "V1PRIN_PCDESCON" , ""},
                { "V1PRIN_TPDESCON" , ""},
                { "V1PRIN_PCADICIO" , ""},
                { "V1PRIN_PCVALRISC" , ""},
                { "V1PRIN_COEFAGRAV" , ""},
                { "V1PRIN_TIPRAZO" , ""},
                { "V1PRIN_SITUACAO" , ""},
                { "V1PRIN_TPMOVTO" , ""},
                { "V1PRIN_TPOCUP" , ""},
                { "V1PRIN_SPOCUP" , ""},
                { "V1PRIN_QTPAVTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPINC", q9);

            #endregion

            #region R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "V0APLI_COD_EMPRESA" , ""},
                { "V0APLI_NUM_APOL" , ""},
                { "V0APLI_NRENDOS" , ""},
                { "V0APLI_NUM_RISCO" , ""},
                { "V0APLI_COD_LOCAL" , ""},
                { "V0APLI_QTITENS" , ""},
                { "V0APLI_DTINIVIG" , ""},
                { "V0APLI_DTTERVIG" , ""},
                { "V0APLI_SITUACAO" , ""},
                { "V0APLI_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "V1APLI_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1", q11);

            #endregion

            #region R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "V1PRLI_NUM_RISCO" , ""},
                { "V0ENDO_NUM_APOL" , ""},
                { "V1APLI_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1_Update1", q12);

            #endregion

            #region EM0006B_V1PROPCLAUSULA

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "V1PRCL_COD_EMPRESA" , ""},
                { "V1PRCL_FONTE" , ""},
                { "V1PRCL_NRPROPOS" , ""},
                { "V1PRCL_RAMOFR" , ""},
                { "V1PRCL_MODALIFR" , ""},
                { "V1PRCL_CODCOBER" , ""},
                { "V1PRCL_DTINIVIG" , ""},
                { "V1PRCL_DTTERVIG" , ""},
                { "V1PRCL_NRITEM" , ""},
                { "V1PRCL_CODCLAUS" , ""},
                { "V1PRCL_LIM_IND_IX" , ""},
                { "V1PRCL_TIPOCLAU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPCLAUSULA", q13);

            #endregion

            #region R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "V0APIN_COD_EMPRESA" , ""},
                { "V0APIN_NUM_APOL" , ""},
                { "V0APIN_NRENDOS" , ""},
                { "V0APIN_NUM_RISCO" , ""},
                { "V0APIN_CODCOBINC" , ""},
                { "V0APIN_SUBRIS" , ""},
                { "V0APIN_NRITEM" , ""},
                { "V0APIN_COD_PLANTA" , ""},
                { "V0APIN_COD_RUBRICA" , ""},
                { "V0APIN_CLASOCUPA" , ""},
                { "V0APIN_CLASCONST" , ""},
                { "V0APIN_DTINIVIG" , ""},
                { "V0APIN_DTTERVIG" , ""},
                { "V0APIN_IMP_SEG_IX" , ""},
                { "V0APIN_PRM_TAR_IX" , ""},
                { "V0APIN_TIPCOND" , ""},
                { "V0APIN_TAXA_PRM" , ""},
                { "V0APIN_TIPO_TAXA" , ""},
                { "V0APIN_PCDESCON" , ""},
                { "V0APIN_TPDESCON" , ""},
                { "V0APIN_PCADICIO" , ""},
                { "V0APIN_PCVALRISC" , ""},
                { "V0APIN_COEFAGRAV" , ""},
                { "V0APIN_TIPRAZO" , ""},
                { "V0APIN_SITUACAO" , ""},
                { "V0APIN_TPMOVTO" , ""},
                { "V0APIN_TPOCUP" , ""},
                { "V0APIN_SPOCUP" , ""},
                { "V0APIN_QTPAVTO" , ""},
                { "V0APIN_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "V1APIN_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1", q15);

            #endregion

            #region R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "V1PRIN_NUM_RISCO" , ""},
                { "V1PRIN_TIPO_TAXA" , ""},
                { "V1PRIN_CODCOBINC" , ""},
                { "V0ENDO_NUM_APOL" , ""},
                { "V1APIN_OCORHIST" , ""},
                { "V1PRIN_TIPCOND" , ""},
                { "V1PRIN_SUBRIS" , ""},
                { "V1PRIN_NRITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1", q16);

            #endregion

            #region EM0006B_V1COSSEGSORT

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "V1COSS_RAMO" , ""},
                { "V1COSS_CONGENER" , ""},
                { "V1COSS_PCCOMCOS" , ""},
                { "V1COSS_PCPARTIC" , ""},
                { "V1COSS_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1COSSEGSORT", q17);

            #endregion

            #region R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1_Insert1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1_Insert1", q18);

            #endregion

            #region EM0006B_V1PROPDESINC

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "V1PRDI_COD_EMPRESA" , ""},
                { "V1PRDI_FONTE" , ""},
                { "V1PRDI_NRPROPOS" , ""},
                { "V1PRDI_NUM_RISCO" , ""},
                { "V1PRDI_NRITEM" , ""},
                { "V1PRDI_COD_PLANTA" , ""},
                { "V1PRDI_NRLINHA" , ""},
                { "V1PRDI_DESC_LINHA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPDESINC", q19);

            #endregion

            #region EM0006B_V1PROPDESCO

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "V1PIND_COD_EMPRESA" , ""},
                { "V1PIND_FONTE" , ""},
                { "V1PIND_NRPROPOS" , ""},
                { "V1PIND_NUM_RISCO" , ""},
                { "V1PIND_SUBRIS" , ""},
                { "V1PIND_NRITEM" , ""},
                { "V1PIND_PLANTA" , ""},
                { "V1PIND_PCDESPRT" , ""},
                { "V1PIND_TPDESCON" , ""},
                { "V1PIND_PCDESTAR" , ""},
                { "V1PIND_DESCDESCON" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPDESCO", q20);

            #endregion

            #region R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "V0APDI_COD_EMPRESA" , ""},
                { "V0APDI_NUM_APOL" , ""},
                { "V0APDI_NRENDOS" , ""},
                { "V0APDI_NUM_RISCO" , ""},
                { "V0APDI_NRITEM" , ""},
                { "V0APDI_COD_PLANTA" , ""},
                { "V0APDI_NRLINHA" , ""},
                { "V0APDI_DESC_LINHA" , ""},
                { "V0APDI_DTINIVIG" , ""},
                { "V0APDI_DTTERVIG" , ""},
                { "V0APDI_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1", q21);

            #endregion

            #region EM0006B_V1PROPOUTR

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "V1PROU_COD_EMPRESA" , ""},
                { "V1PROU_FONTE" , ""},
                { "V1PROU_NRPROPOS" , ""},
                { "V1PROU_APOLIDER" , ""},
                { "V1PROU_CODLIDER" , ""},
                { "V1PROU_IMP_SEG_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPOUTR", q22);

            #endregion

            #region R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "V0APID_COD_EMPRESA" , ""},
                { "V0APID_NUM_APOL" , ""},
                { "V0APID_NRENDOS" , ""},
                { "V0APID_NUM_RISCO" , ""},
                { "V0APID_SUBRIS" , ""},
                { "V0APID_NRITEM" , ""},
                { "V0APID_PLANTA" , ""},
                { "V0APID_PCDESPRT" , ""},
                { "V0APID_TPDESCON" , ""},
                { "V0APID_PCDESTAR" , ""},
                { "V0APID_DESCDESCON" , ""},
                { "V0APID_DTINIVIG" , ""},
                { "V0APID_DTTERVIG" , ""},
                { "V0APID_SITUACAO" , ""},
                { "V0APID_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1", q23);

            #endregion

            #region EM0006B_V1PROPDCOB

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "V1PRDC_COD_EMPRESA" , ""},
                { "V1PRDC_FONTE" , ""},
                { "V1PRDC_NRPROPOS" , ""},
                { "V1PRDC_NUM_RISCO" , ""},
                { "V1PRDC_SUBRIS" , ""},
                { "V1PRDC_NRITEM" , ""},
                { "V1PRDC_DESCR_BENS" , ""},
                { "V1PRDC_IMP_SEG_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPDCOB", q24);

            #endregion

            #region R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "V0APOU_COD_EMPRESA" , ""},
                { "V0APOU_NUM_APOL" , ""},
                { "V0APOU_NRENDOS" , ""},
                { "V0APOU_APOLIDER" , ""},
                { "V0APOU_CODLIDER" , ""},
                { "V0APOU_IMP_SEG_IX" , ""},
                { "V0APOU_DTINIVIG" , ""},
                { "V0APOU_DTTERVIG" , ""},
                { "V0APOU_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1", q25);

            #endregion

            #region EM0006B_V1COBPROPINC

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "V1COBP_COD_EMPRESA" , ""},
                { "V1COBP_FONTE" , ""},
                { "V1COBP_NRPROPOS" , ""},
                { "V1COBP_NUM_RISCO" , ""},
                { "V1COBP_SUBRIS" , ""},
                { "V1COBP_NRITEM" , ""},
                { "V1COBP_CODCOBINC" , ""},
                { "V1COBP_IMP_SEG_IX" , ""},
                { "V1COBP_TIPCOBINC" , ""},
                { "V1COBP_PRM_TAR_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1COBPROPINC", q26);

            #endregion

            #region R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "V0APDC_COD_EMPRESA" , ""},
                { "V0APDC_NUM_APOL" , ""},
                { "V0APDC_NRENDOS" , ""},
                { "V0APDC_NUM_RISCO" , ""},
                { "V0APDC_SUBRIS" , ""},
                { "V0APDC_NRITEM" , ""},
                { "V0APDC_DESCR_BENS" , ""},
                { "V0APDC_IMP_SEG_IX" , ""},
                { "V0APDC_DTINIVIG" , ""},
                { "V0APDC_DTTERVIG" , ""},
                { "V0APDC_SITUACAO" , ""},
                { "V0APDC_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1", q27);

            #endregion

            #region R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "V0APOL_CODCLIEN" , ""},
                { "V0APOL_NUM_APOL" , ""},
                { "V0APOL_NUM_ITEM" , ""},
                { "V0APOL_MODALIDA" , ""},
                { "V0APOL_ORGAO" , ""},
                { "V0APOL_RAMO" , ""},
                { "V0APOL_NUM_APO_ANT" , ""},
                { "V0APOL_NUMBIL" , ""},
                { "V0APOL_TIPSGU" , ""},
                { "V0APOL_TIPAPO" , ""},
                { "V0APOL_TIPCALC" , ""},
                { "V0APOL_PODPUBL" , ""},
                { "V0APOL_NUM_ATA" , ""},
                { "V0APOL_ANO_ATA" , ""},
                { "V0APOL_IDEMAN" , ""},
                { "V0APOL_PCDESCON" , ""},
                { "V0APOL_PCIOCC" , ""},
                { "V0APOL_TPCOSCED" , ""},
                { "V0APOL_QTCOSSEG" , ""},
                { "V0APOL_PCTCED" , ""},
                { "V0APOL_COD_EMPRESA" , ""},
                { "V0APOL_CODPRODU" , ""},
                { "V0APOL_TPCORRET" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1", q28);

            #endregion

            #region R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "V0ENDO_NUM_APOL" , ""},
                { "V0ENDO_NRENDOS" , ""},
                { "V0ENDO_CODSUBES" , ""},
                { "V0ENDO_FONTE" , ""},
                { "V0ENDO_NRPROPOS" , ""},
                { "V0ENDO_DATPRO" , ""},
                { "V0ENDO_DT_LIBER" , ""},
                { "V0ENDO_DTEMIS" , ""},
                { "V0ENDO_NRRCAP" , ""},
                { "V0ENDO_VLRCAP" , ""},
                { "V0ENDO_BCORCAP" , ""},
                { "V0ENDO_AGERCAP" , ""},
                { "V0ENDO_DACRCAP" , ""},
                { "V0ENDO_IDRCAP" , ""},
                { "V0ENDO_BCOCOBR" , ""},
                { "V0ENDO_AGECOBR" , ""},
                { "V0ENDO_DACCOBR" , ""},
                { "V0ENDO_DTINIVIG" , ""},
                { "V0ENDO_DTTERVIG" , ""},
                { "V0ENDO_CDFRACIO" , ""},
                { "V0ENDO_PCENTRAD" , ""},
                { "V0ENDO_PCADICIO" , ""},
                { "V0ENDO_PRESTA1" , ""},
                { "V0ENDO_QTPARCEL" , ""},
                { "V0ENDO_QTPRESTA" , ""},
                { "V0ENDO_QTITENS" , ""},
                { "V0ENDO_CODTXT" , ""},
                { "V0ENDO_CDACEITA" , ""},
                { "V0ENDO_MOEDA_IMP" , ""},
                { "V0ENDO_MOEDA_PRM" , ""},
                { "V0ENDO_TIPEND" , ""},
                { "V0ENDO_COD_USUAR" , ""},
                { "V0ENDO_OCORR_END" , ""},
                { "V0ENDO_SITUACAO" , ""},
                { "V0ENDO_DATARCAP" , ""},
                { "V0ENDO_COD_EMPRESA" , ""},
                { "V0ENDO_CORRECAO" , ""},
                { "V0ENDO_ISENTA_CST" , ""},
                { "V0ENDO_DTVENCTO" , ""},
                { "V0ENDO_CFPREFIX" , ""},
                { "V0ENDO_VLCUSEMI" , ""},
                { "V0ENDO_RAMO" , ""},
                { "V0ENDO_CODPRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1_Insert1", q29);

            #endregion

            #region EM0006B_V1PRAZOCURTO

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "V1PRAC_PCTPRAZOVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PRAZOCURTO", q30);

            #endregion

            #region R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "V0COBI_COD_EMPRESA" , ""},
                { "V0COBI_NUM_APOL" , ""},
                { "V0COBI_NRENDOS" , ""},
                { "V0COBI_NUM_RISCO" , ""},
                { "V0COBI_SUBRIS" , ""},
                { "V0COBI_NRITEM" , ""},
                { "V0COBI_CODCOBINC" , ""},
                { "V0COBI_IMP_SEG_IX" , ""},
                { "V0COBI_TIPCOBINC" , ""},
                { "V0COBI_PRM_TAR_IX" , ""},
                { "V0COBI_PRM_ANU_IX" , ""},
                { "V0COBI_PRM_TAR_VR" , ""},
                { "V0COBI_DTINIVIG" , ""},
                { "V0COBI_DTTERVIG" , ""},
                { "V0COBI_SITUACAO" , ""},
                { "V0COBI_OCORHIST" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1", q31);

            #endregion

            #region R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "V1COBI_OCORHIST" , ""},
                { "W1COBI_ANU_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1", q32);

            #endregion

            #region R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "V1COBP_NUM_RISCO" , ""},
                { "V1COBP_TIPCOBINC" , ""},
                { "V1COBP_CODCOBINC" , ""},
                { "V0ENDO_NUM_APOL" , ""},
                { "V1COBI_OCORHIST" , ""},
                { "V1COBP_SUBRIS" , ""},
                { "V1COBP_NRITEM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1", q33);

            #endregion

            #region EM0006B_V1PRAZOLONGO

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "V1PRAL_PCTPRAZOVIG" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1PRAZOLONGO", q34);

            #endregion

            #region EM0006B_V1ACOMPROP

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "V1APRO_DATOPR" , ""},
                { "V1APRO_HORAOPER" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("EM0006B_V1ACOMPROP", q35);

            #endregion

            #region R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
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
                { "V0COBA_DTINIVIG" , ""},
                { "V0COBA_DTTERVIG" , ""},
                { "V0COBA_COD_EMPRESA" , ""},
                { "V0COBA_SITREG" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1", q36);

            #endregion

            #region R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "W0APOL_QTCOSSEG" , ""},
                { "V1PROP_CODCLIEN" , ""},
                { "W0APOL_PCTCED" , ""},
                { "V0APOL_NUM_APOL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1", q37);

            #endregion

            #region R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_SEQ_APOL" , ""},
                { "V0NAES_ENDOSCOB" , ""},
                { "V0NAES_NRENDOCA" , ""},
                { "V0NAES_ENDOSRES" , ""},
                { "V0NAES_ENDOSSEM" , ""},
                { "V0NAES_ENDOSCCR" , ""},
                { "V0NAES_ENDOSMVC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1", q38);

            #endregion

            #region R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "V0NAES_SEQ_APOL" , ""},
                { "V0NAES_ENDOSCOB" , ""},
                { "V0NAES_NRENDOCA" , ""},
                { "V0NAES_ENDOSRES" , ""},
                { "V0NAES_ENDOSSEM" , ""},
                { "V0NAES_ENDOSCCR" , ""},
                { "V0NAES_ENDOSMVC" , ""},
                { "V1FONT_ORGAOEMIS" , ""},
                { "V1PROP_RAMO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1", q39);

            #endregion

            #region R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1", q40);

            #endregion

            #region R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
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
                { "V0EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1", q41);

            #endregion

            #region R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
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
                { "V0EDIA_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1", q42);

            #endregion

            #region R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1_Query1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "W1CPRO_OCORHIST" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1_Query1", q43);

            #endregion

            #region R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "V0APRO_FONTE" , ""},
                { "V0APRO_NRPROPOS" , ""},
                { "V0APRO_OPERACAO" , ""},
                { "V0APRO_DATOPR" , ""},
                { "V0APRO_HORAOPER" , ""},
                { "V0APRO_OCORHIST" , ""},
                { "V0APRO_CODUSU" , ""},
                { "V0APRO_COD_EMPRESA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1", q44);

            #endregion

            #region R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "V0MPRD_NUM_APOL" , ""},
                { "V0MPRD_CODSUBES" , ""},
                { "V0MPRD_CODCORR" , ""},
                { "V0MPRD_CODPRP" , ""},
                { "V0MPRD_CODCLB" , ""},
                { "V0MPRD_INSPETOR" , ""},
                { "V0MPRD_ISPRGI" , ""},
                { "V0MPRD_CODGTE" , ""},
                { "V0MPRD_CODSTE" , ""},
                { "V0MPRD_DIRRGI" , ""},
                { "V0MPRD_DIRCMC" , ""},
                { "V0MPRD_COD_EMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1", q45);

            #endregion

            #region R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1

            var q46 = new DynamicData();
            q46.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1", q46);

            #endregion

            #region R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1_Update1

            var q47 = new DynamicData();
            q47.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1_Update1", q47);

            #endregion

            #region R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1_Update1

            var q48 = new DynamicData();
            q48.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1_Update1", q48);

            #endregion

            #region R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1_Update1

            var q49 = new DynamicData();
            q49.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1_Update1", q49);

            #endregion

            #region R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1_Update1

            var q50 = new DynamicData();
            q50.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1_Update1", q50);

            #endregion

            #endregion
        }

        [Fact]
        public static void EM0006B_Tests_Fact()
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
                AppSettings.TestSet.DynamicData.Remove("EM0006B_V1PROPOSTA");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "V1PROP_TPPROPOS" , "1"},
                { "V1PROP_FONTE" , ""},
                { "V1PROP_NRPROPOS" , ""},
                { "V1PROP_RAMO" , ""},
                { "V1PROP_MODALIDA" , ""},
                { "V1PROP_NUM_APO_ANT" , ""},
                { "V1PROP_TIPAPO" , ""},
                { "V1PROP_CODCLIEN" , ""},
                { "V1PROP_DTINIVIG" , ""},
                { "V1PROP_DTTERVIG" , ""},
                { "V1PROP_PODPUBL" , ""},
                { "V1PROP_CORRECAO" , ""},
                { "V1PROP_MOEDA_IMP" , ""},
                { "V1PROP_MOEDA_PRM" , ""},
                { "V1PROP_PRESTA1" , ""},
                { "V1PROP_BCORCAP" , ""},
                { "V1PROP_AGERCAP" , ""},
                { "V1PROP_NRRCAP" , ""},
                { "V1PROP_VLRCAP" , ""},
                { "V1PROP_CDFRACIO" , ""},
                { "V1PROP_QTPARCEL" , ""},
                { "V1PROP_PCENTRAD" , ""},
                { "V1PROP_PCADICIO" , ""},
                { "V1PROP_IDIOF" , ""},
                { "V1PROP_ISENTA_CST" , ""},
                { "V1PROP_QTPRESTA" , ""},
                { "V1PROP_BCOCOBR" , ""},
                { "V1PROP_AGECOBR" , ""},
                { "V1PROP_TPCORRET" , ""},
                { "V1PROP_NRAUTCOR" , ""},
                { "V1PROP_QTCORR" , ""},
                { "V1PROP_QTCORRC" , ""},
                { "V1PROP_NUM_APO_MAN" , ""},
                { "V1PROP_TPCOSCED" , ""},
                { "V1PROP_QTCOSSGC" , ""},
                { "V1PROP_QTCOSSEG" , ""},
                { "V1PROP_QTITENSI" , ""},
                { "V1PROP_QTITENS" , ""},
                { "V1PROP_TPMOVTO" , ""},
                { "V1PROP_DTENTRAD" , ""},
                { "V1PROP_DTCADAST" , ""},
                { "V1PROP_TIPCALC" , ""},
                { "V1PROP_LIMIND" , ""},
                { "V1PROP_CDACEITA" , ""},
                { "V1PROP_NRAUTACE" , ""},
                { "V1PROP_PCDESCON" , ""},
                { "V1PROP_IDRCAP" , ""},
                { "V1PROP_CODTXT" , ""},
                { "V1PROP_NUM_RENOV" , ""},
                { "V1PROP_CONV_COBR" , ""},
                { "V1PROP_OCORR_END" , ""},
                { "V1PROP_SITUACAO" , ""},
                { "V1PROP_COD_USUAR" , ""},
                { "V1PROP_NUM_ATA" , ""},
                { "V1PROP_ANO_ATA" , ""},
                { "V1PROP_DATA_SORT" , ""},
                { "V1PROP_DTLIBER" , ""},
                { "V1PROP_DTAPOLM" , ""},
                { "V1PROP_DATARCAP" , ""},
                { "V1PROP_COD_EMPRESA" , ""},
                { "V1PROP_TIMESTAMP" , ""},
                { "V1PROP_TIPO_ENDO" , "1"},
                { "V1PROP_NUM_APOLICE" , ""},
                { "V1PROP_INSPETOR" , ""},
                { "V1PROP_CANALPROD" , ""},
                { "V1PROP_CODPRODU" , ""},
                { "V1PROP_DTVENCTO" , ""},
                { "V1PROP_CFPREFIX" , ""},
                { "V1PROP_VLCUSEMI" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("EM0006B_V1PROPOSTA", q1);

                AppSettings.TestSet.DynamicData.Remove("R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1");
                var q24 = new DynamicData();
                q24.AddDynamic(new Dictionary<string, string>{
                { "V0APOU_COD_EMPRESA" , ""},
                { "V0APOU_NUM_APOL" , "0000000009999"},
                { "V0APOU_NRENDOS" , ""},
                { "V0APOU_APOLIDER" , ""},
                { "V0APOU_CODLIDER" , ""},
                { "V0APOU_IMP_SEG_IX" , ""},
                { "V0APOU_DTINIVIG" , ""},
                { "V0APOU_DTTERVIG" , ""},
                { "V0APOU_OCORHIST" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1", q24);

                #endregion
                var program = new EM0006B();
                program.Execute();

                var envList = AppSettings.TestSet.DynamicData["R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1"].DynamicList;
                var envList2 = AppSettings.TestSet.DynamicData["R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1_Insert1"].DynamicList;
                var envList3 = AppSettings.TestSet.DynamicData["R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1"].DynamicList;
                var envList4 = AppSettings.TestSet.DynamicData["R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1"].DynamicList;
                var envList6 = AppSettings.TestSet.DynamicData["R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1"].DynamicList;
                var envList7 = AppSettings.TestSet.DynamicData["R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1_Insert1"].DynamicList;
                var envList8 = AppSettings.TestSet.DynamicData["R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1"].DynamicList;
                var envList9 = AppSettings.TestSet.DynamicData["R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1"].DynamicList;
                var envList10 = AppSettings.TestSet.DynamicData["R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1"].DynamicList;
                var envList11 = AppSettings.TestSet.DynamicData["R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1"].DynamicList;
                var envList12 = AppSettings.TestSet.DynamicData["R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1"].DynamicList;
                var envList13 = AppSettings.TestSet.DynamicData["R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1"].DynamicList;
                var envList14 = AppSettings.TestSet.DynamicData["R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1"].DynamicList;
                var envList15 = AppSettings.TestSet.DynamicData["R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1"].DynamicList;
                var envList16 = AppSettings.TestSet.DynamicData["R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                var envList17 = AppSettings.TestSet.DynamicData["R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1_Update1"].DynamicList;
                var envList18 = AppSettings.TestSet.DynamicData["R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1_Update1"].DynamicList;
                var envList19 = AppSettings.TestSet.DynamicData["R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1_Update1"].DynamicList;
                var envList20 = AppSettings.TestSet.DynamicData["R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1"].DynamicList;
                var envList21 = AppSettings.TestSet.DynamicData["R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1"].DynamicList;
                var envList22 = AppSettings.TestSet.DynamicData["R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1"].DynamicList;
                var envList23 = AppSettings.TestSet.DynamicData["R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1"].DynamicList;

                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);
                Assert.True(envList2?.Count > 1);
                Assert.True(envList3?.Count > 1);
                Assert.True(envList4?.Count > 1);
                Assert.True(envList6?.Count > 1);
                Assert.True(envList7?.Count > 1);
                Assert.True(envList8?.Count > 1);
                Assert.True(envList9?.Count > 1);
                Assert.True(envList10?.Count > 1);
                Assert.True(envList11?.Count > 1);
                Assert.True(envList12?.Count > 1);
                Assert.True(envList13?.Count > 1);
                Assert.True(envList14?.Count > 1);
                Assert.True(envList15?.Count > 1);
                Assert.True(envList16?.Count > 1);
                Assert.True(envList17?.Count > 1);
                Assert.True(envList18?.Count > 1);
                Assert.True(envList19?.Count > 1);
                Assert.True(envList20?.Count > 1);
                Assert.True(envList21?.Count > 1);
                Assert.True(envList22?.Count > 1);
                Assert.True(envList23?.Count > 1);

                Assert.True(envList[1].TryGetValue("V0APLI_COD_EMPRESA", out string valor) && valor == "000000011");
                Assert.True(envList1[1].TryGetValue("V0APIN_NUM_APOL", out valor) && valor == "0000000000001");
                Assert.True(envList2[1].TryGetValue("V0APCL_NRENDOS", out valor) && valor == "000000000");
                Assert.True(envList3[1].TryGetValue("V0APDI_NUM_RISCO", out valor) && valor == "000000000");
                Assert.True(envList4[1].TryGetValue("V0APID_COD_EMPRESA", out valor) && valor == "000000011");
                Assert.True(envList6[1].TryGetValue("V0APDC_COD_EMPRESA", out valor) && valor == "000000011");
                Assert.True(envList7[1].TryGetValue("V0ENDO_NUM_APOL", out valor) && valor == "0000000000001");
                Assert.True(envList8[1].TryGetValue("V0COBI_COD_EMPRESA", out valor) && valor == "000000011");
                Assert.True(envList9[1].TryGetValue("V0COBA_NUM_APOL", out valor) && valor == "0000000000001");
                Assert.True(envList10[1].TryGetValue("V0NAES_ENDOSCOB", out valor) && valor == "000000000");
                Assert.True(envList11[1].TryGetValue("V1PROP_NRPROPOS", out valor) && valor == "000000000");
                Assert.True(envList12[1].TryGetValue("V0EDIA_CODRELAT", out valor) && valor == "EM0221B1");
                Assert.True(envList13[1].TryGetValue("V0EDIA_CODRELAT", out valor) && valor == "EM0200B1");
                Assert.True(envList14[1].TryGetValue("V0APRO_OPERACAO", out valor) && valor == "9019");
                Assert.True(envList15[1].TryGetValue("V0MPRD_COD_EMP", out valor) && valor == "000000011");
                Assert.True(envList16[1].TryGetValue("V1PROP_NRPROPOS", out valor) && valor == "000000000");
                Assert.True(envList17[1].TryGetValue("V1PROP_NRPROPOS", out valor) && valor == "000000000");
                Assert.True(envList18[1].TryGetValue("V1PROP_NRPROPOS", out valor) && valor == "000000000");
                Assert.True(envList19[1].TryGetValue("V1PROP_NRPROPOS", out valor) && valor == "000000000");
                Assert.True(envList20[1].TryGetValue("V0ACOR_NUM_APOL", out valor) && valor == "0000000000001");
                Assert.True(envList21[1].TryGetValue("V0ACOS_NUM_APOL", out valor) && valor == "0000000000001");
                Assert.True(envList22[1].TryGetValue("V0APOL_CODCLIEN", out valor) && valor == "000000000");
                Assert.True(envList23[1].TryGetValue("W0APOL_QTCOSSEG", out valor) && valor == "0001");
            }
        }
    }
}