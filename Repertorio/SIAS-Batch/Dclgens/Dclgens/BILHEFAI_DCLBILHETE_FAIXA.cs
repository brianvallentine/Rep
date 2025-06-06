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
    public class BILHEFAI_DCLBILHETE_FAIXA : VarBasis
    {
        /*"    10 BILHEFAI-NUMBIL-INI  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BILHEFAI_NUMBIL_INI { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BILHEFAI-NUMBIL-FIM  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BILHEFAI_NUMBIL_FIM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BILHEFAI-COD-RAMO    PIC S9(4) USAGE COMP.*/
        public IntBasis BILHEFAI_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHEFAI-VERSAO-BIL  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHEFAI_VERSAO_BIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHEFAI-TIPO-EMISSAO  PIC X(1).*/
        public StringBasis BILHEFAI_TIPO_EMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHEFAI-TIMESTAMP   PIC X(26).*/
        public StringBasis BILHEFAI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BILHEFAI-VALADT-IND  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHEFAI_VALADT_IND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILHEFAI-VALADT-GER  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHEFAI_VALADT_GER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BILHEFAI-VALADT-SUN  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHEFAI_VALADT_SUN { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
    }
}