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
    public class M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 : QueryBasis<M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :CONVER-NUM-SICOB
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :CONVER-NUM-PROPOSTA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.CONVER_NUM_PROPOSTA}'
											WITH UR";

            return query;
        }
        public string CONVER_NUM_SICOB { get; set; }
        public string CONVER_NUM_PROPOSTA { get; set; }

        public static M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 Execute(M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1)
        {
            var ths = m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVER_NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}