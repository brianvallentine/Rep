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
    public class M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            DATA_MOV_ABERTO - 1 MONTH,
            DATA_MOV_ABERTO - 6 MONTH
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-ANTERIOR,
            :SISTEMAS-DATA-MOV-6MONTH
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VG'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											DATA_MOV_ABERTO - 1 MONTH
							,
											DATA_MOV_ABERTO - 6 MONTH
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VG'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_DATA_ANTERIOR { get; set; }
        public string SISTEMAS_DATA_MOV_6MONTH { get; set; }

        public static M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1 m_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = m_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_ANTERIOR = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_6MONTH = result[i++].Value?.ToString();
            return dta;
        }

    }
}