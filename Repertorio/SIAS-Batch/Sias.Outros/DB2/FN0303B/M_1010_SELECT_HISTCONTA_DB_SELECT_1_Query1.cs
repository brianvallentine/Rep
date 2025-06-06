using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0303B
{
    public class M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1 : QueryBasis<M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO,
            CODRET
            INTO :SITUACAO-LANC,
            :CODRET:VIND-CODRET
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :NRCERTIF
            AND NRPARCEL = :NRPARCEL
            AND OCORRHISTCTA = :OCORHIST
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
							,
											CODRET
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.NRCERTIF}'
											AND NRPARCEL = '{this.NRPARCEL}'
											AND OCORRHISTCTA = '{this.OCORHIST}'
											WITH UR";

            return query;
        }
        public string SITUACAO_LANC { get; set; }
        public string CODRET { get; set; }
        public string VIND_CODRET { get; set; }
        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }
        public string OCORHIST { get; set; }

        public static M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1 Execute(M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1 m_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1)
        {
            var ths = m_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1010_SELECT_HISTCONTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SITUACAO_LANC = result[i++].Value?.ToString();
            dta.CODRET = result[i++].Value?.ToString();
            dta.VIND_CODRET = string.IsNullOrWhiteSpace(dta.CODRET) ? "-1" : "0";
            return dta;
        }

    }
}