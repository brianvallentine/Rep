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
    public class LBTB3101_TABELA_DE_LIMITE_MINMAX_CCA : VarBasis
    {
        /*" 07 TABELA-LIMITE-MINMAX-CCA*/
        public LBTB3101_TABELA_LIMITE_MINMAX_CCA TABELA_LIMITE_MINMAX_CCA { get; set; } = new LBTB3101_TABELA_LIMITE_MINMAX_CCA();

        private _REDEF_LBTB3101_FILLER_29 _filler_29 { get; set; }
        public _REDEF_LBTB3101_FILLER_29 FILLER_29
        {
            get { _filler_29 = new _REDEF_LBTB3101_FILLER_29(); _.Move(TABELA_LIMITE_MINMAX_CCA, _filler_29); VarBasis.RedefinePassValue(TABELA_LIMITE_MINMAX_CCA, _filler_29, TABELA_LIMITE_MINMAX_CCA); _filler_29.ValueChanged += () => { _.Move(_filler_29, TABELA_LIMITE_MINMAX_CCA); }; return _filler_29; }
            set { VarBasis.RedefinePassValue(value, _filler_29, TABELA_LIMITE_MINMAX_CCA); }
        }  //Redefines

    }
}