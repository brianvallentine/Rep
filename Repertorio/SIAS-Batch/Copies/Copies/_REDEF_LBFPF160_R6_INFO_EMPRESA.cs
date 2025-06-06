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
    public class _REDEF_LBFPF160_R6_INFO_EMPRESA : VarBasis
    {
        /*"    15 R6-VERSAO                       PIC  9(004)*/
        public IntBasis R6_VERSAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    15 R6-TIPO-CAPITAL                 PIC  9(002)*/
        public IntBasis R6_TIPO_CAPITAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-CAPITAL-CONTRATADO           PIC  9(013)V99*/
        public DoubleBasis R6_CAPITAL_CONTRATADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    15 R6-PERIPGTO                     PIC  9(002)*/
        public IntBasis R6_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-VALOR-DA-FATURA              PIC  9(013)V99*/
        public DoubleBasis R6_VALOR_DA_FATURA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    15 R6-TOTAL-DE-VIDAS               PIC  9(003)*/
        public IntBasis R6_TOTAL_DE_VIDAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"    15 R6-CODIGO-CNAE                  PIC  9(010)*/
        public IntBasis R6_CODIGO_CNAE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"    15 R6-PORTE-EMPRESA                PIC  9(002)*/
        public IntBasis R6_PORTE_EMPRESA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-QUANT-NIVEIS                 PIC  9(002)*/
        public IntBasis R6_QUANT_NIVEIS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    15 R6-NIVEIS-CARGO OCCURS 05 TIMES*/
        public ListBasis<LBFPF160_R6_NIVEIS_CARGO> R6_NIVEIS_CARGO { get; set; } = new ListBasis<LBFPF160_R6_NIVEIS_CARGO>(05);

        public DoubleBasis R6_FATURAMENTO_ANUAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    15 R6-DATA-CONSTITUICAO            PIC  9(008)*/
        public IntBasis R6_DATA_CONSTITUICAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    15 FILLER                          PIC  X(105)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "105", "X(105)"), @"");
        /*"  10   R6-INFO-FUNCIONARIO             REDEFINES                                       R6-INFO*/

        public _REDEF_LBFPF160_R6_INFO_EMPRESA()
        {
            R6_VERSAO.ValueChanged += OnValueChanged;
            R6_TIPO_CAPITAL.ValueChanged += OnValueChanged;
            R6_CAPITAL_CONTRATADO.ValueChanged += OnValueChanged;
            R6_PERIPGTO.ValueChanged += OnValueChanged;
            R6_VALOR_DA_FATURA.ValueChanged += OnValueChanged;
            R6_TOTAL_DE_VIDAS.ValueChanged += OnValueChanged;
            R6_CODIGO_CNAE.ValueChanged += OnValueChanged;
            R6_PORTE_EMPRESA.ValueChanged += OnValueChanged;
            R6_QUANT_NIVEIS.ValueChanged += OnValueChanged;
            R6_NIVEIS_CARGO.ValueChanged += OnValueChanged;
            R6_FATURAMENTO_ANUAL.ValueChanged += OnValueChanged;
            R6_DATA_CONSTITUICAO.ValueChanged += OnValueChanged;
            FILLER.ValueChanged += OnValueChanged;
        }

    }
}