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
    public class EF083_DCLEF_IMOVEL : VarBasis
    {
        /*"    10 EF083-NUM-CONTRATO-SEGUR  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF083_NUM_CONTRATO_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF083-COD-TIPO-OBJ-SEG  PIC S9(4) USAGE COMP.*/
        public IntBasis EF083_COD_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF083-SEQ-TIPO-OBJ-SEG  PIC S9(4) USAGE COMP.*/
        public IntBasis EF083_SEQ_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF083-NUM-CEP        PIC S9(9) USAGE COMP.*/
        public IntBasis EF083_NUM_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF083-DES-ENDERECO   PIC X(40).*/
        public StringBasis EF083_DES_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 EF083-DES-COMPL-ENDERECO  PIC X(40).*/
        public StringBasis EF083_DES_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 EF083-IND-TIPO-IMOVEL  PIC X(1).*/
        public StringBasis EF083_IND_TIPO_IMOVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF083-NOM-BAIRRO     PIC X(40).*/
        public StringBasis EF083_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 EF083-NOM-CIDADE     PIC X(40).*/
        public StringBasis EF083_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 EF083-COD-UF         PIC X(2).*/
        public StringBasis EF083_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}