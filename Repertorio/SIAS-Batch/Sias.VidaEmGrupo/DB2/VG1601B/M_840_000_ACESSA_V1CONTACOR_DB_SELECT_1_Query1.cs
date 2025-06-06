using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 : QueryBasis<M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE,
            NUM_APOLICE,
            COD_BANCO,
            COD_AGENCIA,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE
            INTO
            :OCOD-CLIENTE,
            :ONUM-APOLICE,
            :OCOD-BANCO,
            :OCOD-AGENCIA,
            :ONUM-CTA-CORRENTE,
            :ODAC-CTA-CORRENTE
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
											COD_BANCO
							,
											COD_AGENCIA
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
        public string OCOD_BANCO { get; set; }
        public string OCOD_AGENCIA { get; set; }
        public string ONUM_CTA_CORRENTE { get; set; }
        public string ODAC_CTA_CORRENTE { get; set; }

        public static M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 Execute(M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 m_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1)
        {
            var ths = m_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.OCOD_CLIENTE = result[i++].Value?.ToString();
            dta.ONUM_APOLICE = result[i++].Value?.ToString();
            dta.OCOD_BANCO = result[i++].Value?.ToString();
            dta.OCOD_AGENCIA = result[i++].Value?.ToString();
            dta.ONUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.ODAC_CTA_CORRENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}