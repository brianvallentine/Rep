using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0811B
{
    public class M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD,
            SIGLUNIM
            INTO :V1MOEDA-VLCRUZAD,
            :V1MOEDA-SIGLUNIM
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :RELATORI-COD-MOEDA
            AND DTINIVIG <= :SISTEMAS-DATA-MOV-ABERTO
            AND DTTERVIG >= :SISTEMAS-DATA-MOV-ABERTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
							,
											SIGLUNIM
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.RELATORI_COD_MOEDA}'
											AND DTINIVIG <= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND DTTERVIG >= '{this.SISTEMAS_DATA_MOV_ABERTO}'";

            return query;
        }
        public string V1MOEDA_VLCRUZAD { get; set; }
        public string V1MOEDA_SIGLUNIM { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_COD_MOEDA { get; set; }

        public static M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 Execute(M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOEDA_VLCRUZAD = result[i++].Value?.ToString();
            dta.V1MOEDA_SIGLUNIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}