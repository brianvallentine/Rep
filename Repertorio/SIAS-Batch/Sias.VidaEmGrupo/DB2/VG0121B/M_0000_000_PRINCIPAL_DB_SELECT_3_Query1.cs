using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0121B
{
    public class M_0000_000_PRINCIPAL_DB_SELECT_3_Query1 : QueryBasis<M_0000_000_PRINCIPAL_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT RAMO_VG ,
            RAMO_AP
            INTO :PARAM-RAMO-VG ,
            :PARAM-RAMO-AP
            FROM SEGUROS.V1PARAMRAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VG 
							,
											RAMO_AP
											FROM SEGUROS.V1PARAMRAMO";

            return query;
        }
        public string PARAM_RAMO_VG { get; set; }
        public string PARAM_RAMO_AP { get; set; }

        public static M_0000_000_PRINCIPAL_DB_SELECT_3_Query1 Execute(M_0000_000_PRINCIPAL_DB_SELECT_3_Query1 m_0000_000_PRINCIPAL_DB_SELECT_3_Query1)
        {
            var ths = m_0000_000_PRINCIPAL_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_000_PRINCIPAL_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_000_PRINCIPAL_DB_SELECT_3_Query1();
            var i = 0;
            dta.PARAM_RAMO_VG = result[i++].Value?.ToString();
            dta.PARAM_RAMO_AP = result[i++].Value?.ToString();
            return dta;
        }

    }
}