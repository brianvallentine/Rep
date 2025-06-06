using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI2010B
{
    public class R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            PERI_INICIAL
            INTO
            :RELATORI-PERI-INICIAL
            FROM
            SEGUROS.RELATORIOS
            WHERE
            IDE_SISTEMA = 'SI'
            AND COD_RELATORIO = 'SI2010B1'
            AND SIT_REGISTRO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PERI_INICIAL
											FROM
											SEGUROS.RELATORIOS
											WHERE
											IDE_SISTEMA = 'SI'
											AND COD_RELATORIO = 'SI2010B1'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RELATORI_PERI_INICIAL { get; set; }

        public static R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1 Execute(R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1 r0012_000_LER_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0012_000_LER_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0012_000_LER_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}