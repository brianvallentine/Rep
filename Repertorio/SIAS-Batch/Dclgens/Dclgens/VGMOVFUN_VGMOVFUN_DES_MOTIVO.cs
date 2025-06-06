using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class VGMOVFUN_VGMOVFUN_DES_MOTIVO : VarBasis
    {
        /*"       49 VGMOVFUN-DES-MOTIVO-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis VGMOVFUN_DES_MOTIVO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VGMOVFUN-DES-MOTIVO-TEXT  PIC X(60).*/
        public StringBasis VGMOVFUN_DES_MOTIVO_TEXT { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 VGMOVFUN-NUM-DDD     PIC S9(4) USAGE COMP.*/
    }
}