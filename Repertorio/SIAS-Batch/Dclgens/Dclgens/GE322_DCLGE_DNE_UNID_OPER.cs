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
    public class GE322_DCLGE_DNE_UNID_OPER : VarBasis
    {
        /*"    10 GE322-NUM-UNID-OPERCINAL  PIC S9(9) USAGE COMP.*/
        public IntBasis GE322_NUM_UNID_OPERCINAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE322-COD-UF         PIC X(2).*/
        public StringBasis GE322_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE322-NUM-LOCALIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis GE322_NUM_LOCALIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE322-NUM-BAIRRO     PIC S9(9) USAGE COMP.*/
        public IntBasis GE322_NUM_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE322-NOM-UNID-OPERCINAL  PIC X(100).*/
        public StringBasis GE322_NOM_UNID_OPERCINAL { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE322-COD-CEP        PIC X(8).*/
        public StringBasis GE322_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE322-NOM-ABREV-UNID  PIC X(36).*/
        public StringBasis GE322_NOM_ABREV_UNID { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE322-NOM-TP-UNID-OPER  PIC X(72).*/
        public StringBasis GE322_NOM_TP_UNID_OPER { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE322-NOM-TP-LOGRADOURO  PIC X(72).*/
        public StringBasis GE322_NOM_TP_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE322-NOM-PREPOSICAO  PIC X(3).*/
        public StringBasis GE322_NOM_PREPOSICAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE322-NOM-TITULO-PATENTE  PIC X(72).*/
        public StringBasis GE322_NOM_TITULO_PATENTE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE322-NOM-LOGRADOURO  PIC X(72).*/
        public StringBasis GE322_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE322-NUM-LOTE       PIC X(10).*/
        public StringBasis GE322_NUM_LOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE322-NOM-COMPLEMENTO1  PIC X(36).*/
        public StringBasis GE322_NOM_COMPLEMENTO1 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE322-COD-COMPLEMENTO1  PIC X(11).*/
        public StringBasis GE322_COD_COMPLEMENTO1 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"    10 GE322-NOM-COMPLEMENTO2  PIC X(36).*/
        public StringBasis GE322_NOM_COMPLEMENTO2 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE322-COD-COMPLEMENTO2  PIC X(11).*/
        public StringBasis GE322_COD_COMPLEMENTO2 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
        /*"    10 GE322-NOM-UNID-OCUPACAO  PIC X(36).*/
        public StringBasis GE322_NOM_UNID_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"    10 GE322-COD-UNID-OCUPACAO  PIC X(36).*/
        public StringBasis GE322_COD_UNID_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "36", "X(36)."), @"");
        /*"*/
    }
}