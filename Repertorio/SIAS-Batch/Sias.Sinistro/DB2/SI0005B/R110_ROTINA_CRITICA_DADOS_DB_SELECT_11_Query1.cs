using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1 : QueryBasis<R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            ,SIT_REGISTRO
            INTO :HOST-DATA-INIVIGENCIA
            ,:HOST-DATA-TERVIGENCIA
            ,:HOST-SIT-REGISTRO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											,SIT_REGISTRO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string HOST_DATA_INIVIGENCIA { get; set; }
        public string HOST_DATA_TERVIGENCIA { get; set; }
        public string HOST_SIT_REGISTRO { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1 Execute(R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1 r110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1)
        {
            var ths = r110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_11_Query1();
            var i = 0;
            dta.HOST_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HOST_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.HOST_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}