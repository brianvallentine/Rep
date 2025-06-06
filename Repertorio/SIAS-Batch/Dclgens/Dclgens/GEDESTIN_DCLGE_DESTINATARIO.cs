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
    public class GEDESTIN_DCLGE_DESTINATARIO : VarBasis
    {
        /*"    10 GEDESTIN-COD-DESTINATARIO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEDESTIN_COD_DESTINATARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEDESTIN-COD-ESTIPULANTE  PIC S9(9) USAGE COMP.*/
        public IntBasis GEDESTIN_COD_ESTIPULANTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEDESTIN-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis GEDESTIN_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEDESTIN-COD-FILIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis GEDESTIN_COD_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEDESTIN-NOME-DESTINATARIO  PIC X(40).*/
        public StringBasis GEDESTIN_NOME_DESTINATARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEDESTIN-EMAIL-DESTINATARIO  PIC X(50).*/
        public StringBasis GEDESTIN_EMAIL_DESTINATARIO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 GEDESTIN-NOME-CONTATO  PIC X(40).*/
        public StringBasis GEDESTIN_NOME_CONTATO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEDESTIN-COD-USUARIO  PIC X(8).*/
        public StringBasis GEDESTIN_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEDESTIN-TIMESTAMP   PIC X(26).*/
        public StringBasis GEDESTIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GEDESTIN-SITUACAO    PIC X(1).*/
        public StringBasis GEDESTIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}