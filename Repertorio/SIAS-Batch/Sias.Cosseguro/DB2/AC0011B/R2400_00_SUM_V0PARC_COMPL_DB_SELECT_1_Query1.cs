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
    public class R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(VLR_COMPLEMENT_IX),+0) ,
            VALUE(SUM(VLR_COMPLEMENTO),+0)
            INTO :V2PCOM-VLR-COMPL-IX ,
            :V2PCOM-VLR-COMPL
            FROM SEGUROS.V0PARCELA_COMPL
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(VLR_COMPLEMENT_IX)
							,+0) 
							,
											VALUE(SUM(VLR_COMPLEMENTO)
							,+0)
											FROM SEGUROS.V0PARCELA_COMPL
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'";

            return query;
        }
        public string V2PCOM_VLR_COMPL_IX { get; set; }
        public string V2PCOM_VLR_COMPL { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1 Execute(R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1 r2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V2PCOM_VLR_COMPL_IX = result[i++].Value?.ToString();
            dta.V2PCOM_VLR_COMPL = result[i++].Value?.ToString();
            return dta;
        }

    }
}