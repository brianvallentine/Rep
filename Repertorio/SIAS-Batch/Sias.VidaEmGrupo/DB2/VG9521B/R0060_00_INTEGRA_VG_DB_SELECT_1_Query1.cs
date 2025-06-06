using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_00_INTEGRA_VG_DB_SELECT_1_Query1 : QueryBasis<R0060_00_INTEGRA_VG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NASCIMENTO
            INTO
            :FUNCICEF-NASCIMENTO
            FROM SEGUROS.FUNCIONARIOS_CEF
            WHERE
            NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NASCIMENTO
											FROM SEGUROS.FUNCIONARIOS_CEF
											WHERE
											NUM_MATRICULA = '{this.FUNCICEF_NUM_MATRICULA}'";

            return query;
        }
        public string FUNCICEF_NASCIMENTO { get; set; }
        public string FUNCICEF_NUM_MATRICULA { get; set; }

        public static R0060_00_INTEGRA_VG_DB_SELECT_1_Query1 Execute(R0060_00_INTEGRA_VG_DB_SELECT_1_Query1 r0060_00_INTEGRA_VG_DB_SELECT_1_Query1)
        {
            var ths = r0060_00_INTEGRA_VG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_00_INTEGRA_VG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_00_INTEGRA_VG_DB_SELECT_1_Query1();
            var i = 0;
            dta.FUNCICEF_NASCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}