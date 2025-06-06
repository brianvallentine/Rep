using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1 : QueryBasis<R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :PROPOVA-SIT-REGISTRO
            FROM SEGUROS.V0PROPOSTAVA
            WHERE NRCERTIF = :RELATORI-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0PROPOSTAVA
											WHERE NRCERTIF = '{this.RELATORI_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1 Execute(R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1 r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}