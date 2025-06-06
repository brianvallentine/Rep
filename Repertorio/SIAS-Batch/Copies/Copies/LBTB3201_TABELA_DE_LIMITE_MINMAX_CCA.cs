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
    public class LBTB3201_TABELA_DE_LIMITE_MINMAX_CCA : VarBasis
    {
        /*" 07 TABELA-LIMITE-MINMAX-CCA*/
        public LBTB3201_TABELA_LIMITE_MINMAX_CCA TABELA_LIMITE_MINMAX_CCA { get; set; } = new LBTB3201_TABELA_LIMITE_MINMAX_CCA();

        private _REDEF_LBTB3201_FILLER_43 _filler_43 { get; set; }
        public _REDEF_LBTB3201_FILLER_43 FILLER_43
        {
            get { _filler_43 = new _REDEF_LBTB3201_FILLER_43(); _.Move(TABELA_LIMITE_MINMAX_CCA, _filler_43); VarBasis.RedefinePassValue(TABELA_LIMITE_MINMAX_CCA, _filler_43, TABELA_LIMITE_MINMAX_CCA); _filler_43.ValueChanged += () => { _.Move(_filler_43, TABELA_LIMITE_MINMAX_CCA); }; return _filler_43; }
            set { VarBasis.RedefinePassValue(value, _filler_43, TABELA_LIMITE_MINMAX_CCA); }
        }  //Redefines

    }
}