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
    public class GEDOCTIP_DCLGE_DOCUMENTO_TIPO : VarBasis
    {
        /*"    10 GEDOCTIP-COD-DOCUMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEDOCTIP_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEDOCTIP-DESCR-DOCUMENTO  PIC X(60).*/
        public StringBasis GEDOCTIP_DESCR_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GEDOCTIP-SIGLA-DOCUMENTO  PIC X(30).*/
        public StringBasis GEDOCTIP_SIGLA_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GEDOCTIP-COD-USUARIO  PIC X(8).*/
        public StringBasis GEDOCTIP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEDOCTIP-TIMESTAMP   PIC X(26).*/
        public StringBasis GEDOCTIP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GEDOCTIP-STA-GERA-CHECKLIST  PIC X(1).*/
        public StringBasis GEDOCTIP_STA_GERA_CHECKLIST { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}