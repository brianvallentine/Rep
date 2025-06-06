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
using static Code.GE0853S;

namespace FileTests.Test_DB
{
    [Collection("GE0853S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0853S_Tests_DB
    {

        [Fact]
        public static void GE0853S_Database()
        {
            var program = new GE0853S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0000_00_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0000_00_PRINCIPAL_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1000_90_LEITURA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1000_90_LEITURA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.V1SIST_DTMOVABE.Value = "2025-01-08";
                program.R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1051_00_CANCELA_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1051_00_CANCELA_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1100_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1(); program.R1100_00_TRATA_V0DIFPARCELVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R4000_00_TRATA_3APARCELA_DB_DECLARE_1(); program.R4000_00_TRATA_3APARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1051_00_CANCELA_PARCELA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*20*/
                program.V0PROP_DTVENCTO.Value = "2025-01-08";
                program.R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R4000_00_TRATA_3APARCELA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*22*/
                program.V1SIST_DTVENFIM_CN.Value = "2025-01-08";
                program.R8170_00_CONTA_PEND_CCRED_DB_DECLARE_1(); 
                program.R8170_00_CONTA_PEND_CCRED_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R4000_10_LOOP_CDIFANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R4000_10_LOOP_CDIFANT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R4000_20_LE_CDIFANT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*26*/
                program.V0HISC_DTVENCTO.Value = "2025-01-08";
                program.R4500_00_SOLIC_RELAT_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*27*/
                program.V0PROP_DTPROXVEN.Value = "2025-01-08";
                program.R5000_00_GERA_PROXIMA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R5000_00_GERA_PROXIMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R5010_00_OCORHIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*32*/
                program.V0PROP_DTADMISSAO.Value = "2025-01-08";
                program.R5000_00_GERA_PROXIMA_DB_SELECT_3(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R5000_00_GERA_PROXIMA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R5010_10_OCORHIST_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R5010_10_OCORHIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R5000_00_GERA_PROXIMA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R5000_00_GERA_PROXIMA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*39*/
                program.V0HCOB_DTVENCTO.Value = "2025-01-08";
                program.R5000_00_GERA_PROXIMA_DB_UPDATE_3(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R5500_00_GERA_ATRASADAS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R5000_00_GERA_PROXIMA_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R5000_00_GERA_PROXIMA_DB_UPDATE_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R5000_00_GERA_PROXIMA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R5540_10_OCORHIST_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R5540_10_OCORHIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R5540_10_OCORHIST_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R5540_10_OCORHIST_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R5540_10_OCORHIST_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R5540_10_OCORHIST_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R5000_00_GERA_PROXIMA_DB_INSERT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R6000_10_CANCEL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*57*/
                program.V0FATC_DTREF.Value = "2025-01-08";
                program.V0MOVI_DTMOVTO.Value = "2025-01-08";
                program.R6000_20_PROPAUTOM_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.R6000_20_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R6000_10_CANCEL_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R6000_10_CANCEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R6000_10_CANCEL_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R6000_10_CANCEL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.R6100_00_SELECT_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.R6000_10_CANCEL_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/ program.R6000_10_CANCEL_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/ program.R6000_10_CANCEL_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/ program.R6000_10_CANCEL_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*68*/ program.R7000_00_QUITA_ATRASADA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*69*/ program.R6000_10_CANCEL_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/ program.R7000_00_QUITA_ATRASADA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*71*/ program.R7000_00_QUITA_ATRASADA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.R7000_00_QUITA_ATRASADA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/ program.R6000_10_CANCEL_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/ program.R7000_00_QUITA_ATRASADA_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.R7500_00_QUITA_PROXIMA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/ program.R7500_00_QUITA_PROXIMA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*77*/ program.R6000_10_CANCEL_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/ program.R7500_00_QUITA_PROXIMA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/ program.R7500_00_QUITA_PROXIMA_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*80*/ program.R7500_00_QUITA_PROXIMA_DB_INSERT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*81*/ program.R7500_00_QUITA_PROXIMA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*82*/ program.R6000_10_CANCEL_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*83*/ program.R7700_00_VERIFICA_REPASSES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*84*/ program.R6000_10_CANCEL_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*85*/ program.R7700_00_VERIFICA_REPASSES_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*86*/ program.R6000_10_CANCEL_DB_SELECT_11(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*87*/
                program.V0RCDG_DTREFER.Value = "2025-01-08";
                program.R8000_00_REPASSA_CDG_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*88*/ program.R8000_00_REPASSA_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*89*/ program.R6000_10_CANCEL_DB_SELECT_12(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*90*/
                program.V0RSAF_DTREFER.Value = "2025-01-08";
                program.R8100_00_REPASSA_SAF_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*91*/ program.R8100_00_REPASSA_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*92*/ program.R8105_00_ACERTA_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*93*/ program.R8105_00_ACERTA_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*94*/ program.R8105_00_ACERTA_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*95*/ program.R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*96*/ program.R8150_00_CONTA_PEND_CONTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*97*/ program.R8160_00_MAX_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*98*/ program.R8161_00_SELECIONA_VL_PARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*99*/ program.R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*100*/ program.R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*101*/ program.R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*102*/ program.R8164_00_MIN_PARCELA_PEND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*103*/ program.R8175_00_CONTAR_PARC_AT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*104*/ program.R8175_00_CONTAR_PARC_AT_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}