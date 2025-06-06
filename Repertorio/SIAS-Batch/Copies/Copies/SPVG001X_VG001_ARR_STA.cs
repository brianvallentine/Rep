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
    public class SPVG001X_VG001_ARR_STA : VarBasis
    {
        /*"  10 VG001-ARR-STA-00                PIC  X(005) VALUE '014B'*/
        public StringBasis VG001_ARR_STA_00 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"014B");
        /*"  10 VG001-ARR-STA-01                PIC  X(005) VALUE '102'*/
        public StringBasis VG001_ARR_STA_01 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"102");
        /*"  10 VG001-ARR-STA-02                PIC  X(005) VALUE '201'*/
        public StringBasis VG001_ARR_STA_02 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"201");
        /*"  10 VG001-ARR-STA-03                PIC  X(005) VALUE '33'*/
        public StringBasis VG001_ARR_STA_03 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"33");
        /*"  10 VG001-ARR-STA-04                PIC  X(005) VALUE '405'*/
        public StringBasis VG001_ARR_STA_04 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"405");
        /*"  10 VG001-ARR-STA-05                PIC  X(005) VALUE '504'*/
        public StringBasis VG001_ARR_STA_05 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"504");
        /*"  10 VG001-ARR-STA-06                PIC  X(005) VALUE '66'*/
        public StringBasis VG001_ARR_STA_06 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"66");
        /*"  10 VG001-ARR-STA-07                PIC  X(005) VALUE '77'*/
        public StringBasis VG001_ARR_STA_07 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"77");
        /*"  10 VG001-ARR-STA-08                PIC  X(005) VALUE '88'*/
        public StringBasis VG001_ARR_STA_08 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"88");
        /*"  10 VG001-ARR-STA-09                PIC  X(005) VALUE '99'*/
        public StringBasis VG001_ARR_STA_09 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"99");
        /*"  10 VG001-ARR-STA-A                 PIC  X(005) VALUE 'AA'*/
        public StringBasis VG001_ARR_STA_A { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"AA");
        /*"  10 VG001-ARR-STA-B                 PIC  X(005) VALUE 'BB'*/
        public StringBasis VG001_ARR_STA_B { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"BB");
        /*" 05  FILLER                REDEFINES VG001-ARR-STA*/
    }
}