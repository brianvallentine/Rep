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
    public class GE321_DCLGE_DNE_GRD_USUARIO : VarBasis
    {
        /*"    10 GE321-NUM-GRANDE-USUARIO  PIC S9(9) USAGE COMP.*/
        public IntBasis GE321_NUM_GRANDE_USUARIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE321-COD-UF         PIC X(2).*/
        public StringBasis GE321_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE321-NUM-LOCALIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis GE321_NUM_LOCALIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE321-NUM-BAIRRO     PIC S9(9) USAGE COMP.*/
        public IntBasis GE321_NUM_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE321-NOM-GRANDE-USUARIO  PIC X(72).*/
        public StringBasis GE321_NOM_GRANDE_USUARIO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE321-COD-CEP        PIC X(8).*/
        public StringBasis GE321_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE321-NOM-TP-LOGRADOURO  PIC X(72).*/
        public StringBasis GE321_NOM_TP_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE321-NOM-PREPOSICAO  PIC X(3).*/
        public StringBasis GE321_NOM_PREPOSICAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE321-NOM-TITULO-PATENTE  PIC X(72).*/
        public StringBasis GE321_NOM_TITULO_PATENTE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE321-NOM-LOGRADOURO  PIC X(72).*/
        public StringBasis GE321_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE321-NUM-LOTE       PIC X(10).*/
        public StringBasis GE321_NUM_LOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE321-NOM-COMPLEMENTO1  PIC X(36).*/
        public StringBasis GE321_NOM_COMPLEMENTO1 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE321-COD-COMPLEMENTO1  PIC X(11).*/
        public StringBasis GE321_COD_COMPLEMENTO1 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"    10 GE321-NOM-COMPLEMENTO2  PIC X(36).*/
        public StringBasis GE321_NOM_COMPLEMENTO2 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE321-COD-COMPLEMENTO2  PIC X(11).*/
        public StringBasis GE321_COD_COMPLEMENTO2 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"    10 GE321-NOM-UNID-OCUPACAO  PIC X(36).*/
        public StringBasis GE321_NOM_UNID_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE321-COD-UNID-OCUPACAO  PIC X(36).*/
        public StringBasis GE321_COD_UNID_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"*/
    }
}