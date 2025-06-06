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
    public class GE318_DCLGE_DNE_LOG_UF : VarBasis
    {
        /*"    10 GE318-NUM-LOGRADOURO-UF  PIC S9(9) USAGE COMP.*/
        public IntBasis GE318_NUM_LOGRADOURO_UF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE318-COD-CEP        PIC X(8).*/
        public StringBasis GE318_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE318-NUM-LOCALIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis GE318_NUM_LOCALIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE318-COD-UF         PIC X(2).*/
        public StringBasis GE318_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE318-NUM-INI-BAIRRO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE318_NUM_INI_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE318-NUM-FIM-BAIRRO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE318_NUM_FIM_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE318-NOM-LOGRADOURO  PIC X(100).*/
        public StringBasis GE318_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE318-DES-COMPLEMENTO  PIC X(100).*/
        public StringBasis GE318_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE318-IND-TP-LOGRADOURO  PIC X(36).*/
        public StringBasis GE318_IND_TP_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE318-STA-GRDUSUARIO-LOG  PIC X(1).*/
        public StringBasis GE318_STA_GRDUSUARIO_LOG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE318-NUM-LOTE       PIC X(10).*/
        public StringBasis GE318_NUM_LOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE318-NOM-COMPLEMENTO1  PIC X(36).*/
        public StringBasis GE318_NOM_COMPLEMENTO1 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE318-COD-COMPLEMENTO1  PIC X(11).*/
        public StringBasis GE318_COD_COMPLEMENTO1 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"    10 GE318-NOM-COMPLEMENTO2  PIC X(36).*/
        public StringBasis GE318_NOM_COMPLEMENTO2 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE318-COD-COMPLEMENTO2  PIC X(11).*/
        public StringBasis GE318_COD_COMPLEMENTO2 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"    10 GE318-NOM-PREPOSICAO  PIC X(3).*/
        public StringBasis GE318_NOM_PREPOSICAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE318-NOM-TITULO-PATENTE  PIC X(72).*/
        public StringBasis GE318_NOM_TITULO_PATENTE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"*/
    }
}