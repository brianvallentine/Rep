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
    public class RSGEWERR : VarBasis
    {
        /*"01 LK-ERRO-DB2                     PIC  X(11138)*/
        public StringBasis LK_ERRO_DB2 { get; set; } = new StringBasis(new PIC("X", "11138", "X(11138)"), @"");
        /*"01 LKERR-REG                      REDEFINES LK-ERRO-DB2*/
        private _REDEF_RSGEWERR_LKERR_REG _lkerr_reg { get; set; }
        public _REDEF_RSGEWERR_LKERR_REG LKERR_REG
        {
            get { _lkerr_reg = new _REDEF_RSGEWERR_LKERR_REG(); _.Move(LK_ERRO_DB2, _lkerr_reg); VarBasis.RedefinePassValue(LK_ERRO_DB2, _lkerr_reg, LK_ERRO_DB2); _lkerr_reg.ValueChanged += () => { _.Move(_lkerr_reg, LK_ERRO_DB2); }; return _lkerr_reg; }
            set { VarBasis.RedefinePassValue(value, _lkerr_reg, LK_ERRO_DB2); }
        }  //Redefines

    }
}