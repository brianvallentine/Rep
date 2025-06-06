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
    public class LBTB3101_TABELA_DE_LIM_MINMAX_CCAT : VarBasis
    {
        /*" 07 TABELA-LIM-MINMAX-CCAT*/
        public LBTB3101_TABELA_LIM_MINMAX_CCAT TABELA_LIM_MINMAX_CCAT { get; set; } = new LBTB3101_TABELA_LIM_MINMAX_CCAT();

        private _REDEF_LBTB3101_FILLER_34 _filler_34 { get; set; }
        public _REDEF_LBTB3101_FILLER_34 FILLER_34
        {
            get { _filler_34 = new _REDEF_LBTB3101_FILLER_34(); _.Move(TABELA_LIM_MINMAX_CCAT, _filler_34); VarBasis.RedefinePassValue(TABELA_LIM_MINMAX_CCAT, _filler_34, TABELA_LIM_MINMAX_CCAT); _filler_34.ValueChanged += () => { _.Move(_filler_34, TABELA_LIM_MINMAX_CCAT); }; return _filler_34; }
            set { VarBasis.RedefinePassValue(value, _filler_34, TABELA_LIM_MINMAX_CCAT); }
        }  //Redefines

    }
}