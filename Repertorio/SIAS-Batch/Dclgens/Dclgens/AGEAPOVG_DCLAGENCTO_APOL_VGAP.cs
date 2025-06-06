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
    public class AGEAPOVG_DCLAGENCTO_APOL_VGAP : VarBasis
    {
        /*"    10 AGEAPOVG-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis AGEAPOVG_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 AGEAPOVG-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis AGEAPOVG_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGEAPOVG-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis AGEAPOVG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGEAPOVG-COD-AGENCIADOR  PIC S9(9) USAGE COMP.*/
        public IntBasis AGEAPOVG_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AGEAPOVG-MATRIC-INDICADOR  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis AGEAPOVG_MATRIC_INDICADOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 AGEAPOVG-PERC-PAG-PARCELA  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis AGEAPOVG_PERC_PAG_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 AGEAPOVG-COD-PAG-ANGARIACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis AGEAPOVG_COD_PAG_ANGARIACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGEAPOVG-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis AGEAPOVG_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 AGEAPOVG-DATA-INCLUSAO  PIC X(10).*/
        public StringBasis AGEAPOVG_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AGEAPOVG-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis AGEAPOVG_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 AGEAPOVG-SITUACAO-AGENCTO  PIC X(1).*/
        public StringBasis AGEAPOVG_SITUACAO_AGENCTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 AGEAPOVG-COD-USUARIO  PIC X(8).*/
        public StringBasis AGEAPOVG_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 AGEAPOVG-TIMESTAMP   PIC X(26).*/
        public StringBasis AGEAPOVG_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}