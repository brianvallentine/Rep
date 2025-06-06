using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1 : QueryBasis<M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERT_VGAP + 1
            INTO :NUMEROUT-NUM-CERT-VGAP
            FROM SEGUROS.NUMERO_OUTROS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERT_VGAP + 1
											FROM SEGUROS.NUMERO_OUTROS
											WITH UR";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }

        public static M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1 Execute(M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1 m_1100_SELECT_NUMEROS_DB_SELECT_1_Query1)
        {
            var ths = m_1100_SELECT_NUMEROS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1100_SELECT_NUMEROS_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUMEROUT_NUM_CERT_VGAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}