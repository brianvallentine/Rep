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
    public class LBFVG003_MOVTO_T_DATA_GERACAO : VarBasis
    {
        /*"      15    MOVTO-T-ANO-GERA     PIC  9(004)*/
        public IntBasis MOVTO_T_ANO_GERA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      15    FILLER               PIC  X(001)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      15    MOVTO-T-MES-GERA     PIC  9(002)*/
        public IntBasis MOVTO_T_MES_GERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      15    FILLER               PIC  X(001)*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      15    MOVTO-T-DIA-GERA     PIC  9(002)*/
        public IntBasis MOVTO_T_DIA_GERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      MOVTO-T-DATA-REFER   PIC  9(006)*/
    }
}