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
using static Code.LT3164S;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("LT3164S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3164S_Tests_DB
    {

        [Fact]
        public static void LT3164S_Database()
        {
            var program = new LT3164S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE.Value = 000000000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.Value = "132";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO.Value = "2025-03-13";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO.Value =  "";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC.Value = "2025-03-13";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.Value = "" ;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.Value = "2025-03-13";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02.Value = "2025-03-13";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.Value = "2025-03-13";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02.Value = 0000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01.Value = "" ;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02.Value = "" ;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03.Value =  "";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04.Value = "" ;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR05.LTSOLPAR_PARAM_CHAR05_LEN.Value = 0 ;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR05.LTSOLPAR_PARAM_CHAR05_TEXT.Value = "";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DTH_SOLICITACAO.Value = "01:01:01";
                program.R1000_00_PROCESSAR_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}