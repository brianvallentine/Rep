using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0110_FETCH_DB_SELECT_2_Query1 : QueryBasis<M_0110_FETCH_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO
            INTO :V1APOL-RAMO
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT RAMO
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string V1APOL_RAMO { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }

        public static M_0110_FETCH_DB_SELECT_2_Query1 Execute(M_0110_FETCH_DB_SELECT_2_Query1 m_0110_FETCH_DB_SELECT_2_Query1)
        {
            var ths = m_0110_FETCH_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0110_FETCH_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0110_FETCH_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1APOL_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}