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
    public class SPVG001W_LK_VG001_S_DES_COMPLEMENTAR : VarBasis
    {
        /*" 49 LK-VG001-S-DES-COMPLEMENTAR-L         PIC S9(004) COMP*/
        public IntBasis LK_VG001_S_DES_COMPLEMENTAR_L { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 49 LK-VG001-S-DES-COMPLEMENTAR-T         PIC  X(1000)*/
        public StringBasis LK_VG001_S_DES_COMPLEMENTAR_T { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)"), @"");
        /*"01  LK-VG001-S-COD-USUARIO                PIC  X(008)*/
    }
}