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
    public class LBTB3101_TABELA_DE_LIM_MINMAX : VarBasis
    {
        /*" 07 TABELA-LIM-MINMAX*/
        public LBTB3101_TABELA_LIM_MINMAX TABELA_LIM_MINMAX { get; set; } = new LBTB3101_TABELA_LIM_MINMAX();

        private _REDEF_LBTB3101_TABELA_LIM_MINMAX_R _tabela_lim_minmax_r { get; set; }
        public _REDEF_LBTB3101_TABELA_LIM_MINMAX_R TABELA_LIM_MINMAX_R
        {
            get { _tabela_lim_minmax_r = new _REDEF_LBTB3101_TABELA_LIM_MINMAX_R(); _.Move(TABELA_LIM_MINMAX, _tabela_lim_minmax_r); VarBasis.RedefinePassValue(TABELA_LIM_MINMAX, _tabela_lim_minmax_r, TABELA_LIM_MINMAX); _tabela_lim_minmax_r.ValueChanged += () => { _.Move(_tabela_lim_minmax_r, TABELA_LIM_MINMAX); }; return _tabela_lim_minmax_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_lim_minmax_r, TABELA_LIM_MINMAX); }
        }  //Redefines

    }
}