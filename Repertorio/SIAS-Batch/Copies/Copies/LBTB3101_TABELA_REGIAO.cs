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
    public class LBTB3101_TABELA_REGIAO : VarBasis
    {
        /*" 07     TAB-REGIAO*/
        public LBTB3101_TAB_REGIAO TAB_REGIAO { get; set; } = new LBTB3101_TAB_REGIAO();

        private _REDEF_LBTB3101_TAB_REGIAO_R _tab_regiao_r { get; set; }
        public _REDEF_LBTB3101_TAB_REGIAO_R TAB_REGIAO_R
        {
            get { _tab_regiao_r = new _REDEF_LBTB3101_TAB_REGIAO_R(); _.Move(TAB_REGIAO, _tab_regiao_r); VarBasis.RedefinePassValue(TAB_REGIAO, _tab_regiao_r, TAB_REGIAO); _tab_regiao_r.ValueChanged += () => { _.Move(_tab_regiao_r, TAB_REGIAO); }; return _tab_regiao_r; }
            set { VarBasis.RedefinePassValue(value, _tab_regiao_r, TAB_REGIAO); }
        }  //Redefines

    }
}