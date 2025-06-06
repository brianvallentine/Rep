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
    public class LBGE8051_TABELA_COD_SIACC_240 : VarBasis
    {
        /*"  10 FILLER PIC X(083) VALUE '00-CREDITO OU DEBITO EFETIVADO'*/
        public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"00-CREDITO OU DEBITO EFETIVADO");
        /*"  10 FILLER PIC X(083) VALUE '01-INSUFICIENCIA DE FUNDOS - DEBITO     ' NAO EFETUADO'*/
        public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"01-INSUFICIENCIA DE FUNDOS - DEBITO     ");
        /*"  10 FILLER PIC X(083) VALUE '02-CREDITO OU DEBITO CANCELADO PELO     ' PAGADOR/CREDOR'*/
        public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"02-CREDITO OU DEBITO CANCELADO PELO     ");
        /*"  10 FILLER PIC X(083) VALUE '03-DEBITO AUTORIZADO PELA AGENCIA -     ' EFETUADO'*/
        public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"03-DEBITO AUTORIZADO PELA AGENCIA -     ");
        /*"  10 FILLER PIC X(083) VALUE 'HA-LOTE NAO ACEITO'*/
        public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HA-LOTE NAO ACEITO");
        /*"  10 FILLER PIC X(083) VALUE 'HB-INSCRICAO DA EMPRESA INVALIDA PA     'RA O CONTRATO'*/
        public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HB-INSCRICAO DA EMPRESA INVALIDA PA     ");
        /*"  10 FILLER PIC X(083) VALUE 'HC-CONVENIO COM A EMPRESA INEXISTEN     'TE/INVALIDO PARA O CONTRATO'*/
        public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HC-CONVENIO COM A EMPRESA INEXISTEN     ");
        /*"  10 FILLER PIC X(083) VALUE 'HD-AGENCIA/CONTA CORRENTE DA EMPRES     'A INEXISTENTE/INVALIDO PARA O CONTRATO'*/
        public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HD-AGENCIA/CONTA CORRENTE DA EMPRES     ");
        /*"  10 FILLER PIC X(083) VALUE 'HE-TIPO DE SERVICO INVALIDO PARA O     'CONTRATO'*/
        public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HE-TIPO DE SERVICO INVALIDO PARA O     ");
        /*"  10 FILLER PIC X(083) VALUE 'HF-CONTA CORRENTE DA EMPRESA COM SA     'LDO INSUFICIENTE'*/
        public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HF-CONTA CORRENTE DA EMPRESA COM SA     ");
        /*"  10 FILLER PIC X(083) VALUE 'HG-LOTE DE SERVICO FORA DE SEQ�ENCI     'A'*/
        public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HG-LOTE DE SERVICO FORA DE SEQ�ENCI     ");
        /*"  10 FILLER PIC X(083) VALUE 'HH-LOTE DE SERVICO INVALIDO'*/
        public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HH-LOTE DE SERVICO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'HI-NUMERO DA REMESSA INVALIDO'*/
        public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HI-NUMERO DA REMESSA INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'HJ-ARQUIVO SEM HEADER'*/
        public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HJ-ARQUIVO SEM HEADER");
        /*"  10 FILLER PIC X(083) VALUE 'HM-VERSAO DO ARQUIVO INVALIDO'*/
        public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"HM-VERSAO DO ARQUIVO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AA-CONTROLE INVALIDO'*/
        public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AA-CONTROLE INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AB-TIPO DE OPERACAO INVALIDO'*/
        public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AB-TIPO DE OPERACAO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AC-TIPO DE SERVICO INVALIDO'*/
        public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AC-TIPO DE SERVICO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AD-FORMA DE LANCAMENTO INVALIDA'*/
        public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AD-FORMA DE LANCAMENTO INVALIDA");
        /*"  10 FILLER PIC X(083) VALUE 'AE-TIPO/NUMERO DE INSCRICAO INVALID     'O'*/
        public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AE-TIPO/NUMERO DE INSCRICAO INVALID     ");
        /*"  10 FILLER PIC X(083) VALUE 'AF-CODIGO DE CONVENIO INVALIDO'*/
        public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AF-CODIGO DE CONVENIO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AG-AGENCIA/CONTA CORRENTE/DV INVALI     'DO'*/
        public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AG-AGENCIA/CONTA CORRENTE/DV INVALI     ");
        /*"  10 FILLER PIC X(083) VALUE 'AH-NUMERO SEQUENCIAL DO REGISTRO NO     ' LOTE INVALIDO'*/
        public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AH-NUMERO SEQUENCIAL DO REGISTRO NO     ");
        /*"  10 FILLER PIC X(083) VALUE 'AI-CODIGO DE SEGMENTO DE DETALHE IN     'VALIDO'*/
        public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AI-CODIGO DE SEGMENTO DE DETALHE IN     ");
        /*"  10 FILLER PIC X(083) VALUE 'AJ-TIPO DE MOVIMENTO INVALIDO'*/
        public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AJ-TIPO DE MOVIMENTO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AK-CODIGO DA CAMARA DE COMPENSACAO     'DO BANCO FAVORECIDO/DEPOSITARIO INVALIDO'*/
        public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AK-CODIGO DA CAMARA DE COMPENSACAO     ");
        /*"  10 FILLER PIC X(083) VALUE 'AL-CODIGO DO BANCO FAVORECIDO OU DE     'POSITARIO INVALIDO'*/
        public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AL-CODIGO DO BANCO FAVORECIDO OU DE     ");
        /*"  10 FILLER PIC X(083) VALUE 'AM-AGENCIA MANTENEDORA DA CONTA COR     'RENTE DO FAVORECIDO INVALIDA'*/
        public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AM-AGENCIA MANTENEDORA DA CONTA COR     ");
        /*"  10 FILLER PIC X(083) VALUE 'AN-CONTA CORRENTE / DV DO FAVORECID     'O INVALIDO'*/
        public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AN-CONTA CORRENTE / DV DO FAVORECID     ");
        /*"  10 FILLER PIC X(083) VALUE 'AO-NOME DO FAVORECIDO NAO INFORMADO     ''*/
        public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AO-NOME DO FAVORECIDO NAO INFORMADO     ");
        /*"  10 FILLER PIC X(083) VALUE 'AP-DATA DE LANCAMENTO INVALIDO'*/
        public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AP-DATA DE LANCAMENTO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AQ-TIPO/QUANTIDADE DE MOEDA INVALID     'O'*/
        public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AQ-TIPO/QUANTIDADE DE MOEDA INVALID     ");
        /*"  10 FILLER PIC X(083) VALUE 'AR-VALOR DO LANCAMENTO INVALIDO'*/
        public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AR-VALOR DO LANCAMENTO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'AS-AVISO AO FAVORECIDO - IDENTIFICA     'CAO INVALIDA'*/
        public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AS-AVISO AO FAVORECIDO - IDENTIFICA     ");
        /*"  10 FILLER PIC X(083) VALUE 'AT-TIPO/NUMERO DE INSCRICAO DO FAVO     'RECIDO INVALIDO'*/
        public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AT-TIPO/NUMERO DE INSCRICAO DO FAVO     ");
        /*"  10 FILLER PIC X(083) VALUE 'AU-LOGRADOURO DO FAVORECIDO NAO INF     'ORMADO'*/
        public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AU-LOGRADOURO DO FAVORECIDO NAO INF     ");
        /*"  10 FILLER PIC X(083) VALUE 'AV-NUMERO DO LOCAL DO FAVORECIDO NA     'O INFORMADO'*/
        public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AV-NUMERO DO LOCAL DO FAVORECIDO NA     ");
        /*"  10 FILLER PIC X(083) VALUE 'AW-CIDADE DO FAVORECIDO NAO INFORMA     'DO'*/
        public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AW-CIDADE DO FAVORECIDO NAO INFORMA     ");
        /*"  10 FILLER PIC X(083) VALUE 'AX-CEP/COMPLEMENTO DO FAVORECIDO IN     'VALIDO'*/
        public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AX-CEP/COMPLEMENTO DO FAVORECIDO IN     ");
        /*"  10 FILLER PIC X(083) VALUE 'AY-SIGLA DO ESTADO DO FAVORECIDO IN     'VALIDA'*/
        public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AY-SIGLA DO ESTADO DO FAVORECIDO IN     ");
        /*"  10 FILLER PIC X(083) VALUE 'AZ-CODIGO/NOME DO BANCO DEPOSITARIO     ' INVALIDO'*/
        public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"AZ-CODIGO/NOME DO BANCO DEPOSITARIO     ");
        /*"  10 FILLER PIC X(083) VALUE 'BA-CODIGO/NOME DA AGENCIA DEPOSITAR     'IA NAO INFORMADO'*/
        public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"BA-CODIGO/NOME DA AGENCIA DEPOSITAR     ");
        /*"  10 FILLER PIC X(083) VALUE 'BB-SEU NUMERO INVALIDO'*/
        public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"BB-SEU NUMERO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'BC-NOSSO NUMERO INVALIDO'*/
        public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"BC-NOSSO NUMERO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'BD-INCLUSAO EFETUADA COM SUCESSO'*/
        public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"BD-INCLUSAO EFETUADA COM SUCESSO");
        /*"  10 FILLER PIC X(083) VALUE 'BE-ALTERACAO EFETUADA COM SUCESSO'*/
        public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"BE-ALTERACAO EFETUADA COM SUCESSO");
        /*"  10 FILLER PIC X(083) VALUE 'BF-EXCLUSAO EFETUADA COM SUCESSO'*/
        public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"BF-EXCLUSAO EFETUADA COM SUCESSO");
        /*"  10 FILLER PIC X(083) VALUE 'BG-AGENCIA/CONTA IMPEDIDA LEGALMENT     'E'*/
        public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"BG-AGENCIA/CONTA IMPEDIDA LEGALMENT     ");
        /*"  10 FILLER PIC X(083) VALUE 'CA-CODIGO DE BARRAS - CODIGO DO BAN     'CO INVALIDO'*/
        public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CA-CODIGO DE BARRAS - CODIGO DO BAN     ");
        /*"  10 FILLER PIC X(083) VALUE 'CB-CODIGO DE BARRAS - CODIGO DA MOE     'DA INVALIDA'*/
        public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CB-CODIGO DE BARRAS - CODIGO DA MOE     ");
        /*"  10 FILLER PIC X(083) VALUE 'CC-CODIGO DE BARRAS - DIGITO VERIFI     'CADOR GERAL INVALIDO'*/
        public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CC-CODIGO DE BARRAS - DIGITO VERIFI     ");
        /*"  10 FILLER PIC X(083) VALUE 'CD-CODIGO DE BARRAS - VALOR DO TITU     'LO INVALIDO'*/
        public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CD-CODIGO DE BARRAS - VALOR DO TITU     ");
        /*"  10 FILLER PIC X(083) VALUE 'CE-CODIGO DE BARRAS - CAMPO LIVRE I     'NVALIDO'*/
        public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CE-CODIGO DE BARRAS - CAMPO LIVRE I     ");
        /*"  10 FILLER PIC X(083) VALUE 'CF-VALOR DO DOCUMENTO INVALIDO'*/
        public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CF-VALOR DO DOCUMENTO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CG-VALOR DO ABATIMENTO INVALIDO'*/
        public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CG-VALOR DO ABATIMENTO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CH-VALOR DO DESCONTO INVALIDO'*/
        public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CH-VALOR DO DESCONTO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CI-VALOR DE MORA INVALIDO'*/
        public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CI-VALOR DE MORA INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CJ-VALOR DA MULTA INVALIDO'*/
        public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CJ-VALOR DA MULTA INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CK-VALOR DO IR INVALIDO'*/
        public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CK-VALOR DO IR INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CL-VALOR DO ISS INVALIDO'*/
        public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CL-VALOR DO ISS INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CM-VALOR DO IOF INVALIDO'*/
        public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CM-VALOR DO IOF INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CN-VALOR DE OUTRAS DEDUCOES INVALID     'O'*/
        public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CN-VALOR DE OUTRAS DEDUCOES INVALID     ");
        /*"  10 FILLER PIC X(083) VALUE 'CO-VALOR DE OUTROS ACRESCIMOS INVAL     'IDO'*/
        public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CO-VALOR DE OUTROS ACRESCIMOS INVAL     ");
        /*"  10 FILLER PIC X(083) VALUE 'CP-VALOR DO INSS INVALIDO'*/
        public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CP-VALOR DO INSS INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'CQ-CODIGO DE BARRAS INVALIDO'*/
        public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"CQ-CODIGO DE BARRAS INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'TA-LOTE NAO ACEITO - TOTAIS DE LOTE     ' COM DIFERENCA'*/
        public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"TA-LOTE NAO ACEITO - TOTAIS DE LOTE     ");
        /*"  10 FILLER PIC X(083) VALUE 'TB-LOTE SEM TRAILLER'*/
        public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"TB-LOTE SEM TRAILLER");
        /*"  10 FILLER PIC X(083) VALUE 'TC-LOTE DE ARQUIVO SEM TRAILLER'*/
        public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"TC-LOTE DE ARQUIVO SEM TRAILLER");
        /*"  10 FILLER PIC X(083) VALUE 'YA-TITULO NAO ENCONTRADO'*/
        public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"YA-TITULO NAO ENCONTRADO");
        /*"  10 FILLER PIC X(083) VALUE 'YB-IDENTIFICADOR REGISTRO OPCIONAL     'INVALIDO'*/
        public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"YB-IDENTIFICADOR REGISTRO OPCIONAL     ");
        /*"  10 FILLER PIC X(083) VALUE 'YC-CODIGO PADRAO INVALIDO'*/
        public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"YC-CODIGO PADRAO INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'YD-CODIGO DE OCORRENCIA INVALIDO'*/
        public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"YD-CODIGO DE OCORRENCIA INVALIDO");
        /*"  10 FILLER PIC X(083) VALUE 'YE-COMPLEMENTO DE OCORRENCIA INVALI     'DO'*/
        public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"YE-COMPLEMENTO DE OCORRENCIA INVALI     ");
        /*"  10 FILLER PIC X(083) VALUE 'YF-ALEGACAO JA INFORMADA'*/
        public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"YF-ALEGACAO JA INFORMADA");
        /*"  10 FILLER PIC X(083) VALUE 'ZA-AGENCIA/CONTA DO FAVORECIDO SUBS     'TITUIDA'*/
        public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"ZA-AGENCIA/CONTA DO FAVORECIDO SUBS     ");
        /*"  10 FILLER PIC X(083) VALUE 'YF-ALEGACAO JA INFORMADA'*/
        public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"YF-ALEGACAO JA INFORMADA");
        /*"  10 FILLER PIC X(083) VALUE 'ZA-AGENCIA/CONTA DO FAVORECIDO SUBS     'TITUIDA'*/
        public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"ZA-AGENCIA/CONTA DO FAVORECIDO SUBS     ");
        /*"01 TABELA-COD-SIACC-240-R  REDEFINES  TABELA-COD-SIACC-240*/
    }
}