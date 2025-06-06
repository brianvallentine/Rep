using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE,
            RAMO_EMISSOR
            INTO :APOLICES-COD-CLIENTE,
            :APOLICES-RAMO-EMISSOR
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE =
            :PROPOVA-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
							,
											RAMO_EMISSOR
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE =
											'{this.PROPOVA_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1 r1600_00_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}