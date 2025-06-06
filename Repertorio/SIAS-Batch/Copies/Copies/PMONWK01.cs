using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class PMONWK01 : VarBasis
    {
        /*"77  W-:GE3000B:-PROG-CALL         PIC X(008) VALUE SPACES*/
        public StringBasis W_GE3000B_PROG_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  W-:GE3000B:-PARAGRAFO-ORIG    PIC X(005) VALUE SPACES*/
        public StringBasis W_GE3000B_PARAGRAFO_ORIG { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"77  W-:GE3000B:-RETURN-CODE       PIC 9(009) VALUE 0*/
        public IntBasis W_GE3000B_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  W-:GE3000B:-FIM-ARQ           PIC X(003) VALUE 'NAO'*/
        public StringBasis W_GE3000B_FIM_ARQ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77  W-:GE3000B:-COUNT             PIC 9(010) VALUE 0*/
        public IntBasis W_GE3000B_COUNT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"77  W-:GE3000B:-IND-ERRO-INI      PIC 9(004) VALUE 0*/
        public IntBasis W_GE3000B_IND_ERRO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  W-:GE3000B:-IND-ERRO-GRA      PIC 9(004) VALUE 0*/
        public IntBasis W_GE3000B_IND_ERRO_GRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  W-:GE3000B:-IND-ERRO-FIN      PIC 9(004) VALUE 0*/
        public IntBasis W_GE3000B_IND_ERRO_FIN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  W-:GE3000B:-MSG-ERRO-INI      PIC X(120) VALUE SPACES*/
        public StringBasis W_GE3000B_MSG_ERRO_INI { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
        /*"77  W-:GE3000B:-MSG-ERRO-GRA      PIC X(120) VALUE SPACES*/
        public StringBasis W_GE3000B_MSG_ERRO_GRA { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
        /*"77  W-:GE3000B:-MSG-ERRO-FIN      PIC X(120) VALUE SPACES*/
        public StringBasis W_GE3000B_MSG_ERRO_FIN { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
        /*"77  W-:GE3000B:-MSG-ERRO          PIC X(120) VALUE SPACES*/
        public StringBasis W_GE3000B_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
        /*"01  W-:GE3000B:-CT-TRACE          PIC X(003) VALUE 'NAO'*/

        public SelectorBasis W_GE3000B_CT_TRACE { get; set; } = new SelectorBasis("003", "NAO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 W-:GE3000B:-CT-TRACE-ON     VALUE 'SIM' */
							new SelectorItemBasis("W_GE3000B_CT_TRACE_ON", "SIM"),
							/*" 88 W-:GE3000B:-CT-TRACE-DET-ON VALUE 'SIM' */
							new SelectorItemBasis("W_GE3000B_CT_TRACE_DET_ON", "SIM")
                }
        };

        /*"*/
    }
}