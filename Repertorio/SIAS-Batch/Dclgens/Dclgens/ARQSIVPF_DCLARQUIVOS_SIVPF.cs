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
    public class ARQSIVPF_DCLARQUIVOS_SIVPF : VarBasis
    {
        /*"    10 ARQSIVPF-SIGLA-ARQUIVO  PIC X(8).*/
        public StringBasis ARQSIVPF_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 ARQSIVPF-SISTEMA-ORIGEM  PIC S9(4) USAGE COMP.*/
        public IntBasis ARQSIVPF_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ARQSIVPF-NSAS-SIVPF  PIC S9(9) USAGE COMP.*/
        public IntBasis ARQSIVPF_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ARQSIVPF-DATA-GERACAO  PIC X(10).*/
        public StringBasis ARQSIVPF_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ARQSIVPF-QTDE-REG-GER  PIC S9(9) USAGE COMP.*/
        public IntBasis ARQSIVPF_QTDE_REG_GER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ARQSIVPF-DATA-PROCESSAMENTO  PIC X(10).*/
        public StringBasis ARQSIVPF_DATA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}