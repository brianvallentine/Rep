using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1 : QueryBasis<R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CERT_VGAP ,
            NUM_CLIENTE
            INTO
            :NUMEROUT-NUM-CERT-VGAP ,
            :NUMEROUT-NUM-CLIENTE
            FROM
            SEGUROS.NUMERO_OUTROS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CERT_VGAP 
							,
											NUM_CLIENTE
											FROM
											SEGUROS.NUMERO_OUTROS";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string NUMEROUT_NUM_CLIENTE { get; set; }

        public static R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1 Execute(R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1 r0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1)
        {
            var ths = r0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMEROUT_NUM_CERT_VGAP = result[i++].Value?.ToString();
            dta.NUMEROUT_NUM_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}