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
    public class LBSI505A : VarBasis
    {
        /*"01  W-TABELA*/
        public LBSI505A_W_TABELA W_TABELA { get; set; } = new LBSI505A_W_TABELA();

        private _REDEF_LBSI505A_FILLER_694 _filler_694 { get; set; }
        public _REDEF_LBSI505A_FILLER_694 FILLER_694
        {
            get { _filler_694 = new _REDEF_LBSI505A_FILLER_694(); _.Move(W_TABELA, _filler_694); VarBasis.RedefinePassValue(W_TABELA, _filler_694, W_TABELA); _filler_694.ValueChanged += () => { _.Move(_filler_694, W_TABELA); }; return _filler_694; }
            set { VarBasis.RedefinePassValue(value, _filler_694, W_TABELA); }
        }  //Redefines

        public IntBasis W_NUM_OCORR_TAB1 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"), 695);
        /*"*/
    }
}