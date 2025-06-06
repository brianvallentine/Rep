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
    public class MOEDAS_DCLMOEDAS : VarBasis
    {
        /*"    10 MOEDAS-COD-MOEDA     PIC S9(4) USAGE COMP.*/
        public IntBasis MOEDAS_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MOEDAS-NOME-MOEDA    PIC X(20).*/
        public StringBasis MOEDAS_NOME_MOEDA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 MOEDAS-SIGLA-MOEDA   PIC X(6).*/
        public StringBasis MOEDAS_SIGLA_MOEDA { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"    10 MOEDAS-TIPO-MOEDA    PIC X(1).*/
        public StringBasis MOEDAS_TIPO_MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOEDAS-SIT-REGISTRO  PIC X(1).*/
        public StringBasis MOEDAS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOEDAS-COD-EMPRESA   PIC S9(9) USAGE COMP.*/
        public IntBasis MOEDAS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MOEDAS-ENVOGA        PIC X(1).*/
        public StringBasis MOEDAS_ENVOGA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}