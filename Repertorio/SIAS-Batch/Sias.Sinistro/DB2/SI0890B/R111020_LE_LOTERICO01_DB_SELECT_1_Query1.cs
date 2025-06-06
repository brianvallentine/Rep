using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0890B
{
    public class R111020_LE_LOTERICO01_DB_SELECT_1_Query1 : QueryBasis<R111020_LE_LOTERICO01_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SIGLA_UF,
            CIDADE,
            COD_CLASSE_ADESAO,
            AGENCIA
            INTO
            :LOTERI01-SIGLA-UF,
            :LOTERI01-CIDADE,
            :LOTERI01-COD-CLASSE-ADESAO,
            :LOTERI01-AGENCIA
            FROM SEGUROS.LOTERICO01
            WHERE COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND DTINIVIG <= :SINISMES-DATA-OCORRENCIA
            AND DTTERVIG >= :SINISMES-DATA-OCORRENCIA
            AND DTINIVIG =
            (SELECT MAX(A.DTINIVIG)
            FROM SEGUROS.LOTERICO01 A
            WHERE A.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND A.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND A.DTINIVIG <= :SINISMES-DATA-OCORRENCIA
            AND A.DTTERVIG >= :SINISMES-DATA-OCORRENCIA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SIGLA_UF
							,
											CIDADE
							,
											COD_CLASSE_ADESAO
							,
											AGENCIA
											FROM SEGUROS.LOTERICO01
											WHERE COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND DTINIVIG <= '{this.SINISMES_DATA_OCORRENCIA}'
											AND DTTERVIG >= '{this.SINISMES_DATA_OCORRENCIA}'
											AND DTINIVIG =
											(SELECT MAX(A.DTINIVIG)
											FROM SEGUROS.LOTERICO01 A
											WHERE A.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND A.COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND A.DTINIVIG <= '{this.SINISMES_DATA_OCORRENCIA}'
											AND A.DTTERVIG >= '{this.SINISMES_DATA_OCORRENCIA}')";

            return query;
        }
        public string LOTERI01_SIGLA_UF { get; set; }
        public string LOTERI01_CIDADE { get; set; }
        public string LOTERI01_COD_CLASSE_ADESAO { get; set; }
        public string LOTERI01_AGENCIA { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R111020_LE_LOTERICO01_DB_SELECT_1_Query1 Execute(R111020_LE_LOTERICO01_DB_SELECT_1_Query1 r111020_LE_LOTERICO01_DB_SELECT_1_Query1)
        {
            var ths = r111020_LE_LOTERICO01_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R111020_LE_LOTERICO01_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R111020_LE_LOTERICO01_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTERI01_SIGLA_UF = result[i++].Value?.ToString();
            dta.LOTERI01_CIDADE = result[i++].Value?.ToString();
            dta.LOTERI01_COD_CLASSE_ADESAO = result[i++].Value?.ToString();
            dta.LOTERI01_AGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}