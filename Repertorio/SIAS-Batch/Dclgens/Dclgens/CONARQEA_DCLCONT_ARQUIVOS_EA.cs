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
    public class CONARQEA_DCLCONT_ARQUIVOS_EA : VarBasis
    {
        /*"    10 CONARQEA-NSAS        PIC S9(4) USAGE COMP.*/
        public IntBasis CONARQEA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONARQEA-ANO-REFERENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis CONARQEA_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONARQEA-NUM-ARQUIVO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONARQEA_NUM_ARQUIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONARQEA-DATA-EMISSAO  PIC X(10).*/
        public StringBasis CONARQEA_DATA_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONARQEA-NUM-REGISTROS  PIC S9(9) USAGE COMP.*/
        public IntBasis CONARQEA_NUM_REGISTROS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONARQEA-NUM-INCLUSOES  PIC S9(9) USAGE COMP.*/
        public IntBasis CONARQEA_NUM_INCLUSOES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONARQEA-NUM-ALTERACOES  PIC S9(9) USAGE COMP.*/
        public IntBasis CONARQEA_NUM_ALTERACOES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONARQEA-NUM-EXCLUSOES  PIC S9(9) USAGE COMP.*/
        public IntBasis CONARQEA_NUM_EXCLUSOES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONARQEA-COD-USUARIO  PIC X(8).*/
        public StringBasis CONARQEA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CONARQEA-TIMESTAMP   PIC X(26).*/
        public StringBasis CONARQEA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}