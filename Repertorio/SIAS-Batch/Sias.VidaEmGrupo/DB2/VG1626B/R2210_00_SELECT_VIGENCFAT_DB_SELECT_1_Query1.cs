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
    public class R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1 : QueryBasis<R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTA_INI_FATURA,
            DTA_FIM_FATURA,
            IND_PROCESSAMENTO
            INTO :VG083-DTA-INI-FATURA,
            :VG083-DTA-FIM-FATURA,
            :VG083-IND-PROCESSAMENTO
            FROM SEGUROS.VG_VIGENCIA_FATURA
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = 0
            AND SEQ_FATURAMENTO =
            (SELECT MAX(T1.SEQ_FATURAMENTO)
            FROM SEGUROS.VG_VIGENCIA_FATURA T1
            WHERE T1.NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND T1.COD_SUBGRUPO = 0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTA_INI_FATURA
							,
											DTA_FIM_FATURA
							,
											IND_PROCESSAMENTO
											FROM SEGUROS.VG_VIGENCIA_FATURA
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = 0
											AND SEQ_FATURAMENTO =
											(SELECT MAX(T1.SEQ_FATURAMENTO)
											FROM SEGUROS.VG_VIGENCIA_FATURA T1
											WHERE T1.NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND T1.COD_SUBGRUPO = 0)";

            return query;
        }
        public string VG083_DTA_INI_FATURA { get; set; }
        public string VG083_DTA_FIM_FATURA { get; set; }
        public string VG083_IND_PROCESSAMENTO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1 Execute(R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1 r2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1)
        {
            var ths = r2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG083_DTA_INI_FATURA = result[i++].Value?.ToString();
            dta.VG083_DTA_FIM_FATURA = result[i++].Value?.ToString();
            dta.VG083_IND_PROCESSAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}