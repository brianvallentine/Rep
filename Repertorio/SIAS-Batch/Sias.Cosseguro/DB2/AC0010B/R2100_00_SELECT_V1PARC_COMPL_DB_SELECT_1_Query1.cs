using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLR_COMPLEMENT_IX,
            VLR_COMPLEMENTO
            INTO :V1PCOM-VLR-COMPL-IX,
            :V1PCOM-VLR-COMPL
            FROM SEGUROS.V1PARCELA_COMPL
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND NRPARCEL = :V1HISP-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLR_COMPLEMENT_IX
							,
											VLR_COMPLEMENTO
											FROM SEGUROS.V1PARCELA_COMPL
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND NRPARCEL = '{this.V1HISP_NRPARCEL}'";

            return query;
        }
        public string V1PCOM_VLR_COMPL_IX { get; set; }
        public string V1PCOM_VLR_COMPL { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1 r2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_V1PARC_COMPL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PCOM_VLR_COMPL_IX = result[i++].Value?.ToString();
            dta.V1PCOM_VLR_COMPL = result[i++].Value?.ToString();
            return dta;
        }

    }
}