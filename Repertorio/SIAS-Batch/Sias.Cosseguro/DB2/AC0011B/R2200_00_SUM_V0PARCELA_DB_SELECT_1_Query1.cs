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
    public class R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_TARIFARIO_IX),+0) ,
            VALUE(SUM(VAL_DESCONTO_IX),+0) ,
            VALUE(SUM(OTNADFRA),+0) ,
            VALUE(SUM(OTNCUSTO),+0)
            INTO :V3PARC-PRM-TAR ,
            :V3PARC-VAL-DES ,
            :V3PARC-OTNADFRA ,
            :V3PARC-OTNCUSTO
            FROM SEGUROS.V0PARCELA
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO_IX)
							,+0) 
							,
											VALUE(SUM(VAL_DESCONTO_IX)
							,+0) 
							,
											VALUE(SUM(OTNADFRA)
							,+0) 
							,
											VALUE(SUM(OTNCUSTO)
							,+0)
											FROM SEGUROS.V0PARCELA
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'";

            return query;
        }
        public string V3PARC_PRM_TAR { get; set; }
        public string V3PARC_VAL_DES { get; set; }
        public string V3PARC_OTNADFRA { get; set; }
        public string V3PARC_OTNCUSTO { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1 Execute(R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1 r2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SUM_V0PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V3PARC_PRM_TAR = result[i++].Value?.ToString();
            dta.V3PARC_VAL_DES = result[i++].Value?.ToString();
            dta.V3PARC_OTNADFRA = result[i++].Value?.ToString();
            dta.V3PARC_OTNCUSTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}