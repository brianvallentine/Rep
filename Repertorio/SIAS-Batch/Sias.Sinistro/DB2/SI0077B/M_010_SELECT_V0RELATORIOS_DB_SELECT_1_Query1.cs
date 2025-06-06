using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0077B
{
    public class M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :V0RELATORIOS-DATA-REFERENCIA
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'SI0077B'
            AND IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.V0RELATORIOS
											WHERE CODRELAT = 'SI0077B'
											AND IDSISTEM = 'SI'";

            return query;
        }
        public string V0RELATORIOS_DATA_REFERENCIA { get; set; }

        public static M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 Execute(M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 m_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = m_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_010_SELECT_V0RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RELATORIOS_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}