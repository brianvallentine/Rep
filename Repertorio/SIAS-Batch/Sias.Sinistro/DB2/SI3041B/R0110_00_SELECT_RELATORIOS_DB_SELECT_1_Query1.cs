using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI3041B
{
    public class R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_RELATORIO,
            PERI_INICIAL,
            PERI_FINAL
            INTO :RELATORI-COD-RELATORIO,
            :RELATORI-PERI-INICIAL,
            :RELATORI-PERI-FINAL
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'SI'
            AND COD_RELATORIO = 'SI3041B'
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_RELATORIO
							,
											PERI_INICIAL
							,
											PERI_FINAL
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'SI'
											AND COD_RELATORIO = 'SI3041B'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }

        public static R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1 Execute(R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1 r0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0110_00_SELECT_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}