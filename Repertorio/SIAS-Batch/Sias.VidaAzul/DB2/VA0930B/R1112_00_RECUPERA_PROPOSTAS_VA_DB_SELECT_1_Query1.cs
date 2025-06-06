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
    public class R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1 : QueryBasis<R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROFISSAO
            , DTPROXVEN
            INTO :PROPOVA-PROFISSAO
            , :PROPOVA-DTPROXVEN
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PROFISSAO
											, DTPROXVEN
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_PROFISSAO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1 Execute(R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1 r1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1)
        {
            var ths = r1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_PROFISSAO = result[i++].Value?.ToString();
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}