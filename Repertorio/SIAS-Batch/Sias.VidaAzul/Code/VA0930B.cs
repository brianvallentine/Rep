using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Copies;
using Sias.VidaAzul.DB2.VA0930B;

namespace Code
{
    public class VA0930B
    {
        public bool IsCall { get; set; }

        public VA0930B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     GERA ARQUIVO ANALITICO COM TODOS ENDOSSOS REALIZADOS NO    *      */
        /*"V.10  *     DIA PARA OS SEGUROS INDIVIDUAIS E EM GRUPO.                *      */
        /*"=     *                                                                *      */
        /*"=     ******************************************************************      */
        /*"=     *     A VERSAO V.10 PASSOU A TER A OPCAO DE RETOMADA COM         *      */
        /*"=     *     PARAMETRO DATA DO MOVIMENTO NO FORMATO:                    *      */
        /*"=     *                                                                *      */
        /*"=     *     RAAAA-MM-DD                                                *      */
        /*"=     *     ||                                                         *      */
        /*"=     *     ||--> DATA DO MOVIMENTO A PROCESSAR                        *      */
        /*"=     *     |                                                          *      */
        /*"=     *     |---> TIPO DE PROCESSAMENTO ('R'- RETOMADA)                *      */
        /*"=     *                                                                *      */
        /*"=     *     SE PARAMETRO NAO INFORMADO O PROGRAMA BUSCA DTMOVABE.      *      */
        /*"=     *                                                                *      */
        /*"=     *     EXEMPLO:                                                   *      */
        /*"=     *     //SYSTSIN  DD   *                                          *      */
        /*"=     *       DSN SYSTEM(DB2P)                                         *      */
        /*"=     *       RUN PROGRAM(VA0930B) PLAN(SIASBAT) LIB('PRD.V01.LOAD') - *      */
        /*"=     *       PARMS('R2022-10-07')                                     *      */
        /*"=     *       END                                                      *      */
        /*"=     *                                                                *      */
        /*"V.10  ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     ALTERACOES                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 08/11/2022 - BRICE HO                      V.10  *      */
        /*"      *   OBJETIVO: INCIDENTE 434.480                                  *      */
        /*"      *             INCLUIR PARAMETRO DATA PARA RETOMADA.              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 10/10/2022 - BRICE HO                      V.09  *      */
        /*"      *   OBJETIVO: INCIDENTE 434.480                                  *      */
        /*"      *             AJUSTES ROTINA R1109-00-RECUPERA-NOVO-CERT.        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 24/11/2021 - BRICE HO                      V.08  *      */
        /*"      *   OBJETIVO: INCIDENTE 336.364                                  *      */
        /*"      *             AJUSTES ROTINA R1103-00-VERIFICA-RESTITUICAO.      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 02/12/2020 - MARCO PAIVA                   V.07  *      */
        /*"      *   OBJETIVO: CADMUS 235.207 - AJUSTE PARA SELECIONAR REGISTRO   *      */
        /*"      *   QUANDO ALTERADO DIA DEBITO PELA SPBVA007.                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 11/06/2020 - THIAGO BLAIER                 V.06  *      */
        /*"      *   OBJETIVO: DEMANDA 241000 - RESTRUTURACAO DO ATALHO DE        *      */
        /*"      *   BILHETE, ATALHO CB58 CANCELAMENTO DE BILHETE.                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 31/01/2019 - FRANK CARVALHO                V.05  *      */
        /*"      *   OBJETIVO: CADMUS 171.935 - ABEND -811 - ALTERADO A QUERY DO  *      */
        /*"      *   PARA NAO RECUPERAR CERTIFICADOS DECLINADOS OU CANCELADOS.    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CIELO - ADEQUA�AO AO CAMPO NUM_CARTAO_CREDITO    *      */
        /*"      *               O NUMERO DO CARTAO DE CREDITO FOI ALTERADO NA    *      */
        /*"      *               TABELA OPCAO_PAG_VIDAZUL PARA CHAR(16), POIS O   *      */
        /*"      *               NUMERO QUE O LEGADO RECEBE ESTA MASCARADO COM "*"*      */
        /*"      *               A TABELAS HISTCONTAVA RECEBERA ZEROS.            *      */
        /*"      *   EM 05/08/2019 - DANIEL MEDINA GOMIDE - MILLENIUM             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 26/01/2018 - FRANK CARVALHO(INDRA)         V.04  *      */
        /*"      *   OBJETIVO: CADMUS 159.930 - ABEND -811 - ABEND CAUSADO POR    *      */
        /*"      *   DADOS INCORRETOS NA BASE, FOI FEITO UMA TRATATIVA PARA EVITAR*      */
        /*"      *   NOVOS ABENDS.                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 10/07/2017 - FRANK CARVALHO(INDRA)         V.03  *      */
        /*"      *   OBJETIVO: CADMUS 151.934 - ALTERAR A DISPOSICAO CRIANDO      *      */
        /*"      *   COLUNAS PARA CADA TIPO DE ENDOSSO AO INVES DE USAR O CAMPO   *      */
        /*"      *   DADOS-ALTERADOS.                                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 16/03/2017 - FRANK CARVALHO(INDRA)         V.02  *      */
        /*"      *   OBJETIVO: ABEND  149.076 - ABEND OCORREU POIS HOUVE UMA ALTE-*      */
        /*"      *   RACAO DE SUBGRUPO E FORAM CADASTRADOS DOIS NOVOS CERTIFICADOS*      */
        /*"      *   SENDO QUE UM ESTAVA EMITIDO E UM CANCELADO. OCORREU -811.    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERADO EM 20/07/2016 - FRANK CARVALHO(INDRA)         V.01  *      */
        /*"      *   OBJETIVO: CADMUS 135.964 - ALTERAR O RELATORIO INFORMANDO    *      */
        /*"      *   OS TIPOS DE ALTERACOES EFETUADAS NO ENDOSSO.                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     00     *  12/01/16  *   LUIGI C.   *      IMPLANTACAO      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _AVA0930B { get; set; } = new FileBasis(new PIC("X", "1403", "X(1403)"));

        public FileBasis AVA0930B
        {
            get
            {
                _.Move(REG_AVA0930B, _AVA0930B); VarBasis.RedefinePassValue(REG_AVA0930B, _AVA0930B, REG_AVA0930B); return _AVA0930B;
            }
        }
        public SortBasis<VA0930B_REG_SVA0930B> SVA0930B { get; set; } = new SortBasis<VA0930B_REG_SVA0930B>(new VA0930B_REG_SVA0930B());
        /*"01            REG-AVA0930B        PIC X(1403).*/
        public StringBasis REG_AVA0930B { get; set; } = new StringBasis(new PIC("X", "1403", "X(1403)."), @"");
        /*"01  REG-SVA0930B.*/
        public VA0930B_REG_SVA0930B REG_SVA0930B { get; set; } = new VA0930B_REG_SVA0930B();
        public class VA0930B_REG_SVA0930B : VarBasis
        {
            /*"    05  SVA-TIP-REL                    PIC  9(001).*/
            public IntBasis SVA_TIP_REL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05  SVA-APOLICE                    PIC  9(013).*/
            public IntBasis SVA_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05  SVA-CODSUBES                   PIC  9(004).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  SVA-NRCERTIF                   PIC  9(015).*/
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  SVA-CODPRODU                   PIC  9(004).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  SVA-NOMPRODU                   PIC  X(030).*/
            public StringBasis SVA_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  SVA-CGCCPF                     PIC  9(014).*/
            public IntBasis SVA_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  SVA-NOME-RAZAO                 PIC  X(040).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  SVA-TIPO-ENDOSSO               PIC  X(050).*/
            public StringBasis SVA_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"    05  SVA-DT-ENDOSSO                 PIC  X(010).*/
            public StringBasis SVA_DT_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  SVA-CODUSU                     PIC  X(008).*/
            public StringBasis SVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-NOMUSU                     PIC  X(040).*/
            public StringBasis SVA_NOMUSU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  SVA-TIPO-PESSOA                PIC  X(002).*/
            public StringBasis SVA_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  SVA-DT-NASC                    PIC  X(010).*/
            public StringBasis SVA_DT_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  SVA-DADOS-ALTERADOS            PIC  X(050).*/
            public StringBasis SVA_DADOS_ALTERADOS { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"    05  SVA-PRM-TARIFARIO-VAR          PIC  X(015).*/
            public StringBasis SVA_PRM_TARIFARIO_VAR { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05  SVA-NUM-PARCELA                PIC S9(004).*/
            public IntBasis SVA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05  SVA-DATA-PREVISTA              PIC  X(010).*/
            public StringBasis SVA_DATA_PREVISTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  SVA-RETORNO-OPERACAO           PIC  X(030).*/
            public StringBasis SVA_RETORNO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  SVA-DIA-DEBITO                 PIC S9(004).*/
            public IntBasis SVA_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05  SVA-OPCAO-PGTO-ATUAL           PIC  X(018).*/
            public StringBasis SVA_OPCAO_PGTO_ATUAL { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
            /*"    05  SVA-OPCAO-PGTO-ANTERIOR        PIC  X(018).*/
            public StringBasis SVA_OPCAO_PGTO_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
            /*"    05  SVA-COD-AGENCIA-DEBITO         PIC S9(004).*/
            public IntBasis SVA_COD_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05  SVA-OPE-CONTA-DEBITO           PIC S9(013).*/
            public IntBasis SVA_OPE_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)."));
            /*"    05  SVA-NUM-CONTA-DEBITO           PIC S9(013).*/
            public IntBasis SVA_NUM_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)."));
            /*"    05  SVA-DIG-CONTA-DEBITO           PIC S9(004).*/
            public IntBasis SVA_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05  SVA-NUM-CARTAO-CREDITO         PIC  X(016).*/
            public StringBasis SVA_NUM_CARTAO_CREDITO { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"    05  SVA-ENDERECO                   PIC  X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05  SVA-BAIRRO                     PIC  X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05  SVA-CIDADE                     PIC  X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05  SVA-CEP                        PIC  9(009).*/
            public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  SVA-UF                         PIC  X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  SVA-DDD                        PIC S9(004).*/
            public IntBasis SVA_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05  SVA-TELEFONE                   PIC S9(009).*/
            public IntBasis SVA_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)."));
            /*"    05  SVA-NOME-ESPOSA                PIC  X(008).*/
            public StringBasis SVA_NOME_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-PROF-ESPOSA                PIC  X(008).*/
            public StringBasis SVA_PROF_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DTNASC-ESPOSA              PIC  X(008).*/
            public StringBasis SVA_DTNASC_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DPS-ESPOSA                 PIC  X(008).*/
            public StringBasis SVA_DPS_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-PROF-ATUAL                 PIC  X(020).*/
            public StringBasis SVA_PROF_ATUAL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  SVA-AGE-VENDA-BIL              PIC  X(008).*/
            public StringBasis SVA_AGE_VENDA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-FILIAL-BIL                 PIC  X(008).*/
            public StringBasis SVA_FILIAL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-NUM-BILHETE                PIC  X(008).*/
            public StringBasis SVA_NUM_BILHETE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-RAMO-BIL                   PIC  X(008).*/
            public StringBasis SVA_RAMO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-PROPOSTA-BIL               PIC  X(008).*/
            public StringBasis SVA_PROPOSTA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-NUM-BILHETE-ANT            PIC  X(008).*/
            public StringBasis SVA_NUM_BILHETE_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-COD-PRODUTO-BIL            PIC  X(008).*/
            public StringBasis SVA_COD_PRODUTO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CONVENENTE-BIL             PIC  X(008).*/
            public StringBasis SVA_CONVENENTE_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-NOME-SEGURADO-BIL          PIC  X(008).*/
            public StringBasis SVA_NOME_SEGURADO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DATA-NASC-BIL              PIC  X(008).*/
            public StringBasis SVA_DATA_NASC_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CPF-BIL                    PIC  X(008).*/
            public StringBasis SVA_CPF_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-SEXO-BIL                   PIC  X(008).*/
            public StringBasis SVA_SEXO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-ESTADO-CIVIL-BIL           PIC  X(008).*/
            public StringBasis SVA_ESTADO_CIVIL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-PROFISSAO-BIL              PIC  X(008).*/
            public StringBasis SVA_PROFISSAO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-RENDA-INDIV-BIL            PIC  X(008).*/
            public StringBasis SVA_RENDA_INDIV_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-RENDA-FAMIL-BIL            PIC  X(008).*/
            public StringBasis SVA_RENDA_FAMIL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-ENDERECO-BIL               PIC  X(008).*/
            public StringBasis SVA_ENDERECO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-BAIRRO-BIL                 PIC  X(008).*/
            public StringBasis SVA_BAIRRO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CIDADE-BIL                 PIC  X(008).*/
            public StringBasis SVA_CIDADE_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-UF-BIL                     PIC  X(008).*/
            public StringBasis SVA_UF_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CEP-BIL                    PIC  X(008).*/
            public StringBasis SVA_CEP_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DDD-BIL                    PIC  X(008).*/
            public StringBasis SVA_DDD_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-TELEFONE-BIL               PIC  X(008).*/
            public StringBasis SVA_TELEFONE_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CELULAR-BIL                PIC  X(008).*/
            public StringBasis SVA_CELULAR_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-OPCAO-COB-BIL              PIC  X(008).*/
            public StringBasis SVA_OPCAO_COB_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-IMP-SEGURADA-BIL           PIC  X(008).*/
            public StringBasis SVA_IMP_SEGURADA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-PREM-LIQUIDO-BIL           PIC  X(008).*/
            public StringBasis SVA_PREM_LIQUIDO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-IOF-BIL                    PIC  X(008).*/
            public StringBasis SVA_IOF_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-PREM-TOTAL-BIL             PIC  X(008).*/
            public StringBasis SVA_PREM_TOTAL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-AGE-BANC-INDICADOR         PIC  X(008).*/
            public StringBasis SVA_AGE_BANC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-OPE-BANC-INDICADOR         PIC  X(008).*/
            public StringBasis SVA_OPE_BANC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CTA-BANC-INDICADOR         PIC  X(008).*/
            public StringBasis SVA_CTA_BANC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DIG-CTA-INDICADOR          PIC  X(008).*/
            public StringBasis SVA_DIG_CTA_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-MATRICULA-INDICADOR        PIC  X(008).*/
            public StringBasis SVA_MATRICULA_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DATA-QUIT-BIL              PIC  X(008).*/
            public StringBasis SVA_DATA_QUIT_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-VALOR-RECIBO-BIL           PIC  X(008).*/
            public StringBasis SVA_VALOR_RECIBO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-AGE-DEBITO-BIL             PIC  X(008).*/
            public StringBasis SVA_AGE_DEBITO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-OPE-DEBITO-BIL             PIC  X(008).*/
            public StringBasis SVA_OPE_DEBITO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CTA-BANC-BIL               PIC  X(008).*/
            public StringBasis SVA_CTA_BANC_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DIG-CTA-BIL                PIC  X(008).*/
            public StringBasis SVA_DIG_CTA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CARTAO-CRED-BIL            PIC  X(008).*/
            public StringBasis SVA_CARTAO_CRED_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-NOVO-CERTIFICADO           PIC  9(015).*/
            public IntBasis SVA_NOVO_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  SVA-INCLUSAO                   PIC  X(003).*/
            public StringBasis SVA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05  SVA-ALTERACAO                  PIC  X(003).*/
            public StringBasis SVA_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05  SVA-EXCLUSAO                   PIC  X(003).*/
            public StringBasis SVA_EXCLUSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05  SVA-DATA-CANCELAMENTO          PIC  X(010).*/
            public StringBasis SVA_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  SVA-MOTIVO-CANCELAMENTO        PIC  X(120).*/
            public StringBasis SVA_MOTIVO_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
            /*"    05  SVA-NOME-CLIENTE               PIC  X(008).*/
            public StringBasis SVA_NOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-TIPO-PESSOA-CLIENTE        PIC  X(008).*/
            public StringBasis SVA_TIPO_PESSOA_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-CGCCPF-CLIENTE             PIC  X(008).*/
            public StringBasis SVA_CGCCPF_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DATA-NASCIMENTO            PIC  X(008).*/
            public StringBasis SVA_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-EMAIL-CLIENTE              PIC  X(008).*/
            public StringBasis SVA_EMAIL_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-HOUVE-RESTITUICAO          PIC  X(003).*/
            public StringBasis SVA_HOUVE_RESTITUICAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05  SVA-OPERACAO                   PIC  X(050).*/
            public StringBasis SVA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"    05  SVA-VLR-CAPITAL-ANT            PIC  X(015).*/
            public StringBasis SVA_VLR_CAPITAL_ANT { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05  SVA-VLR-CAPITAL-ATU            PIC  X(015).*/
            public StringBasis SVA_VLR_CAPITAL_ATU { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05  SVA-NOME-CLIENTE-CERT          PIC  X(008).*/
            public StringBasis SVA_NOME_CLIENTE_CERT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-DATA-NASC-CLIENTE          PIC  X(008).*/
            public StringBasis SVA_DATA_NASC_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-SEXO-CLIENTE               PIC  X(008).*/
            public StringBasis SVA_SEXO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-EST-CIVIL-CLIENTE          PIC  X(008).*/
            public StringBasis SVA_EST_CIVIL_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  SVA-NOVO-CLIENTE               PIC  X(003).*/
            public StringBasis SVA_NOVO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05  SVA-COD-CLIENTE-ANT            PIC  9(009).*/
            public IntBasis SVA_COD_CLIENTE_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  SVA-COD-CLIENTE-ATUAL          PIC  9(009).*/
            public IntBasis SVA_COD_CLIENTE_ATUAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  SVA-DATA-OPER-REMISSAO         PIC  X(010).*/
            public StringBasis SVA_DATA_OPER_REMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  SVA-DATA-RET-COBRANCA          PIC  X(010).*/
            public StringBasis SVA_DATA_RET_COBRANCA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_IDX_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77            WHOST-NRCERTIF      PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            WHOST-CGCCPF        PIC S9(15) COMP-3.*/
        public IntBasis WHOST_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            WHOST-APOLICE       PIC S9(13) COMP-3.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-CODSUBES      PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-DT-NASC       PIC  X(10).*/
        public StringBasis WHOST_DT_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WS-ERRO-FATAL       PIC  X(01) VALUE ' '.*/
        public StringBasis WS_ERRO_FATAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"77            V0BILH-NUM-APOLICE  PIC S9(13) COMP-3.*/
        public IntBasis V0BILH_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0BILH-CODCLIEN     PIC S9(09) COMP.*/
        public IntBasis V0BILH_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PROD-NOMPRODU     PIC  X(40).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            SUBGRU-COD-CLIENTE  PIC S9(09) COMP.*/
        public IntBasis SUBGRU_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTHOJE       PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-NRCERTIF     PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0PROP-APOLICE      PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0PROP-CODSUBES     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-CODCLIEN     PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PROP-CODPRODU     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-NOMPRODU     PIC  X(30).*/
        public StringBasis V0PROP_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77            V0USUA-NOMUSU       PIC  X(40).*/
        public StringBasis V0USUA_NOMUSU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0CLIE-CODCLIEN     PIC S9(09)    COMP.*/
        public IntBasis V0CLIE_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0CLIE-NOME-RAZAO   PIC  X(40).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0CLIE-CGCCPF       PIC S9(15)    COMP-3.*/
        public IntBasis V0CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0CLIE-TIPO-PESSOA  PIC  X(01).*/
        public StringBasis V0CLIE_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            V0CLIE-DATA-NASC    PIC  X(10).*/
        public StringBasis V0CLIE_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            VIND-DATA-NASC      PIC S9(004) VALUE +0  COMP.*/
        public IntBasis VIND_DATA_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-COD-EMPRESA    PIC S9(004) VALUE +0  COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-COD-AGE-DEB    PIC S9(004) VALUE +0  COMP.*/
        public IntBasis VIND_COD_AGE_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-OPE-CTA-DEB    PIC S9(004) VALUE +0  COMP.*/
        public IntBasis VIND_OPE_CTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-NUM-CTA-DEB    PIC S9(004) VALUE +0  COMP.*/
        public IntBasis VIND_NUM_CTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-DIG-CTA-DEB    PIC S9(004) VALUE +0  COMP.*/
        public IntBasis VIND_DIG_CTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-NUM-CAR-CRE    PIC S9(004) VALUE +0  COMP.*/
        public IntBasis VIND_NUM_CAR_CRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         COBHISVI-SIT-REGISTRO  PIC X(1).*/
        public StringBasis COBHISVI_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77         WS-DAYOFWEEK           PIC S9(004)           COMP.*/
        public IntBasis WS_DAYOFWEEK { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WORK-AREA.*/
        public VA0930B_WORK_AREA WORK_AREA { get; set; } = new VA0930B_WORK_AREA();
        public class VA0930B_WORK_AREA : VarBasis
        {
            /*"    05        WS-NUM-APOLICE      PIC S9(013) COMP-3 VALUE +0.*/
            public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        WS-COD-SUBGRUPO     PIC S9(004) COMP.*/
            public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WS-NUM-CERTIFICADO  PIC S9(015) COMP-3.*/
            public IntBasis WS_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        WS-NUM-BILHETE      PIC S9(015) COMP-3.*/
            public IntBasis WS_NUM_BILHETE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        WS-COD-CLIENTE      PIC S9(009) COMP.*/
            public IntBasis WS_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        WS-NOME-RAZAO       PIC  X(040).*/
            public StringBasis WS_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        WS-NOME-USUARIO     PIC  X(040).*/
            public StringBasis WS_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        WS-CGCCPF           PIC S9(015) COMP-3.*/
            public IntBasis WS_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        WS-TIPO-PESSOA      PIC  X(001).*/
            public StringBasis WS_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-DATA-NASC        PIC  X(010).*/
            public StringBasis WS_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WIND-01             PIC  9(005) VALUE ZEROS.*/
            public IntBasis WIND_01 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WIND-COD-OPR        PIC  9(005) VALUE ZEROS.*/
            public IntBasis WIND_COD_OPR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WS-APOLICE-ANT      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05        WS-CODSUBES-ANT     PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-CERTIF-ANT       PIC  9(015) VALUE ZEROS.*/
            public IntBasis WS_CERTIF_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05        WS-CGCCPF-ANT       PIC  9(015) VALUE ZEROS.*/
            public IntBasis WS_CGCCPF_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05        WS-TIPREL-ANT       PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_TIPREL_ANT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05        WS-BILHETE          PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"    05        WS-VE0401B1         PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_VE0401B1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"    05        WS-SO-APOLICE       PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_SO_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"    05        WS-COD-CLI-RELATORI PIC S9(009) COMP.*/
            public IntBasis WS_COD_CLI_RELATORI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        WS-NUMBIL           PIC  9(015).*/
            public IntBasis WS_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-APOLICE          PIC  9(013).*/
            public IntBasis WS_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-PRM-TARIFARIO-VAR                                  PIC ZZZZZZZZZ9,99.*/
            public DoubleBasis WS_PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZZZZZZ9V99."), 2);
            /*"    05        WS-PRM-RESTITUIDO   PIC S9(13)V99 COMP-3.*/
            public DoubleBasis WS_PRM_RESTITUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05        WS-COD-RELATORIOS.*/
            public VA0930B_WS_COD_RELATORIOS WS_COD_RELATORIOS { get; set; } = new VA0930B_WS_COD_RELATORIOS();
            public class VA0930B_WS_COD_RELATORIOS : VarBasis
            {
                /*"       10     WS-CB58A            PIC  X(001) VALUE 'N'.*/
                public StringBasis WS_CB58A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
                /*"    05        WCAMPOS-CB52A-01.*/
            }
            public VA0930B_WCAMPOS_CB52A_01 WCAMPOS_CB52A_01 { get; set; } = new VA0930B_WCAMPOS_CB52A_01();
            public class VA0930B_WCAMPOS_CB52A_01 : VarBasis
            {
                /*"       10     WAGECOBR            PIC   X(01).*/
                public StringBasis WAGECOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WFONTE              PIC   X(01).*/
                public StringBasis WFONTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WNUMBIL             PIC   X(01).*/
                public StringBasis WNUMBIL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WRAMO               PIC   X(01).*/
                public StringBasis WRAMO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WNUM-PROPOSTA       PIC   X(01).*/
                public StringBasis WNUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WNUM-APOL-ANTERIOR  PIC   X(01).*/
                public StringBasis WNUM_APOL_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCODPRODU           PIC   X(01).*/
                public StringBasis WCODPRODU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCONVENENTE         PIC   X(01).*/
                public StringBasis WCONVENENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WNOME-RAZAO         PIC   X(01).*/
                public StringBasis WNOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WDATA-NASCIMENTO    PIC   X(01).*/
                public StringBasis WDATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCGCCPF             PIC   X(01).*/
                public StringBasis WCGCCPF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WIDE-SEXO           PIC   X(01).*/
                public StringBasis WIDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WESTADO-CIVIL       PIC   X(01).*/
                public StringBasis WESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WPROFISSAO          PIC   X(01).*/
                public StringBasis WPROFISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WBI-RENDA-IND       PIC   X(01).*/
                public StringBasis WBI_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    05        WCAMPOS-CB52A-02.*/
            }
            public VA0930B_WCAMPOS_CB52A_02 WCAMPOS_CB52A_02 { get; set; } = new VA0930B_WCAMPOS_CB52A_02();
            public class VA0930B_WCAMPOS_CB52A_02 : VarBasis
            {
                /*"       10     WBI-RENDA-FAM       PIC   X(01).*/
                public StringBasis WBI_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCEP                PIC   X(01).*/
                public StringBasis WCEP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WENDERECO           PIC   X(01).*/
                public StringBasis WENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WBAIRRO             PIC   X(01).*/
                public StringBasis WBAIRRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCIDADE             PIC   X(01).*/
                public StringBasis WCIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WUF                 PIC   X(01).*/
                public StringBasis WUF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WDDD-FIXO           PIC   X(01).*/
                public StringBasis WDDD_FIXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WTEL-FIXO           PIC   X(01).*/
                public StringBasis WTEL_FIXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WTEL-CEL            PIC   X(01).*/
                public StringBasis WTEL_CEL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WOPCAO-COBER        PIC   X(01).*/
                public StringBasis WOPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WIMP-SEGURADA       PIC   X(01).*/
                public StringBasis WIMP_SEGURADA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WPREM-LIQUIDO       PIC   X(01).*/
                public StringBasis WPREM_LIQUIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WIOF                PIC   X(01).*/
                public StringBasis WIOF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WPREM-TOTAL         PIC   X(01).*/
                public StringBasis WPREM_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     FILLER              PIC   X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    05        WCAMPOS-CB52A-03.*/
            }
            public VA0930B_WCAMPOS_CB52A_03 WCAMPOS_CB52A_03 { get; set; } = new VA0930B_WCAMPOS_CB52A_03();
            public class VA0930B_WCAMPOS_CB52A_03 : VarBasis
            {
                /*"       10     WAGE-INDICADOR      PIC   X(01).*/
                public StringBasis WAGE_INDICADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WOPE-INDICADOR      PIC   X(01).*/
                public StringBasis WOPE_INDICADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCONTA-INDICADOR    PIC   X(01).*/
                public StringBasis WCONTA_INDICADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WDIG-CONTA-IND      PIC   X(01).*/
                public StringBasis WDIG_CONTA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WMATRICULA-IND      PIC   X(01).*/
                public StringBasis WMATRICULA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WDATA-QUITACAO      PIC   X(01).*/
                public StringBasis WDATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WVALOR-RECIBO       PIC   X(01).*/
                public StringBasis WVALOR_RECIBO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WAGE-DEBITO         PIC   X(01).*/
                public StringBasis WAGE_DEBITO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WOPE-DEBITO         PIC   X(01).*/
                public StringBasis WOPE_DEBITO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCONTA-DEBITO       PIC   X(01).*/
                public StringBasis WCONTA_DEBITO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WDIG-CONTA-DEB      PIC   X(01).*/
                public StringBasis WDIG_CONTA_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WCARTAO             PIC   X(01).*/
                public StringBasis WCARTAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     FILLER              PIC   X(03).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"    05        WCAMPOS-VLNXA.*/
            }
            public VA0930B_WCAMPOS_VLNXA WCAMPOS_VLNXA { get; set; } = new VA0930B_WCAMPOS_VLNXA();
            public class VA0930B_WCAMPOS_VLNXA : VarBasis
            {
                /*"       10     WNOME-ESPOSA        PIC   X(01).*/
                public StringBasis WNOME_ESPOSA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WPROF-ESPOSA        PIC   X(01).*/
                public StringBasis WPROF_ESPOSA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WDTNASC-ESPOSA      PIC   X(01).*/
                public StringBasis WDTNASC_ESPOSA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     WDPS-ESPOSA         PIC   X(01).*/
                public StringBasis WDPS_ESPOSA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     FILLER              PIC   X(11).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
                /*"    05        WCAMPOS-CTB2A.*/
            }
            public VA0930B_WCAMPOS_CTB2A WCAMPOS_CTB2A { get; set; } = new VA0930B_WCAMPOS_CTB2A();
            public class VA0930B_WCAMPOS_CTB2A : VarBasis
            {
                /*"       10     W-NOME-RAZAO        PIC   X(01).*/
                public StringBasis W_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-TIPO-PESSOA       PIC   X(01).*/
                public StringBasis W_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CGCCPF            PIC   X(01).*/
                public StringBasis W_CGCCPF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-DATA-NASC         PIC   X(01).*/
                public StringBasis W_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-EMAIL             PIC   X(01).*/
                public StringBasis W_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     FILLER              PIC   X(10).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    05        WCAMPOS-VLN9A-01.*/
            }
            public VA0930B_WCAMPOS_VLN9A_01 WCAMPOS_VLN9A_01 { get; set; } = new VA0930B_WCAMPOS_VLN9A_01();
            public class VA0930B_WCAMPOS_VLN9A_01 : VarBasis
            {
                /*"       10     W-CAMPO-CEP         PIC   X(01).*/
                public StringBasis W_CAMPO_CEP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-UF          PIC   X(01).*/
                public StringBasis W_CAMPO_UF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-ENDERECO    PIC   X(01).*/
                public StringBasis W_CAMPO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-BAIRRO      PIC   X(01).*/
                public StringBasis W_CAMPO_BAIRRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-CIDADE      PIC   X(01).*/
                public StringBasis W_CAMPO_CIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-DDD         PIC   X(01).*/
                public StringBasis W_CAMPO_DDD { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-TELEFONE    PIC   X(01).*/
                public StringBasis W_CAMPO_TELEFONE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     FILLER              PIC   X(08).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"    05        WCAMPOS-VLN9A-02.*/
            }
            public VA0930B_WCAMPOS_VLN9A_02 WCAMPOS_VLN9A_02 { get; set; } = new VA0930B_WCAMPOS_VLN9A_02();
            public class VA0930B_WCAMPOS_VLN9A_02 : VarBasis
            {
                /*"       10     W-CAMPO-AGE-DEB     PIC   X(01).*/
                public StringBasis W_CAMPO_AGE_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-OPE-DEB     PIC   X(01).*/
                public StringBasis W_CAMPO_OPE_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-CTA-DEB     PIC   X(01).*/
                public StringBasis W_CAMPO_CTA_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-DIG-CTA     PIC   X(01).*/
                public StringBasis W_CAMPO_DIG_CTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-CRT-CRE     PIC   X(01).*/
                public StringBasis W_CAMPO_CRT_CRE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     FILLER              PIC   X(10).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    05        WCAMPOS-VGMAA.*/
            }
            public VA0930B_WCAMPOS_VGMAA WCAMPOS_VGMAA { get; set; } = new VA0930B_WCAMPOS_VGMAA();
            public class VA0930B_WCAMPOS_VGMAA : VarBasis
            {
                /*"       10     W-CAMPO-NOME        PIC   X(01).*/
                public StringBasis W_CAMPO_NOME { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-DATA-NASC   PIC   X(01).*/
                public StringBasis W_CAMPO_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-SEXO        PIC   X(01).*/
                public StringBasis W_CAMPO_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-EST-CIVIL   PIC   X(01).*/
                public StringBasis W_CAMPO_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     W-CAMPO-NOVO-CLI    PIC   X(01).*/
                public StringBasis W_CAMPO_NOVO_CLI { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10     FILLER              PIC   X(10).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    05        TABELA-COD-OPERACAO.*/
            }
            public VA0930B_TABELA_COD_OPERACAO TABELA_COD_OPERACAO { get; set; } = new VA0930B_TABELA_COD_OPERACAO();
            public class VA0930B_TABELA_COD_OPERACAO : VarBasis
            {
                /*"       10 FILLER PIC X(053) VALUE         '0401CANCELAMENTO SOLICITADO                          '*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0401CANCELAMENTO SOLICITADO                          ");
                /*"       10 FILLER PIC X(053) VALUE         '0402CANCELAMENTO POR AVISO DE SINISTRO               '*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0402CANCELAMENTO POR AVISO DE SINISTRO               ");
                /*"       10 FILLER PIC X(053) VALUE         '0403CANCELAMENTO POR FALTA DE PAGAMENTO              '*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0403CANCELAMENTO POR FALTA DE PAGAMENTO              ");
                /*"       10 FILLER PIC X(053) VALUE         '0404CANCEL AUTOMAT CONTA ENCERRRADA/NAO CADASTRADA   '*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0404CANCEL AUTOMAT CONTA ENCERRRADA/NAO CADASTRADA   ");
                /*"       10 FILLER PIC X(053) VALUE         '0405CANCEL AUTOMAT SEGURO DUPLICADO                  '*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0405CANCEL AUTOMAT SEGURO DUPLICADO                  ");
                /*"       10 FILLER PIC X(053) VALUE         '0406CANCEL AUTOMAT CONTA TAXADA/OUTRAS RESTRICOES    '*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0406CANCEL AUTOMAT CONTA TAXADA/OUTRAS RESTRICOES    ");
                /*"       10 FILLER PIC X(053) VALUE         '0407CANCEL AUTOMAT ADESAO NOVO PRODUTO               '*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0407CANCEL AUTOMAT ADESAO NOVO PRODUTO               ");
                /*"       10 FILLER PIC X(053) VALUE         '0408CANCEL AUTOMAT TRANSFERENCIA DE SUBGRUPO         '*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0408CANCEL AUTOMAT TRANSFERENCIA DE SUBGRUPO         ");
                /*"       10 FILLER PIC X(053) VALUE         '0409CANCEL AUTOMAT CANCELAMENTO DE SUBGRUPO          '*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0409CANCEL AUTOMAT CANCELAMENTO DE SUBGRUPO          ");
                /*"       10 FILLER PIC X(053) VALUE         '0410CANCEL AUTOMAT CANCELAMENTO DE APOLICE           '*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0410CANCEL AUTOMAT CANCELAMENTO DE APOLICE           ");
                /*"       10 FILLER PIC X(053) VALUE         '0412CANCEL POR REATIVACAO DE SINISTRO                '*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0412CANCEL POR REATIVACAO DE SINISTRO                ");
                /*"       10 FILLER PIC X(053) VALUE         '0415CANCEL AUTOMAT VENDA VALOR MAIOR                 '*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0415CANCEL AUTOMAT VENDA VALOR MAIOR                 ");
                /*"       10 FILLER PIC X(053) VALUE         '0416CANCEL AUTOMAT VENDA VALOR MENOR                 '*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0416CANCEL AUTOMAT VENDA VALOR MENOR                 ");
                /*"       10 FILLER PIC X(053) VALUE         '0417CANCELAMENTO POR EMISSAO INDEVIDA                '*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0417CANCELAMENTO POR EMISSAO INDEVIDA                ");
                /*"       10 FILLER PIC X(053) VALUE         '0418CANCEL AUTOMAT TRANSFERENCIA DE APOLICE          '*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0418CANCEL AUTOMAT TRANSFERENCIA DE APOLICE          ");
                /*"       10 FILLER PIC X(053) VALUE         '0419CANCELAMENTO POR TERMINO DE VIGENCIA             '*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0419CANCELAMENTO POR TERMINO DE VIGENCIA             ");
                /*"       10 FILLER PIC X(053) VALUE         '0499CANCELAMENTO POR SINISTRO DO PRINCIPAL           '*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0499CANCELAMENTO POR SINISTRO DO PRINCIPAL           ");
                /*"       10 FILLER PIC X(053) VALUE         '0701REDUCAO DE CAPITAL                               '*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0701REDUCAO DE CAPITAL                               ");
                /*"       10 FILLER PIC X(053) VALUE         '0801AUMENTO DE CAPITAL                               '*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"0801AUMENTO DE CAPITAL                               ");
                /*"    05 TAB-AUX REDEFINES TABELA-COD-OPERACAO.*/
            }
            private _REDEF_VA0930B_TAB_AUX _tab_aux { get; set; }
            public _REDEF_VA0930B_TAB_AUX TAB_AUX
            {
                get { _tab_aux = new _REDEF_VA0930B_TAB_AUX(); _.Move(TABELA_COD_OPERACAO, _tab_aux); VarBasis.RedefinePassValue(TABELA_COD_OPERACAO, _tab_aux, TABELA_COD_OPERACAO); _tab_aux.ValueChanged += () => { _.Move(_tab_aux, TABELA_COD_OPERACAO); }; return _tab_aux; }
                set { VarBasis.RedefinePassValue(value, _tab_aux, TABELA_COD_OPERACAO); }
            }  //Redefines
            public class _REDEF_VA0930B_TAB_AUX : VarBasis
            {
                /*"       10 TAB-CODIGO-OPERACAO OCCURS 19 INDEXED BY WS-IDX-1.*/
                public ListBasis<VA0930B_TAB_CODIGO_OPERACAO> TAB_CODIGO_OPERACAO { get; set; } = new ListBasis<VA0930B_TAB_CODIGO_OPERACAO>(19);
                public class VA0930B_TAB_CODIGO_OPERACAO : VarBasis
                {
                    /*"           15  TAB-COD-OPERACAO         PIC  9(004).*/
                    public IntBasis TAB_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           15  TAB-DES-OPERACAO         PIC  X(049).*/
                    public StringBasis TAB_DES_OPERACAO { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
                    /*"    05        TABELA-CAMPOS.*/

                    public VA0930B_TAB_CODIGO_OPERACAO()
                    {
                        TAB_COD_OPERACAO.ValueChanged += OnValueChanged;
                        TAB_DES_OPERACAO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA0930B_TAB_AUX()
                {
                    TAB_CODIGO_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public VA0930B_TABELA_CAMPOS TABELA_CAMPOS { get; set; } = new VA0930B_TABELA_CAMPOS();
            public class VA0930B_TABELA_CAMPOS : VarBasis
            {
                /*"       10     TCAMPOS-ALTERADOS  PIC X(943).*/
                public StringBasis TCAMPOS_ALTERADOS { get; set; } = new StringBasis(new PIC("X", "943", "X(943)."), @"");
                /*"       10     TABL-CAMPOS-R      REDEFINES TCAMPOS-ALTERADOS                                    OCCURS 41 TIMES.*/
                private ListBasis<_REDEF_VA0930B_TABL_CAMPOS_R> _tabl_campos_r { get; set; }
                public ListBasis<_REDEF_VA0930B_TABL_CAMPOS_R> TABL_CAMPOS_R
                {
                    get { _tabl_campos_r = new ListBasis<_REDEF_VA0930B_TABL_CAMPOS_R>(41); _.Move(TCAMPOS_ALTERADOS, _tabl_campos_r); VarBasis.RedefinePassValue(TCAMPOS_ALTERADOS, _tabl_campos_r, TCAMPOS_ALTERADOS); _tabl_campos_r.ValueChanged += () => { _.Move(_tabl_campos_r, TCAMPOS_ALTERADOS); }; return _tabl_campos_r; }
                    set { VarBasis.RedefinePassValue(value, _tabl_campos_r, TCAMPOS_ALTERADOS); }
                }  //Redefines
                public class _REDEF_VA0930B_TABL_CAMPOS_R : VarBasis
                {
                    /*"           15 TCAMPOS            PIC X(022).*/
                    public StringBasis TCAMPOS { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
                    /*"           15 TDIVISOR           PIC X(001).*/
                    public StringBasis TDIVISOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    05        TCAMPOS-CONCATENA.*/

                    public _REDEF_VA0930B_TABL_CAMPOS_R()
                    {
                        TCAMPOS.ValueChanged += OnValueChanged;
                        TDIVISOR.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VA0930B_TCAMPOS_CONCATENA TCAMPOS_CONCATENA { get; set; } = new VA0930B_TCAMPOS_CONCATENA();
            public class VA0930B_TCAMPOS_CONCATENA : VarBasis
            {
                /*"       10     TAB-DESCRICAO-1    PIC  X(015).*/
                public StringBasis TAB_DESCRICAO_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"       10     TAB-ESPACO-1       PIC  X(001).*/
                public StringBasis TAB_ESPACO_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10     TAB-DESCRICAO-2    PIC  X(015).*/
                public StringBasis TAB_DESCRICAO_2 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05        WFIM-V0RELATORIO    PIC   X(01)  VALUE  ' '.*/
            }
            public StringBasis WFIM_V0RELATORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-LIDOS-SORT       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_SORT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-GRAVADOS         PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ERRO-DADOS       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ERRO_DADOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ERRO-SISTEMA     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ERRO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-SEGUNDA-VIA-BIL  PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_SEGUNDA_VIA_BIL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-CANC-SEM-REST    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_CANC_SEM_REST { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-SUSP-RENOVACAO   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_SUSP_RENOVACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-DADOS-BILHETE    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_DADOS_BILHETE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-REST-PRO-RATA    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_REST_PRO_RATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-CANC-BIL-CRITICA PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_CANC_BIL_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-SEG-VIA-CERT     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_SEG_VIA_CERT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-SEG-VIA-BOLETO   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_SEG_VIA_BOLETO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-REC-DEBITO       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_REC_DEBITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-CANC-PARCELA     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_CANC_PARCELA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-INCLUIR-PARC     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_INCLUIR_PARC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-REMISSAO-PRE     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_REMISSAO_PRE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-BENEFICIARIOS    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_BENEFICIARIOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-INC-EXC-CONJ     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_INC_EXC_CONJ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALTER-CAPITAL    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALTER_CAPITAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALTER-PER-PGTO   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALTER_PER_PGTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-REST-PREMIO      PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_REST_PREMIO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-CANC-REST        PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_CANC_REST { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-REABILITACAO     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_REABILITACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-FORMA-PGTO   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_FORMA_PGTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-DAD-BANCARIOS    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_DAD_BANCARIOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-DAD-ENDERECO     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_DAD_ENDERECO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-DIA-VENC     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_DIA_VENC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-PROF-SEG     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_PROF_SEG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-DAD-CONJ     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_DAD_CONJ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-EMIS-CERT-IND    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_EMIS_CERT_IND { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-CAPIT-GLO    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_CAPIT_GLO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-AUM-CAPITAL      PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_AUM_CAPITAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-RED-CAPITAL      PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_RED_CAPITAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-CANC-APOLICE     PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_CANC_APOLICE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-CANC-SUBGRUPO    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_CANC_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-SOL-RELACAO      PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_SOL_RELACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-INCL-SUBGRUPO    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_INCL_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-TAXA         PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_TAXA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-COBERT       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_COBERT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-INCL-PLANO       PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_INCL_PLANO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-EST-DEV-FOLLOW   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_EST_DEV_FOLLOW { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-SEG-VIA-FRONT    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_SEG_VIA_FRONT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-CAPIT-EXC    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_CAPIT_EXC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-REAB-AP-ESPEC    PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_REAB_AP_ESPEC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-DAD-CAD      PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_DAD_CAD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        AC-ALT-DAD-CERTIF   PIC  9(008) VALUE ZEROS.*/
            public IntBasis AC_ALT_DAD_CERTIF { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05        WS-COUNT            PIC S9(004) COMP VALUE +0.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WABEND.*/
            public VA0930B_WABEND WABEND { get; set; } = new VA0930B_WABEND();
            public class VA0930B_WABEND : VarBasis
            {
                /*"       10      FILLER              PIC  X(010) VALUE           ' VA0930B'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0930B");
                /*"       10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"       10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"       10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        LD00.*/
            }
            public VA0930B_LD00 LD00 { get; set; } = new VA0930B_LD00();
            public class VA0930B_LD00 : VarBasis
            {
                /*"       10      FILLER              PIC X(07)   VALUE 'VA0930B'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA0930B");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(55)   VALUE         'RELATORIO CONTENDO OS MOVIMENTOS DE ENDOSSOS DIARIOS.'*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "55", "X(55)"), @"RELATORIO CONTENDO OS MOVIMENTOS DE ENDOSSOS DIARIOS.");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(07)   VALUE             'DATA : '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"DATA : ");
                /*"       10      LD00-DATAINI        PIC X(10).*/
                public StringBasis LD00_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05        LD00-1.*/
            }
            public VA0930B_LD00_1 LD00_1 { get; set; } = new VA0930B_LD00_1();
            public class VA0930B_LD00_1 : VarBasis
            {
                /*"       10      FILLER              PIC X(07)   VALUE 'APOLICE'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE 'SUBGRUPO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SUBGRUPO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(11)   VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE             'NOME PRODUTO'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NOME PRODUTO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE 'CPF/CNPJ'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"CPF/CNPJ");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE             'SEGURADO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE             'TIPO ENDOSSO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"TIPO ENDOSSO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE             'DATA ENDOSSO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"DATA ENDOSSO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(07)   VALUE 'USUARIO'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(15)   VALUE             'NOME DO USUARIO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME DO USUARIO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(11)   VALUE             'TIPO PESSOA'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"TIPO PESSOA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(15)   VALUE             'DADOS ALTERADOS'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DADOS ALTERADOS");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(16)   VALUE             'VALOR RESSARCIDO'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"VALOR RESSARCIDO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(07)   VALUE             'PARCELA'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PARCELA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(20)   VALUE             'DATA PREVISTA'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"DATA PREVISTA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(22)   VALUE             'SITUACAO DO RETORNO'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"SITUACAO DO RETORNO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(17)   VALUE             'DIA DO VENCIMENTO'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"DIA DO VENCIMENTO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(27)   VALUE             'OPCAO DE PAGAMENTO ANTERIOR'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"OPCAO DE PAGAMENTO ANTERIOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(24)   VALUE             'OPCAO DE PAGAMENTO ATUAL'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"OPCAO DE PAGAMENTO ATUAL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(07)   VALUE             'AGENCIA'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE             'OPERACAO'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"OPERACAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE             'NUMERO CONTA'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUMERO CONTA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE             'DIGITO CONTA'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"DIGITO CONTA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(14)   VALUE             'CARTAO CREDITO'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"CARTAO CREDITO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE             'ENDERECO'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ENDERECO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(06)   VALUE             'BAIRRO'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"BAIRRO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(06)   VALUE             'CIDADE'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CIDADE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(03)   VALUE 'CEP'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CEP");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(09)   VALUE             'ESTADO/UF'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"ESTADO/UF");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(03)   VALUE 'DDD'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DDD");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE             'TELEFONE'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(14)   VALUE             'NOME DA ESPOSA'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"NOME DA ESPOSA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(19)   VALUE             'PROFISSAO DA ESPOSA'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"PROFISSAO DA ESPOSA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(22)   VALUE             'DATA NASCIMENTO ESPOSA'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"DATA NASCIMENTO ESPOSA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(13)   VALUE             'DPS DA ESPOSA'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DPS DA ESPOSA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(15)   VALUE             'PROFISSAO ATUAL'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"PROFISSAO ATUAL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(13)   VALUE             'AGENCIA VENDA'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"AGENCIA VENDA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(06)   VALUE             'FILIAL'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(07)   VALUE             'BILHETE'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BILHETE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(04)   VALUE 'RAMO'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"RAMO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(18)   VALUE             'NUMERO DA PROPOSTA'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"NUMERO DA PROPOSTA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(16)   VALUE             'BILHETE ANTERIOR'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"BILHETE ANTERIOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(17)   VALUE             'CODIGO DO PRODUTO'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"CODIGO DO PRODUTO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(10)   VALUE             'CONVENENTE'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"CONVENENTE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(13)   VALUE             'NOME SEGURADO'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME SEGURADO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(15)   VALUE             'DATA NASCIMENTO'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA NASCIMENTO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(03)   VALUE 'CPF'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(04)   VALUE 'SEXO'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"SEXO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE             'ESTADO CIVIL'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"ESTADO CIVIL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(09)   VALUE             'PROFISSAO'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROFISSAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(16)   VALUE             'RENDA INDIVIDUAL'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"RENDA INDIVIDUAL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(14)   VALUE             'RENDA FAMILIAR'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"RENDA FAMILIAR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE             'ENDERECO'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ENDERECO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(06)   VALUE             'BAIRRO'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"BAIRRO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(06)   VALUE             'CIDADE'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CIDADE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(02)   VALUE 'UF'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"UF");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(03)   VALUE 'CEP'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CEP");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(03)   VALUE 'DDD'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DDD");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE             'TELEFONE'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(07)   VALUE             'CELULAR'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"CELULAR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(15)   VALUE             'OPCAO COBERTURA'.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"OPCAO COBERTURA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(20)   VALUE             'IMPORTANCIA SEGURADA'.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"IMPORTANCIA SEGURADA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(14)   VALUE             'PREMIO LIQUIDO'.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"PREMIO LIQUIDO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(03)   VALUE 'IOF'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"IOF");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE             'PREMIO TOTAL'.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"PREMIO TOTAL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(17)   VALUE             'AGENCIA INDICADOR'.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"AGENCIA INDICADOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(24)   VALUE             'OPERACAO CONTA INDICADOR'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"OPERACAO CONTA INDICADOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(24)   VALUE             'CONTA BANCARIA INDICADOR'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"CONTA BANCARIA INDICADOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(22)   VALUE             'DIGITO CONTA INDICADOR'.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"DIGITO CONTA INDICADOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(19)   VALUE             'MATRICULA INDICADOR'.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"MATRICULA INDICADOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(13)   VALUE             'DATA QUITACAO'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DATA QUITACAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(13)   VALUE             'VALOR RECIBO'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"VALOR RECIBO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(14)   VALUE             'AGENCIA DEBITO'.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"AGENCIA DEBITO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(21)   VALUE             'OPERACAO CONTA DEBITO'.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"OPERACAO CONTA DEBITO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(21)   VALUE              'CONTA BANCARIA DEBITO'.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"CONTA BANCARIA DEBITO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(19)   VALUE              'DIGITO CONTA DEBITO'.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DIGITO CONTA DEBITO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(14)   VALUE              'CARTAO CREDITO'.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"CARTAO CREDITO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(16)   VALUE              'NOVO CERTIFICADO'.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"NOVO CERTIFICADO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(18)   VALUE              'OPERACAO REALIZADA'.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"OPERACAO REALIZADA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE              'INCLUSAO'.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"INCLUSAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(09)   VALUE              'ALTERACAO'.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"ALTERACAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(08)   VALUE              'EXCLUSAO'.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"EXCLUSAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(20)   VALUE              'DATA DO CANCELAMENTO'.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"DATA DO CANCELAMENTO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(22)   VALUE              'MOTIVO DO CANCELAMENTO'.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"MOTIVO DO CANCELAMENTO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(17)   VALUE              'HOUVE RESTITUICAO'.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"HOUVE RESTITUICAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(18)   VALUE              'DESCRICAO OPERACAO'.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DESCRICAO OPERACAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(22)   VALUE              'VALOR CAPITAL ANTERIOR'.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"VALOR CAPITAL ANTERIOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(19)   VALUE              'VALOR CAPITAL ATUAL'.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"VALOR CAPITAL ATUAL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(15)   VALUE              'NOME DO CLIENTE'.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME DO CLIENTE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(26)   VALUE              'DATA NASCIMENTO DO CLIENTE'.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"DATA NASCIMENTO DO CLIENTE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(04)   VALUE              'SEXO'.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"SEXO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(23)   VALUE              'ESTADO CIVIL DO CLIENTE'.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"ESTADO CIVIL DO CLIENTE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(12)   VALUE              'NOVO CLIENTE'.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NOVO CLIENTE");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(23)   VALUE              'CODIGO CLIENTE ANTERIOR'.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"CODIGO CLIENTE ANTERIOR");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(20)   VALUE              'CODIGO CLIENTE ATUAL'.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"CODIGO CLIENTE ATUAL");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(28)   VALUE              'DATA DA OPERACAO DE REMISSAO'.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"DATA DA OPERACAO DE REMISSAO");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER              PIC X(27)   VALUE              'DATA DE RETORNO DA COBRANCA'.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"DATA DE RETORNO DA COBRANCA");
                /*"       10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05         LD01.*/
            }
            public VA0930B_LD01 LD01 { get; set; } = new VA0930B_LD01();
            public class VA0930B_LD01 : VarBasis
            {
                /*"       10      LD01-APOLICE             PIC 9(13).*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-SUBGRUPO            PIC 9(05).*/
                public IntBasis LD01_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NRCERTIF            PIC 9(15).*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CODPRODU            PIC 9(04).*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NOMPRODU            PIC X(40)   VALUE SPACES*/
                public StringBasis LD01_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CGCCPF              PIC 9(15).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NM-SEGURADO         PIC X(40)   VALUE ZEROES*/
                public StringBasis LD01_NM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-TIP-ENDOSSO         PIC X(50)   VALUE SPACES*/
                public StringBasis LD01_TIP_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DT-ENDOSSO          PIC X(10)   VALUE SPACES*/
                public StringBasis LD01_DT_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CODUSU              PIC X(08).*/
                public StringBasis LD01_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NOMUSU              PIC X(40).*/
                public StringBasis LD01_NOMUSU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-TIP-PESSOA          PIC X(02).*/
                public StringBasis LD01_TIP_PESSOA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DAD-ALTERADOS       PIC X(50).*/
                public StringBasis LD01_DAD_ALTERADOS { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-PRM-TARIFARIO-VAR   PIC X(15).*/
                public StringBasis LD01_PRM_TARIFARIO_VAR { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NUM-PARCELA         PIC 9(04).*/
                public IntBasis LD01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DATA-PREVISTA       PIC X(10).*/
                public StringBasis LD01_DATA_PREVISTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-RETORNO-OPERACAO    PIC X(22).*/
                public StringBasis LD01_RETORNO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DIA-DEBITO          PIC 9(04).*/
                public IntBasis LD01_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPCAO-PGTO-ANTERIOR PIC X(18).*/
                public StringBasis LD01_OPCAO_PGTO_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPCAO-PGTO-ATUAL    PIC X(18).*/
                public StringBasis LD01_OPCAO_PGTO_ATUAL { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-COD-AGENCIA-DEBITO  PIC 9(04).*/
                public IntBasis LD01_COD_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPE-CONTA-DEBITO    PIC 9(13).*/
                public IntBasis LD01_OPE_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NUM-CONTA-DEBITO    PIC 9(13).*/
                public IntBasis LD01_NUM_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DIG-CONTA-DEBITO    PIC 9(04).*/
                public IntBasis LD01_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NUM-CARTAO-CREDITO  PIC 9(16).*/
                public IntBasis LD01_NUM_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-ENDERECO            PIC X(72).*/
                public StringBasis LD01_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-BAIRRO              PIC X(72).*/
                public StringBasis LD01_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CIDADE              PIC X(72).*/
                public StringBasis LD01_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CEP                 PIC 9(09).*/
                public IntBasis LD01_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-UF                  PIC X(02).*/
                public StringBasis LD01_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DDD                 PIC 9(04).*/
                public IntBasis LD01_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-TELEFONE            PIC 9(09).*/
                public IntBasis LD01_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NOME-ESPOSA         PIC X(08).*/
                public StringBasis LD01_NOME_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-PROFISSAO-ESPOSA    PIC X(08).*/
                public StringBasis LD01_PROFISSAO_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DTNASC-ESPOSA       PIC X(08).*/
                public StringBasis LD01_DTNASC_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DPS-ESPOSA          PIC X(08).*/
                public StringBasis LD01_DPS_ESPOSA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-PROFISSAO-ATUAL     PIC X(20).*/
                public StringBasis LD01_PROFISSAO_ATUAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-AGE-VENDA-BIL       PIC X(08).*/
                public StringBasis LD01_AGE_VENDA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-FILIAL-BIL          PIC X(08).*/
                public StringBasis LD01_FILIAL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NUM-BILHETE         PIC X(08).*/
                public StringBasis LD01_NUM_BILHETE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-RAMO-BIL            PIC X(08).*/
                public StringBasis LD01_RAMO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-PROPOSTA-BIL        PIC X(08).*/
                public StringBasis LD01_PROPOSTA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NUM-BILHETE-ANT     PIC X(08).*/
                public StringBasis LD01_NUM_BILHETE_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-COD-PRODUTO-BIL     PIC X(08).*/
                public StringBasis LD01_COD_PRODUTO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CONVENENTE-BIL      PIC X(08).*/
                public StringBasis LD01_CONVENENTE_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NOME-SEGURADO-BIL   PIC X(08).*/
                public StringBasis LD01_NOME_SEGURADO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DATA-NASC-BIL       PIC X(08).*/
                public StringBasis LD01_DATA_NASC_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CPF-BIL             PIC X(08).*/
                public StringBasis LD01_CPF_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-SEXO-BIL            PIC X(08).*/
                public StringBasis LD01_SEXO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_279 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-ESTADO-CIVIL-BIL    PIC X(08).*/
                public StringBasis LD01_ESTADO_CIVIL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_280 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-PROFISSAO-BIL       PIC X(08).*/
                public StringBasis LD01_PROFISSAO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_281 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-RENDA-INDIV-BIL     PIC X(08).*/
                public StringBasis LD01_RENDA_INDIV_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_282 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-RENDA-FAMIL-BIL     PIC X(08).*/
                public StringBasis LD01_RENDA_FAMIL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_283 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-ENDERECO-BIL        PIC X(08).*/
                public StringBasis LD01_ENDERECO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_284 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-BAIRRO-BIL          PIC X(08).*/
                public StringBasis LD01_BAIRRO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_285 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CIDADE-BIL          PIC X(08).*/
                public StringBasis LD01_CIDADE_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_286 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-UF-BIL              PIC X(08).*/
                public StringBasis LD01_UF_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_287 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CEP-BIL             PIC X(08).*/
                public StringBasis LD01_CEP_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_288 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DDD-BIL             PIC X(08).*/
                public StringBasis LD01_DDD_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_289 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-TELEFONE-BIL        PIC X(08).*/
                public StringBasis LD01_TELEFONE_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_290 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CELULAR-BIL         PIC X(08).*/
                public StringBasis LD01_CELULAR_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_291 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPCAO-COB-BIL       PIC X(08).*/
                public StringBasis LD01_OPCAO_COB_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_292 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-IMP-SEGURADA-BIL    PIC X(08).*/
                public StringBasis LD01_IMP_SEGURADA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_293 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-PREM-LIQUIDO-BIL    PIC X(08).*/
                public StringBasis LD01_PREM_LIQUIDO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_294 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-IOF-BIL             PIC X(08).*/
                public StringBasis LD01_IOF_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_295 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-PREM-TOTAL-BIL      PIC X(08).*/
                public StringBasis LD01_PREM_TOTAL_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_296 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-AGE-BANC-INDICADOR  PIC X(08).*/
                public StringBasis LD01_AGE_BANC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_297 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPE-BANC-INDICADOR  PIC X(08).*/
                public StringBasis LD01_OPE_BANC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_298 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CTA-BANC-INDICADOR  PIC X(08).*/
                public StringBasis LD01_CTA_BANC_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_299 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DIG-CTA-INDICADOR   PIC X(08).*/
                public StringBasis LD01_DIG_CTA_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_300 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-MATRICULA-INDICADOR PIC X(08).*/
                public StringBasis LD01_MATRICULA_INDICADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_301 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DATA-QUIT-BIL       PIC X(08).*/
                public StringBasis LD01_DATA_QUIT_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_302 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-VALOR-RECIBO-BIL    PIC X(08).*/
                public StringBasis LD01_VALOR_RECIBO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_303 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-AGE-DEBITO-BIL      PIC X(08).*/
                public StringBasis LD01_AGE_DEBITO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_304 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPE-DEBITO-BIL      PIC X(08).*/
                public StringBasis LD01_OPE_DEBITO_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_305 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CTA-BANC-BIL        PIC X(08).*/
                public StringBasis LD01_CTA_BANC_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_306 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DIG-CTA-BIL         PIC X(08).*/
                public StringBasis LD01_DIG_CTA_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_307 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-CARTAO-CRED-BIL     PIC X(08).*/
                public StringBasis LD01_CARTAO_CRED_BIL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_308 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NOVO-CERTIFICADO    PIC 9(15).*/
                public IntBasis LD01_NOVO_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_309 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPERACAO-REALIZADA  PIC X(22).*/
                public StringBasis LD01_OPERACAO_REALIZADA { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_310 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-INCLUSAO            PIC X(03).*/
                public StringBasis LD01_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_311 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-ALTERACAO           PIC X(03).*/
                public StringBasis LD01_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_312 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-EXCLUSAO            PIC X(03).*/
                public StringBasis LD01_EXCLUSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_313 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DATA-CANCELAMENTO   PIC X(10).*/
                public StringBasis LD01_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_314 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-MOTIVO-CANCELAMENTO PIC X(120).*/
                public StringBasis LD01_MOTIVO_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_315 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-HOUVE-RESTITUICAO   PIC X(03).*/
                public StringBasis LD01_HOUVE_RESTITUICAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_316 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-OPERACAO            PIC X(50).*/
                public StringBasis LD01_OPERACAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_317 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-VLR-CAPITAL-ANT     PIC X(15).*/
                public StringBasis LD01_VLR_CAPITAL_ANT { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_318 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-VLR-CAPITAL-ATU     PIC X(15).*/
                public StringBasis LD01_VLR_CAPITAL_ATU { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_319 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NOME-CLIENTE-CERT   PIC X(08).*/
                public StringBasis LD01_NOME_CLIENTE_CERT { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_320 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DATA-NASC-CLIENTE   PIC X(08).*/
                public StringBasis LD01_DATA_NASC_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_321 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-SEXO-CLIENTE        PIC X(08).*/
                public StringBasis LD01_SEXO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_322 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-EST-CIVIL-CLIENTE   PIC X(08).*/
                public StringBasis LD01_EST_CIVIL_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_323 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-NOVO-CLIENTE        PIC X(03).*/
                public StringBasis LD01_NOVO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_324 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-COD-CLIENTE-ANT     PIC 9(09).*/
                public IntBasis LD01_COD_CLIENTE_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_325 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-COD-CLIENTE-ATUAL   PIC 9(09).*/
                public IntBasis LD01_COD_CLIENTE_ATUAL { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_326 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DATA-OPER-REMISSAO  PIC X(10).*/
                public StringBasis LD01_DATA_OPER_REMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_327 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD01-DATA-RET-COBRANCA   PIC X(10).*/
                public StringBasis LD01_DATA_RET_COBRANCA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_328 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05         LD00-2.*/
            }
            public VA0930B_LD00_2 LD00_2 { get; set; } = new VA0930B_LD00_2();
            public class VA0930B_LD00_2 : VarBasis
            {
                /*"       10      FILLER                   PIC X(43)   VALUE              'ENDOSSOS DE ALTERACOES DE DADOS CADASTRAIS.'.*/
                public StringBasis FILLER_329 { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"ENDOSSOS DE ALTERACOES DE DADOS CADASTRAIS.");
                /*"       10      FILLER                   PIC X(01)   VALUE   ';'.*/
                public StringBasis FILLER_330 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05         LD00-3.*/
            }
            public VA0930B_LD00_3 LD00_3 { get; set; } = new VA0930B_LD00_3();
            public class VA0930B_LD00_3 : VarBasis
            {
                /*"       10      FILLER                   PIC X(03)   VALUE 'CPF'.*/
                public StringBasis FILLER_331 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_332 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(08)   VALUE              'SEGURADO'.*/
                public StringBasis FILLER_333 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_334 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(15)   VALUE              'DATA NASCIMENTO'.*/
                public StringBasis FILLER_335 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA NASCIMENTO");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_336 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(12)   VALUE              'TIPO ENDOSSO'.*/
                public StringBasis FILLER_337 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"TIPO ENDOSSO");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_338 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(12)   VALUE              'DATA ENDOSSO'.*/
                public StringBasis FILLER_339 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"DATA ENDOSSO");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_340 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(07)   VALUE              'USUARIO'.*/
                public StringBasis FILLER_341 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_342 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(15)   VALUE              'NOME DO USUARIO'.*/
                public StringBasis FILLER_343 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME DO USUARIO");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_344 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(11)   VALUE              'TIPO PESSOA'.*/
                public StringBasis FILLER_345 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"TIPO PESSOA");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_346 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(15)   VALUE              'NOME DO CLIENTE'.*/
                public StringBasis FILLER_347 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME DO CLIENTE");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_348 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(14)   VALUE              'TIPO DE PESSOA'.*/
                public StringBasis FILLER_349 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"TIPO DE PESSOA");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_350 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(18)   VALUE              'CPF CGC DO CLIENTE'.*/
                public StringBasis FILLER_351 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"CPF CGC DO CLIENTE");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_352 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(18)   VALUE              'DATA DE NASCIMENTO'.*/
                public StringBasis FILLER_353 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DATA DE NASCIMENTO");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_354 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      FILLER                   PIC X(16)   VALUE              'EMAIL DO CLIENTE'.*/
                public StringBasis FILLER_355 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"EMAIL DO CLIENTE");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_356 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05         LD02.*/
            }
            public VA0930B_LD02 LD02 { get; set; } = new VA0930B_LD02();
            public class VA0930B_LD02 : VarBasis
            {
                /*"       10      LD02-CGCCPF              PIC 9(15).*/
                public IntBasis LD02_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_357 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-NM-SEGURADO         PIC X(40)   VALUE ZEROES*/
                public StringBasis LD02_NM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_358 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-DT-NASCIMENTO       PIC X(10)   VALUE SPACES*/
                public StringBasis LD02_DT_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_359 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-TIP-ENDOSSO         PIC X(40)   VALUE SPACES*/
                public StringBasis LD02_TIP_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_360 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-DT-ENDOSSO          PIC X(10)   VALUE SPACES*/
                public StringBasis LD02_DT_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_361 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-CODUSU              PIC X(08).*/
                public StringBasis LD02_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_362 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-NOMUSU              PIC X(40).*/
                public StringBasis LD02_NOMUSU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_363 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-TIP-PESSOA          PIC X(02).*/
                public StringBasis LD02_TIP_PESSOA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_364 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-NOME-CLIENTE        PIC X(08).*/
                public StringBasis LD02_NOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_365 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-TIPO-PESSOA-CLIENTE PIC X(08).*/
                public StringBasis LD02_TIPO_PESSOA_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_366 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-CGCCPF-CLIENTE      PIC X(08).*/
                public StringBasis LD02_CGCCPF_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_367 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-DATA-NASCIMENTO     PIC X(08).*/
                public StringBasis LD02_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_368 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10      LD02-EMAIL-CLIENTE       PIC X(08).*/
                public StringBasis LD02_EMAIL_CLIENTE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"       10      FILLER                   PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_369 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"01  LK-PARAMETRO.*/
            }
        }
        public VA0930B_LK_PARAMETRO LK_PARAMETRO { get; set; } = new VA0930B_LK_PARAMETRO();
        public class VA0930B_LK_PARAMETRO : VarBasis
        {
            /*"    03  FILLER                PIC  X(02).*/
            public StringBasis FILLER_370 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    03  LK-TIPO               PIC  X(01).*/
            public StringBasis LK_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  LK-DATAMOV            PIC  X(10).*/
            public StringBasis LK_DATAMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        }


        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.DEVOLVID DEVOLVID { get; set; } = new Dclgens.DEVOLVID();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SEGURHIS SEGURHIS { get; set; } = new Dclgens.SEGURHIS();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public VA0930B_TRELAT TRELAT { get; set; } = new VA0930B_TRELAT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0930B_LK_PARAMETRO VA0930B_LK_PARAMETRO_P, string SVA0930B_FILE_NAME_P, string AVA0930B_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETRO*/
        {
            try
            {
                this.LK_PARAMETRO = VA0930B_LK_PARAMETRO_P;
                SVA0930B.SetFile(SVA0930B_FILE_NAME_P);
                AVA0930B.SetFile(AVA0930B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1208- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1211- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1214- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1218- DISPLAY '--------------------------------------' */
            _.Display($"--------------------------------------");

            /*" -1219- DISPLAY '     PROGRAMA EM EXECUCAO VA0930B     ' */
            _.Display($"     PROGRAMA EM EXECUCAO VA0930B     ");

            /*" -1220- DISPLAY '                                      ' */
            _.Display($"                                      ");

            /*" -1221- DISPLAY 'VERSAO V.10 JAZZ   434.480 08/11/2022 ' */
            _.Display($"VERSAO V.10 JAZZ   434.480 08/11/2022 ");

            /*" -1222- DISPLAY '                                      ' */
            _.Display($"                                      ");

            /*" -1229- DISPLAY 'INICIO PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"INICIO PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1230- DISPLAY '                                      ' */
            _.Display($"                                      ");

            /*" -1242- DISPLAY '--------------------------------------' . */
            _.Display($"--------------------------------------");

            /*" -1245- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1248- INITIALIZE DCLRELATORIOS LD01 */
            _.Initialize(
                RELATORI.DCLRELATORIOS
                , WORK_AREA.LD01
            );

            /*" -1250- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1251- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -1252- DISPLAY '*** PROBLEMAS NA V0SISTEMA' */
                _.Display($"*** PROBLEMAS NA V0SISTEMA");

                /*" -1253- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1254- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1256- END-IF. */
            }


            /*" -1257- IF LK-TIPO EQUAL 'R' */

            if (LK_PARAMETRO.LK_TIPO == "R")
            {

                /*" -1258- IF LK-DATAMOV EQUAL SPACES OR LOW-VALUES */

                if (LK_PARAMETRO.LK_DATAMOV.IsLowValues())
                {

                    /*" -1259- DISPLAY 'PARAMETRO DATA NAO INFORMADO P/RETOMADA' */
                    _.Display($"PARAMETRO DATA NAO INFORMADO P/RETOMADA");

                    /*" -1260- MOVE 99 TO RETURN-CODE */
                    _.Move(99, RETURN_CODE);

                    /*" -1261- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -1262- ELSE */
                }
                else
                {


                    /*" -1263- IF LK-DATAMOV NOT GREATER V1SIST-DTMOVABE */

                    if (LK_PARAMETRO.LK_DATAMOV <= V1SIST_DTMOVABE)
                    {

                        /*" -1264- CONTINUE */

                        /*" -1265- ELSE */
                    }
                    else
                    {


                        /*" -1266- DISPLAY 'PARAMETRO DATA INVALIDO' */
                        _.Display($"PARAMETRO DATA INVALIDO");

                        /*" -1267- MOVE 99 TO RETURN-CODE */
                        _.Move(99, RETURN_CODE);

                        /*" -1268- STOP RUN */

                        throw new GoBack();   // => STOP RUN.

                        /*" -1269- END-IF */
                    }


                    /*" -1271- END-IF */
                }


                /*" -1272- MOVE LK-DATAMOV TO V1SIST-DTMOVABE */
                _.Move(LK_PARAMETRO.LK_DATAMOV, V1SIST_DTMOVABE);

                /*" -1273- DISPLAY 'PROCESSAMENTO RETOMADA NA DATA ' LK-DATAMOV */
                _.Display($"PROCESSAMENTO RETOMADA NA DATA {LK_PARAMETRO.LK_DATAMOV}");

                /*" -1274- ELSE */
            }
            else
            {


                /*" -1275- DISPLAY 'PROCESSAMENTO NORMAL' */
                _.Display($"PROCESSAMENTO NORMAL");

                /*" -1277- END-IF. */
            }


            /*" -1278- MOVE V1SIST-DTHOJE(1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(1, 4), WORK_AREA.LD00.LD00_DATAINI, 7, 4);

            /*" -1279- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 3, 1);

            /*" -1280- MOVE V1SIST-DTHOJE(6:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(6, 2), WORK_AREA.LD00.LD00_DATAINI, 4, 2);

            /*" -1281- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 6, 1);

            /*" -1283- MOVE V1SIST-DTHOJE(9:2) TO LD00-DATAINI(1:2). */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(9, 2), WORK_AREA.LD00.LD00_DATAINI, 1, 2);

            /*" -1285- PERFORM R0900-00-DECLARE-V0RELATORIO. */

            R0900_00_DECLARE_V0RELATORIO_SECTION();

            /*" -1286- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1288- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1290- PERFORM R0910-00-FETCH-V0RELATORIO. */

            R0910_00_FETCH_V0RELATORIO_SECTION();

            /*" -1291- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1293- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1294- IF WFIM-V0RELATORIO EQUAL 'S' */

            if (WORK_AREA.WFIM_V0RELATORIO == "S")
            {

                /*" -1295- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1296- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1300- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1307- SORT SVA0930B ON ASCENDING KEY SVA-TIP-REL SVA-APOLICE SVA-CODSUBES SVA-NRCERTIF INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-GERA-ARQ THRU R0020-FIM. */
            SORT_RETURN.Value = SVA0930B.Sort("SVA-TIP-REL,SVA-APOLICE,SVA-CODSUBES,SVA-NRCERTIF", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_GERA_ARQ_SECTION());

            /*" -1310- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1312- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1313- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1314- DISPLAY '*** VA0930B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VA0930B *** PROBLEMAS NO SORT ");

                /*" -1315- DISPLAY '*** VA0930B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VA0930B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1316- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1316- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1322- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1324- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (WORK_AREA.AC_ERRO_DADOS > 00 && WORK_AREA.AC_ERRO_SISTEMA > 00)
            {

                /*" -1325- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -1326- ELSE */
            }
            else
            {


                /*" -1327- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (WORK_AREA.AC_ERRO_SISTEMA > 00)
                {

                    /*" -1328- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -1329- ELSE */
                }
                else
                {


                    /*" -1330- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (WORK_AREA.AC_ERRO_DADOS > 00)
                    {

                        /*" -1332- MOVE 1 TO RETURN-CODE. */
                        _.Move(1, RETURN_CODE);
                    }

                }

            }


            /*" -1332- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1336- PERFORM R9900-00-MONTAR-CONTROLES */

            R9900_00_MONTAR_CONTROLES_SECTION();

            /*" -1336- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1348- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1356- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1359- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1360- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                /*" -1361- DISPLAY 'VA0930B - PROBLEMAS NO ACESSO A SISTEMAS ' */
                _.Display($"VA0930B - PROBLEMAS NO ACESSO A SISTEMAS ");

                /*" -1362- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1362- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1356- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTHOJE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0RELATORIO-SECTION */
        private void R0900_00_DECLARE_V0RELATORIO_SECTION()
        {
            /*" -1375- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1401- PERFORM R0900_00_DECLARE_V0RELATORIO_DB_DECLARE_1 */

            R0900_00_DECLARE_V0RELATORIO_DB_DECLARE_1();

            /*" -1403- PERFORM R0900_00_DECLARE_V0RELATORIO_DB_OPEN_1 */

            R0900_00_DECLARE_V0RELATORIO_DB_OPEN_1();

            /*" -1406- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1407- DISPLAY 'R0900 - PROBLEMAS DECLARE RELATORIOS' */
                _.Display($"R0900 - PROBLEMAS DECLARE RELATORIOS");

                /*" -1408- DISPLAY 'SQLCODE    - ' SQLCODE */
                _.Display($"SQLCODE    - {DB.SQLCODE}");

                /*" -1409- DISPLAY 'DATA SOLIC - ' V1SIST-DTMOVABE */
                _.Display($"DATA SOLIC - {V1SIST_DTMOVABE}");

                /*" -1409- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0RELATORIO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0RELATORIO_DB_DECLARE_1()
        {
            /*" -1401- EXEC SQL DECLARE TRELAT CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_CERTIFICADO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , TIPO_CORRECAO , IND_PREV_DEFINIT , NUM_ENDOSSO , NUM_TITULO , NUM_PARCELA , COD_USUARIO , NUM_ORDEM , COD_OPERACAO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_SINI_LIDER , COD_PRODUTOR , COD_EMPRESA FROM SEGUROS.RELATORIOS WHERE DATA_SOLICITACAO = :V1SIST-DTMOVABE WITH UR END-EXEC. */
            TRELAT = new VA0930B_TRELAT(true);
            string GetQuery_TRELAT()
            {
                var query = @$"SELECT NUM_APOLICE 
							, COD_SUBGRUPO 
							, NUM_CERTIFICADO 
							, DATA_SOLICITACAO 
							, IDE_SISTEMA 
							, COD_RELATORIO 
							, NUM_COPIAS 
							, QUANTIDADE 
							, TIPO_CORRECAO 
							, IND_PREV_DEFINIT 
							, NUM_ENDOSSO 
							, NUM_TITULO 
							, NUM_PARCELA 
							, COD_USUARIO 
							, NUM_ORDEM 
							, COD_OPERACAO 
							, NUM_APOL_LIDER 
							, ENDOS_LIDER 
							, NUM_SINI_LIDER 
							, COD_PRODUTOR 
							, COD_EMPRESA 
							FROM SEGUROS.RELATORIOS 
							WHERE DATA_SOLICITACAO = '{V1SIST_DTMOVABE}'";

                return query;
            }
            TRELAT.GetQueryEvent += GetQuery_TRELAT;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0RELATORIO-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0RELATORIO_DB_OPEN_1()
        {
            /*" -1403- EXEC SQL OPEN TRELAT END-EXEC. */

            TRELAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0RELATORIO-SECTION */
        private void R0910_00_FETCH_V0RELATORIO_SECTION()
        {
            /*" -1421- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1444- PERFORM R0910_00_FETCH_V0RELATORIO_DB_FETCH_1 */

            R0910_00_FETCH_V0RELATORIO_DB_FETCH_1();

            /*" -1447- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1448- MOVE 'S' TO WFIM-V0RELATORIO */
                _.Move("S", WORK_AREA.WFIM_V0RELATORIO);

                /*" -1448- PERFORM R0910_00_FETCH_V0RELATORIO_DB_CLOSE_1 */

                R0910_00_FETCH_V0RELATORIO_DB_CLOSE_1();

                /*" -1450- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -1452- END-IF */
            }


            /*" -1453- IF VIND-COD-EMPRESA LESS ZEROS */

            if (VIND_COD_EMPRESA < 00)
            {

                /*" -1454- MOVE ZEROS TO RELATORI-COD-EMPRESA */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA);

                /*" -1456- END-IF */
            }


            /*" -1456- ADD 1 TO AC-LIDOS. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0RELATORIO-DB-FETCH-1 */
        public void R0910_00_FETCH_V0RELATORIO_DB_FETCH_1()
        {
            /*" -1444- EXEC SQL FETCH TRELAT INTO :RELATORI-NUM-APOLICE , :RELATORI-COD-SUBGRUPO , :RELATORI-NUM-CERTIFICADO , :RELATORI-DATA-SOLICITACAO , :RELATORI-IDE-SISTEMA , :RELATORI-COD-RELATORIO , :RELATORI-NUM-COPIAS , :RELATORI-QUANTIDADE , :RELATORI-TIPO-CORRECAO , :RELATORI-IND-PREV-DEFINIT , :RELATORI-NUM-ENDOSSO , :RELATORI-NUM-TITULO , :RELATORI-NUM-PARCELA , :RELATORI-COD-USUARIO , :RELATORI-NUM-ORDEM , :RELATORI-COD-OPERACAO , :RELATORI-NUM-APOL-LIDER , :RELATORI-ENDOS-LIDER , :RELATORI-NUM-SINI-LIDER , :RELATORI-COD-PRODUTOR , :RELATORI-COD-EMPRESA:VIND-COD-EMPRESA END-EXEC. */

            if (TRELAT.Fetch())
            {
                _.Move(TRELAT.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(TRELAT.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(TRELAT.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(TRELAT.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(TRELAT.RELATORI_IDE_SISTEMA, RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);
                _.Move(TRELAT.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(TRELAT.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(TRELAT.RELATORI_QUANTIDADE, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);
                _.Move(TRELAT.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(TRELAT.RELATORI_IND_PREV_DEFINIT, RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);
                _.Move(TRELAT.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
                _.Move(TRELAT.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(TRELAT.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(TRELAT.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(TRELAT.RELATORI_NUM_ORDEM, RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM);
                _.Move(TRELAT.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(TRELAT.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
                _.Move(TRELAT.RELATORI_ENDOS_LIDER, RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER);
                _.Move(TRELAT.RELATORI_NUM_SINI_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER);
                _.Move(TRELAT.RELATORI_COD_PRODUTOR, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);
                _.Move(TRELAT.RELATORI_COD_EMPRESA, RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA);
                _.Move(TRELAT.VIND_COD_EMPRESA, VIND_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0RELATORIO-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0RELATORIO_DB_CLOSE_1()
        {
            /*" -1448- EXEC SQL CLOSE TRELAT END-EXEC */

            TRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1469- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0RELATORIO EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V0RELATORIO == "S" || WS_ERRO_FATAL == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -1470- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -1472- GO TO R0010-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/ //GOTO
                return;
            }


            /*" -1472- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1485- INITIALIZE REG-SVA0930B WS-COD-RELATORIOS TABELA-CAMPOS */
            _.Initialize(
                REG_SVA0930B
                , WORK_AREA.WS_COD_RELATORIOS
                , WORK_AREA.TABELA_CAMPOS
            );

            /*" -1486- MOVE 'N' TO WS-SO-APOLICE */
            _.Move("N", WORK_AREA.WS_SO_APOLICE);

            /*" -1496- MOVE ZEROS TO WS-NUM-APOLICE WS-COD-SUBGRUPO WS-NUM-CERTIFICADO WS-NUM-BILHETE WS-COD-CLIENTE WS-NOME-RAZAO WS-CGCCPF WS-TIPO-PESSOA WS-DATA-NASC. */
            _.Move(0, WORK_AREA.WS_NUM_APOLICE, WORK_AREA.WS_COD_SUBGRUPO, WORK_AREA.WS_NUM_CERTIFICADO, WORK_AREA.WS_NUM_BILHETE, WORK_AREA.WS_COD_CLIENTE, WORK_AREA.WS_NOME_RAZAO, WORK_AREA.WS_CGCCPF, WORK_AREA.WS_TIPO_PESSOA, WORK_AREA.WS_DATA_NASC);

            /*" -1498- PERFORM R1010-00-SELECT-TIPO-ENDOSSO. */

            R1010_00_SELECT_TIPO_ENDOSSO_SECTION();

            /*" -1499- IF SVA-TIP-REL EQUAL 1 */

            if (REG_SVA0930B.SVA_TIP_REL == 1)
            {

                /*" -1500- IF WS-BILHETE EQUAL 'S' */

                if (WORK_AREA.WS_BILHETE == "S")
                {

                    /*" -1501- PERFORM R1020-00-SELECT-BILHETE */

                    R1020_00_SELECT_BILHETE_SECTION();

                    /*" -1502- ELSE */
                }
                else
                {


                    /*" -1504- IF RELATORI-NUM-CERTIFICADO NOT EQUAL ZEROS OR RELATORI-NUM-TITULO NOT EQUAL ZEROS */

                    if (RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO != 00 || RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO != 00)
                    {

                        /*" -1505- PERFORM R1030-00-SELECT-CERTIFICADO */

                        R1030_00_SELECT_CERTIFICADO_SECTION();

                        /*" -1506- ELSE */
                    }
                    else
                    {


                        /*" -1507- MOVE 'S' TO WS-SO-APOLICE */
                        _.Move("S", WORK_AREA.WS_SO_APOLICE);

                        /*" -1508- PERFORM R1080-SELECT-NRCERTIF-APOL */

                        R1080_SELECT_NRCERTIF_APOL_SECTION();

                        /*" -1509- END-IF */
                    }


                    /*" -1511- END-IF */
                }


                /*" -1512- PERFORM R1040-00-SELECT-PRODUTOSVG */

                R1040_00_SELECT_PRODUTOSVG_SECTION();

                /*" -1513- PERFORM R1050-00-SELECT-CLIENTE */

                R1050_00_SELECT_CLIENTE_SECTION();

                /*" -1515- PERFORM R1060-00-SELECT-USUARIO */

                R1060_00_SELECT_USUARIO_SECTION();

                /*" -1516- MOVE WS-NUM-APOLICE TO SVA-APOLICE */
                _.Move(WORK_AREA.WS_NUM_APOLICE, REG_SVA0930B.SVA_APOLICE);

                /*" -1517- MOVE WS-COD-SUBGRUPO TO SVA-CODSUBES */
                _.Move(WORK_AREA.WS_COD_SUBGRUPO, REG_SVA0930B.SVA_CODSUBES);

                /*" -1518- IF WS-BILHETE EQUAL 'S' */

                if (WORK_AREA.WS_BILHETE == "S")
                {

                    /*" -1519- MOVE WS-NUM-BILHETE TO SVA-NRCERTIF */
                    _.Move(WORK_AREA.WS_NUM_BILHETE, REG_SVA0930B.SVA_NRCERTIF);

                    /*" -1520- ELSE */
                }
                else
                {


                    /*" -1521- MOVE WS-NUM-CERTIFICADO TO SVA-NRCERTIF */
                    _.Move(WORK_AREA.WS_NUM_CERTIFICADO, REG_SVA0930B.SVA_NRCERTIF);

                    /*" -1522- END-IF */
                }


                /*" -1523- MOVE V0PROP-CODPRODU TO SVA-CODPRODU */
                _.Move(V0PROP_CODPRODU, REG_SVA0930B.SVA_CODPRODU);

                /*" -1525- MOVE V0PROP-NOMPRODU TO SVA-NOMPRODU */
                _.Move(V0PROP_NOMPRODU, REG_SVA0930B.SVA_NOMPRODU);

                /*" -1526- ELSE */
            }
            else
            {


                /*" -1527- PERFORM R1050-00-SELECT-CLIENTE */

                R1050_00_SELECT_CLIENTE_SECTION();

                /*" -1528- PERFORM R1060-00-SELECT-USUARIO */

                R1060_00_SELECT_USUARIO_SECTION();

                /*" -1529- MOVE WS-DATA-NASC TO SVA-DT-NASC */
                _.Move(WORK_AREA.WS_DATA_NASC, REG_SVA0930B.SVA_DT_NASC);

                /*" -1531- END-IF */
            }


            /*" -1532- MOVE RELATORI-DATA-SOLICITACAO TO SVA-DT-ENDOSSO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, REG_SVA0930B.SVA_DT_ENDOSSO);

            /*" -1533- MOVE RELATORI-COD-USUARIO TO SVA-CODUSU */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SVA0930B.SVA_CODUSU);

            /*" -1534- MOVE WS-NOME-USUARIO TO SVA-NOMUSU */
            _.Move(WORK_AREA.WS_NOME_USUARIO, REG_SVA0930B.SVA_NOMUSU);

            /*" -1535- MOVE WS-CGCCPF TO SVA-CGCCPF */
            _.Move(WORK_AREA.WS_CGCCPF, REG_SVA0930B.SVA_CGCCPF);

            /*" -1536- MOVE WS-NOME-RAZAO TO SVA-NOME-RAZAO */
            _.Move(WORK_AREA.WS_NOME_RAZAO, REG_SVA0930B.SVA_NOME_RAZAO);

            /*" -1537- MOVE TCAMPOS-ALTERADOS TO SVA-DADOS-ALTERADOS */
            _.Move(WORK_AREA.TABELA_CAMPOS.TCAMPOS_ALTERADOS, REG_SVA0930B.SVA_DADOS_ALTERADOS);

            /*" -1538- IF WS-TIPO-PESSOA EQUAL 'F' */

            if (WORK_AREA.WS_TIPO_PESSOA == "F")
            {

                /*" -1539- MOVE 'PF' TO SVA-TIPO-PESSOA */
                _.Move("PF", REG_SVA0930B.SVA_TIPO_PESSOA);

                /*" -1540- ELSE */
            }
            else
            {


                /*" -1541- IF WS-TIPO-PESSOA EQUAL 'J' */

                if (WORK_AREA.WS_TIPO_PESSOA == "J")
                {

                    /*" -1542- MOVE 'PJ' TO SVA-TIPO-PESSOA */
                    _.Move("PJ", REG_SVA0930B.SVA_TIPO_PESSOA);

                    /*" -1543- END-IF */
                }


                /*" -1544- END-IF */
            }


            /*" -1544- RELEASE REG-SVA0930B. */
            SVA0930B.Release(REG_SVA0930B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1548- PERFORM R0910-00-FETCH-V0RELATORIO. */

            R0910_00_FETCH_V0RELATORIO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-TIPO-ENDOSSO-SECTION */
        private void R1010_00_SELECT_TIPO_ENDOSSO_SECTION()
        {
            /*" -1560- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1562- MOVE 'N' TO WS-BILHETE WS-VE0401B1 */
            _.Move("N", WORK_AREA.WS_BILHETE, WORK_AREA.WS_VE0401B1);

            /*" -1563- MOVE 1 TO SVA-TIP-REL */
            _.Move(1, REG_SVA0930B.SVA_TIP_REL);

            /*" -1565- MOVE 0 TO WIND-01 */
            _.Move(0, WORK_AREA.WIND_01);

            /*" -1566-  EVALUATE TRUE  */

            /*" -1567-  WHEN RELATORI-COD-RELATORIO EQUAL 'BI7028B1' OR 'BI6021B2'  */

            /*" -1567- IF RELATORI-COD-RELATORIO EQUAL 'BI7028B1' OR 'BI6021B2' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("BI7028B1", "BI6021B2"))
            {

                /*" -1568- MOVE '2� VIA DE BILHETE' TO SVA-TIPO-ENDOSSO */
                _.Move("2� VIA DE BILHETE", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1569- MOVE 'S' TO WS-BILHETE */
                _.Move("S", WORK_AREA.WS_BILHETE);

                /*" -1570- ADD 1 TO AC-SEGUNDA-VIA-BIL */
                WORK_AREA.AC_SEGUNDA_VIA_BIL.Value = WORK_AREA.AC_SEGUNDA_VIA_BIL + 1;

                /*" -1572-  WHEN RELATORI-COD-RELATORIO EQUAL 'CB58AOP2'  */

                /*" -1572- ELSE IF RELATORI-COD-RELATORIO EQUAL 'CB58AOP2' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "CB58AOP2")
            {

                /*" -1574- MOVE 'CANCELAMENTO SEM RESTITUICAO/DEVOLUCAO' TO SVA-TIPO-ENDOSSO */
                _.Move("CANCELAMENTO SEM RESTITUICAO/DEVOLUCAO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1575- MOVE 'S' TO WS-BILHETE */
                _.Move("S", WORK_AREA.WS_BILHETE);

                /*" -1576- ADD 1 TO AC-CANC-SEM-REST */
                WORK_AREA.AC_CANC_SEM_REST.Value = WORK_AREA.AC_CANC_SEM_REST + 1;

                /*" -1577-  WHEN RELATORI-COD-RELATORIO EQUAL 'BI04A'  */

                /*" -1577- ELSE IF RELATORI-COD-RELATORIO EQUAL 'BI04A' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "BI04A")
            {

                /*" -1578- MOVE 'SUSPENDER RENOVACAO' TO SVA-TIPO-ENDOSSO */
                _.Move("SUSPENDER RENOVACAO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1579- MOVE 'S' TO WS-BILHETE */
                _.Move("S", WORK_AREA.WS_BILHETE);

                /*" -1580- ADD 1 TO AC-SUSP-RENOVACAO */
                WORK_AREA.AC_SUSP_RENOVACAO.Value = WORK_AREA.AC_SUSP_RENOVACAO + 1;

                /*" -1581-  WHEN RELATORI-COD-RELATORIO EQUAL 'CB52A'  */

                /*" -1581- ELSE IF RELATORI-COD-RELATORIO EQUAL 'CB52A' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "CB52A")
            {

                /*" -1583- MOVE 'ALTERACAO DE DADOS DO BILHETE' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE DADOS DO BILHETE", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1584- MOVE 'S' TO WS-BILHETE */
                _.Move("S", WORK_AREA.WS_BILHETE);

                /*" -1585- PERFORM R1101-00-VERIFICA-CAMPOS-CB52A */

                R1101_00_VERIFICA_CAMPOS_CB52A_SECTION();

                /*" -1586- ADD 1 TO AC-DADOS-BILHETE */
                WORK_AREA.AC_DADOS_BILHETE.Value = WORK_AREA.AC_DADOS_BILHETE + 1;

                /*" -1588-  WHEN RELATORI-COD-RELATORIO EQUAL  'CB58AOP1'  */

                /*" -1588- ELSE IF RELATORI-COD-RELATORIO EQUAL  'CB58AOP1' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "CB58AOP1")
            {

                /*" -1590- MOVE 'CANCELAMENTO COM RESTITUICAO PRO-RATA' TO SVA-TIPO-ENDOSSO */
                _.Move("CANCELAMENTO COM RESTITUICAO PRO-RATA", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1591- MOVE 'S' TO WS-BILHETE */
                _.Move("S", WORK_AREA.WS_BILHETE);

                /*" -1592- PERFORM R1102-00-VERIFICA-CAMPOS-CB58A */

                R1102_00_VERIFICA_CAMPOS_CB58A_SECTION();

                /*" -1593- ADD 1 TO AC-REST-PRO-RATA */
                WORK_AREA.AC_REST_PRO_RATA.Value = WORK_AREA.AC_REST_PRO_RATA + 1;

                /*" -1594-  WHEN RELATORI-COD-RELATORIO EQUAL 'CB0355B1'  */

                /*" -1594- ELSE IF RELATORI-COD-RELATORIO EQUAL 'CB0355B1' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "CB0355B1")
            {

                /*" -1596- MOVE 'CANCELAMENTO BILHETE EM CRITICA' TO SVA-TIPO-ENDOSSO */
                _.Move("CANCELAMENTO BILHETE EM CRITICA", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1597- MOVE 'S' TO WS-BILHETE */
                _.Move("S", WORK_AREA.WS_BILHETE);

                /*" -1598- ADD 1 TO AC-CANC-BIL-CRITICA */
                WORK_AREA.AC_CANC_BIL_CRITICA.Value = WORK_AREA.AC_CANC_BIL_CRITICA + 1;

                /*" -1599-  WHEN RELATORI-COD-RELATORIO EQUAL 'VG0420B' OR 'VG5001B'  */

                /*" -1599- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VG0420B' OR 'VG5001B' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VG0420B", "VG5001B"))
            {

                /*" -1600- IF RELATORI-COD-USUARIO EQUAL 'VA0118B' OR 'VA0130B' */

                if (RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.In("VA0118B", "VA0130B"))
                {

                    /*" -1601- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1603- END-IF */
                }


                /*" -1604- MOVE '2� VIA DE CERTIFICADO' TO SVA-TIPO-ENDOSSO */
                _.Move("2� VIA DE CERTIFICADO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1605- ADD 1 TO AC-SEG-VIA-CERT */
                WORK_AREA.AC_SEG_VIA_CERT.Value = WORK_AREA.AC_SEG_VIA_CERT + 1;

                /*" -1606-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLNOA'  */

                /*" -1606- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLNOA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VLNOA")
            {

                /*" -1607-  EVALUATE TRUE  */

                /*" -1608-  WHEN RELATORI-NUM-SINI-LIDER EQUAL 'IMP'  */

                /*" -1608- ELSE IF RELATORI-NUM-SINI-LIDER EQUAL 'IMP' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER == "IMP")
            {

                /*" -1609- MOVE '2� VIA DE BOLETO' TO SVA-TIPO-ENDOSSO */
                _.Move("2� VIA DE BOLETO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1610- MOVE RELATORI-NUM-PARCELA TO SVA-NUM-PARCELA */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SVA0930B.SVA_NUM_PARCELA);

                /*" -1611- ADD 1 TO AC-SEG-VIA-BOLETO */
                WORK_AREA.AC_SEG_VIA_BOLETO.Value = WORK_AREA.AC_SEG_VIA_BOLETO + 1;

                /*" -1612-  WHEN RELATORI-NUM-SINI-LIDER EQUAL 'DEB'  */

                /*" -1612- ELSE IF RELATORI-NUM-SINI-LIDER EQUAL 'DEB' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER == "DEB")
            {

                /*" -1614- MOVE 'RECOMANDO DE DEBITO' TO SVA-TIPO-ENDOSSO */
                _.Move("RECOMANDO DE DEBITO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1615- MOVE RELATORI-NUM-PARCELA TO SVA-NUM-PARCELA */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SVA0930B.SVA_NUM_PARCELA);

                /*" -1616- ADD 1 TO AC-REC-DEBITO */
                WORK_AREA.AC_REC_DEBITO.Value = WORK_AREA.AC_REC_DEBITO + 1;

                /*" -1617-  WHEN RELATORI-NUM-SINI-LIDER EQUAL 'CAN'  */

                /*" -1617- ELSE IF RELATORI-NUM-SINI-LIDER EQUAL 'CAN' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER == "CAN")
            {

                /*" -1618- MOVE 'CANCELAR PARCELA' TO SVA-TIPO-ENDOSSO */
                _.Move("CANCELAR PARCELA", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1619- MOVE RELATORI-NUM-PARCELA TO SVA-NUM-PARCELA */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SVA0930B.SVA_NUM_PARCELA);

                /*" -1620- ADD 1 TO AC-CANC-PARCELA */
                WORK_AREA.AC_CANC_PARCELA.Value = WORK_AREA.AC_CANC_PARCELA + 1;

                /*" -1621-  WHEN OTHER  */

                /*" -1621- ELSE */
            }
            else
            {


                /*" -1622- IF RELATORI-NUM-APOL-LIDER EQUAL 'INCLUIR' */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER == "INCLUIR")
                {

                    /*" -1623- MOVE ' ' TO TAB-ESPACO-1 */
                    _.Move(" ", WORK_AREA.TCAMPOS_CONCATENA.TAB_ESPACO_1);

                    /*" -1625- MOVE 'INCLUIR PARCELA' TO SVA-TIPO-ENDOSSO */
                    _.Move("INCLUIR PARCELA", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                    /*" -1627- MOVE RELATORI-ENDOS-LIDER TO TAB-DESCRICAO-1 */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER, WORK_AREA.TCAMPOS_CONCATENA.TAB_DESCRICAO_1);

                    /*" -1629- MOVE RELATORI-NUM-SINI-LIDER TO TAB-DESCRICAO-2 */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER, WORK_AREA.TCAMPOS_CONCATENA.TAB_DESCRICAO_2);

                    /*" -1631- MOVE TCAMPOS-CONCATENA TO TCAMPOS-ALTERADOS */
                    _.Move(WORK_AREA.TCAMPOS_CONCATENA, WORK_AREA.TABELA_CAMPOS.TCAMPOS_ALTERADOS);

                    /*" -1633- MOVE RELATORI-NUM-PARCELA TO SVA-NUM-PARCELA */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SVA0930B.SVA_NUM_PARCELA);

                    /*" -1634- ADD 1 TO AC-INCLUIR-PARC */
                    WORK_AREA.AC_INCLUIR_PARC.Value = WORK_AREA.AC_INCLUIR_PARC + 1;

                    /*" -1635- ELSE */
                }
                else
                {


                    /*" -1636- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1637- END-IF */
                }


                /*" -1638-  END-EVALUATE  */

                /*" -1638- END-IF */
            }


            /*" -1639-  WHEN RELATORI-COD-RELATORIO EQUAL 'VG0134B'  */

            /*" -1639- IF RELATORI-COD-RELATORIO EQUAL 'VG0134B' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VG0134B")
            {

                /*" -1640- MOVE 'REMISSAO DE PREMIO' TO SVA-TIPO-ENDOSSO */
                _.Move("REMISSAO DE PREMIO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1641- PERFORM R1112-00-RECUPERA-PROPOSTAS-VA */

                R1112_00_RECUPERA_PROPOSTAS_VA_SECTION();

                /*" -1642- MOVE PROPOVA-DTPROXVEN TO SVA-DATA-RET-COBRANCA */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN, REG_SVA0930B.SVA_DATA_RET_COBRANCA);

                /*" -1644- MOVE RELATORI-DATA-SOLICITACAO TO SVA-DATA-OPER-REMISSAO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, REG_SVA0930B.SVA_DATA_OPER_REMISSAO);

                /*" -1645- MOVE SPACES TO SVA-PROF-ATUAL */
                _.Move("", REG_SVA0930B.SVA_PROF_ATUAL);

                /*" -1646- ADD 1 TO AC-REMISSAO-PRE */
                WORK_AREA.AC_REMISSAO_PRE.Value = WORK_AREA.AC_REMISSAO_PRE + 1;

                /*" -1647-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGNBA'  */

                /*" -1647- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGNBA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGNBA")
            {

                /*" -1648- MOVE 'BENEFICIARIOS' TO SVA-TIPO-ENDOSSO */
                _.Move("BENEFICIARIOS", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1649-  EVALUATE TRUE  */

                /*" -1650-  WHEN RELATORI-NUM-APOL-LIDER EQUAL 'INCLUSAO'  */

                /*" -1650- ELSE IF RELATORI-NUM-APOL-LIDER EQUAL 'INCLUSAO' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER == "INCLUSAO")
            {

                /*" -1651- MOVE 'SIM' TO SVA-INCLUSAO */
                _.Move("SIM", REG_SVA0930B.SVA_INCLUSAO);

                /*" -1652-  WHEN RELATORI-NUM-APOL-LIDER EQUAL 'ALTERACAO'  */

                /*" -1652- ELSE IF RELATORI-NUM-APOL-LIDER EQUAL 'ALTERACAO' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER == "ALTERACAO")
            {

                /*" -1653- MOVE 'SIM' TO SVA-ALTERACAO */
                _.Move("SIM", REG_SVA0930B.SVA_ALTERACAO);

                /*" -1654-  WHEN RELATORI-NUM-APOL-LIDER EQUAL 'EXCLUSAO'  */

                /*" -1654- ELSE IF RELATORI-NUM-APOL-LIDER EQUAL 'EXCLUSAO' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER == "EXCLUSAO")
            {

                /*" -1655- MOVE 'SIM' TO SVA-EXCLUSAO */
                _.Move("SIM", REG_SVA0930B.SVA_EXCLUSAO);

                /*" -1656-  WHEN OTHER  */

                /*" -1656- ELSE */
            }
            else
            {


                /*" -1657- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1658-  END-EVALUATE  */

                /*" -1658- END-IF */
            }


            /*" -1659- ADD 1 TO AC-BENEFICIARIOS */
            WORK_AREA.AC_BENEFICIARIOS.Value = WORK_AREA.AC_BENEFICIARIOS + 1;

            /*" -1660-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGMQA'  */

            /*" -1660- IF RELATORI-COD-RELATORIO EQUAL 'VGMQA' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGMQA")
            {

                /*" -1662- MOVE 'INCLUSAO/EXCLUSAO DE CONJUGE' TO SVA-TIPO-ENDOSSO */
                _.Move("INCLUSAO/EXCLUSAO DE CONJUGE", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1663- PERFORM R1104-00-VERIFICA-CONJUGUE */

                R1104_00_VERIFICA_CONJUGUE_SECTION();

                /*" -1664- ADD 1 TO AC-INC-EXC-CONJ */
                WORK_AREA.AC_INC_EXC_CONJ.Value = WORK_AREA.AC_INC_EXC_CONJ + 1;

                /*" -1665-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLNTA'  */

                /*" -1665- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLNTA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VLNTA")
            {

                /*" -1666- MOVE 'ALTERACAO DE CAPITAL' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE CAPITAL", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1667- PERFORM R1108-00-VERIFICA-CAPITAL */

                R1108_00_VERIFICA_CAPITAL_SECTION();

                /*" -1668- ADD 1 TO AC-ALTER-CAPITAL */
                WORK_AREA.AC_ALTER_CAPITAL.Value = WORK_AREA.AC_ALTER_CAPITAL + 1;

                /*" -1669-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGMJA'  */

                /*" -1669- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGMJA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGMJA")
            {

                /*" -1671- MOVE 'ALTERACAO DE PERIODICIDADE DE PAGAMENTO' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE PERIODICIDADE DE PAGAMENTO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1672- PERFORM R1109-00-RECUPERA-NOVO-CERT */

                R1109_00_RECUPERA_NOVO_CERT_SECTION();

                /*" -1673- ADD 1 TO AC-ALTER-PER-PGTO */
                WORK_AREA.AC_ALTER_PER_PGTO.Value = WORK_AREA.AC_ALTER_PER_PGTO + 1;

                /*" -1674-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLNRA'  */

                /*" -1674- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLNRA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VLNRA")
            {

                /*" -1676- MOVE 'RESTITUICAO/DEVOLUCAO DE PREMIOS' TO SVA-TIPO-ENDOSSO */
                _.Move("RESTITUICAO/DEVOLUCAO DE PREMIOS", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1677- PERFORM R1110-00-RECUPERA-DADOS-REST */

                R1110_00_RECUPERA_DADOS_REST_SECTION();

                /*" -1678- ADD 1 TO AC-REST-PREMIO */
                WORK_AREA.AC_REST_PREMIO.Value = WORK_AREA.AC_REST_PREMIO + 1;

                /*" -1679-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLN8A'  */

                /*" -1679- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLN8A' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VLN8A")
            {

                /*" -1680- MOVE 'CANCELAMENTO ' TO SVA-TIPO-ENDOSSO */
                _.Move("CANCELAMENTO ", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1681- PERFORM R1103-00-VERIFICA-RESTITUICAO */

                R1103_00_VERIFICA_RESTITUICAO_SECTION();

                /*" -1682- ADD 1 TO AC-CANC-REST */
                WORK_AREA.AC_CANC_REST.Value = WORK_AREA.AC_CANC_REST + 1;

                /*" -1683-  WHEN RELATORI-COD-RELATORIO EQUAL 'VE0030B' OR 'VA0512B'  */

                /*" -1683- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VE0030B' OR 'VA0512B' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VE0030B", "VA0512B"))
            {

                /*" -1685- IF RELATORI-COD-USUARIO EQUAL 'VE0029B' OR 'VA0458B' OR 'VA0469B' */

                if (RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.In("VE0029B", "VA0458B", "VA0469B"))
                {

                    /*" -1686- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1687- ELSE */
                }
                else
                {


                    /*" -1688- MOVE 'CANCELAMENTO ' TO SVA-TIPO-ENDOSSO */
                    _.Move("CANCELAMENTO ", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                    /*" -1689- ADD 1 TO AC-CANC-REST */
                    WORK_AREA.AC_CANC_REST.Value = WORK_AREA.AC_CANC_REST + 1;

                    /*" -1690- END-IF */
                }


                /*" -1691-  WHEN RELATORI-COD-RELATORIO EQUAL 'VA0412B'  */

                /*" -1691- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VA0412B' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VA0412B")
            {

                /*" -1692- MOVE 'REABILITACAO' TO SVA-TIPO-ENDOSSO */
                _.Move("REABILITACAO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1693- PERFORM R1105-00-VERIFICA-CANCELAMENTO */

                R1105_00_VERIFICA_CANCELAMENTO_SECTION();

                /*" -1695- ADD 1 TO AC-REABILITACAO */
                WORK_AREA.AC_REABILITACAO.Value = WORK_AREA.AC_REABILITACAO + 1;

                /*" -1696-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLN9A01'  OR 'SP007A01'  */

                /*" -1696- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLN9A01'  OR 'SP007A01' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VLN9A01", "SP007A01"))
            {

                /*" -1698- MOVE 'ALTERACAO DA FORMA DE PAGAMENTO' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DA FORMA DE PAGAMENTO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1699- PERFORM R1106-00-BUSCA-DADOS-VLN9A */

                R1106_00_BUSCA_DADOS_VLN9A_SECTION();

                /*" -1701- ADD 1 TO AC-ALT-FORMA-PGTO */
                WORK_AREA.AC_ALT_FORMA_PGTO.Value = WORK_AREA.AC_ALT_FORMA_PGTO + 1;

                /*" -1702-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLN9A02' OR 'SP007A02'  */

                /*" -1702- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLN9A02' OR 'SP007A02' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VLN9A02", "SP007A02"))
            {

                /*" -1704- MOVE 'ALTERACAO DE DADOS BANCARIOS' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE DADOS BANCARIOS", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1705- PERFORM R1106-00-BUSCA-DADOS-VLN9A */

                R1106_00_BUSCA_DADOS_VLN9A_SECTION();

                /*" -1706- ADD 1 TO AC-DAD-BANCARIOS */
                WORK_AREA.AC_DAD_BANCARIOS.Value = WORK_AREA.AC_DAD_BANCARIOS + 1;

                /*" -1707-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLN9A03'  */

                /*" -1707- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLN9A03' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VLN9A03")
            {

                /*" -1709- MOVE 'ALTERACAO DE ENDERECO E TELEFONE' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE ENDERECO E TELEFONE", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1710- PERFORM R1113-00-BUSCA-ENDERECO-TELE */

                R1113_00_BUSCA_ENDERECO_TELE_SECTION();

                /*" -1712- ADD 1 TO AC-DAD-ENDERECO */
                WORK_AREA.AC_DAD_ENDERECO.Value = WORK_AREA.AC_DAD_ENDERECO + 1;

                /*" -1713-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLN9A04' OR 'SP007A04'  */

                /*" -1713- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLN9A04' OR 'SP007A04' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VLN9A04", "SP007A04"))
            {

                /*" -1715- MOVE 'ALTERACAO DO DIA DE VENCIMENTO' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DO DIA DE VENCIMENTO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1716- PERFORM R1106-00-BUSCA-DADOS-VLN9A */

                R1106_00_BUSCA_DADOS_VLN9A_SECTION();

                /*" -1717- ADD 1 TO AC-ALT-DIA-VENC */
                WORK_AREA.AC_ALT_DIA_VENC.Value = WORK_AREA.AC_ALT_DIA_VENC + 1;

                /*" -1718-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLNXA01'  */

                /*" -1718- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLNXA01' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VLNXA01")
            {

                /*" -1720- MOVE 'ALTERACAO DE PROFISSAO DO SEGURADO' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE PROFISSAO DO SEGURADO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1721- PERFORM R1112-00-RECUPERA-PROPOSTAS-VA */

                R1112_00_RECUPERA_PROPOSTAS_VA_SECTION();

                /*" -1722- MOVE PROPOVA-PROFISSAO TO SVA-PROF-ATUAL */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO, REG_SVA0930B.SVA_PROF_ATUAL);

                /*" -1723- MOVE SPACES TO SVA-DATA-RET-COBRANCA */
                _.Move("", REG_SVA0930B.SVA_DATA_RET_COBRANCA);

                /*" -1724- ADD 1 TO AC-ALT-PROF-SEG */
                WORK_AREA.AC_ALT_PROF_SEG.Value = WORK_AREA.AC_ALT_PROF_SEG + 1;

                /*" -1725-  WHEN RELATORI-COD-RELATORIO EQUAL 'VLNXA02'  */

                /*" -1725- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VLNXA02' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VLNXA02")
            {

                /*" -1727- MOVE 'ALTERACAO DADOS DO CONJUGE' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DADOS DO CONJUGE", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1728- PERFORM R1107-00-BUSCA-DADOS-CONJUGE */

                R1107_00_BUSCA_DADOS_CONJUGE_SECTION();

                /*" -1729- ADD 1 TO AC-ALT-DAD-CONJ */
                WORK_AREA.AC_ALT_DAD_CONJ.Value = WORK_AREA.AC_ALT_DAD_CONJ + 1;

                /*" -1730-  WHEN RELATORI-COD-RELATORIO EQUAL 'VE0401B1'  */

                /*" -1730- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VE0401B1' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VE0401B1")
            {

                /*" -1731- MOVE '2� VIA DE CERTIFICADO' TO SVA-TIPO-ENDOSSO */
                _.Move("2� VIA DE CERTIFICADO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1732- MOVE 'S' TO WS-VE0401B1 */
                _.Move("S", WORK_AREA.WS_VE0401B1);

                /*" -1733- ADD 1 TO AC-SEG-VIA-CERT */
                WORK_AREA.AC_SEG_VIA_CERT.Value = WORK_AREA.AC_SEG_VIA_CERT + 1;

                /*" -1734-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGLUA'  */

                /*" -1734- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGLUA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGLUA")
            {

                /*" -1736- MOVE 'EMISSAO CERTIFICADO INDIVIDUAL' TO SVA-TIPO-ENDOSSO */
                _.Move("EMISSAO CERTIFICADO INDIVIDUAL", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1737- ADD 1 TO AC-EMIS-CERT-IND */
                WORK_AREA.AC_EMIS_CERT_IND.Value = WORK_AREA.AC_EMIS_CERT_IND + 1;

                /*" -1738-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGOSP016'  */

                /*" -1738- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGOSP016' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGOSP016")
            {

                /*" -1740- MOVE 'ALTERACAO DE CAPITAL GLOBAL' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE CAPITAL GLOBAL", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1741- ADD 1 TO AC-ALT-CAPIT-GLO */
                WORK_AREA.AC_ALT_CAPIT_GLO.Value = WORK_AREA.AC_ALT_CAPIT_GLO + 1;

                /*" -1742-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGMOA'  */

                /*" -1742- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGMOA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGMOA")
            {

                /*" -1743- MOVE 'AUMENTO DE CAPITAL' TO SVA-TIPO-ENDOSSO */
                _.Move("AUMENTO DE CAPITAL", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1744- ADD 1 TO AC-AUM-CAPITAL */
                WORK_AREA.AC_AUM_CAPITAL.Value = WORK_AREA.AC_AUM_CAPITAL + 1;

                /*" -1745-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGMGA'  */

                /*" -1745- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGMGA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGMGA")
            {

                /*" -1746- MOVE 'REDUCAO DE CAPITAL' TO SVA-TIPO-ENDOSSO */
                _.Move("REDUCAO DE CAPITAL", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1747- ADD 1 TO AC-RED-CAPITAL */
                WORK_AREA.AC_RED_CAPITAL.Value = WORK_AREA.AC_RED_CAPITAL + 1;

                /*" -1748-  WHEN RELATORI-COD-RELATORIO EQUAL 'VG0031B'  */

                /*" -1748- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VG0031B' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VG0031B")
            {

                /*" -1749- MOVE 'CANCELAMENTO - APOLICE' TO SVA-TIPO-ENDOSSO */
                _.Move("CANCELAMENTO - APOLICE", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1750- ADD 1 TO AC-CANC-APOLICE */
                WORK_AREA.AC_CANC_APOLICE.Value = WORK_AREA.AC_CANC_APOLICE + 1;

                /*" -1751-  WHEN RELATORI-COD-RELATORIO EQUAL 'VG0031B1'  */

                /*" -1751- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VG0031B1' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VG0031B1")
            {

                /*" -1752- MOVE 'CANCELAMENTO - SUBGRUPO' TO SVA-TIPO-ENDOSSO */
                _.Move("CANCELAMENTO - SUBGRUPO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1753- ADD 1 TO AC-CANC-SUBGRUPO */
                WORK_AREA.AC_CANC_SUBGRUPO.Value = WORK_AREA.AC_CANC_SUBGRUPO + 1;

                /*" -1755-  WHEN RELATORI-COD-RELATORIO EQUAL 'VG0120B' OR 'VG0121B' OR 'VG0122B' OR 'VG0123B'  */

                /*" -1755- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VG0120B' OR 'VG0121B' OR 'VG0122B' OR 'VG0123B' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VG0120B", "VG0121B", "VG0122B", "VG0123B"))
            {

                /*" -1757- MOVE 'SOLICITACAO DE RELACAO DE VIDAS' TO SVA-TIPO-ENDOSSO */
                _.Move("SOLICITACAO DE RELACAO DE VIDAS", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1758- ADD 1 TO AC-SOL-RELACAO */
                WORK_AREA.AC_SOL_RELACAO.Value = WORK_AREA.AC_SOL_RELACAO + 1;

                /*" -1759-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGFFA'  */

                /*" -1759- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGFFA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGFFA")
            {

                /*" -1760- MOVE 'INCLUSAO DE SUBGRUPO' TO SVA-TIPO-ENDOSSO */
                _.Move("INCLUSAO DE SUBGRUPO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1761- ADD 1 TO AC-INCL-SUBGRUPO */
                WORK_AREA.AC_INCL_SUBGRUPO.Value = WORK_AREA.AC_INCL_SUBGRUPO + 1;

                /*" -1762-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGFTA'  */

                /*" -1762- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGFTA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGFTA")
            {

                /*" -1763- MOVE 'ALTERAR TAXA' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERAR TAXA", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1764- ADD 1 TO AC-ALT-TAXA */
                WORK_AREA.AC_ALT_TAXA.Value = WORK_AREA.AC_ALT_TAXA + 1;

                /*" -1765-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGFYA'  */

                /*" -1765- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGFYA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGFYA")
            {

                /*" -1766- MOVE 'ALTERAR COBERTURAS' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERAR COBERTURAS", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1767- ADD 1 TO AC-ALT-COBERT */
                WORK_AREA.AC_ALT_COBERT.Value = WORK_AREA.AC_ALT_COBERT + 1;

                /*" -1768-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGICA'  */

                /*" -1768- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGICA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGICA")
            {

                /*" -1769- MOVE 'INCLUSAO DE PLANO' TO SVA-TIPO-ENDOSSO */
                _.Move("INCLUSAO DE PLANO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1770- ADD 1 TO AC-INCL-PLANO */
                WORK_AREA.AC_INCL_PLANO.Value = WORK_AREA.AC_INCL_PLANO + 1;

                /*" -1771-  WHEN RELATORI-COD-RELATORIO EQUAL 'CB0355B1'  */

                /*" -1771- ELSE IF RELATORI-COD-RELATORIO EQUAL 'CB0355B1' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "CB0355B1")
            {

                /*" -1773- MOVE 'ESTORNO/DEVOLUCAO EM FOLLOW' TO SVA-TIPO-ENDOSSO */
                _.Move("ESTORNO/DEVOLUCAO EM FOLLOW", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1774- ADD 1 TO AC-EST-DEV-FOLLOW */
                WORK_AREA.AC_EST_DEV_FOLLOW.Value = WORK_AREA.AC_EST_DEV_FOLLOW + 1;

                /*" -1777-  WHEN RELATORI-COD-RELATORIO EQUAL 'MR0004B1' OR 'MR0873B1' OR 'MR0104B1' OR 'MR0204B1' OR 'MR0014B1' OR 'MR0114B1' OR 'MR0214B1' OR 'EM0200B1'  */

                /*" -1777- ELSE IF RELATORI-COD-RELATORIO EQUAL 'MR0004B1' OR 'MR0873B1' OR 'MR0104B1' OR 'MR0204B1' OR 'MR0014B1' OR 'MR0114B1' OR 'MR0214B1' OR 'EM0200B1' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("MR0004B1", "MR0873B1", "MR0104B1", "MR0204B1", "MR0014B1", "MR0114B1", "MR0214B1", "EM0200B1"))
            {

                /*" -1779- MOVE '2� VIA DE FRONTISPICIO' TO SVA-TIPO-ENDOSSO */
                _.Move("2� VIA DE FRONTISPICIO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1780- ADD 1 TO AC-SEG-VIA-FRONT */
                WORK_AREA.AC_SEG_VIA_FRONT.Value = WORK_AREA.AC_SEG_VIA_FRONT + 1;

                /*" -1781-  WHEN RELATORI-COD-RELATORIO EQUAL 'VPVMA'  */

                /*" -1781- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VPVMA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VPVMA")
            {

                /*" -1783- MOVE 'ALTERACAO DE CAPITAL - VIDA EXCLUSIVO' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE CAPITAL - VIDA EXCLUSIVO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1784- PERFORM R1108-00-VERIFICA-CAPITAL */

                R1108_00_VERIFICA_CAPITAL_SECTION();

                /*" -1785- ADD 1 TO AC-ALT-CAPIT-EXC */
                WORK_AREA.AC_ALT_CAPIT_EXC.Value = WORK_AREA.AC_ALT_CAPIT_EXC + 1;

                /*" -1786-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGJ1A'  */

                /*" -1786- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGJ1A' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGJ1A")
            {

                /*" -1788- MOVE 'REABILITACAO - APOLICE ESPECIFICA' TO SVA-TIPO-ENDOSSO */
                _.Move("REABILITACAO - APOLICE ESPECIFICA", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1789- ADD 1 TO AC-REAB-AP-ESPEC */
                WORK_AREA.AC_REAB_AP_ESPEC.Value = WORK_AREA.AC_REAB_AP_ESPEC + 1;

                /*" -1790-  WHEN RELATORI-COD-RELATORIO EQUAL 'CTB2A'  */

                /*" -1790- ELSE IF RELATORI-COD-RELATORIO EQUAL 'CTB2A' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "CTB2A")
            {

                /*" -1792- MOVE 'ALTERACAO DE DADOS CADASTRAIS' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE DADOS CADASTRAIS", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1793- MOVE 2 TO SVA-TIP-REL */
                _.Move(2, REG_SVA0930B.SVA_TIP_REL);

                /*" -1794- PERFORM R1111-00-VERIFICA-CAMPOS-CTB2A */

                R1111_00_VERIFICA_CAMPOS_CTB2A_SECTION();

                /*" -1795- ADD 1 TO AC-ALT-DAD-CAD */
                WORK_AREA.AC_ALT_DAD_CAD.Value = WORK_AREA.AC_ALT_DAD_CAD + 1;

                /*" -1796-  WHEN RELATORI-COD-RELATORIO EQUAL 'VGMAA'  */

                /*" -1796- ELSE IF RELATORI-COD-RELATORIO EQUAL 'VGMAA' */
            }
            else

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == "VGMAA")
            {

                /*" -1798- MOVE 'ALTERACAO DE DADOS DO CERTIFICADO' TO SVA-TIPO-ENDOSSO */
                _.Move("ALTERACAO DE DADOS DO CERTIFICADO", REG_SVA0930B.SVA_TIPO_ENDOSSO);

                /*" -1799- PERFORM R1114-00-MOVER-CAMPOS-VGMAA */

                R1114_00_MOVER_CAMPOS_VGMAA_SECTION();

                /*" -1800- ADD 1 TO AC-ALT-DAD-CERTIF */
                WORK_AREA.AC_ALT_DAD_CERTIF.Value = WORK_AREA.AC_ALT_DAD_CERTIF + 1;

                /*" -1801-  WHEN OTHER  */

                /*" -1801- ELSE */
            }
            else
            {


                /*" -1802- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1802-  END-EVALUATE.  */

                /*" -1802- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-BILHETE-SECTION */
        private void R1020_00_SELECT_BILHETE_SECTION()
        {
            /*" -1814- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1815- IF RELATORI-NUM-TITULO NOT EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO != 00)
            {

                /*" -1816- MOVE RELATORI-NUM-TITULO TO WS-NUM-BILHETE */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO, WORK_AREA.WS_NUM_BILHETE);

                /*" -1817- ELSE */
            }
            else
            {


                /*" -1818- MOVE RELATORI-NUM-CERTIFICADO TO WS-NUM-BILHETE */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, WORK_AREA.WS_NUM_BILHETE);

                /*" -1820- END-IF. */
            }


            /*" -1828- PERFORM R1020_00_SELECT_BILHETE_DB_SELECT_1 */

            R1020_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1831- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1832- DISPLAY 'R1020 - ERRO NO SELECT SEGUROS.V0BILHETE' */
                _.Display($"R1020 - ERRO NO SELECT SEGUROS.V0BILHETE");

                /*" -1833- DISPLAY 'R1020 - SQLCODE - ' SQLCODE */
                _.Display($"R1020 - SQLCODE - {DB.SQLCODE}");

                /*" -1834- DISPLAY 'R1020 - NUM-BIL - ' WS-NUM-BILHETE */
                _.Display($"R1020 - NUM-BIL - {WORK_AREA.WS_NUM_BILHETE}");

                /*" -1835- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1836- ELSE */
            }
            else
            {


                /*" -1837- MOVE V0BILH-NUM-APOLICE TO WS-APOLICE */
                _.Move(V0BILH_NUM_APOLICE, WORK_AREA.WS_APOLICE);

                /*" -1838- MOVE WS-APOLICE TO WS-NUM-APOLICE */
                _.Move(WORK_AREA.WS_APOLICE, WORK_AREA.WS_NUM_APOLICE);

                /*" -1839- MOVE ZEROS TO WS-COD-SUBGRUPO */
                _.Move(0, WORK_AREA.WS_COD_SUBGRUPO);

                /*" -1840- MOVE V0BILH-CODCLIEN TO WS-COD-CLIENTE */
                _.Move(V0BILH_CODCLIEN, WORK_AREA.WS_COD_CLIENTE);

                /*" -1840- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R1020_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -1828- EXEC SQL SELECT NUM_APOLICE, CODCLIEN INTO :V0BILH-NUM-APOLICE, :V0BILH-CODCLIEN FROM SEGUROS.V0BILHETE WHERE NUMBIL = :WS-NUM-BILHETE WITH UR END-EXEC. */

            var r1020_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                WS_NUM_BILHETE = WORK_AREA.WS_NUM_BILHETE.ToString(),
            };

            var executed_1 = R1020_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_NUM_APOLICE, V0BILH_NUM_APOLICE);
                _.Move(executed_1.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-CERTIFICADO-SECTION */
        private void R1030_00_SELECT_CERTIFICADO_SECTION()
        {
            /*" -1854- MOVE '103' TO WNR-EXEC-SQL. */
            _.Move("103", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1855- IF RELATORI-NUM-CERTIFICADO EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO == 00)
            {

                /*" -1856- MOVE RELATORI-NUM-TITULO TO WS-NUM-CERTIFICADO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO, WORK_AREA.WS_NUM_CERTIFICADO);

                /*" -1857- ELSE */
            }
            else
            {


                /*" -1858- MOVE RELATORI-NUM-CERTIFICADO TO WS-NUM-CERTIFICADO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, WORK_AREA.WS_NUM_CERTIFICADO);

                /*" -1860- END-IF. */
            }


            /*" -1870- PERFORM R1030_00_SELECT_CERTIFICADO_DB_SELECT_1 */

            R1030_00_SELECT_CERTIFICADO_DB_SELECT_1();

            /*" -1873- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1874- DISPLAY 'R1030 - ERRO NO SELECT SEGUROS.V0PROPOSTAVA' */
                _.Display($"R1030 - ERRO NO SELECT SEGUROS.V0PROPOSTAVA");

                /*" -1875- DISPLAY 'R1030 - SQLCODE  - ' SQLCODE */
                _.Display($"R1030 - SQLCODE  - {DB.SQLCODE}");

                /*" -1876- DISPLAY 'R1030 - NRCERTIF - ' WS-NUM-CERTIFICADO */
                _.Display($"R1030 - NRCERTIF - {WORK_AREA.WS_NUM_CERTIFICADO}");

                /*" -1877- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1878- ELSE */
            }
            else
            {


                /*" -1879- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1890- PERFORM R1030_00_SELECT_CERTIFICADO_DB_SELECT_2 */

                    R1030_00_SELECT_CERTIFICADO_DB_SELECT_2();

                    /*" -1893- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -1894- DISPLAY 'R1030 - ERRO NO SELECT SEGUROS.V0SEGURAVG' */
                        _.Display($"R1030 - ERRO NO SELECT SEGUROS.V0SEGURAVG");

                        /*" -1895- DISPLAY 'R1030 - CERTIFICADO - ' WS-NUM-CERTIFICADO */
                        _.Display($"R1030 - CERTIFICADO - {WORK_AREA.WS_NUM_CERTIFICADO}");

                        /*" -1896- DISPLAY 'R1030 - SQLCODE - ' SQLCODE */
                        _.Display($"R1030 - SQLCODE - {DB.SQLCODE}");

                        /*" -1897- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1898- ELSE */
                    }
                    else
                    {


                        /*" -1899- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1901- IF WS-VE0401B1 EQUAL 'S' */

                            if (WORK_AREA.WS_VE0401B1 == "S")
                            {

                                /*" -1903- INITIALIZE DCLTERMO-ADESAO */
                                _.Initialize(
                                    TERMOADE.DCLTERMO_ADESAO
                                );

                                /*" -1909- PERFORM R1030_00_SELECT_CERTIFICADO_DB_SELECT_3 */

                                R1030_00_SELECT_CERTIFICADO_DB_SELECT_3();

                                /*" -1912- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

                                if (!DB.SQLCODE.In("00", "100"))
                                {

                                    /*" -1914- DISPLAY 'R1030 - ERRO NO SELECT' ' SEGUROS.TERMO_ADESAO.' */
                                    _.Display($"R1030 - ERRO NO SELECT SEGUROS.TERMO_ADESAO.");

                                    /*" -1916- DISPLAY 'R1030 - CERTIFICADO - ' WS-NUM-CERTIFICADO */
                                    _.Display($"R1030 - CERTIFICADO - {WORK_AREA.WS_NUM_CERTIFICADO}");

                                    /*" -1918- DISPLAY 'R1030 - NUM-TERMO - ' RELATORI-NUM-TITULO */
                                    _.Display($"R1030 - NUM-TERMO - {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                                    /*" -1919- DISPLAY 'R1030 - SQLCODE - ' SQLCODE */
                                    _.Display($"R1030 - SQLCODE - {DB.SQLCODE}");

                                    /*" -1920- GO TO R9999-00-ROT-ERRO */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;

                                    /*" -1921- ELSE */
                                }
                                else
                                {


                                    /*" -1922- IF SQLCODE EQUAL 100 */

                                    if (DB.SQLCODE == 100)
                                    {

                                        /*" -1924- DISPLAY 'R1030 - ERRO NO SELECT' ' SEGUROS.TERMO_ADESAO.' */
                                        _.Display($"R1030 - ERRO NO SELECT SEGUROS.TERMO_ADESAO.");

                                        /*" -1926- DISPLAY 'R1030 - CERTIFICADO - ' WS-NUM-CERTIFICADO */
                                        _.Display($"R1030 - CERTIFICADO - {WORK_AREA.WS_NUM_CERTIFICADO}");

                                        /*" -1928- DISPLAY 'R1030 - NUM-TERMO - ' RELATORI-NUM-TITULO */
                                        _.Display($"R1030 - NUM-TERMO - {RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO}");

                                        /*" -1929- DISPLAY 'R1030 - SQLCODE - ' SQLCODE */
                                        _.Display($"R1030 - SQLCODE - {DB.SQLCODE}");

                                        /*" -1930- GO TO R1000-10-NEXT */

                                        R1000_10_NEXT(); //GOTO
                                        return;

                                        /*" -1931- END-IF */
                                    }


                                    /*" -1933- END-IF */
                                }


                                /*" -1934- MOVE RELATORI-NUM-APOLICE TO V0PROP-APOLICE */
                                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, V0PROP_APOLICE);

                                /*" -1935- MOVE RELATORI-COD-SUBGRUPO TO V0PROP-CODSUBES */
                                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, V0PROP_CODSUBES);

                                /*" -1937- MOVE TERMOADE-COD-CLIENTE TO V0PROP-CODCLIEN */
                                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, V0PROP_CODCLIEN);

                                /*" -1938- ELSE */
                            }
                            else
                            {


                                /*" -1939- DISPLAY 'R1030 - ERRO NO SELECT SEGUROS.V0SEGURAVG' */
                                _.Display($"R1030 - ERRO NO SELECT SEGUROS.V0SEGURAVG");

                                /*" -1940- DISPLAY 'R1030 - CERTIFICADO - ' WS-NUM-CERTIFICADO */
                                _.Display($"R1030 - CERTIFICADO - {WORK_AREA.WS_NUM_CERTIFICADO}");

                                /*" -1941- DISPLAY 'R1030 - SQLCODE - ' SQLCODE */
                                _.Display($"R1030 - SQLCODE - {DB.SQLCODE}");

                                /*" -1942- GO TO R1000-10-NEXT */

                                R1000_10_NEXT(); //GOTO
                                return;

                                /*" -1943- END-IF */
                            }


                            /*" -1944- END-IF */
                        }


                        /*" -1945- END-IF */
                    }


                    /*" -1946- END-IF */
                }


                /*" -1948- END-IF */
            }


            /*" -1949- MOVE V0PROP-APOLICE TO WS-APOLICE */
            _.Move(V0PROP_APOLICE, WORK_AREA.WS_APOLICE);

            /*" -1950- MOVE WS-APOLICE TO WS-NUM-APOLICE */
            _.Move(WORK_AREA.WS_APOLICE, WORK_AREA.WS_NUM_APOLICE);

            /*" -1951- MOVE V0PROP-CODSUBES TO WS-COD-SUBGRUPO */
            _.Move(V0PROP_CODSUBES, WORK_AREA.WS_COD_SUBGRUPO);

            /*" -1953- MOVE V0PROP-CODCLIEN TO WS-COD-CLIENTE */
            _.Move(V0PROP_CODCLIEN, WORK_AREA.WS_COD_CLIENTE);

            /*" -1953- . */

        }

        [StopWatch]
        /*" R1030-00-SELECT-CERTIFICADO-DB-SELECT-1 */
        public void R1030_00_SELECT_CERTIFICADO_DB_SELECT_1()
        {
            /*" -1870- EXEC SQL SELECT NUM_APOLICE, CODSUBES, CODCLIEN INTO :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-CODCLIEN FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :WS-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1 = new R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1()
            {
                WS_NUM_CERTIFICADO = WORK_AREA.WS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1.Execute(r1030_00_SELECT_CERTIFICADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-SELECT-CERTIFICADO-DB-SELECT-2 */
        public void R1030_00_SELECT_CERTIFICADO_DB_SELECT_2()
        {
            /*" -1890- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, COD_CLIENTE INTO :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-CODCLIEN FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1 = new R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1()
            {
                WS_NUM_CERTIFICADO = WORK_AREA.WS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1.Execute(r1030_00_SELECT_CERTIFICADO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
            }


        }

        [StopWatch]
        /*" R1040-00-SELECT-PRODUTOSVG-SECTION */
        private void R1040_00_SELECT_PRODUTOSVG_SECTION()
        {
            /*" -1965- MOVE '104' TO WNR-EXEC-SQL. */
            _.Move("104", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1966- IF WS-BILHETE EQUAL 'S' */

            if (WORK_AREA.WS_BILHETE == "S")
            {

                /*" -1977- PERFORM R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1 */

                R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1();

                /*" -1980- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1981- DISPLAY 'R1040 - ERRO NO SELECT SEGUROS.APOLICES' */
                    _.Display($"R1040 - ERRO NO SELECT SEGUROS.APOLICES");

                    /*" -1982- DISPLAY 'R1040 - SQLCODE  - ' SQLCODE */
                    _.Display($"R1040 - SQLCODE  - {DB.SQLCODE}");

                    /*" -1983- DISPLAY 'R1040 - NUM-APOL - ' WS-NUM-APOLICE */
                    _.Display($"R1040 - NUM-APOL - {WORK_AREA.WS_NUM_APOLICE}");

                    /*" -1984- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1985- ELSE */
                }
                else
                {


                    /*" -1986- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1987- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -1988- END-IF */
                    }


                    /*" -1989- END-IF */
                }


                /*" -1990- ELSE */
            }
            else
            {


                /*" -1991- IF WS-SO-APOLICE EQUAL 'S' */

                if (WORK_AREA.WS_SO_APOLICE == "S")
                {

                    /*" -1992- MOVE RELATORI-NUM-APOLICE TO WS-NUM-APOLICE */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, WORK_AREA.WS_NUM_APOLICE);

                    /*" -1993- MOVE RELATORI-COD-SUBGRUPO TO WS-COD-SUBGRUPO */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, WORK_AREA.WS_COD_SUBGRUPO);

                    /*" -1995- END-IF */
                }


                /*" -2007- PERFORM R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2 */

                R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2();

                /*" -2010- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -2011- DISPLAY 'R1040 - ERRO NO SELECT SEGUROS.V0PRODUTOSVG' */
                    _.Display($"R1040 - ERRO NO SELECT SEGUROS.V0PRODUTOSVG");

                    /*" -2012- DISPLAY 'R1040 - SQLCODE  - ' SQLCODE */
                    _.Display($"R1040 - SQLCODE  - {DB.SQLCODE}");

                    /*" -2013- DISPLAY 'R1040 - NUM-APOL - ' WS-NUM-APOLICE */
                    _.Display($"R1040 - NUM-APOL - {WORK_AREA.WS_NUM_APOLICE}");

                    /*" -2014- DISPLAY 'R1040 - COD-SUBG - ' WS-COD-SUBGRUPO */
                    _.Display($"R1040 - COD-SUBG - {WORK_AREA.WS_COD_SUBGRUPO}");

                    /*" -2015- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2016- ELSE */
                }
                else
                {


                    /*" -2017- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2018- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -2019- END-IF */
                    }


                    /*" -2020- END-IF */
                }


                /*" -2020- END-IF. */
            }


        }

        [StopWatch]
        /*" R1040-00-SELECT-PRODUTOSVG-DB-SELECT-1 */
        public void R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1()
        {
            /*" -1977- EXEC SQL SELECT B.CODPRODU, B.DESCRPROD INTO :V0PROP-CODPRODU, :V0PROP-NOMPRODU FROM SEGUROS.APOLICES A, SEGUROS.V0PRODUTO B WHERE A.NUM_APOLICE = :WS-NUM-APOLICE AND A.COD_PRODUTO = B.CODPRODU AND A.RAMO_EMISSOR NOT IN ( 0 , 77 ) WITH UR END-EXEC */

            var r1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 = new R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1()
            {
                WS_NUM_APOLICE = WORK_AREA.WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1.Execute(r1040_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_NOMPRODU, V0PROP_NOMPRODU);
            }


        }

        [StopWatch]
        /*" R1030-00-SELECT-CERTIFICADO-DB-SELECT-3 */
        public void R1030_00_SELECT_CERTIFICADO_DB_SELECT_3()
        {
            /*" -1909- EXEC SQL SELECT COD_CLIENTE INTO :TERMOADE-COD-CLIENTE FROM SEGUROS.TERMO_ADESAO WHERE NUM_TERMO = :RELATORI-NUM-TITULO WITH UR END-EXEC */

            var r1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1 = new R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1.Execute(r1030_00_SELECT_CERTIFICADO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TERMOADE_COD_CLIENTE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R1040-00-SELECT-PRODUTOSVG-DB-SELECT-2 */
        public void R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2()
        {
            /*" -2007- EXEC SQL SELECT B.CODPRODU, B.DESCRPROD INTO :V0PROP-CODPRODU, :V0PROP-NOMPRODU FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PRODUTO B WHERE A.NUM_APOLICE = :WS-NUM-APOLICE AND A.CODSUBES = :WS-COD-SUBGRUPO AND A.CODPRODU = B.CODPRODU AND A.RAMO NOT IN ( 0 , 77 ) WITH UR END-EXEC */

            var r1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1 = new R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1()
            {
                WS_COD_SUBGRUPO = WORK_AREA.WS_COD_SUBGRUPO.ToString(),
                WS_NUM_APOLICE = WORK_AREA.WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1.Execute(r1040_00_SELECT_PRODUTOSVG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_NOMPRODU, V0PROP_NOMPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-CLIENTE-SECTION */
        private void R1050_00_SELECT_CLIENTE_SECTION()
        {
            /*" -2032- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2033- IF SVA-TIP-REL EQUAL 2 */

            if (REG_SVA0930B.SVA_TIP_REL == 2)
            {

                /*" -2034- MOVE RELATORI-NUM-ORDEM TO WS-COD-CLIENTE */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM, WORK_AREA.WS_COD_CLIENTE);

                /*" -2035- END-IF */
            }


            /*" -2037- MOVE +0 TO VIND-DATA-NASC */
            _.Move(+0, VIND_DATA_NASC);

            /*" -2049- PERFORM R1050_00_SELECT_CLIENTE_DB_SELECT_1 */

            R1050_00_SELECT_CLIENTE_DB_SELECT_1();

            /*" -2052- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2053- DISPLAY 'R1050 - ERRO NO SELECT SEGUROS.V0CLIENTE' */
                _.Display($"R1050 - ERRO NO SELECT SEGUROS.V0CLIENTE");

                /*" -2054- DISPLAY 'R1050 - SQLCODE - ' SQLCODE */
                _.Display($"R1050 - SQLCODE - {DB.SQLCODE}");

                /*" -2055- DISPLAY 'R1050 - COD-CLI - ' WS-COD-CLIENTE */
                _.Display($"R1050 - COD-CLI - {WORK_AREA.WS_COD_CLIENTE}");

                /*" -2056- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2057- ELSE */
            }
            else
            {


                /*" -2058- MOVE V0CLIE-NOME-RAZAO TO WS-NOME-RAZAO */
                _.Move(V0CLIE_NOME_RAZAO, WORK_AREA.WS_NOME_RAZAO);

                /*" -2059- MOVE V0CLIE-CGCCPF TO WS-CGCCPF */
                _.Move(V0CLIE_CGCCPF, WORK_AREA.WS_CGCCPF);

                /*" -2060- MOVE V0CLIE-TIPO-PESSOA TO WS-TIPO-PESSOA */
                _.Move(V0CLIE_TIPO_PESSOA, WORK_AREA.WS_TIPO_PESSOA);

                /*" -2061- IF VIND-DATA-NASC LESS ZEROS */

                if (VIND_DATA_NASC < 00)
                {

                    /*" -2062- MOVE SPACES TO WS-DATA-NASC */
                    _.Move("", WORK_AREA.WS_DATA_NASC);

                    /*" -2063- ELSE */
                }
                else
                {


                    /*" -2064- MOVE V0CLIE-DATA-NASC TO WS-DATA-NASC */
                    _.Move(V0CLIE_DATA_NASC, WORK_AREA.WS_DATA_NASC);

                    /*" -2065- END-IF */
                }


                /*" -2065- END-IF. */
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-CLIENTE-DB-SELECT-1 */
        public void R1050_00_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -2049- EXEC SQL SELECT NOME_RAZAO, CGCCPF, TIPO_PESSOA, DATA_NASCIMENTO INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CGCCPF, :V0CLIE-TIPO-PESSOA, :V0CLIE-DATA-NASC:VIND-DATA-NASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :WS-COD-CLIENTE WITH UR END-EXEC. */

            var r1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                WS_COD_CLIENTE = WORK_AREA.WS_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
                _.Move(executed_1.V0CLIE_CGCCPF, V0CLIE_CGCCPF);
                _.Move(executed_1.V0CLIE_TIPO_PESSOA, V0CLIE_TIPO_PESSOA);
                _.Move(executed_1.V0CLIE_DATA_NASC, V0CLIE_DATA_NASC);
                _.Move(executed_1.VIND_DATA_NASC, VIND_DATA_NASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-SELECT-USUARIO-SECTION */
        private void R1060_00_SELECT_USUARIO_SECTION()
        {
            /*" -2076- MOVE '106' TO WNR-EXEC-SQL. */
            _.Move("106", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2078- MOVE ' ' TO V0USUA-NOMUSU. */
            _.Move(" ", V0USUA_NOMUSU);

            /*" -2084- PERFORM R1060_00_SELECT_USUARIO_DB_SELECT_1 */

            R1060_00_SELECT_USUARIO_DB_SELECT_1();

            /*" -2087- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2088- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2089- DISPLAY 'R1060 - ERRO NO SELECT SEGUROS.V0USUARIOS' */
                    _.Display($"R1060 - ERRO NO SELECT SEGUROS.V0USUARIOS");

                    /*" -2090- DISPLAY 'R1060 - SQLCODE - ' SQLCODE */
                    _.Display($"R1060 - SQLCODE - {DB.SQLCODE}");

                    /*" -2091- DISPLAY 'R1060 - COD-USU - ' RELATORI-COD-USUARIO */
                    _.Display($"R1060 - COD-USU - {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                    /*" -2092- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2093- ELSE */
                }
                else
                {


                    /*" -2097- IF RELATORI-COD-USUARIO NOT EQUAL 'VE2640B' */

                    if (RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO != "VE2640B")
                    {

                        /*" -2098- MOVE 'USUARIO INEXISTENTE NO SIAS' TO WS-NOME-USUARIO */
                        _.Move("USUARIO INEXISTENTE NO SIAS", WORK_AREA.WS_NOME_USUARIO);

                        /*" -2099- END-IF */
                    }


                    /*" -2100- END-IF */
                }


                /*" -2101- ELSE */
            }
            else
            {


                /*" -2102- MOVE V0USUA-NOMUSU TO WS-NOME-USUARIO */
                _.Move(V0USUA_NOMUSU, WORK_AREA.WS_NOME_USUARIO);

                /*" -2102- END-IF. */
            }


        }

        [StopWatch]
        /*" R1060-00-SELECT-USUARIO-DB-SELECT-1 */
        public void R1060_00_SELECT_USUARIO_DB_SELECT_1()
        {
            /*" -2084- EXEC SQL SELECT NOMUSU INTO :V0USUA-NOMUSU FROM SEGUROS.V0USUARIOS WHERE CODUSU = :RELATORI-COD-USUARIO WITH UR END-EXEC. */

            var r1060_00_SELECT_USUARIO_DB_SELECT_1_Query1 = new R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
            };

            var executed_1 = R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1.Execute(r1060_00_SELECT_USUARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0USUA_NOMUSU, V0USUA_NOMUSU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1080-SELECT-NRCERTIF-APOL-SECTION */
        private void R1080_SELECT_NRCERTIF_APOL_SECTION()
        {
            /*" -2114- MOVE '108' TO WNR-EXEC-SQL. */
            _.Move("108", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2115- MOVE RELATORI-NUM-APOLICE TO WS-NUM-APOLICE */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, WORK_AREA.WS_NUM_APOLICE);

            /*" -2117- MOVE RELATORI-COD-SUBGRUPO TO WS-COD-SUBGRUPO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, WORK_AREA.WS_COD_SUBGRUPO);

            /*" -2124- PERFORM R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1 */

            R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1();

            /*" -2127- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2128- DISPLAY 'R1080 - ERRO NO SELECT SEGUROS.V0PROPOSTAVA' */
                _.Display($"R1080 - ERRO NO SELECT SEGUROS.V0PROPOSTAVA");

                /*" -2129- DISPLAY 'R1080 - SQLCODE  - ' SQLCODE */
                _.Display($"R1080 - SQLCODE  - {DB.SQLCODE}");

                /*" -2130- DISPLAY 'R1080 - NUM-APOL - ' WS-NUM-APOLICE */
                _.Display($"R1080 - NUM-APOL - {WORK_AREA.WS_NUM_APOLICE}");

                /*" -2131- DISPLAY 'R1080 - COD-SUBG - ' WS-COD-SUBGRUPO */
                _.Display($"R1080 - COD-SUBG - {WORK_AREA.WS_COD_SUBGRUPO}");

                /*" -2132- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2133- ELSE */
            }
            else
            {


                /*" -2134- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2135- GO TO R1080-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/ //GOTO
                    return;

                    /*" -2136- END-IF */
                }


                /*" -2138- END-IF */
            }


            /*" -2140- MOVE SUBGRU-COD-CLIENTE TO WS-COD-CLIENTE */
            _.Move(SUBGRU_COD_CLIENTE, WORK_AREA.WS_COD_CLIENTE);

            /*" -2148- PERFORM R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2 */

            R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2();

            /*" -2151- IF SQLCODE NOT EQUAL ZEROS AND NOT EQUAL 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2152- DISPLAY 'R1080 - ERRO SELECT SEGUROS.V0PROPOSTAVA' */
                _.Display($"R1080 - ERRO SELECT SEGUROS.V0PROPOSTAVA");

                /*" -2153- DISPLAY 'R1080 - SQLCODE  - ' SQLCODE */
                _.Display($"R1080 - SQLCODE  - {DB.SQLCODE}");

                /*" -2154- DISPLAY 'R1080 - COD-CLI  - ' WS-COD-CLIENTE */
                _.Display($"R1080 - COD-CLI  - {WORK_AREA.WS_COD_CLIENTE}");

                /*" -2155- DISPLAY 'R1080 - NUM-APOL - ' WS-NUM-APOLICE */
                _.Display($"R1080 - NUM-APOL - {WORK_AREA.WS_NUM_APOLICE}");

                /*" -2156- DISPLAY 'R1080 - COD-SUBG - ' WS-COD-SUBGRUPO */
                _.Display($"R1080 - COD-SUBG - {WORK_AREA.WS_COD_SUBGRUPO}");

                /*" -2157- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2158- ELSE */
            }
            else
            {


                /*" -2159- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2160- MOVE V0PROP-NRCERTIF TO WS-NUM-CERTIFICADO */
                    _.Move(V0PROP_NRCERTIF, WORK_AREA.WS_NUM_CERTIFICADO);

                    /*" -2161- END-IF */
                }


                /*" -2161- END-IF. */
            }


        }

        [StopWatch]
        /*" R1080-SELECT-NRCERTIF-APOL-DB-SELECT-1 */
        public void R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1()
        {
            /*" -2124- EXEC SQL SELECT COD_CLIENTE INTO :SUBGRU-COD-CLIENTE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :WS-NUM-APOLICE AND COD_SUBGRUPO = :WS-COD-SUBGRUPO WITH UR END-EXEC. */

            var r1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1 = new R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1()
            {
                WS_COD_SUBGRUPO = WORK_AREA.WS_COD_SUBGRUPO.ToString(),
                WS_NUM_APOLICE = WORK_AREA.WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1.Execute(r1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGRU_COD_CLIENTE, SUBGRU_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1080_99_SAIDA*/

        [StopWatch]
        /*" R1080-SELECT-NRCERTIF-APOL-DB-SELECT-2 */
        public void R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2()
        {
            /*" -2148- EXEC SQL SELECT NRCERTIF INTO :V0PROP-NRCERTIF FROM SEGUROS.V0PROPOSTAVA WHERE CODCLIEN = :WS-COD-CLIENTE AND NUM_APOLICE = :WS-NUM-APOLICE AND CODSUBES = :WS-COD-SUBGRUPO WITH UR END-EXEC. */

            var r1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1 = new R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1()
            {
                WS_COD_SUBGRUPO = WORK_AREA.WS_COD_SUBGRUPO.ToString(),
                WS_COD_CLIENTE = WORK_AREA.WS_COD_CLIENTE.ToString(),
                WS_NUM_APOLICE = WORK_AREA.WS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1.Execute(r1080_SELECT_NRCERTIF_APOL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
            }


        }

        [StopWatch]
        /*" R1101-00-VERIFICA-CAMPOS-CB52A-SECTION */
        private void R1101_00_VERIFICA_CAMPOS_CB52A_SECTION()
        {
            /*" -2173- MOVE '1101' TO WNR-EXEC-SQL */
            _.Move("1101", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2174- MOVE RELATORI-NUM-APOL-LIDER TO WCAMPOS-CB52A-01 */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, WORK_AREA.WCAMPOS_CB52A_01);

            /*" -2175- MOVE RELATORI-ENDOS-LIDER TO WCAMPOS-CB52A-02 */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER, WORK_AREA.WCAMPOS_CB52A_02);

            /*" -2177- MOVE RELATORI-NUM-SINI-LIDER TO WCAMPOS-CB52A-03 */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER, WORK_AREA.WCAMPOS_CB52A_03);

            /*" -2178- IF WAGECOBR EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WAGECOBR == "S")
            {

                /*" -2179- MOVE 'ALTERADO' TO SVA-AGE-VENDA-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_AGE_VENDA_BIL);

                /*" -2180- END-IF */
            }


            /*" -2181- IF WFONTE EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WFONTE == "S")
            {

                /*" -2182- MOVE 'ALTERADO' TO SVA-FILIAL-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_FILIAL_BIL);

                /*" -2183- END-IF */
            }


            /*" -2184- IF WNUMBIL EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WNUMBIL == "S")
            {

                /*" -2185- MOVE 'ALTERADO' TO SVA-NUM-BILHETE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_NUM_BILHETE);

                /*" -2186- END-IF */
            }


            /*" -2187- IF WRAMO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WRAMO == "S")
            {

                /*" -2188- MOVE 'ALTERADO' TO SVA-RAMO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_RAMO_BIL);

                /*" -2189- END-IF */
            }


            /*" -2190- IF WNUM-PROPOSTA EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WNUM_PROPOSTA == "S")
            {

                /*" -2191- MOVE 'ALTERADO' TO SVA-PROPOSTA-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_PROPOSTA_BIL);

                /*" -2192- END-IF */
            }


            /*" -2193- IF WNUM-APOL-ANTERIOR EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WNUM_APOL_ANTERIOR == "S")
            {

                /*" -2194- MOVE 'ALTERADO' TO SVA-NUM-BILHETE-ANT */
                _.Move("ALTERADO", REG_SVA0930B.SVA_NUM_BILHETE_ANT);

                /*" -2195- END-IF */
            }


            /*" -2196- IF WCODPRODU EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WCODPRODU == "S")
            {

                /*" -2197- MOVE 'ALTERADO' TO SVA-COD-PRODUTO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_COD_PRODUTO_BIL);

                /*" -2198- END-IF */
            }


            /*" -2199- IF WCONVENENTE EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WCONVENENTE == "S")
            {

                /*" -2200- MOVE 'ALTERADO' TO SVA-CONVENENTE-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CONVENENTE_BIL);

                /*" -2201- END-IF */
            }


            /*" -2202- IF WNOME-RAZAO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WNOME_RAZAO == "S")
            {

                /*" -2203- MOVE 'ALTERADO' TO SVA-NOME-SEGURADO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_NOME_SEGURADO_BIL);

                /*" -2204- END-IF */
            }


            /*" -2205- IF WDATA-NASCIMENTO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WDATA_NASCIMENTO == "S")
            {

                /*" -2206- MOVE 'ALTERADO' TO SVA-DATA-NASC-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DATA_NASC_BIL);

                /*" -2207- END-IF */
            }


            /*" -2208- IF WCGCCPF EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WCGCCPF == "S")
            {

                /*" -2209- MOVE 'ALTERADO' TO SVA-CPF-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CPF_BIL);

                /*" -2210- END-IF */
            }


            /*" -2211- IF WIDE-SEXO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WIDE_SEXO == "S")
            {

                /*" -2212- MOVE 'ALTERADO' TO SVA-SEXO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_SEXO_BIL);

                /*" -2213- END-IF */
            }


            /*" -2214- IF WESTADO-CIVIL EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WESTADO_CIVIL == "S")
            {

                /*" -2215- MOVE 'ALTERADO' TO SVA-ESTADO-CIVIL-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_ESTADO_CIVIL_BIL);

                /*" -2216- END-IF */
            }


            /*" -2217- IF WPROFISSAO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WPROFISSAO == "S")
            {

                /*" -2218- MOVE 'ALTERADO' TO SVA-PROFISSAO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_PROFISSAO_BIL);

                /*" -2219- END-IF */
            }


            /*" -2220- IF WBI-RENDA-IND EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_01.WBI_RENDA_IND == "S")
            {

                /*" -2221- MOVE 'ALTERADO' TO SVA-RENDA-INDIV-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_RENDA_INDIV_BIL);

                /*" -2222- END-IF */
            }


            /*" -2223- IF WBI-RENDA-FAM EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WBI_RENDA_FAM == "S")
            {

                /*" -2224- MOVE 'ALTERADO' TO SVA-RENDA-FAMIL-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_RENDA_FAMIL_BIL);

                /*" -2225- END-IF */
            }


            /*" -2226- IF WENDERECO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WENDERECO == "S")
            {

                /*" -2227- MOVE 'ALTERADO' TO SVA-ENDERECO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_ENDERECO_BIL);

                /*" -2228- END-IF */
            }


            /*" -2229- IF WBAIRRO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WBAIRRO == "S")
            {

                /*" -2230- MOVE 'ALTERADO' TO SVA-BAIRRO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_BAIRRO_BIL);

                /*" -2231- END-IF */
            }


            /*" -2232- IF WCIDADE EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WCIDADE == "S")
            {

                /*" -2233- MOVE 'ALTERADO' TO SVA-CIDADE-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CIDADE_BIL);

                /*" -2234- END-IF */
            }


            /*" -2235- IF WUF EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WUF == "S")
            {

                /*" -2236- MOVE 'ALTERADO' TO SVA-UF-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_UF_BIL);

                /*" -2237- END-IF */
            }


            /*" -2238- IF WCEP EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WCEP == "S")
            {

                /*" -2239- MOVE 'ALTERADO' TO SVA-CEP-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CEP_BIL);

                /*" -2240- END-IF */
            }


            /*" -2241- IF WDDD-FIXO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WDDD_FIXO == "S")
            {

                /*" -2242- MOVE 'ALTERADO' TO SVA-DDD-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DDD_BIL);

                /*" -2243- END-IF */
            }


            /*" -2244- IF WTEL-FIXO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WTEL_FIXO == "S")
            {

                /*" -2245- MOVE 'ALTERADO' TO SVA-TELEFONE-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_TELEFONE_BIL);

                /*" -2246- END-IF */
            }


            /*" -2247- IF WTEL-CEL EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WTEL_CEL == "S")
            {

                /*" -2248- MOVE 'ALTERADO' TO SVA-CELULAR-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CELULAR_BIL);

                /*" -2249- END-IF */
            }


            /*" -2250- IF WOPCAO-COBER EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WOPCAO_COBER == "S")
            {

                /*" -2251- MOVE 'ALTERADO' TO SVA-OPCAO-COB-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_OPCAO_COB_BIL);

                /*" -2252- END-IF */
            }


            /*" -2253- IF WIMP-SEGURADA EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WIMP_SEGURADA == "S")
            {

                /*" -2254- MOVE 'ALTERADO' TO SVA-IMP-SEGURADA-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_IMP_SEGURADA_BIL);

                /*" -2255- END-IF */
            }


            /*" -2256- IF WPREM-LIQUIDO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WPREM_LIQUIDO == "S")
            {

                /*" -2257- MOVE 'ALTERADO' TO SVA-PREM-LIQUIDO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_PREM_LIQUIDO_BIL);

                /*" -2258- END-IF */
            }


            /*" -2259- IF WIOF EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WIOF == "S")
            {

                /*" -2260- MOVE 'ALTERADO' TO SVA-IOF-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_IOF_BIL);

                /*" -2261- END-IF */
            }


            /*" -2262- IF WPREM-TOTAL EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_02.WPREM_TOTAL == "S")
            {

                /*" -2263- MOVE 'ALTERADO' TO SVA-PREM-TOTAL-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_PREM_TOTAL_BIL);

                /*" -2264- END-IF */
            }


            /*" -2265- IF WAGE-INDICADOR EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WAGE_INDICADOR == "S")
            {

                /*" -2266- MOVE 'ALTERADO' TO SVA-AGE-BANC-INDICADOR */
                _.Move("ALTERADO", REG_SVA0930B.SVA_AGE_BANC_INDICADOR);

                /*" -2267- END-IF */
            }


            /*" -2268- IF WOPE-INDICADOR EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WOPE_INDICADOR == "S")
            {

                /*" -2269- MOVE 'ALTERADO' TO SVA-OPE-BANC-INDICADOR */
                _.Move("ALTERADO", REG_SVA0930B.SVA_OPE_BANC_INDICADOR);

                /*" -2270- END-IF */
            }


            /*" -2271- IF WCONTA-INDICADOR EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WCONTA_INDICADOR == "S")
            {

                /*" -2272- MOVE 'ALTERADO' TO SVA-CTA-BANC-INDICADOR */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CTA_BANC_INDICADOR);

                /*" -2273- END-IF */
            }


            /*" -2274- IF WDIG-CONTA-IND EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WDIG_CONTA_IND == "S")
            {

                /*" -2275- MOVE 'ALTERADO' TO SVA-DIG-CTA-INDICADOR */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DIG_CTA_INDICADOR);

                /*" -2276- END-IF */
            }


            /*" -2277- IF WMATRICULA-IND EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WMATRICULA_IND == "S")
            {

                /*" -2278- MOVE 'MATRICULA INDICADOR' TO SVA-MATRICULA-INDICADOR */
                _.Move("MATRICULA INDICADOR", REG_SVA0930B.SVA_MATRICULA_INDICADOR);

                /*" -2279- END-IF */
            }


            /*" -2280- IF WDATA-QUITACAO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WDATA_QUITACAO == "S")
            {

                /*" -2281- MOVE 'DATA DE QUITACAO' TO SVA-DATA-QUIT-BIL */
                _.Move("DATA DE QUITACAO", REG_SVA0930B.SVA_DATA_QUIT_BIL);

                /*" -2282- END-IF */
            }


            /*" -2283- IF WVALOR-RECIBO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WVALOR_RECIBO == "S")
            {

                /*" -2284- MOVE 'ALTERADO' TO SVA-VALOR-RECIBO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_VALOR_RECIBO_BIL);

                /*" -2285- END-IF */
            }


            /*" -2286- IF WAGE-DEBITO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WAGE_DEBITO == "S")
            {

                /*" -2287- MOVE 'ALTERADO' TO SVA-AGE-DEBITO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_AGE_DEBITO_BIL);

                /*" -2288- END-IF */
            }


            /*" -2289- IF WOPE-DEBITO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WOPE_DEBITO == "S")
            {

                /*" -2290- MOVE 'ALTERADO' TO SVA-OPE-DEBITO-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_OPE_DEBITO_BIL);

                /*" -2291- END-IF */
            }


            /*" -2292- IF WCONTA-DEBITO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WCONTA_DEBITO == "S")
            {

                /*" -2293- MOVE 'ALTERADO' TO SVA-CTA-BANC-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CTA_BANC_BIL);

                /*" -2294- END-IF */
            }


            /*" -2295- IF WDIG-CONTA-DEB EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WDIG_CONTA_DEB == "S")
            {

                /*" -2296- MOVE 'ALTERADO' TO SVA-DIG-CTA-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DIG_CTA_BIL);

                /*" -2297- END-IF */
            }


            /*" -2298- IF WCARTAO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CB52A_03.WCARTAO == "S")
            {

                /*" -2299- MOVE 'ALTERADO' TO SVA-CARTAO-CRED-BIL */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CARTAO_CRED_BIL);

                /*" -2301- END-IF */
            }


            /*" -2301- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1101_FIM*/

        [StopWatch]
        /*" R1102-00-VERIFICA-CAMPOS-CB58A-SECTION */
        private void R1102_00_VERIFICA_CAMPOS_CB58A_SECTION()
        {
            /*" -2313- MOVE '1102' TO WNR-EXEC-SQL */
            _.Move("1102", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2322- PERFORM R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1 */

            R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1();

            /*" -2325- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2326- DISPLAY 'R1102 - ERRO NO SELECT SEGUROS.APOLICOB' */
                _.Display($"R1102 - ERRO NO SELECT SEGUROS.APOLICOB");

                /*" -2327- DISPLAY 'R1102 - SQLCODE  - ' SQLCODE */
                _.Display($"R1102 - SQLCODE  - {DB.SQLCODE}");

                /*" -2328- DISPLAY 'R1102 - NUM-APOL - ' RELATORI-NUM-APOLICE */
                _.Display($"R1102 - NUM-APOL - {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -2329- DISPLAY 'R1102 - NUM-ENDO - ' RELATORI-NUM-ENDOSSO */
                _.Display($"R1102 - NUM-ENDO - {RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO}");

                /*" -2330- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2332- END-IF */
            }


            /*" -2334- MOVE APOLICOB-PRM-TARIFARIO-VAR TO WS-PRM-TARIFARIO-VAR */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR, WORK_AREA.WS_PRM_TARIFARIO_VAR);

            /*" -2337- MOVE WS-PRM-TARIFARIO-VAR TO SVA-PRM-TARIFARIO-VAR */
            _.Move(WORK_AREA.WS_PRM_TARIFARIO_VAR, REG_SVA0930B.SVA_PRM_TARIFARIO_VAR);

            /*" -2337- . */

        }

        [StopWatch]
        /*" R1102-00-VERIFICA-CAMPOS-CB58A-DB-SELECT-1 */
        public void R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1()
        {
            /*" -2322- EXEC SQL SELECT NUM_APOLICE, PRM_TARIFARIO_VAR INTO :APOLICOB-NUM-APOLICE, :APOLICOB-PRM-TARIFARIO-VAR FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND NUM_ENDOSSO = :RELATORI-NUM-ENDOSSO WITH UR END-EXEC. */

            var r1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1 = new R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1.Execute(r1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_FIM*/

        [StopWatch]
        /*" R1103-00-VERIFICA-RESTITUICAO-SECTION */
        private void R1103_00_VERIFICA_RESTITUICAO_SECTION()
        {
            /*" -2351- MOVE '1103' TO WNR-EXEC-SQL */
            _.Move("1103", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2359- PERFORM R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1 */

            R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1();

            /*" -2362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2363- DISPLAY 'R1103 - ERRO NO SELECT DEVOLUCAO_VIDAZUL' */
                _.Display($"R1103 - ERRO NO SELECT DEVOLUCAO_VIDAZUL");

                /*" -2364- DISPLAY 'R1103 - SQLCODE - ' SQLCODE */
                _.Display($"R1103 - SQLCODE - {DB.SQLCODE}");

                /*" -2365- DISPLAY 'R1103 - COD-DEV - ' RELATORI-COD-OPERACAO */
                _.Display($"R1103 - COD-DEV - {RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO}");

                /*" -2366- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2368- END-IF */
            }


            /*" -2374- MOVE DEVOLVID-DESC-DEVOLUCAO-TEXT TO SVA-MOTIVO-CANCELAMENTO */
            _.Move(DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO.DEVOLVID_DESC_DEVOLUCAO_TEXT, REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

            /*" -2385- PERFORM R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2 */

            R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2();

            /*" -2388- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2389- DISPLAY 'R1103 - ERRO NO COUNT(*) RELATORIOS' */
                _.Display($"R1103 - ERRO NO COUNT(*) RELATORIOS");

                /*" -2390- DISPLAY 'R1103 - SQLCODE          - ' SQLCODE */
                _.Display($"R1103 - SQLCODE          - {DB.SQLCODE}");

                /*" -2391- DISPLAY 'R1103 - COD-USUARIO      - ' RELATORI-COD-USUARIO */
                _.Display($"R1103 - COD-USUARIO      - {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                /*" -2393- DISPLAY 'R1103 - DATA-SOLICITACAO - ' RELATORI-DATA-SOLICITACAO */
                _.Display($"R1103 - DATA-SOLICITACAO - {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

                /*" -2394- DISPLAY 'R1103 - IDE-SISTEMA      - ' RELATORI-IDE-SISTEMA */
                _.Display($"R1103 - IDE-SISTEMA      - {RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA}");

                /*" -2396- DISPLAY 'R1103 - NUM-CERTIFICADO  - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1103 - NUM-CERTIFICADO  - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2397- DISPLAY 'R1103 - NUM-ORDEM        - ' RELATORI-NUM-ORDEM */
                _.Display($"R1103 - NUM-ORDEM        - {RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM}");

                /*" -2398- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2400- END-IF */
            }


            /*" -2401- IF WS-COUNT EQUAL ZEROS */

            if (WORK_AREA.WS_COUNT == 00)
            {

                /*" -2402- MOVE 'NAO' TO SVA-HOUVE-RESTITUICAO */
                _.Move("NAO", REG_SVA0930B.SVA_HOUVE_RESTITUICAO);

                /*" -2403- MOVE ZEROS TO SVA-PRM-TARIFARIO-VAR */
                _.Move(0, REG_SVA0930B.SVA_PRM_TARIFARIO_VAR);

                /*" -2405- GO TO R1103-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_FIM*/ //GOTO
                return;
            }


            /*" -2406- IF WS-COUNT GREATER 1 */

            if (WORK_AREA.WS_COUNT > 1)
            {

                /*" -2407- MOVE 'SIM' TO SVA-HOUVE-RESTITUICAO */
                _.Move("SIM", REG_SVA0930B.SVA_HOUVE_RESTITUICAO);

                /*" -2408- MOVE ZEROS TO SVA-PRM-TARIFARIO-VAR */
                _.Move(0, REG_SVA0930B.SVA_PRM_TARIFARIO_VAR);

                /*" -2409- MOVE SPACES TO SVA-RETORNO-OPERACAO */
                _.Move("", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                /*" -2410- MOVE 'POSSUI + DE UMA REST.' TO SVA-MOTIVO-CANCELAMENTO */
                _.Move("POSSUI + DE UMA REST.", REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

                /*" -2412- GO TO R1103-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_FIM*/ //GOTO
                return;
            }


            /*" -2413- MOVE 'SIM' TO SVA-HOUVE-RESTITUICAO */
            _.Move("SIM", REG_SVA0930B.SVA_HOUVE_RESTITUICAO);

            /*" -2414- MOVE RELATORI-NUM-ORDEM TO WS-PRM-RESTITUIDO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM, WORK_AREA.WS_PRM_RESTITUIDO);

            /*" -2416- DIVIDE WS-PRM-RESTITUIDO BY 100 GIVING WS-PRM-RESTITUIDO */
            _.Divide(WORK_AREA.WS_PRM_RESTITUIDO, 100, WORK_AREA.WS_PRM_RESTITUIDO);

            /*" -2417- MOVE WS-PRM-RESTITUIDO TO WS-PRM-TARIFARIO-VAR */
            _.Move(WORK_AREA.WS_PRM_RESTITUIDO, WORK_AREA.WS_PRM_TARIFARIO_VAR);

            /*" -2422- MOVE WS-PRM-TARIFARIO-VAR TO SVA-PRM-TARIFARIO-VAR. */
            _.Move(WORK_AREA.WS_PRM_TARIFARIO_VAR, REG_SVA0930B.SVA_PRM_TARIFARIO_VAR);

            /*" -2430- PERFORM R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3 */

            R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3();

            /*" -2433- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2434- DISPLAY 'R1103 - ERRO SELECT COBER_HIST_VIDAZUL' */
                _.Display($"R1103 - ERRO SELECT COBER_HIST_VIDAZUL");

                /*" -2435- DISPLAY 'R1103 - SQLCODE  - ' SQLCODE */
                _.Display($"R1103 - SQLCODE  - {DB.SQLCODE}");

                /*" -2437- DISPLAY 'R1103 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1103 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2439- DISPLAY 'R1103 - NUM-PARC - ' RELATORI-NUM-PARCELA */
                _.Display($"R1103 - NUM-PARC - {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -2441- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2442- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2443- MOVE SPACES TO SVA-RETORNO-OPERACAO */
                _.Move("", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                /*" -2444- MOVE 'REST. SEM RETORNO' TO SVA-MOTIVO-CANCELAMENTO */
                _.Move("REST. SEM RETORNO", REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

                /*" -2446- GO TO R1103-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_FIM*/ //GOTO
                return;
            }


            /*" -2447- EVALUATE COBHISVI-SIT-REGISTRO */
            switch (COBHISVI_SIT_REGISTRO.Value.Trim())
            {

                /*" -2448- WHEN  ' ' */
                case " ":

                    /*" -2449- MOVE 'NAO PAGA' TO SVA-RETORNO-OPERACAO */
                    _.Move("NAO PAGA", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2450- WHEN  '0' */
                    break;
                case "0":

                    /*" -2451- MOVE 'PENDENTE' TO SVA-RETORNO-OPERACAO */
                    _.Move("PENDENTE", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2452- WHEN  '1' */
                    break;
                case "1":

                    /*" -2453- MOVE 'PAGA' TO SVA-RETORNO-OPERACAO */
                    _.Move("PAGA", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2454- WHEN  '2' */
                    break;
                case "2":

                    /*" -2455- MOVE 'CANCELADA' TO SVA-RETORNO-OPERACAO */
                    _.Move("CANCELADA", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2456- WHEN  '4' */
                    break;
                case "4":

                    /*" -2458- MOVE 'GERAR RELATORIO DE DEVOLUCAO' TO SVA-RETORNO-OPERACAO */
                    _.Move("GERAR RELATORIO DE DEVOLUCAO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2459- WHEN  '5' */
                    break;
                case "5":

                    /*" -2461- MOVE 'IMPRESSAO' TO SVA-RETORNO-OPERACAO */
                    _.Move("IMPRESSAO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2462- WHEN  '6' */
                    break;
                case "6":

                    /*" -2464- MOVE 'PENDENTE DE IDENTIFICACAO' TO SVA-RETORNO-OPERACAO */
                    _.Move("PENDENTE DE IDENTIFICACAO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2465- WHEN  '7' */
                    break;
                case "7":

                    /*" -2467- MOVE 'DEVOLVIDA' TO SVA-RETORNO-OPERACAO */
                    _.Move("DEVOLVIDA", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2468- WHEN  '8' */
                    break;
                case "8":

                    /*" -2470- MOVE 'SUBSTITUIDA' TO SVA-RETORNO-OPERACAO */
                    _.Move("SUBSTITUIDA", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2471- WHEN OTHER */
                    break;
                default:

                    /*" -2473- MOVE 'SIT RETORNO NAO PREVISTO' TO SVA-RETORNO-OPERACAO */
                    _.Move("SIT RETORNO NAO PREVISTO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -2473- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R1103-00-VERIFICA-RESTITUICAO-DB-SELECT-1 */
        public void R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1()
        {
            /*" -2359- EXEC SQL SELECT COD_DEVOLUCAO, DESC_DEVOLUCAO INTO :DEVOLVID-COD-DEVOLUCAO, :DEVOLVID-DESC-DEVOLUCAO FROM SEGUROS.DEVOLUCAO_VIDAZUL WHERE COD_DEVOLUCAO = :RELATORI-COD-OPERACAO WITH UR END-EXEC */

            var r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 = new R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1.Execute(r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DEVOLVID_COD_DEVOLUCAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_COD_DEVOLUCAO);
                _.Move(executed_1.DEVOLVID_DESC_DEVOLUCAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_FIM*/

        [StopWatch]
        /*" R1103-00-VERIFICA-RESTITUICAO-DB-SELECT-2 */
        public void R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2()
        {
            /*" -2385- EXEC SQL SELECT IFNULL(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'VA0469B' AND COD_USUARIO = :RELATORI-COD-USUARIO AND DATA_SOLICITACAO = :RELATORI-DATA-SOLICITACAO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA AND NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_ORDEM = :RELATORI-NUM-ORDEM WITH UR END-EXEC */

            var r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1 = new R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1()
            {
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
            };

            var executed_1 = R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1.Execute(r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WORK_AREA.WS_COUNT);
            }


        }

        [StopWatch]
        /*" R1104-00-VERIFICA-CONJUGUE-SECTION */
        private void R1104_00_VERIFICA_CONJUGUE_SECTION()
        {
            /*" -2486- MOVE '1104' TO WNR-EXEC-SQL */
            _.Move("1104", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2489- INITIALIZE DCLPROPOSTAS-VA DCLCONDICOES-TECNICAS */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
                , CONDITEC.DCLCONDICOES_TECNICAS
            );

            /*" -2497- PERFORM R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1 */

            R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1();

            /*" -2500- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2501- DISPLAY 'R1104 - ERRO NO SELECT PROPOSTAS_VA I' */
                _.Display($"R1104 - ERRO NO SELECT PROPOSTAS_VA I");

                /*" -2502- DISPLAY 'R1104 - SQLCODE  - ' SQLCODE */
                _.Display($"R1104 - SQLCODE  - {DB.SQLCODE}");

                /*" -2503- DISPLAY 'R1104 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1104 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2504- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2506- END-IF */
            }


            /*" -2513- PERFORM R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2 */

            R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2();

            /*" -2516- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2517- DISPLAY 'R1104 - ERRO NO SELECT CONDICOES_TECNICAS' */
                _.Display($"R1104 - ERRO NO SELECT CONDICOES_TECNICAS");

                /*" -2518- DISPLAY 'R1104 - SQLCODE - ' SQLCODE */
                _.Display($"R1104 - SQLCODE - {DB.SQLCODE}");

                /*" -2519- DISPLAY 'R1104 - NUM-APOL - ' PROPOVA-NUM-APOLICE */
                _.Display($"R1104 - NUM-APOL - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -2520- DISPLAY 'R1104 - COD-SUBG - ' PROPOVA-COD-SUBGRUPO */
                _.Display($"R1104 - COD-SUBG - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -2521- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2523- END-IF */
            }


            /*" -2524- IF CONDITEC-CARREGA-CONJUGE EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE == 00)
            {

                /*" -2525- MOVE 'SIM' TO SVA-EXCLUSAO */
                _.Move("SIM", REG_SVA0930B.SVA_EXCLUSAO);

                /*" -2526- ELSE */
            }
            else
            {


                /*" -2527- MOVE 'SIM' TO SVA-INCLUSAO */
                _.Move("SIM", REG_SVA0930B.SVA_INCLUSAO);

                /*" -2529- END-IF */
            }


            /*" -2531- MOVE RELATORI-NUM-CERTIFICADO TO PROPOVA-NRCERTIFANT */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRCERTIFANT);

            /*" -2538- PERFORM R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3 */

            R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3();

            /*" -2541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2542- DISPLAY 'R1104 - ERRO NO SELECT PROPOSTAS_VA II' */
                _.Display($"R1104 - ERRO NO SELECT PROPOSTAS_VA II");

                /*" -2543- DISPLAY 'R1104 - SQLCODE - ' SQLCODE */
                _.Display($"R1104 - SQLCODE - {DB.SQLCODE}");

                /*" -2544- DISPLAY 'R1104 - NRCERTI - ' PROPOVA-NRCERTIFANT */
                _.Display($"R1104 - NRCERTI - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRCERTIFANT}");

                /*" -2545- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2547- END-IF */
            }


            /*" -2549- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NOVO-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVA0930B.SVA_NOVO_CERTIFICADO);

            /*" -2549- . */

        }

        [StopWatch]
        /*" R1104-00-VERIFICA-CONJUGUE-DB-SELECT-1 */
        public void R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1()
        {
            /*" -2497- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC */

            var r1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1 = new R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1.Execute(r1104_00_VERIFICA_CONJUGUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
            }


        }

        [StopWatch]
        /*" R1103-00-VERIFICA-RESTITUICAO-DB-SELECT-3 */
        public void R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3()
        {
            /*" -2430- EXEC SQL SELECT SIT_REGISTRO INTO :COBHISVI-SIT-REGISTRO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1 = new R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1.Execute(r1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_SIT_REGISTRO, COBHISVI_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R1104-00-VERIFICA-CONJUGUE-DB-SELECT-2 */
        public void R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2()
        {
            /*" -2513- EXEC SQL SELECT CARREGA_CONJUGE INTO :CONDITEC-CARREGA-CONJUGE FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO WITH UR END-EXEC */

            var r1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1 = new R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1.Execute(r1104_00_VERIFICA_CONJUGUE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1104_FIM*/

        [StopWatch]
        /*" R1104-00-VERIFICA-CONJUGUE-DB-SELECT-3 */
        public void R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3()
        {
            /*" -2538- EXEC SQL SELECT NUM_CERTIFICADO INTO :PROPOVA-NUM-CERTIFICADO FROM SEGUROS.PROPOSTAS_VA WHERE NRCERTIFANT = :PROPOVA-NRCERTIFANT AND SIT_REGISTRO NOT IN ( '2' , '4' ) WITH UR END-EXEC */

            var r1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1 = new R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1()
            {
                PROPOVA_NRCERTIFANT = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRCERTIFANT.ToString(),
            };

            var executed_1 = R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1.Execute(r1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
            }


        }

        [StopWatch]
        /*" R1105-00-VERIFICA-CANCELAMENTO-SECTION */
        private void R1105_00_VERIFICA_CANCELAMENTO_SECTION()
        {
            /*" -2561- MOVE '1105' TO WNR-EXEC-SQL */
            _.Move("1105", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2566- INITIALIZE DCLPROPOSTAS-VA DCLSEGURADOS-VGAP DCLSEGURADOSVGAP-HIST */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
                , SEGURVGA.DCLSEGURADOS_VGAP
                , SEGURHIS.DCLSEGURADOSVGAP_HIST
            );

            /*" -2572- PERFORM R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1 */

            R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1();

            /*" -2575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2576- DISPLAY 'R1105 - ERRO NO SELECT SEGUROS.V0PROPOSTAVA' */
                _.Display($"R1105 - ERRO NO SELECT SEGUROS.V0PROPOSTAVA");

                /*" -2577- DISPLAY 'R1105 - SQLCODE  - ' SQLCODE */
                _.Display($"R1105 - SQLCODE  - {DB.SQLCODE}");

                /*" -2578- DISPLAY 'R1105 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1105 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2579- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2581- END-IF */
            }


            /*" -2582- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
            {

                /*" -2584- MOVE 'FALHA AO REABILITAR CERTIFICADO. VERIFICAR.' TO SVA-MOTIVO-CANCELAMENTO */
                _.Move("FALHA AO REABILITAR CERTIFICADO. VERIFICAR.", REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

                /*" -2585- GO TO R1105-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_FIM*/ //GOTO
                return;

                /*" -2587- END-IF */
            }


            /*" -2595- PERFORM R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2 */

            R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2();

            /*" -2598- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2599- DISPLAY 'R1105 - ERRO NO SELECT SEGURADOS_VGAP' */
                _.Display($"R1105 - ERRO NO SELECT SEGURADOS_VGAP");

                /*" -2600- DISPLAY 'R1105 - SQLCODE  - ' SQLCODE */
                _.Display($"R1105 - SQLCODE  - {DB.SQLCODE}");

                /*" -2602- DISPLAY 'R1105 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1105 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2604- MOVE 'FALHA AO REABILITAR CERTIFICADO. VERIFICAR.' TO SVA-MOTIVO-CANCELAMENTO */
                _.Move("FALHA AO REABILITAR CERTIFICADO. VERIFICAR.", REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

                /*" -2606- GO TO R1105-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_FIM*/ //GOTO
                return;

                /*" -2608- END-IF */
            }


            /*" -2620- PERFORM R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3 */

            R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3();

            /*" -2623- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2624- DISPLAY 'R1105 - ERRO NO SELECT SEGURADOSVGAP_HIST' */
                _.Display($"R1105 - ERRO NO SELECT SEGURADOSVGAP_HIST");

                /*" -2625- DISPLAY 'R1105 - SQLCODE  - ' SQLCODE */
                _.Display($"R1105 - SQLCODE  - {DB.SQLCODE}");

                /*" -2626- DISPLAY 'R1105 - NUM-APOL - ' SEGURVGA-NUM-APOLICE */
                _.Display($"R1105 - NUM-APOL - {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                /*" -2628- DISPLAY 'R1105 - NUM-ITEM - ' SEGURVGA-NUM-ITEM */
                _.Display($"R1105 - NUM-ITEM - {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -2630- MOVE 'FALHA AO REABILITAR CERTIFICADO. VERIFICAR.' TO SVA-MOTIVO-CANCELAMENTO */
                _.Move("FALHA AO REABILITAR CERTIFICADO. VERIFICAR.", REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

                /*" -2631- GO TO R1105-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_FIM*/ //GOTO
                return;

                /*" -2633- END-IF */
            }


            /*" -2635- SET WS-IDX-1 TO +1. */
            WS_IDX_1.Value = +1;

            /*" -2637- SEARCH TAB-CODIGO-OPERACAO AT END */
            void SearchAtEnd0()
            {

                /*" -2638- MOVE SPACES TO SVA-MOTIVO-CANCELAMENTO */
                _.Move("", REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

                /*" -2639- WHEN (TAB-COD-OPERACAO(WS-IDX-1) = SEGURHIS-COD-OPERACAO) */
            };

            var mustSearchAtEnd0 = true;
            for (; WS_IDX_1 < WORK_AREA.TAB_AUX.TAB_CODIGO_OPERACAO.Items.Count; WS_IDX_1.Value++)
            {

                if ((WORK_AREA.TAB_AUX.TAB_CODIGO_OPERACAO[WS_IDX_1].TAB_COD_OPERACAO == SEGURHIS.DCLSEGURADOSVGAP_HIST.SEGURHIS_COD_OPERACAO))
                {

                    mustSearchAtEnd0 = false;

                    /*" -2640- MOVE TAB-DES-OPERACAO(WS-IDX-1) TO SVA-MOTIVO-CANCELAMENTO */
                    _.Move(WORK_AREA.TAB_AUX.TAB_CODIGO_OPERACAO[WS_IDX_1].TAB_DES_OPERACAO, REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO);

                    /*" -2642- END-SEARCH */

                    /*" -2644- MOVE SEGURHIS-DATA-OPERACAO TO SVA-DATA-CANCELAMENTO */
                    _.Move(SEGURHIS.DCLSEGURADOSVGAP_HIST.SEGURHIS_DATA_OPERACAO, REG_SVA0930B.SVA_DATA_CANCELAMENTO);

                    /*" -2644- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }

        [StopWatch]
        /*" R1105-00-VERIFICA-CANCELAMENTO-DB-SELECT-1 */
        public void R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -2572- EXEC SQL SELECT SITUACAO INTO :PROPOVA-SIT-REGISTRO FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC */

            var r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1 = new R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1.Execute(r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_FIM*/

        [StopWatch]
        /*" R1105-00-VERIFICA-CANCELAMENTO-DB-SELECT-2 */
        public void R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2()
        {
            /*" -2595- EXEC SQL SELECT NUM_APOLICE , NUM_ITEM INTO :SEGURVGA-NUM-APOLICE , :SEGURVGA-NUM-ITEM FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC */

            var r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1 = new R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1.Execute(r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
            }


        }

        [StopWatch]
        /*" R1106-00-BUSCA-DADOS-VLN9A-SECTION */
        private void R1106_00_BUSCA_DADOS_VLN9A_SECTION()
        {
            /*" -2656- MOVE '1106' TO WNR-EXEC-SQL */
            _.Move("1106", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2660- INITIALIZE DCLOPCAO-PAG-VIDAZUL */
            _.Initialize(
                OPCPAGVI.DCLOPCAO_PAG_VIDAZUL
            );

            /*" -2680- PERFORM R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1 */

            R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1();

            /*" -2683-  EVALUATE SQLCODE  */

            /*" -2684-  WHEN ZEROS  */

            /*" -2684- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2685- CONTINUE */

                /*" -2686-  WHEN -811  */

                /*" -2686- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -2705- PERFORM R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2 */

                R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2();

                /*" -2708- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2709- DISPLAY 'R1106 - ERRO NO SELECT OPCAO_PAG_VDZUL II' */
                    _.Display($"R1106 - ERRO NO SELECT OPCAO_PAG_VDZUL II");

                    /*" -2710- DISPLAY 'R1106 - SQLCODE  - ' SQLCODE */
                    _.Display($"R1106 - SQLCODE  - {DB.SQLCODE}");

                    /*" -2711- DISPLAY 'R1106 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                    _.Display($"R1106 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -2712- DISPLAY 'R1106 - DATA-SOL - ' RELATORI-DATA-SOLICITACAO */
                    _.Display($"R1106 - DATA-SOL - {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

                    /*" -2713- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2715- END-IF */
                }


                /*" -2716-  WHEN OTHER  */

                /*" -2716- ELSE */
            }
            else
            {


                /*" -2717- DISPLAY 'R1106 - ERRO NO SELECT OPCAO_PAG_VDZUL I' */
                _.Display($"R1106 - ERRO NO SELECT OPCAO_PAG_VDZUL I");

                /*" -2718- DISPLAY 'R1106 - SQLCODE  - ' SQLCODE */
                _.Display($"R1106 - SQLCODE  - {DB.SQLCODE}");

                /*" -2719- DISPLAY 'R1106 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1106 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2720- DISPLAY 'R1106 - DATA-SOL - ' RELATORI-DATA-SOLICITACAO */
                _.Display($"R1106 - DATA-SOL - {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

                /*" -2721- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2723-  END-EVALUATE  */

                /*" -2723- END-IF */
            }


            /*" -2724- IF VIND-COD-AGE-DEB LESS ZEROS */

            if (VIND_COD_AGE_DEB < 00)
            {

                /*" -2725- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                /*" -2726- END-IF */
            }


            /*" -2727- IF VIND-OPE-CTA-DEB LESS ZEROS */

            if (VIND_OPE_CTA_DEB < 00)
            {

                /*" -2728- MOVE ZEROS TO OPCPAGVI-OPE-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                /*" -2729- END-IF */
            }


            /*" -2730- IF VIND-NUM-CTA-DEB LESS ZEROS */

            if (VIND_NUM_CTA_DEB < 00)
            {

                /*" -2731- MOVE ZEROS TO OPCPAGVI-NUM-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                /*" -2732- END-IF */
            }


            /*" -2733- IF VIND-DIG-CTA-DEB LESS ZEROS */

            if (VIND_DIG_CTA_DEB < 00)
            {

                /*" -2734- MOVE ZEROS TO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -2735- END-IF */
            }


            /*" -2736- IF VIND-NUM-CAR-CRE LESS ZEROS */

            if (VIND_NUM_CAR_CRE < 00)
            {

                /*" -2737- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -2746- END-IF */
            }


            /*" -2747- IF RELATORI-COD-RELATORIO EQUAL 'VLN9A01' OR 'SP007A01' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VLN9A01", "SP007A01"))
            {

                /*" -2748- EVALUATE OPCPAGVI-OPCAO-PAGAMENTO */
                switch (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.Value.Trim())
                {

                    /*" -2749- WHEN '1' */
                    case "1":

                        /*" -2750- MOVE 'DEBITO EM CONTA' TO SVA-OPCAO-PGTO-ATUAL */
                        _.Move("DEBITO EM CONTA", REG_SVA0930B.SVA_OPCAO_PGTO_ATUAL);

                        /*" -2751- WHEN '2' */
                        break;
                    case "2":

                        /*" -2752- MOVE 'DEBITO EM POUPANCA' TO SVA-OPCAO-PGTO-ATUAL */
                        _.Move("DEBITO EM POUPANCA", REG_SVA0930B.SVA_OPCAO_PGTO_ATUAL);

                        /*" -2753- WHEN '3' */
                        break;
                    case "3":

                        /*" -2754- MOVE 'BOLETO BANCARIO' TO SVA-OPCAO-PGTO-ATUAL */
                        _.Move("BOLETO BANCARIO", REG_SVA0930B.SVA_OPCAO_PGTO_ATUAL);

                        /*" -2755- WHEN '4' */
                        break;
                    case "4":

                        /*" -2756- MOVE 'AVERBACAO' TO SVA-OPCAO-PGTO-ATUAL */
                        _.Move("AVERBACAO", REG_SVA0930B.SVA_OPCAO_PGTO_ATUAL);

                        /*" -2757- WHEN '5' */
                        break;
                    case "5":

                        /*" -2758- MOVE 'CARTAO DE CREDITO' TO SVA-OPCAO-PGTO-ATUAL */
                        _.Move("CARTAO DE CREDITO", REG_SVA0930B.SVA_OPCAO_PGTO_ATUAL);

                        /*" -2761- END-EVALUATE */
                        break;
                }


                /*" -2770- PERFORM R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3 */

                R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3();

                /*" -2773- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2774- DISPLAY 'R1106 - ERRO NO SELECT OPCAO_PAG_VDZUL III' */
                    _.Display($"R1106 - ERRO NO SELECT OPCAO_PAG_VDZUL III");

                    /*" -2775- DISPLAY 'R1106 - SQLCODE  - ' SQLCODE */
                    _.Display($"R1106 - SQLCODE  - {DB.SQLCODE}");

                    /*" -2776- DISPLAY 'R1106 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                    _.Display($"R1106 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -2777- DISPLAY 'R1106 - DATA-SOL - ' RELATORI-DATA-SOLICITACAO */
                    _.Display($"R1106 - DATA-SOL - {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

                    /*" -2778- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2784- END-IF */
                }


                /*" -2785- EVALUATE OPCPAGVI-OPCAO-PAGAMENTO */
                switch (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.Value.Trim())
                {

                    /*" -2786- WHEN '1' */
                    case "1":

                        /*" -2787- MOVE 'DEBITO EM CONTA' TO SVA-OPCAO-PGTO-ANTERIOR */
                        _.Move("DEBITO EM CONTA", REG_SVA0930B.SVA_OPCAO_PGTO_ANTERIOR);

                        /*" -2788- WHEN '2' */
                        break;
                    case "2":

                        /*" -2789- MOVE 'DEBITO EM POUPANCA' TO SVA-OPCAO-PGTO-ANTERIOR */
                        _.Move("DEBITO EM POUPANCA", REG_SVA0930B.SVA_OPCAO_PGTO_ANTERIOR);

                        /*" -2790- WHEN '3' */
                        break;
                    case "3":

                        /*" -2791- MOVE 'BOLETO BANCARIO' TO SVA-OPCAO-PGTO-ANTERIOR */
                        _.Move("BOLETO BANCARIO", REG_SVA0930B.SVA_OPCAO_PGTO_ANTERIOR);

                        /*" -2792- WHEN '4' */
                        break;
                    case "4":

                        /*" -2793- MOVE 'AVERBACAO' TO SVA-OPCAO-PGTO-ANTERIOR */
                        _.Move("AVERBACAO", REG_SVA0930B.SVA_OPCAO_PGTO_ANTERIOR);

                        /*" -2794- WHEN '5' */
                        break;
                    case "5":

                        /*" -2795- MOVE 'CARTAO DE CREDITO' TO SVA-OPCAO-PGTO-ANTERIOR */
                        _.Move("CARTAO DE CREDITO", REG_SVA0930B.SVA_OPCAO_PGTO_ANTERIOR);

                        /*" -2796- END-EVALUATE */
                        break;
                }


                /*" -2800- END-IF */
            }


            /*" -2802- IF RELATORI-COD-RELATORIO EQUAL 'VLN9A02' OR 'SP007A02' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VLN9A02", "SP007A02"))
            {

                /*" -2804- MOVE RELATORI-NUM-APOL-LIDER TO WCAMPOS-VLN9A-02 */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, WORK_AREA.WCAMPOS_VLN9A_02);

                /*" -2805- IF W-CAMPO-AGE-DEB EQUAL 'S' */

                if (WORK_AREA.WCAMPOS_VLN9A_02.W_CAMPO_AGE_DEB == "S")
                {

                    /*" -2807- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO SVA-COD-AGENCIA-DEBITO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, REG_SVA0930B.SVA_COD_AGENCIA_DEBITO);

                    /*" -2808- END-IF */
                }


                /*" -2809- IF W-CAMPO-OPE-DEB EQUAL 'S' */

                if (WORK_AREA.WCAMPOS_VLN9A_02.W_CAMPO_OPE_DEB == "S")
                {

                    /*" -2811- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO SVA-OPE-CONTA-DEBITO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, REG_SVA0930B.SVA_OPE_CONTA_DEBITO);

                    /*" -2812- END-IF */
                }


                /*" -2813- IF W-CAMPO-CTA-DEB EQUAL 'S' */

                if (WORK_AREA.WCAMPOS_VLN9A_02.W_CAMPO_CTA_DEB == "S")
                {

                    /*" -2815- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO SVA-NUM-CONTA-DEBITO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, REG_SVA0930B.SVA_NUM_CONTA_DEBITO);

                    /*" -2816- END-IF */
                }


                /*" -2817- IF W-CAMPO-DIG-CTA EQUAL 'S' */

                if (WORK_AREA.WCAMPOS_VLN9A_02.W_CAMPO_DIG_CTA == "S")
                {

                    /*" -2819- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO SVA-DIG-CONTA-DEBITO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, REG_SVA0930B.SVA_DIG_CONTA_DEBITO);

                    /*" -2820- END-IF */
                }


                /*" -2821- IF W-CAMPO-CRT-CRE EQUAL 'S' */

                if (WORK_AREA.WCAMPOS_VLN9A_02.W_CAMPO_CRT_CRE == "S")
                {

                    /*" -2823- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO SVA-NUM-CARTAO-CREDITO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, REG_SVA0930B.SVA_NUM_CARTAO_CREDITO);

                    /*" -2824- END-IF */
                }


                /*" -2827- END-IF */
            }


            /*" -2828- IF RELATORI-COD-RELATORIO EQUAL 'VLN9A04' OR 'SP007A04' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.In("VLN9A04", "SP007A04"))
            {

                /*" -2829- MOVE OPCPAGVI-DIA-DEBITO TO SVA-DIA-DEBITO */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, REG_SVA0930B.SVA_DIA_DEBITO);

                /*" -2831- END-IF */
            }


            /*" -2831- . */

        }

        [StopWatch]
        /*" R1106-00-BUSCA-DADOS-VLN9A-DB-SELECT-1 */
        public void R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1()
        {
            /*" -2680- EXEC SQL SELECT OPCAO_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , NUM_CARTAO_CREDITO INTO :OPCPAGVI-OPCAO-PAGAMENTO , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-COD-AGE-DEB , :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPE-CTA-DEB , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUM-CTA-DEB , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIG-CTA-DEB , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUM-CAR-CRE FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :RELATORI-DATA-SOLICITACAO AND DATA_TERVIGENCIA >= :RELATORI-DATA-SOLICITACAO WITH UR END-EXEC */

            var r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1 = new R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1()
            {
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1.Execute(r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_COD_AGE_DEB, VIND_COD_AGE_DEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPE_CTA_DEB, VIND_OPE_CTA_DEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUM_CTA_DEB, VIND_NUM_CTA_DEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIG_CTA_DEB, VIND_DIG_CTA_DEB);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_NUM_CAR_CRE, VIND_NUM_CAR_CRE);
            }


        }

        [StopWatch]
        /*" R1105-00-VERIFICA-CANCELAMENTO-DB-SELECT-3 */
        public void R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3()
        {
            /*" -2620- EXEC SQL SELECT COD_OPERACAO , DATA_OPERACAO INTO :SEGURHIS-COD-OPERACAO , :SEGURHIS-DATA-OPERACAO FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND COD_OPERACAO BETWEEN 400 AND 499 ORDER BY DATA_OPERACAO DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1 = new R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1.Execute(r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURHIS_COD_OPERACAO, SEGURHIS.DCLSEGURADOSVGAP_HIST.SEGURHIS_COD_OPERACAO);
                _.Move(executed_1.SEGURHIS_DATA_OPERACAO, SEGURHIS.DCLSEGURADOSVGAP_HIST.SEGURHIS_DATA_OPERACAO);
            }


        }

        [StopWatch]
        /*" R1106-00-BUSCA-DADOS-VLN9A-DB-SELECT-2 */
        public void R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2()
        {
            /*" -2705- EXEC SQL SELECT OPCAO_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , NUM_CARTAO_CREDITO INTO :OPCPAGVI-OPCAO-PAGAMENTO , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-COD-AGE-DEB , :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPE-CTA-DEB , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUM-CTA-DEB , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIG-CTA-DEB , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUM-CAR-CRE FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC */

            var r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1 = new R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1.Execute(r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_COD_AGE_DEB, VIND_COD_AGE_DEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPE_CTA_DEB, VIND_OPE_CTA_DEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUM_CTA_DEB, VIND_NUM_CTA_DEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIG_CTA_DEB, VIND_DIG_CTA_DEB);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_NUM_CAR_CRE, VIND_NUM_CAR_CRE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1106_FIM*/

        [StopWatch]
        /*" R1106-00-BUSCA-DADOS-VLN9A-DB-SELECT-3 */
        public void R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3()
        {
            /*" -2770- EXEC SQL SELECT OPCAO_PAGAMENTO INTO :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND DATA_TERVIGENCIA <= :RELATORI-DATA-SOLICITACAO ORDER BY DATA_TERVIGENCIA DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1 = new R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1()
            {
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1.Execute(r1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }

        [StopWatch]
        /*" R1107-00-BUSCA-DADOS-CONJUGE-SECTION */
        private void R1107_00_BUSCA_DADOS_CONJUGE_SECTION()
        {
            /*" -2843- MOVE '1107' TO WNR-EXEC-SQL */
            _.Move("1107", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2848- MOVE SPACES TO SVA-NOME-ESPOSA SVA-PROF-ESPOSA SVA-DTNASC-ESPOSA SVA-DPS-ESPOSA */
            _.Move("", REG_SVA0930B.SVA_NOME_ESPOSA, REG_SVA0930B.SVA_PROF_ESPOSA, REG_SVA0930B.SVA_DTNASC_ESPOSA, REG_SVA0930B.SVA_DPS_ESPOSA);

            /*" -2850- MOVE RELATORI-NUM-APOL-LIDER TO WCAMPOS-VLNXA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, WORK_AREA.WCAMPOS_VLNXA);

            /*" -2851- IF WNOME-ESPOSA EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLNXA.WNOME_ESPOSA == "S")
            {

                /*" -2852- MOVE 'ALTERADO' TO SVA-NOME-ESPOSA */
                _.Move("ALTERADO", REG_SVA0930B.SVA_NOME_ESPOSA);

                /*" -2853- END-IF */
            }


            /*" -2854- IF WPROF-ESPOSA EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLNXA.WPROF_ESPOSA == "S")
            {

                /*" -2855- MOVE 'ALTERADO' TO SVA-PROF-ESPOSA */
                _.Move("ALTERADO", REG_SVA0930B.SVA_PROF_ESPOSA);

                /*" -2856- END-IF */
            }


            /*" -2857- IF WDTNASC-ESPOSA EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLNXA.WDTNASC_ESPOSA == "S")
            {

                /*" -2858- MOVE 'ALTERADO' TO SVA-DTNASC-ESPOSA */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DTNASC_ESPOSA);

                /*" -2859- END-IF */
            }


            /*" -2860- IF WDPS-ESPOSA EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLNXA.WDPS_ESPOSA == "S")
            {

                /*" -2861- MOVE 'ALTERADO' TO SVA-DPS-ESPOSA */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DPS_ESPOSA);

                /*" -2863- END-IF */
            }


            /*" -2863- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1107_FIM*/

        [StopWatch]
        /*" R1108-00-VERIFICA-CAPITAL-SECTION */
        private void R1108_00_VERIFICA_CAPITAL_SECTION()
        {
            /*" -2875- MOVE '1108' TO WNR-EXEC-SQL */
            _.Move("1108", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2877- INITIALIZE DCLMOVIMENTO-VGAP */
            _.Initialize(
                MOVIMVGA.DCLMOVIMENTO_VGAP
            );

            /*" -2889- PERFORM R1108_00_VERIFICA_CAPITAL_DB_SELECT_1 */

            R1108_00_VERIFICA_CAPITAL_DB_SELECT_1();

            /*" -2892- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2893- DISPLAY 'R1108 - ERRO NO SELECT MOVIMENTO_VGAP' */
                _.Display($"R1108 - ERRO NO SELECT MOVIMENTO_VGAP");

                /*" -2894- DISPLAY 'R1108 - SQLCODE  - ' SQLCODE */
                _.Display($"R1108 - SQLCODE  - {DB.SQLCODE}");

                /*" -2895- DISPLAY 'R1108 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1108 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2896- DISPLAY 'R1108 - COD-OPR  - ' RELATORI-COD-OPERACAO */
                _.Display($"R1108 - COD-OPR  - {RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO}");

                /*" -2897- DISPLAY 'R1108 - DATA-SOL - ' RELATORI-DATA-SOLICITACAO */
                _.Display($"R1108 - DATA-SOL - {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

                /*" -2898- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2900- END-IF */
            }


            /*" -2902- SET WS-IDX-1 TO +1. */
            WS_IDX_1.Value = +1;

            /*" -2904- SEARCH TAB-CODIGO-OPERACAO AT END */
            void SearchAtEnd1()
            {

                /*" -2905- MOVE SPACES TO SVA-OPERACAO */
                _.Move("", REG_SVA0930B.SVA_OPERACAO);

                /*" -2906- WHEN (TAB-COD-OPERACAO(WS-IDX-1) = MOVIMVGA-COD-OPERACAO) */
            };

            var mustSearchAtEnd1 = true;
            for (; WS_IDX_1 < WORK_AREA.TAB_AUX.TAB_CODIGO_OPERACAO.Items.Count; WS_IDX_1.Value++)
            {

                if ((WORK_AREA.TAB_AUX.TAB_CODIGO_OPERACAO[WS_IDX_1].TAB_COD_OPERACAO == MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO))
                {

                    mustSearchAtEnd1 = false;

                    /*" -2907- MOVE TAB-DES-OPERACAO(WS-IDX-1) TO SVA-OPERACAO */
                    _.Move(WORK_AREA.TAB_AUX.TAB_CODIGO_OPERACAO[WS_IDX_1].TAB_DES_OPERACAO, REG_SVA0930B.SVA_OPERACAO);

                    /*" -2909- END-SEARCH */

                    /*" -2910- MOVE MOVIMVGA-IMP-MORNATU-ANT TO WS-PRM-TARIFARIO-VAR */
                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT, WORK_AREA.WS_PRM_TARIFARIO_VAR);

                    /*" -2911- MOVE WS-PRM-TARIFARIO-VAR TO SVA-VLR-CAPITAL-ANT */
                    _.Move(WORK_AREA.WS_PRM_TARIFARIO_VAR, REG_SVA0930B.SVA_VLR_CAPITAL_ANT);

                    /*" -2912- MOVE MOVIMVGA-IMP-MORNATU-ATU TO WS-PRM-TARIFARIO-VAR */
                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, WORK_AREA.WS_PRM_TARIFARIO_VAR);

                    /*" -2914- MOVE WS-PRM-TARIFARIO-VAR TO SVA-VLR-CAPITAL-ATU */
                    _.Move(WORK_AREA.WS_PRM_TARIFARIO_VAR, REG_SVA0930B.SVA_VLR_CAPITAL_ATU);

                    /*" -2914- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd1)
                SearchAtEnd1();

        }

        [StopWatch]
        /*" R1108-00-VERIFICA-CAPITAL-DB-SELECT-1 */
        public void R1108_00_VERIFICA_CAPITAL_DB_SELECT_1()
        {
            /*" -2889- EXEC SQL SELECT IMP_MORNATU_ANT , IMP_MORNATU_ATU , COD_OPERACAO INTO :MOVIMVGA-IMP-MORNATU-ANT , :MOVIMVGA-IMP-MORNATU-ATU , :MOVIMVGA-COD-OPERACAO FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND COD_OPERACAO = :RELATORI-COD-OPERACAO AND DATA_OPERACAO = :RELATORI-DATA-SOLICITACAO WITH UR END-EXEC */

            var r1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1 = new R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1()
            {
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1.Execute(r1108_00_VERIFICA_CAPITAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_MORNATU_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);
                _.Move(executed_1.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1108_FIM*/

        [StopWatch]
        /*" R1109-00-RECUPERA-NOVO-CERT-SECTION */
        private void R1109_00_RECUPERA_NOVO_CERT_SECTION()
        {
            /*" -2926- MOVE '1109' TO WNR-EXEC-SQL */
            _.Move("1109", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2928- INITIALIZE DCLPROPOSTAS-VA */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
            );

            /*" -2936- PERFORM R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1 */

            R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1();

            /*" -2939- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2940- DISPLAY 'R1109 - ERRO NO SELECT PROPOSTAS_VA' */
                _.Display($"R1109 - ERRO NO SELECT PROPOSTAS_VA");

                /*" -2942- DISPLAY 'R1109 - NRCERTIFANT   = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1109 - NRCERTIFANT   = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2944- DISPLAY 'R1109 - DATA QUITACAO = ' RELATORI-DATA-SOLICITACAO */
                _.Display($"R1109 - DATA QUITACAO = {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}");

                /*" -2945- DISPLAY 'R1109 - SQLCODE - ' SQLCODE */
                _.Display($"R1109 - SQLCODE - {DB.SQLCODE}");

                /*" -2946- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2948- END-IF */
            }


            /*" -2951- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NOVO-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVA0930B.SVA_NOVO_CERTIFICADO);

            /*" -2951- . */

        }

        [StopWatch]
        /*" R1109-00-RECUPERA-NOVO-CERT-DB-SELECT-1 */
        public void R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1()
        {
            /*" -2936- EXEC SQL SELECT NUM_CERTIFICADO INTO :PROPOVA-NUM-CERTIFICADO FROM SEGUROS.PROPOSTAS_VA WHERE NRCERTIFANT = :RELATORI-NUM-CERTIFICADO AND SIT_REGISTRO NOT IN ( '2' , '4' ) AND DATA_QUITACAO = :RELATORI-DATA-SOLICITACAO WITH UR END-EXEC */

            var r1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1 = new R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1()
            {
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1.Execute(r1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1109_FIM*/

        [StopWatch]
        /*" R1110-00-RECUPERA-DADOS-REST-SECTION */
        private void R1110_00_RECUPERA_DADOS_REST_SECTION()
        {
            /*" -2963- MOVE '1110' TO WNR-EXEC-SQL */
            _.Move("1110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -2965- INITIALIZE DCLHIST-LANC-CTA */
            _.Initialize(
                HISLANCT.DCLHIST_LANC_CTA
            );

            /*" -2968- MOVE RELATORI-NUM-PARCELA TO SVA-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SVA0930B.SVA_NUM_PARCELA);

            /*" -2991- PERFORM R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1 */

            R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1();

            /*" -2994-  EVALUATE SQLCODE  */

            /*" -2995-  WHEN ZEROS  */

            /*" -2995- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2996- CONTINUE */

                /*" -2997-  WHEN +100  */

                /*" -2997- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2999- MOVE SPACES TO HISLANCT-DATA-VENCIMENTO */
                _.Move("", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);

                /*" -3000- MOVE RELATORI-NUM-ORDEM TO HISLANCT-PRM-TOTAL */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);

                /*" -3002- DIVIDE HISLANCT-PRM-TOTAL BY 100 GIVING HISLANCT-PRM-TOTAL */
                _.Divide(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL, 100, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);

                /*" -3003-  WHEN OTHER  */

                /*" -3003- ELSE */
            }
            else
            {


                /*" -3004- DISPLAY 'R1110 - ERRO NO SELECT HIST_LANC_CTA' */
                _.Display($"R1110 - ERRO NO SELECT HIST_LANC_CTA");

                /*" -3005- DISPLAY 'R1110 - NUM_CERTIF = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1110 - NUM_CERTIF = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -3006- DISPLAY 'R1110 - NUM_PARCEL = ' RELATORI-NUM-PARCELA */
                _.Display($"R1110 - NUM_PARCEL = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -3007- DISPLAY 'R1110 - SQLCODE    = ' SQLCODE */
                _.Display($"R1110 - SQLCODE    = {DB.SQLCODE}");

                /*" -3008- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3010-  END-EVALUATE  */

                /*" -3010- END-IF */
            }


            /*" -3012- MOVE HISLANCT-PRM-TOTAL TO WS-PRM-TARIFARIO-VAR */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL, WORK_AREA.WS_PRM_TARIFARIO_VAR);

            /*" -3015- MOVE WS-PRM-TARIFARIO-VAR TO SVA-PRM-TARIFARIO-VAR */
            _.Move(WORK_AREA.WS_PRM_TARIFARIO_VAR, REG_SVA0930B.SVA_PRM_TARIFARIO_VAR);

            /*" -3017- MOVE HISLANCT-DATA-VENCIMENTO TO SVA-DATA-PREVISTA */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO, REG_SVA0930B.SVA_DATA_PREVISTA);

            /*" -3019- MOVE HISLANCT-COD-AGENCIA-DEBITO TO SVA-COD-AGENCIA-DEBITO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO, REG_SVA0930B.SVA_COD_AGENCIA_DEBITO);

            /*" -3021- MOVE HISLANCT-OPE-CONTA-DEBITO TO SVA-OPE-CONTA-DEBITO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO, REG_SVA0930B.SVA_OPE_CONTA_DEBITO);

            /*" -3023- MOVE HISLANCT-NUM-CONTA-DEBITO TO SVA-NUM-CONTA-DEBITO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO, REG_SVA0930B.SVA_NUM_CONTA_DEBITO);

            /*" -3026- MOVE HISLANCT-DIG-CONTA-DEBITO TO SVA-DIG-CONTA-DEBITO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO, REG_SVA0930B.SVA_DIG_CONTA_DEBITO);

            /*" -3027- EVALUATE HISLANCT-SIT-REGISTRO */
            switch (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.Value.Trim())
            {

                /*" -3028- WHEN ' ' */
                case " ":

                    /*" -3029- MOVE 'NAO EFETUADO' TO SVA-RETORNO-OPERACAO */
                    _.Move("NAO EFETUADO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3030- WHEN '0' */
                    break;
                case "0":

                    /*" -3031- MOVE 'GERAR FITA' TO SVA-RETORNO-OPERACAO */
                    _.Move("GERAR FITA", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3032- WHEN '1' */
                    break;
                case "1":

                    /*" -3033- MOVE 'PAGO' TO SVA-RETORNO-OPERACAO */
                    _.Move("PAGO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3034- WHEN '2' */
                    break;
                case "2":

                    /*" -3035- MOVE 'CANCELADO' TO SVA-RETORNO-OPERACAO */
                    _.Move("CANCELADO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3036- WHEN '3' */
                    break;
                case "3":

                    /*" -3037- MOVE 'SEM RETORNO' TO SVA-RETORNO-OPERACAO */
                    _.Move("SEM RETORNO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3038- WHEN '4' */
                    break;
                case "4":

                    /*" -3039- MOVE 'EMITIDO COB. EM ATRASO' TO SVA-RETORNO-OPERACAO */
                    _.Move("EMITIDO COB. EM ATRASO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3040- WHEN '5' */
                    break;
                case "5":

                    /*" -3041- MOVE 'RELATORIO EMITIDO' TO SVA-RETORNO-OPERACAO */
                    _.Move("RELATORIO EMITIDO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3042- WHEN '6' */
                    break;
                case "6":

                    /*" -3043- MOVE 'RECOMANDOU' TO SVA-RETORNO-OPERACAO */
                    _.Move("RECOMANDOU", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3044- WHEN '7' */
                    break;
                case "7":

                    /*" -3045- MOVE 'ESTORNADO' TO SVA-RETORNO-OPERACAO */
                    _.Move("ESTORNADO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3046- WHEN '8' */
                    break;
                case "8":

                    /*" -3047- MOVE 'CANCELADO' TO SVA-RETORNO-OPERACAO */
                    _.Move("CANCELADO", REG_SVA0930B.SVA_RETORNO_OPERACAO);

                    /*" -3049- END-EVALUATE */
                    break;
            }


            /*" -3049- . */

        }

        [StopWatch]
        /*" R1110-00-RECUPERA-DADOS-REST-DB-SELECT-1 */
        public void R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1()
        {
            /*" -2991- EXEC SQL SELECT DATA_VENCIMENTO , PRM_TOTAL , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , SIT_REGISTRO INTO :HISLANCT-DATA-VENCIMENTO , :HISLANCT-PRM-TOTAL , :HISLANCT-COD-AGENCIA-DEBITO , :HISLANCT-OPE-CONTA-DEBITO , :HISLANCT-NUM-CONTA-DEBITO , :HISLANCT-DIG-CONTA-DEBITO , :HISLANCT-SIT-REGISTRO FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND TIPLANC IN ( '2' , '3' ) AND CODCONV = 6090 ORDER BY OCORR_HISTORICOCTA DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1 = new R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1.Execute(r1110_00_RECUPERA_DADOS_REST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(executed_1.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(executed_1.HISLANCT_COD_AGENCIA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO);
                _.Move(executed_1.HISLANCT_OPE_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO);
                _.Move(executed_1.HISLANCT_NUM_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO);
                _.Move(executed_1.HISLANCT_DIG_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO);
                _.Move(executed_1.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_FIM*/

        [StopWatch]
        /*" R1111-00-VERIFICA-CAMPOS-CTB2A-SECTION */
        private void R1111_00_VERIFICA_CAMPOS_CTB2A_SECTION()
        {
            /*" -3061- MOVE '1111' TO WNR-EXEC-SQL */
            _.Move("1111", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -3063- MOVE RELATORI-NUM-APOL-LIDER TO WCAMPOS-CTB2A */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, WORK_AREA.WCAMPOS_CTB2A);

            /*" -3064- IF W-NOME-RAZAO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CTB2A.W_NOME_RAZAO == "S")
            {

                /*" -3065- MOVE 'ALTERADO' TO SVA-NOME-CLIENTE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_NOME_CLIENTE);

                /*" -3066- END-IF */
            }


            /*" -3067- IF W-TIPO-PESSOA EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CTB2A.W_TIPO_PESSOA == "S")
            {

                /*" -3068- MOVE 'ALTERADO' TO SVA-TIPO-PESSOA-CLIENTE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_TIPO_PESSOA_CLIENTE);

                /*" -3069- END-IF */
            }


            /*" -3070- IF W-CGCCPF EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CTB2A.W_CGCCPF == "S")
            {

                /*" -3071- MOVE 'ALTERADO' TO SVA-CGCCPF-CLIENTE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_CGCCPF_CLIENTE);

                /*" -3072- END-IF */
            }


            /*" -3073- IF W-DATA-NASC EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CTB2A.W_DATA_NASC == "S")
            {

                /*" -3074- MOVE 'ALTERADO' TO SVA-DATA-NASCIMENTO */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DATA_NASCIMENTO);

                /*" -3075- END-IF */
            }


            /*" -3076- IF W-EMAIL EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_CTB2A.W_EMAIL == "S")
            {

                /*" -3077- MOVE 'ALTERADO' TO SVA-EMAIL-CLIENTE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_EMAIL_CLIENTE);

                /*" -3079- END-IF */
            }


            /*" -3079- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1111_FIM*/

        [StopWatch]
        /*" R1112-00-RECUPERA-PROPOSTAS-VA-SECTION */
        private void R1112_00_RECUPERA_PROPOSTAS_VA_SECTION()
        {
            /*" -3091- MOVE '1112' TO WNR-EXEC-SQL */
            _.Move("1112", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -3093- INITIALIZE DCLPROPOSTAS-VA */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
            );

            /*" -3101- PERFORM R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1 */

            R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1();

            /*" -3104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3105- DISPLAY 'R1112 - ERRO NO SELECT PROPOSTAS_VA' */
                _.Display($"R1112 - ERRO NO SELECT PROPOSTAS_VA");

                /*" -3106- DISPLAY 'R1112 - SQLCODE  - ' SQLCODE */
                _.Display($"R1112 - SQLCODE  - {DB.SQLCODE}");

                /*" -3107- DISPLAY 'R1112 - NRCERTIF - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1112 - NRCERTIF - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -3108- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3110- END-IF */
            }


            /*" -3110- . */

        }

        [StopWatch]
        /*" R1112-00-RECUPERA-PROPOSTAS-VA-DB-SELECT-1 */
        public void R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1()
        {
            /*" -3101- EXEC SQL SELECT PROFISSAO , DTPROXVEN INTO :PROPOVA-PROFISSAO , :PROPOVA-DTPROXVEN FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC */

            var r1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1 = new R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1.Execute(r1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_PROFISSAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO);
                _.Move(executed_1.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1112_FIM*/

        [StopWatch]
        /*" R1113-00-BUSCA-ENDERECO-TELE-SECTION */
        private void R1113_00_BUSCA_ENDERECO_TELE_SECTION()
        {
            /*" -3122- MOVE '1113' TO WNR-EXEC-SQL */
            _.Move("1113", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -3124- INITIALIZE DCLENDERECOS */
            _.Initialize(
                ENDERECO.DCLENDERECOS
            );

            /*" -3126- MOVE RELATORI-NUM-APOL-LIDER TO WCAMPOS-VLN9A-01 */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, WORK_AREA.WCAMPOS_VLN9A_01);

            /*" -3132- PERFORM R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1 */

            R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1();

            /*" -3135- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3136- DISPLAY 'R1113 - ERRO SELECT SEGUROS.V0PROPOSTAVA' */
                _.Display($"R1113 - ERRO SELECT SEGUROS.V0PROPOSTAVA");

                /*" -3137- DISPLAY 'R1113 - SQLCODE  - ' SQLCODE */
                _.Display($"R1113 - SQLCODE  - {DB.SQLCODE}");

                /*" -3139- DISPLAY 'R1113 - NUM-CERTIFICADO - ' RELATORI-NUM-CERTIFICADO */
                _.Display($"R1113 - NUM-CERTIFICADO - {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -3140- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3142- END-IF */
            }


            /*" -3144- INITIALIZE DCLENDERECOS */
            _.Initialize(
                ENDERECO.DCLENDERECOS
            );

            /*" -3163- PERFORM R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2 */

            R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2();

            /*" -3166- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3167- DISPLAY 'R1113 - ERRO SELECT SEGUROS.ENDERECOS' */
                _.Display($"R1113 - ERRO SELECT SEGUROS.ENDERECOS");

                /*" -3168- DISPLAY 'R1113 - SQLCODE  - ' SQLCODE */
                _.Display($"R1113 - SQLCODE  - {DB.SQLCODE}");

                /*" -3169- DISPLAY 'R1113 - COD-CLIENTE - ' WS-COD-CLIENTE */
                _.Display($"R1113 - COD-CLIENTE - {WORK_AREA.WS_COD_CLIENTE}");

                /*" -3170- DISPLAY 'R1113 - OCORR-ENDERECO - ' RELATORI-NUM-COPIAS */
                _.Display($"R1113 - OCORR-ENDERECO - {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS}");

                /*" -3171- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3173- END-IF */
            }


            /*" -3174- IF W-CAMPO-CEP EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLN9A_01.W_CAMPO_CEP == "S")
            {

                /*" -3175- MOVE ENDERECO-CEP TO SVA-CEP */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, REG_SVA0930B.SVA_CEP);

                /*" -3176- END-IF */
            }


            /*" -3177- IF W-CAMPO-UF EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLN9A_01.W_CAMPO_UF == "S")
            {

                /*" -3178- MOVE ENDERECO-SIGLA-UF TO SVA-UF */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SVA0930B.SVA_UF);

                /*" -3179- END-IF */
            }


            /*" -3180- IF W-CAMPO-ENDERECO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLN9A_01.W_CAMPO_ENDERECO == "S")
            {

                /*" -3181- MOVE ENDERECO-ENDERECO TO SVA-ENDERECO */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SVA0930B.SVA_ENDERECO);

                /*" -3182- END-IF */
            }


            /*" -3183- IF W-CAMPO-BAIRRO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLN9A_01.W_CAMPO_BAIRRO == "S")
            {

                /*" -3184- MOVE ENDERECO-BAIRRO TO SVA-BAIRRO */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SVA0930B.SVA_BAIRRO);

                /*" -3185- END-IF */
            }


            /*" -3186- IF W-CAMPO-CIDADE EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLN9A_01.W_CAMPO_CIDADE == "S")
            {

                /*" -3187- MOVE ENDERECO-CIDADE TO SVA-CIDADE */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SVA0930B.SVA_CIDADE);

                /*" -3188- END-IF */
            }


            /*" -3189- IF W-CAMPO-DDD EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLN9A_01.W_CAMPO_DDD == "S")
            {

                /*" -3190- MOVE ENDERECO-DDD TO SVA-DDD */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, REG_SVA0930B.SVA_DDD);

                /*" -3191- END-IF */
            }


            /*" -3192- IF W-CAMPO-TELEFONE EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VLN9A_01.W_CAMPO_TELEFONE == "S")
            {

                /*" -3193- MOVE ENDERECO-TELEFONE TO SVA-TELEFONE */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, REG_SVA0930B.SVA_TELEFONE);

                /*" -3195- END-IF */
            }


            /*" -3195- . */

        }

        [StopWatch]
        /*" R1113-00-BUSCA-ENDERECO-TELE-DB-SELECT-1 */
        public void R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1()
        {
            /*" -3132- EXEC SQL SELECT COD_CLIENTE INTO :WS-COD-CLIENTE FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1 = new R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1.Execute(r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_CLIENTE, WORK_AREA.WS_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1113_FIM*/

        [StopWatch]
        /*" R1113-00-BUSCA-ENDERECO-TELE-DB-SELECT-2 */
        public void R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2()
        {
            /*" -3163- EXEC SQL SELECT ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE INTO :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :WS-COD-CLIENTE AND OCORR_ENDERECO = :RELATORI-NUM-COPIAS WITH UR END-EXEC */

            var r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1 = new R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1()
            {
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                WS_COD_CLIENTE = WORK_AREA.WS_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1.Execute(r1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
            }


        }

        [StopWatch]
        /*" R1114-00-MOVER-CAMPOS-VGMAA-SECTION */
        private void R1114_00_MOVER_CAMPOS_VGMAA_SECTION()
        {
            /*" -3207- MOVE '1114' TO WNR-EXEC-SQL */
            _.Move("1114", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -3209- MOVE RELATORI-NUM-APOL-LIDER TO WCAMPOS-VGMAA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, WORK_AREA.WCAMPOS_VGMAA);

            /*" -3210- IF W-CAMPO-NOME EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VGMAA.W_CAMPO_NOME == "S")
            {

                /*" -3211- MOVE 'ALTERADO' TO SVA-NOME-CLIENTE-CERT */
                _.Move("ALTERADO", REG_SVA0930B.SVA_NOME_CLIENTE_CERT);

                /*" -3212- END-IF */
            }


            /*" -3213- IF W-CAMPO-DATA-NASC EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VGMAA.W_CAMPO_DATA_NASC == "S")
            {

                /*" -3214- MOVE 'ALTERADO' TO SVA-DATA-NASC-CLIENTE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_DATA_NASC_CLIENTE);

                /*" -3215- END-IF */
            }


            /*" -3216- IF W-CAMPO-SEXO EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VGMAA.W_CAMPO_SEXO == "S")
            {

                /*" -3217- MOVE 'ALTERADO' TO SVA-SEXO-CLIENTE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_SEXO_CLIENTE);

                /*" -3218- END-IF */
            }


            /*" -3219- IF W-CAMPO-EST-CIVIL EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VGMAA.W_CAMPO_EST_CIVIL == "S")
            {

                /*" -3220- MOVE 'ALTERADO' TO SVA-EST-CIVIL-CLIENTE */
                _.Move("ALTERADO", REG_SVA0930B.SVA_EST_CIVIL_CLIENTE);

                /*" -3221- END-IF */
            }


            /*" -3222- IF W-CAMPO-NOVO-CLI EQUAL 'S' */

            if (WORK_AREA.WCAMPOS_VGMAA.W_CAMPO_NOVO_CLI == "S")
            {

                /*" -3223- MOVE 'SIM' TO SVA-NOVO-CLIENTE */
                _.Move("SIM", REG_SVA0930B.SVA_NOVO_CLIENTE);

                /*" -3224- MOVE RELATORI-COD-PRODUTOR TO SVA-COD-CLIENTE-ANT */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR, REG_SVA0930B.SVA_COD_CLIENTE_ANT);

                /*" -3225- MOVE RELATORI-COD-EMPRESA TO SVA-COD-CLIENTE-ATUAL */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA, REG_SVA0930B.SVA_COD_CLIENTE_ATUAL);

                /*" -3226- ELSE */
            }
            else
            {


                /*" -3227- MOVE 'NAO' TO SVA-NOVO-CLIENTE */
                _.Move("NAO", REG_SVA0930B.SVA_NOVO_CLIENTE);

                /*" -3229- END-IF */
            }


            /*" -3229- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1114_FIM*/

        [StopWatch]
        /*" R0020-00-GERA-ARQ-SECTION */
        private void R0020_00_GERA_ARQ_SECTION()
        {
            /*" -3240- OPEN OUTPUT AVA0930B. */
            AVA0930B.Open(REG_AVA0930B);

            /*" -3241- WRITE REG-AVA0930B FROM LD00. */
            _.Move(WORK_AREA.LD00.GetMoveValues(), REG_AVA0930B);

            AVA0930B.Write(REG_AVA0930B.GetMoveValues().ToString());

            /*" -3243- WRITE REG-AVA0930B FROM LD00-1. */
            _.Move(WORK_AREA.LD00_1.GetMoveValues(), REG_AVA0930B);

            AVA0930B.Write(REG_AVA0930B.GetMoveValues().ToString());

            /*" -3245- PERFORM R2600-00-LE-SORT. */

            R2600_00_LE_SORT_SECTION();

            /*" -3249- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S" || WS_ERRO_FATAL == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -3249- CLOSE AVA0930B. */
            AVA0930B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -3260- MOVE SVA-APOLICE TO WS-APOLICE-ANT WHOST-APOLICE */
            _.Move(REG_SVA0930B.SVA_APOLICE, WORK_AREA.WS_APOLICE_ANT, WHOST_APOLICE);

            /*" -3262- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT WHOST-CODSUBES */
            _.Move(REG_SVA0930B.SVA_CODSUBES, WORK_AREA.WS_CODSUBES_ANT, WHOST_CODSUBES);

            /*" -3264- MOVE SVA-NRCERTIF TO WS-CERTIF-ANT WHOST-NRCERTIF */
            _.Move(REG_SVA0930B.SVA_NRCERTIF, WORK_AREA.WS_CERTIF_ANT, WHOST_NRCERTIF);

            /*" -3267- MOVE SVA-CGCCPF TO WS-CGCCPF-ANT WHOST-CGCCPF */
            _.Move(REG_SVA0930B.SVA_CGCCPF, WORK_AREA.WS_CGCCPF_ANT, WHOST_CGCCPF);

            /*" -3275- PERFORM R2100-00-PROCESSA-PRODUTO UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-NRCERTIF NOT EQUAL WS-CERTIF-ANT OR SVA-CGCCPF NOT EQUAL WS-CGCCPF-ANT OR WFIM-SORT EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' */

            while (!(REG_SVA0930B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA0930B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || REG_SVA0930B.SVA_NRCERTIF != WORK_AREA.WS_CERTIF_ANT || REG_SVA0930B.SVA_CGCCPF != WORK_AREA.WS_CGCCPF_ANT || WORK_AREA.WFIM_SORT == "S" || WS_ERRO_FATAL == "S"))
            {

                R2100_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -3276- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -3277- GO TO R2000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;

                /*" -3279- END-IF */
            }


            /*" -3279- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-PRODUTO-SECTION */
        private void R2100_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -3296- PERFORM R2400-00-PROCESSA-FONTE UNTIL SVA-APOLICE NOT EQUAL WS-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-NRCERTIF NOT EQUAL WS-CERTIF-ANT OR SVA-CGCCPF NOT EQUAL WS-CGCCPF-ANT OR WFIM-SORT EQUAL 'S' OR WS-ERRO-FATAL EQUAL 'S' . */

            while (!(REG_SVA0930B.SVA_APOLICE != WORK_AREA.WS_APOLICE_ANT || REG_SVA0930B.SVA_CODSUBES != WORK_AREA.WS_CODSUBES_ANT || REG_SVA0930B.SVA_NRCERTIF != WORK_AREA.WS_CERTIF_ANT || REG_SVA0930B.SVA_CGCCPF != WORK_AREA.WS_CGCCPF_ANT || WORK_AREA.WFIM_SORT == "S" || WS_ERRO_FATAL == "S"))
            {

                R2400_00_PROCESSA_FONTE_SECTION();
            }

            /*" -3297- IF WS-ERRO-FATAL EQUAL 'S' */

            if (WS_ERRO_FATAL == "S")
            {

                /*" -3297- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-PROCESSA-FONTE-SECTION */
        private void R2400_00_PROCESSA_FONTE_SECTION()
        {
            /*" -3309- MOVE '2400' TO WNR-EXEC-SQL */
            _.Move("2400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -3310- IF SVA-TIP-REL EQUAL 1 */

            if (REG_SVA0930B.SVA_TIP_REL == 1)
            {

                /*" -3311- MOVE SVA-APOLICE TO LD01-APOLICE */
                _.Move(REG_SVA0930B.SVA_APOLICE, WORK_AREA.LD01.LD01_APOLICE);

                /*" -3312- MOVE SVA-CODSUBES TO LD01-SUBGRUPO */
                _.Move(REG_SVA0930B.SVA_CODSUBES, WORK_AREA.LD01.LD01_SUBGRUPO);

                /*" -3313- MOVE SVA-NRCERTIF TO LD01-NRCERTIF */
                _.Move(REG_SVA0930B.SVA_NRCERTIF, WORK_AREA.LD01.LD01_NRCERTIF);

                /*" -3314- MOVE SVA-CODPRODU TO LD01-CODPRODU */
                _.Move(REG_SVA0930B.SVA_CODPRODU, WORK_AREA.LD01.LD01_CODPRODU);

                /*" -3315- MOVE SVA-NOMPRODU TO LD01-NOMPRODU */
                _.Move(REG_SVA0930B.SVA_NOMPRODU, WORK_AREA.LD01.LD01_NOMPRODU);

                /*" -3316- MOVE SVA-CGCCPF TO LD01-CGCCPF */
                _.Move(REG_SVA0930B.SVA_CGCCPF, WORK_AREA.LD01.LD01_CGCCPF);

                /*" -3317- MOVE SVA-NOME-RAZAO TO LD01-NM-SEGURADO */
                _.Move(REG_SVA0930B.SVA_NOME_RAZAO, WORK_AREA.LD01.LD01_NM_SEGURADO);

                /*" -3318- MOVE SVA-TIPO-ENDOSSO TO LD01-TIP-ENDOSSO */
                _.Move(REG_SVA0930B.SVA_TIPO_ENDOSSO, WORK_AREA.LD01.LD01_TIP_ENDOSSO);

                /*" -3319- MOVE SVA-DT-ENDOSSO (1:4) TO LD01-DT-ENDOSSO (7:4) */
                _.MoveAtPosition(REG_SVA0930B.SVA_DT_ENDOSSO.Substring(1, 4), WORK_AREA.LD01.LD01_DT_ENDOSSO, 7, 4);

                /*" -3320- MOVE '/' TO LD01-DT-ENDOSSO (3:1) */
                _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DT_ENDOSSO, 3, 1);

                /*" -3321- MOVE SVA-DT-ENDOSSO (6:2) TO LD01-DT-ENDOSSO (4:2) */
                _.MoveAtPosition(REG_SVA0930B.SVA_DT_ENDOSSO.Substring(6, 2), WORK_AREA.LD01.LD01_DT_ENDOSSO, 4, 2);

                /*" -3322- MOVE '/' TO LD01-DT-ENDOSSO (6:1) */
                _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DT_ENDOSSO, 6, 1);

                /*" -3323- MOVE SVA-DT-ENDOSSO (9:2) TO LD01-DT-ENDOSSO (1:2) */
                _.MoveAtPosition(REG_SVA0930B.SVA_DT_ENDOSSO.Substring(9, 2), WORK_AREA.LD01.LD01_DT_ENDOSSO, 1, 2);

                /*" -3324- MOVE SVA-CODUSU TO LD01-CODUSU */
                _.Move(REG_SVA0930B.SVA_CODUSU, WORK_AREA.LD01.LD01_CODUSU);

                /*" -3325- MOVE SVA-NOMUSU TO LD01-NOMUSU */
                _.Move(REG_SVA0930B.SVA_NOMUSU, WORK_AREA.LD01.LD01_NOMUSU);

                /*" -3326- MOVE SVA-TIPO-PESSOA TO LD01-TIP-PESSOA */
                _.Move(REG_SVA0930B.SVA_TIPO_PESSOA, WORK_AREA.LD01.LD01_TIP_PESSOA);

                /*" -3327- MOVE SVA-DADOS-ALTERADOS TO LD01-DAD-ALTERADOS */
                _.Move(REG_SVA0930B.SVA_DADOS_ALTERADOS, WORK_AREA.LD01.LD01_DAD_ALTERADOS);

                /*" -3328- MOVE SVA-PRM-TARIFARIO-VAR TO LD01-PRM-TARIFARIO-VAR */
                _.Move(REG_SVA0930B.SVA_PRM_TARIFARIO_VAR, WORK_AREA.LD01.LD01_PRM_TARIFARIO_VAR);

                /*" -3329- MOVE SVA-NUM-PARCELA TO LD01-NUM-PARCELA */
                _.Move(REG_SVA0930B.SVA_NUM_PARCELA, WORK_AREA.LD01.LD01_NUM_PARCELA);

                /*" -3330- MOVE SVA-DIA-DEBITO TO LD01-DIA-DEBITO */
                _.Move(REG_SVA0930B.SVA_DIA_DEBITO, WORK_AREA.LD01.LD01_DIA_DEBITO);

                /*" -3331- MOVE SVA-OPCAO-PGTO-ATUAL TO LD01-OPCAO-PGTO-ATUAL */
                _.Move(REG_SVA0930B.SVA_OPCAO_PGTO_ATUAL, WORK_AREA.LD01.LD01_OPCAO_PGTO_ATUAL);

                /*" -3332- MOVE SVA-OPCAO-PGTO-ANTERIOR TO LD01-OPCAO-PGTO-ANTERIOR */
                _.Move(REG_SVA0930B.SVA_OPCAO_PGTO_ANTERIOR, WORK_AREA.LD01.LD01_OPCAO_PGTO_ANTERIOR);

                /*" -3333- MOVE SVA-COD-AGENCIA-DEBITO TO LD01-COD-AGENCIA-DEBITO */
                _.Move(REG_SVA0930B.SVA_COD_AGENCIA_DEBITO, WORK_AREA.LD01.LD01_COD_AGENCIA_DEBITO);

                /*" -3334- MOVE SVA-OPE-CONTA-DEBITO TO LD01-OPE-CONTA-DEBITO */
                _.Move(REG_SVA0930B.SVA_OPE_CONTA_DEBITO, WORK_AREA.LD01.LD01_OPE_CONTA_DEBITO);

                /*" -3335- MOVE SVA-NUM-CONTA-DEBITO TO LD01-NUM-CONTA-DEBITO */
                _.Move(REG_SVA0930B.SVA_NUM_CONTA_DEBITO, WORK_AREA.LD01.LD01_NUM_CONTA_DEBITO);

                /*" -3336- MOVE SVA-DIG-CONTA-DEBITO TO LD01-DIG-CONTA-DEBITO */
                _.Move(REG_SVA0930B.SVA_DIG_CONTA_DEBITO, WORK_AREA.LD01.LD01_DIG_CONTA_DEBITO);

                /*" -3337- MOVE SVA-NUM-CARTAO-CREDITO TO LD01-NUM-CARTAO-CREDITO */
                _.Move(REG_SVA0930B.SVA_NUM_CARTAO_CREDITO, WORK_AREA.LD01.LD01_NUM_CARTAO_CREDITO);

                /*" -3338- MOVE SVA-ENDERECO TO LD01-ENDERECO */
                _.Move(REG_SVA0930B.SVA_ENDERECO, WORK_AREA.LD01.LD01_ENDERECO);

                /*" -3339- MOVE SVA-BAIRRO TO LD01-BAIRRO */
                _.Move(REG_SVA0930B.SVA_BAIRRO, WORK_AREA.LD01.LD01_BAIRRO);

                /*" -3340- MOVE SVA-CIDADE TO LD01-CIDADE */
                _.Move(REG_SVA0930B.SVA_CIDADE, WORK_AREA.LD01.LD01_CIDADE);

                /*" -3341- MOVE SVA-CEP TO LD01-CEP */
                _.Move(REG_SVA0930B.SVA_CEP, WORK_AREA.LD01.LD01_CEP);

                /*" -3342- MOVE SVA-UF TO LD01-UF */
                _.Move(REG_SVA0930B.SVA_UF, WORK_AREA.LD01.LD01_UF);

                /*" -3343- MOVE SVA-DDD TO LD01-DDD */
                _.Move(REG_SVA0930B.SVA_DDD, WORK_AREA.LD01.LD01_DDD);

                /*" -3344- MOVE SVA-TELEFONE TO LD01-TELEFONE */
                _.Move(REG_SVA0930B.SVA_TELEFONE, WORK_AREA.LD01.LD01_TELEFONE);

                /*" -3345- MOVE SVA-NOME-ESPOSA TO LD01-NOME-ESPOSA */
                _.Move(REG_SVA0930B.SVA_NOME_ESPOSA, WORK_AREA.LD01.LD01_NOME_ESPOSA);

                /*" -3346- MOVE SVA-PROF-ESPOSA TO LD01-PROFISSAO-ESPOSA */
                _.Move(REG_SVA0930B.SVA_PROF_ESPOSA, WORK_AREA.LD01.LD01_PROFISSAO_ESPOSA);

                /*" -3347- MOVE SVA-DTNASC-ESPOSA TO LD01-DTNASC-ESPOSA */
                _.Move(REG_SVA0930B.SVA_DTNASC_ESPOSA, WORK_AREA.LD01.LD01_DTNASC_ESPOSA);

                /*" -3348- MOVE SVA-DPS-ESPOSA TO LD01-DPS-ESPOSA */
                _.Move(REG_SVA0930B.SVA_DPS_ESPOSA, WORK_AREA.LD01.LD01_DPS_ESPOSA);

                /*" -3349- MOVE SVA-PROF-ATUAL TO LD01-PROFISSAO-ATUAL */
                _.Move(REG_SVA0930B.SVA_PROF_ATUAL, WORK_AREA.LD01.LD01_PROFISSAO_ATUAL);

                /*" -3350- MOVE SVA-AGE-VENDA-BIL TO LD01-AGE-VENDA-BIL */
                _.Move(REG_SVA0930B.SVA_AGE_VENDA_BIL, WORK_AREA.LD01.LD01_AGE_VENDA_BIL);

                /*" -3351- MOVE SVA-FILIAL-BIL TO LD01-FILIAL-BIL */
                _.Move(REG_SVA0930B.SVA_FILIAL_BIL, WORK_AREA.LD01.LD01_FILIAL_BIL);

                /*" -3352- MOVE SVA-NUM-BILHETE TO LD01-NUM-BILHETE */
                _.Move(REG_SVA0930B.SVA_NUM_BILHETE, WORK_AREA.LD01.LD01_NUM_BILHETE);

                /*" -3353- MOVE SVA-RAMO-BIL TO LD01-RAMO-BIL */
                _.Move(REG_SVA0930B.SVA_RAMO_BIL, WORK_AREA.LD01.LD01_RAMO_BIL);

                /*" -3354- MOVE SVA-PROPOSTA-BIL TO LD01-PROPOSTA-BIL */
                _.Move(REG_SVA0930B.SVA_PROPOSTA_BIL, WORK_AREA.LD01.LD01_PROPOSTA_BIL);

                /*" -3355- MOVE SVA-NUM-BILHETE-ANT TO LD01-NUM-BILHETE-ANT */
                _.Move(REG_SVA0930B.SVA_NUM_BILHETE_ANT, WORK_AREA.LD01.LD01_NUM_BILHETE_ANT);

                /*" -3356- MOVE SVA-COD-PRODUTO-BIL TO LD01-COD-PRODUTO-BIL */
                _.Move(REG_SVA0930B.SVA_COD_PRODUTO_BIL, WORK_AREA.LD01.LD01_COD_PRODUTO_BIL);

                /*" -3357- MOVE SVA-CONVENENTE-BIL TO LD01-CONVENENTE-BIL */
                _.Move(REG_SVA0930B.SVA_CONVENENTE_BIL, WORK_AREA.LD01.LD01_CONVENENTE_BIL);

                /*" -3358- MOVE SVA-NOME-SEGURADO-BIL TO LD01-NOME-SEGURADO-BIL */
                _.Move(REG_SVA0930B.SVA_NOME_SEGURADO_BIL, WORK_AREA.LD01.LD01_NOME_SEGURADO_BIL);

                /*" -3359- MOVE SVA-DATA-NASC-BIL TO LD01-DATA-NASC-BIL */
                _.Move(REG_SVA0930B.SVA_DATA_NASC_BIL, WORK_AREA.LD01.LD01_DATA_NASC_BIL);

                /*" -3360- MOVE SVA-CPF-BIL TO LD01-CPF-BIL */
                _.Move(REG_SVA0930B.SVA_CPF_BIL, WORK_AREA.LD01.LD01_CPF_BIL);

                /*" -3361- MOVE SVA-SEXO-BIL TO LD01-SEXO-BIL */
                _.Move(REG_SVA0930B.SVA_SEXO_BIL, WORK_AREA.LD01.LD01_SEXO_BIL);

                /*" -3362- MOVE SVA-ESTADO-CIVIL-BIL TO LD01-ESTADO-CIVIL-BIL */
                _.Move(REG_SVA0930B.SVA_ESTADO_CIVIL_BIL, WORK_AREA.LD01.LD01_ESTADO_CIVIL_BIL);

                /*" -3363- MOVE SVA-PROFISSAO-BIL TO LD01-PROFISSAO-BIL */
                _.Move(REG_SVA0930B.SVA_PROFISSAO_BIL, WORK_AREA.LD01.LD01_PROFISSAO_BIL);

                /*" -3364- MOVE SVA-RENDA-INDIV-BIL TO LD01-RENDA-INDIV-BIL */
                _.Move(REG_SVA0930B.SVA_RENDA_INDIV_BIL, WORK_AREA.LD01.LD01_RENDA_INDIV_BIL);

                /*" -3365- MOVE SVA-RENDA-FAMIL-BIL TO LD01-RENDA-FAMIL-BIL */
                _.Move(REG_SVA0930B.SVA_RENDA_FAMIL_BIL, WORK_AREA.LD01.LD01_RENDA_FAMIL_BIL);

                /*" -3366- MOVE SVA-ENDERECO-BIL TO LD01-ENDERECO-BIL */
                _.Move(REG_SVA0930B.SVA_ENDERECO_BIL, WORK_AREA.LD01.LD01_ENDERECO_BIL);

                /*" -3367- MOVE SVA-BAIRRO-BIL TO LD01-BAIRRO-BIL */
                _.Move(REG_SVA0930B.SVA_BAIRRO_BIL, WORK_AREA.LD01.LD01_BAIRRO_BIL);

                /*" -3368- MOVE SVA-CIDADE-BIL TO LD01-CIDADE-BIL */
                _.Move(REG_SVA0930B.SVA_CIDADE_BIL, WORK_AREA.LD01.LD01_CIDADE_BIL);

                /*" -3369- MOVE SVA-UF-BIL TO LD01-UF-BIL */
                _.Move(REG_SVA0930B.SVA_UF_BIL, WORK_AREA.LD01.LD01_UF_BIL);

                /*" -3370- MOVE SVA-CEP-BIL TO LD01-CEP-BIL */
                _.Move(REG_SVA0930B.SVA_CEP_BIL, WORK_AREA.LD01.LD01_CEP_BIL);

                /*" -3371- MOVE SVA-DDD-BIL TO LD01-DDD-BIL */
                _.Move(REG_SVA0930B.SVA_DDD_BIL, WORK_AREA.LD01.LD01_DDD_BIL);

                /*" -3372- MOVE SVA-TELEFONE-BIL TO LD01-TELEFONE-BIL */
                _.Move(REG_SVA0930B.SVA_TELEFONE_BIL, WORK_AREA.LD01.LD01_TELEFONE_BIL);

                /*" -3373- MOVE SVA-CELULAR-BIL TO LD01-CELULAR-BIL */
                _.Move(REG_SVA0930B.SVA_CELULAR_BIL, WORK_AREA.LD01.LD01_CELULAR_BIL);

                /*" -3374- MOVE SVA-OPCAO-COB-BIL TO LD01-OPCAO-COB-BIL */
                _.Move(REG_SVA0930B.SVA_OPCAO_COB_BIL, WORK_AREA.LD01.LD01_OPCAO_COB_BIL);

                /*" -3375- MOVE SVA-IMP-SEGURADA-BIL TO LD01-IMP-SEGURADA-BIL */
                _.Move(REG_SVA0930B.SVA_IMP_SEGURADA_BIL, WORK_AREA.LD01.LD01_IMP_SEGURADA_BIL);

                /*" -3376- MOVE SVA-PREM-LIQUIDO-BIL TO LD01-PREM-LIQUIDO-BIL */
                _.Move(REG_SVA0930B.SVA_PREM_LIQUIDO_BIL, WORK_AREA.LD01.LD01_PREM_LIQUIDO_BIL);

                /*" -3377- MOVE SVA-IOF-BIL TO LD01-IOF-BIL */
                _.Move(REG_SVA0930B.SVA_IOF_BIL, WORK_AREA.LD01.LD01_IOF_BIL);

                /*" -3378- MOVE SVA-PREM-TOTAL-BIL TO LD01-PREM-TOTAL-BIL */
                _.Move(REG_SVA0930B.SVA_PREM_TOTAL_BIL, WORK_AREA.LD01.LD01_PREM_TOTAL_BIL);

                /*" -3379- MOVE SVA-AGE-BANC-INDICADOR TO LD01-AGE-BANC-INDICADOR */
                _.Move(REG_SVA0930B.SVA_AGE_BANC_INDICADOR, WORK_AREA.LD01.LD01_AGE_BANC_INDICADOR);

                /*" -3380- MOVE SVA-OPE-BANC-INDICADOR TO LD01-OPE-BANC-INDICADOR */
                _.Move(REG_SVA0930B.SVA_OPE_BANC_INDICADOR, WORK_AREA.LD01.LD01_OPE_BANC_INDICADOR);

                /*" -3381- MOVE SVA-CTA-BANC-INDICADOR TO LD01-CTA-BANC-INDICADOR */
                _.Move(REG_SVA0930B.SVA_CTA_BANC_INDICADOR, WORK_AREA.LD01.LD01_CTA_BANC_INDICADOR);

                /*" -3382- MOVE SVA-DIG-CTA-INDICADOR TO LD01-DIG-CTA-INDICADOR */
                _.Move(REG_SVA0930B.SVA_DIG_CTA_INDICADOR, WORK_AREA.LD01.LD01_DIG_CTA_INDICADOR);

                /*" -3383- MOVE SVA-MATRICULA-INDICADOR TO LD01-MATRICULA-INDICADOR */
                _.Move(REG_SVA0930B.SVA_MATRICULA_INDICADOR, WORK_AREA.LD01.LD01_MATRICULA_INDICADOR);

                /*" -3384- MOVE SVA-DATA-QUIT-BIL TO LD01-DATA-QUIT-BIL */
                _.Move(REG_SVA0930B.SVA_DATA_QUIT_BIL, WORK_AREA.LD01.LD01_DATA_QUIT_BIL);

                /*" -3385- MOVE SVA-VALOR-RECIBO-BIL TO LD01-VALOR-RECIBO-BIL */
                _.Move(REG_SVA0930B.SVA_VALOR_RECIBO_BIL, WORK_AREA.LD01.LD01_VALOR_RECIBO_BIL);

                /*" -3386- MOVE SVA-AGE-DEBITO-BIL TO LD01-AGE-DEBITO-BIL */
                _.Move(REG_SVA0930B.SVA_AGE_DEBITO_BIL, WORK_AREA.LD01.LD01_AGE_DEBITO_BIL);

                /*" -3387- MOVE SVA-OPE-DEBITO-BIL TO LD01-OPE-DEBITO-BIL */
                _.Move(REG_SVA0930B.SVA_OPE_DEBITO_BIL, WORK_AREA.LD01.LD01_OPE_DEBITO_BIL);

                /*" -3388- MOVE SVA-CTA-BANC-BIL TO LD01-CTA-BANC-BIL */
                _.Move(REG_SVA0930B.SVA_CTA_BANC_BIL, WORK_AREA.LD01.LD01_CTA_BANC_BIL);

                /*" -3389- MOVE SVA-DIG-CTA-BIL TO LD01-DIG-CTA-BIL */
                _.Move(REG_SVA0930B.SVA_DIG_CTA_BIL, WORK_AREA.LD01.LD01_DIG_CTA_BIL);

                /*" -3390- MOVE SVA-CARTAO-CRED-BIL TO LD01-CARTAO-CRED-BIL */
                _.Move(REG_SVA0930B.SVA_CARTAO_CRED_BIL, WORK_AREA.LD01.LD01_CARTAO_CRED_BIL);

                /*" -3391- MOVE SVA-NOVO-CERTIFICADO TO LD01-NOVO-CERTIFICADO */
                _.Move(REG_SVA0930B.SVA_NOVO_CERTIFICADO, WORK_AREA.LD01.LD01_NOVO_CERTIFICADO);

                /*" -3392- MOVE SVA-INCLUSAO TO LD01-INCLUSAO */
                _.Move(REG_SVA0930B.SVA_INCLUSAO, WORK_AREA.LD01.LD01_INCLUSAO);

                /*" -3393- MOVE SVA-ALTERACAO TO LD01-ALTERACAO */
                _.Move(REG_SVA0930B.SVA_ALTERACAO, WORK_AREA.LD01.LD01_ALTERACAO);

                /*" -3394- MOVE SVA-EXCLUSAO TO LD01-EXCLUSAO */
                _.Move(REG_SVA0930B.SVA_EXCLUSAO, WORK_AREA.LD01.LD01_EXCLUSAO);

                /*" -3395- MOVE SVA-DATA-CANCELAMENTO TO LD01-DATA-CANCELAMENTO */
                _.Move(REG_SVA0930B.SVA_DATA_CANCELAMENTO, WORK_AREA.LD01.LD01_DATA_CANCELAMENTO);

                /*" -3396- MOVE SVA-MOTIVO-CANCELAMENTO TO LD01-MOTIVO-CANCELAMENTO */
                _.Move(REG_SVA0930B.SVA_MOTIVO_CANCELAMENTO, WORK_AREA.LD01.LD01_MOTIVO_CANCELAMENTO);

                /*" -3397- MOVE SVA-DATA-PREVISTA TO LD01-DATA-PREVISTA */
                _.Move(REG_SVA0930B.SVA_DATA_PREVISTA, WORK_AREA.LD01.LD01_DATA_PREVISTA);

                /*" -3398- MOVE SVA-RETORNO-OPERACAO TO LD01-RETORNO-OPERACAO */
                _.Move(REG_SVA0930B.SVA_RETORNO_OPERACAO, WORK_AREA.LD01.LD01_RETORNO_OPERACAO);

                /*" -3399- MOVE SVA-HOUVE-RESTITUICAO TO LD01-HOUVE-RESTITUICAO */
                _.Move(REG_SVA0930B.SVA_HOUVE_RESTITUICAO, WORK_AREA.LD01.LD01_HOUVE_RESTITUICAO);

                /*" -3400- MOVE SVA-OPERACAO TO LD01-OPERACAO */
                _.Move(REG_SVA0930B.SVA_OPERACAO, WORK_AREA.LD01.LD01_OPERACAO);

                /*" -3401- MOVE SVA-VLR-CAPITAL-ANT TO LD01-VLR-CAPITAL-ANT */
                _.Move(REG_SVA0930B.SVA_VLR_CAPITAL_ANT, WORK_AREA.LD01.LD01_VLR_CAPITAL_ANT);

                /*" -3402- MOVE SVA-VLR-CAPITAL-ATU TO LD01-VLR-CAPITAL-ATU */
                _.Move(REG_SVA0930B.SVA_VLR_CAPITAL_ATU, WORK_AREA.LD01.LD01_VLR_CAPITAL_ATU);

                /*" -3403- MOVE SVA-NOME-CLIENTE-CERT TO LD01-NOME-CLIENTE-CERT */
                _.Move(REG_SVA0930B.SVA_NOME_CLIENTE_CERT, WORK_AREA.LD01.LD01_NOME_CLIENTE_CERT);

                /*" -3404- MOVE SVA-DATA-NASC-CLIENTE TO LD01-DATA-NASC-CLIENTE */
                _.Move(REG_SVA0930B.SVA_DATA_NASC_CLIENTE, WORK_AREA.LD01.LD01_DATA_NASC_CLIENTE);

                /*" -3405- MOVE SVA-SEXO-CLIENTE TO LD01-SEXO-CLIENTE */
                _.Move(REG_SVA0930B.SVA_SEXO_CLIENTE, WORK_AREA.LD01.LD01_SEXO_CLIENTE);

                /*" -3406- MOVE SVA-EST-CIVIL-CLIENTE TO LD01-EST-CIVIL-CLIENTE */
                _.Move(REG_SVA0930B.SVA_EST_CIVIL_CLIENTE, WORK_AREA.LD01.LD01_EST_CIVIL_CLIENTE);

                /*" -3407- MOVE SVA-NOVO-CLIENTE TO LD01-NOVO-CLIENTE */
                _.Move(REG_SVA0930B.SVA_NOVO_CLIENTE, WORK_AREA.LD01.LD01_NOVO_CLIENTE);

                /*" -3408- MOVE SVA-COD-CLIENTE-ANT TO LD01-COD-CLIENTE-ANT */
                _.Move(REG_SVA0930B.SVA_COD_CLIENTE_ANT, WORK_AREA.LD01.LD01_COD_CLIENTE_ANT);

                /*" -3409- MOVE SVA-COD-CLIENTE-ATUAL TO LD01-COD-CLIENTE-ATUAL */
                _.Move(REG_SVA0930B.SVA_COD_CLIENTE_ATUAL, WORK_AREA.LD01.LD01_COD_CLIENTE_ATUAL);

                /*" -3410- MOVE SVA-DATA-OPER-REMISSAO TO LD01-DATA-OPER-REMISSAO */
                _.Move(REG_SVA0930B.SVA_DATA_OPER_REMISSAO, WORK_AREA.LD01.LD01_DATA_OPER_REMISSAO);

                /*" -3412- MOVE SVA-DATA-RET-COBRANCA TO LD01-DATA-RET-COBRANCA */
                _.Move(REG_SVA0930B.SVA_DATA_RET_COBRANCA, WORK_AREA.LD01.LD01_DATA_RET_COBRANCA);

                /*" -3413- WRITE REG-AVA0930B FROM LD01 */
                _.Move(WORK_AREA.LD01.GetMoveValues(), REG_AVA0930B);

                AVA0930B.Write(REG_AVA0930B.GetMoveValues().ToString());

                /*" -3414- ADD 1 TO AC-GRAVADOS */
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -3415- ELSE */
            }
            else
            {


                /*" -3416- IF WS-TIPREL-ANT NOT EQUAL SVA-TIP-REL */

                if (WORK_AREA.WS_TIPREL_ANT != REG_SVA0930B.SVA_TIP_REL)
                {

                    /*" -3417- WRITE REG-AVA0930B FROM LD00-2 */
                    _.Move(WORK_AREA.LD00_2.GetMoveValues(), REG_AVA0930B);

                    AVA0930B.Write(REG_AVA0930B.GetMoveValues().ToString());

                    /*" -3418- WRITE REG-AVA0930B FROM LD00-3 */
                    _.Move(WORK_AREA.LD00_3.GetMoveValues(), REG_AVA0930B);

                    AVA0930B.Write(REG_AVA0930B.GetMoveValues().ToString());

                    /*" -3420- END-IF */
                }


                /*" -3421- MOVE SVA-TIP-REL TO WS-TIPREL-ANT */
                _.Move(REG_SVA0930B.SVA_TIP_REL, WORK_AREA.WS_TIPREL_ANT);

                /*" -3422- MOVE SVA-CGCCPF TO LD02-CGCCPF */
                _.Move(REG_SVA0930B.SVA_CGCCPF, WORK_AREA.LD02.LD02_CGCCPF);

                /*" -3423- MOVE SVA-NOME-RAZAO TO LD02-NM-SEGURADO */
                _.Move(REG_SVA0930B.SVA_NOME_RAZAO, WORK_AREA.LD02.LD02_NM_SEGURADO);

                /*" -3424- MOVE SVA-DT-NASC TO LD02-DT-NASCIMENTO */
                _.Move(REG_SVA0930B.SVA_DT_NASC, WORK_AREA.LD02.LD02_DT_NASCIMENTO);

                /*" -3425- MOVE SVA-TIPO-ENDOSSO TO LD02-TIP-ENDOSSO */
                _.Move(REG_SVA0930B.SVA_TIPO_ENDOSSO, WORK_AREA.LD02.LD02_TIP_ENDOSSO);

                /*" -3426- MOVE SVA-DT-ENDOSSO (1:4) TO LD02-DT-ENDOSSO (7:4) */
                _.MoveAtPosition(REG_SVA0930B.SVA_DT_ENDOSSO.Substring(1, 4), WORK_AREA.LD02.LD02_DT_ENDOSSO, 7, 4);

                /*" -3427- MOVE '/' TO LD02-DT-ENDOSSO (3:1) */
                _.MoveAtPosition("/", WORK_AREA.LD02.LD02_DT_ENDOSSO, 3, 1);

                /*" -3428- MOVE SVA-DT-ENDOSSO (6:2) TO LD02-DT-ENDOSSO (4:2) */
                _.MoveAtPosition(REG_SVA0930B.SVA_DT_ENDOSSO.Substring(6, 2), WORK_AREA.LD02.LD02_DT_ENDOSSO, 4, 2);

                /*" -3429- MOVE '/' TO LD02-DT-ENDOSSO (6:1) */
                _.MoveAtPosition("/", WORK_AREA.LD02.LD02_DT_ENDOSSO, 6, 1);

                /*" -3430- MOVE SVA-DT-ENDOSSO (9:2) TO LD02-DT-ENDOSSO (1:2) */
                _.MoveAtPosition(REG_SVA0930B.SVA_DT_ENDOSSO.Substring(9, 2), WORK_AREA.LD02.LD02_DT_ENDOSSO, 1, 2);

                /*" -3431- MOVE SVA-CODUSU TO LD02-CODUSU */
                _.Move(REG_SVA0930B.SVA_CODUSU, WORK_AREA.LD02.LD02_CODUSU);

                /*" -3432- MOVE SVA-NOMUSU TO LD02-NOMUSU */
                _.Move(REG_SVA0930B.SVA_NOMUSU, WORK_AREA.LD02.LD02_NOMUSU);

                /*" -3434- MOVE SVA-TIPO-PESSOA TO LD02-TIP-PESSOA */
                _.Move(REG_SVA0930B.SVA_TIPO_PESSOA, WORK_AREA.LD02.LD02_TIP_PESSOA);

                /*" -3435- MOVE SVA-NOME-CLIENTE TO LD02-NOME-CLIENTE */
                _.Move(REG_SVA0930B.SVA_NOME_CLIENTE, WORK_AREA.LD02.LD02_NOME_CLIENTE);

                /*" -3436- MOVE SVA-TIPO-PESSOA-CLIENTE TO LD02-TIPO-PESSOA-CLIENTE */
                _.Move(REG_SVA0930B.SVA_TIPO_PESSOA_CLIENTE, WORK_AREA.LD02.LD02_TIPO_PESSOA_CLIENTE);

                /*" -3437- MOVE SVA-CGCCPF-CLIENTE TO LD02-CGCCPF-CLIENTE */
                _.Move(REG_SVA0930B.SVA_CGCCPF_CLIENTE, WORK_AREA.LD02.LD02_CGCCPF_CLIENTE);

                /*" -3438- MOVE SVA-DATA-NASCIMENTO TO LD02-DATA-NASCIMENTO */
                _.Move(REG_SVA0930B.SVA_DATA_NASCIMENTO, WORK_AREA.LD02.LD02_DATA_NASCIMENTO);

                /*" -3440- MOVE SVA-EMAIL-CLIENTE TO LD02-EMAIL-CLIENTE */
                _.Move(REG_SVA0930B.SVA_EMAIL_CLIENTE, WORK_AREA.LD02.LD02_EMAIL_CLIENTE);

                /*" -3441- WRITE REG-AVA0930B FROM LD02 */
                _.Move(WORK_AREA.LD02.GetMoveValues(), REG_AVA0930B);

                AVA0930B.Write(REG_AVA0930B.GetMoveValues().ToString());

                /*" -3442- ADD 1 TO AC-GRAVADOS */
                WORK_AREA.AC_GRAVADOS.Value = WORK_AREA.AC_GRAVADOS + 1;

                /*" -3442- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2500_90_LER */

            R2500_90_LER();

        }

        [StopWatch]
        /*" R2500-90-LER */
        private void R2500_90_LER(bool isPerform = false)
        {
            /*" -3446- PERFORM R2600-00-LE-SORT. */

            R2600_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-LE-SORT-SECTION */
        private void R2600_00_LE_SORT_SECTION()
        {
            /*" -3457- RETURN SVA0930B AT END */
            try
            {
                SVA0930B.Return(REG_SVA0930B, () =>
                {

                    /*" -3459- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -3460- IF WFIM-SORT NOT EQUAL 'S' */

            if (WORK_AREA.WFIM_SORT != "S")
            {

                /*" -3461- ADD 1 TO AC-LIDOS-SORT */
                WORK_AREA.AC_LIDOS_SORT.Value = WORK_AREA.AC_LIDOS_SORT + 1;

                /*" -3461- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -3474- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3475- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3476- DISPLAY '*   VA0930B - GERA RELATORIO ENDOSSOS      *' */
            _.Display($"*   VA0930B - GERA RELATORIO ENDOSSOS      *");

            /*" -3477- DISPLAY '*   -------   -------------- --------      *' */
            _.Display($"*   -------   -------------- --------      *");

            /*" -3478- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3479- DISPLAY '*       NAO HA REGISTRO DE ENDOSSO PARA    *' */
            _.Display($"*       NAO HA REGISTRO DE ENDOSSO PARA    *");

            /*" -3480- DISPLAY '*             A DATA SOLICITADA.           *' */
            _.Display($"*             A DATA SOLICITADA.           *");

            /*" -3481- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3481- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MONTAR-CONTROLES-SECTION */
        private void R9900_00_MONTAR_CONTROLES_SECTION()
        {
            /*" -3494- MOVE '9900' TO WNR-EXEC-SQL */
            _.Move("9900", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -3496- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -3498- DISPLAY 'I RESUMO DE CONTADORES DE ENDOSSO 'S                I' */

            $"I RESUMO DE CONTADORES DE ENDOSSO {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_FAIXA}I"
            .Display();

            /*" -3500- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -3502- DISPLAY 'I                 TOTAIS DE CONTROLE EM ' LD00-DATAINI '                I' */

            $"I                 TOTAIS DE CONTROLE EM {WORK_AREA.LD00.LD00_DATAINI}                I"
            .Display();

            /*" -3504- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -3506- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3508- DISPLAY 'I NOME DO ENDOSSO I '  QUANTIDADE     I' */

            $"I NOME DO ENDOSSO I QUANTIDADEI"
            .Display();

            /*" -3510- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3512- DISPLAY 'I 2a VIA DE BILHETE I '    ' AC-SEGUNDA-VIA-BIL '     I' */

            $"I 2a VIA DE BILHETE I  AC-SEGUNDA-VIA-BIL I"
            .Display();

            /*" -3514- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3516- DISPLAY 'I CANCELAMENTO SEM RESTITUICAO/DEVOLUCAO I '    ' AC-CANC-SEM-REST '     I' */

            $"I CANCELAMENTO SEM RESTITUICAO/DEVOLUCAO I  AC-CANC-SEM-REST I"
            .Display();

            /*" -3518- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3520- DISPLAY 'I SUSPENDER RENOVACAO I '    ' AC-SUSP-RENOVACAO '     I' */

            $"I SUSPENDER RENOVACAO I  AC-SUSP-RENOVACAO I"
            .Display();

            /*" -3522- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3524- DISPLAY 'I ALTERACAO DADOS DE BILHETES I '    ' AC-DADOS-BILHETE '     I' */

            $"I ALTERACAO DADOS DE BILHETES I  AC-DADOS-BILHETE I"
            .Display();

            /*" -3526- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3528- DISPLAY 'I CANCELAMENTO COM RESTITUICAO PRO-RATA I '    ' AC-REST-PRO-RATA '     I' */

            $"I CANCELAMENTO COM RESTITUICAO PRO-RATA I  AC-REST-PRO-RATA I"
            .Display();

            /*" -3530- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3532- DISPLAY 'I CANCELAMENTO BILHETE EM CRITICA I '    ' AC-CANC-BIL-CRITICA '     I' */

            $"I CANCELAMENTO BILHETE EM CRITICA I  AC-CANC-BIL-CRITICA I"
            .Display();

            /*" -3534- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3536- DISPLAY 'I 2a VIA DE CERTIFICADO I '    ' AC-SEG-VIA-CERT '     I' */

            $"I 2a VIA DE CERTIFICADO I  AC-SEG-VIA-CERT I"
            .Display();

            /*" -3538- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3540- DISPLAY 'I 2a VIA DE BOLETO I '    ' AC-SEG-VIA-BOLETO '     I' */

            $"I 2a VIA DE BOLETO I  AC-SEG-VIA-BOLETO I"
            .Display();

            /*" -3542- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3544- DISPLAY 'I RECOMANDO DE DEBITO I '    ' AC-REC-DEBITO '     I' */

            $"I RECOMANDO DE DEBITO I  AC-REC-DEBITO I"
            .Display();

            /*" -3546- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3548- DISPLAY 'I CANCELAR PARCELA I '    ' AC-CANC-PARCELA '     I' */

            $"I CANCELAR PARCELA I  AC-CANC-PARCELA I"
            .Display();

            /*" -3550- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3552- DISPLAY 'I INCLUIR PARCELA I '    ' AC-INCLUIR-PARC '     I' */

            $"I INCLUIR PARCELA I  AC-INCLUIR-PARC I"
            .Display();

            /*" -3554- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3556- DISPLAY 'I REMISSAO DE PREMIO I '    ' AC-REMISSAO-PRE '     I' */

            $"I REMISSAO DE PREMIO I  AC-REMISSAO-PRE I"
            .Display();

            /*" -3558- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3560- DISPLAY 'I BENEFICIARIOS I '    ' AC-BENEFICIARIOS '     I' */

            $"I BENEFICIARIOS I  AC-BENEFICIARIOS I"
            .Display();

            /*" -3562- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3564- DISPLAY 'I INCLUSAO/EXCLUSAO DE CONJUGE I '    ' AC-INC-EXC-CONJ '     I' */

            $"I INCLUSAO/EXCLUSAO DE CONJUGE I  AC-INC-EXC-CONJ I"
            .Display();

            /*" -3566- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3568- DISPLAY 'I ALTERACAO DE CAPITAL I '    ' AC-ALTER-CAPITAL '     I' */

            $"I ALTERACAO DE CAPITAL I  AC-ALTER-CAPITAL I"
            .Display();

            /*" -3570- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3572- DISPLAY 'I ALTERACAO DE PERIODICIDADE DE PAGAMENTO I '    ' AC-ALTER-PER-PGTO '     I' */

            $"I ALTERACAO DE PERIODICIDADE DE PAGAMENTO I  AC-ALTER-PER-PGTO I"
            .Display();

            /*" -3574- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3576- DISPLAY 'I RESTITUICAO/DEVOLUCAO DE PREMIOS I '    ' AC-REST-PREMIO '     I' */

            $"I RESTITUICAO/DEVOLUCAO DE PREMIOS I  AC-REST-PREMIO I"
            .Display();

            /*" -3578- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3580- DISPLAY 'I CANCELAMENTO I '    ' AC-CANC-REST '     I' */

            $"I CANCELAMENTO I  AC-CANC-REST I"
            .Display();

            /*" -3582- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3584- DISPLAY 'I REABILITACAO I '    ' AC-REABILITACAO '     I' */

            $"I REABILITACAO I  AC-REABILITACAO I"
            .Display();

            /*" -3586- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3588- DISPLAY 'I ALTERACAO DA FORMA DE PAGAMENTO I '    ' AC-ALT-FORMA-PGTO '     I' */

            $"I ALTERACAO DA FORMA DE PAGAMENTO I  AC-ALT-FORMA-PGTO I"
            .Display();

            /*" -3590- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3592- DISPLAY 'I ALTERACAO DE DADOS BANCARIOS I '    ' AC-DAD-BANCARIOS '     I' */

            $"I ALTERACAO DE DADOS BANCARIOS I  AC-DAD-BANCARIOS I"
            .Display();

            /*" -3594- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3596- DISPLAY 'I ALTERACAO DE ENDERECO E TELEFONE I '    ' AC-DAD-ENDERECO '     I' */

            $"I ALTERACAO DE ENDERECO E TELEFONE I  AC-DAD-ENDERECO I"
            .Display();

            /*" -3598- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3600- DISPLAY 'I ALTERACAO DO DIA DE VENCIMENTO I '    ' AC-ALT-DIA-VENC '     I' */

            $"I ALTERACAO DO DIA DE VENCIMENTO I  AC-ALT-DIA-VENC I"
            .Display();

            /*" -3602- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3604- DISPLAY 'I ALTERACAO DE PROFISSAO DO SEGURADO I '    ' AC-ALT-PROF-SEG '     I' */

            $"I ALTERACAO DE PROFISSAO DO SEGURADO I  AC-ALT-PROF-SEG I"
            .Display();

            /*" -3606- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3608- DISPLAY 'I ALTERACAO DADOS DO CONJUGE I '    ' AC-ALT-DAD-CONJ '     I' */

            $"I ALTERACAO DADOS DO CONJUGE I  AC-ALT-DAD-CONJ I"
            .Display();

            /*" -3610- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3612- DISPLAY 'I EMISSAO CERTIFICADO INDIVIDUAL I '    ' AC-EMIS-CERT-IND '     I' */

            $"I EMISSAO CERTIFICADO INDIVIDUAL I  AC-EMIS-CERT-IND I"
            .Display();

            /*" -3614- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3616- DISPLAY 'I ALTERACAO DE CAPITAL GLOBAL I '    ' AC-ALT-CAPIT-GLO '     I' */

            $"I ALTERACAO DE CAPITAL GLOBAL I  AC-ALT-CAPIT-GLO I"
            .Display();

            /*" -3618- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3620- DISPLAY 'I AUMENTO DE CAPITAL I '    ' AC-AUM-CAPITAL '     I' */

            $"I AUMENTO DE CAPITAL I  AC-AUM-CAPITAL I"
            .Display();

            /*" -3622- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3624- DISPLAY 'I REDUCAO DE CAPITAL I '    ' AC-RED-CAPITAL '     I' */

            $"I REDUCAO DE CAPITAL I  AC-RED-CAPITAL I"
            .Display();

            /*" -3626- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3628- DISPLAY 'I CANCELAMENTO - APOLICE I '    ' AC-CANC-APOLICE '     I' */

            $"I CANCELAMENTO - APOLICE I  AC-CANC-APOLICE I"
            .Display();

            /*" -3630- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3632- DISPLAY 'I CANCELAMENTO - SUBGRUPO I '    ' AC-CANC-SUBGRUPO '     I' */

            $"I CANCELAMENTO - SUBGRUPO I  AC-CANC-SUBGRUPO I"
            .Display();

            /*" -3634- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3636- DISPLAY 'I SOLICITACAO DE RELACAO DE VIDAS I '    ' AC-SOL-RELACAO '     I' */

            $"I SOLICITACAO DE RELACAO DE VIDAS I  AC-SOL-RELACAO I"
            .Display();

            /*" -3638- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3640- DISPLAY 'I INCLUSAO DE SUBGRUPO I '    ' AC-INCL-SUBGRUPO '     I' */

            $"I INCLUSAO DE SUBGRUPO I  AC-INCL-SUBGRUPO I"
            .Display();

            /*" -3642- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3644- DISPLAY 'I ALTERAR TAXA I '    ' AC-ALT-TAXA '     I' */

            $"I ALTERAR TAXA I  AC-ALT-TAXA I"
            .Display();

            /*" -3646- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3648- DISPLAY 'I ALTERAR COBERTURAS I '    ' AC-ALT-COBERT '     I' */

            $"I ALTERAR COBERTURAS I  AC-ALT-COBERT I"
            .Display();

            /*" -3650- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3652- DISPLAY 'I INCLUSAO DE PLANO I '    ' AC-INCL-PLANO '     I' */

            $"I INCLUSAO DE PLANO I  AC-INCL-PLANO I"
            .Display();

            /*" -3654- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3656- DISPLAY 'I ESTORNO/DEVOLUCAO EM FOLLOW I '    ' AC-EST-DEV-FOLLOW '     I' */

            $"I ESTORNO/DEVOLUCAO EM FOLLOW I  AC-EST-DEV-FOLLOW I"
            .Display();

            /*" -3658- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3660- DISPLAY 'I 2a VIA DE FRONTISPICIO I '    ' AC-SEG-VIA-FRONT '     I' */

            $"I 2a VIA DE FRONTISPICIO I  AC-SEG-VIA-FRONT I"
            .Display();

            /*" -3662- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3664- DISPLAY 'I ALTERACAO DE CAPITAL - VIDA EXCLUSIVO I '    ' AC-ALT-CAPIT-EXC '     I' */

            $"I ALTERACAO DE CAPITAL - VIDA EXCLUSIVO I  AC-ALT-CAPIT-EXC I"
            .Display();

            /*" -3666- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3668- DISPLAY 'I REABILITACAO - APOLICE ESPECIFICA I '    ' AC-REAB-AP-ESPEC '     I' */

            $"I REABILITACAO - APOLICE ESPECIFICA I  AC-REAB-AP-ESPEC I"
            .Display();

            /*" -3670- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3672- DISPLAY 'I ALTERACAO DE DADOS CADASTRAIS I '    ' AC-ALT-DAD-CAD '     I' */

            $"I ALTERACAO DE DADOS CADASTRAIS I  AC-ALT-DAD-CAD I"
            .Display();

            /*" -3674- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3676- DISPLAY 'I ALTERACAO DE DADOS DO CERTIFICADO I '    ' AC-ALT-DAD-CERTIF '     I' */

            $"I ALTERACAO DE DADOS DO CERTIFICADO I  AC-ALT-DAD-CERTIF I"
            .Display();

            /*" -3678- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3680- DISPLAY 'I QUANTIDADE DE REGISTROS LIDOS NA TABELA I '    ' AC-LIDOS '     I' */

            $"I QUANTIDADE DE REGISTROS LIDOS NA TABELA I  AC-LIDOS I"
            .Display();

            /*" -3682- DISPLAY 'I QUANTIDADE DE REGISTROS LIDOS NO SORT I '    ' AC-LIDOS-SORT '     I' */

            $"I QUANTIDADE DE REGISTROS LIDOS NO SORT I  AC-LIDOS-SORT I"
            .Display();

            /*" -3684- DISPLAY 'I QUANTIDADE DE REG. GRAVADOS NO RELATORIO I '    ' AC-GRAVADOS '     I' */

            $"I QUANTIDADE DE REG. GRAVADOS NO RELATORIO I  AC-GRAVADOS I"
            .Display();

            /*" -3686- DISPLAY '+--------------------------------------------+--- '-----------------+' */
            _.Display($"+--------------------------------------------+--- -----------------+");

            /*" -3688- DISPLAY 'I V A 0 9 3 0 B - F I M N O R M A ' L               I' */

            $"I V A 0 9 3 0 B - F I M N O R M A LI"
            .Display();

            /*" -3689- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3702- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -3704- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -3704- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3706- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3710- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3712- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (WORK_AREA.AC_ERRO_DADOS > 00 && WORK_AREA.AC_ERRO_SISTEMA > 00)
            {

                /*" -3713- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -3714- ELSE */
            }
            else
            {


                /*" -3715- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (WORK_AREA.AC_ERRO_SISTEMA > 00)
                {

                    /*" -3716- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -3717- ELSE */
                }
                else
                {


                    /*" -3718- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (WORK_AREA.AC_ERRO_DADOS > 00)
                    {

                        /*" -3720- MOVE 1 TO RETURN-CODE. */
                        _.Move(1, RETURN_CODE);
                    }

                }

            }


            /*" -3720- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}