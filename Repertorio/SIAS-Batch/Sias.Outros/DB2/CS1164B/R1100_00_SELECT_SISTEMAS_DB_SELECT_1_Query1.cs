using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CS1164B
{
    public class R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            (DATA_MOV_ABERTO - 10 DAYS)
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :WHOST-DATA-10DIAS
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'CV'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											(DATA_MOV_ABERTO - 10 DAYS)
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'CV'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_DATA_10DIAS { get; set; }

        public static R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 r1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.WHOST_DATA_10DIAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}