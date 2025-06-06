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
    public class BENPROPZ_DCLBENEF_PROP_AZUL : VarBasis
    {
        /*"    10 NUM-PROPOSTA-AZUL    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_PROPOSTA_AZUL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COD-AGENCIA-LOTE     PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGENCIA_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DATA-LOTE            PIC S9(9) USAGE COMP.*/
        public IntBasis DATA_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-LOTE             PIC S9(4) USAGE COMP.*/
        public IntBasis NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-SEQ-LOTE         PIC S9(4) USAGE COMP.*/
        public IntBasis NUM_SEQ_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-BENEFICIARIO     PIC S9(4) USAGE COMP.*/
        public IntBasis NUM_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NOME-BENEFICIARIO    PIC X(40).*/
        public StringBasis NOME_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GRAU-PARENTESCO      PIC X(10).*/
        public StringBasis GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PCT-PART-BENEFICIA   PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PCT_PART_BENEFICIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 DATA-NASCIMENTO      PIC X(10).*/
        public StringBasis DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}