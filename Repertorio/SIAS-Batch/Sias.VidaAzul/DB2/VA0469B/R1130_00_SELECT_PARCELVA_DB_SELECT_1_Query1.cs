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
    public class R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1 : QueryBasis<R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO,
            PREMIO_VG,
            PREMIO_AP,
            OCORR_HISTORICO,
            PREMIO_VG + PREMIO_AP
            INTO :PARCEVID-DATA-VENCIMENTO,
            :PARCEVID-PREMIO-VG,
            :PARCEVID-PREMIO-AP,
            :PARCEVID-OCORR-HISTORICO,
            :COBHISVI-PRM-TOTAL
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO
							,
											PREMIO_VG
							,
											PREMIO_AP
							,
											OCORR_HISTORICO
							,
											PREMIO_VG + PREMIO_AP
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'";

            return query;
        }
        public string PARCEVID_DATA_VENCIMENTO { get; set; }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PARCEVID_PREMIO_AP { get; set; }
        public string PARCEVID_OCORR_HISTORICO { get; set; }
        public string COBHISVI_PRM_TOTAL { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1 Execute(R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1 r1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1)
        {
            var ths = r1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEVID_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_VG = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_AP = result[i++].Value?.ToString();
            dta.PARCEVID_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.COBHISVI_PRM_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}