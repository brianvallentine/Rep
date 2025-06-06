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
    public class LBTB3201_TABELA_DE_LIM_MINMAX_CCAT : VarBasis
    {
        /*" 07 TABELA-LIM-MINMAX-CCAT*/
        public LBTB3201_TABELA_LIM_MINMAX_CCAT TABELA_LIM_MINMAX_CCAT { get; set; } = new LBTB3201_TABELA_LIM_MINMAX_CCAT();

        private _REDEF_LBTB3201_FILLER_48 _filler_48 { get; set; }
        public _REDEF_LBTB3201_FILLER_48 FILLER_48
        {
            get { _filler_48 = new _REDEF_LBTB3201_FILLER_48(); _.Move(TABELA_LIM_MINMAX_CCAT, _filler_48); VarBasis.RedefinePassValue(TABELA_LIM_MINMAX_CCAT, _filler_48, TABELA_LIM_MINMAX_CCAT); _filler_48.ValueChanged += () => { _.Move(_filler_48, TABELA_LIM_MINMAX_CCAT); }; return _filler_48; }
            set { VarBasis.RedefinePassValue(value, _filler_48, TABELA_LIM_MINMAX_CCAT); }
        }  //Redefines

    }
}