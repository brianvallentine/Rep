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
    public class SICPW001_LK_SICPW001_FAVORECIDO : VarBasis
    {
        /*"       10 LK-SICPW001-NOME-FAVORECIDO     PIC  X(30).*/
        public StringBasis LK_SICPW001_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"       10 LK-SICPW001-NUM-DOC-EMPRESA     PIC  9(06).*/
        public IntBasis LK_SICPW001_NUM_DOC_EMPRESA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
        /*"       10 LK-SICPW001-FILLER1             PIC  X(04).*/
        public StringBasis LK_SICPW001_FILLER1 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
        /*"    05 LK-SICPW001-DES-LOGRADOURO         PIC  X(30).*/
    }
}