using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8051B
{
    public class R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO
            INTO :WHOST-DATA-EM
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'FA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'FA'";

            return query;
        }
        public string WHOST_DATA_EM { get; set; }

        public static R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA_EM = result[i++].Value?.ToString();
            return dta;
        }

    }
}