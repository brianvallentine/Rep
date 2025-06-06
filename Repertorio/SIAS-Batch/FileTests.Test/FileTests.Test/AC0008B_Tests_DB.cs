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
using static Code.AC0008B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("AC0008B_Tests_DB")]
    public class AC0008B_Tests_DB
    {

        [Fact]
        public static void AC0008B_Database()
        {
            var program = new AC0008B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.V0SIST_DTMOVABE.Value = "2020-01-01";
                program.R0900_00_DECLARE_V0HISTOPARC_DB_DECLARE_1(); program.R0900_00_DECLARE_V0HISTOPARC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V0HISP_NUM_APOL.Value = 12;
                program.R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                 program.V0CPRE_COD_EMPR.Value = 1;
                 program.V0CPRE_TIPSGU.Value = "X";
                 program.V0CPRE_CONGENER.Value = 1;
                 program.V0CPRE_NUM_ORDEM.Value = 1;
                 program.V0CPRE_NUM_APOL.Value = 1;
                 program.V0CPRE_NRENDOS.Value = 1;
                 program.V0CPRE_NRPARCEL.Value = 1;
                 program.V0CPRE_PRM_TAR_IX.Value = 1;
                 program.V0CPRE_VAL_DES_IX.Value = 1;
                 program.V0CPRE_OTNPRLIQ.Value = 1;
                 program.V0CPRE_OTNADFRA.Value = 1;
                 program.V0CPRE_VLCOMISIX.Value = 1;
                 program.V0CPRE_OTNTOTAL.Value = 1;
                 program.V0CPRE_SITUACAO.Value = "X";
                 program.V0CPRE_SIT_CONG.Value = "X";
                 program.V0CPRE_OCORHIST.Value = 1;
                 program.VIND_OCR_HIST.Value = 1;
                 program.R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.V0CHIS_COD_EMPR.Value = 1;
                program.V0CHIS_CONGENER.Value = 2;
                program.V0CHIS_NUM_APOL.Value = 3;
                program.V0CHIS_NRENDOS.Value = 4;
                program.V0CHIS_NRPARCEL.Value = 5;
                program.V0CHIS_OCORHIST.Value = 6;
                program.V0CHIS_OPERACAO.Value = 7;
                program.V0CHIS_DTMOVTO.Value = "2020-01-01";
                program.V0CHIS_TIPSGU.Value = "x";
                program.V0CHIS_PRM_TAR.Value = 1;
                program.V0CHIS_VAL_DES.Value = 2;
                program.V0CHIS_VLPRMLIQ.Value = 3;
                program.V0CHIS_VLADIFRA.Value = 4;
                program.V0CHIS_VLCOMIS.Value = 5;
                program.V0CHIS_VLPRMTOT.Value = 6;
                program.V0CHIS_DTQITBCO.Value = "2020-01-01";
                program.VIND_DTQITBCO.Value = 8;
                program.V0CHIS_SIT_FINANC.Value = "X";
                program.VIND_SIT_FINC.Value = 10;
                program.V0CHIS_SIT_LIBRECUP.Value = "X";
                program.VIND_SIT_LIBR.Value = 12;
                program.V0CHIS_NUMOCOR.Value = 13;
                program.VIND_NUM_OCOR.Value = 14;
                program.R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}