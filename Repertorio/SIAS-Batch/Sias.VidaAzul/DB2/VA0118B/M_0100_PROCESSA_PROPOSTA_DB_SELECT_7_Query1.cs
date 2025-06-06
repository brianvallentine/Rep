using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MIN(OCORHIST)
            INTO :V0COBER-MINOCOR
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MIN(OCORHIST)
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string V0COBER_MINOCOR { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1();
            var i = 0;
            dta.V0COBER_MINOCOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}