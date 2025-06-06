using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1 : QueryBasis<R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(DATA_CALENDARIO), '0001-01-01' )
            INTO :W-DATA-PRIMEIRO-DIA-UTIL
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO <= :HOST-SI-DATA-MOV-ABERTO
            AND DATA_CALENDARIO >= :W-DIA01-MES-CORRENTE
            AND DIA_SEMANA NOT IN ( 'S' , 'D' )
            AND FERIADO = ' '
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(DATA_CALENDARIO)
							, '0001-01-01' )
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO <= '{this.HOST_SI_DATA_MOV_ABERTO}'
											AND DATA_CALENDARIO >= '{this.W_DIA01_MES_CORRENTE}'
											AND DIA_SEMANA NOT IN ( 'S' 
							, 'D' )
											AND FERIADO = ' '
											WITH UR";

            return query;
        }
        public string W_DATA_PRIMEIRO_DIA_UTIL { get; set; }
        public string HOST_SI_DATA_MOV_ABERTO { get; set; }
        public string W_DIA01_MES_CORRENTE { get; set; }

        public static R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1 Execute(R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1 r0010_SELECT_SISTEMAS_DB_SELECT_3_Query1)
        {
            var ths = r0010_SELECT_SISTEMAS_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0010_SELECT_SISTEMAS_DB_SELECT_3_Query1();
            var i = 0;
            dta.W_DATA_PRIMEIRO_DIA_UTIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}