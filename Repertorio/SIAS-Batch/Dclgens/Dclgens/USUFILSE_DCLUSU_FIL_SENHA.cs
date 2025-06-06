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
    public class USUFILSE_DCLUSU_FIL_SENHA : VarBasis
    {
        /*"    10 USUFILSE-COD-CO      PIC X(2).*/
        public StringBasis USUFILSE_COD_CO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 USUFILSE-FONTE       PIC S9(4) USAGE COMP.*/
        public IntBasis USUFILSE_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 USUFILSE-CODUSU      PIC X(8).*/
        public StringBasis USUFILSE_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 USUFILSE-SENHA       PIC X(8).*/
        public StringBasis USUFILSE_SENHA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 USUFILSE-NIVEL-AUTORIZACAO       PIC X(1).*/
        public StringBasis USUFILSE_NIVEL_AUTORIZACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 USUFILSE-TIPO-FUNCAO       PIC X(30).*/
        public StringBasis USUFILSE_TIPO_FUNCAO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 USUFILSE-TIMESTAMP   PIC X(26).*/
        public StringBasis USUFILSE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 USUFILSE-SITUACAO    PIC X(1).*/
        public StringBasis USUFILSE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 USUFILSE-DES-DEMANDA       PIC X(8).*/
        public StringBasis USUFILSE_DES_DEMANDA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 USUFILSE-COD-DEMANDA       PIC S9(8)V USAGE COMP-3.*/
        public DoubleBasis USUFILSE_COD_DEMANDA { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V"), 0);
        /*"    10 USUFILSE-IND-AMBIENTE       PIC X(1).*/
        public StringBasis USUFILSE_IND_AMBIENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}