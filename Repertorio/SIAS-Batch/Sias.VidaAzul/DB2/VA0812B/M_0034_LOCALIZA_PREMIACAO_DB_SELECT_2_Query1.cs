using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1 : QueryBasis<M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :CAMP-SITUACAO
            FROM SEGUROS.V0CAMPMULTGER
            WHERE NSAS = :MVCOM-NSAS
            AND NSL = :MVCOM-NSL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0CAMPMULTGER
											WHERE NSAS = '{this.MVCOM_NSAS}'
											AND NSL = '{this.MVCOM_NSL}'
											WITH UR";

            return query;
        }
        public string CAMP_SITUACAO { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }

        public static M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1 Execute(M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1 m_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1)
        {
            var ths = m_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0034_LOCALIZA_PREMIACAO_DB_SELECT_2_Query1();
            var i = 0;
            dta.CAMP_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}