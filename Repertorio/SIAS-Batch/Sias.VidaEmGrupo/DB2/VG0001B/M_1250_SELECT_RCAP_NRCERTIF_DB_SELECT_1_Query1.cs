using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1 : QueryBasis<M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE ,
            NUM_RCAP ,
            VAL_RCAP ,
            DATA_MOVIMENTO ,
            VALUE(AGE_COBRANCA, 0)
            INTO :RCAPS-COD-FONTE ,
            :RCAPS-NUM-RCAP ,
            :RCAPS-VAL-RCAP ,
            :RCAPS-DATA-MOVIMENTO,
            :RCAPS-AGE-COBRANCA
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE 
							,
											NUM_RCAP 
							,
											VAL_RCAP 
							,
											DATA_MOVIMENTO 
							,
											VALUE(AGE_COBRANCA
							, 0)
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RCAPS_NUM_CERTIFICADO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_DATA_MOVIMENTO { get; set; }
        public string RCAPS_AGE_COBRANCA { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1 Execute(M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1 m_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1)
        {
            var ths = m_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1250_SELECT_RCAP_NRCERTIF_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPS_AGE_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}