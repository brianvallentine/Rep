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
using static Code.SI0888B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0888B_Tests_DB")]
    public class SI0888B_Tests_DB
    {

        [Fact]
        public static void SI0888B_Database()
        {
            var program = new SI0888B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/

                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2025-01-01";
                program.R300_OPEN_CR_ESTORNO_DB_OPEN_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*2*/ program.R31010_SEGURADO_CREDINT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R10_PROCESSA_DATA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R31000_SEGURADO_HABIT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R31010_SEGURADO_CREDINT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R31020_SEGURADO_OUTROS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R310200_SEGURADO_ITEM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R310210_SEGURADO_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R31100_LE_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R31110_PROC_AGENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R31110_PROC_AGENCIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R31120_PROC_CHEQUE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R31110_PROC_AGENCIA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R31130_PROC_SIVAT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R31140_PROC_SICOV_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R31140_PROC_SICOV_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R31150_LE_AGTABCH1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R31140_PROC_SICOV_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R3120_BUSCA_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try 
            { /*20*/
                program.WK_INICIO_WORKING.HOST_MOV_INICIAL.Value = "2025-01-01";
                program.WK_INICIO_WORKING.HOST_DTH_ULT_DIA_MES.Value = "2025-01-01";
                program.R330_BUSCA_SOMATORIO_DB_SELECT_1(); 
            } catch (Exception ex) 
            {
                _.ThreatableTestError(ex); 
            }

            try { /*21*/ program.R340_CALENDARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}