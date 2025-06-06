using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0020B
{
    public class M_1100_INCLUSAO_DB_SELECT_2_Query1 : QueryBasis<M_1100_INCLUSAO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA
            INTO :SQL-AGENCIA
            FROM SEGUROS.V0AGENCIACEF
            WHERE COD_AGENCIA = :SQL-AGENCIA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
											FROM SEGUROS.V0AGENCIACEF
											WHERE COD_AGENCIA = '{this.SQL_AGENCIA}'";

            return query;
        }
        public string SQL_AGENCIA { get; set; }

        public static M_1100_INCLUSAO_DB_SELECT_2_Query1 Execute(M_1100_INCLUSAO_DB_SELECT_2_Query1 m_1100_INCLUSAO_DB_SELECT_2_Query1)
        {
            var ths = m_1100_INCLUSAO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1100_INCLUSAO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1100_INCLUSAO_DB_SELECT_2_Query1();
            var i = 0;
            dta.SQL_AGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}