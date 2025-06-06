using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0214B
{
    public class R010_LE_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<R010_LE_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            CURRENT DATE,
            DATA_MOV_ABERTO - 1 MONTH
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :HOST-DATA-CORRENTE,
            :HOST-DATA-SISTEMA-MENOS-30DIAS
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											CURRENT DATE
							,
											DATA_MOV_ABERTO - 1 MONTH
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'SI'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string HOST_DATA_CORRENTE { get; set; }
        public string HOST_DATA_SISTEMA_MENOS_30DIAS { get; set; }

        public static R010_LE_SISTEMAS_DB_SELECT_1_Query1 Execute(R010_LE_SISTEMAS_DB_SELECT_1_Query1 r010_LE_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = r010_LE_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R010_LE_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R010_LE_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.HOST_DATA_CORRENTE = result[i++].Value?.ToString();
            dta.HOST_DATA_SISTEMA_MENOS_30DIAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}