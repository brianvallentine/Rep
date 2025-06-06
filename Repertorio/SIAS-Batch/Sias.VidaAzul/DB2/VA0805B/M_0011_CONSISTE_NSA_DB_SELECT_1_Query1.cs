using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0805B
{
    public class M_0011_CONSISTE_NSA_DB_SELECT_1_Query1 : QueryBasis<M_0011_CONSISTE_NSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAC,
            DATA_GERACAO
            INTO :FITCEF-NSAC,
            :FITCEF-DATA-GERACAO
            FROM SEGUROS.V0FITACEF
            WHERE NSAC = :FITCEF-NSA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NSAC
							,
											DATA_GERACAO
											FROM SEGUROS.V0FITACEF
											WHERE NSAC = '{this.FITCEF_NSA}'
											WITH UR";

            return query;
        }
        public string FITCEF_NSAC { get; set; }
        public string FITCEF_DATA_GERACAO { get; set; }
        public string FITCEF_NSA { get; set; }

        public static M_0011_CONSISTE_NSA_DB_SELECT_1_Query1 Execute(M_0011_CONSISTE_NSA_DB_SELECT_1_Query1 m_0011_CONSISTE_NSA_DB_SELECT_1_Query1)
        {
            var ths = m_0011_CONSISTE_NSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0011_CONSISTE_NSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0011_CONSISTE_NSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.FITCEF_NSAC = result[i++].Value?.ToString();
            dta.FITCEF_DATA_GERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}