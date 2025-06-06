using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1 : QueryBasis<R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_INCLUSAO,
            COD_AGENCIADOR,
            NUM_ITEM,
            OCORR_HISTORICO,
            LOT_EMP_SEGURADO
            INTO :V0SEGU-TPINCLUS,
            :V0SEGU-AGENCIADOR,
            :V0SEGU-ITEM,
            :V0SEGU-OCORHIST,
            :V0SEGU-LOT-EMP-SEGURADO :VIND-LOT-EMP-SEG
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_INCLUSAO
							,
											COD_AGENCIADOR
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
							,
											LOT_EMP_SEGURADO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.HISLANCT_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string V0SEGU_TPINCLUS { get; set; }
        public string V0SEGU_AGENCIADOR { get; set; }
        public string V0SEGU_ITEM { get; set; }
        public string V0SEGU_OCORHIST { get; set; }
        public string V0SEGU_LOT_EMP_SEGURADO { get; set; }
        public string VIND_LOT_EMP_SEG { get; set; }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }

        public static R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1 Execute(R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1 r7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1)
        {
            var ths = r7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7020_00_SELECT_SEGURADO_VG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SEGU_TPINCLUS = result[i++].Value?.ToString();
            dta.V0SEGU_AGENCIADOR = result[i++].Value?.ToString();
            dta.V0SEGU_ITEM = result[i++].Value?.ToString();
            dta.V0SEGU_OCORHIST = result[i++].Value?.ToString();
            dta.V0SEGU_LOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.VIND_LOT_EMP_SEG = string.IsNullOrWhiteSpace(dta.V0SEGU_LOT_EMP_SEGURADO) ? "-1" : "0";
            return dta;
        }

    }
}