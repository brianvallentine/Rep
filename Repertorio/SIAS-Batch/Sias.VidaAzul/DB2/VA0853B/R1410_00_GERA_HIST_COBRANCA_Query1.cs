using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1410_00_GERA_HIST_COBRANCA_Query1 : QueryBasis<R1410_00_GERA_HIST_COBRANCA_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO,
            DTVENCTO
            INTO :V0PARC-SITUACAO1,
            :V0PARC-DTVENCTO
            FROM SEGUROS.V0PARCELVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0RELA-NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
							,
											DTVENCTO
											FROM SEGUROS.V0PARCELVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0RELA_NRPARCEL}'
											WITH UR";

            return query;
        }
        public string V0PARC_SITUACAO1 { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0RELA_NRPARCEL { get; set; }

        public static R1410_00_GERA_HIST_COBRANCA_Query1 Execute(R1410_00_GERA_HIST_COBRANCA_Query1 r1410_00_GERA_HIST_COBRANCA_Query1)
        {
            var ths = r1410_00_GERA_HIST_COBRANCA_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1410_00_GERA_HIST_COBRANCA_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1410_00_GERA_HIST_COBRANCA_Query1();
            var i = 0;
            dta.V0PARC_SITUACAO1 = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}