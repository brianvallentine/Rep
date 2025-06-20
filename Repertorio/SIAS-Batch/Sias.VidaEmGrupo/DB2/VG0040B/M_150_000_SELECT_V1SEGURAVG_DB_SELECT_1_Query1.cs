using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0040B
{
    public class M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_HISTORICO,
            NUM_ITEM,
            DATA_INIVIGENCIA + 1 YEAR - 1 DAY,
            DATA_ADMISSAO,
            SIT_REGISTRO
            INTO :SOCORR-HISTORICO,
            :SNUM-ITEM,
            :SDATA-TERVIGENCIA:WDATA-TERVIGENCIA,
            :SDATA-DTTERVIG:WDATA-DTTERVIG,
            :SSIT-REGISTRO
            FROM SEGUROS.V1SEGURAVG
            WHERE
            NUM_CERTIFICADO = :MNUM-CERTIFICADO
            AND TIPO_SEGURADO = :MTIPO-SEGURADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_HISTORICO
							,
											NUM_ITEM
							,
											DATA_INIVIGENCIA + 1 YEAR - 1 DAY
							,
											DATA_ADMISSAO
							,
											SIT_REGISTRO
											FROM SEGUROS.V1SEGURAVG
											WHERE
											NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string SOCORR_HISTORICO { get; set; }
        public string SNUM_ITEM { get; set; }
        public string SDATA_TERVIGENCIA { get; set; }
        public string WDATA_TERVIGENCIA { get; set; }
        public string SDATA_DTTERVIG { get; set; }
        public string WDATA_DTTERVIG { get; set; }
        public string SSIT_REGISTRO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }

        public static M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 Execute(M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 m_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SOCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SNUM_ITEM = result[i++].Value?.ToString();
            dta.SDATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WDATA_TERVIGENCIA = string.IsNullOrWhiteSpace(dta.SDATA_TERVIGENCIA) ? "-1" : "0";
            dta.SDATA_DTTERVIG = result[i++].Value?.ToString();
            dta.WDATA_DTTERVIG = string.IsNullOrWhiteSpace(dta.SDATA_DTTERVIG) ? "-1" : "0";
            dta.SSIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}