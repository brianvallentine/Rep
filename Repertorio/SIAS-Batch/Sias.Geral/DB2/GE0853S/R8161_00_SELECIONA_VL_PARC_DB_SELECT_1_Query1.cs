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
    public class R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1 : QueryBasis<R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO,
            PRM_TOTAL,
            SIT_REGISTRO
            INTO :WHOST-DT-VENC-PARC,
            :WHOST-VL-PRM-TOTAL,
            :WHOST-SIT-REGISTRO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF
            AND NUM_PARCELA = :WHOST-NUM-PARCELA-F
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO
							,
											PRM_TOTAL
							,
											SIT_REGISTRO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.V0HISC_NRCERTIF}'
											AND NUM_PARCELA = '{this.WHOST_NUM_PARCELA_F}'
											WITH UR";

            return query;
        }
        public string WHOST_DT_VENC_PARC { get; set; }
        public string WHOST_VL_PRM_TOTAL { get; set; }
        public string WHOST_SIT_REGISTRO { get; set; }
        public string WHOST_NUM_PARCELA_F { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1 Execute(R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1 r8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1)
        {
            var ths = r8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DT_VENC_PARC = result[i++].Value?.ToString();
            dta.WHOST_VL_PRM_TOTAL = result[i++].Value?.ToString();
            dta.WHOST_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}