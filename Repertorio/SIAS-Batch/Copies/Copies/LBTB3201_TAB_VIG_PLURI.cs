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
    public class LBTB3201_TAB_VIG_PLURI : VarBasis
    {
        /*"  10   FILLER      PIC X(047) VALUE '00 10 2021-12-31'*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 10 2021-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 20 2022-12-31'*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 20 2022-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 30 2023-12-31'*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 30 2023-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 40 2024-12-31'*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 40 2024-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 50 2025-12-31'*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 50 2025-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 60 2026-12-31'*/
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 60 2026-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 70 2027-12-31'*/
        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 70 2027-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 80 2028-12-31'*/
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 80 2028-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 90 2029-12-31'*/
        public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 90 2029-12-31");
        /*"  10   FILLER      PIC X(047) VALUE '00 99 2030-12-31'*/
        public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"00 99 2030-12-31");
        /*" 07     TAB-VIG-PLURI-R   REDEFINES TAB-VIG-PLURI*/
    }
}