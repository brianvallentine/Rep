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
    public class R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 : QueryBasis<R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:WHOST-DATA1) + :V0OPCP-PERIPGTO MONTHS
            - 1 DAY
            INTO :WHOST-DATA2
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'FI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.WHOST_DATA1}') + {this.V0OPCP_PERIPGTO} MONTHS
											- 1 DAY
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'FI'
											WITH UR";

            return query;
        }
        public string WHOST_DATA2 { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string WHOST_DATA1 { get; set; }

        public static R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 Execute(R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA2 = result[i++].Value?.ToString();
            return dta;
        }

    }
}