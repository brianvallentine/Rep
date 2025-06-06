using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1 : QueryBasis<R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_CAPALOTE1
            (COD_FONTE,
            NUM_LOTE,
            COD_PREST_SERVICO,
            NUM_CHEQUE_INTERNO,
            DIG_CHEQUE_INTERNO,
            QTD_LANCAMENTO,
            VAL_TOT_LANCA,
            DT_ABERTURA,
            DT_FECHAMENTO,
            DT_LIBERA_PAGTO,
            DT_PAGAMENTO,
            DT_CANCELA_LOTE,
            SITUACAO_LOTE,
            COD_MOEDA,
            COD_USUARIO,
            TIMESTAMP,
            NOME_DEPTO,
            COD_FONTE_DEST,
            IDTAB,
            CODIGO_CH1,
            NUM_DOCF_INTERNO,
            COD_PRODUTO,
            COD_SISTEMA_ORIGEM)
            VALUES (:SINNUMLO-COD-FONTE,
            :SINNUMLO-NUM-LOTE,
            :SINISHIS-COD-PREST-SERVICO,
            0,
            0,
            :SINISCAP-QTD-LANCAMENTO,
            :SINISCAP-VAL-TOT-LANCA,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SINISCAP-DT-LIBERA-PAGTO :I-DT-LIBERA-PAGTO,
            :SINISCAP-DT-PAGAMENTO :I-DT-PAGAMENTO,
            NULL,
            :SINISCAP-SITUACAO-LOTE,
            0,
            :SINISCAP-COD-USUARIO,
            CURRENT TIMESTAMP,
            :SINISCAP-NOME-DEPTO,
            :SINISCAP-COD-FONTE-DEST,
            :SINISCAP-IDTAB,
            :SINISCAP-CODIGO-CH1,
            :FIPADOFI-NUM-DOCF-INTERNO,
            NULL,
            :SINISCAP-COD-SISTEMA-ORIGEM)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_CAPALOTE1 (COD_FONTE, NUM_LOTE, COD_PREST_SERVICO, NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO, QTD_LANCAMENTO, VAL_TOT_LANCA, DT_ABERTURA, DT_FECHAMENTO, DT_LIBERA_PAGTO, DT_PAGAMENTO, DT_CANCELA_LOTE, SITUACAO_LOTE, COD_MOEDA, COD_USUARIO, TIMESTAMP, NOME_DEPTO, COD_FONTE_DEST, IDTAB, CODIGO_CH1, NUM_DOCF_INTERNO, COD_PRODUTO, COD_SISTEMA_ORIGEM) VALUES ({FieldThreatment(this.SINNUMLO_COD_FONTE)}, {FieldThreatment(this.SINNUMLO_NUM_LOTE)}, {FieldThreatment(this.SINISHIS_COD_PREST_SERVICO)}, 0, 0, {FieldThreatment(this.SINISCAP_QTD_LANCAMENTO)}, {FieldThreatment(this.SINISCAP_VAL_TOT_LANCA)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)},  {FieldThreatment((this.I_DT_LIBERA_PAGTO?.ToInt() == -1 ? null : this.SINISCAP_DT_LIBERA_PAGTO))},  {FieldThreatment((this.I_DT_PAGAMENTO?.ToInt() == -1 ? null : this.SINISCAP_DT_PAGAMENTO))}, NULL, {FieldThreatment(this.SINISCAP_SITUACAO_LOTE)}, 0, {FieldThreatment(this.SINISCAP_COD_USUARIO)}, CURRENT TIMESTAMP, {FieldThreatment(this.SINISCAP_NOME_DEPTO)}, {FieldThreatment(this.SINISCAP_COD_FONTE_DEST)}, {FieldThreatment(this.SINISCAP_IDTAB)}, {FieldThreatment(this.SINISCAP_CODIGO_CH1)}, {FieldThreatment(this.FIPADOFI_NUM_DOCF_INTERNO)}, NULL, {FieldThreatment(this.SINISCAP_COD_SISTEMA_ORIGEM)})";

            return query;
        }
        public string SINNUMLO_COD_FONTE { get; set; }
        public string SINNUMLO_NUM_LOTE { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISCAP_QTD_LANCAMENTO { get; set; }
        public string SINISCAP_VAL_TOT_LANCA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SINISCAP_DT_LIBERA_PAGTO { get; set; }
        public string I_DT_LIBERA_PAGTO { get; set; }
        public string SINISCAP_DT_PAGAMENTO { get; set; }
        public string I_DT_PAGAMENTO { get; set; }
        public string SINISCAP_SITUACAO_LOTE { get; set; }
        public string SINISCAP_COD_USUARIO { get; set; }
        public string SINISCAP_NOME_DEPTO { get; set; }
        public string SINISCAP_COD_FONTE_DEST { get; set; }
        public string SINISCAP_IDTAB { get; set; }
        public string SINISCAP_CODIGO_CH1 { get; set; }
        public string FIPADOFI_NUM_DOCF_INTERNO { get; set; }
        public string SINISCAP_COD_SISTEMA_ORIGEM { get; set; }

        public static void Execute(R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1 r1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1)
        {
            var ths = r1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}