using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0530S
{
    public class R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1 : QueryBasis<R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO
            INTO :SISTEMAS-DATA-MOV-ABERTO
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'LT'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'LT'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1 Execute(R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1 r1200_00_DATA_SISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_DATA_SISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_DATA_SISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}