using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1 : QueryBasis<R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_EMISSOR,
            COD_PRODUTO
            INTO :APOLICES-RAMO-EMISSOR,
            :APOLICES-COD-PRODUTO
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_EMISSOR
							,
											COD_PRODUTO
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1 Execute(R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1 r2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1)
        {
            var ths = r2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2305_00_SELECT_V0CONDTEC_DB_SELECT_2_Query1();
            var i = 0;
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}