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
    public class LXFPF024_REG_TIPO_B : VarBasis
    {
        /*"    10    R24-TIPO-REG                 PIC  X(001)*/
        public StringBasis R24_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10    R24-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R24_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"    10    R24-TIPO-INFORMACAO          PIC  9(002)*/
        public IntBasis R24_TIPO_INFORMACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10    R24-INFO                     PIC  X(283)*/
        public StringBasis R24_INFO { get; set; } = new StringBasis(new PIC("X", "283", "X(283)"), @"");
        /*"    10    R24-INFO-R REDEFINES R24-INFO*/
        private _REDEF_LXFPF024_R24_INFO_R _r24_info_r { get; set; }
        public _REDEF_LXFPF024_R24_INFO_R R24_INFO_R
        {
            get { _r24_info_r = new _REDEF_LXFPF024_R24_INFO_R(); _.Move(R24_INFO, _r24_info_r); VarBasis.RedefinePassValue(R24_INFO, _r24_info_r, R24_INFO); _r24_info_r.ValueChanged += () => { _.Move(_r24_info_r, R24_INFO); }; return _r24_info_r; }
            set { VarBasis.RedefinePassValue(value, _r24_info_r, R24_INFO); }
        }  //Redefines

        private _REDEF_LXFPF024_R24_INFO_R2 _r24_info_r2 { get; set; }
        public _REDEF_LXFPF024_R24_INFO_R2 R24_INFO_R2
        {
            get { _r24_info_r2 = new _REDEF_LXFPF024_R24_INFO_R2(); _.Move(R24_INFO, _r24_info_r2); VarBasis.RedefinePassValue(R24_INFO, _r24_info_r2, R24_INFO); _r24_info_r2.ValueChanged += () => { _.Move(_r24_info_r2, R24_INFO); }; return _r24_info_r2; }
            set { VarBasis.RedefinePassValue(value, _r24_info_r2, R24_INFO); }
        }  //Redefines

    }
}