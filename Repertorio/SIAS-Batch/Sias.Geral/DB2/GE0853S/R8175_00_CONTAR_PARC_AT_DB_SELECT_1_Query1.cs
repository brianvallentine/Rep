using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1 : QueryBasis<R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NSAS, 0)
            , VALUE(NSL, 0)
            , SITUACAO
            INTO :V0HCTA-NSAS
            , :V0HCTA-NSL
            , :V0HCTA-SITUACAO
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :V0HISC-NRCERTIF
            AND NRPARCEL = :WS-NUM-PARC-AT
            AND SITUACAO IN ( '3' , ' ' , '2' )
            AND TIPLANC = '1'
            ORDER BY SITUACAO DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(NSAS
							, 0)
											, VALUE(NSL
							, 0)
											, SITUACAO
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.V0HISC_NRCERTIF}'
											AND NRPARCEL = '{this.WS_NUM_PARC_AT}'
											AND SITUACAO IN ( '3' 
							, ' ' 
							, '2' )
											AND TIPLANC = '1'
											ORDER BY SITUACAO DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_NSL { get; set; }
        public string V0HCTA_SITUACAO { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string WS_NUM_PARC_AT { get; set; }

        public static R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1 Execute(R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1 r8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1)
        {
            var ths = r8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCTA_NSAS = result[i++].Value?.ToString();
            dta.V0HCTA_NSL = result[i++].Value?.ToString();
            dta.V0HCTA_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}