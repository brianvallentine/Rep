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
    public class LBFVG002_MOVTO_D_DTH_PASSEMBLEIA : VarBasis
    {
        /*"         20 MOVTO-D-ANO-PASSEMB  PIC  9(004)*/
        public IntBasis MOVTO_D_ANO_PASSEMB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"         20 MOVTO-D-MES-PASSEMB  PIC  9(002)*/
        public IntBasis MOVTO_D_MES_PASSEMB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"         20 MOVTO-D-DIA-PASSEMB  PIC  9(002)*/
        public IntBasis MOVTO_D_DIA_PASSEMB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      15    MOVTO-D-DTH-VENCTO*/
    }
}