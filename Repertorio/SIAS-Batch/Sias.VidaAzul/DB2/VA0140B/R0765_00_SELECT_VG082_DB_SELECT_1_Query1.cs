using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0765_00_SELECT_VG082_DB_SELECT_1_Query1 : QueryBasis<R0765_00_SELECT_VG082_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            ,SUM(VLR_PREMIO_RAMO)
            INTO :WHOST-COUNT:VIND-COUNT
            ,:VG082-VLR-PREMIO-RAMO:VIND-VALOR
            FROM SEGUROS.VG_HIST_CONT_COBER
            WHERE NUM_CERTIFICADO = :VG082-NUM-CERTIFICADO
            AND NUM_PARCELA = :VG082-NUM-PARCELA
            AND NUM_TITULO = :VG082-NUM-TITULO
            AND OCORR_HISTORICO = :VG082-OCORR-HISTORICO
            AND VLR_PREMIO_RAMO > 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											,SUM(VLR_PREMIO_RAMO)
											FROM SEGUROS.VG_HIST_CONT_COBER
											WHERE NUM_CERTIFICADO = '{this.VG082_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.VG082_NUM_PARCELA}'
											AND NUM_TITULO = '{this.VG082_NUM_TITULO}'
											AND OCORR_HISTORICO = '{this.VG082_OCORR_HISTORICO}'
											AND VLR_PREMIO_RAMO > 0
											WITH UR";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string VIND_COUNT { get; set; }
        public string VG082_VLR_PREMIO_RAMO { get; set; }
        public string VIND_VALOR { get; set; }
        public string VG082_NUM_CERTIFICADO { get; set; }
        public string VG082_OCORR_HISTORICO { get; set; }
        public string VG082_NUM_PARCELA { get; set; }
        public string VG082_NUM_TITULO { get; set; }

        public static R0765_00_SELECT_VG082_DB_SELECT_1_Query1 Execute(R0765_00_SELECT_VG082_DB_SELECT_1_Query1 r0765_00_SELECT_VG082_DB_SELECT_1_Query1)
        {
            var ths = r0765_00_SELECT_VG082_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0765_00_SELECT_VG082_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0765_00_SELECT_VG082_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.WHOST_COUNT) ? "-1" : "0";
            dta.VG082_VLR_PREMIO_RAMO = result[i++].Value?.ToString();
            dta.VIND_VALOR = string.IsNullOrWhiteSpace(dta.VG082_VLR_PREMIO_RAMO) ? "-1" : "0";
            return dta;
        }

    }
}