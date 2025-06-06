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
    public class NUMERAES_DCLNUMERO_AES : VarBasis
    {
        /*"    10 NUMERAES-ORGAO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis NUMERAES_ORGAO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUMERAES-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis NUMERAES_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUMERAES-SEQ-APOLICE  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_SEQ_APOLICE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-ENDOS-COBRANCA  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_ENDOS_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-ENDOS-CANCELA  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_ENDOS_CANCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-ENDOS-RESTITUICAO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_ENDOS_RESTITUICAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-ENDOS-SEM-MOVIMEN  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_ENDOS_SEM_MOVIMEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-ENDOS-CANC-RESTI  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_ENDOS_CANC_RESTI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-ENDOS-MOV-CONTAB  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_ENDOS_MOV_CONTAB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-SEQ-SINISTRO  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_SEQ_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-NUM-PROP-AUTOMAT  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_NUM_PROP_AUTOMAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis NUMERAES_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUMERAES-TIMESTAMP   PIC X(26).*/
        public StringBasis NUMERAES_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}