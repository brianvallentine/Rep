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
    public class GE149_DCLGE_NOME_SOCIAL : VarBasis
    {
        /*"    10 GE149-NUM-CPF        PIC S9(18) USAGE COMP.*/
        public IntBasis GE149_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE149-DTH-OPERACAO   PIC X(26).*/
        public StringBasis GE149_DTH_OPERACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE149-NOM-SOCIAL.*/
        public GE149_GE149_NOM_SOCIAL GE149_NOM_SOCIAL { get; set; } = new GE149_GE149_NOM_SOCIAL();

        public StringBasis GE149_IND_TIPO_ACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE149-IND-USA-NOME-SOCIAL       PIC X(1).*/
        public StringBasis GE149_IND_USA_NOME_SOCIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE149-COD-TP-PES-NEGOCIO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE149_COD_TP_PES_NEGOCIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE149-NUM-PROPOSTA   PIC S9(18) USAGE COMP.*/
        public IntBasis GE149_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE149-COD-CANAL-ORIGEM       PIC X(10).*/
        public StringBasis GE149_COD_CANAL_ORIGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE149-NUM-MATRICULA  PIC X(20).*/
        public StringBasis GE149_NUM_MATRICULA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GE149-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE149_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE149-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE149_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}