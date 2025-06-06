using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0781B
{
    public class M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD
            INTO :V1MOEDA-VLCRUZAD
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = 5 AND
            DTINIVIG <= :V0ENDOPARC-DTQITBCO AND
            DTTERVIG >= :V0ENDOPARC-DTQITBCO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = 5 AND
											DTINIVIG <= '{this.V0ENDOPARC_DTQITBCO}' AND
											DTTERVIG >= '{this.V0ENDOPARC_DTQITBCO}'";

            return query;
        }
        public string V1MOEDA_VLCRUZAD { get; set; }
        public string V0ENDOPARC_DTQITBCO { get; set; }

        public static M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1 Execute(M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1 m_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_200_100_SELECT_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOEDA_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}