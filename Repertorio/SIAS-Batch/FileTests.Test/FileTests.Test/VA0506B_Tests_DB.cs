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
using static Code.VA0506B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA0506B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0506B_Tests_DB
    {
        private static string pData = "2024-02-02";

        [Fact]
        public static void VA0506B_Database()
        {
            var program = new VA0506B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_DECLARE_V0FUNDO_DB_DECLARE_1(); program.R0300_00_DECLARE_V0FUNDO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.Value = pData;
                program.R2600_00_DECLARE_COBERAPOL_DB_DECLARE_1(); 
                program.R2600_00_DECLARE_COBERAPOL_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO.Value = 1;
                program.R0410_00_SELECT_HISCONPA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0420_00_SELECT_HISCONPA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_DATA_QUITACAO.Value = pData;
                program.R0430_00_SELECT_OPCPAGVI_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/
                program.PARAMPRO.DCLPARAM_PRODUTO.PARAMPRO_DATA_INIVIGENCIA.Value = pData;
                program.R0450_00_SELECT_PARAM_PRODUTO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*8*/ program.R0500_00_SELECT_V0COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_NUM_MATRI_VENDEDOR.Value = 1;
                program.FUNCOMVA.DCLFUNDO_COMISSAO_VA.FUNCOMVA_SITUACAO.Value = "1";
                program.R1500_00_UPDATE_V0FUNDO_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
                program.R3400_00_DECLARE_V0HISCONPA_DB_DECLARE_1(); 
                program.R3400_00_DECLARE_V0HISCONPA_DB_OPEN_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ 
                program.COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO.Value = pData;
                program.COMISSOE.DCLCOMISSOES.COMISSOE_DATA_MOVIMENTO.Value = pData;
                program.COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO.Value = pData;
                program.COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO.Value = pData;
                program.R3300_00_INSERT_COMISSOE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/ program.R3500_00_SELECT_V0COMISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}