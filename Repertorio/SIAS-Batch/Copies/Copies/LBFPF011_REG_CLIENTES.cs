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
    public class LBFPF011_REG_CLIENTES : VarBasis
    {
        /*"     10  R1-TIPO-REG                 PIC  X(001)*/
        public StringBasis R1_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R1-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R1_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R1-CGC-CPF                  PIC  9(014)*/
        public IntBasis R1_CGC_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R1-DATA-NASCIMENTO          PIC  9(008)*/
        public IntBasis R1_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  R1-NOME-PESSOA              PIC  X(040)*/
        public StringBasis R1_NOME_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10  R1-TIPO-PESSOA              PIC  9(001)*/
        public IntBasis R1_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R1-NUM-IDENTIDADE           PIC  X(015)*/
        public StringBasis R1_NUM_IDENTIDADE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"     10  R1-ORGAO-EXPEDIDOR          PIC  X(005)*/
        public StringBasis R1_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"     10  R1-UF-EXPEDIDORA            PIC  X(002)*/
        public StringBasis R1_UF_EXPEDIDORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"     10  R1-ESTADO-CIVIL             PIC  9(001)*/
        public IntBasis R1_ESTADO_CIVIL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R1-IDE-SEXO                 PIC  9(001)*/
        public IntBasis R1_IDE_SEXO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R1-COD-CBO                  PIC  9(003)*/
        public IntBasis R1_COD_CBO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10  R1-TELEFONE OCCURS  3       TIMES*/
        public ListBasis<LBFPF011_R1_TELEFONE> R1_TELEFONE { get; set; } = new ListBasis<LBFPF011_R1_TELEFONE>(3);

        public IntBasis R1_DATA_EXPEDICAO_RG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  R1-CODIGO-SEGMENTO          PIC  X(004)*/
        public StringBasis R1_CODIGO_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"     10  R1-NOME-CONJUGE             PIC  X(040)*/
        public StringBasis R1_NOME_CONJUGE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10  R1-DTNASC-CONJUGE           PIC  9(008)*/
        public IntBasis R1_DTNASC_CONJUGE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  R1-CBO-CONJUGE              PIC  9(003)*/
        public IntBasis R1_CBO_CONJUGE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10  R1-EMAIL                    PIC  X(050)*/
        public StringBasis R1_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"     10  R1-DESCRICAO-PROFISSAO      PIC  X(040)*/
        public StringBasis R1_DESCRICAO_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10  R1-RENDA-INDIVIDUAL         PIC  X(001)*/
        public StringBasis R1_RENDA_INDIVIDUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R1-RENDA-FAMILIAR           PIC  X(001)*/
        public StringBasis R1_RENDA_FAMILIAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  FILLER                      PIC  X(003)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"     10  R1-IDE-CONVENIO             PIC  9(001)*/
        public IntBasis R1_IDE_CONVENIO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"*/
    }
}