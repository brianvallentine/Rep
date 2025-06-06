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
using static Code.SI5040B;

namespace FileTests.Test_DB
{
    [Collection("SI5040B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI5040B_Tests_DB
    {

        [Fact]
        public static void SI5040B_Database()
        {
            var program = new SI5040B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            #region VARIABLES
            program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";
            program.HOST_DT_MOVABTO_MENOS_10DIAS.Value = "2000-10-10";
            #endregion
            program.InitializeGetQuery();

            try { /*1*/ program.R300_OPEN_CR_SIVAT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R10_BUSCA_DATA_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R20_LE_NUMERO_OUTROS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}