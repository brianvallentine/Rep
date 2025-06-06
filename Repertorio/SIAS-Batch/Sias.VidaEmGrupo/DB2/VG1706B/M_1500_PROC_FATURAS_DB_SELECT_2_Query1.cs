using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1706B
{
    public class M_1500_PROC_FATURAS_DB_SELECT_2_Query1 : QueryBasis<M_1500_PROC_FATURAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VAL_VENDA
            INTO
            :MOEDACOT-VAL-VENDA
            FROM
            SEGUROS.MOEDAS_COTACAO
            WHERE
            COD_MOEDA = :ENDOSSOS-COD-MOEDA-PRM
            AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VAL_VENDA
											FROM
											SEGUROS.MOEDAS_COTACAO
											WHERE
											COD_MOEDA = '{this.ENDOSSOS_COD_MOEDA_PRM}'
											AND DATA_INIVIGENCIA <= '{this.ENDOSSOS_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.ENDOSSOS_DATA_INIVIGENCIA}'";

            return query;
        }
        public string MOEDACOT_VAL_VENDA { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_COD_MOEDA_PRM { get; set; }

        public static M_1500_PROC_FATURAS_DB_SELECT_2_Query1 Execute(M_1500_PROC_FATURAS_DB_SELECT_2_Query1 m_1500_PROC_FATURAS_DB_SELECT_2_Query1)
        {
            var ths = m_1500_PROC_FATURAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_PROC_FATURAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_PROC_FATURAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOEDACOT_VAL_VENDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}