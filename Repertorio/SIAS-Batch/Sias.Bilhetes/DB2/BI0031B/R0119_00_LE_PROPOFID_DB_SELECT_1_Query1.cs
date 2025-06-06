using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R0119_00_LE_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R0119_00_LE_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIGEM_PROPOSTA
            , COD_PLANO
            INTO :PROPOFID-ORIGEM-PROPOSTA
            , :PROPOFID-COD-PLANO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :V1BILH-NUMBIL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORIGEM_PROPOSTA
											, COD_PLANO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.V1BILH_NUMBIL}'";

            return query;
        }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string V1BILH_NUMBIL { get; set; }

        public static R0119_00_LE_PROPOFID_DB_SELECT_1_Query1 Execute(R0119_00_LE_PROPOFID_DB_SELECT_1_Query1 r0119_00_LE_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r0119_00_LE_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0119_00_LE_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0119_00_LE_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}