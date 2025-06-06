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
    public class R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 : QueryBasis<R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRM_TARIFARIO_IX ,
            VAL_DESCONTO_IX ,
            OTNADFRA
            INTO :V1PARC-PRM-TAR ,
            :V1PARC-VAL-DES ,
            :V1PARC-OTNADFRA
            FROM SEGUROS.V1PARCELA
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND NRPARCEL = :V1HISP-NRPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRM_TARIFARIO_IX 
							,
											VAL_DESCONTO_IX 
							,
											OTNADFRA
											FROM SEGUROS.V1PARCELA
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND NRPARCEL = '{this.V1HISP_NRPARCEL}'";

            return query;
        }
        public string V1PARC_PRM_TAR { get; set; }
        public string V1PARC_VAL_DES { get; set; }
        public string V1PARC_OTNADFRA { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 Execute(R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 r1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1900_00_SELECT_V1PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_PRM_TAR = result[i++].Value?.ToString();
            dta.V1PARC_VAL_DES = result[i++].Value?.ToString();
            dta.V1PARC_OTNADFRA = result[i++].Value?.ToString();
            return dta;
        }

    }
}