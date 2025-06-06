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
    public class LBGE8051 : VarBasis
    {
        /*"*/
        public IntBasis WS150 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS240 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WSSIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01 TABELA-COD-SIACC-150*/
        public LBGE8051_TABELA_COD_SIACC_150 TABELA_COD_SIACC_150 { get; set; } = new LBGE8051_TABELA_COD_SIACC_150();

        private _REDEF_LBGE8051_TABELA_COD_SIACC_150_R _tabela_cod_siacc_150_r { get; set; }
        public _REDEF_LBGE8051_TABELA_COD_SIACC_150_R TABELA_COD_SIACC_150_R
        {
            get { _tabela_cod_siacc_150_r = new _REDEF_LBGE8051_TABELA_COD_SIACC_150_R(); _.Move(TABELA_COD_SIACC_150, _tabela_cod_siacc_150_r); VarBasis.RedefinePassValue(TABELA_COD_SIACC_150, _tabela_cod_siacc_150_r, TABELA_COD_SIACC_150); _tabela_cod_siacc_150_r.ValueChanged += () => { _.Move(_tabela_cod_siacc_150_r, TABELA_COD_SIACC_150); }; return _tabela_cod_siacc_150_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_cod_siacc_150_r, TABELA_COD_SIACC_150); }
        }  //Redefines

        public LBGE8051_TABELA_COD_SIACC_240 TABELA_COD_SIACC_240 { get; set; } = new LBGE8051_TABELA_COD_SIACC_240();

        private _REDEF_LBGE8051_TABELA_COD_SIACC_240_R _tabela_cod_siacc_240_r { get; set; }
        public _REDEF_LBGE8051_TABELA_COD_SIACC_240_R TABELA_COD_SIACC_240_R
        {
            get { _tabela_cod_siacc_240_r = new _REDEF_LBGE8051_TABELA_COD_SIACC_240_R(); _.Move(TABELA_COD_SIACC_240, _tabela_cod_siacc_240_r); VarBasis.RedefinePassValue(TABELA_COD_SIACC_240, _tabela_cod_siacc_240_r, TABELA_COD_SIACC_240); _tabela_cod_siacc_240_r.ValueChanged += () => { _.Move(_tabela_cod_siacc_240_r, TABELA_COD_SIACC_240); }; return _tabela_cod_siacc_240_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_cod_siacc_240_r, TABELA_COD_SIACC_240); }
        }  //Redefines

        public LBGE8051_TABELA_COD_RETORNO_SIAS TABELA_COD_RETORNO_SIAS { get; set; } = new LBGE8051_TABELA_COD_RETORNO_SIAS();

        private _REDEF_LBGE8051_TABELA_COD_RETORNO_SIAS_R _tabela_cod_retorno_sias_r { get; set; }
        public _REDEF_LBGE8051_TABELA_COD_RETORNO_SIAS_R TABELA_COD_RETORNO_SIAS_R
        {
            get { _tabela_cod_retorno_sias_r = new _REDEF_LBGE8051_TABELA_COD_RETORNO_SIAS_R(); _.Move(TABELA_COD_RETORNO_SIAS, _tabela_cod_retorno_sias_r); VarBasis.RedefinePassValue(TABELA_COD_RETORNO_SIAS, _tabela_cod_retorno_sias_r, TABELA_COD_RETORNO_SIAS); _tabela_cod_retorno_sias_r.ValueChanged += () => { _.Move(_tabela_cod_retorno_sias_r, TABELA_COD_RETORNO_SIAS); }; return _tabela_cod_retorno_sias_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_cod_retorno_sias_r, TABELA_COD_RETORNO_SIAS); }
        }  //Redefines

    }
}