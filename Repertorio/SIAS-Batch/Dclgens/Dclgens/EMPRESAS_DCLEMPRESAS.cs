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
    public class EMPRESAS_DCLEMPRESAS : VarBasis
    {
        /*"    10 EMPRESAS-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis EMPRESAS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EMPRESAS-NOME-EMPRESA       PIC X(40).*/
        public StringBasis EMPRESAS_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 EMPRESAS-NOME-ABREVIADO       PIC X(25).*/
        public StringBasis EMPRESAS_NOME_ABREVIADO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 EMPRESAS-MNEMON-EMPRESA       PIC X(20).*/
        public StringBasis EMPRESAS_MNEMON_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 EMPRESAS-SIST-OPERACIONAL       PIC X(10).*/
        public StringBasis EMPRESAS_SIST_OPERACIONAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-VERSAO-SIST-OPER       PIC X(10).*/
        public StringBasis EMPRESAS_VERSAO_SIST_OPER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-BCO-DADOS   PIC X(10).*/
        public StringBasis EMPRESAS_BCO_DADOS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-VERSAO-BCO-DADOS       PIC X(10).*/
        public StringBasis EMPRESAS_VERSAO_BCO_DADOS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-VERSAO-CSP  PIC X(10).*/
        public StringBasis EMPRESAS_VERSAO_CSP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-VERSAO-CICS       PIC X(10).*/
        public StringBasis EMPRESAS_VERSAO_CICS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-VERSAO-QMF  PIC X(10).*/
        public StringBasis EMPRESAS_VERSAO_QMF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-MODELO-CPU  PIC X(10).*/
        public StringBasis EMPRESAS_MODELO_CPU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-TIPO-CPU    PIC X(10).*/
        public StringBasis EMPRESAS_TIPO_CPU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-MODELO-DISCO       PIC X(10).*/
        public StringBasis EMPRESAS_MODELO_DISCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EMPRESAS_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EMPRESAS-DATA-ABERTURA       PIC X(10).*/
        public StringBasis EMPRESAS_DATA_ABERTURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-DATA-ENCERRAMENTO       PIC X(10).*/
        public StringBasis EMPRESAS_DATA_ENCERRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EMPRESAS-SIT-REGISTRO       PIC X(1).*/
        public StringBasis EMPRESAS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EMPRESAS-URL-SITE    PIC X(20).*/
        public StringBasis EMPRESAS_URL_SITE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"*/
    }
}