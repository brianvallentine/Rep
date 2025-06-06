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
    public class VATBFREN_VATBFREN_TABELA_FAIXA_RENDA : VarBasis
    {
        /*"    03   VATBFREN-LIM-OCOR              PIC 9(001) VALUE 05*/
        public IntBasis VATBFREN_LIM_OCOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 05);
        /*"    03   VATBFREN-IND                   PIC 9(001)*/
        public IntBasis VATBFREN_IND { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    03   VATBFREN-TB-REND-IND*/
        public VATBFREN_VATBFREN_TB_REND_IND VATBFREN_TB_REND_IND { get; set; } = new VATBFREN_VATBFREN_TB_REND_IND();

        private _REDEF_VATBFREN_FILLER_4 _filler_4 { get; set; }
        public _REDEF_VATBFREN_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_VATBFREN_FILLER_4(); _.Move(VATBFREN_TB_REND_IND, _filler_4); VarBasis.RedefinePassValue(VATBFREN_TB_REND_IND, _filler_4, VATBFREN_TB_REND_IND); _filler_4.ValueChanged += () => { _.Move(_filler_4, VATBFREN_TB_REND_IND); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, VATBFREN_TB_REND_IND); }
        }  //Redefines

    }
}