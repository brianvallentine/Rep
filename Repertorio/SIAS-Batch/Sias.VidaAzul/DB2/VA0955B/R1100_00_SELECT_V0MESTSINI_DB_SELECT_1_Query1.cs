using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0955B
{
    public class R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_SINISTRO,
            NUM_APOLICE,
            TIPREG,
            FONTE,
            RAMO,
            CODLIDER,
            SINLID,
            DATCMD,
            DATORR,
            DATTEC,
            NRCERTIF,
            CODCAU
            INTO :V0MSIN-NUM-SINI,
            :V0MSIN-NUM-APOL,
            :V0MSIN-TIPREG,
            :V0MSIN-FONTE,
            :V0MSIN-RAMO,
            :V0MSIN-CODLIDER,
            :V0MSIN-SINLID,
            :V0MSIN-DATCMD,
            :V0MSIN-DATORR,
            :V0MSIN-DATTEC,
            :V0MSIN-NRCERTIF,
            :V0MSIN-CODCAU
            FROM SEGUROS.V0MESTSINI
            WHERE NUM_APOL_SINISTRO = :V0MSIN-NUM-SINI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_SINISTRO
							,
											NUM_APOLICE
							,
											TIPREG
							,
											FONTE
							,
											RAMO
							,
											CODLIDER
							,
											SINLID
							,
											DATCMD
							,
											DATORR
							,
											DATTEC
							,
											NRCERTIF
							,
											CODCAU
											FROM SEGUROS.V0MESTSINI
											WHERE NUM_APOL_SINISTRO = '{this.V0MSIN_NUM_SINI}'";

            return query;
        }
        public string V0MSIN_NUM_SINI { get; set; }
        public string V0MSIN_NUM_APOL { get; set; }
        public string V0MSIN_TIPREG { get; set; }
        public string V0MSIN_FONTE { get; set; }
        public string V0MSIN_RAMO { get; set; }
        public string V0MSIN_CODLIDER { get; set; }
        public string V0MSIN_SINLID { get; set; }
        public string V0MSIN_DATCMD { get; set; }
        public string V0MSIN_DATORR { get; set; }
        public string V0MSIN_DATTEC { get; set; }
        public string V0MSIN_NRCERTIF { get; set; }
        public string V0MSIN_CODCAU { get; set; }

        public static R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 r1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V0MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0MSIN_NUM_SINI = result[i++].Value?.ToString();
            dta.V0MSIN_NUM_APOL = result[i++].Value?.ToString();
            dta.V0MSIN_TIPREG = result[i++].Value?.ToString();
            dta.V0MSIN_FONTE = result[i++].Value?.ToString();
            dta.V0MSIN_RAMO = result[i++].Value?.ToString();
            dta.V0MSIN_CODLIDER = result[i++].Value?.ToString();
            dta.V0MSIN_SINLID = result[i++].Value?.ToString();
            dta.V0MSIN_DATCMD = result[i++].Value?.ToString();
            dta.V0MSIN_DATORR = result[i++].Value?.ToString();
            dta.V0MSIN_DATTEC = result[i++].Value?.ToString();
            dta.V0MSIN_NRCERTIF = result[i++].Value?.ToString();
            dta.V0MSIN_CODCAU = result[i++].Value?.ToString();
            return dta;
        }

    }
}