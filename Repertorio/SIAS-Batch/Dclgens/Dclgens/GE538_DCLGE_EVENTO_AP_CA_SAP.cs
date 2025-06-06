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
    public class GE538_DCLGE_EVENTO_AP_CA_SAP : VarBasis
    {
        /*"    10 GE538-COD-EMPRESA    PIC X(4).*/
        public StringBasis GE538_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE538-COD-SISTEMA    PIC X(2).*/
        public StringBasis GE538_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE538-COD-MODULO     PIC X(2).*/
        public StringBasis GE538_COD_MODULO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE538-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE538_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE538-COD-EVENTO     PIC X(10).*/
        public StringBasis GE538_COD_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE538-DES-EMPRESA    PIC X(40).*/
        public StringBasis GE538_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE538-DES-MODULO     PIC X(40).*/
        public StringBasis GE538_DES_MODULO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE538-DES-ORIGEM     PIC X(40).*/
        public StringBasis GE538_DES_ORIGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE538-DES-EVENTO     PIC X(40).*/
        public StringBasis GE538_DES_EVENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
    }
}