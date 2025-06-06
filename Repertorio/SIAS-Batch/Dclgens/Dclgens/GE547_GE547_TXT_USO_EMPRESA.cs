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
    public class GE547_GE547_TXT_USO_EMPRESA : VarBasis
    {
        /*"       49 GE547-TXT-USO-EMPRESA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE547_TXT_USO_EMPRESA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE547-TXT-USO-EMPRESA-TEXT          PIC X(200).*/
        public StringBasis GE547_TXT_USO_EMPRESA_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"    10 GE547-VLR-ATUALIZA-MONETARIA       PIC S9(13)V9(2) USAGE COMP-3.*/
    }
}