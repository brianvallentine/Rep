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
    public class LBTB3201_TABELA_DE_LIMITE_MINMAX_CCAT : VarBasis
    {
        /*" 07 TABELA-LIMITE-MINMAX-CCAT*/
        public LBTB3201_TABELA_LIMITE_MINMAX_CCAT TABELA_LIMITE_MINMAX_CCAT { get; set; } = new LBTB3201_TABELA_LIMITE_MINMAX_CCAT();

        private _REDEF_LBTB3201_FILLER_49 _filler_49 { get; set; }
        public _REDEF_LBTB3201_FILLER_49 FILLER_49
        {
            get { _filler_49 = new _REDEF_LBTB3201_FILLER_49(); _.Move(TABELA_LIMITE_MINMAX_CCAT, _filler_49); VarBasis.RedefinePassValue(TABELA_LIMITE_MINMAX_CCAT, _filler_49, TABELA_LIMITE_MINMAX_CCAT); _filler_49.ValueChanged += () => { _.Move(_filler_49, TABELA_LIMITE_MINMAX_CCAT); }; return _filler_49; }
            set { VarBasis.RedefinePassValue(value, _filler_49, TABELA_LIMITE_MINMAX_CCAT); }
        }  //Redefines

    }
}