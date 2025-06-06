using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_70000_00_INICIAL_DB_SELECT_1_Query1 : QueryBasis<M_70000_00_INICIAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO ,
            DATA_MOV_ABERTO
            INTO :WS-DATA-PROC ,
            :WS-DATA-PROC-AUX
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'BI'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO 
							,
											DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'BI'
											WITH UR";

            return query;
        }
        public string WS_DATA_PROC { get; set; }
        public string WS_DATA_PROC_AUX { get; set; }

        public static M_70000_00_INICIAL_DB_SELECT_1_Query1 Execute(M_70000_00_INICIAL_DB_SELECT_1_Query1 m_70000_00_INICIAL_DB_SELECT_1_Query1)
        {
            var ths = m_70000_00_INICIAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_70000_00_INICIAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_70000_00_INICIAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_PROC = result[i++].Value?.ToString();
            dta.WS_DATA_PROC_AUX = result[i++].Value?.ToString();
            return dta;
        }

    }
}