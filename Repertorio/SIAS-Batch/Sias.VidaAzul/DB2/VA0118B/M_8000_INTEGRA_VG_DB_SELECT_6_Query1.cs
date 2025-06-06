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
    public class M_8000_INTEGRA_VG_DB_SELECT_6_Query1 : QueryBasis<M_8000_INTEGRA_VG_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO
            INTO :WHOST-DATA-MOVIMENTO
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND COD_OPERACAO = 101
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND COD_OPERACAO = 101
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WHOST_DATA_MOVIMENTO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_8000_INTEGRA_VG_DB_SELECT_6_Query1 Execute(M_8000_INTEGRA_VG_DB_SELECT_6_Query1 m_8000_INTEGRA_VG_DB_SELECT_6_Query1)
        {
            var ths = m_8000_INTEGRA_VG_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8000_INTEGRA_VG_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8000_INTEGRA_VG_DB_SELECT_6_Query1();
            var i = 0;
            dta.WHOST_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}