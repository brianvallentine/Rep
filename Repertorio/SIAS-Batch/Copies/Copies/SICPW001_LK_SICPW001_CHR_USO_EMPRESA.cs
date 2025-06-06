using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class SICPW001_LK_SICPW001_CHR_USO_EMPRESA : VarBasis
    {
        /*"       10 LKCPW001-EMP-SICOV-TXT1         PIC  X(40).*/
        public StringBasis LKCPW001_EMP_SICOV_TXT1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"       10 FILLER                          PIC  X(01).*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"       10 LKCPW001-EMP-SICOV-25           PIC  X(25).*/
        public StringBasis LKCPW001_EMP_SICOV_25 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"       10 FILLER                          PIC  X(01).*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"       10 LKCPW001-EMP-SICOV-TXT2         PIC  X(40).*/
        public StringBasis LKCPW001_EMP_SICOV_TXT2 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"       10 FILLER                          PIC  X(01).*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"       10 LKCPW001-EMP-SICOV-60           PIC  X(60).*/
        public StringBasis LKCPW001_EMP_SICOV_60 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"       10 FILLER                          PIC  X(32).*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
        /*"    05 LK-SICPW001-COD-DOC-SIACC          PIC  X(15).*/
    }
}