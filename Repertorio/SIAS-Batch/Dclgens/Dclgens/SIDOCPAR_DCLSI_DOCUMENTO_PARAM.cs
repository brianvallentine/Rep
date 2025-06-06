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
    public class SIDOCPAR_DCLSI_DOCUMENTO_PARAM : VarBasis
    {
        /*"    10 SIDOCPAR-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCPAR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCPAR-COD-GRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCPAR_COD_GRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCPAR-COD-SUBGRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCPAR_COD_SUBGRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCPAR-COD-DOCUMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCPAR_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCPAR-DATA-INIVIG-DOCPAR  PIC X(10).*/
        public StringBasis SIDOCPAR_DATA_INIVIG_DOCPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIDOCPAR-DATA-TERVIG-DOCPAR  PIC X(10).*/
        public StringBasis SIDOCPAR_DATA_TERVIG_DOCPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIDOCPAR-OPCAO-DOCUMENTO  PIC X(1).*/
        public StringBasis SIDOCPAR_OPCAO_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIDOCPAR-COD-FASE    PIC S9(4) USAGE COMP.*/
        public IntBasis SIDOCPAR_COD_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIDOCPAR-COD-TIPO-CARTA  PIC S9(9) USAGE COMP.*/
        public IntBasis SIDOCPAR_COD_TIPO_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIDOCPAR-COD-USUARIO  PIC X(8).*/
        public StringBasis SIDOCPAR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIDOCPAR-TIMESTAMP   PIC X(26).*/
        public StringBasis SIDOCPAR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}