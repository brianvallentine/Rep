using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1617B
{
    public class R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1 : QueryBasis<R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:W-DATA-SQL)
            INTO :W-DATA-SQL
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VG'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.W_DATA_SQL}')
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VG'
											WITH UR";

            return query;
        }
        public string W_DATA_SQL { get; set; }

        public static R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1 Execute(R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1 r8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1)
        {
            var ths = r8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8001_00_VERIFICA_DATA_VALIDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_DATA_SQL = result[i++].Value?.ToString();
            return dta;
        }

    }
}