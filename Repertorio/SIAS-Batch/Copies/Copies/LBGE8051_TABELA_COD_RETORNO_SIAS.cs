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
    public class LBGE8051_TABELA_COD_RETORNO_SIAS : VarBasis
    {
        /*"    10       FILLER            PIC  X(037)    VALUE            '00DEBITO/CREDITO EFETUADO'*/
        public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"00DEBITO/CREDITO EFETUADO");
        /*"    10       FILLER            PIC  X(037)    VALUE            '01INSUFICIENCIA DE FUNDOS'*/
        public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"01INSUFICIENCIA DE FUNDOS");
        /*"    10       FILLER            PIC  X(037)    VALUE            '02CONTA CORRENTE NAO CADASTRADA'*/
        public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"02CONTA CORRENTE NAO CADASTRADA");
        /*"    10       FILLER            PIC  X(037)    VALUE            '04OUTRAS RESTRICOES'*/
        public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"04OUTRAS RESTRICOES");
        /*"    10       FILLER            PIC  X(037)    VALUE            '10AGENCIA EM REGIME DE ENCERRAMENTO'*/
        public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"10AGENCIA EM REGIME DE ENCERRAMENTO");
        /*"    10       FILLER            PIC  X(037)    VALUE            '12VALOR INVALIDO'*/
        public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"12VALOR INVALIDO");
        /*"    10       FILLER            PIC  X(037)    VALUE            '13DATA DO LANCAMENTO INVALIDA'*/
        public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"13DATA DO LANCAMENTO INVALIDA");
        /*"    10       FILLER            PIC  X(037)    VALUE            '14AGENCIA INVALIDA'*/
        public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"14AGENCIA INVALIDA");
        /*"    10       FILLER            PIC  X(037)    VALUE            '15DAC DA CONTA CORRENTE INVALIDO'*/
        public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"15DAC DA CONTA CORRENTE INVALIDO");
        /*"    10       FILLER            PIC  X(037)    VALUE            '18DATA DEB. ANTERIOR AO PROCESSAMENTO'*/
        public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"18DATA DEB. ANTERIOR AO PROCESSAMENTO");
        /*"    10       FILLER            PIC  X(037)    VALUE            '30SEM CONTRATO DE DEBITO AUTOMATICO'*/
        public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"30SEM CONTRATO DE DEBITO AUTOMATICO");
        /*"    10       FILLER            PIC  X(037)    VALUE            '80CANCELAMENTO SIAS'*/
        public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"80CANCELAMENTO SIAS");
        /*"    10       FILLER            PIC  X(037)    VALUE            '96DEB. NAO EFET. MANUT. CADASTRO   '*/
        public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"96DEB. NAO EFET. MANUT. CADASTRO   ");
        /*"    10       FILLER            PIC  X(037)    VALUE            '97DEB. NAO EFET. CANCELAM. NAO ENC.'*/
        public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"97DEB. NAO EFET. CANCELAM. NAO ENC.");
        /*"    10       FILLER            PIC  X(037)    VALUE            '98CANCEL. NAO EFETUADO - FORA TEMPO'*/
        public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"98CANCEL. NAO EFETUADO - FORA TEMPO");
        /*"    10       FILLER            PIC  X(037)    VALUE            '99SEM AUTORIZACAO DEBITO AUTOMATICO'*/
        public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"99SEM AUTORIZACAO DEBITO AUTOMATICO");
        /*"    10       FILLER            PIC  X(037)    VALUE            'CHSICOV TRANSF. CHEQUE'*/
        public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"CHSICOV TRANSF. CHEQUE");
        /*"    10       FILLER            PIC  X(037)    VALUE            'ENENVIO DE PAGAMENTO'*/
        public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"ENENVIO DE PAGAMENTO");
        /*"01 TABELA-COD-RETORNO-SIAS-R  REDEFINES TABELA-COD-RETORNO-SIAS*/
    }
}