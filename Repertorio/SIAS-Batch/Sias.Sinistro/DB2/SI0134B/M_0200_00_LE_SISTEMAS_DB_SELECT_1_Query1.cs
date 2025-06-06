using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0134B
{
    public class M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            DATA_MOV_ABERTO - 12 MONTHS,
            CURRENT_DATE
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :WHOST-DATA-INI,
            :WHOST-DT-HOJE
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'SI'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											DATA_MOV_ABERTO - 12 MONTHS
							,
											CURRENT_DATE
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'SI'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_DATA_INI { get; set; }
        public string WHOST_DT_HOJE { get; set; }

        public static M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1 Execute(M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1 m_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = m_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0200_00_LE_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.WHOST_DATA_INI = result[i++].Value?.ToString();
            dta.WHOST_DT_HOJE = result[i++].Value?.ToString();
            return dta;
        }

    }
}