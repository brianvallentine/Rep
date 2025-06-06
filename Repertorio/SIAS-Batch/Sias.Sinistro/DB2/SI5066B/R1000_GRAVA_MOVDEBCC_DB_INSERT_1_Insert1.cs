using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1 : QueryBasis<R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF
            (COD_EMPRESA ,
            NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            SITUACAO_COBRANCA ,
            DATA_VENCIMENTO ,
            VALOR_DEBITO ,
            DATA_MOVIMENTO ,
            TIMESTAMP ,
            DIA_DEBITO ,
            COD_AGENCIA_DEB ,
            OPER_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            COD_CONVENIO ,
            DATA_ENVIO ,
            DATA_RETORNO ,
            COD_RETORNO_CEF ,
            NSAS ,
            COD_USUARIO ,
            NUM_REQUISICAO ,
            NUM_CARTAO ,
            SEQUENCIA ,
            NUM_LOTE ,
            DTCREDITO ,
            STATUS_CARTAO ,
            VLR_CREDITO)
            VALUES (:MOVDEBCE-COD-EMPRESA,
            :MOVDEBCE-NUM-APOLICE,
            :MOVDEBCE-NUM-ENDOSSO,
            :MOVDEBCE-NUM-PARCELA,
            :MOVDEBCE-SITUACAO-COBRANCA,
            :MOVDEBCE-DATA-VENCIMENTO,
            :MOVDEBCE-VALOR-DEBITO,
            :MOVDEBCE-DATA-MOVIMENTO,
            CURRENT TIMESTAMP,
            :MOVDEBCE-DIA-DEBITO,
            :MOVDEBCE-COD-AGENCIA-DEB,
            :MOVDEBCE-OPER-CONTA-DEB,
            :MOVDEBCE-NUM-CONTA-DEB,
            :MOVDEBCE-DIG-CONTA-DEB,
            :MOVDEBCE-COD-CONVENIO,
            NULL,
            NULL,
            NULL,
            :MOVDEBCE-NSAS,
            :MOVDEBCE-COD-USUARIO,
            :MOVDEBCE-NUM-REQUISICAO,
            :MOVDEBCE-NUM-CARTAO,
            :MOVDEBCE-SEQUENCIA,
            :MOVDEBCE-NUM-LOTE,
            NULL,
            NULL,
            :MOVDEBCE-VLR-CREDITO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF (COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO) VALUES ({FieldThreatment(this.MOVDEBCE_COD_EMPRESA)}, {FieldThreatment(this.MOVDEBCE_NUM_APOLICE)}, {FieldThreatment(this.MOVDEBCE_NUM_ENDOSSO)}, {FieldThreatment(this.MOVDEBCE_NUM_PARCELA)}, {FieldThreatment(this.MOVDEBCE_SITUACAO_COBRANCA)}, {FieldThreatment(this.MOVDEBCE_DATA_VENCIMENTO)}, {FieldThreatment(this.MOVDEBCE_VALOR_DEBITO)}, {FieldThreatment(this.MOVDEBCE_DATA_MOVIMENTO)}, CURRENT TIMESTAMP, {FieldThreatment(this.MOVDEBCE_DIA_DEBITO)}, {FieldThreatment(this.MOVDEBCE_COD_AGENCIA_DEB)}, {FieldThreatment(this.MOVDEBCE_OPER_CONTA_DEB)}, {FieldThreatment(this.MOVDEBCE_NUM_CONTA_DEB)}, {FieldThreatment(this.MOVDEBCE_DIG_CONTA_DEB)}, {FieldThreatment(this.MOVDEBCE_COD_CONVENIO)}, NULL, NULL, NULL, {FieldThreatment(this.MOVDEBCE_NSAS)}, {FieldThreatment(this.MOVDEBCE_COD_USUARIO)}, {FieldThreatment(this.MOVDEBCE_NUM_REQUISICAO)}, {FieldThreatment(this.MOVDEBCE_NUM_CARTAO)}, {FieldThreatment(this.MOVDEBCE_SEQUENCIA)}, {FieldThreatment(this.MOVDEBCE_NUM_LOTE)}, NULL, NULL, {FieldThreatment(this.MOVDEBCE_VLR_CREDITO)})";

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
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_COD_USUARIO { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string MOVDEBCE_SEQUENCIA { get; set; }
        public string MOVDEBCE_NUM_LOTE { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }

        public static void Execute(R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1 r1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1)
        {
            var ths = r1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_GRAVA_MOVDEBCC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}