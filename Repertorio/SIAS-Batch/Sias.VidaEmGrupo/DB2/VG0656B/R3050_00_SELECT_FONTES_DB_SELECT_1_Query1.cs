using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R3050_00_SELECT_FONTES_DB_SELECT_1_Query1 : QueryBasis<R3050_00_SELECT_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FONTE
            INTO :FONTES-NOME-FONTE
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :FONTES-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FONTE
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.FONTES_COD_FONTE}'";

            return query;
        }
        public string FONTES_NOME_FONTE { get; set; }
        public string FONTES_COD_FONTE { get; set; }

        public static R3050_00_SELECT_FONTES_DB_SELECT_1_Query1 Execute(R3050_00_SELECT_FONTES_DB_SELECT_1_Query1 r3050_00_SELECT_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r3050_00_SELECT_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3050_00_SELECT_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3050_00_SELECT_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}