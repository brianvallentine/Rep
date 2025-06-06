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
    public class LBTB3101_TABELA_DE_LIMITE_MINMAX_CCAT : VarBasis
    {
        /*" 07 TABELA-LIMITE-MINMAX-CCAT*/
        public LBTB3101_TABELA_LIMITE_MINMAX_CCAT TABELA_LIMITE_MINMAX_CCAT { get; set; } = new LBTB3101_TABELA_LIMITE_MINMAX_CCAT();

        private _REDEF_LBTB3101_FILLER_35 _filler_35 { get; set; }
        public _REDEF_LBTB3101_FILLER_35 FILLER_35
        {
            get { _filler_35 = new _REDEF_LBTB3101_FILLER_35(); _.Move(TABELA_LIMITE_MINMAX_CCAT, _filler_35); VarBasis.RedefinePassValue(TABELA_LIMITE_MINMAX_CCAT, _filler_35, TABELA_LIMITE_MINMAX_CCAT); _filler_35.ValueChanged += () => { _.Move(_filler_35, TABELA_LIMITE_MINMAX_CCAT); }; return _filler_35; }
            set { VarBasis.RedefinePassValue(value, _filler_35, TABELA_LIMITE_MINMAX_CCAT); }
        }  //Redefines

    }
}