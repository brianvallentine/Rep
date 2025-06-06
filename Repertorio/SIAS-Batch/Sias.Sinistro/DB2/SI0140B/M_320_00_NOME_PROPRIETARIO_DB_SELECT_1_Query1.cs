using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0140B
{
    public class M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1 : QueryBasis<M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT
            A.PROPRIET
            INTO :V0AUTO-PROPRIET
            FROM SEGUROS.V0AUTOAPOL A
            WHERE A.NUM_APOLICE = :V0MEST-NUM-APOLICE
            AND A.NRITEM = :V0AUTO1-NUM-ITEM
            AND A.SITUACAO <> '2'
            ORDER BY A.PROPRIET
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT
											A.PROPRIET
											FROM SEGUROS.V0AUTOAPOL A
											WHERE A.NUM_APOLICE = '{this.V0MEST_NUM_APOLICE}'
											AND A.NRITEM = '{this.V0AUTO1_NUM_ITEM}'
											AND A.SITUACAO <> '2'
											ORDER BY A.PROPRIET";

            return query;
        }
        public string V0AUTO_PROPRIET { get; set; }
        public string V0MEST_NUM_APOLICE { get; set; }
        public string V0AUTO1_NUM_ITEM { get; set; }

        public static M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1 Execute(M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1 m_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1)
        {
            var ths = m_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_320_00_NOME_PROPRIETARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0AUTO_PROPRIET = result[i++].Value?.ToString();
            return dta;
        }

    }
}