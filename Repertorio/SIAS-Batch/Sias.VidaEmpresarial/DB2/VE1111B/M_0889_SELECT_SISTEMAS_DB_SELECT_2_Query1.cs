using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE1111B
{
    public class M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1 : QueryBasis<M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:W01DTSQL) + 1 MONTH - 1 DAY
            INTO :W02DTSQL
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VE'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.W01DTSQL}') + 1 MONTH - 1 DAY
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VE'
											WITH UR";

            return query;
        }
        public string W02DTSQL { get; set; }
        public string W01DTSQL { get; set; }

        public static M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1 Execute(M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1 m_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1)
        {
            var ths = m_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.W02DTSQL = result[i++].Value?.ToString();
            return dta;
        }

    }
}