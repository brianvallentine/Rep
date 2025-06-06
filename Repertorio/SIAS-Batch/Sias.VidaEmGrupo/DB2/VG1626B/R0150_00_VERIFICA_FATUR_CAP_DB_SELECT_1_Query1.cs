using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1 : QueryBasis<R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTPROXVEN ,
            DATA_VENCIMENTO ,
            DTPROXVEN - 16 DAYS ,
            DATE(TIMESTAMP)
            INTO :WS-DATA-PRO-VCTO ,
            :WS-DATA-VCTO ,
            :WS-DATA-PRO-VCTO-15 ,
            :WS-DATA-GER-VA
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_APOLICE = :WS-APOLICE-CAP
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTPROXVEN 
							,
											DATA_VENCIMENTO 
							,
											DTPROXVEN - 16 DAYS 
							,
											DATE(TIMESTAMP)
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_APOLICE = '{this.WS_APOLICE_CAP}'
											WITH UR";

            return query;
        }
        public string WS_DATA_PRO_VCTO { get; set; }
        public string WS_DATA_VCTO { get; set; }
        public string WS_DATA_PRO_VCTO_15 { get; set; }
        public string WS_DATA_GER_VA { get; set; }
        public string WS_APOLICE_CAP { get; set; }

        public static R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1 Execute(R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1 r0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1)
        {
            var ths = r0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_PRO_VCTO = result[i++].Value?.ToString();
            dta.WS_DATA_VCTO = result[i++].Value?.ToString();
            dta.WS_DATA_PRO_VCTO_15 = result[i++].Value?.ToString();
            dta.WS_DATA_GER_VA = result[i++].Value?.ToString();
            return dta;
        }

    }
}