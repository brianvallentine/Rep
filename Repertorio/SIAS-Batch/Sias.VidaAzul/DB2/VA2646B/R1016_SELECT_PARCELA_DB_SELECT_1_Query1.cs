using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1016_SELECT_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R1016_SELECT_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PREMIO_VG
            , PREMIO_AP
            , SIT_REGISTRO
            INTO :PARCEVID-PREMIO-VG
            ,:PARCEVID-PREMIO-AP
            ,:PARCEVID-SIT-REGISTRO
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PREMIO_VG
											, PREMIO_AP
											, SIT_REGISTRO
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'";

            return query;
        }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PARCEVID_PREMIO_AP { get; set; }
        public string PARCEVID_SIT_REGISTRO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1016_SELECT_PARCELA_DB_SELECT_1_Query1 Execute(R1016_SELECT_PARCELA_DB_SELECT_1_Query1 r1016_SELECT_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r1016_SELECT_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1016_SELECT_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1016_SELECT_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEVID_PREMIO_VG = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_AP = result[i++].Value?.ToString();
            dta.PARCEVID_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}