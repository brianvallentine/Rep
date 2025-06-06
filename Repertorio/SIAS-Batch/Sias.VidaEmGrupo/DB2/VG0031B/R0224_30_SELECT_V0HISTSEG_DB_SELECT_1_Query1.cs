using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1 : QueryBasis<R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO,
            COD_MOEDA_IMP,
            COD_MOEDA_PRM
            INTO :V1HSEG-DT-MOVTO,
            :V1HSEG-MOEDA-IMP,
            :V1HSEG-MOEDA-PRM
            FROM SEGUROS.V1HISTSEGVG
            WHERE NUM_APOLICE = :V0SEG-NUM-APOL
            AND NUM_ITEM = :V0SEG-NUM-ITEM
            AND OCORR_HISTORICO = :V0SEG-OCORR-HIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
							,
											COD_MOEDA_IMP
							,
											COD_MOEDA_PRM
											FROM SEGUROS.V1HISTSEGVG
											WHERE NUM_APOLICE = '{this.V0SEG_NUM_APOL}'
											AND NUM_ITEM = '{this.V0SEG_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.V0SEG_OCORR_HIST}'";

            return query;
        }
        public string V1HSEG_DT_MOVTO { get; set; }
        public string V1HSEG_MOEDA_IMP { get; set; }
        public string V1HSEG_MOEDA_PRM { get; set; }
        public string V0SEG_OCORR_HIST { get; set; }
        public string V0SEG_NUM_APOL { get; set; }
        public string V0SEG_NUM_ITEM { get; set; }

        public static R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1 Execute(R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1 r0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1)
        {
            var ths = r0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0224_30_SELECT_V0HISTSEG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1HSEG_DT_MOVTO = result[i++].Value?.ToString();
            dta.V1HSEG_MOEDA_IMP = result[i++].Value?.ToString();
            dta.V1HSEG_MOEDA_PRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}