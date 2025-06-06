using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3139B
{
    public class R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1 : QueryBasis<R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :V0PARC-OCORHIST
            FROM SEGUROS.V0PARCELA
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE
            AND NRENDOS = :V0ENDO-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V0PARCELA
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOLICE}'
											AND NRENDOS = '{this.V0ENDO_NRENDOS}'";

            return query;
        }
        public string V0PARC_OCORHIST { get; set; }
        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_NRENDOS { get; set; }

        public static R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1 Execute(R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1 r1330_00_LER_V0PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r1330_00_LER_V0PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1330_00_LER_V0PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARC_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}