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
    public class R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO,
            COD_COBERTURA,
            PERC_ADIANTAMENTO
            INTO :SIPARADI-COD-PRODUTO,
            :SIPARADI-COD-COBERTURA,
            :SIPARADI-PERC-ADIANTAMENTO
            FROM SEGUROS.SI_PARAM_ADIANT
            WHERE COD_PRODUTO = :APOLICES-COD-PRODUTO
            AND COD_COBERTURA = :LOTISG01-COD-COBERTURA
            AND DATA_INIVIGENCIA <= CURRENT DATE
            AND DATA_TERVIGENCIA >= CURRENT DATE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
							,
											COD_COBERTURA
							,
											PERC_ADIANTAMENTO
											FROM SEGUROS.SI_PARAM_ADIANT
											WHERE COD_PRODUTO = '{this.APOLICES_COD_PRODUTO}'
											AND COD_COBERTURA = '{this.LOTISG01_COD_COBERTURA}'
											AND DATA_INIVIGENCIA <= CURRENT DATE
											AND DATA_TERVIGENCIA >= CURRENT DATE
											WITH UR";

            return query;
        }
        public string SIPARADI_COD_PRODUTO { get; set; }
        public string SIPARADI_COD_COBERTURA { get; set; }
        public string SIPARADI_PERC_ADIANTAMENTO { get; set; }
        public string LOTISG01_COD_COBERTURA { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }

        public static R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1 Execute(R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1 r1000_GRAVA_SINISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_GRAVA_SINISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_GRAVA_SINISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIPARADI_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SIPARADI_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SIPARADI_PERC_ADIANTAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}