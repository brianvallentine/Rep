using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class RSGEWCNT : VarBasis
    {
        /*"01  LK-RSGEWCNT-IND-ERRO             PIC S9(004) COMP-5.*/
        public IntBasis LK_RSGEWCNT_IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-RSGEWCNT-MENSAGEM-RETORNO     PIC  X(133).*/
        public StringBasis LK_RSGEWCNT_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "133", "X(133)."), @"");
        /*"01  LK-RSGEWCNT-NOME-TABELA          PIC  X(030).*/
        public StringBasis LK_RSGEWCNT_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"01  LK-RSGEWCNT-SQLCODE              PIC S9(009) COMP-5.*/
        public IntBasis LK_RSGEWCNT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-RSGEWCNT-SQLERRMC             PIC  X(070).*/
        public StringBasis LK_RSGEWCNT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
    }
}