using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1 : QueryBasis<R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.MOVTO_DEBITOCC_CEF
            (COD_EMPRESA
            ,NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,SITUACAO_COBRANCA
            ,DATA_VENCIMENTO
            ,VALOR_DEBITO
            ,DATA_MOVIMENTO
            ,TIMESTAMP
            ,DIA_DEBITO
            ,COD_AGENCIA_DEB
            ,OPER_CONTA_DEB
            ,NUM_CONTA_DEB
            ,DIG_CONTA_DEB
            ,COD_CONVENIO
            ,DATA_ENVIO
            ,DATA_RETORNO
            ,COD_RETORNO_CEF
            ,NSAS
            ,COD_USUARIO
            ,NUM_REQUISICAO
            ,NUM_CARTAO
            ,SEQUENCIA
            ,NUM_LOTE
            ,DTCREDITO
            ,STATUS_CARTAO
            ,VLR_CREDITO
            ,NUM_CERTIFICADO
            ,COD_MOEDA
            ,PCT_INDICE
            ,VLR_ORIGINAL
            ,VLR_PRORATA
            ,VLR_JUROS
            ,VLR_MULTA
            ,DTA_ORIGINAL
            ,COD_IDLG)
            VALUES (:MOVDEBCE-COD-EMPRESA ,
            :MOVDEBCE-NUM-APOLICE ,
            :MOVDEBCE-NUM-ENDOSSO ,
            :MOVDEBCE-NUM-PARCELA ,
            :MOVDEBCE-SITUACAO-COBRANCA ,
            :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-VALOR-DEBITO ,
            :MOVDEBCE-DATA-MOVIMENTO ,
            CURRENT TIMESTAMP ,
            :MOVDEBCE-DIA-DEBITO :VIND-DIADEBITO ,
            :MOVDEBCE-COD-AGENCIA-DEB :VIND-AGENCIA ,
            :MOVDEBCE-OPER-CONTA-DEB :VIND-OPERACAO ,
            :MOVDEBCE-NUM-CONTA-DEB :VIND-NUMCONTA ,
            :MOVDEBCE-DIG-CONTA-DEB :VIND-DIGCONTA ,
            :MOVDEBCE-COD-CONVENIO ,
            :MOVDEBCE-DATA-ENVIO :VIND-DTENVIO ,
            :MOVDEBCE-DATA-RETORNO :VIND-DTRETORNO ,
            :MOVDEBCE-COD-RETORNO-CEF :VIND-CODRETORNO,
            :MOVDEBCE-NSAS ,
            :MOVDEBCE-COD-USUARIO :VIND-USUARIO ,
            :MOVDEBCE-NUM-REQUISICAO :VIND-REQUISICAO,
            :MOVDEBCE-NUM-CARTAO :VIND-CARTAO-CREDITO,
            :MOVDEBCE-SEQUENCIA :VIND-SEQUENCIA ,
            :MOVDEBCE-NUM-LOTE :VIND-NUM-LOTE ,
            :MOVDEBCE-DTCREDITO :VIND-DTCREDITO ,
            :MOVDEBCE-STATUS-CARTAO :VIND-STATUS ,
            :MOVDEBCE-VLR-CREDITO :VIND-VLCREDITO ,
            :MOVDEBCE-NUM-CERTIFICADO ,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF (COD_EMPRESA ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,SITUACAO_COBRANCA ,DATA_VENCIMENTO ,VALOR_DEBITO ,DATA_MOVIMENTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DATA_ENVIO ,DATA_RETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ,NUM_CERTIFICADO ,COD_MOEDA ,PCT_INDICE ,VLR_ORIGINAL ,VLR_PRORATA ,VLR_JUROS ,VLR_MULTA ,DTA_ORIGINAL ,COD_IDLG) VALUES ({FieldThreatment(this.MOVDEBCE_COD_EMPRESA)} , {FieldThreatment(this.MOVDEBCE_NUM_APOLICE)} , {FieldThreatment(this.MOVDEBCE_NUM_ENDOSSO)} , {FieldThreatment(this.MOVDEBCE_NUM_PARCELA)} , {FieldThreatment(this.MOVDEBCE_SITUACAO_COBRANCA)} , {FieldThreatment(this.MOVDEBCE_DATA_VENCIMENTO)} , {FieldThreatment(this.MOVDEBCE_VALOR_DEBITO)} , {FieldThreatment(this.MOVDEBCE_DATA_MOVIMENTO)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DIADEBITO?.ToInt() == -1 ? null : this.MOVDEBCE_DIA_DEBITO))} ,  {FieldThreatment((this.VIND_AGENCIA?.ToInt() == -1 ? null : this.MOVDEBCE_COD_AGENCIA_DEB))} ,  {FieldThreatment((this.VIND_OPERACAO?.ToInt() == -1 ? null : this.MOVDEBCE_OPER_CONTA_DEB))} ,  {FieldThreatment((this.VIND_NUMCONTA?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_CONTA_DEB))} ,  {FieldThreatment((this.VIND_DIGCONTA?.ToInt() == -1 ? null : this.MOVDEBCE_DIG_CONTA_DEB))} , {FieldThreatment(this.MOVDEBCE_COD_CONVENIO)} ,  {FieldThreatment((this.VIND_DTENVIO?.ToInt() == -1 ? null : this.MOVDEBCE_DATA_ENVIO))} ,  {FieldThreatment((this.VIND_DTRETORNO?.ToInt() == -1 ? null : this.MOVDEBCE_DATA_RETORNO))} ,  {FieldThreatment((this.VIND_CODRETORNO?.ToInt() == -1 ? null : this.MOVDEBCE_COD_RETORNO_CEF))}, {FieldThreatment(this.MOVDEBCE_NSAS)} ,  {FieldThreatment((this.VIND_USUARIO?.ToInt() == -1 ? null : this.MOVDEBCE_COD_USUARIO))} ,  {FieldThreatment((this.VIND_REQUISICAO?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_REQUISICAO))},  {FieldThreatment((this.VIND_CARTAO_CREDITO?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_CARTAO))},  {FieldThreatment((this.VIND_SEQUENCIA?.ToInt() == -1 ? null : this.MOVDEBCE_SEQUENCIA))} ,  {FieldThreatment((this.VIND_NUM_LOTE?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_LOTE))} ,  {FieldThreatment((this.VIND_DTCREDITO?.ToInt() == -1 ? null : this.MOVDEBCE_DTCREDITO))} ,  {FieldThreatment((this.VIND_STATUS?.ToInt() == -1 ? null : this.MOVDEBCE_STATUS_CARTAO))} ,  {FieldThreatment((this.VIND_VLCREDITO?.ToInt() == -1 ? null : this.MOVDEBCE_VLR_CREDITO))} , {FieldThreatment(this.MOVDEBCE_NUM_CERTIFICADO)} , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL )";

            return query;
        }
        public string MOVDEBCE_COD_EMPRESA { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_DIA_DEBITO { get; set; }
        public string VIND_DIADEBITO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string VIND_OPERACAO { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string VIND_NUMCONTA { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string VIND_DIGCONTA { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_DATA_ENVIO { get; set; }
        public string VIND_DTENVIO { get; set; }
        public string MOVDEBCE_DATA_RETORNO { get; set; }
        public string VIND_DTRETORNO { get; set; }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string VIND_CODRETORNO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_COD_USUARIO { get; set; }
        public string VIND_USUARIO { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string VIND_REQUISICAO { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_CARTAO_CREDITO { get; set; }
        public string MOVDEBCE_SEQUENCIA { get; set; }
        public string VIND_SEQUENCIA { get; set; }
        public string MOVDEBCE_NUM_LOTE { get; set; }
        public string VIND_NUM_LOTE { get; set; }
        public string MOVDEBCE_DTCREDITO { get; set; }
        public string VIND_DTCREDITO { get; set; }
        public string MOVDEBCE_STATUS_CARTAO { get; set; }
        public string VIND_STATUS { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string VIND_VLCREDITO { get; set; }
        public string MOVDEBCE_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1 r1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1)
        {
            var ths = r1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1155_00_TRATA_MOVDEBCC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}