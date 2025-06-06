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
    public class LBWPF004 : VarBasis
    {
        /*"01     W88-NUM-PROPOSTA                    PIC 9(014)*/
        public IntBasis W88_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"01     CANAL   REDEFINES W88-NUM-PROPOSTA*/
        private _REDEF_LBWPF004_CANAL _canal { get; set; }
        public _REDEF_LBWPF004_CANAL CANAL
        {
            get { _canal = new _REDEF_LBWPF004_CANAL(); _.Move(W88_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W88_NUM_PROPOSTA, _canal, W88_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W88_NUM_PROPOSTA); }; return _canal; }
            set { VarBasis.RedefinePassValue(value, _canal, W88_NUM_PROPOSTA); }
        }  //Redefines

    }
}