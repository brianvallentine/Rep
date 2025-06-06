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
    public class LBFCT018_REG_TRAILLER_PARAM : VarBasis
    {
        /*"     10  RT-TIPO-REG                  PIC  X(002)*/
        public StringBasis RT_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"     10  RT-AGENCIA                   PIC  9(004)*/
        public IntBasis RT_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  RT-NOME-ARQUIVO              PIC  X(008)*/
        public StringBasis RT_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"     10  RT-QTDE-TIPO-1               PIC  9(004)*/
        public IntBasis RT_QTDE_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  FILLER                       PIC  X(182)*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "182", "X(182)"), @"");
    }
}