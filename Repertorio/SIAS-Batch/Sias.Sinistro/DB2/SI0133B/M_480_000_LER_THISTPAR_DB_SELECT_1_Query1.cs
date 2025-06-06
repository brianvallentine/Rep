using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_480_000_LER_THISTPAR_DB_SELECT_1_Query1 : QueryBasis<M_480_000_LER_THISTPAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVTO, DTVENCTO
            INTO
            :THISTPAR-DTMOVTO, :THISTPAR-DTVENCTO
            FROM
            SEGUROS.V1HISTOPARC
            WHERE
            NUM_APOLICE = :PARCEL-NUM-APOL
            AND NRENDOS = :PARCEL-NRENDOS
            AND NRPARCEL = :PARCEL-NRPARCEL
            AND OCORHIST = :PARCEL-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVTO
							, DTVENCTO
											FROM
											SEGUROS.V1HISTOPARC
											WHERE
											NUM_APOLICE = '{this.PARCEL_NUM_APOL}'
											AND NRENDOS = '{this.PARCEL_NRENDOS}'
											AND NRPARCEL = '{this.PARCEL_NRPARCEL}'
											AND OCORHIST = '{this.PARCEL_OCORHIST}'";

            return query;
        }
        public string THISTPAR_DTMOVTO { get; set; }
        public string THISTPAR_DTVENCTO { get; set; }
        public string PARCEL_NUM_APOL { get; set; }
        public string PARCEL_NRPARCEL { get; set; }
        public string PARCEL_OCORHIST { get; set; }
        public string PARCEL_NRENDOS { get; set; }

        public static M_480_000_LER_THISTPAR_DB_SELECT_1_Query1 Execute(M_480_000_LER_THISTPAR_DB_SELECT_1_Query1 m_480_000_LER_THISTPAR_DB_SELECT_1_Query1)
        {
            var ths = m_480_000_LER_THISTPAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_480_000_LER_THISTPAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_480_000_LER_THISTPAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.THISTPAR_DTMOVTO = result[i++].Value?.ToString();
            dta.THISTPAR_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}