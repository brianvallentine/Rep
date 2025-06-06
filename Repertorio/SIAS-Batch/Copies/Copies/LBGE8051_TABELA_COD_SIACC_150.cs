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
    public class LBGE8051_TABELA_COD_SIACC_150 : VarBasis
    {
        /*" 10 FILLER PIC X(086) VALUE '000000DEBITO/CREDITO EFETUADO OU INC                            'LUSAO DE CADASTRO'*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"000000DEBITO/CREDITO EFETUADO OU INC                            ");
        /*" 10 FILLER PIC X(086) VALUE '0104HGNUMERO DA REMESSA INVALIDO'*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0104HGNUMERO DA REMESSA INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '0204HJARQUIVO SEM HEADER'*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0204HJARQUIVO SEM HEADER");
        /*" 10 FILLER PIC X(086) VALUE '0304HETIPO REGISTRO INVALIDO'*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0304HETIPO REGISTRO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '0404ALCODIGO BANCO INVALIDO'*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0404ALCODIGO BANCO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '050101INSUFICIENCIA DE FUNDOS'*/
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"050101INSUFICIENCIA DE FUNDOS");
        /*" 10 FILLER PIC X(086) VALUE '0604ACTIPO SERVICO INVALIDO'*/
        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0604ACTIPO SERVICO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '0704AFCODIGO DO CONVENIO INVALIDO'*/
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0704AFCODIGO DO CONVENIO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '0804HICODIGO DA REMESSA INVALIDO'*/
        public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0804HICODIGO DA REMESSA INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '0904ANOUTRAS RESTRICOES'*/
        public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"0904ANOUTRAS RESTRICOES");
        /*" 10 FILLER PIC X(086) VALUE '1004ABTIPO DE OPERACAO INVALIDO'*/
        public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1004ABTIPO DE OPERACAO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1114HDAGENCIA INVALIDA'*/
        public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1114HDAGENCIA INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE '1214HDNUMERO DA CONTA INVALIDO'*/
        public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1214HDNUMERO DA CONTA INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1304HHNUMERO DE LOTE INVALIDO'*/
        public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1304HHNUMERO DE LOTE INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1404AICODIGO SEGMENTO INVALIDO'*/
        public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1404AICODIGO SEGMENTO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1504AJTIPO MOVIMENTO INVALIDO'*/
        public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1504AJTIPO MOVIMENTO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1604ALBANCO FAVORECIDO INVALIDO'*/
        public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1604ALBANCO FAVORECIDO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1704AONOME DO FAVORECIDO INVALIDO'*/
        public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1704AONOME DO FAVORECIDO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1804BBSEU NUMERO INVALIDO'*/
        public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1804BBSEU NUMERO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '1913BCDATA DE PAGAMENTO INVALIDO'*/
        public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"1913BCDATA DE PAGAMENTO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '2004AQTIPO DE MOEDA INVALIDO'*/
        public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2004AQTIPO DE MOEDA INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '2104AQQUANTIDADE DE MOEDA INVALIDA'*/
        public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2104AQQUANTIDADE DE MOEDA INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE '2212ARVALOR DE PAGAMENTO INVALIDO'*/
        public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2212ARVALOR DE PAGAMENTO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '2304ATTIPO DE INSCRICAO INVALIDO'*/
        public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2304ATTIPO DE INSCRICAO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '2404ATNUMERO DE INSCRICAO INVALIDO'*/
        public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2404ATNUMERO DE INSCRICAO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '2504AULOGRADOURO/COMPLEMENTO INVALID                            'O'*/
        public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2504AULOGRADOURO/COMPLEMENTO INVALID                            ");
        /*" 10 FILLER PIC X(086) VALUE '2604AVNUM.LOCAL DO FAVORECIDO INVALI                            'DO'*/
        public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2604AVNUM.LOCAL DO FAVORECIDO INVALI                            ");
        /*" 10 FILLER PIC X(086) VALUE '2704AVCODIGO DOCUMENTO FAVORECIDO IN                            'VALIDO'*/
        public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2704AVCODIGO DOCUMENTO FAVORECIDO IN                            ");
        /*" 10 FILLER PIC X(086) VALUE '2804AXBAIRRO DO FAVORECIDO INVALIDO'*/
        public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2804AXBAIRRO DO FAVORECIDO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '2904AWCIDADE DO FAVORECIDO INVALIDA'*/
        public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"2904AWCIDADE DO FAVORECIDO INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE '3004AXNUM. CEP/COMPLEMENTO INVALIDO'*/
        public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3004AXNUM. CEP/COMPLEMENTO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '3104AYESTADO DO FAVORECIDO INVALIDO'*/
        public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3104AYESTADO DO FAVORECIDO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '3204CQCODIGO DE BARRAS INVALIDO'*/
        public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3204CQCODIGO DE BARRAS INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '3304HBNOME DO CEDENTE INVALIDO'*/
        public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3304HBNOME DO CEDENTE INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '3413APDATA DE VENCIMENTO INVALIDA'*/
        public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3413APDATA DE VENCIMENTO INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE '3512CDVALOR DO TITULO INVALIDO'*/
        public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3512CDVALOR DO TITULO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '3604TCQTDE REGIST.LOTE C/DIFERENCA'*/
        public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3604TCQTDE REGIST.LOTE C/DIFERENCA");
        /*" 10 FILLER PIC X(086) VALUE '3704TCVALOR REGIST.LOTE C/DIFERENCA'*/
        public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3704TCVALOR REGIST.LOTE C/DIFERENCA");
        /*" 10 FILLER PIC X(086) VALUE '3804TBLOTE SEM TRAILLER'*/
        public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3804TBLOTE SEM TRAILLER");
        /*" 10 FILLER PIC X(086) VALUE '3904TCREMESSA SEM TRAILLER'*/
        public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"3904TCREMESSA SEM TRAILLER");
        /*" 10 FILLER PIC X(086) VALUE '4004TCTOTAL REGISTROS DO TRAILLER IN                            'VALIDO'*/
        public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4004TCTOTAL REGISTROS DO TRAILLER IN                            ");
        /*" 10 FILLER PIC X(086) VALUE '4104TCVALOR TOTAL REGISTROS DO TRAIL                            'L INVALIDO'*/
        public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4104TCVALOR TOTAL REGISTROS DO TRAIL                            ");
        /*" 10 FILLER PIC X(086) VALUE '4204TALOTE FORA DE SEQ�ENCIA'*/
        public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4204TALOTE FORA DE SEQ�ENCIA");
        /*" 10 FILLER PIC X(086) VALUE '4304HBNOME EMPRESA INVALIDO'*/
        public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4304HBNOME EMPRESA INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '4404TCNUM.SEQ. DE REGISTRO INVALIDO'*/
        public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4404TCNUM.SEQ. DE REGISTRO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '4504AZNOME DO BANCO INVALIDO'*/
        public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4504AZNOME DO BANCO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '4613TCDATA MOVIMENTO INVALIDA'*/
        public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4613TCDATA MOVIMENTO INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE '4704HCIDENTIFICACAO CLIENTE EMPRESA                            'INVALIDO'*/
        public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4704HCIDENTIFICACAO CLIENTE EMPRESA                            ");
        /*" 10 FILLER PIC X(086) VALUE '4804ANCODIGO DO MOVIMENTO INVALIDO'*/
        public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4804ANCODIGO DO MOVIMENTO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '4904TCTOT. LOTE NO ARQ C/DIFERENCA'*/
        public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"4904TCTOT. LOTE NO ARQ C/DIFERENCA");
        /*" 10 FILLER PIC X(086) VALUE '5004HCCONVENIO NAO CADASTRADO'*/
        public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5004HCCONVENIO NAO CADASTRADO");
        /*" 10 FILLER PIC X(086) VALUE '5104TCPARAMETRO TRANSMISSAO NAO CADA                            'STRADO'*/
        public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5104TCPARAMETRO TRANSMISSAO NAO CADA                            ");
        /*" 10 FILLER PIC X(086) VALUE '5204TCCOMPROMISSO NAO CADASTRADO'*/
        public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5204TCCOMPROMISSO NAO CADASTRADO");
        /*" 10 FILLER PIC X(086) VALUE '5314BAAGENCIA INATIVA'*/
        public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5314BAAGENCIA INATIVA");
        /*" 10 FILLER PIC X(086) VALUE '5404BDAGENDAMENTO JA EFETIVADO'*/
        public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5404BDAGENDAMENTO JA EFETIVADO");
        /*" 10 FILLER PIC X(086) VALUE '5504TBLOTE SEM HEADER'*/
        public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5504TBLOTE SEM HEADER");
        /*" 10 FILLER PIC X(086) VALUE '5604TCTIPO DE OPERACAO INVALIDO'*/
        public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5604TCTIPO DE OPERACAO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '5714BAAGENCIA INVALIDA'*/
        public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5714BAAGENCIA INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE '5804TCCADASTRAMENTO CONVENIO INCOMPL                            'ETO'*/
        public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5804TCCADASTRAMENTO CONVENIO INCOMPL                            ");
        /*" 10 FILLER PIC X(086) VALUE '5904TCSITUACAO ATUAL CONVENIO NAO AT                            'IVO'*/
        public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"5904TCSITUACAO ATUAL CONVENIO NAO AT                            ");
        /*" 10 FILLER PIC X(086) VALUE '6002HBCONTA A DEBITAR INEXISTENTE NO                            ' CADASTRO DE OPTANTES'*/
        public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6002HBCONTA A DEBITAR INEXISTENTE NO                            ");
        /*" 10 FILLER PIC X(086) VALUE '6102HBCONTA COMPROMISSO INVALIDA.62-                            'NUMERO DO CONVENIO INVALIDO'*/
        public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6102HBCONTA COMPROMISSO INVALIDA.62-                            ");
        /*" 10 FILLER PIC X(086) VALUE '6304HBTIPO DE COMPROMISSO INVALIDO'*/
        public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6304HBTIPO DE COMPROMISSO INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '6404HBNUMERO DE COMPROMISSO INVALIDO                            ''*/
        public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6404HBNUMERO DE COMPROMISSO INVALIDO                            ");
        /*" 10 FILLER PIC X(086) VALUE '6504TBMAIS DE 1 TRAILLER NA REMESSA'*/
        public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6504TBMAIS DE 1 TRAILLER NA REMESSA");
        /*" 10 FILLER PIC X(086) VALUE '6604TCREMESSA COM ERRO'*/
        public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6604TCREMESSA COM ERRO");
        /*" 10 FILLER PIC X(086) VALUE '6713ANDATA OPCAO INVALIDA'*/
        public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6713ANDATA OPCAO INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE '6804ANQTDE MOEDA LOTE C/DIFERENCA'*/
        public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6804ANQTDE MOEDA LOTE C/DIFERENCA");
        /*" 10 FILLER PIC X(086) VALUE '6904ANOPTANTE JA CADASTRADO PARA EST                            'E CONVENIO'*/
        public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"6904ANOPTANTE JA CADASTRADO PARA EST                            ");
        /*" 10 FILLER PIC X(086) VALUE '7004ANINDICACAO DE AVISO SEM ENDEREC                            'O'*/
        public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7004ANINDICACAO DE AVISO SEM ENDEREC                            ");
        /*" 10 FILLER PIC X(086) VALUE '7104CACOD. DE BARRAS/COD. BANCO INVA    'LIDO'*/
        public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7104CACOD. DE BARRAS/COD. BANCO INVA    ");
        /*" 10 FILLER PIC X(086) VALUE '7204CBCOD. DE BARRAS/CODMOEDA INVALI                            'DO'*/
        public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7204CBCOD. DE BARRAS/CODMOEDA INVALI                            ");
        /*" 10 FILLER PIC X(086) VALUE '7304CCCOD DE BARRAS/DIGITO VERIFICAD                            'OR GERAL INVALIDO'*/
        public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7304CCCOD DE BARRAS/DIGITO VERIFICAD                            ");
        /*" 10 FILLER PIC X(086) VALUE '7404CFCODIGO DE BARRAS/VALOR DO TITU                            'LO INVALIDO'*/
        public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7404CFCODIGO DE BARRAS/VALOR DO TITU                            ");
        /*" 10 FILLER PIC X(086) VALUE '7604ANQUANTIDADE DE PARCELAS INVALID                            'A'*/
        public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7604ANQUANTIDADE DE PARCELAS INVALID                            ");
        /*" 10 FILLER PIC X(086) VALUE '7704ANINDICADOR BLOQUEIO PARCELA INV                            'ALIDO'*/
        public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7704ANINDICADOR BLOQUEIO PARCELA INV                            ");
        /*" 10 FILLER PIC X(086) VALUE '783002CADASTRO DE OPTANTES INEXISTEN                            'TE'*/
        public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"783002CADASTRO DE OPTANTES INEXISTEN                            ");
        /*" 10 FILLER PIC X(086) VALUE '7904ANOPCAO DE AVISO SEM ENDERECO'*/
        public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"7904ANOPCAO DE AVISO SEM ENDERECO");
        /*" 10 FILLER PIC X(086) VALUE '8004ANOPCAO DE DOC/OP SEM ENDERECO'*/
        public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8004ANOPCAO DE DOC/OP SEM ENDERECO");
        /*" 10 FILLER PIC X(086) VALUE '8102ANCONTA NAO CADASTRADA'*/
        public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8102ANCONTA NAO CADASTRADA");
        /*" 10 FILLER PIC X(086) VALUE '8202ANTIPO DE CONTA INVALIDO'*/
        public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8202ANTIPO DE CONTA INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '8304ANTIPO DE OPERACAO DIVERGE DE TI                            'PO DE COMPROMISSO'*/
        public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8304ANTIPO DE OPERACAO DIVERGE DE TI                            ");
        /*" 10 FILLER PIC X(086) VALUE '8404ANTIPO DE OPERACAO DIVERGE COM T                            'IPO DE SERVICO'*/
        public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8404ANTIPO DE OPERACAO DIVERGE COM T                            ");
        /*" 10 FILLER PIC X(086) VALUE '8513ANDATA CANCELAMENTO EXPIRADA'*/
        public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8513ANDATA CANCELAMENTO EXPIRADA");
        /*" 10 FILLER PIC X(086) VALUE '8604ANAGENDAMENTO NAO ENCONTRADO'*/
        public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8604ANAGENDAMENTO NAO ENCONTRADO");
        /*" 10 FILLER PIC X(086) VALUE '8712ANVALOR DO DEBITO MAIOR QUE O VA                            'LOR LIMITE'*/
        public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8712ANVALOR DO DEBITO MAIOR QUE O VA                            ");
        /*" 10 FILLER PIC X(086) VALUE '8804AAINDICE INVALIDO'*/
        public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8804AAINDICE INVALIDO");
        /*" 10 FILLER PIC X(086) VALUE '8913ANDATA ATUAL DO COMPROMISSO NAO                            'ATIVA'*/
        public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"8913ANDATA ATUAL DO COMPROMISSO NAO                            ");
        /*" 10 FILLER PIC X(086) VALUE '9004ANHISTORICO NAO CADASTRADO'*/
        public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9004ANHISTORICO NAO CADASTRADO");
        /*" 10 FILLER PIC X(086) VALUE '9104ANREGISTRO JA EXISTENTE NA BASE'*/
        public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9104ANREGISTRO JA EXISTENTE NA BASE");
        /*" 10 FILLER PIC X(086) VALUE '9204ANFORMA PARCELAMENTO/PERIODO INV                            'ALIDO'*/
        public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9204ANFORMA PARCELAMENTO/PERIODO INV                            ");
        /*" 10 FILLER PIC X(086) VALUE '9304ANERRO NO ACESSO TAB PARAMETRO D                            'E OPTANTES'*/
        public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9304ANERRO NO ACESSO TAB PARAMETRO D                            ");
        /*" 10 FILLER PIC X(086) VALUE '9404ANCONVENIO NAO CADASTRADO NA TAB                            ' PARAMETRO OPTANTES'*/
        public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9404ANCONVENIO NAO CADASTRADO NA TAB                            ");
        /*" 10 FILLER PIC X(086) VALUE '9513ANARQUIVO COM DATA VENCIMENTO IN                            'FERIOR A 03 DIAS UTEIS'*/
        public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9513ANARQUIVO COM DATA VENCIMENTO IN                            ");
        /*" 10 FILLER PIC X(086) VALUE '9696ANMANUTENCAO DE CADASTRO'*/
        public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9696ANMANUTENCAO DE CADASTRO");
        /*" 10 FILLER PIC X(086) VALUE '9704ANCAMARA DE COMPENSACAO INVALIDA                            ''*/
        public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"9704ANCAMARA DE COMPENSACAO INVALIDA                            ");
        /*" 10 FILLER PIC X(086) VALUE '999902CANCELAMENTO - CANCELADO CONFO                     'RME SOLICITACAO DA EMPRESA OU DO CLIENTE'*/
        public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"999902CANCELAMENTO - CANCELADO CONFO                     ");
        /*" 10 FILLER PIC X(086) VALUE 'AA0402INCLUSAO DE OPTANTE NAO EFETUA    'DA - CADASTRO REJEITADO PELO CLIENTE'*/
        public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"AA0402INCLUSAO DE OPTANTE NAO EFETUA    ");
        /*" 10 FILLER PIC X(086) VALUE 'AB0402INCLUSAO DE OPTANTE NAO EFETUA                            'DO'*/
        public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"AB0402INCLUSAO DE OPTANTE NAO EFETUA                            ");
        /*" 10 FILLER PIC X(086) VALUE 'BD04BDINCLUSAO EFETUADA COM SUCESSO'*/
        public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"BD04BDINCLUSAO EFETUADA COM SUCESSO");
        /*" 10 FILLER PIC X(086) VALUE 'HE0402TIPO DE SERVICO INVALIDO PARA                            'O CONTRATO'*/
        public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"HE0402TIPO DE SERVICO INVALIDO PARA                            ");
        /*" 10 FILLER PIC X(086) VALUE 'B10402BLOQUEIO DE CADASTRO SOLICITAD                            'O PELO CLIENTE'*/
        public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"B10402BLOQUEIO DE CADASTRO SOLICITAD                            ");
        /*" 10 FILLER PIC X(086) VALUE 'D104ANDESBLOQUEIO DE CADASTRO SOLICI                            'TADO PELO CLIENTE'*/
        public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"D104ANDESBLOQUEIO DE CADASTRO SOLICI                            ");
        /*" 10 FILLER PIC X(086) VALUE 'LD04ANVERSAO DO LEIAUTE INCOMPATIVEL                        ' PARA O TIPO CADASTRADO NO COMPROMISSO'*/
        public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"LD04ANVERSAO DO LEIAUTE INCOMPATIVEL                        ");
        /*" 10 FILLER PIC X(086) VALUE 'R10402OPERACAO/TIPO DE CONTA NAO ATI                            'VADA PARA O COMPROMISSO'*/
        public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"R10402OPERACAO/TIPO DE CONTA NAO ATI                            ");
        /*" 10 FILLER PIC X(086) VALUE 'DP04ANDEBITO/CREDITO - VALOR PARCIAL                            ''*/
        public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"DP04ANDEBITO/CREDITO - VALOR PARCIAL                            ");
        /*" 10 FILLER PIC X(086) VALUE 'C10101INSUFICIENCIA DE FUNDOS - CONT                            'A SALARIO COM PORTABILIDADE'*/
        public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"C10101INSUFICIENCIA DE FUNDOS - CONT                            ");
        /*" 10 FILLER PIC X(086) VALUE 'DT18ANDATA DE VENCIMENTO INVALIDA'*/
        public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"DT18ANDATA DE VENCIMENTO INVALIDA");
        /*" 10 FILLER PIC X(086) VALUE 'AD04ANCODIGO DOC FAVORECIDO INVALIDO                            ''*/
        public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"AD04ANCODIGO DOC FAVORECIDO INVALIDO                            ");
        /*" 10 FILLER PIC X(086) VALUE 'CH0402INCLUSAO DE OPTANTE NAO EFETUA                 'DA - OPCAO DE USO DO CHEQUE ESPECIAL INVALIDA'*/
        public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"CH0402INCLUSAO DE OPTANTE NAO EFETUA                 ");
        /*" 10 FILLER PIC X(086) VALUE 'PV0402INCLUSAO DE OPTANTE NAO EFETUA              'DA OPCAO DEBITO INT OU PARC APOS VENCTO INVALIDA'*/
        public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"PV0402INCLUSAO DE OPTANTE NAO EFETUA              ");
        /*" 10 FILLER PIC X(086) VALUE 'FP1802FORA DO PRAZO - CADASTRO DO OP                            'TANTE X VENCIMENTO'*/
        public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"FP1802FORA DO PRAZO - CADASTRO DO OP                            ");
        /*" 10 FILLER PIC X(086) VALUE 'F21802FORA DO PRAZO - DATA DE REMESS                            'A X VENCIMENTO'*/
        public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"F21802FORA DO PRAZO - DATA DE REMESS                            ");
        /*" 10 FILLER PIC X(086) VALUE 'F31802FORA DO PRAZO - DATA DE REMESS                            'A X VENCIMENTO'*/
        public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"F31802FORA DO PRAZO - DATA DE REMESS                            ");
        /*" 10 FILLER PIC X(086) VALUE 'F41802FORA DO PRAZO - DATA DE VALIDA                            'DE DO OPTANTE EXPIRADA'*/
        public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"F41802FORA DO PRAZO - DATA DE VALIDA                            ");
        /*"01 TABELA-COD-SIACC-150-R REDEFINES TABELA-COD-SIACC-150*/
    }
}