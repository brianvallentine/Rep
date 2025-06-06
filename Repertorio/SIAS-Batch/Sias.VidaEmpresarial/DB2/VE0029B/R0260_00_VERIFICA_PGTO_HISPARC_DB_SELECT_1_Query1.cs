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
    public class R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1 : QueryBasis<R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_APOLICE,
            NRENDOS,
            OPERACAO
            INTO :V1HISP-NUM-APOL,
            :V1HISP-NRENDOS,
            :V1HISP-OPERACAO
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V0PEND-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            AND OCORHIST = :V1PARC-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											NRENDOS
							,
											OPERACAO
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V0PEND_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											AND OCORHIST = '{this.V1PARC_OCORHIST}'";

            return query;
        }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }
        public string V1HISP_OPERACAO { get; set; }
        public string V0PEND_NUM_APOL { get; set; }
        public string V1PARC_OCORHIST { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1 Execute(R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1 r0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1)
        {
            var ths = r0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V1HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V1HISP_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}