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
    public class ORIGEAVI_DCLORIGEM_AVISO : VarBasis
    {
        /*"    10 ORIGEAVI-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis ORIGEAVI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ORIGEAVI-ORIGEM-AVISO  PIC S9(4) USAGE COMP.*/
        public IntBasis ORIGEAVI_ORIGEM_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ORIGEAVI-DESCRICAO-ORIGEM  PIC X(20).*/
        public StringBasis ORIGEAVI_DESCRICAO_ORIGEM { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 ORIGEAVI-NUMERO-CONTA  PIC S9(9) USAGE COMP.*/
        public IntBasis ORIGEAVI_NUMERO_CONTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ORIGEAVI-TIMESTAMP   PIC X(26).*/
        public StringBasis ORIGEAVI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}