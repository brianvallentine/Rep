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
    public class M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1 : QueryBasis<M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-COUNTRCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO =:PROPVA-NRCERTIF
            AND COD_OPERACAO <> 210
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO ='{this.PROPVA_NRCERTIF}'
											AND COD_OPERACAO <> 210
											WITH UR";

            return query;
        }
        public string WS_COUNTRCAP { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1 Execute(M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1 m_2010_VERIFICA_RCAP_DB_SELECT_1_Query1)
        {
            var ths = m_2010_VERIFICA_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNTRCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}