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
    public class SPVG001V : VarBasis
    {
        /*"01  VG001-PROGRAMA                   PIC  X(08) VALUE 'SPBVG001'*/
        public StringBasis VG001_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SPBVG001");
        /*"01  VG001-IND-EXISTE                 PIC  X(01) VALUE 'N'*/
        public StringBasis VG001_IND_EXISTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"*/
    }
}