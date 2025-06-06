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
    public class R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1 : QueryBasis<R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            INTO :PROPOVA-NUM-CERTIFICADO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NRCERTIFANT = :PROPOVA-NRCERTIFANT
            AND SIT_REGISTRO NOT IN ( '2' , '4' )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NRCERTIFANT = '{this.PROPOVA_NRCERTIFANT}'
											AND SIT_REGISTRO NOT IN ( '2' 
							, '4' )
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NRCERTIFANT { get; set; }

        public static R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1 Execute(R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1 r1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1)
        {
            var ths = r1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}