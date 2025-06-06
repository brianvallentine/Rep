using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IDE_SISTEMA
            INTO :SISTEMAS-IDE-SISTEMA
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IDE_SISTEMA
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = '{this.SISTEMAS_IDE_SISTEMA}'
											WITH UR";

            return query;
        }
        public string SISTEMAS_IDE_SISTEMA { get; set; }

        public static R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1 Execute(R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1 r0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0120_CRITICA_IDE_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_IDE_SISTEMA = result[i++].Value?.ToString();
            return dta;
        }

    }
}