using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6253B
{
    public class R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :ENDOSSOS-COD-PRODUTO
            FROM SEGUROS.PROPOSTAS
            WHERE COD_FONTE = :PROPOSTA-COD-FONTE
            AND NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.PROPOSTAS
											WHERE COD_FONTE = '{this.PROPOSTA_COD_FONTE}'
											AND NUM_PROPOSTA = '{this.PROPOSTA_NUM_PROPOSTA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string PROPOSTA_COD_FONTE { get; set; }

        public static R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 Execute(R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 r1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1530_00_SELECT_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}