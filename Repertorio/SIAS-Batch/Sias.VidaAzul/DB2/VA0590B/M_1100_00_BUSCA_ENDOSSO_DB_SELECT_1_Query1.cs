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
    public class M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE (MAX ( NUM_ENDOSSO ), 0)
            INTO :HISCONPA-NUM-ENDOSSO
            FROM SEGUROS.HIST_CONT_PARCELVA
            WHERE NUM_PARCELA = :HISCONPA-NUM-PARCELA
            AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE (MAX ( NUM_ENDOSSO )
							, 0)
											FROM SEGUROS.HIST_CONT_PARCELVA
											WHERE NUM_PARCELA = '{this.HISCONPA_NUM_PARCELA}'
											AND NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 Execute(M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 m_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = m_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1100_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCONPA_NUM_ENDOSSO = result[i++].Value?.ToString();
            return dta;
        }

    }
}