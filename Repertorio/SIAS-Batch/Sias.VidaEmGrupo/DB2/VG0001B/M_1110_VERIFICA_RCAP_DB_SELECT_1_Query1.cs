using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 : QueryBasis<M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            NUM_RCAP
            INTO :RCAPS-COD-FONTE,
            :RCAPS-NUM-RCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO = :RCAPS-NUM-TITULO
            AND (COD_OPERACAO BETWEEN 100 AND 199
            OR COD_OPERACAO BETWEEN 300 AND 399)
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											NUM_RCAP
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO = '{this.RCAPS_NUM_TITULO}'
											AND (COD_OPERACAO BETWEEN 100 AND 199
											OR COD_OPERACAO BETWEEN 300 AND 399)
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }

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
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}