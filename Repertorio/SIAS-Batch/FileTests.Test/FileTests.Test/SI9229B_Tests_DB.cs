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
using static Code.SI9229B;

namespace FileTests.Test_DB
{
    [Collection("SI9229B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI9229B_Tests_DB
    {

        [Fact]
        public static void SI9229B_Database()
        {
            var program = new SI9229B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/


                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Value = "2000-10-10";


                program.R1000_OPEN_CUR01_HIST_MESTRE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0050_00_MAX_GEARDETA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                //foreign key
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO.Value = "2000-10-10";
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO.Value = "2000-10-10";
                program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO.Value = "2000-10-10";
                //program.GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA.Value = "2000-10-10";

                program.R6000_00_INCLUI_GEARDETA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}