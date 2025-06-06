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
    public class FCPROSUS_DCLFC_PROCESSO_SUSEP : VarBasis
    {
        /*"    10 FCPROSUS-COD-PROCESSO-SUSEP  PIC X(25).*/
        public StringBasis FCPROSUS_COD_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 FCPROSUS-NUM-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROSUS_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCPROSUS-COD-PRODUTO-SUSEP  PIC X(4).*/
        public StringBasis FCPROSUS_COD_PRODUTO_SUSEP { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 FCPROSUS-DES-PROCESSO-SUSEP  PIC X(50).*/
        public StringBasis FCPROSUS_DES_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 FCPROSUS-DTH-FIM-VENDAS  PIC X(10).*/
        public StringBasis FCPROSUS_DTH_FIM_VENDAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCPROSUS-DTH-INI-VENDAS  PIC X(10).*/
        public StringBasis FCPROSUS_DTH_INI_VENDAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}