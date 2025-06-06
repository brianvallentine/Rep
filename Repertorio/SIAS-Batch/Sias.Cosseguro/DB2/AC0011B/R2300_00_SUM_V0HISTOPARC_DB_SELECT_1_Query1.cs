using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0011B
{
    public class R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_TARIFARIO),+0) ,
            VALUE(SUM(VAL_DESCONTO),+0) ,
            VALUE(SUM(VLADIFRA),+0) ,
            VALUE(SUM(VLCUSEMI),+0)
            INTO :V3HISP-PRM-TAR ,
            :V3HISP-VAL-DES ,
            :V3HISP-VLADIFRA ,
            :V3HISP-VLCUSEMI
            FROM SEGUROS.V0HISTOPARC
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND OCORHIST = 01
            AND OPERACAO < 0200
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO)
							,+0) 
							,
											VALUE(SUM(VAL_DESCONTO)
							,+0) 
							,
											VALUE(SUM(VLADIFRA)
							,+0) 
							,
											VALUE(SUM(VLCUSEMI)
							,+0)
											FROM SEGUROS.V0HISTOPARC
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND OCORHIST = 01
											AND OPERACAO < 0200";

            return query;
        }
        public string V3HISP_PRM_TAR { get; set; }
        public string V3HISP_VAL_DES { get; set; }
        public string V3HISP_VLADIFRA { get; set; }
        public string V3HISP_VLCUSEMI { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1 Execute(R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1 r2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SUM_V0HISTOPARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V3HISP_PRM_TAR = result[i++].Value?.ToString();
            dta.V3HISP_VAL_DES = result[i++].Value?.ToString();
            dta.V3HISP_VLADIFRA = result[i++].Value?.ToString();
            dta.V3HISP_VLCUSEMI = result[i++].Value?.ToString();
            return dta;
        }

    }
}