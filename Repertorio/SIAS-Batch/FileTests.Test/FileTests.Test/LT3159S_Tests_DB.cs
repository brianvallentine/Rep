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
using static Code.LT3159S;

namespace FileTests.Test_DB
{
    [Collection("LT3159S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3159S_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void LT3159S_Database()
        {
            var program = new LT3159S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.WS_DTINIVIG_PROPOSTA.Value = pData;
                program.R1100_00_CONSULTA_GERAL_DB_DECLARE_1(); program.R1100_00_CONSULTA_GERAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R1200_00_CONSULTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1210_00_CONSULTA_COUNT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC.Value = pData;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.Value = pData;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02.Value = pData;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.Value = pData;
                program.R1305_00_INSERT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/
                program.WS_DT_INIVIGENCIA.Value = pData;
                program.R1500_00_PESQ_DATA_SIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.WS_DT_INIVIGENCIA.Value = pData;
                program.R1500_00_PESQ_DATA_SIST_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1600_00_EXCLUIR_REG_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/
                program.WS_DT_INIVIGENCIA.Value = pData;
                program.R1500_00_PESQ_DATA_SIST_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}