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
    public class MRPROQUE_MRPROQUE_DES_COMPLEMENTO : VarBasis
    {
        /*"       49 MRPROQUE-DES-COMPLEMENTO-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROQUE_DES_COMPLEMENTO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 MRPROQUE-DES-COMPLEMENTO-TEXT  PIC X(200).*/
        public StringBasis MRPROQUE_DES_COMPLEMENTO_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"    10 MRPROQUE-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
    }
}