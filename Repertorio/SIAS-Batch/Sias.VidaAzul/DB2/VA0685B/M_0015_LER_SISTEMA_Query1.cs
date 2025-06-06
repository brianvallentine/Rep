using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0015_LER_SISTEMA_Query1 : QueryBasis<M_0015_LER_SISTEMA_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO,
            CURRENT DATE
            INTO :WSIST-DTMOVABE,
            :WSIST-DTCURREN
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VA'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOV_ABERTO
							,
											CURRENT DATE
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VA'";

            return query;
        }
        public string WSIST_DTMOVABE { get; set; }
        public string WSIST_DTCURREN { get; set; }

        public static M_0015_LER_SISTEMA_Query1 Execute(M_0015_LER_SISTEMA_Query1 m_0015_LER_SISTEMA_Query1)
        {
            var ths = m_0015_LER_SISTEMA_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0015_LER_SISTEMA_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0015_LER_SISTEMA_Query1();
            var i = 0;
            dta.WSIST_DTMOVABE = result[i++].Value?.ToString();
            dta.WSIST_DTCURREN = result[i++].Value?.ToString();
            return dta;
        }

    }
}