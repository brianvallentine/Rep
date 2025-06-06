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
    public class SX017_DCLSX_PRODUTO : VarBasis
    {
        /*"    10 SX017-COD-PRODUTO    PIC S9(9) USAGE COMP.*/
        public IntBasis SX017_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX017-NUM-RAMO       PIC S9(4) USAGE COMP.*/
        public IntBasis SX017_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX017-COD-GRUPO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis SX017_COD_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX017-NUM-LINHA-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SX017_NUM_LINHA_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX017-DES-PRODUTO.*/
        public SX017_SX017_DES_PRODUTO SX017_DES_PRODUTO { get; set; } = new SX017_SX017_DES_PRODUTO();

        public StringBasis SX017_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX017-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis SX017_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX017-COD-INT-RAMO   PIC S9(4) USAGE COMP.*/
        public IntBasis SX017_COD_INT_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX017-IND-EMITE-KIT  PIC X(1).*/
        public StringBasis SX017_IND_EMITE_KIT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX017-NUM-PROCESSO-SUSEP       PIC X(25).*/
        public StringBasis SX017_NUM_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 SX017-IND-SFH        PIC X(1).*/
        public StringBasis SX017_IND_SFH { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX017-DTA-CADASTRAMENTO       PIC X(10).*/
        public StringBasis SX017_DTA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
    }
}