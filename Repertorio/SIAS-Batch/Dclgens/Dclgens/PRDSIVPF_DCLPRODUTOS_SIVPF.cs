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
    public class PRDSIVPF_DCLPRODUTOS_SIVPF : VarBasis
    {
        /*"    10 PRDSIVPF-COD-EMPRESA-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis PRDSIVPF_COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRDSIVPF-COD-PRODUTO-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis PRDSIVPF_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRDSIVPF-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis PRDSIVPF_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRDSIVPF-COD-RELAC   PIC S9(4) USAGE COMP.*/
        public IntBasis PRDSIVPF_COD_RELAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRDSIVPF-NOME-PRODUTO       PIC X(40).*/
        public StringBasis PRDSIVPF_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PRDSIVPF-IND-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis PRDSIVPF_IND_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRDSIVPF-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis PRDSIVPF_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRDSIVPF-DTH-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis PRDSIVPF_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRDSIVPF-SEQ-PRD-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis PRDSIVPF_SEQ_PRD_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRDSIVPF-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PRDSIVPF_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}