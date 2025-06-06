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
    public class GECARPAR_DCLGE_CARTA_PARAMETRO : VarBasis
    {
        /*"    10 GECARPAR-COD-TIPO-CARTA  PIC S9(9) USAGE COMP.*/
        public IntBasis GECARPAR_COD_TIPO_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECARPAR-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis GECARPAR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECARPAR-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis GECARPAR_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECARPAR-COD-CLASSE  PIC S9(4) USAGE COMP.*/
        public IntBasis GECARPAR_COD_CLASSE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECARPAR-DATA-INIVIG-CARPAR  PIC X(10).*/
        public StringBasis GECARPAR_DATA_INIVIG_CARPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GECARPAR-DATA-TERVIG-CARPAR  PIC X(10).*/
        public StringBasis GECARPAR_DATA_TERVIG_CARPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GECARPAR-PRAZO-REITERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis GECARPAR_PRAZO_REITERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECARPAR-COD-USUARIO  PIC X(8).*/
        public StringBasis GECARPAR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GECARPAR-TIMESTAMP   PIC X(26).*/
        public StringBasis GECARPAR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GECARPAR-IND-CLASSE-PRINC  PIC X(1).*/
        public StringBasis GECARPAR_IND_CLASSE_PRINC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}