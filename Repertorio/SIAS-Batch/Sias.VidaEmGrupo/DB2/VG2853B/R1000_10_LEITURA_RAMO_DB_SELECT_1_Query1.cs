using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2853B
{
    public class R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1 : QueryBasis<R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO
            INTO :V0APOL-RAMO
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'";

            return query;
        }
        public string V0APOL_RAMO { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }

        public static R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1 Execute(R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1 r1000_10_LEITURA_RAMO_DB_SELECT_1_Query1)
        {
            var ths = r1000_10_LEITURA_RAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0APOL_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}