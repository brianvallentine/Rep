using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0590B
{
    public class M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1 : QueryBasis<M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX ( NUM_PARCELA )
            INTO :HISCONPA-NUM-PARCELA
            FROM SEGUROS.HIST_CONT_PARCELVA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MAX ( NUM_PARCELA )
											FROM SEGUROS.HIST_CONT_PARCELVA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1 Execute(M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1 m_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = m_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0900_BUSCA_NUM_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}