using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0120B
{
    public class M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTA_INI_FATURA,
            DTA_FIM_FATURA
            INTO :VG083-DTA-INI-FATURA,
            :VG083-DTA-FIM-FATURA
            FROM SEGUROS.VG_VIGENCIA_FATURA
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND COD_SUBGRUPO = 0
            AND SEQ_FATURAMENTO =
            (SELECT MAX(T1.SEQ_FATURAMENTO)
            FROM SEGUROS.VG_VIGENCIA_FATURA T1
            WHERE T1.NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND T1.COD_SUBGRUPO = 0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTA_INI_FATURA
							,
											DTA_FIM_FATURA
											FROM SEGUROS.VG_VIGENCIA_FATURA
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND COD_SUBGRUPO = 0
											AND SEQ_FATURAMENTO =
											(SELECT MAX(T1.SEQ_FATURAMENTO)
											FROM SEGUROS.VG_VIGENCIA_FATURA T1
											WHERE T1.NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND T1.COD_SUBGRUPO = 0)";

            return query;
        }
        public string VG083_DTA_INI_FATURA { get; set; }
        public string VG083_DTA_FIM_FATURA { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }

        public static M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1 Execute(M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1 m_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = m_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0040_030_BUSCA_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG083_DTA_INI_FATURA = result[i++].Value?.ToString();
            dta.VG083_DTA_FIM_FATURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}