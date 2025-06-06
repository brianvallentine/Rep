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
    public class PARAMPRO_DCLPARAM_PRODUTO : VarBasis
    {
        /*"    10 PARAMPRO-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMPRO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARAMPRO-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMPRO_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMPRO-TIPO-COBRANCA  PIC X(1).*/
        public StringBasis PARAMPRO_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARAMPRO-TIPO-FUNCIONARIO  PIC X(1).*/
        public StringBasis PARAMPRO_TIPO_FUNCIONARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARAMPRO-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PARAMPRO_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAMPRO-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PARAMPRO_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAMPRO-VALOR-COMISSAO-PRD  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis PARAMPRO_VALOR_COMISSAO_PRD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARAMPRO-VALOR-COMISSAO-CEF  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis PARAMPRO_VALOR_COMISSAO_CEF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARAMPRO-PERCEN-COMIS-FUNC  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARAMPRO_PERCEN_COMIS_FUNC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARAMPRO-TIMESTAMP   PIC X(26).*/
        public StringBasis PARAMPRO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PARAMPRO-MARGEM      PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMPRO_MARGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMPRO-STA-RENOVACAO  PIC X(1).*/
        public StringBasis PARAMPRO_STA_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}