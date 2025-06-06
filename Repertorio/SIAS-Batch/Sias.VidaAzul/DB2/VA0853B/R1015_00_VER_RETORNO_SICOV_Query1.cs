using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1015_00_VER_RETORNO_SICOV_Query1 : QueryBasis<R1015_00_VER_RETORNO_SICOV_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NSAS, 0),
            VALUE(SITUACAO, ' ' )
            INTO :V0HCTA-NSAS,
            :V0HCTA-SITUACAO
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND NRPARCEL = :V0PROP-NRPARCEL
            AND SITUACAO IN ( ' ' , '0' , '3' , 'A' )
            AND TIPLANC = '1'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(NSAS
							, 0)
							,
											VALUE(SITUACAO
							, ' ' )
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND NRPARCEL = '{this.V0PROP_NRPARCEL}'
											AND SITUACAO IN ( ' ' 
							, '0' 
							, '3' 
							, 'A' )
											AND TIPLANC = '1'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_SITUACAO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static R1015_00_VER_RETORNO_SICOV_Query1 Execute(R1015_00_VER_RETORNO_SICOV_Query1 r1015_00_VER_RETORNO_SICOV_Query1)
        {
            var ths = r1015_00_VER_RETORNO_SICOV_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1015_00_VER_RETORNO_SICOV_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1015_00_VER_RETORNO_SICOV_Query1();
            var i = 0;
            dta.V0HCTA_NSAS = result[i++].Value?.ToString();
            dta.V0HCTA_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}