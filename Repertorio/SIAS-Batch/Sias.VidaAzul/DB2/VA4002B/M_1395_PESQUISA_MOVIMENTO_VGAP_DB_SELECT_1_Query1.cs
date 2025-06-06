using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1 : QueryBasis<M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WS-COUNT-MOVIMENTO
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string WS_COUNT_MOVIMENTO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1 Execute(M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1 m_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1)
        {
            var ths = m_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNT_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}