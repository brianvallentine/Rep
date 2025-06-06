using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0340B
{
    public class R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1 : QueryBasis<R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO ,
            OPCAOOPAG
            INTO :V0PARC-SITUACAO ,
            :V0PARC-OPCAOPAG
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :NRCERTIF
            AND NRPARCEL = :NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO 
							,
											OPCAOOPAG
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.NRCERTIF}'
											AND NRPARCEL = '{this.NRPARCEL}'";

            return query;
        }
        public string V0PARC_SITUACAO { get; set; }
        public string V0PARC_OPCAOPAG { get; set; }
        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }

        public static R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1 Execute(R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1 r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1)
        {
            var ths = r0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_PROCESSA_V0HCONTAVA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0PARC_SITUACAO = result[i++].Value?.ToString();
            dta.V0PARC_OPCAOPAG = result[i++].Value?.ToString();
            return dta;
        }

    }
}