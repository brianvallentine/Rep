using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1 : QueryBasis<M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPSEGCDG,
            VLCUSTCDG
            INTO :HOST-IMPSEGCDG,
            :HOST-VLCUSTCDG
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = 97010000889
            AND CODSUBES = 3603
            AND OPCAO_COBER = 'A'
            AND IDADE_INICIAL = 16
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPSEGCDG
							,
											VLCUSTCDG
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = 97010000889
											AND CODSUBES = 3603
											AND OPCAO_COBER = 'A'
											AND IDADE_INICIAL = 16
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string HOST_IMPSEGCDG { get; set; }
        public string HOST_VLCUSTCDG { get; set; }

        public static M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1 Execute(M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1 m_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1)
        {
            var ths = m_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0889_SELECT_V1SISTEMA_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_IMPSEGCDG = result[i++].Value?.ToString();
            dta.HOST_VLCUSTCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}