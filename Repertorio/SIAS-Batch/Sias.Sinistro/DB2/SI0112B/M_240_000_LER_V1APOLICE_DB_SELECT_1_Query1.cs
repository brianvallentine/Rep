using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1 : QueryBasis<M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME,
            MODALIDA,
            CODCLIEN,
            PODPUBL
            INTO :APOL-NOME,
            :APOL-MODALIDA,
            :APOL-CODCLIEN,
            :APOL-PODPUBL
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :MEST-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME
							,
											MODALIDA
							,
											CODCLIEN
							,
											PODPUBL
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.MEST_NUM_APOL}'";

            return query;
        }
        public string APOL_NOME { get; set; }
        public string APOL_MODALIDA { get; set; }
        public string APOL_CODCLIEN { get; set; }
        public string APOL_PODPUBL { get; set; }
        public string MEST_NUM_APOL { get; set; }

        public static M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1 Execute(M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1 m_240_000_LER_V1APOLICE_DB_SELECT_1_Query1)
        {
            var ths = m_240_000_LER_V1APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOL_NOME = result[i++].Value?.ToString();
            dta.APOL_MODALIDA = result[i++].Value?.ToString();
            dta.APOL_CODCLIEN = result[i++].Value?.ToString();
            dta.APOL_PODPUBL = result[i++].Value?.ToString();
            return dta;
        }

    }
}