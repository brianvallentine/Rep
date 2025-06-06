using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1 : QueryBasis<R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SIT_REGISTRO
            , PREMIO_VG
            , PREMIO_AP
            INTO
            :HISCONPA-SIT-REGISTRO
            ,:HISCONPA-PREMIO-VG
            ,:HISCONPA-PREMIO-AP
            FROM SEGUROS.HIST_CONT_PARCELVA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND SIT_REGISTRO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SIT_REGISTRO
											, PREMIO_VG
											, PREMIO_AP
											FROM SEGUROS.HIST_CONT_PARCELVA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND SIT_REGISTRO = '1'";

            return query;
        }
        public string HISCONPA_SIT_REGISTRO { get; set; }
        public string HISCONPA_PREMIO_VG { get; set; }
        public string HISCONPA_PREMIO_AP { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1 Execute(R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1 r1401_00_SELECT_HISTCON_DB_SELECT_1_Query1)
        {
            var ths = r1401_00_SELECT_HISTCON_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCONPA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.HISCONPA_PREMIO_VG = result[i++].Value?.ToString();
            dta.HISCONPA_PREMIO_AP = result[i++].Value?.ToString();
            return dta;
        }

    }
}