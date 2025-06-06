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
    public class COMFEDCA_DCLCOMUNIC_FED_CAP_VA : VarBasis
    {
        /*"    10 COMFEDCA-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis COMFEDCA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COMFEDCA-SITUACAO    PIC X(1).*/
        public StringBasis COMFEDCA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COMFEDCA-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis COMFEDCA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COMFEDCA-TIMESTAMP   PIC X(26).*/
        public StringBasis COMFEDCA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}