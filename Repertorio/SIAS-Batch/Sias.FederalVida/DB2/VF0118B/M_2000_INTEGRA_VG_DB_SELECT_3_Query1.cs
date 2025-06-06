using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_2000_INTEGRA_VG_DB_SELECT_3_Query1 : QueryBasis<M_2000_INTEGRA_VG_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :FATURC-DTREF
            FROM SEGUROS.V0FATURCONT
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = 0
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.V0FATURCONT
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = 0";

            return query;
        }
        public string FATURC_DTREF { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }

        public static M_2000_INTEGRA_VG_DB_SELECT_3_Query1 Execute(M_2000_INTEGRA_VG_DB_SELECT_3_Query1 m_2000_INTEGRA_VG_DB_SELECT_3_Query1)
        {
            var ths = m_2000_INTEGRA_VG_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2000_INTEGRA_VG_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2000_INTEGRA_VG_DB_SELECT_3_Query1();
            var i = 0;
            dta.FATURC_DTREF = result[i++].Value?.ToString();
            return dta;
        }

    }
}