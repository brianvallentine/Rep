using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0110_FETCH_DB_SELECT_1_Query1 : QueryBasis<M_0110_FETCH_DB_SELECT_1_Query1>
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
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND COD_OPERACAO = 101
											WITH UR";

            return query;
        }
        public string WHOST_DATA_MOVIMENTO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0110_FETCH_DB_SELECT_1_Query1 Execute(M_0110_FETCH_DB_SELECT_1_Query1 m_0110_FETCH_DB_SELECT_1_Query1)
        {
            var ths = m_0110_FETCH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0110_FETCH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0110_FETCH_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}