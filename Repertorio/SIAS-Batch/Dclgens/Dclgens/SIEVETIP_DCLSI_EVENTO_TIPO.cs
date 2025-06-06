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
    public class SIEVETIP_DCLSI_EVENTO_TIPO : VarBasis
    {
        /*"    10 SIEVETIP-COD-EVENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIEVETIP_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIEVETIP-DESCR-EVENTO       PIC X(40).*/
        public StringBasis SIEVETIP_DESCR_EVENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SIEVETIP-SIGLA-EVENTO       PIC X(15).*/
        public StringBasis SIEVETIP_SIGLA_EVENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 SIEVETIP-IND-SINISTRO-ACOMP       PIC X(1).*/
        public StringBasis SIEVETIP_IND_SINISTRO_ACOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIEVETIP-IND-DOCUMENT-ACOMP       PIC X(1).*/
        public StringBasis SIEVETIP_IND_DOCUMENT_ACOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIEVETIP-IND-CARTA-ACOMP       PIC X(1).*/
        public StringBasis SIEVETIP_IND_CARTA_ACOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIEVETIP-COD-USUARIO       PIC X(8).*/
        public StringBasis SIEVETIP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIEVETIP-TIMESTAMP   PIC X(26).*/
        public StringBasis SIEVETIP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIEVETIP-IND-GERA-EVENTO       PIC X(1).*/
        public StringBasis SIEVETIP_IND_GERA_EVENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIEVETIP-COD-TIPO-CARTA       PIC S9(9) USAGE COMP.*/
        public IntBasis SIEVETIP_COD_TIPO_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIEVETIP-COD-DOCUMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SIEVETIP_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIEVETIP-COD-GRUPO-EVENTO       PIC X(2).*/
        public StringBasis SIEVETIP_COD_GRUPO_EVENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SIEVETIP-COD-EVENTO-EXT       PIC S9(4) USAGE COMP.*/
        public IntBasis SIEVETIP_COD_EVENTO_EXT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}