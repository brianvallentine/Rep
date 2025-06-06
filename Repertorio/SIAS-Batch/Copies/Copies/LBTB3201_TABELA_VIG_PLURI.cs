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
    public class LBTB3201_TABELA_VIG_PLURI : VarBasis
    {
        /*" 07     TAB-VIG-PLURI*/
        public LBTB3201_TAB_VIG_PLURI TAB_VIG_PLURI { get; set; } = new LBTB3201_TAB_VIG_PLURI();

        private _REDEF_LBTB3201_TAB_VIG_PLURI_R _tab_vig_pluri_r { get; set; }
        public _REDEF_LBTB3201_TAB_VIG_PLURI_R TAB_VIG_PLURI_R
        {
            get { _tab_vig_pluri_r = new _REDEF_LBTB3201_TAB_VIG_PLURI_R(); _.Move(TAB_VIG_PLURI, _tab_vig_pluri_r); VarBasis.RedefinePassValue(TAB_VIG_PLURI, _tab_vig_pluri_r, TAB_VIG_PLURI); _tab_vig_pluri_r.ValueChanged += () => { _.Move(_tab_vig_pluri_r, TAB_VIG_PLURI); }; return _tab_vig_pluri_r; }
            set { VarBasis.RedefinePassValue(value, _tab_vig_pluri_r, TAB_VIG_PLURI); }
        }  //Redefines

    }
}