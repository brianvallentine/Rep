using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1 : QueryBasis<M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            DATA_MOV_ABERTO
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOVIMENTO
            FROM SEGUROS.SISTEMAS
            WHERE
            IDE_SISTEMA = 'VG'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											DATA_MOV_ABERTO
											FROM SEGUROS.SISTEMAS
											WHERE
											IDE_SISTEMA = 'VG'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_DATA_MOVIMENTO { get; set; }

        public static M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1 Execute(M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1 m_010_000_LER_TSISTEMA_DB_SELECT_1_Query1)
        {
            var ths = m_010_000_LER_TSISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}