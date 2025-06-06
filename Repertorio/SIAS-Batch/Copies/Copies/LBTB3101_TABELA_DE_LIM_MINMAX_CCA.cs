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
    public class LBTB3101_TABELA_DE_LIM_MINMAX_CCA : VarBasis
    {
        /*" 07 TABELA-LIM-MINMAX-CCA*/
        public LBTB3101_TABELA_LIM_MINMAX_CCA TABELA_LIM_MINMAX_CCA { get; set; } = new LBTB3101_TABELA_LIM_MINMAX_CCA();

        private _REDEF_LBTB3101_FILLER_28 _filler_28 { get; set; }
        public _REDEF_LBTB3101_FILLER_28 FILLER_28
        {
            get { _filler_28 = new _REDEF_LBTB3101_FILLER_28(); _.Move(TABELA_LIM_MINMAX_CCA, _filler_28); VarBasis.RedefinePassValue(TABELA_LIM_MINMAX_CCA, _filler_28, TABELA_LIM_MINMAX_CCA); _filler_28.ValueChanged += () => { _.Move(_filler_28, TABELA_LIM_MINMAX_CCA); }; return _filler_28; }
            set { VarBasis.RedefinePassValue(value, _filler_28, TABELA_LIM_MINMAX_CCA); }
        }  //Redefines

    }
}