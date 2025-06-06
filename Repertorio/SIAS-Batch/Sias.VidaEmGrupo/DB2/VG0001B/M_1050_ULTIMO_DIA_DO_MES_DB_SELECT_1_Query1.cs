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
    public class M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1 : QueryBasis<M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT LAST_DAY(DATE(:WS-DATA-AUX))
            INTO :WS-DATA-AUX
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VG'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT LAST_DAY(DATE('{this.WS_DATA_AUX}'))
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VG'
											WITH UR";

            return query;
        }
        public string WS_DATA_AUX { get; set; }

        public static M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1 Execute(M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1 m_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1)
        {
            var ths = m_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1050_ULTIMO_DIA_DO_MES_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_AUX = result[i++].Value?.ToString();
            return dta;
        }

    }
}