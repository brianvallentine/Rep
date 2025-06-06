using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 : QueryBasis<M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:LK-DATA-INI-PROC),
            CURRENT DATE,
            DATE(:LK-DATA-INI-PROC) - 2 MONTH,
            DATE(:LK-DATA-INI-PROC) - 13 MONTH,
            DATE(:LK-DATA-INI-PROC) + 1 MONTH,
            DATE(:LK-DATA-INI-PROC) + 20 DAYS
            INTO :SISTEMA-DTMOVABE,
            :SISTEMA-CURRENT,
            :SISTEMA-DTTERCOT,
            :SISTEMA-DTINICOT,
            :SISTEMA-DTMOV01M,
            :SISTEMA-DTMOV20D
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.LK_DATA_INI_PROC}')
							,
											CURRENT DATE
							,
											DATE('{this.LK_DATA_INI_PROC}') - 2 MONTH
							,
											DATE('{this.LK_DATA_INI_PROC}') - 13 MONTH
							,
											DATE('{this.LK_DATA_INI_PROC}') + 1 MONTH
							,
											DATE('{this.LK_DATA_INI_PROC}') + 20 DAYS
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string SISTEMA_CURRENT { get; set; }
        public string SISTEMA_DTTERCOT { get; set; }
        public string SISTEMA_DTINICOT { get; set; }
        public string SISTEMA_DTMOV01M { get; set; }
        public string SISTEMA_DTMOV20D { get; set; }
        public string LK_DATA_INI_PROC { get; set; }

        public static M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 Execute(M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 m_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1)
        {
            var ths = m_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0010_SELECT_SISTEMAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISTEMA_DTMOVABE = result[i++].Value?.ToString();
            dta.SISTEMA_CURRENT = result[i++].Value?.ToString();
            dta.SISTEMA_DTTERCOT = result[i++].Value?.ToString();
            dta.SISTEMA_DTINICOT = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV01M = result[i++].Value?.ToString();
            dta.SISTEMA_DTMOV20D = result[i++].Value?.ToString();
            return dta;
        }

    }
}