using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1 : QueryBasis<R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(L.BANCO,999),
            VALUE(L.AGENCIA,999),
            VALUE(L.OPERACAO_CONTA,9999),
            VALUE(L.NUMERO_CONTA,999999999999),
            VALUE(L.DV_CONTA, '9' )
            INTO :LOTERI01-BANCO,
            :LOTERI01-AGENCIA,
            :LOTERI01-OPERACAO-CONTA,
            :LOTERI01-NUMERO-CONTA,
            :LOTERI01-DV-CONTA
            FROM SEGUROS.LOTERICO01 L
            WHERE L.COD_LOT_CEF = :SINILT01-COD-LOT-CEF
            AND L.COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL
            AND L.DTTERVIG = (
            SELECT MAX(A.DTTERVIG)
            FROM SEGUROS.LOTERICO01 A
            WHERE A.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF
            AND A.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(L.BANCO
							,999)
							,
											VALUE(L.AGENCIA
							,999)
							,
											VALUE(L.OPERACAO_CONTA
							,9999)
							,
											VALUE(L.NUMERO_CONTA
							,999999999999)
							,
											VALUE(L.DV_CONTA
							, '9' )
											FROM SEGUROS.LOTERICO01 L
											WHERE L.COD_LOT_CEF = '{this.SINILT01_COD_LOT_CEF}'
											AND L.COD_LOT_FENAL = '{this.SINILT01_COD_LOT_FENAL}'
											AND L.DTTERVIG = (
											SELECT MAX(A.DTTERVIG)
											FROM SEGUROS.LOTERICO01 A
											WHERE A.COD_LOT_CEF = '{this.LOTERI01_COD_LOT_CEF}'
											AND A.COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											)
											WITH UR";

            return query;
        }
        public string LOTERI01_BANCO { get; set; }
        public string LOTERI01_AGENCIA { get; set; }
        public string LOTERI01_OPERACAO_CONTA { get; set; }
        public string LOTERI01_NUMERO_CONTA { get; set; }
        public string LOTERI01_DV_CONTA { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string LOTERI01_COD_LOT_CEF { get; set; }

        public static R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1 Execute(R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1 r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1)
        {
            var ths = r130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1_Query1();
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