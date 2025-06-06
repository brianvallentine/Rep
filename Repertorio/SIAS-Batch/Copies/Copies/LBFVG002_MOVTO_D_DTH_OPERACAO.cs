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
    public class LBFVG002_MOVTO_D_DTH_OPERACAO : VarBasis
    {
        /*"      15    MOVTO-D-ANO-OPER     PIC  9(004)*/
        public IntBasis MOVTO_D_ANO_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      15    MOVTO-D-MES-OPER     PIC  9(002)*/
        public IntBasis MOVTO_D_MES_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      15    MOVTO-D-DIA-OPER     PIC  9(002)*/
        public IntBasis MOVTO_D_DIA_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10      MOVTO-D-IND-PESSOA   PIC  X(001)*/
    }
}