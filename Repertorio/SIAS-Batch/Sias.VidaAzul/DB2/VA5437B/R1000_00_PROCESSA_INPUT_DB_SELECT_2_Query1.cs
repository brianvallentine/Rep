using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1 : QueryBasis<R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT YEAR(CURRENT_DATE -
            DATE(:CLIENTES-DATA-NASCIMENTO))
            INTO :WS-IDADE
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'FI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT YEAR(CURRENT_DATE -
											DATE('{this.CLIENTES_DATA_NASCIMENTO}'))
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'FI'
											WITH UR";

            return query;
        }
        public string WS_IDADE { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }

        public static R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1 Execute(R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1 r1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1)
        {
            var ths = r1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_IDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}