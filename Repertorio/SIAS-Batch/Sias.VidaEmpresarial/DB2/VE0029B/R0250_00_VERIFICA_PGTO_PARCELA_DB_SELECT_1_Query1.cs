using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0029B
{
    public class R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_APOLICE,
            NRENDOS,
            SITUACAO,
            OCORHIST
            INTO :V1PARC-NUM-APOL,
            :V1PARC-NRENDOS,
            :V1PARC-SITUACAO,
            :V1PARC-OCORHIST
            FROM SEGUROS.V1PARCELA
            WHERE NUM_APOLICE = :V0PEND-NUM-APOL
            AND NRENDOS = :V0PEND-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											NRENDOS
							,
											SITUACAO
							,
											OCORHIST
											FROM SEGUROS.V1PARCELA
											WHERE NUM_APOLICE = '{this.V0PEND_NUM_APOL}'
											AND NRENDOS = '{this.V0PEND_NRENDOS}'";

            return query;
        }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }
        public string V1PARC_SITUACAO { get; set; }
        public string V1PARC_OCORHIST { get; set; }
        public string V0PEND_NUM_APOL { get; set; }
        public string V0PEND_NRENDOS { get; set; }

        public static R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1 Execute(R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1 r0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_NUM_APOL = result[i++].Value?.ToString();
            dta.V1PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V1PARC_SITUACAO = result[i++].Value?.ToString();
            dta.V1PARC_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}