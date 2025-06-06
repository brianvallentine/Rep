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
    public class R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1 : QueryBasis<R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-ACHA-LOTERICO
            FROM SEGUROS.LOTERICO01
            WHERE COD_LOT_CEF = :LOTERI01-COD-LOT-CEF
            AND COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND DTINIVIG <= :HOST-DATA-OCORRENCIA
            AND DTTERVIG >= :HOST-DATA-OCORRENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.LOTERICO01
											WHERE COD_LOT_CEF = '{this.LOTERI01_COD_LOT_CEF}'
											AND COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND DTINIVIG <= '{this.HOST_DATA_OCORRENCIA}'
											AND DTTERVIG >= '{this.HOST_DATA_OCORRENCIA}'
											WITH UR";

            return query;
        }
        public string HOST_ACHA_LOTERICO { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string LOTERI01_COD_LOT_CEF { get; set; }
        public string HOST_DATA_OCORRENCIA { get; set; }

        public static R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1 Execute(R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1 r110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1)
        {
            var ths = r110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_6_Query1();
            var i = 0;
            dta.HOST_ACHA_LOTERICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}