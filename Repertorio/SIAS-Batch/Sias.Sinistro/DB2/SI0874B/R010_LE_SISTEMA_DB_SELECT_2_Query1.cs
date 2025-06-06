using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R010_LE_SISTEMA_DB_SELECT_2_Query1 : QueryBasis<R010_LE_SISTEMA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :HOST-QTDE
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO BETWEEN :W-GDA-DATA-INICIO AND
            :SISTEMAS-DATA-MOV-ABERTO
            AND ((DIA_SEMANA = '6' )
            OR (DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO))
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO BETWEEN '{this.W_GDA_DATA_INICIO}' AND
											'{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND ((DIA_SEMANA = '6' )
											OR (DATA_CALENDARIO = '{this.SISTEMAS_DATA_MOV_ABERTO}'))";

            return query;
        }
        public string HOST_QTDE { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string W_GDA_DATA_INICIO { get; set; }

        public static R010_LE_SISTEMA_DB_SELECT_2_Query1 Execute(R010_LE_SISTEMA_DB_SELECT_2_Query1 r010_LE_SISTEMA_DB_SELECT_2_Query1)
        {
            var ths = r010_LE_SISTEMA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R010_LE_SISTEMA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R010_LE_SISTEMA_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_QTDE = result[i++].Value?.ToString();
            return dta;
        }

    }
}