using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0006S
{
    public class M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1 : QueryBasis<M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT P.COD_PRODUTO,
            P.COD_COBERTURA,
            P.PERC_ADIANTAMENTO
            INTO :SIPARADI-COD-PRODUTO,
            :SIPARADI-COD-COBERTURA,
            :SIPARADI-PERC-ADIANTAMENTO
            FROM SEGUROS.SI_PARAM_ADIANT P,
            SEGUROS.APOLICES A
            WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE
            AND P.COD_PRODUTO = A.COD_PRODUTO
            AND P.COD_COBERTURA = :SIPARADI-COD-COBERTURA
            AND P.DATA_INIVIGENCIA <= CURRENT DATE
            AND P.DATA_TERVIGENCIA >= CURRENT DATE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT P.COD_PRODUTO
							,
											P.COD_COBERTURA
							,
											P.PERC_ADIANTAMENTO
											FROM SEGUROS.SI_PARAM_ADIANT P
							,
											SEGUROS.APOLICES A
											WHERE A.NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'
											AND P.COD_PRODUTO = A.COD_PRODUTO
											AND P.COD_COBERTURA = '{this.SIPARADI_COD_COBERTURA}'
											AND P.DATA_INIVIGENCIA <= CURRENT DATE
											AND P.DATA_TERVIGENCIA >= CURRENT DATE
											WITH UR";

            return query;
        }
        public string SIPARADI_COD_PRODUTO { get; set; }
        public string SIPARADI_COD_COBERTURA { get; set; }
        public string SIPARADI_PERC_ADIANTAMENTO { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1 Execute(M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1 m_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1)
        {
            var ths = m_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIPARADI_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SIPARADI_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SIPARADI_PERC_ADIANTAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}