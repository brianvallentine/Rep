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
    public class LBSI0005_TABELA_MENSAGENS : VarBasis
    {
        /*"  05         TAB-MENSAGENS*/
        public LBSI0005_TAB_MENSAGENS TAB_MENSAGENS { get; set; } = new LBSI0005_TAB_MENSAGENS();

        private _REDEF_LBSI0005_TAB_MENSAGENS_R _tab_mensagens_r { get; set; }
        public _REDEF_LBSI0005_TAB_MENSAGENS_R TAB_MENSAGENS_R
        {
            get { _tab_mensagens_r = new _REDEF_LBSI0005_TAB_MENSAGENS_R(); _.Move(TAB_MENSAGENS, _tab_mensagens_r); VarBasis.RedefinePassValue(TAB_MENSAGENS, _tab_mensagens_r, TAB_MENSAGENS); _tab_mensagens_r.ValueChanged += () => { _.Move(_tab_mensagens_r, TAB_MENSAGENS); }; return _tab_mensagens_r; }
            set { VarBasis.RedefinePassValue(value, _tab_mensagens_r, TAB_MENSAGENS); }
        }  //Redefines

    }
}