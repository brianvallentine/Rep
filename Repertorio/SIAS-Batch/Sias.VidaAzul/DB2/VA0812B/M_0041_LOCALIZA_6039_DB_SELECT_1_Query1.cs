using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0041_LOCALIZA_6039_DB_SELECT_1_Query1 : QueryBasis<M_0041_LOCALIZA_6039_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAS,
            DATA_MOVIMENTO
            INTO :MVCOM-NSAS,
            :MVCOM-DATA-MOV
            FROM SEGUROS.V0MOVCOMIS
            WHERE NSL = :MVCOM-NSL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NSAS
							,
											DATA_MOVIMENTO
											FROM SEGUROS.V0MOVCOMIS
											WHERE NSL = '{this.MVCOM_NSL}'
											WITH UR";

            return query;
        }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_DATA_MOV { get; set; }
        public string MVCOM_NSL { get; set; }

        public static M_0041_LOCALIZA_6039_DB_SELECT_1_Query1 Execute(M_0041_LOCALIZA_6039_DB_SELECT_1_Query1 m_0041_LOCALIZA_6039_DB_SELECT_1_Query1)
        {
            var ths = m_0041_LOCALIZA_6039_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0041_LOCALIZA_6039_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0041_LOCALIZA_6039_DB_SELECT_1_Query1();
            var i = 0;
            dta.MVCOM_NSAS = result[i++].Value?.ToString();
            dta.MVCOM_DATA_MOV = result[i++].Value?.ToString();
            return dta;
        }

    }
}