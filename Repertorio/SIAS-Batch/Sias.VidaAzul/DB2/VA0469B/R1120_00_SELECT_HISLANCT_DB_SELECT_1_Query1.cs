using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1 : QueryBasis<R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_HISTORICOCTA),0)
            INTO :WS-OCORR-HISTORICOCTA
            FROM SEGUROS.HIST_LANC_CTA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND SIT_REGISTRO = ' '
            AND TIPLANC = '2'
            AND CODCONV = :WS-COD-CONVENIO
            AND (NSAS IS NULL
            OR NSAS = 0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_HISTORICOCTA)
							,0)
											FROM SEGUROS.HIST_LANC_CTA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND SIT_REGISTRO = ' '
											AND TIPLANC = '2'
											AND CODCONV = '{this.WS_COD_CONVENIO}'
											AND (NSAS IS NULL
											OR NSAS = 0)";

            return query;
        }
        public string WS_OCORR_HISTORICOCTA { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string WS_COD_CONVENIO { get; set; }

        public static R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1 Execute(R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1 r1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1)
        {
            var ths = r1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_OCORR_HISTORICOCTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}