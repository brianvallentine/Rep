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
    public class SIMOTIVO_DCLSI_MOTIVO : VarBasis
    {
        /*"    10 SIMOTIVO-NUM-MOTIVO  PIC S9(9) USAGE COMP.*/
        public IntBasis SIMOTIVO_NUM_MOTIVO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIMOTIVO-DES-MOTIVO.*/
        public SIMOTIVO_SIMOTIVO_DES_MOTIVO SIMOTIVO_DES_MOTIVO { get; set; } = new SIMOTIVO_SIMOTIVO_DES_MOTIVO();

        public IntBasis SIMOTIVO_COD_TIPO_MOTIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIMOTIVO-COD-EXTERNO  PIC X(20).*/
        public StringBasis SIMOTIVO_COD_EXTERNO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SIMOTIVO-STA-MOTIVO  PIC X(1).*/
        public StringBasis SIMOTIVO_STA_MOTIVO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIMOTIVO-COD-USUARIO  PIC X(8).*/
        public StringBasis SIMOTIVO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIMOTIVO-TIMESTAMP   PIC X(26).*/
        public StringBasis SIMOTIVO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}