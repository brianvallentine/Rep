using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1 : QueryBasis<R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_SUBGRUPO,
            SEQ_FATURAMENTO,
            DTA_INI_FATURA,
            DTA_VENC_FATURA + 18 DAYS,
            IND_PROCESSAMENTO
            INTO :VG083-NUM-APOLICE,
            :VG083-COD-SUBGRUPO,
            :VG083-SEQ-FATURAMENTO,
            :VG083-DTA-INI-FATURA,
            :VG083-DTA-VENC-FATURA,
            :VG083-IND-PROCESSAMENTO
            FROM SEGUROS.VG_VIGENCIA_FATURA
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = 0
            AND SEQ_FATURAMENTO =
            (SELECT MAX(T1.SEQ_FATURAMENTO)
            FROM SEGUROS.VG_VIGENCIA_FATURA T1
            WHERE T1.NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND T1.COD_SUBGRUPO = 0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											SEQ_FATURAMENTO
							,
											DTA_INI_FATURA
							,
											DTA_VENC_FATURA + 18 DAYS
							,
											IND_PROCESSAMENTO
											FROM SEGUROS.VG_VIGENCIA_FATURA
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = 0
											AND SEQ_FATURAMENTO =
											(SELECT MAX(T1.SEQ_FATURAMENTO)
											FROM SEGUROS.VG_VIGENCIA_FATURA T1
											WHERE T1.NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND T1.COD_SUBGRUPO = 0)";

            return query;
        }
        public string VG083_NUM_APOLICE { get; set; }
        public string VG083_COD_SUBGRUPO { get; set; }
        public string VG083_SEQ_FATURAMENTO { get; set; }
        public string VG083_DTA_INI_FATURA { get; set; }
        public string VG083_DTA_VENC_FATURA { get; set; }
        public string VG083_IND_PROCESSAMENTO { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }

        public static R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1 Execute(R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1 r6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1)
        {
            var ths = r6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG083_NUM_APOLICE = result[i++].Value?.ToString();
            dta.VG083_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.VG083_SEQ_FATURAMENTO = result[i++].Value?.ToString();
            dta.VG083_DTA_INI_FATURA = result[i++].Value?.ToString();
            dta.VG083_DTA_VENC_FATURA = result[i++].Value?.ToString();
            dta.VG083_IND_PROCESSAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}