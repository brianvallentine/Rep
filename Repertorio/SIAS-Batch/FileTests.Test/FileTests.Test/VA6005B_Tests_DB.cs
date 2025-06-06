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
using static Code.VA6005B;

namespace FileTests.Test_DB
{
    [Collection("VA6005B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA6005B_Tests_DB
    {

        [Fact]
        public static void VA6005B_Database()
        {
            var program = new VA6005B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1(); program.R0900_00_DECLARE_V0BILHETE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1080_00_GRAVA_V0APOLCOSCED_DB_DECLARE_1(); program.R1080_00_GRAVA_V0APOLCOSCED_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1000_00_LEITURA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1050_00_TRATA_FUNDAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1050_00_TRATA_FUNDAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1050_20_TRATA_FENAE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1050_20_TRATA_FENAE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1000_00_PROCESSA_REGISTRO_DB_INSERT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1000_00_PROCESSA_REGISTRO_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1066_00_TRATA_EVOGEPES016_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1067_00_TRATA_CORRETOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1068_00_INSERT_APOLCORRET_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R3200_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.R3200_10_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1083_00_INSERT_V0ORDECOSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R1090_00_UPDATE_V0APOLICE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R2990_00_VERIFICA_PROFISSAO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R3000_10_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R3000_00_ACUMULA_BILHETE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R3000_10_CONTINUA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R3000_90_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R3000_10_CONTINUA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R3000_10_CONTINUA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R3000_10_CONTINUA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R3000_10_CONTINUA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R3000_91_LE_ENDOSSO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R3000_91_LE_ENDOSSO_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R3000_10_CONTINUA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R3000_10_CONTINUA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.R3020_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.R3000_10_CONTINUA_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*60*/ program.R3000_10_CONTINUA_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.R3045_00_INSERE_ERRO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.R3080_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.R3090_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.R3095_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/ program.R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/ program.R8100_00_DECLARE_CBO_DB_DECLARE_1(); program.R8100_00_DECLARE_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/ program.R3200_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*68*/ program.R3200_40_INSERT_V0RCAPCOMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*69*/ program.R3200_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/ program.R3240_00_UPDATE_CROT_AP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*71*/ program.R3250_00_UPDATE_CROT_RES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/ program.R3270_00_SELECT_APOLICE_ANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/ program.R3275_00_SELECT_ENDOSSO_ANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.R3280_00_SELECT_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/ program.R3280_00_SELECT_PRODUTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*77*/ program.R4400_00_INSERT_COMFEDCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/ program.R5000_00_SELECT_EMP_CAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/ program.R8000_JV1_BUSCA_EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}