using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6017B
{
    public class R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            MONTH(DATA_MOV_ABERTO),
            YEAR(DATA_MOV_ABERTO)
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-MESREFER,
            :SISTEMAS-ANOREFER
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'CO'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											MONTH(DATA_MOV_ABERTO)
							,
											YEAR(DATA_MOV_ABERTO)
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'CO'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_MESREFER { get; set; }
        public string SISTEMAS_ANOREFER { get; set; }

        public static R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_MESREFER = result[i++].Value?.ToString();
            dta.SISTEMAS_ANOREFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}