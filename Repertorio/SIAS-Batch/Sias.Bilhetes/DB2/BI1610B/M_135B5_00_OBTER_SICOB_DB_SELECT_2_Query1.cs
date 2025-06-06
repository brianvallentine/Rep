using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1 : QueryBasis<M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO,
            NUM_TITULO_MAX
            INTO :DCLCEDENTE.CEDENTE-NUM-TITULO,
            :DCLCEDENTE.CEDENTE-NUM-TITULO-MAX
            FROM SEGUROS.CEDENTE
            WHERE COD_CEDENTE = 026
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
							,
											NUM_TITULO_MAX
											FROM SEGUROS.CEDENTE
											WHERE COD_CEDENTE = 026
											WITH UR";

            return query;
        }
        public string CEDENTE_NUM_TITULO { get; set; }
        public string CEDENTE_NUM_TITULO_MAX { get; set; }

        public static M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1 Execute(M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1 m_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1)
        {
            var ths = m_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_135B5_00_OBTER_SICOB_DB_SELECT_2_Query1();
            var i = 0;
            dta.CEDENTE_NUM_TITULO = result[i++].Value?.ToString();
            dta.CEDENTE_NUM_TITULO_MAX = result[i++].Value?.ToString();
            return dta;
        }

    }
}