using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1 : QueryBasis<M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD
            INTO :DVLCRUZAD-PRM
            FROM SEGUROS.V1MOEDA
            WHERE
            CODUNIMO = :ECOD-MOEDA-PRM AND
            DTINIVIG <= :R-DATA-AUMENTO AND
            DTTERVIG >= :R-DATA-AUMENTO AND
            SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE
											CODUNIMO = '{this.ECOD_MOEDA_PRM}' AND
											DTINIVIG <= '{this.R_DATA_AUMENTO}' AND
											DTTERVIG >= '{this.R_DATA_AUMENTO}' AND
											SITUACAO = '0'";

            return query;
        }
        public string DVLCRUZAD_PRM { get; set; }
        public string ECOD_MOEDA_PRM { get; set; }
        public string R_DATA_AUMENTO { get; set; }

        public static M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1 Execute(M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1 m_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1)
        {
            var ths = m_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_270_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1();
            var i = 0;
            dta.DVLCRUZAD_PRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}