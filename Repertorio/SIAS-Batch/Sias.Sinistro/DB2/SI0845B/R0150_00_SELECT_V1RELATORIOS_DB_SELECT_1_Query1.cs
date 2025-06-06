using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0845B
{
    public class R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODRELAT,
            MES_REFERENCIA,
            ANO_REFERENCIA
            INTO :V1RELA-CODRELAT,
            :V1RELA-MES-REFER,
            :V1RELA-ANO-REFER
            FROM SEGUROS.V1RELATORIOS
            WHERE CODRELAT = 'SI0845B1'
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODRELAT
							,
											MES_REFERENCIA
							,
											ANO_REFERENCIA
											FROM SEGUROS.V1RELATORIOS
											WHERE CODRELAT = 'SI0845B1'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1RELA_CODRELAT { get; set; }
        public string V1RELA_MES_REFER { get; set; }
        public string V1RELA_ANO_REFER { get; set; }

        public static R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1 Execute(R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1 r0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RELA_CODRELAT = result[i++].Value?.ToString();
            dta.V1RELA_MES_REFER = result[i++].Value?.ToString();
            dta.V1RELA_ANO_REFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}