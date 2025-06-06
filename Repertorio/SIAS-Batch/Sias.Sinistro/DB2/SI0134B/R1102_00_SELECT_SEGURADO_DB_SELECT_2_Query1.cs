using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0134B
{
    public class R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1 : QueryBasis<R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCRICAO
            INTO :AGTABCH1-DESCRICAO
            FROM SEGUROS.AGRUPA_TABELAS_CH1
            WHERE IDTAB = 14
            AND CODIGO_CH1 = :SIHABIT2-CODIGO-CH1-REC1
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DESCRICAO
											FROM SEGUROS.AGRUPA_TABELAS_CH1
											WHERE IDTAB = 14
											AND CODIGO_CH1 = '{this.SIHABIT2_CODIGO_CH1_REC1}'
											WITH UR";

            return query;
        }
        public string AGTABCH1_DESCRICAO { get; set; }
        public string SIHABIT2_CODIGO_CH1_REC1 { get; set; }

        public static R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1 Execute(R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1 r1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1)
        {
            var ths = r1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1102_00_SELECT_SEGURADO_DB_SELECT_2_Query1();
            var i = 0;
            dta.AGTABCH1_DESCRICAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}