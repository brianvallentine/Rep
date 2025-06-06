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
    public class SICPW001_SSICPW001 : VarBasis
    {
        /*"    05 LK-SICPW001-NUM-APOLICE            PIC S9(13) COMP-3.*/
        public IntBasis LK_SICPW001_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"    05 LK-SICPW001-NUM-ENDOSSO            PIC S9(09) COMP-5.*/
        public IntBasis LK_SICPW001_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"    05 LK-SICPW001-NUM-PARCELA            PIC S9(04) COMP-5.*/
        public IntBasis LK_SICPW001_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    05 LK-SICPW001-COD-CONVENIO           PIC S9(09) COMP-5.*/
        public IntBasis LK_SICPW001_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"    05 LK-SICPW001-NSAS                   PIC S9(04) COMP-5.*/
        public IntBasis LK_SICPW001_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    05 LK-SICPW001-SITUACAO-COBRANCA      PIC  X(01).*/
        public StringBasis LK_SICPW001_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"    05 LK-SICPW001-COD-BANCO              PIC S9(04) COMP-5.*/
        public IntBasis LK_SICPW001_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    05 LK-SICPW001-COD-AGENCIA            PIC  9(05).*/
        public IntBasis LK_SICPW001_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
        /*"    05 LK-SICPW001-DV-AGENCIA             PIC  X(01).*/
        public StringBasis LK_SICPW001_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"    05 LK-SICPW001-OPERACAO-CONTA         PIC  9(04).*/
        public IntBasis LK_SICPW001_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"    05 LK-SICPW001-NUM-CONTA              PIC  9(12).*/
        public IntBasis LK_SICPW001_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
        /*"    05 LK-SICPW001-DV-CONTA               PIC  X(01).*/
        public StringBasis LK_SICPW001_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"    05 LK-SICPW001-COD-PROGRAMA           PIC  X(08).*/
        public StringBasis LK_SICPW001_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"    05 LK-SICPW001-FAVORECIDO.*/
        public SICPW001_LK_SICPW001_FAVORECIDO LK_SICPW001_FAVORECIDO { get; set; } = new SICPW001_LK_SICPW001_FAVORECIDO();

        public StringBasis LK_SICPW001_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    05 LK-SICPW001-NUM-LOCAL              PIC  9(05).*/
        public IntBasis LK_SICPW001_NUM_LOCAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
        /*"    05 LK-SICPW001-DES-COMPLEMENTO        PIC  X(15).*/
        public StringBasis LK_SICPW001_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    05 LK-SICPW001-DES-BAIRRO             PIC  X(15).*/
        public StringBasis LK_SICPW001_DES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    05 LK-SICPW001-DES-CIDADE             PIC  X(20).*/
        public StringBasis LK_SICPW001_DES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    05 LK-SICPW001-NUM-CEP                PIC  9(05).*/
        public IntBasis LK_SICPW001_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
        /*"    05 LK-SICPW001-DES-COMPL-CEP          PIC  X(03).*/
        public StringBasis LK_SICPW001_DES_COMPL_CEP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"    05 LK-SICPW001-DES-SIGLA-UF           PIC  X(02).*/
        public StringBasis LK_SICPW001_DES_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"    05 LK-SICPW001-CHR-USO-EMPRESA.*/
        public SICPW001_LK_SICPW001_CHR_USO_EMPRESA LK_SICPW001_CHR_USO_EMPRESA { get; set; } = new SICPW001_LK_SICPW001_CHR_USO_EMPRESA();

        public StringBasis LK_SICPW001_COD_DOC_SIACC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    05 LK-SICPW001-USO-SIACC              PIC  X(40).*/
        public StringBasis LK_SICPW001_USO_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    05 LK-SICPW001-COD-RETORNO            PIC  X(01).*/
        public StringBasis LK_SICPW001_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"    05 LK-SICPW001-MENSAGEM-RETORNO       PIC  X(80).*/
        public StringBasis LK_SICPW001_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
    }
}