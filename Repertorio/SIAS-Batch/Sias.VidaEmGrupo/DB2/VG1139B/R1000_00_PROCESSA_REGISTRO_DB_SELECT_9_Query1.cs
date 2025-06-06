using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATE(:V0ENDO-DTINIVIG) +
            :V0OPCP-PERIPGTO MONTHS - 1 DAY
            INTO
            :V0ENDO-DTTERVIG
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'VG'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATE('{this.V0ENDO_DTINIVIG}') +
											{this.V0OPCP_PERIPGTO} MONTHS - 1 DAY
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'VG'";

            return query;
        }
        public string V0ENDO_DTTERVIG { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_9_Query1();
            var i = 0;
            dta.V0ENDO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}