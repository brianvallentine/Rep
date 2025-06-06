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
    public class LBTB3101_TABELA_DE_FRANQUIAS : VarBasis
    {
        /*" 07 TABELA-FRANQUIAS*/
        public LBTB3101_TABELA_FRANQUIAS TABELA_FRANQUIAS { get; set; } = new LBTB3101_TABELA_FRANQUIAS();

        private _REDEF_LBTB3101_TABELA_FRANQUIAS_R _tabela_franquias_r { get; set; }
        public _REDEF_LBTB3101_TABELA_FRANQUIAS_R TABELA_FRANQUIAS_R
        {
            get { _tabela_franquias_r = new _REDEF_LBTB3101_TABELA_FRANQUIAS_R(); _.Move(TABELA_FRANQUIAS, _tabela_franquias_r); VarBasis.RedefinePassValue(TABELA_FRANQUIAS, _tabela_franquias_r, TABELA_FRANQUIAS); _tabela_franquias_r.ValueChanged += () => { _.Move(_tabela_franquias_r, TABELA_FRANQUIAS); }; return _tabela_franquias_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_franquias_r, TABELA_FRANQUIAS); }
        }  //Redefines

    }
}