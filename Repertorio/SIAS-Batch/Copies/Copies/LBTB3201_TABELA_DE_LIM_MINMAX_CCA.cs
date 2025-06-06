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
    public class LBTB3201_TABELA_DE_LIM_MINMAX_CCA : VarBasis
    {
        /*" 07 TABELA-LIM-MINMAX-CCA*/
        public LBTB3201_TABELA_LIM_MINMAX_CCA TABELA_LIM_MINMAX_CCA { get; set; } = new LBTB3201_TABELA_LIM_MINMAX_CCA();

        private _REDEF_LBTB3201_FILLER_42 _filler_42 { get; set; }
        public _REDEF_LBTB3201_FILLER_42 FILLER_42
        {
            get { _filler_42 = new _REDEF_LBTB3201_FILLER_42(); _.Move(TABELA_LIM_MINMAX_CCA, _filler_42); VarBasis.RedefinePassValue(TABELA_LIM_MINMAX_CCA, _filler_42, TABELA_LIM_MINMAX_CCA); _filler_42.ValueChanged += () => { _.Move(_filler_42, TABELA_LIM_MINMAX_CCA); }; return _filler_42; }
            set { VarBasis.RedefinePassValue(value, _filler_42, TABELA_LIM_MINMAX_CCA); }
        }  //Redefines

    }
}