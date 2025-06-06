using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R3040_00_CONTA_DIAS_DB_SELECT_2_Query1 : QueryBasis<R3040_00_CONTA_DIAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DAYS (:WHOST-DATA-CRED) -
            DAYS (:PARCEVID-DATA-VENCIMENTO)
            INTO :WQTDIAS
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VA'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DAYS ('{this.WHOST_DATA_CRED}') -
											DAYS ('{this.PARCEVID_DATA_VENCIMENTO}')
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VA'";

            return query;
        }
        public string WQTDIAS { get; set; }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string WHOST_DATA_CRED { get; set; }

        public static R3040_00_CONTA_DIAS_DB_SELECT_2_Query1 Execute(R3040_00_CONTA_DIAS_DB_SELECT_2_Query1 r3040_00_CONTA_DIAS_DB_SELECT_2_Query1)
        {
            var ths = r3040_00_CONTA_DIAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3040_00_CONTA_DIAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3040_00_CONTA_DIAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.WQTDIAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}