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
    public class LBGE0530_LK_GE0530_RELATORIOS : VarBasis
    {
        /*"        10  LK-GE0530-TIPO-RELATORIO    PIC  9(004) VALUE   0*/
        public IntBasis LK_GE0530_TIPO_RELATORIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0530-NOME-CLIENTE-PEPS PIC  X(060) VALUE ' '*/
        public StringBasis LK_GE0530_NOME_CLIENTE_PEPS { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @" ");
        /*"        10  LK-GE0530-CIDADE            PIC  X(010) VALUE ' '*/
        public StringBasis LK_GE0530_CIDADE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
        /*"        10  LK-GE0530-UF                PIC  X(002) VALUE ' '*/
        public StringBasis LK_GE0530_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
    }
}