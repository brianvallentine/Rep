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
using static Code.BI0073B;

namespace FileTests.Test_DB
{
    [Collection("BI0073B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0073B_Tests_DB
    {

        [Fact]
        public static void BI0073B_Database()
        {
            var program = new BI0073B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0150_00_SELECT_MOVIMCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0420_00_SELECT_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0430_00_SELECT_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0450_00_SELECT_MOVIMCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0510_00_SELECT_V0CEDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*8*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.Value = "1988-04-30";
                program.R0520_00_UPDATE_BILHETE_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*10*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "1988-04-30";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "1988-04-30";
                program.R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R1000_00_DELETE_BILHETE_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*12*/

                program.CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO.Value = "1988-04-30";
                program.CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO.Value = "1988-04-30";
                program.R1100_00_INSERT_CONVERSI_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*13*/

                program.BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.Value = "1988-04-30";
                program.R1200_00_INSERT_BILHETE_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.Value = 201807020000017;
                program.R3900_00_SELECT_MOVIMCOB_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.Value = "1988-04-30";
                program.MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.Value = "1988-04-30";
                program.R4000_00_INSERT_MOVIMCOB_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}