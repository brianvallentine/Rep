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
    public class ADPROGRA_DCLAD_PROGRAMA : VarBasis
    {
        /*"    10 ADPROGRA-NOM-PROGRAMA       PIC X(8).*/
        public StringBasis ADPROGRA_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ADPROGRA-DTH-INCLUSAO       PIC X(10).*/
        public StringBasis ADPROGRA_DTH_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ADPROGRA-DTH-COMPILACAO       PIC X(10).*/
        public StringBasis ADPROGRA_DTH_COMPILACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ADPROGRA-IND-PROGRAMA       PIC S9(4) USAGE COMP.*/
        public IntBasis ADPROGRA_IND_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ADPROGRA-STA-DCLGEN  PIC X(1).*/
        public StringBasis ADPROGRA_STA_DCLGEN { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ADPROGRA-STA-AMBIENTE       PIC X(1).*/
        public StringBasis ADPROGRA_STA_AMBIENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ADPROGRA-DES-PROGRAMA       PIC X(60).*/
        public StringBasis ADPROGRA_DES_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 ADPROGRA-COD-USUARIO       PIC X(8).*/
        public StringBasis ADPROGRA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ADPROGRA-DTH-TIMESTAMP       PIC X(26).*/
        public StringBasis ADPROGRA_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 ADPROGRA-STA-PROGRAMA       PIC X(1).*/
        public StringBasis ADPROGRA_STA_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}