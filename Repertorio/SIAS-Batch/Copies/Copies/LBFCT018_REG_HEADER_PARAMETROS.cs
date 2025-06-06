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
    public class LBFCT018_REG_HEADER_PARAMETROS : VarBasis
    {
        /*"     10  RH-TIPO-REG                 PIC  X(002)*/
        public StringBasis RH_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"     10  RH-AGENCIA                  PIC  9(004)*/
        public IntBasis RH_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  RH-NOME-ARQUIVO             PIC  X(008)*/
        public StringBasis RH_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"     10  RH-DATA-GERACAO             PIC  9(008)*/
        public IntBasis RH_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  RH-SIST-ORIGEM              PIC  9(001)*/
        public IntBasis RH_SIST_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  RH-SIST-DESTINO             PIC  9(001)*/
        public IntBasis RH_SIST_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  RH-TIPO-ARQUIVO             PIC  9(001)*/
        public IntBasis RH_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  FILLER                      PIC  X(175)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "175", "X(175)"), @"");
        /*"01      REG-PARAMETROS*/
    }
}