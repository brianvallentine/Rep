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
    public class GECLIMOV_DCLGE_CLIENTES_MOVTO : VarBasis
    {
        /*"    10 GECLIMOV-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis GECLIMOV_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECLIMOV-OCORR-HIST  PIC S9(4) USAGE COMP.*/
        public IntBasis GECLIMOV_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECLIMOV-TIPO-MOVIMENTO  PIC X(1).*/
        public StringBasis GECLIMOV_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GECLIMOV-DATA-ULT-MANUTEN  PIC X(10).*/
        public StringBasis GECLIMOV_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GECLIMOV-NOME-RAZAO  PIC X(40).*/
        public StringBasis GECLIMOV_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GECLIMOV-TIPO-PESSOA  PIC X(1).*/
        public StringBasis GECLIMOV_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GECLIMOV-IDE-SEXO    PIC X(1).*/
        public StringBasis GECLIMOV_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GECLIMOV-ESTADO-CIVIL  PIC X(1).*/
        public StringBasis GECLIMOV_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GECLIMOV-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis GECLIMOV_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECLIMOV-ENDERECO    PIC X(72).*/
        public StringBasis GECLIMOV_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GECLIMOV-BAIRRO      PIC X(72).*/
        public StringBasis GECLIMOV_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GECLIMOV-CIDADE      PIC X(72).*/
        public StringBasis GECLIMOV_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GECLIMOV-SIGLA-UF    PIC X(2).*/
        public StringBasis GECLIMOV_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GECLIMOV-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis GECLIMOV_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECLIMOV-DDD         PIC S9(4) USAGE COMP.*/
        public IntBasis GECLIMOV_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GECLIMOV-TELEFONE    PIC S9(9) USAGE COMP.*/
        public IntBasis GECLIMOV_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECLIMOV-FAX         PIC S9(9) USAGE COMP.*/
        public IntBasis GECLIMOV_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECLIMOV-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GECLIMOV_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GECLIMOV-DATA-NASCIMENTO  PIC X(10).*/
        public StringBasis GECLIMOV_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GECLIMOV-COD-USUARIO  PIC X(8).*/
        public StringBasis GECLIMOV_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GECLIMOV-TIMESTAMP   PIC X(26).*/
        public StringBasis GECLIMOV_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GECLIMOV-DES-COMPLEMENTO  PIC X(72).*/
        public StringBasis GECLIMOV_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"*/
    }
}