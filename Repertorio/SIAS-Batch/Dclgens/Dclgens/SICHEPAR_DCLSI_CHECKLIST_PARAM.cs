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
    public class SICHEPAR_DCLSI_CHECKLIST_PARAM : VarBasis
    {
        /*"    10 SICHEPAR-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SICHEPAR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICHEPAR-COD-GRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SICHEPAR_COD_GRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICHEPAR-COD-SUBGRUPO-CAUSA  PIC S9(4) USAGE COMP.*/
        public IntBasis SICHEPAR_COD_SUBGRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICHEPAR-NUM-PARTICIPANTE  PIC S9(4) USAGE COMP.*/
        public IntBasis SICHEPAR_NUM_PARTICIPANTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICHEPAR-COD-FASE    PIC S9(4) USAGE COMP.*/
        public IntBasis SICHEPAR_COD_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICHEPAR-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis SICHEPAR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SICHEPAR-COD-DOCUMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SICHEPAR_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICHEPAR-COD-TIPO-CARTA  PIC S9(9) USAGE COMP.*/
        public IntBasis SICHEPAR_COD_TIPO_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SICHEPAR-OPCAO-DOCUMENTO  PIC X(1).*/
        public StringBasis SICHEPAR_OPCAO_DOCUMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SICHEPAR-SIT-NEGATIVA  PIC X(1).*/
        public StringBasis SICHEPAR_SIT_NEGATIVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SICHEPAR-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis SICHEPAR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SICHEPAR-TIMESTAMP   PIC X(26).*/
        public StringBasis SICHEPAR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SICHEPAR-COD-USUARIO  PIC X(8).*/
        public StringBasis SICHEPAR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}