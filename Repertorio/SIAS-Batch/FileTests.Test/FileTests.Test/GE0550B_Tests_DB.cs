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
using static Code.GE0550B;

namespace FileTests.Test_DB
{
    [Collection("GE0550B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0550B_Tests_DB
    {

        [Fact]
        public static void GE0550B_Database()
        {
            var program = new GE0550B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_SELECT_OD001_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0310_00_SELECT_SISTEMAS_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ program.R0315_00_SELECT_GE354_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                program.ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_INCLUSAO.Value = "2020-01-01";
                program.R0400_00_SELECT_ADPROGRA_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                program.ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_INCLUSAO.Value = "2020-01-01";
                program.ADPROGRA.DCLAD_PROGRAMA.ADPROGRA_DTH_COMPILACAO.Value = "2020-01-01";
                program.R0405_00_INSERT_PROGRAMAS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0410_00_SELECT_USUARIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0420_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0900_00_SELECT_GE366_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                program.GE366.DCLGE_MOVIMENTO.GE366_DTH_MOVIMENTO.Value = "2020-01-01";
                program.R0910_00_INSERT_GE366_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R0920_00_INSERT_GE367_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0930_00_INSERT_GE368_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*13*/
                program.CB039.DCLCB_PESS_PENDENCIA.CB039_DATA_MOVIMENTO.Value = "2020-01-01";
                program.CB039.DCLCB_PESS_PENDENCIA.CB039_HORA_OPERACAO.Value = "10:02:02";
                program.R1000_00_PROCESSA_OPERACAO_1_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/ program.R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3000_00_PROCESSA_OPERACAO_3_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R4000_00_PROCESSA_OPERACAO_4_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R5000_00_PROCESSA_OPERACAO_5_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}