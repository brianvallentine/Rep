using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0502S
{
    public class R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IDE_SISTEMA,
            DATA_MOV_ABERTO
            INTO :SISTEMAS-IDE-SISTEMA,
            :SISTEMAS-DATA-MOV-ABERTO
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IDE_SISTEMA
							,
											DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'SI'";

            return query;
        }
        public string SISTEMAS_IDE_SISTEMA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 Execute(R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}