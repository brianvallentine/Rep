using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO ,
            NUM_PARCELA,
            SIT_REGISTRO,
            PREMIO_VG + PREMIO_AP,
            DATE(DATA_VENCIMENTO)
            + :SUBGVGAP-PERI-FATURAMENTO MONTHS
            INTO :WHOST-DATA-VENCIMENTO ,
            :WHOST-NUM-PARCELA,
            :WHOST-SIT-PARCELA,
            :PARCEVID-PREMIO-VG,
            :PROPOVA-DTPROXVEN
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            ORDER BY NUM_PARCELA DESC
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO 
							,
											NUM_PARCELA
							,
											SIT_REGISTRO
							,
											PREMIO_VG + PREMIO_AP
							,
											DATE(DATA_VENCIMENTO)
											+ {this.SUBGVGAP_PERI_FATURAMENTO} MONTHS
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											ORDER BY NUM_PARCELA DESC
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string WHOST_DATA_VENCIMENTO { get; set; }
        public string WHOST_NUM_PARCELA { get; set; }
        public string WHOST_SIT_PARCELA { get; set; }
        public string PARCEVID_PREMIO_VG { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.WHOST_NUM_PARCELA = result[i++].Value?.ToString();
            dta.WHOST_SIT_PARCELA = result[i++].Value?.ToString();
            dta.PARCEVID_PREMIO_VG = result[i++].Value?.ToString();
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}