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
    public class VG092_DCLVG_COMPL_CLI_EMP : VarBasis
    {
        /*"    10 VG092-COD-CLIENTE    PIC S9(9) USAGE COMP.*/
        public IntBasis VG092_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG092-DTA-FAT-ANUAL  PIC X(10).*/
        public StringBasis VG092_DTA_FAT_ANUAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG092-VLR-FAT-ANUAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG092_VLR_FAT_ANUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG092-DTA-CONSTITUICAO       PIC X(10).*/
        public StringBasis VG092_DTA_CONSTITUICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG092-COD-CNAE-ATIVIDADE       PIC X(7).*/
        public StringBasis VG092_COD_CNAE_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "7", "X(7)."), @"");
        /*"*/
    }
}