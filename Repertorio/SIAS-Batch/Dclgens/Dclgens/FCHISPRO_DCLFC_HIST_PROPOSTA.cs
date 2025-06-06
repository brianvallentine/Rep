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
    public class FCHISPRO_DCLFC_HIST_PROPOSTA : VarBasis
    {
        /*"    10 FCHISPRO-NUM-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis FCHISPRO_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCHISPRO-NUM-PROPOSTA  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FCHISPRO_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FCHISPRO-NUM-NSA     PIC S9(9) USAGE COMP.*/
        public IntBasis FCHISPRO_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCHISPRO-DTH-REGISTRO  PIC X(10).*/
        public StringBasis FCHISPRO_DTH_REGISTRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCHISPRO-HRS-REGISTRO  PIC X(8).*/
        public StringBasis FCHISPRO_HRS_REGISTRO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FCHISPRO-IDE-USUARIO  PIC S9(4) USAGE COMP.*/
        public IntBasis FCHISPRO_IDE_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCHISPRO-COD-OPERACAO  PIC X(4).*/
        public StringBasis FCHISPRO_COD_OPERACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 FCHISPRO-DES-MSG-ORIGEM  PIC X(56).*/
        public StringBasis FCHISPRO_DES_MSG_ORIGEM { get; set; } = new StringBasis(new PIC("X", "56", "X(56)."), @"");
        /*"    10 FCHISPRO-DES-MSG-DESTINO  PIC X(56).*/
        public StringBasis FCHISPRO_DES_MSG_DESTINO { get; set; } = new StringBasis(new PIC("X", "56", "X(56)."), @"");
        /*"*/
    }
}