using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0061B
{
    public class R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1 : QueryBasis<R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO,
            COD_CLIENTE
            INTO :PROPOVA-SIT-REGISTRO ,
            :PROPOVA-COD-CLIENTE
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							,
											COD_CLIENTE
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.ERRPROVI_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string ERRPROVI_NUM_CERTIFICADO { get; set; }

        public static R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1 Execute(R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1 r1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1)
        {
            var ths = r1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}