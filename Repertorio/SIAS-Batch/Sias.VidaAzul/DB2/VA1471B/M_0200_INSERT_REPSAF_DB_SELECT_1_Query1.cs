using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1471B
{
    public class M_0200_INSERT_REPSAF_DB_SELECT_1_Query1 : QueryBasis<M_0200_INSERT_REPSAF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_MOVIMENTO
            INTO :MOVIMEA-TIPO-MOVIMENTO
            FROM SEGUROS.MOVIMENTO_EA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NSAS = :CONARQEA-NSAS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_MOVIMENTO
											FROM SEGUROS.MOVIMENTO_EA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NSAS = '{this.CONARQEA_NSAS}'";

            return query;
        }
        public string MOVIMEA_TIPO_MOVIMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string CONARQEA_NSAS { get; set; }

        public static M_0200_INSERT_REPSAF_DB_SELECT_1_Query1 Execute(M_0200_INSERT_REPSAF_DB_SELECT_1_Query1 m_0200_INSERT_REPSAF_DB_SELECT_1_Query1)
        {
            var ths = m_0200_INSERT_REPSAF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0200_INSERT_REPSAF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0200_INSERT_REPSAF_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMEA_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}