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
using static Code.GE0300B;

namespace FileTests.Test_DB
{
    [Collection("GE0300B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class GE0300B_Tests_DB
    {

        [Fact]
        public static void GE0300B_Database()
        {
            var program = new GE0300B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO.Value = "2024-10-10";
            program.GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO.Value = "2000-10-10";

            program.GE102.DCLGE_ARQUIVO_SAP.GE102_DTH_MOVIMENTO.Value = "2024-10-10";
            program.GE102.DCLGE_ARQUIVO_SAP.GE102_DTH_CADASTRAMENTO.Value = "2024-10-10";

            try { /*1*/ program.R0010_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1020_INS_BOLETO_EMISSAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1040_INS_CHEQUES_SAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1050_INS_MOVDEBCE_SAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1060_INS_VIDA_SAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1070_INS_USO_EMPRESA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1200_INS_MOVIMENTO_SAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1300_INS_CONTROLE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1400_INS_REGISTRO_SAP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}