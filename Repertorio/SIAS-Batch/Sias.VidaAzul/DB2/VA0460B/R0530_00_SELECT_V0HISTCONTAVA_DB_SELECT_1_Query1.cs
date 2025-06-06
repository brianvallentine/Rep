using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1 : QueryBasis<R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_USUARIO
            INTO :HISLANCT-COD-USUARIO
            FROM SEGUROS.HIST_LANC_CTA A,
            SEGUROS.PARCELAS_VIDAZUL B
            WHERE A.NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :COBHISVI-NUM-PARCELA
            AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            AND A.OCORR_HISTORICOCTA = B.OCORR_HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_USUARIO
											FROM SEGUROS.HIST_LANC_CTA A
							,
											SEGUROS.PARCELAS_VIDAZUL B
											WHERE A.NUM_CERTIFICADO = '{this.COBHISVI_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.COBHISVI_NUM_PARCELA}'
											AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO
											AND A.NUM_PARCELA = B.NUM_PARCELA
											AND A.OCORR_HISTORICOCTA = B.OCORR_HISTORICO";

            return query;
        }
        public string HISLANCT_COD_USUARIO { get; set; }
        public string COBHISVI_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_PARCELA { get; set; }

        public static R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1 Execute(R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1 r0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1)
        {
            var ths = r0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}