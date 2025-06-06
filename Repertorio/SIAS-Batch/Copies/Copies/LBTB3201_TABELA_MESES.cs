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
    public class LBTB3201_TABELA_MESES : VarBasis
    {
        /*" 07     TAB-MESES*/
        public LBTB3201_TAB_MESES TAB_MESES { get; set; } = new LBTB3201_TAB_MESES();

        private _REDEF_LBTB3201_TAB_MESES_R _tab_meses_r { get; set; }
        public _REDEF_LBTB3201_TAB_MESES_R TAB_MESES_R
        {
            get { _tab_meses_r = new _REDEF_LBTB3201_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
            set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
        }  //Redefines

    }
}