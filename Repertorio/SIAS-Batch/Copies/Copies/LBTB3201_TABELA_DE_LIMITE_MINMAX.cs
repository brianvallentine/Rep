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
    public class LBTB3201_TABELA_DE_LIMITE_MINMAX : VarBasis
    {
        /*" 07 TABELA-LIMITE-MINMAX*/
        public LBTB3201_TABELA_LIMITE_MINMAX TABELA_LIMITE_MINMAX { get; set; } = new LBTB3201_TABELA_LIMITE_MINMAX();

        private _REDEF_LBTB3201_TABELA_LIMITE_MINMAX_R _tabela_limite_minmax_r { get; set; }
        public _REDEF_LBTB3201_TABELA_LIMITE_MINMAX_R TABELA_LIMITE_MINMAX_R
        {
            get { _tabela_limite_minmax_r = new _REDEF_LBTB3201_TABELA_LIMITE_MINMAX_R(); _.Move(TABELA_LIMITE_MINMAX, _tabela_limite_minmax_r); VarBasis.RedefinePassValue(TABELA_LIMITE_MINMAX, _tabela_limite_minmax_r, TABELA_LIMITE_MINMAX); _tabela_limite_minmax_r.ValueChanged += () => { _.Move(_tabela_limite_minmax_r, TABELA_LIMITE_MINMAX); }; return _tabela_limite_minmax_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_limite_minmax_r, TABELA_LIMITE_MINMAX); }
        }  //Redefines

    }
}