using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0130B
{
    public class M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 : QueryBasis<M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE,
            NUM_APOLICE,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE
            INTO
            :OCOD-CLIENTE,
            :ONUM-APOLICE,
            :NUM-CTA-CORRENTE,
            :DAC-CTA-CORRENTE
            FROM
            SEGUROS.V1CONTACOR
            WHERE
            COD_CLIENTE = :OCOD-CLIENTE AND
            NUM_APOLICE = :ONUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE
							,
											NUM_APOLICE
							,
											NUM_CTA_CORRENTE
							,
											DAC_CTA_CORRENTE
											FROM
											SEGUROS.V1CONTACOR
											WHERE
											COD_CLIENTE = '{this.OCOD_CLIENTE}' AND
											NUM_APOLICE = '{this.ONUM_APOLICE}'";

            return query;
        }
        public string OCOD_CLIENTE { get; set; }
        public string ONUM_APOLICE { get; set; }
        public string NUM_CTA_CORRENTE { get; set; }
        public string DAC_CTA_CORRENTE { get; set; }

        public static M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 Execute(M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 m_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1)
        {
            var ths = m_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_320_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.OCOD_CLIENTE = result[i++].Value?.ToString();
            dta.ONUM_APOLICE = result[i++].Value?.ToString();
            dta.NUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.DAC_CTA_CORRENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}