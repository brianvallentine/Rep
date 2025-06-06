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
    public class GETPMOIM_DCLGE_TP_MORAD_IMOVEL : VarBasis
    {
        /*"    10 GETPMOIM-NUM-TP-MORA-IMOVEL  PIC S9(4) USAGE COMP.*/
        public IntBasis GETPMOIM_NUM_TP_MORA_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GETPMOIM-DES-TP-MORA-IMOVEL  PIC X(30).*/
        public StringBasis GETPMOIM_DES_TP_MORA_IMOVEL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GETPMOIM-STA-TP-MORA-IMOVEL  PIC X(1).*/
        public StringBasis GETPMOIM_STA_TP_MORA_IMOVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GETPMOIM-COD-USUARIO  PIC X(8).*/
        public StringBasis GETPMOIM_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GETPMOIM-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis GETPMOIM_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}