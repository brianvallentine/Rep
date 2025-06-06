using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1200_00_LER_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R1200_00_LER_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :V1PARC-OCORHIST
            FROM SEGUROS.V1PARCELA
            WHERE NUM_APOLICE = :V1EDIA-NUM-APOL
            AND NRENDOS = :V1EDIA-NRENDOS
            AND NRPARCEL = 0
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V1PARCELA
											WHERE NUM_APOLICE = '{this.V1EDIA_NUM_APOL}'
											AND NRENDOS = '{this.V1EDIA_NRENDOS}'
											AND NRPARCEL = 0
											AND SITUACAO = '0'";

            return query;
        }
        public string V1PARC_OCORHIST { get; set; }
        public string V1EDIA_NUM_APOL { get; set; }
        public string V1EDIA_NRENDOS { get; set; }

        public static R1200_00_LER_PARCELA_DB_SELECT_1_Query1 Execute(R1200_00_LER_PARCELA_DB_SELECT_1_Query1 r1200_00_LER_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_LER_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_LER_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_LER_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}