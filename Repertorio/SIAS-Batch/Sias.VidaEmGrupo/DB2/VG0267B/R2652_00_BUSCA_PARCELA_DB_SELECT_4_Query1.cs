using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 : QueryBasis<R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCIOF
            INTO :SQL-PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = 93
            AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG
            AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = 93
											AND DTINIVIG <= '{this.V0PARC_DTVENCTO_ORIG}'
											AND DTTERVIG >= '{this.V0PARC_DTVENCTO_ORIG}'";

            return query;
        }
        public string SQL_PCIOF { get; set; }
        public string V0PARC_DTVENCTO_ORIG { get; set; }

        public static R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 Execute(R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1)
        {
            var ths = r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1();
            var i = 0;
            dta.SQL_PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}