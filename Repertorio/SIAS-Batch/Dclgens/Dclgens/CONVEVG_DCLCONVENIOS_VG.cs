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
    public class CONVEVG_DCLCONVENIOS_VG : VarBasis
    {
        /*"    10 CONVEVG-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CONVEVG_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CONVEVG-CODSUBES     PIC S9(4) USAGE COMP.*/
        public IntBasis CONVEVG_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVEVG-COD-SEGURO   PIC S9(4) USAGE COMP.*/
        public IntBasis CONVEVG_COD_SEGURO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVEVG-COD-AJUSTE   PIC S9(4) USAGE COMP.*/
        public IntBasis CONVEVG_COD_AJUSTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVEVG-COD-COMISSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONVEVG_COD_COMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVEVG-COD-NAOACEITE  PIC S9(4) USAGE COMP.*/
        public IntBasis CONVEVG_COD_NAOACEITE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVEVG-CODUSU       PIC X(8).*/
        public StringBasis CONVEVG_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CONVEVG-TIMESTAMP    PIC X(26).*/
        public StringBasis CONVEVG_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CONVEVG-COD-CONV-CARTAO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONVEVG_COD_CONV_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}