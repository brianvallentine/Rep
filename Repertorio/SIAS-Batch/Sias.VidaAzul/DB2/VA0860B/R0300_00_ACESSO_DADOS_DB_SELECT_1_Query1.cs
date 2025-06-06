using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0860B
{
    public class R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1 : QueryBasis<R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO,
            COD_PRODUTO ,
            COD_CLIENTE
            INTO :PROPOVA-NUM-CERTIFICADO,
            :PROPOVA-COD-PRODUTO ,
            :PROPOVA-COD-CLIENTE
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
							,
											COD_PRODUTO 
							,
											COD_CLIENTE
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1 Execute(R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1 r0300_00_ACESSO_DADOS_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_ACESSO_DADOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}