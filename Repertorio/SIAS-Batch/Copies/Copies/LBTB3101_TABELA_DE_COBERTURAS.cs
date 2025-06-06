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
    public class LBTB3101_TABELA_DE_COBERTURAS : VarBasis
    {
        /*" 07     TABELA-COBERTURAS*/
        public LBTB3101_TABELA_COBERTURAS TABELA_COBERTURAS { get; set; } = new LBTB3101_TABELA_COBERTURAS();

        private _REDEF_LBTB3101_TABELA_COBERTURAS_R _tabela_coberturas_r { get; set; }
        public _REDEF_LBTB3101_TABELA_COBERTURAS_R TABELA_COBERTURAS_R
        {
            get { _tabela_coberturas_r = new _REDEF_LBTB3101_TABELA_COBERTURAS_R(); _.Move(TABELA_COBERTURAS, _tabela_coberturas_r); VarBasis.RedefinePassValue(TABELA_COBERTURAS, _tabela_coberturas_r, TABELA_COBERTURAS); _tabela_coberturas_r.ValueChanged += () => { _.Move(_tabela_coberturas_r, TABELA_COBERTURAS); }; return _tabela_coberturas_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_coberturas_r, TABELA_COBERTURAS); }
        }  //Redefines

    }
}