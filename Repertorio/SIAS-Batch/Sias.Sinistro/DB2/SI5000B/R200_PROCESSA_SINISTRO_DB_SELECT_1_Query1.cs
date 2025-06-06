using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5000B
{
    public class R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1 : QueryBasis<R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT L.BANCO,
            L.AGENCIA,
            L.OPERACAO_CONTA,
            L.NUMERO_CONTA,
            L.DV_CONTA
            INTO :LOTERI01-BANCO,
            :LOTERI01-AGENCIA,
            :LOTERI01-OPERACAO-CONTA,
            :LOTERI01-NUMERO-CONTA,
            :LOTERI01-DV-CONTA
            FROM SEGUROS.LOTERICO01 L
            WHERE L.COD_LOT_CEF = :SINILT01-COD-LOT-CEF
            AND L.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL
            AND L.NUM_APOLICE = :SINISHIS-NUM-APOLICE
            AND L.DTTERVIG =
            (SELECT MAX(L.DTTERVIG)
            FROM SEGUROS.LOTERICO01 L
            WHERE L.COD_LOT_CEF = :SINILT01-COD-LOT-CEF
            AND L.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL
            AND L.NUM_APOLICE = :SINISHIS-NUM-APOLICE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT L.BANCO
							,
											L.AGENCIA
							,
											L.OPERACAO_CONTA
							,
											L.NUMERO_CONTA
							,
											L.DV_CONTA
											FROM SEGUROS.LOTERICO01 L
											WHERE L.COD_LOT_CEF = '{this.SINILT01_COD_LOT_CEF}'
											AND L.COD_LOT_FENAL = '{this.SINILT01_COD_LOT_FENAL}'
											AND L.NUM_APOLICE = '{this.SINISHIS_NUM_APOLICE}'
											AND L.DTTERVIG =
											(SELECT MAX(L.DTTERVIG)
											FROM SEGUROS.LOTERICO01 L
											WHERE L.COD_LOT_CEF = '{this.SINILT01_COD_LOT_CEF}'
											AND L.COD_LOT_FENAL = '{this.SINILT01_COD_LOT_FENAL}'
											AND L.NUM_APOLICE = '{this.SINISHIS_NUM_APOLICE}')";

            return query;
        }
        public string LOTERI01_BANCO { get; set; }
        public string LOTERI01_AGENCIA { get; set; }
        public string LOTERI01_OPERACAO_CONTA { get; set; }
        public string LOTERI01_NUMERO_CONTA { get; set; }
        public string LOTERI01_DV_CONTA { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string SINISHIS_NUM_APOLICE { get; set; }

        public static R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1 Execute(R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1 r200_PROCESSA_SINISTRO_DB_SELECT_1_Query1)
        {
            var ths = r200_PROCESSA_SINISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_PROCESSA_SINISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTERI01_BANCO = result[i++].Value?.ToString();
            dta.LOTERI01_AGENCIA = result[i++].Value?.ToString();
            dta.LOTERI01_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.LOTERI01_NUMERO_CONTA = result[i++].Value?.ToString();
            dta.LOTERI01_DV_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}