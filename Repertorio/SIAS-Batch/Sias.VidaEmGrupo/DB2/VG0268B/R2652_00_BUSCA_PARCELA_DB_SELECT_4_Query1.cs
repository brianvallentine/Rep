using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0268B
{
    public class R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 : QueryBasis<R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATE(:V0COBP-DTINIVIG-PARC) +
            (:V0OPCP-PERIPGTO * :V0COBP-OCORHIST) MONTHS
            INTO
            :V0COBP-DTINIVIG-PARC
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											DATE('{this.V0COBP_DTINIVIG_PARC}') +
											('{this.V0OPCP_PERIPGTO}' * {this.V0COBP_OCORHIST}) MONTHS
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'
											WITH UR";

            return query;
        }
        public string V0COBP_DTINIVIG_PARC { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0COBP_OCORHIST { get; set; }

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
            dta.V0COBP_DTINIVIG_PARC = result[i++].Value?.ToString();
            return dta;
        }

    }
}